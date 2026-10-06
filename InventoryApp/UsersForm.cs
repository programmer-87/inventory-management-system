using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using InventoryApp.Classes;

namespace InventoryApp
{
    public partial class UsersForm : Form
    {
        private int selectedUserID = 0;

        public UsersForm()
        {
            InitializeComponent();
        }

        private void UsersForm_Load(object sender, EventArgs e)
        {
            // پر کردن ComboBox نقش
            cmbRole.Items.Clear();
            cmbRole.Items.Add("Admin");
            cmbRole.Items.Add("User");

            // راهنمای رمز
            lblPasswordHint.Text = "(هنگام ویرایش، خالی بذار تا رمز عوض نشه)";
            lblPasswordHint.ForeColor = System.Drawing.Color.Gray;
            lblPasswordHint.Font = new System.Drawing.Font("Tahoma", 8);

            LoadUsers();
        }

        // ---------- بارگذاری کاربران ----------
        private void LoadUsers(string search = "")
        {
            string query = @"
                SELECT UserID, Username, FullName, Role, CreatedAt
                FROM Users
                WHERE Username LIKE @s OR FullName LIKE @s
                ORDER BY UserID DESC";

            SqlParameter[] param = { new SqlParameter("@s", "%" + search + "%") };
            DataTable dt = DatabaseConnection.ExecuteQuery(query, param);
            dgvUsers.DataSource = dt;

            if (dgvUsers.Columns.Count > 0)
            {
                dgvUsers.Columns["UserID"].HeaderText = "کد";
                dgvUsers.Columns["Username"].HeaderText = "نام کاربری";
                dgvUsers.Columns["FullName"].HeaderText = "نام کامل";
                dgvUsers.Columns["Role"].HeaderText = "نقش";
                dgvUsers.Columns["CreatedAt"].HeaderText = "تاریخ ایجاد";

                dgvUsers.Columns["UserID"].Width = 60;
                dgvUsers.Columns["Role"].Width = 100;

                dgvUsers.Columns["CreatedAt"].DefaultCellStyle.Format = "yyyy/MM/dd";
            }

            lblCountValue.Text = dgvUsers.Rows.Count.ToString("N0");
        }

        // ---------- پاک کردن فرم ----------
        private void ClearForm()
        {
            txtUsername.Clear();
            txtFullName.Clear();
            txtPassword.Clear();
            cmbRole.SelectedIndex = -1;
            selectedUserID = 0;
            txtUsername.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        // ---------- افزودن ----------
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // اعتبارسنجی
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("نام کاربری را وارد کنید.", "خطا");
                txtUsername.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("نام کامل را وارد کنید.", "خطا");
                txtFullName.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("رمز عبور را وارد کنید.", "خطا");
                txtPassword.Focus();
                return;
            }
            if (txtPassword.Text.Length < 6)
            {
                MessageBox.Show("رمز عبور باید حداقل ۶ کاراکتر باشد.", "خطا");
                txtPassword.Focus();
                return;
            }
            if (cmbRole.SelectedIndex == -1)
            {
                MessageBox.Show("نقش کاربر را انتخاب کنید.", "خطا");
                cmbRole.Focus();
                return;
            }

            // چک تکراری نبودن نام کاربری
            string checkQuery = "SELECT COUNT(*) FROM Users WHERE Username = @u";
            SqlParameter[] checkParam = { new SqlParameter("@u", txtUsername.Text.Trim()) };
            int exists = Convert.ToInt32(DatabaseConnection.ExecuteScalar(checkQuery, checkParam));
            if (exists > 0)
            {
                MessageBox.Show("این نام کاربری قبلاً ثبت شده است.", "هشدار",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // هش کردن رمز
            string hashedPassword = SecurityHelper.HashPassword(txtPassword.Text.Trim());

            string query = @"INSERT INTO Users (Username, Password, FullName, Role)
                             VALUES (@u, @p, @f, @r)";
            SqlParameter[] param =
            {
                new SqlParameter("@u", txtUsername.Text.Trim()),
                new SqlParameter("@p", hashedPassword),
                new SqlParameter("@f", txtFullName.Text.Trim()),
                new SqlParameter("@r", cmbRole.SelectedItem.ToString())
            };

            if (DatabaseConnection.ExecuteNonQuery(query, param) > 0)
            {
                MessageBox.Show("✅ کاربر اضافه شد.", "موفق",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadUsers(txtSearch.Text.Trim());
            }
        }

        // ---------- ویرایش ----------
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedUserID == 0)
            {
                MessageBox.Show("ابتدا یک کاربر از لیست انتخاب کنید.", "هشدار");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("نام کاربری و نام کامل را وارد کنید.", "خطا");
                return;
            }
            if (cmbRole.SelectedIndex == -1)
            {
                MessageBox.Show("نقش کاربر را انتخاب کنید.", "خطا");
                return;
            }

            // چک: کاربر جاری نمیتونه نقش خودش رو تغییر بده
            if (selectedUserID == Session.UserID && cmbRole.SelectedItem.ToString() != "Admin")
            {
                MessageBox.Show("شما نمی‌توانید نقش خودتان را از Admin تغییر دهید.", "خطا",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // چک تکراری نبودن نام کاربری (به جز خودش)
            string checkQuery = "SELECT COUNT(*) FROM Users WHERE Username = @u AND UserID != @id";
            SqlParameter[] checkParam =
            {
                new SqlParameter("@u", txtUsername.Text.Trim()),
                new SqlParameter("@id", selectedUserID)
            };
            int exists = Convert.ToInt32(DatabaseConnection.ExecuteScalar(checkQuery, checkParam));
            if (exists > 0)
            {
                MessageBox.Show("این نام کاربری قبلاً ثبت شده است.", "هشدار",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query;
                SqlParameter[] param;

                // اگه رمز خالی بود، عوض نشه
                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    query = @"UPDATE Users SET 
                              Username = @u, FullName = @f, Role = @r
                              WHERE UserID = @id";
                    param = new SqlParameter[]
                    {
                        new SqlParameter("@u", txtUsername.Text.Trim()),
                        new SqlParameter("@f", txtFullName.Text.Trim()),
                        new SqlParameter("@r", cmbRole.SelectedItem.ToString()),
                        new SqlParameter("@id", selectedUserID)
                    };
                }
                else
                {
                    if (txtPassword.Text.Length < 6)
                    {
                        MessageBox.Show("رمز عبور باید حداقل ۶ کاراکتر باشد.", "خطا");
                        return;
                    }

                    string hashedPassword = SecurityHelper.HashPassword(txtPassword.Text.Trim());
                    query = @"UPDATE Users SET 
                              Username = @u, Password = @p, FullName = @f, Role = @r
                              WHERE UserID = @id";
                    param = new SqlParameter[]
                    {
                        new SqlParameter("@u", txtUsername.Text.Trim()),
                        new SqlParameter("@p", hashedPassword),
                        new SqlParameter("@f", txtFullName.Text.Trim()),
                        new SqlParameter("@r", cmbRole.SelectedItem.ToString()),
                        new SqlParameter("@id", selectedUserID)
                    };
                }

                if (DatabaseConnection.ExecuteNonQuery(query, param) > 0)
                {
                    MessageBox.Show("✅ کاربر ویرایش شد.", "موفق",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadUsers(txtSearch.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا:\n" + ex.Message, "خطا",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---------- حذف ----------
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedUserID == 0)
            {
                MessageBox.Show("ابتدا یک کاربر انتخاب کنید.", "هشدار");
                return;
            }

            // چک: کاربر جاری خودش رو حذف نکنه
            if (selectedUserID == Session.UserID)
            {
                MessageBox.Show("❌ شما نمی‌توانید حساب خودتان را حذف کنید.",
                    "امکان حذف نیست", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // چک: اگه کاربر فاکتور فروش داره، حذف نشه
            string checkQuery = "SELECT COUNT(*) FROM Sales WHERE UserID = @id";
            SqlParameter[] checkParam = { new SqlParameter("@id", selectedUserID) };
            int salesCount = Convert.ToInt32(DatabaseConnection.ExecuteScalar(checkQuery, checkParam));
            if (salesCount > 0)
            {
                MessageBox.Show(
                    $"❌ این کاربر {salesCount} فاکتور فروش دارد و قابل حذف نیست.",
                    "امکان حذف نیست", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("آیا از حذف این کاربر مطمئن هستید؟", "تأیید",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            string query = "DELETE FROM Users WHERE UserID = @id";
            SqlParameter[] param = { new SqlParameter("@id", selectedUserID) };

            if (DatabaseConnection.ExecuteNonQuery(query, param) > 0)
            {
                MessageBox.Show("🗑️ کاربر حذف شد.", "موفق",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadUsers(txtSearch.Text.Trim());
            }
        }

        // ---------- انتخاب از جدول ----------
        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvUsers.Rows[e.RowIndex];
            selectedUserID = Convert.ToInt32(row.Cells["UserID"].Value);
            txtUsername.Text = row.Cells["Username"].Value?.ToString();
            txtFullName.Text = row.Cells["FullName"].Value?.ToString();
            cmbRole.Text = row.Cells["Role"].Value?.ToString();
            txtPassword.Clear();  // رمز هرگز نمایش داده نمیشه
        }

        // ---------- جستجو ----------
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadUsers(txtSearch.Text.Trim());
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void UsersForm_KeyDown(object sender, KeyEventArgs e)
        {
            // Ctrl+F → فوکوس روی جستجو
            if (e.Control && e.KeyCode == Keys.F)
            {
                txtSearch.Focus();
                e.Handled = true;
            }
            // Ctrl+N → کاربر جدید
            else if (e.Control && e.KeyCode == Keys.N)
            {
                btnClear.PerformClick();
                e.Handled = true;
            }
            // Escape → پاک کردن فرم
            else if (e.KeyCode == Keys.Escape)
            {
                btnClear.PerformClick();
                e.Handled = true;
            }
        }

        private void dgvUsers_KeyDown(object sender, KeyEventArgs e)
        {
            // Enter → فوکوس روی نام کاربری
            if (e.KeyCode == Keys.Enter)
            {
                txtUsername.Focus();
                e.Handled = true;
            }
            // Delete → حذف
            else if (e.KeyCode == Keys.Delete)
            {
                btnDelete.PerformClick();
                e.Handled = true;
            }
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtFullName.Focus();
            }
        }

        private void txtFullName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                cmbRole.Focus();
            }
        }
    }
}