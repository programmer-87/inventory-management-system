using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Classes
{
        public static class Session
        {
            public static int UserID { get; set; } = 0;
            public static string FullName { get; set; } = "";
            public static string Role { get; set; } = "";
            public static bool IsLoggedIn => UserID > 0;
        }
    }