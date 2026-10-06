using InventoryApp.Classes;
using System;
using System.Windows.Forms;

namespace InventoryApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // نمایش اطلاعات کاربر جاری
            lblUser.Text = "👤 کاربر: " + Session.FullName +
                          " (" + Session.Role + ")";

            // نمایش تاریخ شمسی
            System.Globalization.PersianCalendar pc =
                new System.Globalization.PersianCalendar();
            DateTime now = DateTime.Now;
            lblDate.Text = string.Format("📅 {0}/{1}/{2}",
                pc.GetYear(now),
                pc.GetMonth(now).ToString("00"),
                pc.GetDayOfMonth(now).ToString("00"));

            // اگه کاربر عادی بود، منوی مدیریت مخفی بشه
            if (Session.Role != "Admin")
            {
                mnuUsers.Visible = false;
            }

            // باز کردن خودکار داشبورد
            OpenForm<DashboardForm>();
        }

        // ---------- متد کمکی برای باز کردن فرم بدون تکرار ----------
        private void OpenForm<T>() where T : Form, new()
        {
            // چک کن آیا این فرم قبلاً باز شده؟
            foreach (Form f in this.MdiChildren)
            {
                if (f is T)
                {
                    // اگه بازه، فعالش کن
                    if (f.WindowState == FormWindowState.Minimized)
                        f.WindowState = FormWindowState.Normal;
                    f.Activate();
                    return;
                }
            }

            // اگه باز نبود، بسازش
            T form = new T();
            form.MdiParent = this;
            form.Show();
        }

        // ---------- کالاها ----------
        private void mnuProducts_Click(object sender, EventArgs e) => OpenForm<ProductsForm>();
        private void mnuCategories_Click(object sender, EventArgs e) => OpenForm<CategoriesForm>();
        private void mnuStock_Click(object sender, EventArgs e) => OpenForm<StockForm>();

        // ---------- فروش ----------
        private void mnuNewSale_Click(object sender, EventArgs e) => OpenForm<SalesForm>();
        private void mnuSalesList_Click(object sender, EventArgs e) => OpenForm<SalesListForm>();
        private void mnuCustomers_Click(object sender, EventArgs e) => OpenForm<CustomersForm>();

        // ---------- گزارشات ----------
        private void mnuDailyReport_Click(object sender, EventArgs e) => OpenForm<DailyReportForm>();

        private void mnuMonthlyReport_Click(object sender, EventArgs e) => OpenForm<MonthlyReportForm>();

        private void mnuLowStock_Click(object sender, EventArgs e) => OpenForm<LowStockReportForm>();

        // ---------- مدیریت ----------
        private void mnuUsers_Click(object sender, EventArgs e) => OpenForm<UsersForm>();

        private void mnuLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "آیا می‌خواهید از حساب کاربری خارج شوید؟",
                "خروج از حساب",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // پاک کردن Session
                Session.UserID = 0;
                Session.FullName = "";
                Session.Role = "";

                LoginForm login = new LoginForm();
                login.Show();
                this.Close();
            }
        }

        // ---------- راهنما ----------
        private void mnuAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "سیستم مدیریت انبار و فروش\n" +
                "نسخه 1.0\n\n" +
                "طراحی و توسعه: [نام شما]\n" +
                "© 1404",
                "درباره ما",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "آیا از برنامه خارج می‌شوید؟",
                "خروج",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                Application.Exit();
        }
        private void کالاهاToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void mnuBackup_Click(object sender, EventArgs e) => OpenForm<BackupForm>();

        private void mnuSettings_Click(object sender, EventArgs e)
        {
            SettingsForm form = new SettingsForm();
            form.ShowDialog();  // Modal (کاربر باید ببندش)
        }
        private void mnuDashboard_Click(object sender, EventArgs e) => OpenForm<DashboardForm>();
    }
}