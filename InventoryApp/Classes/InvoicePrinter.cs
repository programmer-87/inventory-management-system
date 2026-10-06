using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Windows.Forms;

namespace InventoryApp.Classes
{
    public class InvoicePrinter
    {
        private int saleID;
        private DataTable saleInfo;
        private DataTable saleItems;

        // تنظیمات فونت و چیدمان
        private Font titleFont = new Font("Tahoma", 16, FontStyle.Bold);
        private Font headerFont = new Font("Tahoma", 11, FontStyle.Bold);
        private Font normalFont = new Font("Tahoma", 10, FontStyle.Regular);
        private Font smallFont = new Font("Tahoma", 8, FontStyle.Regular);
        private Font totalFont = new Font("Tahoma", 11, FontStyle.Bold);

        private const int PageWidth = 750;
        private const int PageHeight = 1050;
        private const int Margin = 40;

        public InvoicePrinter(int saleID)
        {
            this.saleID = saleID;
            LoadData();
        }

        // ---------- بارگذاری داده‌ها ----------
        private void LoadData()
        {
            // اطلاعات فاکتور
            string infoQuery = @"
                SELECT s.SaleID, s.SaleDate,
                       ISNULL(c.FullName, N'—') AS CustomerName,
                       ISNULL(c.Phone, N'—') AS CustomerPhone,
                       ISNULL(c.Address, N'—') AS CustomerAddress,
                       ISNULL(u.FullName, N'—') AS UserName,
                       s.TotalAmount, s.Discount, s.FinalAmount
                FROM Sales s
                LEFT JOIN Customers c ON s.CustomerID = c.CustomerID
                LEFT JOIN Users u ON s.UserID = u.UserID
                WHERE s.SaleID = @sid";

            SqlParameter[] p1 = { new SqlParameter("@sid", saleID) };
            saleInfo = DatabaseConnection.ExecuteQuery(infoQuery, p1);

            // اقلام فاکتور
            string itemsQuery = @"
                SELECT p.ProductName, sd.Quantity, sd.UnitPrice, sd.TotalPrice
                FROM SaleDetails sd
                INNER JOIN Products p ON sd.ProductID = p.ProductID
                WHERE sd.SaleID = @sid
                ORDER BY sd.SaleDetailID";

            SqlParameter[] p2 = { new SqlParameter("@sid", saleID) };
            saleItems = DatabaseConnection.ExecuteQuery(itemsQuery, p2);
        }

        // ---------- نمایش پیش‌نمایش چاپ ----------
        public void ShowPreview()
        {
            if (saleInfo.Rows.Count == 0)
            {
                MessageBox.Show("فاکتور پیدا نشد.", "خطا",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PrintDocument pd = new PrintDocument();
            pd.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1169);
            pd.DefaultPageSettings.Margins = new Margins(Margin, Margin, Margin, Margin);
            pd.PrintPage += Pd_PrintPage;

            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = pd;
            preview.WindowState = FormWindowState.Maximized;
            preview.Text = "پیش‌نمایش چاپ فاکتور #" + saleID;
            preview.ShowDialog();
        }

        // ---------- چاپ مستقیم ----------
        public void Print()
        {
            PrintDocument pd = new PrintDocument();
            pd.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1169);
            pd.DefaultPageSettings.Margins = new Margins(Margin, Margin, Margin, Margin);
            pd.PrintPage += Pd_PrintPage;

            PrintDialog dialog = new PrintDialog();
            dialog.Document = pd;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pd.Print();
            }
        }

        // ---------- رسم صفحه ----------
        private void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int y = Margin;
            int rightEdge = PageWidth - Margin;
            int centerX = PageWidth / 2;

            // فرمت راست‌چین برای فارسی
            StringFormat rightFormat = new StringFormat
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Near,
                FormatFlags = StringFormatFlags.DirectionRightToLeft
            };

            StringFormat centerFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            // ---------- هدر ----------
            // به جای "فروشگاه من"
            g.DrawString(SettingsHelper.ShopName, titleFont, Brushes.Black,
                new RectangleF(Margin, y, rightEdge - Margin, 30), centerFormat);
            y += 32;

            // به جای آدرس ثابت
            g.DrawString("آدرس: " + SettingsHelper.ShopAddress, smallFont, Brushes.Gray,
                new RectangleF(Margin, y, rightEdge - Margin, 20), centerFormat);
            y += 18;

            // به جای تلفن ثابت
            g.DrawString("تلفن: " + SettingsHelper.ShopPhone, smallFont, Brushes.Gray,
                new RectangleF(Margin, y, rightEdge - Margin, 20), centerFormat);
            y += 18;

            // شعار (اگه داشت)
            if (!string.IsNullOrWhiteSpace(SettingsHelper.ShopSlogan))
            {
                g.DrawString(SettingsHelper.ShopSlogan, smallFont, Brushes.Gray,
                    new RectangleF(Margin, y, rightEdge - Margin, 20), centerFormat);
                y += 18;
            }
            y += 10;

            // خط جداکننده
            g.DrawLine(new Pen(Color.Black, 2), Margin, y, rightEdge, y);
            y += 15;

            // ---------- اطلاعات فاکتور ----------
            DataRow info = saleInfo.Rows[0];
            PersianCalendar pc = new PersianCalendar();
            DateTime saleDate = Convert.ToDateTime(info["SaleDate"]);

            string invoiceNo = info["SaleID"].ToString();
            string persianDate = string.Format("{0}/{1}/{2}",
                pc.GetYear(saleDate),
                pc.GetMonth(saleDate).ToString("00"),
                pc.GetDayOfMonth(saleDate).ToString("00"));
            string time = saleDate.ToString("HH:mm");
            string customerName = info["CustomerName"].ToString();
            string customerPhone = info["CustomerPhone"].ToString();

            g.DrawString("فاکتور فروش", headerFont, Brushes.Black,
                new RectangleF(Margin, y, 200, 25), rightFormat);
            g.DrawString($"شماره: {invoiceNo}", headerFont, Brushes.Black,
                new RectangleF(rightEdge - 220, y, 220, 25), rightFormat);
            y += 28;

            g.DrawString($"تاریخ: {persianDate}   ساعت: {time}", normalFont, Brushes.Black,
                new RectangleF(rightEdge - 320, y, 320, 22), rightFormat);
            y += 25;

            g.DrawString($"مشتری: {customerName}", normalFont, Brushes.Black,
                new RectangleF(rightEdge - 320, y, 320, 22), rightFormat);
            y += 22;

            g.DrawString($"تلفن: {customerPhone}", normalFont, Brushes.Black,
                new RectangleF(rightEdge - 320, y, 320, 22), rightFormat);
            y += 22;

            g.DrawString($"کاربر: {info["UserName"]}", normalFont, Brushes.Black,
                new RectangleF(rightEdge - 320, y, 320, 22), rightFormat);
            y += 30;

            // ---------- جدول اقلام ----------
            int tableTop = y;
            int rowHeight = 30;
            int[] colWidths = { 60, 300, 80, 120, 130 }; // ردیف، نام، تعداد، قیمت، جمع
            int[] colX = new int[5];
            colX[0] = rightEdge - colWidths[0];
            colX[1] = colX[0] - colWidths[1];
            colX[2] = colX[1] - colWidths[2];
            colX[3] = colX[2] - colWidths[3];
            colX[4] = colX[3] - colWidths[4];

            // هدر جدول
            g.FillRectangle(Brushes.LightGray, Margin, y, rightEdge - Margin, rowHeight);
            g.DrawRectangle(Pens.Black, Margin, y, rightEdge - Margin, rowHeight);

            StringFormat headerCell = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center,
                FormatFlags = StringFormatFlags.DirectionRightToLeft
            };

            g.DrawString("ردیف", headerFont, Brushes.Black,
                new RectangleF(colX[0], y, colWidths[0], rowHeight), headerCell);
            g.DrawString("نام کالا", headerFont, Brushes.Black,
                new RectangleF(colX[1], y, colWidths[1], rowHeight), headerCell);
            g.DrawString("تعداد", headerFont, Brushes.Black,
                new RectangleF(colX[2], y, colWidths[2], rowHeight), headerCell);
            g.DrawString("قیمت واحد", headerFont, Brushes.Black,
                new RectangleF(colX[3], y, colWidths[3], rowHeight), headerCell);
            g.DrawString("جمع", headerFont, Brushes.Black,
                new RectangleF(colX[4], y, colWidths[4], rowHeight), headerCell);

            y += rowHeight;

            // خطوط عمودی
            for (int i = 0; i < 5; i++)
            {
                g.DrawLine(Pens.Black, colX[i], tableTop, colX[i], y + rowHeight * saleItems.Rows.Count);
            }
            g.DrawLine(Pens.Black, Margin, tableTop, Margin, y + rowHeight * saleItems.Rows.Count);

            // ردیف‌ها
            int rowNum = 1;
            foreach (DataRow item in saleItems.Rows)
            {
                g.DrawRectangle(Pens.Black, Margin, y, rightEdge - Margin, rowHeight);

                StringFormat cellFormat = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center,
                    FormatFlags = StringFormatFlags.DirectionRightToLeft
                };

                g.DrawString(rowNum.ToString(), normalFont, Brushes.Black,
                    new RectangleF(colX[0], y, colWidths[0], rowHeight), cellFormat);

                StringFormat nameFormat = new StringFormat
                {
                    Alignment = StringAlignment.Near,
                    LineAlignment = StringAlignment.Center,
                    FormatFlags = StringFormatFlags.DirectionRightToLeft
                };
                g.DrawString(item["ProductName"].ToString(), normalFont, Brushes.Black,
                    new RectangleF(colX[1], y, colWidths[1], rowHeight), nameFormat);

                g.DrawString(item["Quantity"].ToString(), normalFont, Brushes.Black,
                    new RectangleF(colX[2], y, colWidths[2], rowHeight), cellFormat);
                g.DrawString(Convert.ToDecimal(item["UnitPrice"]).ToString("N0"),
                    normalFont, Brushes.Black,
                    new RectangleF(colX[3], y, colWidths[3], rowHeight), cellFormat);
                g.DrawString(Convert.ToDecimal(item["TotalPrice"]).ToString("N0"),
                    normalFont, Brushes.Black,
                    new RectangleF(colX[4], y, colWidths[4], rowHeight), cellFormat);

                y += rowHeight;
                rowNum++;
            }

            y += 20;

            // ---------- جمع کل ----------
            int totalsX = rightEdge - 350;
            int totalsWidth = 350;

            g.DrawString("جمع کل:", totalFont, Brushes.Black,
                new RectangleF(totalsX, y, totalsWidth, 25), rightFormat);
            g.DrawString(Convert.ToDecimal(info["TotalAmount"]).ToString("N0") + " ریال",
                totalFont, Brushes.Black,
                new RectangleF(totalsX - 200, y, 200, 25), rightFormat);
            y += 25;

            g.DrawString("تخفیف:", totalFont, Brushes.Black,
                new RectangleF(totalsX, y, totalsWidth, 25), rightFormat);
            g.DrawString(Convert.ToDecimal(info["Discount"]).ToString("N0") + " ریال",
                totalFont, Brushes.Black,
                new RectangleF(totalsX - 200, y, 200, 25), rightFormat);
            y += 25;

            g.DrawLine(new Pen(Color.Black, 1), totalsX - 200, y, rightEdge, y);
            y += 5;

            g.DrawString("قابل پرداخت:", new Font("Tahoma", 13, FontStyle.Bold), Brushes.DarkGreen,
                new RectangleF(totalsX, y, totalsWidth, 30), rightFormat);
            g.DrawString(Convert.ToDecimal(info["FinalAmount"]).ToString("N0") + " ریال",
                new Font("Tahoma", 13, FontStyle.Bold), Brushes.DarkGreen,
                new RectangleF(totalsX - 220, y, 220, 30), rightFormat);
            y += 45;

            // ---------- امضا ----------
            y += 20;
            g.DrawString("امضای فروشنده: ______________", normalFont, Brushes.Black,
                new RectangleF(Margin, y, 300, 25), rightFormat);
            g.DrawString("امضای مشتری: ______________", normalFont, Brushes.Black,
                new RectangleF(rightEdge - 300, y, 300, 25), rightFormat);
            y += 50;

            // ---------- پاورقی ----------
            g.DrawLine(Pens.Gray, Margin, y, rightEdge, y);
            y += 10;

            g.DrawString(SettingsHelper.InvoiceFooter, new Font("Tahoma", 10, FontStyle.Italic),
    Brushes.DarkBlue,
    new RectangleF(Margin, y, rightEdge - Margin, 25), centerFormat);
        }
    }
}