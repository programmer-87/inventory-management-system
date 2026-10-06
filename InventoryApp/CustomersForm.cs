using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using InventoryApp.Classes;

namespace InventoryApp
{
    public partial class CustomersForm : Form
    {
        private int selectedCustomerID = 0;

        public CustomersForm()
        {
            InitializeComponent();
        }

        private void CustomersForm_Load(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        // ---------- بارگذاری مشتریان ----------
        private void LoadCustomers(string search = "")
        {
            string query = @"
                SELECT c.CustomerID, c.FullName, c.Phone, c.Address,
                       ISNULL((SELECT COUNT(*) FROM Sales s WHERE s.CustomerID = c.CustomerID), 0) AS PurchaseCount,
                       ISNULL((SELECT SUM(s.FinalAmount) FROM Sales s WHERE s.CustomerID = c.CustomerID), 0) AS TotalPurchase
                FROM Customers c
                WHERE c.FullName LIKE @s OR c.Phone LIKE @s
                ORDER BY c.CustomerID DESC";

            SqlParameter[] param = { new SqlParameter("@s", "%" + search + "%") };
            DataTable dt = DatabaseConnection.ExecuteQuery(query, param);
            dgvCustomers.DataSource = dt;

            if (dgvCustomers.Columns.Count > 0)
            {
                dgvCustomers.Columns["CustomerID"].HeaderText = "کد";
                dgvCustomers.Columns["FullName"].HeaderText = "نام مشتری";
                dgvCustomers.Columns["Phone"].HeaderText = "تلفن";
                dgvCustomers.Columns["Address"].HeaderText = "آدرس";
                dgvCustomers.Columns["PurchaseCount"].HeaderText = "تعداد خرید";
                dgvCustomers.Columns["TotalPurchase"].HeaderText = "جمع خرید (ریال)";

                dgvCustomers.Columns["CustomerID"].Width = 60;
                dgvCustomers.Columns["PurchaseCount"].Width = 90;
                dgvCustomers.Columns["TotalPurchase"].Width = 140;

                dgvCustomers.Columns["TotalPurchase"].DefaultCellStyle.Format = "N0";
            }

            UpdateSummary();
        }

        // ---------- خلاصه ----------
        private void UpdateSummary()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgvCustomers.Rows)
            {
                if (row.Cells["TotalPurchase"].Value != null)
                    total += Convert.ToDecimal(row.Cells["TotalPurchase"].Value);
            }

            lblCountValue.Text = dgvCustomers.Rows.Count.ToString("N0");
            lblTotalPurchaseValue.Text = total.ToString("N0") + " ریال";
        }

        // ---------- پاک کردن فرم ----------
        private void ClearForm()
        {
            txtName.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            selectedCustomerID = 0;
            txtName.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        // ---------- افزودن ----------
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("نام مشتری را وارد کنید.", "خطا");
                txtName.Focus();
                return;
            }

            // چک تکراری نبودن
            string checkQuery = "SELECT COUNT(*) FROM Customers WHERE FullName = @n AND ISNULL(Phone, N'') = ISNULL(@p, N'')";
            SqlParameter[] checkParam =
            {
                new SqlParameter("@n", txtName.Text.Trim()),
                new SqlParameter("@p", string.IsNullOrWhiteSpace(txtPhone.Text) ? (object)DBNull.Value : txtPhone.Text.Trim())
            };
            int exists = Convert.ToInt32(DatabaseConnection.ExecuteScalar(checkQuery, checkParam));
            if (exists > 0)
            {
                MessageBox.Show("این مشتری قبلاً ثبت شده است.", "هشدار",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"INSERT INTO Customers (FullName, Phone, Address) 
                             VALUES (@n, @p, @a)";
            SqlParameter[] param =
            {
                new SqlParameter("@n", txtName.Text.Trim()),
                new SqlParameter("@p", string.IsNullOrWhiteSpace(txtPhone.Text) ? (object)DBNull.Value : txtPhone.Text.Trim()),
                new SqlParameter("@a", string.IsNullOrWhiteSpace(txtAddress.Text) ? (object)DBNull.Value : txtAddress.Text.Trim())
            };

            if (DatabaseConnection.ExecuteNonQuery(query, param) > 0)
            {
                MessageBox.Show("✅ مشتری اضافه شد.", "موفق",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadCustomers(txtSearch.Text.Trim());
            }
        }

        // ---------- ویرایش ----------
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedCustomerID == 0)
            {
                MessageBox.Show("ابتدا یک مشتری از لیست انتخاب کنید.", "هشدار");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("نام مشتری را وارد کنید.", "خطا");
                return;
            }

            string query = @"UPDATE Customers SET 
                             FullName = @n, Phone = @p, Address = @a
                             WHERE CustomerID = @id";
            SqlParameter[] param =
            {
                new SqlParameter("@n", txtName.Text.Trim()),
                new SqlParameter("@p", string.IsNullOrWhiteSpace(txtPhone.Text) ? (object)DBNull.Value : txtPhone.Text.Trim()),
                new SqlParameter("@a", string.IsNullOrWhiteSpace(txtAddress.Text) ? (object)DBNull.Value : txtAddress.Text.Trim()),
                new SqlParameter("@id", selectedCustomerID)
            };

            if (DatabaseConnection.ExecuteNonQuery(query, param) > 0)
            {
                MessageBox.Show("✅ مشتری ویرایش شد.", "موفق",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadCustomers(txtSearch.Text.Trim());
            }
        }

        // ---------- حذف ----------
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedCustomerID == 0)
            {
                MessageBox.Show("ابتدا یک مشتری انتخاب کنید.", "هشدار");
                return;
            }

            // چک کنیم آیا مشتری فاکتور داره؟
            string checkQuery = "SELECT COUNT(*) FROM Sales WHERE CustomerID = @id";
            SqlParameter[] checkParam = { new SqlParameter("@id", selectedCustomerID) };
            int salesCount = Convert.ToInt32(DatabaseConnection.ExecuteScalar(checkQuery, checkParam));

            if (salesCount > 0)
            {
                MessageBox.Show(
                    $"❌ این مشتری {salesCount} فاکتور فروش دارد و قابل حذف نیست.",
                    "امکان حذف نیست",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("آیا از حذف این مشتری مطمئن هستید؟", "تأیید",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            string query = "DELETE FROM Customers WHERE CustomerID = @id";
            SqlParameter[] param = { new SqlParameter("@id", selectedCustomerID) };

            if (DatabaseConnection.ExecuteNonQuery(query, param) > 0)
            {
                MessageBox.Show("🗑️ مشتری حذف شد.", "موفق",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadCustomers(txtSearch.Text.Trim());
            }
        }

        // ---------- انتخاب از جدول ----------
        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvCustomers.Rows[e.RowIndex];
            selectedCustomerID = Convert.ToInt32(row.Cells["CustomerID"].Value);
            txtName.Text = row.Cells["FullName"].Value?.ToString();
            txtPhone.Text = row.Cells["Phone"].Value?.ToString();
            txtAddress.Text = row.Cells["Address"].Value?.ToString();
        }

        // ---------- جستجو ----------
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadCustomers(txtSearch.Text.Trim());
        }
    }
}