namespace InventoryApp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.کالاهاToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProducts = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCategories = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStock = new System.Windows.Forms.ToolStripMenuItem();
            this.فروشToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewSale = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSalesList = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCustomers = new System.Windows.Forms.ToolStripMenuItem();
            this.گزارشاتToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDailyReport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMonthlyReport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLowStock = new System.Windows.Forms.ToolStripMenuItem();
            this.مدیریتToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.ابزارهاToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.راهنماToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.mnuDashboard = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.کالاهاToolStripMenuItem,
            this.فروشToolStripMenuItem,
            this.گزارشاتToolStripMenuItem,
            this.مدیریتToolStripMenuItem,
            this.ابزارهاToolStripMenuItem,
            this.mnuDashboard,
            this.راهنماToolStripMenuItem,
            this.mnuExit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(615, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // کالاهاToolStripMenuItem
            // 
            this.کالاهاToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuProducts,
            this.mnuCategories,
            this.mnuStock});
            this.کالاهاToolStripMenuItem.Name = "کالاهاToolStripMenuItem";
            this.کالاهاToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.کالاهاToolStripMenuItem.Text = "کالاها";
            this.کالاهاToolStripMenuItem.Click += new System.EventHandler(this.کالاهاToolStripMenuItem_Click);
            // 
            // mnuProducts
            // 
            this.mnuProducts.Name = "mnuProducts";
            this.mnuProducts.Size = new System.Drawing.Size(208, 26);
            this.mnuProducts.Text = "مدیریت محصولات";
            this.mnuProducts.Click += new System.EventHandler(this.mnuProducts_Click);
            // 
            // mnuCategories
            // 
            this.mnuCategories.Name = "mnuCategories";
            this.mnuCategories.Size = new System.Drawing.Size(208, 26);
            this.mnuCategories.Text = "دسته‌بندی‌ها";
            this.mnuCategories.Click += new System.EventHandler(this.mnuCategories_Click);
            // 
            // mnuStock
            // 
            this.mnuStock.Name = "mnuStock";
            this.mnuStock.Size = new System.Drawing.Size(208, 26);
            this.mnuStock.Text = "موجودی انبار";
            this.mnuStock.Click += new System.EventHandler(this.mnuStock_Click);
            // 
            // فروشToolStripMenuItem
            // 
            this.فروشToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNewSale,
            this.mnuSalesList,
            this.mnuCustomers});
            this.فروشToolStripMenuItem.Name = "فروشToolStripMenuItem";
            this.فروشToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
            this.فروشToolStripMenuItem.Text = "فروش";
            // 
            // mnuNewSale
            // 
            this.mnuNewSale.Name = "mnuNewSale";
            this.mnuNewSale.Size = new System.Drawing.Size(172, 26);
            this.mnuNewSale.Text = "فروش جدید";
            this.mnuNewSale.Click += new System.EventHandler(this.mnuNewSale_Click);
            // 
            // mnuSalesList
            // 
            this.mnuSalesList.Name = "mnuSalesList";
            this.mnuSalesList.Size = new System.Drawing.Size(172, 26);
            this.mnuSalesList.Text = "لیست فروش";
            this.mnuSalesList.Click += new System.EventHandler(this.mnuSalesList_Click);
            // 
            // mnuCustomers
            // 
            this.mnuCustomers.Name = "mnuCustomers";
            this.mnuCustomers.Size = new System.Drawing.Size(172, 26);
            this.mnuCustomers.Text = "مشتریان";
            this.mnuCustomers.Click += new System.EventHandler(this.mnuCustomers_Click);
            // 
            // گزارشاتToolStripMenuItem
            // 
            this.گزارشاتToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDailyReport,
            this.mnuMonthlyReport,
            this.mnuLowStock});
            this.گزارشاتToolStripMenuItem.Name = "گزارشاتToolStripMenuItem";
            this.گزارشاتToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.گزارشاتToolStripMenuItem.Text = "گزارشات";
            // 
            // mnuDailyReport
            // 
            this.mnuDailyReport.Name = "mnuDailyReport";
            this.mnuDailyReport.Size = new System.Drawing.Size(225, 26);
            this.mnuDailyReport.Text = "گزارش روزانه";
            this.mnuDailyReport.Click += new System.EventHandler(this.mnuDailyReport_Click);
            // 
            // mnuMonthlyReport
            // 
            this.mnuMonthlyReport.Name = "mnuMonthlyReport";
            this.mnuMonthlyReport.Size = new System.Drawing.Size(225, 26);
            this.mnuMonthlyReport.Text = "گزارش ماهانه";
            this.mnuMonthlyReport.Click += new System.EventHandler(this.mnuMonthlyReport_Click);
            // 
            // mnuLowStock
            // 
            this.mnuLowStock.Name = "mnuLowStock";
            this.mnuLowStock.Size = new System.Drawing.Size(225, 26);
            this.mnuLowStock.Text = "محصولات رو به اتمام";
            this.mnuLowStock.Click += new System.EventHandler(this.mnuLowStock_Click);
            // 
            // مدیریتToolStripMenuItem
            // 
            this.مدیریتToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuUsers,
            this.mnuLogout});
            this.مدیریتToolStripMenuItem.Name = "مدیریتToolStripMenuItem";
            this.مدیریتToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            this.مدیریتToolStripMenuItem.Text = "مدیریت";
            // 
            // mnuUsers
            // 
            this.mnuUsers.Name = "mnuUsers";
            this.mnuUsers.Size = new System.Drawing.Size(182, 26);
            this.mnuUsers.Text = "کاربران";
            this.mnuUsers.Click += new System.EventHandler(this.mnuUsers_Click);
            // 
            // mnuLogout
            // 
            this.mnuLogout.Name = "mnuLogout";
            this.mnuLogout.Size = new System.Drawing.Size(182, 26);
            this.mnuLogout.Text = "خروج از حساب";
            this.mnuLogout.Click += new System.EventHandler(this.mnuLogout_Click);
            // 
            // ابزارهاToolStripMenuItem
            // 
            this.ابزارهاToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBackup,
            this.mnuSettings});
            this.ابزارهاToolStripMenuItem.Name = "ابزارهاToolStripMenuItem";
            this.ابزارهاToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.ابزارهاToolStripMenuItem.Text = "ابزار ها";
            // 
            // mnuBackup
            // 
            this.mnuBackup.Name = "mnuBackup";
            this.mnuBackup.Size = new System.Drawing.Size(227, 26);
            this.mnuBackup.Text = "پشتیبان‌گیری و بازیابی";
            this.mnuBackup.Click += new System.EventHandler(this.mnuBackup_Click);
            // 
            // mnuSettings
            // 
            this.mnuSettings.Name = "mnuSettings";
            this.mnuSettings.Size = new System.Drawing.Size(227, 26);
            this.mnuSettings.Text = "تنظیمات";
            this.mnuSettings.Click += new System.EventHandler(this.mnuSettings_Click);
            // 
            // راهنماToolStripMenuItem
            // 
            this.راهنماToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAbout});
            this.راهنماToolStripMenuItem.Name = "راهنماToolStripMenuItem";
            this.راهنماToolStripMenuItem.Size = new System.Drawing.Size(60, 24);
            this.راهنماToolStripMenuItem.Text = "راهنما";
            // 
            // mnuAbout
            // 
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(145, 26);
            this.mnuAbout.Text = "درباره ما";
            this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(55, 24);
            this.mnuExit.Text = "خروج";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUser,
            this.lblDate});
            this.statusStrip1.Location = new System.Drawing.Point(0, 433);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(615, 26);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblUser
            // 
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(151, 20);
            this.lblUser.Text = "toolStripStatusLabel1";
            // 
            // lblDate
            // 
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(151, 20);
            this.lblDate.Text = "toolStripStatusLabel2";
            // 
            // mnuDashboard
            // 
            this.mnuDashboard.Name = "mnuDashboard";
            this.mnuDashboard.Size = new System.Drawing.Size(74, 24);
            this.mnuDashboard.Text = "داشبورد";
            this.mnuDashboard.Click += new System.EventHandler(this.mnuDashboard_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 459);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "سیستم مدیریت انبار و فروش";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem کالاهاToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuProducts;
        private System.Windows.Forms.ToolStripMenuItem mnuCategories;
        private System.Windows.Forms.ToolStripMenuItem mnuStock;
        private System.Windows.Forms.ToolStripMenuItem فروشToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuNewSale;
        private System.Windows.Forms.ToolStripMenuItem mnuSalesList;
        private System.Windows.Forms.ToolStripMenuItem mnuCustomers;
        private System.Windows.Forms.ToolStripMenuItem گزارشاتToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuDailyReport;
        private System.Windows.Forms.ToolStripMenuItem mnuMonthlyReport;
        private System.Windows.Forms.ToolStripMenuItem mnuLowStock;
        private System.Windows.Forms.ToolStripMenuItem مدیریتToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuUsers;
        private System.Windows.Forms.ToolStripMenuItem mnuLogout;
        private System.Windows.Forms.ToolStripMenuItem راهنماToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblUser;
        private System.Windows.Forms.ToolStripStatusLabel lblDate;
        private System.Windows.Forms.ToolStripMenuItem ابزارهاToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuBackup;
        private System.Windows.Forms.ToolStripMenuItem mnuSettings;
        private System.Windows.Forms.ToolStripMenuItem mnuDashboard;
    }
}