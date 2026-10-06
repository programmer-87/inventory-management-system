using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using InventoryApp.Classes;

namespace InventoryApp
{
    public partial class SalesListForm : Form
    {
        private int selectedSaleID = 0;

        public SalesListForm()
        {
            InitializeComponent();
        }

        private void SalesListForm_Load(object sender, EventArgs e)
        {
            // تنظیم تاریخ‌ها: از اول ماه تا امروز
            dtpFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpTo.Value = DateTime.Now;

            LoadSales();
        }

        // ---------- بارگذاری فاکتورها ----------
        private void LoadSales()
        {
            string query = @"
                SELECT s.SaleID,
                       s.SaleDate,
                       ISNULL(c.FullName, N'مشتری حذف شده') AS CustomerName,
                       ISNULL(u.FullName, N'-') AS UserName,
                       s.TotalAmount,
                       s.Discount,
                       s.FinalAmount
                FROM Sales s
                LEFT JOIN Customers c ON s.CustomerID = c.CustomerID
                LEFT JOIN Users u ON s.UserID = u.UserID
                WHERE s.SaleDate >= @from AND s.SaleDate < DATEADD(DAY, 1, @to)
                  AND (@customer = N'' OR c.FullName LIKE N'%' + @customer + N'%')
                ORDER BY s.SaleID DESC";

            SqlParameter[] param =
            {
                new SqlParameter("@from", dtpFrom.Value.Date),
                new SqlParameter("@to", dtpTo.Value.Date),
                new SqlParameter("@customer", txtCustomerFilter.Text.Trim())
            };

            DataTable dt = DatabaseConnection.ExecuteQuery(query, param);
            dgvSales.DataSource = dt;

            // تنظیم هدر ستون‌ها
            if (dgvSales.Columns.Count > 0)
            {
                dgvSales.Columns["SaleID"].HeaderText = "کد فاکتور";
                dgvSales.Columns["SaleDate"].HeaderText = "تاریخ";
                dgvSales.Columns["CustomerName"].HeaderText = "مشتری";
                dgvSales.Columns["UserName"].HeaderText = "کاربر";
                dgvSales.Columns["TotalAmount"].HeaderText = "جمع کل";
                dgvSales.Columns["Discount"].HeaderText = "تخفیف";
                dgvSales.Columns["FinalAmount"].HeaderText = "قابل پرداخت";

                dgvSales.Columns["SaleID"].Width = 80;
                dgvSales.Columns["SaleDate"].Width = 140;
                dgvSales.Columns["TotalAmount"].Width = 110;
                dgvSales.Columns["Discount"].Width = 90;
                dgvSales.Columns["FinalAmount"].Width = 120;

                // تبدیل اعداد به فرمت با کاما
                dgvSales.Columns["TotalAmount"].DefaultCellStyle.Format = "N0";
                dgvSales.Columns["Discount"].DefaultCellStyle.Format = "N0";
                dgvSales.Columns["FinalAmount"].DefaultCellStyle.Format = "N0";

                // تاریخ به فرمت فارسی
                dgvSales.Columns["SaleDate"].DefaultCellStyle.Format = "yyyy/MM/dd HH:mm";
            }

            UpdateSummary();
        }

        // ---------- محاسبه جمع کل ----------
        private void UpdateSummary()
        {
            decimal total = 0;
            int count = dgvSales.Rows.Count;

            foreach (DataGridViewRow row in dgvSales.Rows)
            {
                if (row.Cells["FinalAmount"].Value != null)
                    total += Convert.ToDecimal(row.Cells["FinalAmount"].Value);
            }

            lblCountValue.Text = count.ToString("N0");
            lblTotalValue.Text = total.ToString("N0") + " ریال";
        }

        // ---------- اعمال فیلتر ----------
        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (dtpFrom.Value > dtpTo.Value)
            {
                MessageBox.Show("تاریخ شروع نمی‌تواند بعد از تاریخ پایان باشد.", "خطا",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            LoadSales();
        }

        // ---------- پاک کردن فیلتر ----------
        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            dtpFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpTo.Value = DateTime.Now;
            txtCustomerFilter.Clear();
            LoadSales();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadSales();
        }

        // ---------- انتخاب فاکتور ----------
        private void dgvSales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            selectedSaleID = Convert.ToInt32(dgvSales.Rows[e.RowIndex].Cells["SaleID"].Value);
        }

        // ---------- مشاهده جزئیات ----------
        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (selectedSaleID == 0)
            {
                MessageBox.Show("ابتدا یک فاکتور انتخاب کنید.", "هشدار",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaleDetailForm form = new SaleDetailForm(selectedSaleID);
            form.ShowDialog();
        }

        // ---------- حذف فاکتور ----------
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedSaleID == 0)
            {
                MessageBox.Show("ابتدا یک فاکتور انتخاب کنید.", "هشدار",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show(
                $"آیا از حذف فاکتور شماره {selectedSaleID} مطمئن هستید؟\n\n" +
                "⚠️ توجه: با حذف فاکتور، موجودی محصولات به انبار بازمی‌گردد.",
                "تأیید حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                // ۱) برگرداندن موجودی محصولات
                string itemsQuery = "SELECT ProductID, Quantity FROM SaleDetails WHERE SaleID = @sid";
                SqlParameter[] itemsParam = { new SqlParameter("@sid", selectedSaleID) };
                DataTable items = DatabaseConnection.ExecuteQuery(itemsQuery, itemsParam);

                foreach (DataRow row in items.Rows)
                {
                    int productID = Convert.ToInt32(row["ProductID"]);
                    int qty = Convert.ToInt32(row["Quantity"]);

                    // برگرداندن موجودی
                    string updateQuery = "UPDATE Products SET Quantity = Quantity + @q WHERE ProductID = @pid";
                    SqlParameter[] updateParam =
                    {
                        new SqlParameter("@q", qty),
                        new SqlParameter("@pid", productID)
                    };
                    DatabaseConnection.ExecuteNonQuery(updateQuery, updateParam);

                    // ثبت حرکت انبار (IN)
                    string moveQuery = @"
                        INSERT INTO StockMovements (ProductID, MovementType, Quantity, Description)
                        VALUES (@pid, 'IN', @q, @desc)";
                    SqlParameter[] moveParam =
                    {
                        new SqlParameter("@pid", productID),
                        new SqlParameter("@q", qty),
                        new SqlParameter("@desc", $"حذف فاکتور #{selectedSaleID}")
                    };
                    DatabaseConnection.ExecuteNonQuery(moveQuery, moveParam);
                }

                // ۲) حذف فاکتور (SaleDetails خودکار با CASCADE حذف میشه)
                string deleteQuery = "DELETE FROM Sales WHERE SaleID = @sid";
                SqlParameter[] deleteParam = { new SqlParameter("@sid", selectedSaleID) };

                if (DatabaseConnection.ExecuteNonQuery(deleteQuery, deleteParam) > 0)
                {
                    MessageBox.Show("✅ فاکتور حذف شد و موجودی به انبار برگشت.", "موفق",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    selectedSaleID = 0;
                    LoadSales();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا در حذف فاکتور:\n" + ex.Message, "خطا",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---------- چاپ فاکتور ----------
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (selectedSaleID == 0)
            {
                MessageBox.Show("ابتدا یک فاکتور انتخاب کنید.", "هشدار",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                InvoicePrinter printer = new InvoicePrinter(selectedSaleID);
                printer.ShowPreview();
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا در آماده‌سازی چاپ:\n" + ex.Message, "خطا",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}