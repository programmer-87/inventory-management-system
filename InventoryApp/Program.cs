using System;
using System.Windows.Forms;
using InventoryApp.Classes;

namespace InventoryApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // ۱) راه‌اندازی دیتابیس (اگه نبود، بساز)
            if (!DatabaseInitializer.EnsureDatabaseExists())
            {
                MessageBox.Show("برنامه بسته می‌شود.", "خطا",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ۲) باز کردن فرم لاگین
            Application.Run(new LoginForm());

            MessageBox.Show("Server Name: " + DatabaseInitializer.ServerName);
        }
    }
}