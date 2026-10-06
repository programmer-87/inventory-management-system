using System;
using System.Data;
using System.Data.SqlClient;

namespace InventoryApp.Classes
{
    public static class SettingsHelper
    {
        private static System.Collections.Generic.Dictionary<string, string> cache =
            new System.Collections.Generic.Dictionary<string, string>();

        /// <summary>
        /// گرفتن یه مقدار از تنظیمات
        /// </summary>
        public static string Get(string key, string defaultValue = "")
        {
            // اگه توی کش هست، برگردون
            if (cache.ContainsKey(key))
                return cache[key];

            try
            {
                string query = "SELECT SettingValue FROM Settings WHERE SettingKey = @k";
                SqlParameter[] param = { new SqlParameter("@k", key) };

                object result = DatabaseConnection.ExecuteScalar(query, param);
                string value = result != null && result != DBNull.Value
                    ? result.ToString()
                    : defaultValue;

                // ذخیره در کش
                cache[key] = value;
                return value;
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// ذخیره یه مقدار توی تنظیمات
        /// </summary>
        public static bool Set(string key, string value)
        {
            try
            {
                // چک کن آیا کلید وجود داره
                string checkQuery = "SELECT COUNT(*) FROM Settings WHERE SettingKey = @k";
                SqlParameter[] checkParam = { new SqlParameter("@k", key) };
                int exists = Convert.ToInt32(DatabaseConnection.ExecuteScalar(checkQuery, checkParam));

                string query;
                SqlParameter[] param;

                if (exists > 0)
                {
                    query = "UPDATE Settings SET SettingValue = @v, UpdatedAt = GETDATE() WHERE SettingKey = @k";
                    param = new SqlParameter[]
                    {
                        new SqlParameter("@k", key),
                        new SqlParameter("@v", (object)value ?? DBNull.Value)
                    };
                }
                else
                {
                    query = "INSERT INTO Settings (SettingKey, SettingValue) VALUES (@k, @v)";
                    param = new SqlParameter[]
                    {
                        new SqlParameter("@k", key),
                        new SqlParameter("@v", (object)value ?? DBNull.Value)
                    };
                }

                int result = DatabaseConnection.ExecuteNonQuery(query, param);

                // آپدیت کش
                cache[key] = value;

                return result > 0;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// پاک کردن کش (وقتی تنظیمات عوض شدن)
        /// </summary>
        public static void ClearCache()
        {
            cache.Clear();
        }

        // ---------- متدهای میانبر ----------
        public static string ShopName
        {
            get { return Get("ShopName", "فروشگاه من"); }
            set { Set("ShopName", value); }
        }

        public static string ShopAddress
        {
            get { return Get("ShopAddress", ""); }
            set { Set("ShopAddress", value); }
        }

        public static string ShopPhone
        {
            get { return Get("ShopPhone", ""); }
            set { Set("ShopPhone", value); }
        }

        public static string ShopSlogan
        {
            get { return Get("ShopSlogan", ""); }
            set { Set("ShopSlogan", value); }
        }

        public static string InvoiceFooter
        {
            get { return Get("InvoiceFooter", "با تشکر از خرید شما"); }
            set { Set("InvoiceFooter", value); }
        }

        public static bool ShowLogo
        {
            get { return Get("ShowLogo", "false") == "true"; }
            set { Set("ShowLogo", value ? "true" : "false"); }
        }
    }
}