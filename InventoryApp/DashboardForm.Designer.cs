namespace InventoryApp
{
    partial class DashboardForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTodayDate = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.pnlProducts = new System.Windows.Forms.Panel();
            this.lblCustomersValue = new System.Windows.Forms.Label();
            this.pnlCustomers = new System.Windows.Forms.Label();
            this.lblInvoicesValue = new System.Windows.Forms.Label();
            this.pnlInvoices = new System.Windows.Forms.Label();
            this.lblProductsValue = new System.Windows.Forms.Label();
            this.lblSalesTodayValue = new System.Windows.Forms.Label();
            this.pnlSalesToday = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvLowStock = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvTopProducts = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvRecentSales = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnNewSale = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.pnlProducts.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLowStock)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopProducts)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentSales)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.lblTodayDate);
            this.panel1.Controls.Add(this.lblWelcome);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(823, 71);
            this.panel1.TabIndex = 0;
            // 
            // lblTodayDate
            // 
            this.lblTodayDate.AutoSize = true;
            this.lblTodayDate.Location = new System.Drawing.Point(725, 42);
            this.lblTodayDate.Name = "lblTodayDate";
            this.lblTodayDate.Size = new System.Drawing.Size(95, 21);
            this.lblTodayDate.TabIndex = 1;
            this.lblTodayDate.Text = "(تاریخ امروز)";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Location = new System.Drawing.Point(729, 9);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(91, 21);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "خوش آمدید";
            // 
            // pnlProducts
            // 
            this.pnlProducts.Controls.Add(this.lblCustomersValue);
            this.pnlProducts.Controls.Add(this.pnlCustomers);
            this.pnlProducts.Controls.Add(this.lblInvoicesValue);
            this.pnlProducts.Controls.Add(this.pnlInvoices);
            this.pnlProducts.Controls.Add(this.lblProductsValue);
            this.pnlProducts.Controls.Add(this.lblSalesTodayValue);
            this.pnlProducts.Controls.Add(this.pnlSalesToday);
            this.pnlProducts.Location = new System.Drawing.Point(0, 77);
            this.pnlProducts.Name = "pnlProducts";
            this.pnlProducts.Size = new System.Drawing.Size(823, 87);
            this.pnlProducts.TabIndex = 2;
            // 
            // lblCustomersValue
            // 
            this.lblCustomersValue.AutoSize = true;
            this.lblCustomersValue.Location = new System.Drawing.Point(90, 13);
            this.lblCustomersValue.Name = "lblCustomersValue";
            this.lblCustomersValue.Size = new System.Drawing.Size(92, 21);
            this.lblCustomersValue.TabIndex = 1;
            this.lblCustomersValue.Text = "👥 مشتریان";
            // 
            // pnlCustomers
            // 
            this.pnlCustomers.AutoSize = true;
            this.pnlCustomers.Location = new System.Drawing.Point(207, 13);
            this.pnlCustomers.Name = "pnlCustomers";
            this.pnlCustomers.Size = new System.Drawing.Size(92, 21);
            this.pnlCustomers.TabIndex = 1;
            this.pnlCustomers.Text = "👥 مشتریان";
            // 
            // lblInvoicesValue
            // 
            this.lblInvoicesValue.AutoSize = true;
            this.lblInvoicesValue.Location = new System.Drawing.Point(403, 61);
            this.lblInvoicesValue.Name = "lblInvoicesValue";
            this.lblInvoicesValue.Size = new System.Drawing.Size(87, 21);
            this.lblInvoicesValue.TabIndex = 1;
            this.lblInvoicesValue.Text = "🛒 فاکتورها";
            // 
            // pnlInvoices
            // 
            this.pnlInvoices.AutoSize = true;
            this.pnlInvoices.Location = new System.Drawing.Point(539, 56);
            this.pnlInvoices.Name = "pnlInvoices";
            this.pnlInvoices.Size = new System.Drawing.Size(87, 21);
            this.pnlInvoices.TabIndex = 1;
            this.pnlInvoices.Text = "🛒 فاکتورها";
            // 
            // lblProductsValue
            // 
            this.lblProductsValue.AutoSize = true;
            this.lblProductsValue.Location = new System.Drawing.Point(227, 56);
            this.lblProductsValue.Name = "lblProductsValue";
            this.lblProductsValue.Size = new System.Drawing.Size(51, 21);
            this.lblProductsValue.TabIndex = 1;
            this.lblProductsValue.Text = "(عدد)";
            // 
            // lblSalesTodayValue
            // 
            this.lblSalesTodayValue.AutoSize = true;
            this.lblSalesTodayValue.Location = new System.Drawing.Point(379, 13);
            this.lblSalesTodayValue.Name = "lblSalesTodayValue";
            this.lblSalesTodayValue.Size = new System.Drawing.Size(111, 21);
            this.lblSalesTodayValue.TabIndex = 1;
            this.lblSalesTodayValue.Text = "💰 فروش امروز";
            // 
            // pnlSalesToday
            // 
            this.pnlSalesToday.AutoSize = true;
            this.pnlSalesToday.Location = new System.Drawing.Point(515, 13);
            this.pnlSalesToday.Name = "pnlSalesToday";
            this.pnlSalesToday.Size = new System.Drawing.Size(111, 21);
            this.pnlSalesToday.TabIndex = 1;
            this.pnlSalesToday.Text = "💰 فروش امروز";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Location = new System.Drawing.Point(0, 170);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(823, 217);
            this.panel2.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvLowStock);
            this.groupBox2.Location = new System.Drawing.Point(3, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(404, 211);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "محصولات رو به اتمام";
            // 
            // dgvLowStock
            // 
            this.dgvLowStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLowStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLowStock.Location = new System.Drawing.Point(3, 24);
            this.dgvLowStock.Name = "dgvLowStock";
            this.dgvLowStock.RowHeadersWidth = 51;
            this.dgvLowStock.RowTemplate.Height = 24;
            this.dgvLowStock.Size = new System.Drawing.Size(398, 184);
            this.dgvLowStock.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvTopProducts);
            this.groupBox1.Location = new System.Drawing.Point(412, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(404, 211);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "پرفروش‌ترین محصولات هفته";
            // 
            // dgvTopProducts
            // 
            this.dgvTopProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTopProducts.Location = new System.Drawing.Point(3, 24);
            this.dgvTopProducts.Name = "dgvTopProducts";
            this.dgvTopProducts.RowHeadersWidth = 51;
            this.dgvTopProducts.RowTemplate.Height = 24;
            this.dgvTopProducts.Size = new System.Drawing.Size(398, 184);
            this.dgvTopProducts.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox3);
            this.panel3.Location = new System.Drawing.Point(0, 393);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(823, 188);
            this.panel3.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvRecentSales);
            this.groupBox3.Location = new System.Drawing.Point(6, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(810, 182);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "آخرین فاکتورها";
            // 
            // dgvRecentSales
            // 
            this.dgvRecentSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecentSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRecentSales.Location = new System.Drawing.Point(3, 24);
            this.dgvRecentSales.Name = "dgvRecentSales";
            this.dgvRecentSales.RowHeadersWidth = 51;
            this.dgvRecentSales.RowTemplate.Height = 24;
            this.dgvRecentSales.Size = new System.Drawing.Size(804, 155);
            this.dgvRecentSales.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnRefresh);
            this.panel4.Controls.Add(this.btnReports);
            this.panel4.Controls.Add(this.btnNewSale);
            this.panel4.Location = new System.Drawing.Point(0, 587);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(823, 87);
            this.panel4.TabIndex = 2;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(207, 13);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(99, 61);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "🔄 بروزرسانی";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnReports
            // 
            this.btnReports.Location = new System.Drawing.Point(364, 13);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(99, 61);
            this.btnReports.TabIndex = 0;
            this.btnReports.Text = "📊 گزارشات";
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnNewSale
            // 
            this.btnNewSale.Location = new System.Drawing.Point(523, 13);
            this.btnNewSale.Name = "btnNewSale";
            this.btnNewSale.Size = new System.Drawing.Size(99, 61);
            this.btnNewSale.TabIndex = 0;
            this.btnNewSale.Text = "🛒 فروش جدید";
            this.btnNewSale.UseVisualStyleBackColor = true;
            this.btnNewSale.Click += new System.EventHandler(this.btnNewSale_Click);
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 692);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.pnlProducts);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DashboardForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "داشبورد";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DashboardForm_Load);
            this.Click += new System.EventHandler(this.DashboardForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlProducts.ResumeLayout(false);
            this.pnlProducts.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLowStock)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopProducts)).EndInit();
            this.panel3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentSales)).EndInit();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTodayDate;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Panel pnlProducts;
        private System.Windows.Forms.Label lblProductsValue;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvTopProducts;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvLowStock;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvRecentSales;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnNewSale;
        private System.Windows.Forms.Label pnlCustomers;
        private System.Windows.Forms.Label pnlInvoices;
        private System.Windows.Forms.Label pnlSalesToday;
        private System.Windows.Forms.Label lblCustomersValue;
        private System.Windows.Forms.Label lblInvoicesValue;
        private System.Windows.Forms.Label lblSalesTodayValue;
    }
}