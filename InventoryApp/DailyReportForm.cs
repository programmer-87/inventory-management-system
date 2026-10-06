using InventoryApp.Classes;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace InventoryApp
{
    public partial class DailyReportForm : Form
    {
        public DailyReportForm()
        {
            InitializeComponent();
        }

        private void DailyReportForm_Load(object sender, EventArgs e)
        {
            dtpDate.Value = DateTime.Now;
            LoadReport();
        }

        // ---------- بارگذاری گزارش ----------
        private void LoadReport()
        {
            DateTime date = dtpDate.Value.Date;

            LoadSummary(date);
            LoadSales(date);
            LoadTopProducts(date);
        }

        // ---------- خلاصه آمار ----------
        private void LoadSummary(DateTime date)
        {
            string query = @"
                SELECT 
                    COUNT(*) AS SaleCount,
                    ISNULL(SUM(TotalAmount), 0) AS TotalAmount,
                    ISNULL(SUM(Discount), 0) AS TotalDiscount,
                    ISNULL(SUM(FinalAmount), 0) AS TotalNet
                FROM Sales
                WHERE SaleDate >= @date AND SaleDate < DATEADD(DAY, 1, @date)";

            SqlParameter[] param = { new SqlParameter("@date", date) };
            DataTable dt = DatabaseConnection.ExecuteQuery(query, param);

            if (dt.Rows.Count > 0)
            {
                DataRow r = dt.Rows[0];
                int count = Convert.ToInt32(r["SaleCount"]);
                decimal total = Convert.ToDecimal(r["TotalAmount"]);
                decimal discount = Convert.ToDecimal(r["TotalDiscount"]);
                decimal net = Convert.ToDecimal(r["TotalNet"]);
                decimal avg = count > 0 ? net / count : 0;

                lblCountValue.Text = count.ToString("N0");
                lblTotalValue.Text = total.ToString("N0") + " ریال";
                lblDiscountValue.Text = discount.ToString("N0") + " ریال";
                lblNetValue.Text = net.ToString("N0") + " ریال";
                lblAvgValue.Text = avg.ToString("N0") + " ریال";
            }
        }

        // ---------- فاکتورهای روز ----------
        private void LoadSales(DateTime date)
        {
            string query = @"
                SELECT s.SaleID,
                       s.SaleDate,
                       ISNULL(c.FullName, N'—') AS CustomerName,
                       ISNULL(u.FullName, N'—') AS UserName,
                       s.TotalAmount,
                       s.Discount,
                       s.FinalAmount
                FROM Sales s
                LEFT JOIN Customers c ON s.CustomerID = c.CustomerID
                LEFT JOIN Users u ON s.UserID = u.UserID
                WHERE s.SaleDate >= @date AND s.SaleDate < DATEADD(DAY, 1, @date)
                ORDER BY s.SaleID DESC";

            SqlParameter[] param = { new SqlParameter("@date", date) };
            DataTable dt = DatabaseConnection.ExecuteQuery(query, param);
            dgvSales.DataSource = dt;

            if (dgvSales.Columns.Count > 0)
            {
                dgvSales.Columns["SaleID"].HeaderText = "کد";
                dgvSales.Columns["SaleDate"].HeaderText = "زمان";
                dgvSales.Columns["CustomerName"].HeaderText = "مشتری";
                dgvSales.Columns["UserName"].HeaderText = "کاربر";
                dgvSales.Columns["TotalAmount"].HeaderText = "جمع کل";
                dgvSales.Columns["Discount"].HeaderText = "تخفیف";
                dgvSales.Columns["FinalAmount"].HeaderText = "قابل پرداخت";

                dgvSales.Columns["SaleID"].Width = 60;
                dgvSales.Columns["SaleDate"].Width = 120;
                dgvSales.Columns["TotalAmount"].Width = 110;
                dgvSales.Columns["Discount"].Width = 90;
                dgvSales.Columns["FinalAmount"].Width = 120;

                dgvSales.Columns["SaleDate"].DefaultCellStyle.Format = "HH:mm";
                dgvSales.Columns["TotalAmount"].DefaultCellStyle.Format = "N0";
                dgvSales.Columns["Discount"].DefaultCellStyle.Format = "N0";
                dgvSales.Columns["FinalAmount"].DefaultCellStyle.Format = "N0";
            }
        }

        // ---------- پرفروش‌ترین محصولات ----------
        private void LoadTopProducts(DateTime date)
        {
            string query = @"
                SELECT TOP 10
                       p.ProductName,
                       SUM(sd.Quantity) AS TotalQuantity,
                       SUM(sd.TotalPrice) AS TotalRevenue
                FROM SaleDetails sd
                INNER JOIN Sales s ON sd.SaleID = s.SaleID
                INNER JOIN Products p ON sd.ProductID = p.ProductID
                WHERE s.SaleDate >= @date AND s.SaleDate < DATEADD(DAY, 1, @date)
                GROUP BY p.ProductName
                ORDER BY TotalQuantity DESC";

            SqlParameter[] param = { new SqlParameter("@date", date) };
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

        private void btnToday_Click(object sender, EventArgs e)
        {
            dtpDate.Value = DateTime.Now;
            LoadReport();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                // خلاصه
                string summary = string.Format(
                    "تعداد فاکتور: {0}   |   جمع فروش: {1} ریال   |   فروش خالص: {2} ریال",
                    lblCountValue.Text, lblTotalValue.Text, lblNetValue.Text);

                // جدول فاکتورها با تاریخ فارسی
                DataTable dtSales = new DataTable();
                dtSales.Columns.Add("کد");
                dtSales.Columns.Add("زمان");
                dtSales.Columns.Add("مشتری");
                dtSales.Columns.Add("مبلغ نهایی");

                foreach (DataGridViewRow row in dgvSales.Rows)
                {
                    dtSales.Rows.Add(
                        row.Cells["SaleID"].Value,
                        Convert.ToDateTime(row.Cells["SaleDate"].Value).ToString("HH:mm"),
                        row.Cells["CustomerName"].Value,
                        Convert.ToDecimal(row.Cells["FinalAmount"].Value).ToString("N0"));
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

                // تاریخ شمسی
                PersianCalendar pc = new PersianCalendar();
                DateTime d = dtpDate.Value;
                string title = string.Format("گزارش فروش روزانه — {0}/{1}/{2}",
                    pc.GetYear(d), pc.GetMonth(d).ToString("00"), pc.GetDayOfMonth(d).ToString("00"));

                ReportPrinter printer = new ReportPrinter(
                    ReportPrinter.ReportType.DailySales, title, dtSales, dtTop, summary);
                printer.ShowPreview();
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا:\n" + ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}