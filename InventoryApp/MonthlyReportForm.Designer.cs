namespace InventoryApp
{
    partial class MonthlyReportForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lblYear = new System.Windows.Forms.Label();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnThisMonth = new System.Windows.Forms.Button();
            this.numYear = new System.Windows.Forms.NumericUpDown();
            this.lblMonth = new System.Windows.Forms.Label();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblBestSellerValue = new System.Windows.Forms.Label();
            this.lblCountLabel = new System.Windows.Forms.Label();
            this.lblBestSellerLabel = new System.Windows.Forms.Label();
            this.lblBestDayValue = new System.Windows.Forms.Label();
            this.lblNetValue = new System.Windows.Forms.Label();
            this.lblCountValue = new System.Windows.Forms.Label();
            this.lblBestDayLabel = new System.Windows.Forms.Label();
            this.lblTotalValue = new System.Windows.Forms.Label();
            this.lblDiscountValue = new System.Windows.Forms.Label();
            this.lblNetLabel = new System.Windows.Forms.Label();
            this.lblTotalLabel = new System.Windows.Forms.Label();
            this.lblDiscountLabel = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvDailySales = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvTopProducts = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDailySales)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPrint);
            this.groupBox1.Controls.Add(this.lblYear);
            this.groupBox1.Controls.Add(this.btnShow);
            this.groupBox1.Controls.Add(this.btnThisMonth);
            this.groupBox1.Controls.Add(this.numYear);
            this.groupBox1.Controls.Add(this.lblMonth);
            this.groupBox1.Controls.Add(this.cmbMonth);
            this.groupBox1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.groupBox1.Location = new System.Drawing.Point(946, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 217);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "انتخاب ماه";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(5, 127);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(78, 34);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "🖨️ چاپ";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(148, 36);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(49, 21);
            this.lblYear.TabIndex = 1;
            this.lblYear.Text = "سال:";
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(22, 167);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(143, 34);
            this.btnShow.TabIndex = 4;
            this.btnShow.Text = "🔍 نمایش گزارش";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnThisMonth
            // 
            this.btnThisMonth.Location = new System.Drawing.Point(89, 127);
            this.btnThisMonth.Name = "btnThisMonth";
            this.btnThisMonth.Size = new System.Drawing.Size(105, 34);
            this.btnThisMonth.TabIndex = 4;
            this.btnThisMonth.Text = "📅 ماه جاری";
            this.btnThisMonth.UseVisualStyleBackColor = true;
            this.btnThisMonth.Click += new System.EventHandler(this.btnThisMonth_Click);
            // 
            // numYear
            // 
            this.numYear.Location = new System.Drawing.Point(22, 36);
            this.numYear.Maximum = new decimal(new int[] {
            1430,
            0,
            0,
            0});
            this.numYear.Minimum = new decimal(new int[] {
            1400,
            0,
            0,
            0});
            this.numYear.Name = "numYear";
            this.numYear.Size = new System.Drawing.Size(120, 28);
            this.numYear.TabIndex = 2;
            this.numYear.Value = new decimal(new int[] {
            1400,
            0,
            0,
            0});
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(159, 86);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(38, 21);
            this.lblMonth.TabIndex = 1;
            this.lblMonth.Text = "ماه:";
            // 
            // cmbMonth
            // 
            this.cmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Location = new System.Drawing.Point(22, 83);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(120, 29);
            this.cmbMonth.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblBestSellerValue);
            this.groupBox2.Controls.Add(this.lblCountLabel);
            this.groupBox2.Controls.Add(this.lblBestSellerLabel);
            this.groupBox2.Controls.Add(this.lblBestDayValue);
            this.groupBox2.Controls.Add(this.lblNetValue);
            this.groupBox2.Controls.Add(this.lblCountValue);
            this.groupBox2.Controls.Add(this.lblBestDayLabel);
            this.groupBox2.Controls.Add(this.lblTotalValue);
            this.groupBox2.Controls.Add(this.lblDiscountValue);
            this.groupBox2.Controls.Add(this.lblNetLabel);
            this.groupBox2.Controls.Add(this.lblTotalLabel);
            this.groupBox2.Controls.Add(this.lblDiscountLabel);
            this.groupBox2.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.groupBox2.Location = new System.Drawing.Point(1152, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(317, 257);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "خلاصه ماه";
            // 
            // lblBestSellerValue
            // 
            this.lblBestSellerValue.AutoSize = true;
            this.lblBestSellerValue.Location = new System.Drawing.Point(10, 220);
            this.lblBestSellerValue.Name = "lblBestSellerValue";
            this.lblBestSellerValue.Size = new System.Drawing.Size(25, 21);
            this.lblBestSellerValue.TabIndex = 2;
            this.lblBestSellerValue.Text = "—";
            // 
            // lblCountLabel
            // 
            this.lblCountLabel.AutoSize = true;
            this.lblCountLabel.Location = new System.Drawing.Point(216, 43);
            this.lblCountLabel.Name = "lblCountLabel";
            this.lblCountLabel.Size = new System.Drawing.Size(95, 21);
            this.lblCountLabel.TabIndex = 2;
            this.lblCountLabel.Text = "تعداد فاکتور:";
            // 
            // lblBestSellerLabel
            // 
            this.lblBestSellerLabel.AutoSize = true;
            this.lblBestSellerLabel.Location = new System.Drawing.Point(184, 220);
            this.lblBestSellerLabel.Name = "lblBestSellerLabel";
            this.lblBestSellerLabel.Size = new System.Drawing.Size(127, 21);
            this.lblBestSellerLabel.TabIndex = 2;
            this.lblBestSellerLabel.Text = "بهترین فروشنده:";
            // 
            // lblBestDayValue
            // 
            this.lblBestDayValue.AutoSize = true;
            this.lblBestDayValue.Location = new System.Drawing.Point(10, 180);
            this.lblBestDayValue.Name = "lblBestDayValue";
            this.lblBestDayValue.Size = new System.Drawing.Size(25, 21);
            this.lblBestDayValue.TabIndex = 2;
            this.lblBestDayValue.Text = "—";
            // 
            // lblNetValue
            // 
            this.lblNetValue.AutoSize = true;
            this.lblNetValue.Location = new System.Drawing.Point(10, 150);
            this.lblNetValue.Name = "lblNetValue";
            this.lblNetValue.Size = new System.Drawing.Size(51, 21);
            this.lblNetValue.TabIndex = 2;
            this.lblNetValue.Text = "0 ریال";
            // 
            // lblCountValue
            // 
            this.lblCountValue.AutoSize = true;
            this.lblCountValue.Location = new System.Drawing.Point(42, 40);
            this.lblCountValue.Name = "lblCountValue";
            this.lblCountValue.Size = new System.Drawing.Size(19, 21);
            this.lblCountValue.TabIndex = 2;
            this.lblCountValue.Text = "0";
            // 
            // lblBestDayLabel
            // 
            this.lblBestDayLabel.AutoSize = true;
            this.lblBestDayLabel.Location = new System.Drawing.Point(226, 184);
            this.lblBestDayLabel.Name = "lblBestDayLabel";
            this.lblBestDayLabel.Size = new System.Drawing.Size(85, 21);
            this.lblBestDayLabel.TabIndex = 2;
            this.lblBestDayLabel.Text = "بهترین روز:";
            // 
            // lblTotalValue
            // 
            this.lblTotalValue.AutoSize = true;
            this.lblTotalValue.Location = new System.Drawing.Point(10, 80);
            this.lblTotalValue.Name = "lblTotalValue";
            this.lblTotalValue.Size = new System.Drawing.Size(51, 21);
            this.lblTotalValue.TabIndex = 2;
            this.lblTotalValue.Text = "0 ریال";
            // 
            // lblDiscountValue
            // 
            this.lblDiscountValue.AutoSize = true;
            this.lblDiscountValue.Location = new System.Drawing.Point(10, 117);
            this.lblDiscountValue.Name = "lblDiscountValue";
            this.lblDiscountValue.Size = new System.Drawing.Size(51, 21);
            this.lblDiscountValue.TabIndex = 2;
            this.lblDiscountValue.Text = "0 ریال";
            // 
            // lblNetLabel
            // 
            this.lblNetLabel.AutoSize = true;
            this.lblNetLabel.Location = new System.Drawing.Point(207, 153);
            this.lblNetLabel.Name = "lblNetLabel";
            this.lblNetLabel.Size = new System.Drawing.Size(104, 21);
            this.lblNetLabel.TabIndex = 2;
            this.lblNetLabel.Text = "فروش خالص:";
            // 
            // lblTotalLabel
            // 
            this.lblTotalLabel.AutoSize = true;
            this.lblTotalLabel.Location = new System.Drawing.Point(217, 83);
            this.lblTotalLabel.Name = "lblTotalLabel";
            this.lblTotalLabel.Size = new System.Drawing.Size(94, 21);
            this.lblTotalLabel.TabIndex = 2;
            this.lblTotalLabel.Text = "جمع فروش:";
            // 
            // lblDiscountLabel
            // 
            this.lblDiscountLabel.AutoSize = true;
            this.lblDiscountLabel.Location = new System.Drawing.Point(212, 120);
            this.lblDiscountLabel.Name = "lblDiscountLabel";
            this.lblDiscountLabel.Size = new System.Drawing.Size(99, 21);
            this.lblDiscountLabel.TabIndex = 2;
            this.lblDiscountLabel.Text = "جمع تخفیف:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox4);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer1.Size = new System.Drawing.Size(886, 545);
            this.splitContainer1.SplitterDistance = 294;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvDailySales);
            this.groupBox3.Location = new System.Drawing.Point(17, 40);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(862, 280);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "فروش روزانه ماه";
            // 
            // dgvDailySales
            // 
            this.dgvDailySales.AllowUserToAddRows = false;
            this.dgvDailySales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDailySales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDailySales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDailySales.Location = new System.Drawing.Point(3, 24);
            this.dgvDailySales.Name = "dgvDailySales";
            this.dgvDailySales.ReadOnly = true;
            this.dgvDailySales.RowHeadersWidth = 51;
            this.dgvDailySales.RowTemplate.Height = 24;
            this.dgvDailySales.Size = new System.Drawing.Size(856, 253);
            this.dgvDailySales.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvTopProducts);
            this.groupBox4.Location = new System.Drawing.Point(12, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(862, 280);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "فروش روزانه ماه";
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
            this.dgvTopProducts.Size = new System.Drawing.Size(856, 253);
            this.dgvTopProducts.TabIndex = 1;
            // 
            // MonthlyReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1481, 583);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MonthlyReportForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "گزارش فروش ماهانه";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MonthlyReportForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDailySales)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopProducts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.NumericUpDown numYear;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnThisMonth;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.Label lblCountLabel;
        private System.Windows.Forms.Label lblCountValue;
        private System.Windows.Forms.Label lblTotalLabel;
        private System.Windows.Forms.Label lblTotalValue;
        private System.Windows.Forms.Label lblDiscountLabel;
        private System.Windows.Forms.Label lblNetLabel;
        private System.Windows.Forms.Label lblDiscountValue;
        private System.Windows.Forms.Label lblNetValue;
        private System.Windows.Forms.Label lblBestDayLabel;
        private System.Windows.Forms.Label lblBestSellerLabel;
        private System.Windows.Forms.Label lblBestDayValue;
        private System.Windows.Forms.Label lblBestSellerValue;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvDailySales;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgvTopProducts;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}