using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using InventoryApp.Classes;

namespace InventoryApp
{
    public partial class LoginForm : Form
    {
        public static int CurrentUserID = 0;
        public static string CurrentUserName = "";
        public static string CurrentUserRole = "";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            try
            {
                // ۱) هش کردن رمز وارد شده
                string hashedPassword = SecurityHelper.HashPassword(txtPassword.Text.Trim());

                // ۲) مقایسه با دیتابیس
                string query = @"
    SELECT UserID, FullName, Role 
    FROM Users 
    WHERE Username = @u 
      AND CAST(Password AS NVARCHAR(MAX)) = @p";
                SqlParameter[] parameters =
{
    new SqlParameter("@u", txtUsername.Text.Trim()),
    new SqlParameter("@p", System.Data.SqlDbType.NVarChar, 200) { Value = hashedPassword }
};

                DataTable dt = DatabaseConnection.ExecuteQuery(query, parameters);

                // 🔴 دیباگ: مقدار هش وارد شده و تعداد رکورد برگشتی
                //MessageBox.Show(
                //    "Hash ارسالی: [" + hashedPassword + "]\n" +
                //    "طول هش: " + hashedPassword.Length + "\n" +
                //    "تعداد رکورد برگشتی: " + dt.Rows.Count);

                if (dt.Rows.Count > 0)
                {
                    Session.UserID = Convert.ToInt32(dt.Rows[0]["UserID"]);
                    Session.FullName = dt.Rows[0]["FullName"].ToString();
                    Session.Role = dt.Rows[0]["Role"].ToString();

                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                    
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا در ورود:\n" + ex.Message, "خطا",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;  // جلوگیری از صدای "دینگ"
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnLogin.PerformClick();  // خودکار دکمه ورود بزنه
            }
        }
    }
}