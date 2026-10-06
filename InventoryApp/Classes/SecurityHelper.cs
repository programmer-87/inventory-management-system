using System;
using System.Security.Cryptography;
using System.Text;

namespace InventoryApp.Classes
{
    public static class SecurityHelper
    {
        /// <summary>
        /// رمز عبور رو با SHA256 هش می‌کنه و به Hex برمی‌گردونه
        /// </summary>
        public static string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                return string.Empty;

            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha.ComputeHash(bytes);

                // تبدیل به Hex (بدون +، /، =)
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hash)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }

        /// <summary>
        /// چک می‌کنه آیا رمز وارد شده با هش ذخیره شده مطابقت داره
        /// </summary>
        public static bool VerifyPassword(string enteredPassword, string storedHash)
        {
            string enteredHash = HashPassword(enteredPassword);
            return string.Equals(enteredHash, storedHash, StringComparison.OrdinalIgnoreCase);
        }
    }
}