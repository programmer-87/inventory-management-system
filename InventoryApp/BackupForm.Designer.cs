namespace InventoryApp
{
    partial class BackupForm
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
            this.lblBackupPath = new System.Windows.Forms.Label();
            this.txtBackupPath = new System.Windows.Forms.TextBox();
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnBrowseBackup = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblDbNameValue = new System.Windows.Forms.Label();
            this.lblDbNameLabel = new System.Windows.Forms.Label();
            this.lblDbPathValue = new System.Windows.Forms.Label();
            this.lblDbPathLabel = new System.Windows.Forms.Label();
            this.lblDbSizeValue = new System.Windows.Forms.Label();
            this.lblDbSizeLabel = new System.Windows.Forms.Label();
            this.btnRefreshInfo = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblRestorePath = new System.Windows.Forms.Label();
            this.txtRestorePath = new System.Windows.Forms.TextBox();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnBrowseRestore = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBrowseBackup);
            this.groupBox1.Controls.Add(this.btnBackup);
            this.groupBox1.Controls.Add(this.lblBackupPath);
            this.groupBox1.Controls.Add(this.txtBackupPath);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(222, 151);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "پشتیبان‌گیری";
            // 
            // lblBackupPath
            // 
            this.lblBackupPath.AutoSize = true;
            this.lblBackupPath.Location = new System.Drawing.Point(112, 36);
            this.lblBackupPath.Name = "lblBackupPath";
            this.lblBackupPath.Size = new System.Drawing.Size(101, 21);
            this.lblBackupPath.TabIndex = 1;
            this.lblBackupPath.Text = "مسیر ذخیره:";
            // 
            // txtBackupPath
            // 
            this.txtBackupPath.Location = new System.Drawing.Point(6, 36);
            this.txtBackupPath.Name = "txtBackupPath";
            this.txtBackupPath.Size = new System.Drawing.Size(100, 28);
            this.txtBackupPath.TabIndex = 2;
            // 
            // btnBackup
            // 
            this.btnBackup.Location = new System.Drawing.Point(112, 93);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(89, 35);
            this.btnBackup.TabIndex = 3;
            this.btnBackup.Text = "💾 ایجاد نسخه پشتیبان";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnBrowseBackup
            // 
            this.btnBrowseBackup.Location = new System.Drawing.Point(17, 93);
            this.btnBrowseBackup.Name = "btnBrowseBackup";
            this.btnBrowseBackup.Size = new System.Drawing.Size(89, 35);
            this.btnBrowseBackup.TabIndex = 3;
            this.btnBrowseBackup.Text = "📁 انتخاب";
            this.btnBrowseBackup.UseVisualStyleBackColor = true;
            this.btnBrowseBackup.Click += new System.EventHandler(this.btnBrowseBackup_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnRefreshInfo);
            this.groupBox2.Controls.Add(this.lblDbNameLabel);
            this.groupBox2.Controls.Add(this.lblDbSizeValue);
            this.groupBox2.Controls.Add(this.lblDbSizeLabel);
            this.groupBox2.Controls.Add(this.lblDbNameValue);
            this.groupBox2.Controls.Add(this.lblDbPathLabel);
            this.groupBox2.Controls.Add(this.lblDbPathValue);
            this.groupBox2.Location = new System.Drawing.Point(240, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(321, 151);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "اطلاعات دیتابیس";
            // 
            // lblDbNameValue
            // 
            this.lblDbNameValue.AutoSize = true;
            this.lblDbNameValue.Location = new System.Drawing.Point(109, 43);
            this.lblDbNameValue.Name = "lblDbNameValue";
            this.lblDbNameValue.Size = new System.Drawing.Size(102, 21);
            this.lblDbNameValue.TabIndex = 2;
            this.lblDbNameValue.Text = "InventoryDB";
            // 
            // lblDbNameLabel
            // 
            this.lblDbNameLabel.AutoSize = true;
            this.lblDbNameLabel.Location = new System.Drawing.Point(217, 39);
            this.lblDbNameLabel.Name = "lblDbNameLabel";
            this.lblDbNameLabel.Size = new System.Drawing.Size(98, 21);
            this.lblDbNameLabel.TabIndex = 2;
            this.lblDbNameLabel.Text = "نام دیتابیس:";
            // 
            // lblDbPathValue
            // 
            this.lblDbPathValue.AutoSize = true;
            this.lblDbPathValue.Location = new System.Drawing.Point(140, 83);
            this.lblDbPathValue.Name = "lblDbPathValue";
            this.lblDbPathValue.Size = new System.Drawing.Size(25, 21);
            this.lblDbPathValue.TabIndex = 2;
            this.lblDbPathValue.Text = "—";
            // 
            // lblDbPathLabel
            // 
            this.lblDbPathLabel.AutoSize = true;
            this.lblDbPathLabel.Location = new System.Drawing.Point(197, 83);
            this.lblDbPathLabel.Name = "lblDbPathLabel";
            this.lblDbPathLabel.Size = new System.Drawing.Size(118, 21);
            this.lblDbPathLabel.TabIndex = 2;
            this.lblDbPathLabel.Text = "مسیر دیتابیس:";
            // 
            // lblDbSizeValue
            // 
            this.lblDbSizeValue.AutoSize = true;
            this.lblDbSizeValue.Location = new System.Drawing.Point(140, 116);
            this.lblDbSizeValue.Name = "lblDbSizeValue";
            this.lblDbSizeValue.Size = new System.Drawing.Size(25, 21);
            this.lblDbSizeValue.TabIndex = 2;
            this.lblDbSizeValue.Text = "—";
            // 
            // lblDbSizeLabel
            // 
            this.lblDbSizeLabel.AutoSize = true;
            this.lblDbSizeLabel.Location = new System.Drawing.Point(202, 116);
            this.lblDbSizeLabel.Name = "lblDbSizeLabel";
            this.lblDbSizeLabel.Size = new System.Drawing.Size(113, 21);
            this.lblDbSizeLabel.TabIndex = 2;
            this.lblDbSizeLabel.Text = "حجم دیتابیس:";
            // 
            // btnRefreshInfo
            // 
            this.btnRefreshInfo.Location = new System.Drawing.Point(6, 70);
            this.btnRefreshInfo.Name = "btnRefreshInfo";
            this.btnRefreshInfo.Size = new System.Drawing.Size(104, 75);
            this.btnRefreshInfo.TabIndex = 3;
            this.btnRefreshInfo.Text = "🔄 بروزرسانی اطلاعات";
            this.btnRefreshInfo.UseVisualStyleBackColor = true;
            this.btnRefreshInfo.Click += new System.EventHandler(this.btnRefreshInfo_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnBrowseRestore);
            this.groupBox3.Controls.Add(this.lblRestorePath);
            this.groupBox3.Controls.Add(this.btnRestore);
            this.groupBox3.Controls.Add(this.txtRestorePath);
            this.groupBox3.Location = new System.Drawing.Point(12, 169);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(222, 127);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "بازیابی از فایل پشتیبان";
            // 
            // lblRestorePath
            // 
            this.lblRestorePath.AutoSize = true;
            this.lblRestorePath.Location = new System.Drawing.Point(109, 42);
            this.lblRestorePath.Name = "lblRestorePath";
            this.lblRestorePath.Size = new System.Drawing.Size(107, 21);
            this.lblRestorePath.TabIndex = 3;
            this.lblRestorePath.Text = "فایل پشتیبان:";
            // 
            // txtRestorePath
            // 
            this.txtRestorePath.Location = new System.Drawing.Point(3, 42);
            this.txtRestorePath.Name = "txtRestorePath";
            this.txtRestorePath.Size = new System.Drawing.Size(100, 28);
            this.txtRestorePath.TabIndex = 4;
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(129, 84);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(87, 37);
            this.btnRestore.TabIndex = 5;
            this.btnRestore.Text = "⚠️ بازیابی";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnBrowseRestore
            // 
            this.btnBrowseRestore.Location = new System.Drawing.Point(17, 84);
            this.btnBrowseRestore.Name = "btnBrowseRestore";
            this.btnBrowseRestore.Size = new System.Drawing.Size(89, 37);
            this.btnBrowseRestore.TabIndex = 5;
            this.btnBrowseRestore.Text = "📁 انتخاب";
            this.btnBrowseRestore.UseVisualStyleBackColor = true;
            this.btnBrowseRestore.Click += new System.EventHandler(this.btnBrowseRestore_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtLog);
            this.groupBox4.Location = new System.Drawing.Point(240, 169);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(321, 127);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "گزارش عملیات";
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(101, 42);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(106, 37);
            this.txtLog.TabIndex = 4;
            // 
            // BackupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 307);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "BackupForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "پشتیبان‌گیری و بازیابی";
            this.Load += new System.EventHandler(this.BackupForm_Load);
            this.Click += new System.EventHandler(this.BackupForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblBackupPath;
        private System.Windows.Forms.TextBox txtBackupPath;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Button btnBrowseBackup;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRefreshInfo;
        private System.Windows.Forms.Label lblDbNameLabel;
        private System.Windows.Forms.Label lblDbSizeValue;
        private System.Windows.Forms.Label lblDbSizeLabel;
        private System.Windows.Forms.Label lblDbNameValue;
        private System.Windows.Forms.Label lblDbPathLabel;
        private System.Windows.Forms.Label lblDbPathValue;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblRestorePath;
        private System.Windows.Forms.Button btnBrowseRestore;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.TextBox txtRestorePath;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtLog;
    }
}