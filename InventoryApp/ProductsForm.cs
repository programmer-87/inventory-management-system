using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using InventoryApp.Classes;

namespace InventoryApp
{
    public partial class ProductsForm : Form
    {
        private int selectedProductID = 0;

        public ProductsForm()
        {
            InitializeComponent();
        }

        private void ProductsForm_Load(object sender, EventArgs e)
        {
            LoadCategories();
            LoadProducts();
        }

        // ---------- بارگذاری دسته‌بندی‌ها ----------
        private void LoadCategories()
        {
            string query = "SELECT CategoryID, CategoryName FROM Categories ORDER BY CategoryName";
            DataTable dt = DatabaseConnection.ExecuteQuery(query);

            cmbCategory.DataSource = dt;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "CategoryID";
            cmbCategory.SelectedIndex = -1;
        }

        // ---------- بارگذاری محصولات ----------
        private void LoadProducts(string search = "")
        {
            string query = @"
                SELECT p.ProductID, p.ProductName, c.CategoryName, 
                       p.Barcode, p.Price, p.Quantity, p.MinQuantity
                FROM Products p
                LEFT JOIN Categories c ON p.CategoryID = c.CategoryID
                WHERE p.ProductName LIKE @s OR p.Barcode LIKE @s
                ORDER BY p.ProductID DESC";

            SqlParameter[] param = { new SqlParameter("@s", "%" + search + "%") };
            DataTable dt = DatabaseConnection.ExecuteQuery(query, param);

            dgvProducts.DataSource = dt;

            // تنظیم هدر ستون‌ها
            if (dgvProducts.Columns.Count > 0)
            {
                dgvProducts.Columns["ProductID"].HeaderText = "کد";
                dgvProducts.Columns["ProductName"].HeaderText = "نام محصول";
                dgvProducts.Columns["CategoryName"].HeaderText = "دسته‌بندی";
                dgvProducts.Columns["Barcode"].HeaderText = "بارکد";
                dgvProducts.Columns["Price"].HeaderText = "قیمت";
                dgvProducts.Columns["Quantity"].HeaderText = "موجودی";
                dgvProducts.Columns["MinQuantity"].HeaderText = "حد هشدار";

                // رنگی کردن محصولات رو به اتمام
                foreach (DataGridViewRow row in dgvProducts.Rows)
                {
                    if (row.Cells["Quantity"].Value != null &&
                        row.Cells["MinQuantity"].Value != null)
                    {
                        int q = Convert.ToInt32(row.Cells["Quantity"].Value);
                        int m = Convert.ToInt32(row.Cells["MinQuantity"].Value);
                        if (q <= m)
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.MistyRose;
                    }
                }
            }
        }

        // ---------- پاک کردن فرم ----------
        private void ClearForm()
        {
            txtName.Clear();
            txtBarcode.Clear();
            txtPrice.Clear();
            txtQuantity.Clear();
            txtMinQuantity.Clear();
            cmbCategory.SelectedIndex = -1;
            selectedProductID = 0;
            txtName.Focus();
        }

        // ---------- افزودن محصول ----------
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            string query = @"INSERT INTO Products 
                (ProductName, CategoryID, Barcode, Price, Quantity, MinQuantity)
                VALUES (@n, @c, @b, @p, @q, @m)";

            SqlParameter[] param =
            {
                new SqlParameter("@n", txtName.Text.Trim()),
                new SqlParameter("@c", cmbCategory.SelectedValue),
                new SqlParameter("@b", string.IsNullOrWhiteSpace(txtBarcode.Text) ? (object)DBNull.Value : txtBarcode.Text.Trim()),
                new SqlParameter("@p", decimal.Parse(txtPrice.Text)),
                new SqlParameter("@q", int.Parse(txtQuantity.Text)),
                new SqlParameter("@m", int.Parse(txtMinQuantity.Text))
            };

            if (DatabaseConnection.ExecuteNonQuery(query, param) > 0)
            {
                MessageBox.Show("✅ محصول با موفقیت اضافه شد.", "موفق",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadProducts();
            }
        }

        // ---------- انتخاب ردیف از جدول ----------
        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvProducts.Rows[e.RowIndex];
            selectedProductID = Convert.ToInt32(row.Cells["ProductID"].Value);
            txtName.Text = row.Cells["ProductName"].Value?.ToString();
            cmbCategory.Text = row.Cells["CategoryName"].Value?.ToString();
            txtBarcode.Text = row.Cells["Barcode"].Value?.ToString();
            txtPrice.Text = row.Cells["Price"].Value?.ToString();
            txtQuantity.Text = row.Cells["Quantity"].Value?.ToString();
            txtMinQuantity.Text = row.Cells["MinQuantity"].Value?.ToString();
        }

        // ---------- جستجو ----------
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadProducts(txtSearch.Text.Trim());
        }

        // ---------- اعتبارسنجی ----------
        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("نام محصول را وارد کنید.", "خطا");
                txtName.Focus();
                return false;
            }
            if (cmbCategory.SelectedIndex == -1)
            {
                MessageBox.Show("دسته‌بندی را انتخاب کنید.", "خطا");
                cmbCategory.Focus();
                return false;
            }
            decimal price;
            if (!decimal.TryParse(txtPrice.Text, out price) || price < 0)
            {
                MessageBox.Show("قیمت را به‌درستی وارد کنید.", "خطا");
                txtPrice.Focus();
                return false;
            }
            int qty;
            if (!int.TryParse(txtQuantity.Text, out qty) || qty < 0)
            {
                MessageBox.Show("موجودی را به‌درستی وارد کنید.", "خطا");
                txtQuantity.Focus();
                return false;
            }
            int minQty;
            if (!int.TryParse(txtMinQuantity.Text, out minQty) || minQty < 0)
            {
                MessageBox.Show("حد هشدار را به‌درستی وارد کنید.", "خطا");
                txtMinQuantity.Focus();
                return false;
            }
            return true;
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            if (selectedProductID == 0)
            {
                MessageBox.Show("⚠️ ابتدا یک محصول از لیست انتخاب کنید.", "هشدار",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidateInputs()) return;

            string query = @"UPDATE Products SET 
                ProductName = @n, CategoryID = @c, Barcode = @b,
                Price = @p, Quantity = @q, MinQuantity = @m
                WHERE ProductID = @id";

            SqlParameter[] param =
            {
                new SqlParameter("@n", txtName.Text.Trim()),
                new SqlParameter("@c", cmbCategory.SelectedValue),
                new SqlParameter("@b", string.IsNullOrWhiteSpace(txtBarcode.Text) ? (object)DBNull.Value : txtBarcode.Text.Trim()),
                new SqlParameter("@p", decimal.Parse(txtPrice.Text)),
                new SqlParameter("@q", int.Parse(txtQuantity.Text)),
                new SqlParameter("@m", int.Parse(txtMinQuantity.Text)),
                new SqlParameter("@id", selectedProductID)
            };

            if (DatabaseConnection.ExecuteNonQuery(query, param) > 0)
            {
                MessageBox.Show("✅ محصول با موفقیت ویرایش شد.", "موفق",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadProducts();
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (selectedProductID == 0)
            {
                MessageBox.Show("⚠️ ابتدا یک محصول از لیست انتخاب کنید.", "هشدار",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("آیا از حذف این محصول مطمئن هستید؟", "تأیید حذف",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            string query = "DELETE FROM Products WHERE ProductID = @id";
            SqlParameter[] param = { new SqlParameter("@id", selectedProductID) };

            if (DatabaseConnection.ExecuteNonQuery(query, param) > 0)
            {
                MessageBox.Show("🗑️ محصول حذف شد.", "موفق",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadProducts();
            }
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            ClearForm();
        }

    }
}