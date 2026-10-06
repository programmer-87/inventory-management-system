using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InventoryApp.Classes
{
    public static class DatabaseConnection
    {
        // 🔴 این خط باید اینجا باشه:
        private static string ConnectionString
        {
            get
            {
                // اگه ServerName تنظیم شده، ازش استفاده کن
                if (!string.IsNullOrEmpty(DatabaseInitializer.ServerName))
                {
                    return DatabaseInitializer.DatabaseConnectionString;
                }

                // fallback برای بکاپ/ریستور که قبل از Init استفاده میشه
                return @"Data Source=localhost;Initial Catalog=InventoryDB;Integrated Security=True;TrustServerCertificate=True;";
            }
        }

        /// <summary>
        /// اجرای کوئری و برگرداندن DataTable (برای SELECT)
        /// </summary>
        public static DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null)
                            cmd.Parameters.AddRange(parameters);

                        conn.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا در اجرای کوئری:\n" + ex.Message, "خطا",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        /// <summary>
        /// اجرای دستور (INSERT/UPDATE/DELETE) و برگرداندن تعداد رکورد تأثیر گرفته
        /// </summary>
        public static int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            int result = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null)
                            cmd.Parameters.AddRange(parameters);

                        conn.Open();
                        result = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا در اجرای دستور:\n" + ex.Message, "خطا",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        /// <summary>
        /// برگرداندن یک مقدار تک (مثلاً COUNT یا MAX)
        /// </summary>
        public static object ExecuteScalar(string query, SqlParameter[] parameters = null)
        {
            object result = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null)
                            cmd.Parameters.AddRange(parameters);

                        conn.Open();
                        result = cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا در اجرای دستور:\n" + ex.Message, "خطا",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
    }
}