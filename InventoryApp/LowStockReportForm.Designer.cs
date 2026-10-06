namespace InventoryApp
{
    partial class LowStockReportForm
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
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblCountLabel = new System.Windows.Forms.Label();
            this.lblCountValue = new System.Windows.Forms.Label();
            this.lblZeroLabel = new System.Windows.Forms.Label();
            this.lblZeroValue = new System.Windows.Forms.Label();
            this.lblStockValueLabel = new System.Windows.Forms.Label();
            this.lblNeedValueLabel = new System.Windows.Forms.Label();
            this.lblStockValueValue = new System.Windows.Forms.Label();
            this.lblNeedValueValue = new System.Windows.Forms.Label();
            this.dgvLowStock = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLowStock)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPrint);
            this.groupBox1.Controls.Add(this.lblInfo);
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(511, 131);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "فیلتر";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(16, 34);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(489, 21);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "نمایش محصولاتی که موجودی آن‌ها کمتر یا مساوی حد هشدار است";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(407, 73);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(94, 52);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "🔄 بروزرسانی";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(313, 83);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(88, 32);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "🖨️ چاپ";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblCountLabel);
            this.groupBox2.Controls.Add(this.lblNeedValueValue);
            this.groupBox2.Controls.Add(this.lblZeroLabel);
            this.groupBox2.Controls.Add(this.lblStockValueValue);
            this.groupBox2.Controls.Add(this.lblZeroValue);
            this.groupBox2.Controls.Add(this.lblNeedValueLabel);
            this.groupBox2.Controls.Add(this.lblCountValue);
            this.groupBox2.Controls.Add(this.lblStockValueLabel);
            this.groupBox2.Location = new System.Drawing.Point(7, 601);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(862, 131);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "خلاصه";
            // 
            // lblCountLabel
            // 
            this.lblCountLabel.AutoSize = true;
            this.lblCountLabel.Location = new System.Drawing.Point(666, 35);
            this.lblCountLabel.Name = "lblCountLabel";
            this.lblCountLabel.Size = new System.Drawing.Size(190, 21);
            this.lblCountLabel.TabIndex = 2;
            this.lblCountLabel.Text = "تعداد محصولات کم‌موجود:";
            // 
            // lblCountValue
            // 
            this.lblCountValue.AutoSize = true;
            this.lblCountValue.Location = new System.Drawing.Point(586, 35);
            this.lblCountValue.Name = "lblCountValue";
            this.lblCountValue.Size = new System.Drawing.Size(19, 21);
            this.lblCountValue.TabIndex = 2;
            this.lblCountValue.Text = "0";
            // 
            // lblZeroLabel
            // 
            this.lblZeroLabel.AutoSize = true;
            this.lblZeroLabel.Location = new System.Drawing.Point(661, 74);
            this.lblZeroLabel.Name = "lblZeroLabel";
            this.lblZeroLabel.Size = new System.Drawing.Size(195, 21);
            this.lblZeroLabel.TabIndex = 2;
            this.lblZeroLabel.Text = "محصولات با موجودی صفر:";
            // 
            // lblZeroValue
            // 
            this.lblZeroValue.AutoSize = true;
            this.lblZeroValue.Location = new System.Drawing.Point(586, 74);
            this.lblZeroValue.Name = "lblZeroValue";
            this.lblZeroValue.Size = new System.Drawing.Size(19, 21);
            this.lblZeroValue.TabIndex = 2;
            this.lblZeroValue.Text = "0";
            // 
            // lblStockValueLabel
            // 
            this.lblStockValueLabel.AutoSize = true;
            this.lblStockValueLabel.Location = new System.Drawing.Point(362, 35);
            this.lblStockValueLabel.Name = "lblStockValueLabel";
            this.lblStockValueLabel.Size = new System.Drawing.Size(160, 21);
            this.lblStockValueLabel.TabIndex = 2;
            this.lblStockValueLabel.Text = "ارزش موجودی فعلی:";
            // 
            // lblNeedValueLabel
            // 
            this.lblNeedValueLabel.AutoSize = true;
            this.lblNeedValueLabel.Location = new System.Drawing.Point(381, 74);
            this.lblNeedValueLabel.Name = "lblNeedValueLabel";
            this.lblNeedValueLabel.Size = new System.Drawing.Size(141, 21);
            this.lblNeedValueLabel.TabIndex = 2;
            this.lblNeedValueLabel.Text = "هزینه تأمین مجدد:";
            // 
            // lblStockValueValue
            // 
            this.lblStockValueValue.AutoSize = true;
            this.lblStockValueValue.Location = new System.Drawing.Point(224, 35);
            this.lblStockValueValue.Name = "lblStockValueValue";
            this.lblStockValueValue.Size = new System.Drawing.Size(51, 21);
            this.lblStockValueValue.TabIndex = 2;
            this.lblStockValueValue.Text = "0 ریال";
            // 
            // lblNeedValueValue
            // 
            this.lblNeedValueValue.AutoSize = true;
            this.lblNeedValueValue.Location = new System.Drawing.Point(224, 74);
            this.lblNeedValueValue.Name = "lblNeedValueValue";
            this.lblNeedValueValue.Size = new System.Drawing.Size(51, 21);
            this.lblNeedValueValue.TabIndex = 2;
            this.lblNeedValueValue.Text = "0 ریال";
            // 
            // dgvLowStock
            // 
            this.dgvLowStock.AllowUserToAddRows = false;
            this.dgvLowStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLowStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLowStock.Location = new System.Drawing.Point(12, 149);
            this.dgvLowStock.Name = "dgvLowStock";
            this.dgvLowStock.ReadOnly = true;
            this.dgvLowStock.RowHeadersWidth = 51;
            this.dgvLowStock.RowTemplate.Height = 24;
            this.dgvLowStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLowStock.Size = new System.Drawing.Size(857, 446);
            this.dgvLowStock.TabIndex = 3;
            // 
            // LowStockReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 744);
            this.Controls.Add(this.dgvLowStock);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "LowStockReportForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "گزارش محصولات رو به اتمام";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LowStockReportForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLowStock)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblCountLabel;
        private System.Windows.Forms.Label lblCountValue;
        private System.Windows.Forms.Label lblZeroLabel;
        private System.Windows.Forms.Label lblZeroValue;
        private System.Windows.Forms.Label lblStockValueLabel;
        private System.Windows.Forms.Label lblNeedValueLabel;
        private System.Windows.Forms.Label lblStockValueValue;
        private System.Windows.Forms.Label lblNeedValueValue;
        private System.Windows.Forms.DataGridView dgvLowStock;
    }
}