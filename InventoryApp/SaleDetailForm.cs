using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using InventoryApp.Classes;

namespace InventoryApp
{
    public partial class SaleDetailForm : Form
    {
        private int saleID;

        public SaleDetailForm(int saleID)
        {
            InitializeComponent();
            this.saleID = saleID;
        }

        private void SaleDetailForm_Load(object sender, EventArgs e)
        {
            LoadSaleInfo();
            LoadSaleItems();
        }

        // ---------- اطلاعات کلی فاکتور ----------
        private void LoadSaleInfo()
        {
            string query = @"
                SELECT s.SaleID, s.SaleDate, 
                       ISNULL(c.FullName, N'مشتری حذف شده') AS CustomerName,
                       ISNULL(c.Phone, N'-') AS Phone,
                       ISNULL(u.FullName, N'-') AS UserName,
                       s.TotalAmount, s.Discount, s.FinalAmount
                FROM Sales s
                LEFT JOIN Customers c ON s.CustomerID = c.CustomerID
                LEFT JOIN Users u ON s.UserID = u.UserID
                WHERE s.SaleID = @sid";

            SqlParameter[] param = { new SqlParameter("@sid", saleID) };
            DataTable dt = DatabaseConnection.ExecuteQuery(query, param);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("فاکتور پیدا نشد.", "خطا");
                this.Close();
                return;
            }

            DataRow r = dt.Rows[0];
            this.Text = $"جزئیات فاکتور #{saleID}";

            lblInvoiceNumber.Text = "شماره فاکتور: " + r["SaleID"];
            lblDate.Text = "تاریخ: " + Convert.ToDateTime(r["SaleDate"]).ToString("yyyy/MM/dd HH:mm");
            lblCustomer.Text = "مشتری: " + r["CustomerName"];
            lblPhone.Text = "تلفن: " + r["Phone"];
            lblUser.Text = "کاربر: " + r["UserName"];
            lblTotal.Text = "جمع کل: " + Convert.ToDecimal(r["TotalAmount"]).ToString("N0") + " ریال";
            lblDiscount.Text = "تخفیف: " + Convert.ToDecimal(r["Discount"]).ToString("N0") + " ریال";
            lblFinal.Text = "قابل پرداخت: " + Convert.ToDecimal(r["FinalAmount"]).ToString("N0") + " ریال";
        }

        // ---------- اقلام فاکتور ----------
        private void LoadSaleItems()
        {
            string query = @"
                SELECT p.ProductName, sd.Quantity, sd.UnitPrice, sd.TotalPrice
                FROM SaleDetails sd
                INNER JOIN Products p ON sd.ProductID = p.ProductID
                WHERE sd.SaleID = @sid
                ORDER BY sd.SaleDetailID";

            SqlParameter[] param = { new SqlParameter("@sid", saleID) };
            DataTable dt = DatabaseConnection.ExecuteQuery(query, param);
            dgvItems.DataSource = dt;

            if (dgvItems.Columns.Count > 0)
            {
                dgvItems.Columns["ProductName"].HeaderText = "نام کالا";
                dgvItems.Columns["Quantity"].HeaderText = "تعداد";
                dgvItems.Columns["UnitPrice"].HeaderText = "قیمت واحد";
                dgvItems.Columns["TotalPrice"].HeaderText = "جمع";

                dgvItems.Columns["UnitPrice"].DefaultCellStyle.Format = "N0";
                dgvItems.Columns["TotalPrice"].DefaultCellStyle.Format = "N0";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                InvoicePrinter printer = new InvoicePrinter(saleID);
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