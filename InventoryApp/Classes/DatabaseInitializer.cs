using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InventoryApp.Classes
{
    public static class DatabaseInitializer
    {
        private const string DatabaseName = "InventoryDB";

        // اسم سرور که به صورت خودکار پیدا میشه
        public static string ServerName { get; private set; } = "";

        // Connection String که به صورت خودکار ساخته میشه
        public static string MasterConnectionString
        {
            get
            {
                return $@"Data Source={ServerName};Initial Catalog=master;Integrated Security=True;TrustServerCertificate=True;";
            }
        }

        public static string DatabaseConnectionString
        {
            get
            {
                return $@"Data Source={ServerName};Initial Catalog={DatabaseName};Integrated Security=True;TrustServerCertificate=True;";
            }
        }

        /// <summary>
        /// راه‌اندازی دیتابیس: پیدا کردن سرور + ساخت دیتابیس اگه نبود
        /// </summary>
        public static bool EnsureDatabaseExists()
        {
            try
            {
                // ۱) پیدا کردن اسم سرور
                ServerName = DetectServerName();

                if (string.IsNullOrEmpty(ServerName))
                {
                    MessageBox.Show(
                        "❌ هیچ SQL Server فعالی روی این سیستم پیدا نشد.\n\n" +
                        "لطفاً مطمئن شوید SQL Server یا SQL Server Express نصب است.",
                        "خطا",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }

                // ۲) چک کن دیتابیس وجود داره؟
                if (DatabaseExists())
                    return true;

                // ۳) اگه نبود، بسازش
                CreateDatabase();
                CreateTables();
                InsertDefaultData();

                MessageBox.Show(
                    "✅ دیتابیس با موفقیت ساخته شد.\n\n" +
                    "نام کاربری: admin\n" +
                    "رمز عبور: admin123\n\n" +
                    "لطفاً بعد از ورود، رمز عبور را تغییر دهید.",
                    "راه‌اندازی اولیه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "❌ خطا در راه‌اندازی دیتابیس:\n\n" + ex.Message,
                    "خطا",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
        }

        // ---------- پیدا کردن خودکار اسم سرور ----------
        private static string DetectServerName()
        {
            // لیست سرورهای احتمالی
            string[] candidates = new string[]
            {
                "localhost",                    // Default Instance
                @".\SQLEXPRESS",                // SQL Server Express
                "(local)",                      // معادل localhost
                ".",                            // معادل localhost
                Environment.MachineName,        // اسم کامپیوتر
                @".\MSSQLSERVER",               // Default Instance
                @".\MSSQL$SQLEXPRESS",          // Express با نام سرویس
                @"(localdb)\MSSQLLocalDB",      // LocalDB (توسعه)
            };

            foreach (string server in candidates)
            {
                if (TestConnection(server))
                    return server;
            }

            return null;
        }

        // ---------- تست اتصال به یه سرور ----------
        private static bool TestConnection(string serverName)
        {
            try
            {
                string connStr = $@"Data Source={serverName};Initial Catalog=master;Integrated Security=True;TrustServerCertificate=True;Connect Timeout=3;";
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        // ---------- چک وجود دیتابیس ----------
        private static bool DatabaseExists()
        {
            using (SqlConnection conn = new SqlConnection(MasterConnectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM sys.databases WHERE name = @name";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", DatabaseName);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        // ---------- ساخت دیتابیس ----------
        private static void CreateDatabase()
        {
            using (SqlConnection conn = new SqlConnection(MasterConnectionString))
            {
                conn.Open();
                string query = $"CREATE DATABASE [{DatabaseName}]";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ---------- ساخت جدول‌ها ----------
        private static void CreateTables()
        {
            using (SqlConnection conn = new SqlConnection(DatabaseConnectionString))
            {
                conn.Open();

                string[] tables = new string[]
                {
                    @"CREATE TABLE Users (
                        UserID INT IDENTITY(1,1) PRIMARY KEY,
                        Username NVARCHAR(50) NOT NULL UNIQUE,
                        Password NVARCHAR(100) NOT NULL,
                        FullName NVARCHAR(100),
                        Role NVARCHAR(20) DEFAULT 'User',
                        CreatedAt DATETIME DEFAULT GETDATE()
                    )",

                    @"CREATE TABLE Categories (
                        CategoryID INT IDENTITY(1,1) PRIMARY KEY,
                        CategoryName NVARCHAR(100) NOT NULL
                    )",

                    @"CREATE TABLE Products (
                        ProductID INT IDENTITY(1,1) PRIMARY KEY,
                        ProductName NVARCHAR(100) NOT NULL,
                        CategoryID INT FOREIGN KEY REFERENCES Categories(CategoryID),
                        Barcode NVARCHAR(50),
                        Price DECIMAL(18,2) NOT NULL DEFAULT 0,
                        Quantity INT NOT NULL DEFAULT 0,
                        MinQuantity INT DEFAULT 5,
                        CreatedAt DATETIME DEFAULT GETDATE()
                    )",

                    @"CREATE TABLE Customers (
                        CustomerID INT IDENTITY(1,1) PRIMARY KEY,
                        FullName NVARCHAR(100) NOT NULL,
                        Phone NVARCHAR(20),
                        Address NVARCHAR(200),
                        CreatedAt DATETIME DEFAULT GETDATE()
                    )",

                    @"CREATE TABLE Sales (
                        SaleID INT IDENTITY(1,1) PRIMARY KEY,
                        CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID),
                        UserID INT FOREIGN KEY REFERENCES Users(UserID),
                        SaleDate DATETIME DEFAULT GETDATE(),
                        TotalAmount DECIMAL(18,2) NOT NULL DEFAULT 0,
                        Discount DECIMAL(18,2) DEFAULT 0,
                        FinalAmount DECIMAL(18,2) NOT NULL DEFAULT 0
                    )",

                    @"CREATE TABLE SaleDetails (
                        SaleDetailID INT IDENTITY(1,1) PRIMARY KEY,
                        SaleID INT FOREIGN KEY REFERENCES Sales(SaleID) ON DELETE CASCADE,
                        ProductID INT FOREIGN KEY REFERENCES Products(ProductID),
                        Quantity INT NOT NULL,
                        UnitPrice DECIMAL(18,2) NOT NULL,
                        TotalPrice DECIMAL(18,2) NOT NULL
                    )",

                    @"CREATE TABLE StockMovements (
                        MovementID INT IDENTITY(1,1) PRIMARY KEY,
                        ProductID INT FOREIGN KEY REFERENCES Products(ProductID),
                        MovementType NVARCHAR(10) NOT NULL,
                        Quantity INT NOT NULL,
                        MovementDate DATETIME DEFAULT GETDATE(),
                        Description NVARCHAR(200)
                    )",

                    @"CREATE TABLE Settings (
                        SettingID INT IDENTITY(1,1) PRIMARY KEY,
                        SettingKey NVARCHAR(50) NOT NULL UNIQUE,
                        SettingValue NVARCHAR(500),
                        UpdatedAt DATETIME DEFAULT GETDATE()
                    )"
                };

                foreach (string tableSql in tables)
                {
                    using (SqlCommand cmd = new SqlCommand(tableSql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        // ---------- درج داده‌های اولیه ----------
        private static void InsertDefaultData()
        {
            using (SqlConnection conn = new SqlConnection(DatabaseConnectionString))
            {
                conn.Open();

                // کاربر admin
                string adminHash = SecurityHelper.HashPassword("admin123");
                string insertAdmin = @"
                    INSERT INTO Users (Username, Password, FullName, Role) 
                    VALUES ('admin', @p, N'مدیر سیستم', 'Admin')";

                using (SqlCommand cmd = new SqlCommand(insertAdmin, conn))
                {
                    cmd.Parameters.AddWithValue("@p", adminHash);
                    cmd.ExecuteNonQuery();
                }

                // دسته‌بندی‌ها
                string insertCats = @"
                    INSERT INTO Categories (CategoryName) VALUES 
                    (N'مواد غذایی'), (N'نوشیدنی'), (N'لبنیات'), (N'شوینده')";

                using (SqlCommand cmd = new SqlCommand(insertCats, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                // محصولات نمونه
                string insertProducts = @"
                    INSERT INTO Products (ProductName, CategoryID, Barcode, Price, Quantity, MinQuantity) VALUES
                    (N'محصول نمونه ۱', 1, '1001', 50000, 10, 5),
                    (N'محصول نمونه ۲', 2, '2001', 25000, 20, 5)";

                using (SqlCommand cmd = new SqlCommand(insertProducts, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                // تنظیمات
                string insertSettings = @"
                    INSERT INTO Settings (SettingKey, SettingValue) VALUES
                    (N'ShopName', N'فروشگاه من'),
                    (N'ShopAddress', N'آدرس فروشگاه'),
                    (N'ShopPhone', N'021-00000000'),
                    (N'ShopSlogan', N''),
                    (N'InvoiceFooter', N'با تشکر از خرید شما 🌹'),
                    (N'ShowLogo', N'false')";

                using (SqlCommand cmd = new SqlCommand(insertSettings, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}