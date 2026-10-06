using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using InventoryApp.Classes;

namespace InventoryApp
{
    public partial class CategoriesForm : Form
    {
        private int selectedCategoryID = 0;

        public CategoriesForm()
        {
            InitializeComponent();
        }

        private void CategoriesForm_Load(object sender, EventArgs e)
        {
            LoadCategories();
        }

        // ---------- بارگذاری دسته‌بندی‌ها ----------
        private void LoadCategories()
        {
            string query = @"
                SELECT c.CategoryID, c.CategoryName,
                       (SELECT COUNT(*) FROM Products p WHERE p.CategoryID = c.CategoryID) AS ProductCount
                FROM Categories c
                ORDER BY c.CategoryName";

            DataTable dt = DatabaseConnection.ExecuteQuery(query);
            dgvCategories.DataSource = dt;

            if (dgvCategories.Columns.Count > 0)
            {
                dgvCategories.Columns["CategoryID"].HeaderText = "کد";
                dgvCategories.Columns["CategoryName"].HeaderText = "نام دسته‌بندی";
                dgvCategories.Columns["ProductCount"].HeaderText = "تعداد محصولات";
                dgvCategories.Columns["CategoryID"].Width = 60;
            }
        }

        // ---------- پاک کردن فرم ----------
        private void ClearForm()
        {
            txtCategoryName.Clear();
            selectedCategoryID = 0;
            txtCategoryName.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        // ---------- افزودن ----------
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("نام دسته‌بندی را وارد کنید.", "خطا",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCategoryName.Focus();
                return;
            }

            string query = "INSERT INTO Categories (CategoryName) VALUES (@n)";
            SqlParameter[] param = { new SqlParameter("@n", txtCategoryName.Text.Trim()) };

            if (DatabaseConnection.ExecuteNonQuery(query, param) > 0)
            {
                MessageBox.Show("✅ دسته‌بندی اضافه شد.", "موفق",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadCategories();
            }
        }

        // ---------- ویرایش ----------
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedCategoryID == 0)
            {
                MessageBox.Show("⚠️ ابتدا یک دسته‌بندی از لیست انتخاب کنید.", "هشدار",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("نام دسته‌بندی را وارد کنید.", "خطا");
                return;
            }

            string query = "UPDATE Categories SET CategoryName = @n WHERE CategoryID = @id";
            SqlParameter[] param =
            {
                new SqlParameter("@n", txtCategoryName.Text.Trim()),
                new SqlParameter("@id", selectedCategoryID)
            };

            if (DatabaseConnection.ExecuteNonQuery(query, param) > 0)
            {
                MessageBox.Show("✅ دسته‌بندی ویرایش شد.", "موفق",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadCategories();
            }
        }

        // ---------- حذف ----------
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedCategoryID == 0)
            {
                MessageBox.Show("⚠️ ابتدا یک دسته‌بندی انتخاب کنید.", "هشدار");
                return;
            }

            // چک کنیم آیا محصولی توی این دسته هست
            string checkQuery = "SELECT COUNT(*) FROM Products WHERE CategoryID = @id";
            SqlParameter[] checkParam = { new SqlParameter("@id", selectedCategoryID) };
            int productCount = Convert.ToInt32(DatabaseConnection.ExecuteScalar(checkQuery, checkParam));

            if (productCount > 0)
            {
                MessageBox.Show(
                    $"❌ این دسته‌بندی {productCount} محصول دارد و قابل حذف نیست.\n" +
                    "ابتدا محصولات آن را جابجا یا حذف کنید.",
                    "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("آیا از حذف این دسته‌بندی مطمئن هستید؟", "تأیید",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            string query = "DELETE FROM Categories WHERE CategoryID = @id";
            SqlParameter[] param = { new SqlParameter("@id", selectedCategoryID) };

            if (DatabaseConnection.ExecuteNonQuery(query, param) > 0)
            {
                MessageBox.Show("🗑️ دسته‌بندی حذف شد.", "موفق",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadCategories();
            }
        }

        // ---------- انتخاب از جدول ----------
        
        private void dgvCategories_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvCategories.Rows[e.RowIndex];
            selectedCategoryID = Convert.ToInt32(row.Cells["CategoryID"].Value);
            txtCategoryName.Text = row.Cells["CategoryName"].Value?.ToString();
        }
    }
}