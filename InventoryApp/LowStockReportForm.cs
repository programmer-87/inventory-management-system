using System;
using System.Data;
using System.Windows.Forms;
using InventoryApp.Classes;

namespace InventoryApp
{
    public partial class LowStockReportForm : Form
    {
        public LowStockReportForm()
        {
            InitializeComponent();
        }

        private void LowStockReportForm_Load(object sender, EventArgs e)
        {
            lblInfo.Text = "نمایش محصولاتی که موجودی آن‌ها کمتر یا مساوی حد هشدار است";
            lblInfo.ForeColor = System.Drawing.Color.Gray;
            lblInfo.Font = new System.Drawing.Font("Tahoma", 9);

            LoadReport();
        }

        // ---------- بارگذاری گزارش ----------
        private void LoadReport()
        {
            string query = @"
                SELECT 
                    p.ProductID,
                    p.ProductName,
                    ISNULL(c.CategoryName, N'—') AS CategoryName,
                    p.Quantity,
                    p.MinQuantity,
                    (p.MinQuantity - p.Quantity) AS Shortage,
                    p.Price,
                    (p.Quantity * p.Price) AS StockValue,
                    ((p.MinQuantity - p.Quantity) * p.Price) AS NeedValue
                FROM Products p
                LEFT JOIN Categories c ON p.CategoryID = c.CategoryID
                WHERE p.Quantity <= p.MinQuantity
                ORDER BY 
                    CASE WHEN p.Quantity = 0 THEN 0 ELSE 1 END,
                    (p.MinQuantity - p.Quantity) DESC";

            DataTable dt = DatabaseConnection.ExecuteQuery(query);
            dgvLowStock.DataSource = dt;

            if (dgvLowStock.Columns.Count > 0)
            {
                dgvLowStock.Columns["ProductID"].HeaderText = "کد";
                dgvLowStock.Columns["ProductName"].HeaderText = "نام محصول";
                dgvLowStock.Columns["CategoryName"].HeaderText = "دسته‌بندی";
                dgvLowStock.Columns["Quantity"].HeaderText = "موجودی";
                dgvLowStock.Columns["MinQuantity"].HeaderText = "حد هشدار";
                dgvLowStock.Columns["Shortage"].HeaderText = "کمبود";
                dgvLowStock.Columns["Price"].HeaderText = "قیمت واحد";
                dgvLowStock.Columns["StockValue"].HeaderText = "ارزش موجودی";
                dgvLowStock.Columns["NeedValue"].HeaderText = "هزینه تأمین";

                dgvLowStock.Columns["ProductID"].Width = 60;
                dgvLowStock.Columns["Quantity"].Width = 80;
                dgvLowStock.Columns["MinQuantity"].Width = 80;
                dgvLowStock.Columns["Shortage"].Width = 80;

                dgvLowStock.Columns["Price"].DefaultCellStyle.Format = "N0";
                dgvLowStock.Columns["StockValue"].DefaultCellStyle.Format = "N0";
                dgvLowStock.Columns["NeedValue"].DefaultCellStyle.Format = "N0";

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

            UpdateSummary(dt);
        }

        // ---------- خلاصه ----------
        private void UpdateSummary(DataTable dt)
        {
            int count = dt.Rows.Count;
            int zeroCount = 0;
            decimal totalStockValue = 0;
            decimal totalNeedValue = 0;

            foreach (DataRow row in dt.Rows)
            {
                int qty = Convert.ToInt32(row["Quantity"]);
                if (qty == 0) zeroCount++;

                totalStockValue += Convert.ToDecimal(row["StockValue"]);
                totalNeedValue += Convert.ToDecimal(row["NeedValue"]);
            }

            lblCountValue.Text = count.ToString("N0");
            lblZeroValue.Text = zeroCount.ToString("N0");
            lblStockValueValue.Text = totalStockValue.ToString("N0") + " ریال";
            lblNeedValueValue.Text = totalNeedValue.ToString("N0") + " ریال";

            // رنگ‌بندی خلاصه
            if (zeroCount > 0)
                lblZeroValue.ForeColor = System.Drawing.Color.Red;
            else
                lblZeroValue.ForeColor = System.Drawing.Color.Green;
        }

        // ---------- دکمه‌ها ----------
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                string summary = string.Format(
                    "تعداد محصولات کم‌موجود: {0}   |   با موجودی صفر: {1}   |   هزینه تأمین: {2}",
                    lblCountValue.Text, lblZeroValue.Text, lblNeedValueValue.Text);

                DataTable dt = new DataTable();
                dt.Columns.Add("نام محصول");
                dt.Columns.Add("دسته");
                dt.Columns.Add("موجودی");
                dt.Columns.Add("حد هشدار");
                dt.Columns.Add("کمبود");
                dt.Columns.Add("هزینه تأمین");

                foreach (DataGridViewRow row in dgvLowStock.Rows)
                {
                    dt.Rows.Add(
                        row.Cells["ProductName"].Value,
                        row.Cells["CategoryName"].Value,
                        row.Cells["Quantity"].Value,
                        row.Cells["MinQuantity"].Value,
                        row.Cells["Shortage"].Value,
                        Convert.ToDecimal(row.Cells["NeedValue"].Value).ToString("N0"));
                }

                string title = "گزارش محصولات رو به اتمام";

                ReportPrinter printer = new ReportPrinter(
                    ReportPrinter.ReportType.LowStock, title, dt, null, summary);
                printer.ShowPreview();
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا:\n" + ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}