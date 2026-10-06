using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using InventoryApp.Classes;
using System.Security.AccessControl;

namespace InventoryApp
{
    public partial class BackupForm : Form
    {
        private const string DatabaseName = "InventoryDB";

        // توی متد btnBackup_Click و btnRestore_Click،
        // به جای DatabaseConnection.ExecuteNonQuery از این استفاده کن:

        private void ExecuteInMaster(string query)
        {
            string masterConn = DatabaseInitializer.MasterConnectionString;
            using (System.Data.SqlClient.SqlConnection conn =
                new System.Data.SqlClient.SqlConnection(masterConn))
            {
                conn.Open();
                using (System.Data.SqlClient.SqlCommand cmd =
                    new System.Data.SqlClient.SqlCommand(query, conn))
                {
                    cmd.CommandTimeout = 300; // ۵ دقیقه
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public BackupForm()
        {
            InitializeComponent();
        }

        private void BackupForm_Load(object sender, EventArgs e)
        {
            // مسیر پیش‌فرض: C:\InventoryBackups
            string backupFolder = @"C:\InventoryBackups";

            // 🔴 این خط رو اضافه کن (قبل از هر کاری):
            EnsureBackupFolder(backupFolder);

            string defaultBackup = Path.Combine(backupFolder,
                $"InventoryBackup_{DateTime.Now:yyyyMMdd_HHmmss}.bak");
            txtBackupPath.Text = defaultBackup;

            LoadDatabaseInfo();
            AddLog("فرم پشتیبان‌گیری باز شد.");
            AddLog("مسیر پیش‌فرض: " + backupFolder);
        }

        private void EnsureBackupFolder(string folderPath)
        {
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            try
            {
                // اجازه دسترسی به Everyone
                DirectoryInfo di = new DirectoryInfo(folderPath);
                var security = di.GetAccessControl();

                security.AddAccessRule(new System.Security.AccessControl.FileSystemAccessRule(
                    "Everyone",
                    System.Security.AccessControl.FileSystemRights.FullControl,
                    System.Security.AccessControl.AccessControlType.Allow));

                di.SetAccessControl(security);
            }
            catch
            {
                // اگه نتونست، نادیده بگیر
            }
        }

        // ---------- لاگ ----------
        private void AddLog(string message)
        {
            PersianCalendar pc = new PersianCalendar();
            DateTime now = DateTime.Now;
            string time = string.Format("[{0}/{1}/{2} {3:HH:mm:ss}] ",
                pc.GetYear(now), pc.GetMonth(now).ToString("00"),
                pc.GetDayOfMonth(now).ToString("00"), now);

            txtLog.AppendText(time + message + Environment.NewLine);
        }

        // ---------- اطلاعات دیتابیس ----------
        private void LoadDatabaseInfo()
        {
            try
            {
                string query = @"
                    SELECT 
                        DB_NAME() AS DbName,
                        (SELECT physical_name FROM sys.database_files WHERE type = 0) AS DbPath,
                        (SELECT SUM(size) * 8.0 / 1024 FROM sys.database_files) AS SizeMB";

                DataTable dt = DatabaseConnection.ExecuteQuery(query);
                if (dt.Rows.Count > 0)
                {
                    DataRow r = dt.Rows[0];
                    lblDbNameValue.Text = r["DbName"].ToString();
                    lblDbPathValue.Text = r["DbPath"].ToString();
                    decimal sizeMB = Convert.ToDecimal(r["SizeMB"]);
                    lblDbSizeValue.Text = sizeMB.ToString("N2") + " MB";
                }
            }
            catch (Exception ex)
            {
                AddLog("خطا در خواندن اطلاعات دیتابیس: " + ex.Message);
            }
        }

        // ---------- انتخاب مسیر بکاپ ----------
        private void btnBrowseBackup_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Backup Files (*.bak)|*.bak|All Files (*.*)|*.*";
                sfd.FileName = $"InventoryBackup_{DateTime.Now:yyyyMMdd_HHmmss}.bak";
                sfd.InitialDirectory = @"C:\InventoryBackups";

                if (sfd.ShowDialog() == DialogResult.OK)
                    txtBackupPath.Text = sfd.FileName;
            }
        }

        // ---------- انتخاب فایل بازیابی ----------
        private void btnBrowseRestore_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Backup Files (*.bak)|*.bak|All Files (*.*)|*.*";
                ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                if (ofd.ShowDialog() == DialogResult.OK)
                    txtRestorePath.Text = ofd.FileName;
            }
        }

        // ---------- بکاپ ----------
        private void btnBackup_Click(object sender, EventArgs e)
        {
            string path = txtBackupPath.Text.Trim();

            if (string.IsNullOrWhiteSpace(path))
            {
                MessageBox.Show("مسیر ذخیره فایل پشتیبان را وارد کنید.", "خطا",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!path.EndsWith(".bak", StringComparison.OrdinalIgnoreCase))
                path += ".bak";

            // چک اگه فایل وجود داره
            if (File.Exists(path))
            {
                if (MessageBox.Show("فایل موجود است. جایگزین شود؟", "تأیید",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
            }

            try
            {
                AddLog("شروع پشتیبان‌گیری...");
                AddLog("مسیر: " + path);

                string query = $"BACKUP DATABASE [{DatabaseName}] TO DISK = @path WITH INIT, FORMAT";

                // نکته: BACKUP DATABASE رو نمی‌شه با پارامتر اجرا کرد، پس دستی می‌سازیم
                // با احتیاط: مسیر رو چک می‌کنیم که کاراکتر خطرناک نداشته باشه
                string safePath = path.Replace("'", "''");
                string backupQuery = $"BACKUP DATABASE [{DatabaseName}] TO DISK = N'{safePath}' WITH INIT, FORMAT";

                ExecuteInMaster(backupQuery);

                AddLog("✅ پشتیبان‌گیری با موفقیت انجام شد.");
                AddLog("فایل ذخیره شد در: " + path);

                long fileSize = new FileInfo(path).Length;
                AddLog("حجم فایل: " + (fileSize / 1024.0 / 1024.0).ToString("N2") + " MB");

                MessageBox.Show(
                    $"✅ پشتیبان‌گیری با موفقیت انجام شد.\n\nفایل: {Path.GetFileName(path)}\nحجم: {(fileSize / 1024.0 / 1024.0):N2} MB",
                    "موفق", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // پیشنهاد یه مسیر جدید برای بکاپ بعدی
                string docsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                txtBackupPath.Text = Path.Combine(docsPath,
                    $"InventoryBackup_{DateTime.Now:yyyyMMdd_HHmmss}.bak");
            }
            catch (Exception ex)
            {
                AddLog("❌ خطا: " + ex.Message);
                MessageBox.Show("خطا در پشتیبان‌گیری:\n" + ex.Message, "خطا",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---------- بازیابی ----------
        private void btnRestore_Click(object sender, EventArgs e)
        {
            string path = txtRestorePath.Text.Trim();

            if (string.IsNullOrWhiteSpace(path))
            {
                MessageBox.Show("فایل پشتیبان را انتخاب کنید.", "خطا",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!File.Exists(path))
            {
                MessageBox.Show("فایل پشتیبان پیدا نشد.", "خطا",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show(
                "⚠️ هشدار مهم!\n\n" +
                "با بازیابی، تمام اطلاعات فعلی دیتابیس (محصولات، فروش‌ها، مشتریان و...)\n" +
                "پاک شده و با اطلاعات فایل پشتیبان جایگزین می‌شود.\n\n" +
                "آیا مطمئن هستید؟",
                "تأیید بازیابی",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes) return;

            try
            {
                AddLog("شروع بازیابی از: " + path);

                // ۱) قطع اتصالات به دیتابیس
                string safePath = path.Replace("'", "''");

                string killQuery = $@"
                    ALTER DATABASE [{DatabaseName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                    RESTORE DATABASE [{DatabaseName}] FROM DISK = N'{safePath}' WITH REPLACE;
                    ALTER DATABASE [{DatabaseName}] SET MULTI_USER;";

                DatabaseConnection.ExecuteNonQuery(killQuery);

                AddLog("✅ بازیابی با موفقیت انجام شد.");

                MessageBox.Show(
                    "✅ بازیابی با موفقیت انجام شد.\n\n" +
                    "لطفاً برنامه را ببندید و دوباره اجرا کنید.",
                    "موفق", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // پیشنهاد بستن برنامه
                if (MessageBox.Show("برنامه بسته شود؟", "بستن",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                AddLog("❌ خطا: " + ex.Message);

                // تلاش برای برگرداندن دیتابیس به حالت Multi-User
                try
                {
                    DatabaseConnection.ExecuteNonQuery(
                        $"ALTER DATABASE [{DatabaseName}] SET MULTI_USER;");
                }
                catch { }

                MessageBox.Show("خطا در بازیابی:\n" + ex.Message, "خطا",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---------- بروزرسانی اطلاعات ----------
        private void btnRefreshInfo_Click(object sender, EventArgs e)
        {
            LoadDatabaseInfo();
            AddLog("اطلاعات دیتابیس بروز شد.");
        }
    }
}