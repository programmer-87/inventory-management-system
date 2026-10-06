using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;
using InventoryApp.Classes;

namespace InventoryApp
{
    public partial class MonthlyReportForm : Form
    {
        private string[] monthNames = new string[]
        {
            "فروردین", "اردیبهشت", "خرداد",
            "تیر", "مرداد", "شهریور",
            "مهر", "آبان", "آذر",
            "دی", "بهمن", "اسفند"
        };

        public MonthlyReportForm()
        {
            InitializeComponent();
        }

        private void MonthlyReportForm_Load(object sender, EventArgs e)
        {
            // پر کردن ComboBox ماه
            cmbMonth.Items.Clear();
            cmbMonth.Items.AddRange(monthNames);
            cmbMonth.SelectedIndex = 0;

            // تنظیم سال و ماه جاری
            SetCurrentMonth();

            LoadReport();
        }

        // ---------- تنظیم ماه و سال جاری ----------
        private void SetCurrentMonth()
        {
            PersianCalendar pc = new PersianCalendar();
            DateTime now = DateTime.Now;
            numYear.Value = pc.GetYear(now);
            cmbMonth.SelectedIndex = pc.GetMonth(now) - 1;
        }

        // ---------- محاسبه بازه تاریخ میلادی از شمسی ----------
        private void GetDateRange(int persianYear, int persianMonth,
            out DateTime startDate, out DateTime endDate)
        {
            PersianCalendar pc = new PersianCalendar();

            // اول ماه شمسی
            startDate = pc.ToDateTime(persianYear, persianMonth, 1, 0, 0, 0, 0);

            // اول ماه بعدی (برای بازه)
            int nextMonth = persianMonth + 1;
            int nextYear = persianYear;
            if (nextMonth > 12)
            {
                nextMonth = 1;
                nextYear++;
            }
            endDate = pc.ToDateTime(nextYear, nextMonth, 1, 0, 0, 0, 0);
        }

        // ---------- بارگذاری گزارش ----------
        private void LoadReport()
        {
            if (cmbMonth.SelectedIndex == -1) return;

            int year = (int)numYear.Value;
            int month = cmbMonth.SelectedIndex + 1;

            DateTime startDate, endDate;
            GetDateRange(year, month, out startDate, out endDate);

            LoadSummary(startDate, endDate);
            LoadDailySales(startDate, endDate);
            LoadTopProducts(startDate, endDate);
        }
        //خلاصه آمار
        private void LoadSummary(DateTime startDate, DateTime endDate)
        {
            // آمار کلی
            string query = @"
        SELECT 
            COUNT(*) AS SaleCount,
            ISNULL(SUM(TotalAmount), 0) AS TotalAmount,
            ISNULL(SUM(Discount), 0) AS TotalDiscount,
            ISNULL(SUM(FinalAmount), 0) AS TotalNet
        FROM Sales
        WHERE SaleDate >= @start AND SaleDate < @end";

            SqlParameter[] param1 =
            {
        new SqlParameter("@start", startDate),
        new SqlParameter("@end", endDate)
    };

            DataTable dt = DatabaseConnection.ExecuteQuery(query, param1);

            if (dt.Rows.Count > 0)
            {
                DataRow r = dt.Rows[0];
                lblCountValue.Text = Convert.ToInt32(r["SaleCount"]).ToString("N0");
                lblTotalValue.Text = Convert.ToDecimal(r["TotalAmount"]).ToString("N0") + " ریال";
                lblDiscountValue.Text = Convert.ToDecimal(r["TotalDiscount"]).ToString("N0") + " ریال";
                lblNetValue.Text = Convert.ToDecimal(r["TotalNet"]).ToString("N0") + " ریال";
            }

            // بهترین روز
            string bestDayQuery = @"
        SELECT TOP 1 
            CAST(SaleDate AS DATE) AS SaleDay,
            SUM(FinalAmount) AS DayTotal
        FROM Sales
        WHERE SaleDate >= @start AND SaleDate < @end
        GROUP BY CAST(SaleDate AS DATE)
        ORDER BY DayTotal DESC";

            SqlParameter[] param2 =
            {
        new SqlParameter("@start", startDate),
        new SqlParameter("@end", endDate)
    };

            DataTable dtDay = DatabaseConnection.ExecuteQuery(bestDayQuery, param2);
            if (dtDay.Rows.Count > 0)
            {
                DateTime bestDate = Convert.ToDateTime(dtDay.Rows[0]["SaleDay"]);
                PersianCalendar pc = new PersianCalendar();
                string bestDayStr = string.Format("{0}/{1}/{2} — {3:N0} ریال",
                    pc.GetYear(bestDate),
                    pc.GetMonth(bestDate).ToString("00"),
                    pc.GetDayOfMonth(bestDate).ToString("00"),
                    Convert.ToDecimal(dtDay.Rows[0]["DayTotal"]));
                lblBestDayValue.Text = bestDayStr;
            }
            else
            {
                lblBestDayValue.Text = "—";
            }

            // بهترین فروشنده
            string bestSellerQuery = @"
        SELECT TOP 1 
            ISNULL(u.FullName, N'—') AS UserName,
            SUM(s.FinalAmount) AS TotalSales
        FROM Sales s
        LEFT JOIN Users u ON s.UserID = u.UserID
        WHERE s.SaleDate >= @start AND s.SaleDate < @end
        GROUP BY u.FullName
        ORDER BY TotalSales DESC";

            SqlParameter[] param3 =
            {
        new SqlParameter("@start", startDate),
        new SqlParameter("@end", endDate)
    };

            DataTable dtSeller = DatabaseConnection.ExecuteQuery(bestSellerQuery, param3);
            if (dtSeller.Rows.Count > 0)
            {
                lblBestSellerValue.Text = string.Format("{0} — {1:N0} ریال",
                    dtSeller.Rows[0]["UserName"],
                    Convert.ToDecimal(dtSeller.Rows[0]["TotalSales"]));
            }
            else
            {
                lblBestSellerValue.Text = "—";
            }
        }

        // ---------- فروش روزانه ماه ----------
        private void LoadDailySales(DateTime startDate, DateTime endDate)
        {
            string query = @"
                SELECT 
                    CAST(SaleDate AS DATE) AS SaleDay,
                    COUNT(*) AS SaleCount,
                    SUM(TotalAmount) AS TotalAmount,
                    SUM(Discount) AS TotalDiscount,
                    SUM(FinalAmount) AS TotalNet
                FROM Sales
                WHERE SaleDate >= @start AND SaleDate < @end
                GROUP BY CAST(SaleDate AS DATE)
                ORDER BY SaleDay";

            SqlParameter[] param =
            {
                new SqlParameter("@start", startDate),
                new SqlParameter("@end", endDate)
            };

            DataTable dt = DatabaseConnection.ExecuteQuery(query, param);

            // اضافه کردن ستون شمسی
            dt.Columns.Add("PersianDate", typeof(string));
            PersianCalendar pc = new PersianCalendar();

            foreach (DataRow row in dt.Rows)
            {
                DateTime d = Convert.ToDateTime(row["SaleDay"]);
                row["PersianDate"] = string.Format("{0}/{1}/{2}",
                    pc.GetYear(d),
                    pc.GetMonth(d).ToString("00"),
                    pc.GetDayOfMonth(d).ToString("00"));
            }

            dgvDailySales.DataSource = dt;

            if (dgvDailySales.Columns.Count > 0)
            {
                // ترتیب ستون‌ها: اول شمسی
                dgvDailySales.Columns["SaleDay"].Visible = false;
                dgvDailySales.Columns["PersianDate"].DisplayIndex = 0;

                dgvDailySales.Columns["PersianDate"].HeaderText = "تاریخ";
                dgvDailySales.Columns["SaleCount"].HeaderText = "تعداد فاکتور";
                dgvDailySales.Columns["TotalAmount"].HeaderText = "جمع کل";
                dgvDailySales.Columns["TotalDiscount"].HeaderText = "تخفیف";
                dgvDailySales.Columns["TotalNet"].HeaderText = "فروش خالص";

                dgvDailySales.Columns["SaleCount"].Width = 100;
                dgvDailySales.Columns["TotalAmount"].DefaultCellStyle.Format = "N0";
                dgvDailySales.Columns["TotalDiscount"].DefaultCellStyle.Format = "N0";
                dgvDailySales.Columns["TotalNet"].DefaultCellStyle.Format = "N0";
            }
        }

        // ---------- پرفروش‌ترین محصولات ماه ----------
        private void LoadTopProducts(DateTime startDate, DateTime endDate)
        {
            string query = @"
                SELECT TOP 15
                    p.ProductName,
                    SUM(sd.Quantity) AS TotalQuantity,
                    SUM(sd.TotalPrice) AS TotalRevenue
                FROM SaleDetails sd
                INNER JOIN Sales s ON sd.SaleID = s.SaleID
                INNER JOIN Products p ON sd.ProductID = p.ProductID
                WHERE s.SaleDate >= @start AND s.SaleDate < @end
                GROUP BY p.ProductName
                ORDER BY TotalQuantity DESC";

            SqlParameter[] param =
            {
                new SqlParameter("@start", startDate),
                new SqlParameter("@end", endDate)
            };

            DataTable dt = DatabaseConnection.ExecuteQuery(query, param);
            dgvTopProducts.DataSource = dt;

            if (dgvTopProducts.Columns.Count > 0)
            {
                dgvTopProducts.Columns["ProductName"].HeaderText = "نام محصول";
                dgvTopProducts.Columns["TotalQuantity"].HeaderText = "تعداد فروش";
                dgvTopProducts.Columns["TotalRevenue"].HeaderText = "جمع مبلغ (ریال)";

                dgvTopProducts.Columns["TotalQuantity"].Width = 120;
                dgvTopProducts.Columns["TotalRevenue"].Width = 180;
                dgvTopProducts.Columns["TotalRevenue"].DefaultCellStyle.Format = "N0";
            }
        }

        // ---------- دکمه‌ها ----------
        private void btnShow_Click(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void btnThisMonth_Click(object sender, EventArgs e)
        {
            SetCurrentMonth();
            LoadReport();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                string summary = string.Format(
                    "تعداد فاکتور: {0}   |   جمع فروش: {1}   |   فروش خالص: {2}   |   بهترین روز: {3}",
                    lblCountValue.Text, lblTotalValue.Text, lblNetValue.Text, lblBestDayValue.Text);

                // جدول فروش روزانه
                DataTable dtDaily = new DataTable();
                dtDaily.Columns.Add("تاریخ");
                dtDaily.Columns.Add("تعداد فاکتور");
                dtDaily.Columns.Add("جمع کل");
                dtDaily.Columns.Add("تخفیف");
                dtDaily.Columns.Add("فروش خالص");

                foreach (DataGridViewRow row in dgvDailySales.Rows)
                {
                    dtDaily.Rows.Add(
                        row.Cells["PersianDate"].Value,
                        row.Cells["SaleCount"].Value,
                        Convert.ToDecimal(row.Cells["TotalAmount"].Value).ToString("N0"),
                        Convert.ToDecimal(row.Cells["TotalDiscount"].Value).ToString("N0"),
                        Convert.ToDecimal(row.Cells["TotalNet"].Value).ToString("N0"));
                }

                // جدول پرفروش‌ترین محصولات
                DataTable dtTop = new DataTable();
                dtTop.Columns.Add("محصول");
                dtTop.Columns.Add("تعداد فروش");
                dtTop.Columns.Add("جمع مبلغ (ریال)");

                foreach (DataGridViewRow row in dgvTopProducts.Rows)
                {
                    dtTop.Rows.Add(
                        row.Cells["ProductName"].Value,
                        row.Cells["TotalQuantity"].Value,
                        Convert.ToDecimal(row.Cells["TotalRevenue"].Value).ToString("N0"));
                }

                string title = string.Format("گزارش فروش ماهانه — {0} {1}",
                    cmbMonth.SelectedItem, numYear.Value);

                ReportPrinter printer = new ReportPrinter(
                    ReportPrinter.ReportType.MonthlySales, title, dtDaily, dtTop, summary);
                printer.ShowPreview();
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا:\n" + ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}