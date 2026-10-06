using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Windows.Forms;

namespace InventoryApp.Classes
{
    public class ReportPrinter
    {
        public enum ReportType
        {
            DailySales,
            MonthlySales,
            LowStock
        }

        private ReportType reportType;
        private string reportTitle;
        private DataTable mainData;
        private DataTable extraData;
        private string summaryText;

        // فونت‌ها
        private Font titleFont = new Font("Tahoma", 16, FontStyle.Bold);
        private Font headerFont = new Font("Tahoma", 11, FontStyle.Bold);
        private Font normalFont = new Font("Tahoma", 10);
        private Font smallFont = new Font("Tahoma", 8);

        private const int PageWidth = 827;
        private const int Margin = 40;

        public ReportPrinter(ReportType type, string title, DataTable mainData,
            DataTable extraData = null, string summaryText = "")
        {
            this.reportType = type;
            this.reportTitle = title;
            this.mainData = mainData;
            this.extraData = extraData;
            this.summaryText = summaryText;
        }

        public void ShowPreview()
        {
            PrintDocument pd = new PrintDocument();
            pd.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1169);
            pd.DefaultPageSettings.Margins = new Margins(Margin, Margin, Margin, Margin);
            pd.PrintPage += Pd_PrintPage;

            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = pd;
            preview.WindowState = FormWindowState.Maximized;
            preview.Text = "پیش‌نمایش چاپ: " + reportTitle;
            preview.ShowDialog();
        }

        public void Print()
        {
            PrintDocument pd = new PrintDocument();
            pd.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1169);
            pd.DefaultPageSettings.Margins = new Margins(Margin, Margin, Margin, Margin);
            pd.PrintPage += Pd_PrintPage;

            PrintDialog dialog = new PrintDialog();
            dialog.Document = pd;
            if (dialog.ShowDialog() == DialogResult.OK)
                pd.Print();
        }

        private void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            int y = Margin;
            int rightEdge = PageWidth - Margin;
            int centerX = PageWidth / 2;

            StringFormat centerFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            StringFormat rightFormat = new StringFormat
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Center,
                FormatFlags = StringFormatFlags.DirectionRightToLeft
            };

            // ---------- هدر ----------
            g.DrawString(SettingsHelper.ShopName, titleFont, Brushes.Black,
    new RectangleF(Margin, y, rightEdge - Margin, 30), centerFormat);

            PersianCalendar pc = new PersianCalendar();
            DateTime now = DateTime.Now;
            string today = string.Format("{0}/{1}/{2} - {3:HH:mm}",
                pc.GetYear(now), pc.GetMonth(now).ToString("00"),
                pc.GetDayOfMonth(now).ToString("00"), now);

            g.DrawString("تاریخ چاپ: " + today, smallFont, Brushes.Gray,
                new RectangleF(Margin, y, rightEdge - Margin, 20), centerFormat);
            y += 20;

            g.DrawLine(new Pen(Color.Black, 2), Margin, y, rightEdge, y);
            y += 15;

            // ---------- عنوان گزارش ----------
            g.DrawString(reportTitle, headerFont, Brushes.DarkBlue,
                new RectangleF(Margin, y, rightEdge - Margin, 28), centerFormat);
            y += 35;

            // ---------- خلاصه ----------
            if (!string.IsNullOrWhiteSpace(summaryText))
            {
                g.FillRectangle(Brushes.LightYellow, Margin, y, rightEdge - Margin, 50);
                g.DrawRectangle(Pens.Gray, Margin, y, rightEdge - Margin, 50);
                g.DrawString(summaryText, normalFont, Brushes.Black,
                    new RectangleF(Margin + 5, y + 5, rightEdge - Margin - 10, 40), rightFormat);
                y += 60;
            }

            // ---------- جدول اصلی ----------
            if (mainData != null && mainData.Rows.Count > 0)
            {
                y = DrawTable(g, mainData, y, rightEdge);
            }
            else
            {
                g.DrawString("داده‌ای برای نمایش وجود ندارد.", normalFont, Brushes.Gray,
                    new RectangleF(Margin, y, rightEdge - Margin, 30), centerFormat);
                y += 40;
            }

            // ---------- جدول اضافی ----------
            if (extraData != null && extraData.Rows.Count > 0)
            {
                y += 20;
                g.DrawString("جدول تکمیلی:", headerFont, Brushes.DarkBlue,
                    new RectangleF(Margin, y, rightEdge - Margin, 25), rightFormat);
                y += 30;
                y = DrawTable(g, extraData, y, rightEdge);
            }

            // ---------- پاورقی ----------
            g.DrawLine(Pens.Gray, Margin, y + 10, rightEdge, y + 10);
            g.DrawString("سیستم مدیریت انبار و فروش — نسخه 1.0", smallFont, Brushes.Gray,
                new RectangleF(Margin, y + 15, rightEdge - Margin, 20), centerFormat);
        }

        // ---------- رسم جدول عمومی ----------
        private int DrawTable(Graphics g, DataTable dt, int startY, int rightEdge)
        {
            int y = startY;
            int cols = dt.Columns.Count;
            int tableWidth = rightEdge - Margin;
            int colWidth = tableWidth / cols;
            int rowHeight = 28;

            StringFormat headerCell = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center,
                FormatFlags = StringFormatFlags.DirectionRightToLeft
            };

            // هدر
            g.FillRectangle(Brushes.LightGray, Margin, y, tableWidth, rowHeight);
            g.DrawRectangle(Pens.Black, Margin, y, tableWidth, rowHeight);

            for (int i = 0; i < cols; i++)
            {
                int x = rightEdge - (i + 1) * colWidth;
                g.DrawString(dt.Columns[i].ColumnName, headerFont, Brushes.Black,
                    new RectangleF(x, y, colWidth, rowHeight), headerCell);
                g.DrawLine(Pens.Black, x, y, x, y + rowHeight);
            }
            y += rowHeight;

            // ردیف‌ها
            foreach (DataRow row in dt.Rows)
            {
                g.DrawRectangle(Pens.Black, Margin, y, tableWidth, rowHeight);

                for (int i = 0; i < cols; i++)
                {
                    int x = rightEdge - (i + 1) * colWidth;
                    string val = row[i]?.ToString() ?? "";
                    g.DrawString(val, normalFont, Brushes.Black,
                        new RectangleF(x, y, colWidth, rowHeight), headerCell);
                    g.DrawLine(Pens.Black, x, y, x, y + rowHeight);
                }
                y += rowHeight;
            }

            return y;
        }
    }
}