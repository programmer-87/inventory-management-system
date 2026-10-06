namespace InventoryApp
{
    partial class StockForm
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
            this.btnClearFilter = new System.Windows.Forms.Button();
            this.lblProductFilter = new System.Windows.Forms.Label();
            this.btnApplyFilter = new System.Windows.Forms.Button();
            this.lblTypeFilter = new System.Windows.Forms.Label();
            this.cmbTypeFilter = new System.Windows.Forms.ComboBox();
            this.cmbProductFilter = new System.Windows.Forms.ComboBox();
            this.dgvMovements = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblOutValue = new System.Windows.Forms.Label();
            this.lblOutLabel = new System.Windows.Forms.Label();
            this.lblCountLabel = new System.Windows.Forms.Label();
            this.lblCountValue = new System.Windows.Forms.Label();
            this.lblInValue = new System.Windows.Forms.Label();
            this.lblInLabel = new System.Windows.Forms.Label();
            this.btnNewEntry = new System.Windows.Forms.Button();
            this.btnNewExit = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovements)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClearFilter);
            this.groupBox1.Controls.Add(this.lblProductFilter);
            this.groupBox1.Controls.Add(this.btnApplyFilter);
            this.groupBox1.Controls.Add(this.lblTypeFilter);
            this.groupBox1.Controls.Add(this.cmbTypeFilter);
            this.groupBox1.Controls.Add(this.cmbProductFilter);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 223);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "فیلترها";
            // 
            // btnClearFilter
            // 
            this.btnClearFilter.Location = new System.Drawing.Point(113, 159);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(68, 52);
            this.btnClearFilter.TabIndex = 3;
            this.btnClearFilter.Text = "🔄 پاک کردن";
            this.btnClearFilter.UseVisualStyleBackColor = true;
            this.btnClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);
            // 
            // lblProductFilter
            // 
            this.lblProductFilter.AutoSize = true;
            this.lblProductFilter.Location = new System.Drawing.Point(125, 48);
            this.lblProductFilter.Name = "lblProductFilter";
            this.lblProductFilter.Size = new System.Drawing.Size(69, 21);
            this.lblProductFilter.TabIndex = 1;
            this.lblProductFilter.Text = "محصول:";
            // 
            // btnApplyFilter
            // 
            this.btnApplyFilter.Location = new System.Drawing.Point(26, 157);
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.Size = new System.Drawing.Size(81, 54);
            this.btnApplyFilter.TabIndex = 3;
            this.btnApplyFilter.Text = "🔍 اعمال فیلتر";
            this.btnApplyFilter.UseVisualStyleBackColor = true;
            this.btnApplyFilter.Click += new System.EventHandler(this.btnApplyFilter_Click);
            // 
            // lblTypeFilter
            // 
            this.lblTypeFilter.AutoSize = true;
            this.lblTypeFilter.Location = new System.Drawing.Point(155, 99);
            this.lblTypeFilter.Name = "lblTypeFilter";
            this.lblTypeFilter.Size = new System.Drawing.Size(39, 21);
            this.lblTypeFilter.TabIndex = 1;
            this.lblTypeFilter.Text = "نوع:";
            // 
            // cmbTypeFilter
            // 
            this.cmbTypeFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypeFilter.FormattingEnabled = true;
            this.cmbTypeFilter.Location = new System.Drawing.Point(6, 96);
            this.cmbTypeFilter.Name = "cmbTypeFilter";
            this.cmbTypeFilter.Size = new System.Drawing.Size(121, 29);
            this.cmbTypeFilter.TabIndex = 2;
            // 
            // cmbProductFilter
            // 
            this.cmbProductFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProductFilter.FormattingEnabled = true;
            this.cmbProductFilter.Location = new System.Drawing.Point(6, 45);
            this.cmbProductFilter.Name = "cmbProductFilter";
            this.cmbProductFilter.Size = new System.Drawing.Size(121, 29);
            this.cmbProductFilter.TabIndex = 2;
            // 
            // dgvMovements
            // 
            this.dgvMovements.AllowUserToAddRows = false;
            this.dgvMovements.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMovements.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMovements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMovements.Location = new System.Drawing.Point(230, 12);
            this.dgvMovements.Name = "dgvMovements";
            this.dgvMovements.ReadOnly = true;
            this.dgvMovements.RowHeadersWidth = 51;
            this.dgvMovements.RowTemplate.Height = 24;
            this.dgvMovements.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMovements.Size = new System.Drawing.Size(599, 501);
            this.dgvMovements.TabIndex = 1;
            this.dgvMovements.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvMovements_KeyDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblOutValue);
            this.groupBox2.Controls.Add(this.lblOutLabel);
            this.groupBox2.Controls.Add(this.lblCountLabel);
            this.groupBox2.Controls.Add(this.lblCountValue);
            this.groupBox2.Controls.Add(this.lblInValue);
            this.groupBox2.Controls.Add(this.lblInLabel);
            this.groupBox2.Location = new System.Drawing.Point(6, 241);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 191);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "خلاصه";
            // 
            // lblOutValue
            // 
            this.lblOutValue.AutoSize = true;
            this.lblOutValue.Location = new System.Drawing.Point(30, 130);
            this.lblOutValue.Name = "lblOutValue";
            this.lblOutValue.Size = new System.Drawing.Size(19, 21);
            this.lblOutValue.TabIndex = 3;
            this.lblOutValue.Text = "0";
            // 
            // lblOutLabel
            // 
            this.lblOutLabel.AutoSize = true;
            this.lblOutLabel.Location = new System.Drawing.Point(107, 130);
            this.lblOutLabel.Name = "lblOutLabel";
            this.lblOutLabel.Size = new System.Drawing.Size(87, 21);
            this.lblOutLabel.TabIndex = 3;
            this.lblOutLabel.Text = "جمع خروج:";
            // 
            // lblCountLabel
            // 
            this.lblCountLabel.AutoSize = true;
            this.lblCountLabel.Location = new System.Drawing.Point(94, 40);
            this.lblCountLabel.Name = "lblCountLabel";
            this.lblCountLabel.Size = new System.Drawing.Size(100, 21);
            this.lblCountLabel.TabIndex = 3;
            this.lblCountLabel.Text = "تعداد حرکات:";
            // 
            // lblCountValue
            // 
            this.lblCountValue.AutoSize = true;
            this.lblCountValue.Location = new System.Drawing.Point(30, 40);
            this.lblCountValue.Name = "lblCountValue";
            this.lblCountValue.Size = new System.Drawing.Size(19, 21);
            this.lblCountValue.TabIndex = 3;
            this.lblCountValue.Text = "0";
            // 
            // lblInValue
            // 
            this.lblInValue.AutoSize = true;
            this.lblInValue.Location = new System.Drawing.Point(30, 81);
            this.lblInValue.Name = "lblInValue";
            this.lblInValue.Size = new System.Drawing.Size(19, 21);
            this.lblInValue.TabIndex = 3;
            this.lblInValue.Text = "0";
            // 
            // lblInLabel
            // 
            this.lblInLabel.AutoSize = true;
            this.lblInLabel.Location = new System.Drawing.Point(114, 81);
            this.lblInLabel.Name = "lblInLabel";
            this.lblInLabel.Size = new System.Drawing.Size(80, 21);
            this.lblInLabel.TabIndex = 3;
            this.lblInLabel.Text = "جمع ورود:";
            // 
            // btnNewEntry
            // 
            this.btnNewEntry.Location = new System.Drawing.Point(9, 438);
            this.btnNewEntry.Name = "btnNewEntry";
            this.btnNewEntry.Size = new System.Drawing.Size(103, 32);
            this.btnNewEntry.TabIndex = 3;
            this.btnNewEntry.Text = "➕ ثبت ورود";
            this.btnNewEntry.UseVisualStyleBackColor = true;
            this.btnNewEntry.Click += new System.EventHandler(this.btnNewEntry_Click);
            // 
            // btnNewExit
            // 
            this.btnNewExit.Location = new System.Drawing.Point(118, 438);
            this.btnNewExit.Name = "btnNewExit";
            this.btnNewExit.Size = new System.Drawing.Size(106, 35);
            this.btnNewExit.TabIndex = 3;
            this.btnNewExit.Text = "➖ ثبت خروج";
            this.btnNewExit.UseVisualStyleBackColor = true;
            this.btnNewExit.Click += new System.EventHandler(this.btnNewExit_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(6, 479);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(114, 34);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "🔄 بروزرسانی";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // StockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 525);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnNewExit);
            this.Controls.Add(this.btnNewEntry);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgvMovements);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "StockForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "مدیریت انبار";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.StockForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StockForm_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovements)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblProductFilter;
        private System.Windows.Forms.Label lblTypeFilter;
        private System.Windows.Forms.ComboBox cmbProductFilter;
        private System.Windows.Forms.Button btnClearFilter;
        private System.Windows.Forms.Button btnApplyFilter;
        private System.Windows.Forms.ComboBox cmbTypeFilter;
        private System.Windows.Forms.DataGridView dgvMovements;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblOutValue;
        private System.Windows.Forms.Label lblOutLabel;
        private System.Windows.Forms.Label lblCountLabel;
        private System.Windows.Forms.Label lblCountValue;
        private System.Windows.Forms.Label lblInValue;
        private System.Windows.Forms.Label lblInLabel;
        private System.Windows.Forms.Button btnNewEntry;
        private System.Windows.Forms.Button btnNewExit;
        private System.Windows.Forms.Button btnRefresh;
    }
}