namespace InventoryApp
{
    partial class DailyReportForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvSales = new System.Windows.Forms.DataGridView();
            this.groupbox4 = new System.Windows.Forms.GroupBox();
            this.dgvTopProducts = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblAvgValue = new System.Windows.Forms.Label();
            this.lblAvgLabel = new System.Windows.Forms.Label();
            this.lblCountLabel = new System.Windows.Forms.Label();
            this.lblNetLabel = new System.Windows.Forms.Label();
            this.lblNetValue = new System.Windows.Forms.Label();
            this.lblCountValue = new System.Windows.Forms.Label();
            this.lblTotalLabel = new System.Windows.Forms.Label();
            this.lblTotalValue = new System.Windows.Forms.Label();
            this.lblDiscountValue = new System.Windows.Forms.Label();
            this.lblDiscountLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.btnToday = new System.Windows.Forms.Button();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.btnShow = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).BeginInit();
            this.groupbox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopProducts)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupbox4);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer1.Size = new System.Drawing.Size(952, 645);
            this.splitContainer1.SplitterDistance = 327;
            this.splitContainer1.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvSales);
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(934, 306);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "فاکتورهای فروش";
            // 
            // dgvSales
            // 
            this.dgvSales.AllowUserToAddRows = false;
            this.dgvSales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSales.Location = new System.Drawing.Point(3, 24);
            this.dgvSales.Name = "dgvSales";
            this.dgvSales.ReadOnly = true;
            this.dgvSales.RowHeadersWidth = 51;
            this.dgvSales.RowTemplate.Height = 24;
            this.dgvSales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSales.Size = new System.Drawing.Size(928, 279);
            this.dgvSales.TabIndex = 4;
            // 
            // groupbox4
            // 
            this.groupbox4.Controls.Add(this.dgvTopProducts);
            this.groupbox4.Location = new System.Drawing.Point(3, 7);
            this.groupbox4.Name = "groupbox4";
            this.groupbox4.Size = new System.Drawing.Size(937, 295);
            this.groupbox4.TabIndex = 0;
            this.groupbox4.TabStop = false;
            this.groupbox4.Text = "پرفروش‌ترین محصولات روز";
            // 
            // dgvTopProducts
            // 
            this.dgvTopProducts.AllowUserToAddRows = false;
            this.dgvTopProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTopProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTopProducts.Location = new System.Drawing.Point(3, 24);
            this.dgvTopProducts.Name = "dgvTopProducts";
            this.dgvTopProducts.ReadOnly = true;
            this.dgvTopProducts.RowHeadersWidth = 51;
            this.dgvTopProducts.RowTemplate.Height = 24;
            this.dgvTopProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTopProducts.Size = new System.Drawing.Size(931, 268);
            this.dgvTopProducts.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblAvgValue);
            this.groupBox2.Controls.Add(this.lblAvgLabel);
            this.groupBox2.Controls.Add(this.lblCountLabel);
            this.groupBox2.Controls.Add(this.lblNetLabel);
            this.groupBox2.Controls.Add(this.lblNetValue);
            this.groupBox2.Controls.Add(this.lblCountValue);
            this.groupBox2.Controls.Add(this.lblTotalLabel);
            this.groupBox2.Controls.Add(this.lblTotalValue);
            this.groupBox2.Controls.Add(this.lblDiscountValue);
            this.groupBox2.Controls.Add(this.lblDiscountLabel);
            this.groupBox2.Location = new System.Drawing.Point(480, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(380, 156);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "خلاصه آمار";
            // 
            // lblAvgValue
            // 
            this.lblAvgValue.AutoSize = true;
            this.lblAvgValue.Location = new System.Drawing.Point(73, 129);
            this.lblAvgValue.Name = "lblAvgValue";
            this.lblAvgValue.Size = new System.Drawing.Size(51, 21);
            this.lblAvgValue.TabIndex = 2;
            this.lblAvgValue.Text = "0 ریال";
            // 
            // lblAvgLabel
            // 
            this.lblAvgLabel.AutoSize = true;
            this.lblAvgLabel.Location = new System.Drawing.Point(259, 128);
            this.lblAvgLabel.Name = "lblAvgLabel";
            this.lblAvgLabel.Size = new System.Drawing.Size(114, 21);
            this.lblAvgLabel.TabIndex = 2;
            this.lblAvgLabel.Text = "میانگین فاکتور:";
            // 
            // lblCountLabel
            // 
            this.lblCountLabel.AutoSize = true;
            this.lblCountLabel.Location = new System.Drawing.Point(279, 29);
            this.lblCountLabel.Name = "lblCountLabel";
            this.lblCountLabel.Size = new System.Drawing.Size(95, 21);
            this.lblCountLabel.TabIndex = 2;
            this.lblCountLabel.Text = "تعداد فاکتور:";
            // 
            // lblNetLabel
            // 
            this.lblNetLabel.AutoSize = true;
            this.lblNetLabel.Location = new System.Drawing.Point(269, 103);
            this.lblNetLabel.Name = "lblNetLabel";
            this.lblNetLabel.Size = new System.Drawing.Size(104, 21);
            this.lblNetLabel.TabIndex = 2;
            this.lblNetLabel.Text = "فروش خالص:";
            // 
            // lblNetValue
            // 
            this.lblNetValue.AutoSize = true;
            this.lblNetValue.Location = new System.Drawing.Point(85, 103);
            this.lblNetValue.Name = "lblNetValue";
            this.lblNetValue.Size = new System.Drawing.Size(51, 21);
            this.lblNetValue.TabIndex = 2;
            this.lblNetValue.Text = "0 ریال";
            // 
            // lblCountValue
            // 
            this.lblCountValue.AutoSize = true;
            this.lblCountValue.Location = new System.Drawing.Point(117, 29);
            this.lblCountValue.Name = "lblCountValue";
            this.lblCountValue.Size = new System.Drawing.Size(19, 21);
            this.lblCountValue.TabIndex = 2;
            this.lblCountValue.Text = "0";
            // 
            // lblTotalLabel
            // 
            this.lblTotalLabel.AutoSize = true;
            this.lblTotalLabel.Location = new System.Drawing.Point(279, 53);
            this.lblTotalLabel.Name = "lblTotalLabel";
            this.lblTotalLabel.Size = new System.Drawing.Size(94, 21);
            this.lblTotalLabel.TabIndex = 2;
            this.lblTotalLabel.Text = "جمع فروش:";
            // 
            // lblTotalValue
            // 
            this.lblTotalValue.AutoSize = true;
            this.lblTotalValue.Location = new System.Drawing.Point(85, 53);
            this.lblTotalValue.Name = "lblTotalValue";
            this.lblTotalValue.Size = new System.Drawing.Size(51, 21);
            this.lblTotalValue.TabIndex = 2;
            this.lblTotalValue.Text = "0 ریال";
            // 
            // lblDiscountValue
            // 
            this.lblDiscountValue.AutoSize = true;
            this.lblDiscountValue.Location = new System.Drawing.Point(85, 78);
            this.lblDiscountValue.Name = "lblDiscountValue";
            this.lblDiscountValue.Size = new System.Drawing.Size(51, 21);
            this.lblDiscountValue.TabIndex = 2;
            this.lblDiscountValue.Text = "0 ریال";
            // 
            // lblDiscountLabel
            // 
            this.lblDiscountLabel.AutoSize = true;
            this.lblDiscountLabel.Location = new System.Drawing.Point(274, 78);
            this.lblDiscountLabel.Name = "lblDiscountLabel";
            this.lblDiscountLabel.Size = new System.Drawing.Size(99, 21);
            this.lblDiscountLabel.TabIndex = 2;
            this.lblDiscountLabel.Text = "جمع تخفیف:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPrint);
            this.groupBox1.Controls.Add(this.lblDate);
            this.groupBox1.Controls.Add(this.btnToday);
            this.groupBox1.Controls.Add(this.dtpDate);
            this.groupBox1.Controls.Add(this.btnShow);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(462, 122);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "انتخاب تاریخ";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(6, 40);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(93, 32);
            this.btnPrint.TabIndex = 3;
            this.btnPrint.Text = "🖨️ چاپ";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(407, 40);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(49, 21);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "تاریخ:";
            // 
            // btnToday
            // 
            this.btnToday.Location = new System.Drawing.Point(102, 67);
            this.btnToday.Name = "btnToday";
            this.btnToday.Size = new System.Drawing.Size(93, 32);
            this.btnToday.TabIndex = 3;
            this.btnToday.Text = "📅 امروز";
            this.btnToday.UseVisualStyleBackColor = true;
            this.btnToday.Click += new System.EventHandler(this.btnToday_Click);
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(201, 40);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 28);
            this.dtpDate.TabIndex = 2;
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(102, 29);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(93, 32);
            this.btnShow.TabIndex = 3;
            this.btnShow.Text = "🔍 نمایش گزارش";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // DailyReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 645);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DailyReportForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "گزارش فروش روزانه";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DailyReportForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).EndInit();
            this.groupbox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopProducts)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblAvgValue;
        private System.Windows.Forms.Label lblAvgLabel;
        private System.Windows.Forms.Label lblCountLabel;
        private System.Windows.Forms.Label lblNetLabel;
        private System.Windows.Forms.Label lblNetValue;
        private System.Windows.Forms.Label lblCountValue;
        private System.Windows.Forms.Label lblTotalLabel;
        private System.Windows.Forms.Label lblTotalValue;
        private System.Windows.Forms.Label lblDiscountValue;
        private System.Windows.Forms.Label lblDiscountLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvSales;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Button btnToday;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupbox4;
        private System.Windows.Forms.DataGridView dgvTopProducts;
    }
}