using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using InventoryApp.Classes;

namespace InventoryApp
{
    public partial class StockEntryForm : Form
    {
        private string movementType;   // "IN" یا "OUT"

        public StockEntryForm(string type)
        {
            InitializeComponent();
            this.movementType = type;
        }

        private void StockEntryForm_Load(object sender, EventArgs e)
        {
            // تنظیم عنوان فرم
            if (movementType == "IN")
            {
                this.Text = "ثبت ورود کالا به انبار";
                lblTitle.Text = "➕ ثبت ورود کالا";
                lblTypeValue.Text = "ورود (IN)";
                lblTypeValue.ForeColor = System.Drawing.Color.DarkGreen;
            }
            else
            {
                this.Text = "ثبت خروج کالا از انبار";
                lblTitle.Text = "➖ ثبت خروج کالا";
                lblTypeValue.Text = "خروج (OUT)";
                lblTypeValue.ForeColor = System.Drawing.Color.DarkRed;
            }

            LoadProducts();
        }

        private void LoadProducts()
        {
            string query = "SELECT ProductID, ProductName, Quantity FROM Products ORDER BY ProductName";
            DataTable dt = DatabaseConnection.ExecuteQuery(query);

            cmbProduct.DataSource = dt;
            cmbProduct.DisplayMember = "ProductName";
            cmbProduct.ValueMember = "ProductID";
            cmbProduct.SelectedIndex = -1;
        }

        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProduct.SelectedIndex == -1) return;

            DataRowView row = cmbProduct.SelectedItem as DataRowView;
            if (row == null) return;

            int stock = Convert.ToInt32(row["Quantity"]);
            lblCurrentStockValue.Text = stock.ToString("N0");

            // اگه خروج بود، حداکثر تعداد = موجودی فعلی
            if (movementType == "OUT")
                numQuantity.Maximum = Math.Max(1, stock);
            else
                numQuantity.Maximum = 100000;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbProduct.SelectedIndex == -1)
            {
                MessageBox.Show("محصول را انتخاب کنید.", "خطا");
                cmbProduct.Focus();
                return;
            }

            int productID = Convert.ToInt32(cmbProduct.SelectedValue);
            int qty = (int)numQuantity.Value;

            // چک موجودی برای خروج
            if (movementType == "OUT")
            {
                DataRowView row = cmbProduct.SelectedItem as DataRowView;
                int currentStock = Convert.ToInt32(row["Quantity"]);
                if (qty > currentStock)
                {
                    MessageBox.Show(
                        $"موجودی کافی نیست.\nموجودی فعلی: {currentStock}",
                        "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            try
            {
                // ۱) ثبت حرکت
                string moveQuery = @"
                    INSERT INTO StockMovements (ProductID, MovementType, Quantity, Description)
                    VALUES (@pid, @type, @qty, @desc)";

                SqlParameter[] moveParam =
                {
                    new SqlParameter("@pid", productID),
                    new SqlParameter("@type", movementType),
                    new SqlParameter("@qty", qty),
                    new SqlParameter("@desc", string.IsNullOrWhiteSpace(txtDescription.Text)
                        ? (object)DBNull.Value
                        : txtDescription.Text.Trim())
                };
                DatabaseConnection.ExecuteNonQuery(moveQuery, moveParam);

                // ۲) به‌روزرسانی موجودی
                string updateQuery = movementType == "IN"
                    ? "UPDATE Products SET Quantity = Quantity + @q WHERE ProductID = @pid"
                    : "UPDATE Products SET Quantity = Quantity - @q WHERE ProductID = @pid";

                SqlParameter[] updateParam =
                {
                    new SqlParameter("@q", qty),
                    new SqlParameter("@pid", productID)
                };
                DatabaseConnection.ExecuteNonQuery(updateQuery, updateParam);

                MessageBox.Show("✅ حرکت انبار ثبت شد.", "موفق",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا:\n" + ex.Message, "خطا",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}