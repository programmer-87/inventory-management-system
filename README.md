# 🏪 سیستم مدیریت انبار و فروش (Inventory Management System)

نرم‌افزار دسکتاپ کامل برای مدیریت موجودی، ثبت فروش و گزارش‌گیری، طراحی‌شده برای **فروشگاه‌های کوچک و متوسط** و **انبارها**.

![Status](https://img.shields.io/badge/Status-Completed-success)
![.NET](https://img.shields.io/badge/.NET%20Framework-4.8-blue)
![SQL Server](https://img.shields.io/badge/SQL%20Server-2019%2B-red)
![License](https://img.shields.io/badge/License-MIT-green)

---

## 📸 اسکرین‌شات‌ها

### 🔐 ورود به سیستم
![Login](screenshots/01-login.png)

### 📊 داشبورد
![Dashboard](screenshots/02-dashboard.png)

### 📦 مدیریت محصولات
![Products](screenshots/03-products.png)

### 🛒 فروش جدید
![Sales](screenshots/04-sales.png)

### 🧾 چاپ فاکتور
![Invoice](screenshots/05-invoice.png)

### 📈 گزارشات
![Reports](screenshots/06-reports.png)

---

## ✨ قابلیت‌ها

### 📦 مدیریت کالا
- مدیریت محصولات با جستجو، قیمت، بارکد، حد هشدار
- مدیریت دسته‌بندی محصولات
- رنگ‌بندی هوشمند محصولات کم‌موجود

### 💰 فروش
- ثبت فاکتور فروش با چند قلم کالا
- محاسبه خودکار جمع، تخفیف و قابل پرداخت
- چاپ فاکتور با قالب حرفه‌ای (Print Preview + PDF)
- لیست فروش با فیلتر تاریخ و مشتری
- حذف فاکتور با بازگرداندن موجودی

### 📊 انبار
- ثبت ورود کالا (خرید از تأمین‌کننده)
- ثبت خروج کالا (ضایعات، مرجوعی)
- مشاهده تاریخچه حرکات انبار با فیلتر

### 👥 مشتریان
- مدیریت مشتریان با نمایش تعداد خرید و مجموع خرید
- جستجو با نام یا تلفن

### 🔐 کاربران
- مدیریت کاربران با دو نقش (Admin / User)
- رمز عبور Hash شده با SHA-256
- محدودیت دسترسی برای کاربران عادی

### 📈 گزارشات
- گزارش فروش روزانه (با نمودار پرفروش‌ترین‌ها)
- گزارش فروش ماهانه (با تقویم شمسی)
- گزارش محصولات رو به اتمام
- **چاپ تمام گزارشات**

### 🛠 ابزارها
- **پشتیبان‌گیری و بازیابی** دیتابیس
- **تنظیمات فروشگاه** (نام، آدرس، تلفن، شعار)
- **داشبورد** با آمار زنده

### ⌨️ کلیدهای میانبر
- `Ctrl+F` جستجو
- `Ctrl+S` ذخیره
- `Ctrl+N` جدید
- `F2` فوکوس روی محصول
- `F4` فوکوس روی مشتری
- `Enter` رفتن به فیلد بعدی
- `Escape` پاک کردن فرم

---

## 🛠 تکنولوژی‌ها

| بخش | تکنولوژی |
|---|---|
| زبان برنامه‌نویسی | C# |
| فریمورک | .NET Framework 4.8 |
| رابط کاربری | Windows Forms |
| دیتابیس | SQL Server 2019+ |
| کتابخانه | Microsoft.Data.SqlClient |
| امنیت | SHA-256 Password Hashing |
| چاپ | PrintDocument + Print Preview |

---

## 🚀 نصب و اجرا

### 📋 پیش‌نیازها

- **Visual Studio 2022** (با Workload: .NET desktop development)
- **SQL Server** (هر نسخه‌ای: Express, Developer, Standard)
- **.NET Framework 4.8**

### 🔧 نصب

```bash
# ۱. کلون کردن پروژه
git clone https://github.com/your-username/inventory-management.git

# ۲. باز کردن Solution در Visual Studio
# فایل InventoryApp.sln رو دابل‌کلیک کنید

# ۳. Build
Ctrl + Shift + B

# ۴. اجرا
F5
```

### 🗄 دیتابیس

برنامه **اولین بار** که اجرا میشه، به صورت خودکار:
- دیتابیس `InventoryDB` رو می‌سازه
- جدول‌ها رو ایجاد می‌کنه
- کاربر `admin` پیش‌فرض رو می‌سازه
- دسته‌بندی و محصولات نمونه اضافه می‌کنه

**اطلاعات ورود پیش‌فرض:**
```
👤 نام کاربری: admin
🔑 رمز عبور:  admin123
```

⚠️ **مهم:** بعد از اولین ورود، رمز عبور رو تغییر بدید!

---

## 📁 ساختار پروژه

```
InventoryApp/
├── Classes/                    # کلاس‌های منطقی
│   ├── DatabaseConnection.cs   # اتصال به دیتابیس
│   ├── DatabaseInitializer.cs  # ساخت خودکار دیتابیس
│   ├── SecurityHelper.cs       # Hash رمز عبور
│   ├── SettingsHelper.cs       # مدیریت تنظیمات
│   ├── Session.cs              # مدیریت کاربر جاری
│   ├── InvoicePrinter.cs       # چاپ فاکتور
│   └── ReportPrinter.cs        # چاپ گزارشات
├── Forms/                      # فرم‌های برنامه
│   ├── LoginForm.cs            # ورود
│   ├── MainForm.cs             # فرم اصلی
│   ├── DashboardForm.cs        # داشبورد
│   ├── ProductsForm.cs         # محصولات
│   ├── CategoriesForm.cs       # دسته‌بندی
│   ├── SalesForm.cs            # فروش جدید
│   ├── SalesListForm.cs        # لیست فروش
│   ├── SaleDetailForm.cs       # جزئیات فاکتور
│   ├── CustomersForm.cs        # مشتریان
│   ├── UsersForm.cs            # کاربران
│   ├── StockForm.cs            # انبار
│   ├── StockEntryForm.cs       # ورود/خروج کالا
│   ├── BackupForm.cs           # پشتیبان‌گیری
│   ├── SettingsForm.cs         # تنظیمات
│   ├── DailyReportForm.cs      # گزارش روزانه
│   ├── MonthlyReportForm.cs    # گزارش ماهانه
│   └── LowStockReportForm.cs   # محصولات کم‌موجود
└── Program.cs                  # نقطه ورود برنامه
```

---

## 🗄 جداول دیتابیس

| جدول | توضیح |
|---|---|
| `Users` | کاربران سیستم |
| `Categories` | دسته‌بندی محصولات |
| `Products` | محصولات |
| `Customers` | مشتریان |
| `Sales` | فاکتورهای فروش |
| `SaleDetails` | اقلام فاکتور |
| `StockMovements` | حرکات انبار |
| `Settings` | تنظیمات برنامه |

---

## 🎬 ویدیو دمو

[![Watch the video](screenshots/video-thumbnail.png)](https://youtu.be/YOUR_VIDEO_ID)

---

## 💡 چالش‌های فنی

### 🔐 امنیت
- پیاده‌سازی Hash رمز عبور با SHA-256
- مدیریت Session کاربر جاری
- جلوگیری از حذف کاربر جاری یا تغییر نقش خود

### 🗄 دیتابیس
- **Auto-Detect** سرور SQL Server (پیدا کردن خودکار)
- ساخت خودکار دیتابیس در اولین اجرا
- پشتیبان‌گیری و بازیابی با دستورات BACKUP/RESTORE

### 🖨 چاپ
- طراحی فاکتور با `PrintDocument` و `Graphics.DrawString`
- پیاده‌سازی `PrintPreviewDialog` برای پیش‌نمایش
- راست‌چین‌سازی خودکار متن فارسی

### 🇮🇷 بومی‌سازی
- تقویم شمسی (PersianCalendar)
- رابط کاربری Right-to-Left
- فونت‌های فارسی (Tahoma)
- فرمت اعداد با کاما (N0)

---

## 📝 مجوز

این پروژه تحت مجوز **MIT** منتشر شده. برای اطلاعات بیشتر فایل [LICENSE](LICENSE) رو ببینید.

---

## 📧 ارتباط با من

- **GitHub:** [@programmer-87](https://github.com/programmer-87)
- **Email:** aydin1387tabriz@gmail.com
- **LinkedIn:** [your-name](https://linkedin.com/in/your-name)

---

## 🙏 تشکر

اگه این پروژه به کارت اومد، یه ⭐ بهش بده!

**ساخته شده با ❤️ در ایران**