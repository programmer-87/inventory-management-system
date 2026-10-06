using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;
using InventoryApp.Classes;

namespace InventoryApp
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            // پیام خوش‌آمدگویی
            lblWelcome.Text = "خوش آمدید، " + Session.FullName + " 👋";

            // تاریخ شمسی
            PersianCalendar pc = new PersianCalendar();
            DateTime now = DateTime.Now;
            string[] days = { "یکشنبه", "دوشنبه", "سه‌شنبه", "چهارشنبه", "پنجشنبه", "جمعه", "شنبه" };
            string dayName = days[(int)pc.GetDayOfWeek(now)];

            lblTodayDate.Text = string.Format("📅 {0}، {1}/{2}/{3}",
                dayName,
                pc.GetYear(now),
                pc.GetMonth(now).ToString("00"),
                pc.GetDayOfMonth(now).ToString("00"));

            LoadAllStats();
        }

        // ---------- بارگذاری همه آمار ----------
        private void LoadAllStats()
        {
            LoadCards();
            LoadTopProducts();
            LoadLowStock();
            LoadRecentSales();
        }

        // ---------- کارت‌های خلاصه ----------
        private void LoadCards()
        {
            try
            {
                // تعداد محصولات
                object prodCount = DatabaseConnection.ExecuteScalar(
                    "SELECT COUNT(*) FROM Products");
                lblProductsValue.Text = prodCount?.ToString() ?? "0";

                // فروش امروز
                object salesToday = DatabaseConnection.ExecuteScalar(
                    @"SELECT ISNULL(SUM(FinalAmount), 0) FROM Sales 
                      WHERE CAST(SaleDate AS DATE) = CAST(GETDATE() AS DATE)");
                decimal salesAmt = Convert.ToDecimal(salesToday);
                lblSalesTodayValue.Text = salesAmt.ToString("N0") + " ریال";

                // فاکتورهای امروز
                object invoiceCount = DatabaseConnection.ExecuteScalar(
                    @"SELECT COUNT(*) FROM Sales 
                      WHERE CAST(SaleDate AS DATE) = CAST(GETDATE() AS DATE)");
                lblInvoicesValue.Text = invoiceCount?.ToString() ?? "0";

                // تعداد مشتریان
                object custCount = DatabaseConnection.ExecuteScalar(
                    "SELECT COUNT(*) FROM Customers");
                lblCustomersValue.Text = custCount?.ToString() ?? "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا در بارگذاری آمار:\n" + ex.Message, "خطا");
            }
        }

        // ---------- پرفروش‌ترین محصولات هفته ----------
        private void LoadTopProducts()
        {
            string query = @"
                SELECT TOP 5
                    p.ProductName,
                    SUM(sd.Quantity) AS TotalQty
                FROM SaleDetails sd
                INNER JOIN Sales s ON sd.SaleID = s.SaleID
                INNER JOIN Products p ON sd.ProductID = p.ProductID
                WHERE s.SaleDate >= DATEADD(DAY, -7, GETDATE())
                GROUP BY p.ProductName
                ORDER BY TotalQty DESC";

            DataTable dt = DatabaseConnection.ExecuteQuery(query);
            dgvTopProducts.DataSource = dt;

            if (dgvTopProducts.Columns.Count > 0)
            {
                dgvTopProducts.Columns["ProductName"].HeaderText = "محصول";
                dgvTopProducts.Columns["TotalQty"].HeaderText = "تعداد فروش";
            }
        }

        // ---------- محصولات رو به اتمام ----------
        private void LoadLowStock()
        {
            string query = @"
                SELECT TOP 5
                    ProductName,
                    Quantity,
                    MinQuantity
                FROM Products
                WHERE Quantity <= MinQuantity
                ORDER BY Quantity ASC";

            DataTable dt = DatabaseConnection.ExecuteQuery(query);
            dgvLowStock.DataSource = dt;

            if (dgvLowStock.Columns.Count > 0)
            {
                dgvLowStock.Columns["ProductName"].HeaderText = "محصول";
                dgvLowStock.Columns["Quantity"].HeaderText = "موجودی";
                dgvLowStock.Columns["MinQuantity"].HeaderText = "حد";

                // رنگ‌بندی
                foreach (DataGridViewRow row in dgvLowStock.Rows)
                {
                    int qty = Convert.ToInt32(row.Cells["Quantity"].Value);
                    if (qty == 0)
                    {
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.LightCoral;
                        row.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.MistyRose;
                    }
                }
            }
        }

        // ---------- آخرین فاکتورها ----------
        private void LoadRecentSales()
        {
            string query = @"
                SELECT TOP 5
                    s.SaleID,
                    s.SaleDate,
                    ISNULL(c.FullName, N'—') AS CustomerName,
                    s.FinalAmount
                FROM Sales s
                LEFT JOIN Customers c ON s.CustomerID = c.CustomerID
                ORDER BY s.SaleID DESC";

            DataTable dt = DatabaseConnection.ExecuteQuery(query);

            // اضافه کردن ستون زمان
            dt.Columns.Add("TimeOnly", typeof(string));
            foreach (DataRow row in dt.Rows)
            {
                DateTime d = Convert.ToDateTime(row["SaleDate"]);
                row["TimeOnly"] = d.ToString("HH:mm");
            }

            dgvRecentSales.DataSource = dt;

            if (dgvRecentSales.Columns.Count > 0)
            {
                dgvRecentSales.Columns["SaleID"].HeaderText = "کد";
                dgvRecentSales.Columns["SaleDate"].Visible = false;
                dgvRecentSales.Columns["CustomerName"].HeaderText = "مشتری";
                dgvRecentSales.Columns["FinalAmount"].HeaderText = "مبلغ";

                dgvRecentSales.Columns["TimeOnly"].HeaderText = "ساعت";
                dgvRecentSales.Columns["TimeOnly"].DisplayIndex = 1;

                dgvRecentSales.Columns["FinalAmount"].DefaultCellStyle.Format = "N0";
            }
        }

        // ---------- دکمه‌ها ----------
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAllStats();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            // باز کردن گزارش روزانه
            DailyReportForm form = new DailyReportForm();
            form.MdiParent = this.MdiParent;
            form.Show();
        }

        private void btnNewSale_Click(object sender, EventArgs e)
        {
            // باز کردن فروش جدید
            SalesForm form = new SalesForm();
            form.MdiParent = this.MdiParent;
            form.Show();
        }
    }
}