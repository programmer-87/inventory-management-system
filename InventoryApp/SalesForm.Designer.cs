namespace InventoryApp
{
    partial class SalesForm
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
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblCustomerPhone = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.txtCustomerPhone = new System.Windows.Forms.TextBox();
            this.btnFindCustomer = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.cmbProduct = new System.Windows.Forms.ComboBox();
            this.lblStockValue = new System.Windows.Forms.Label();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.lblStock = new System.Windows.Forms.Label();
            this.lblQty = new System.Windows.Forms.Label();
            this.lblUnitPrice = new System.Windows.Forms.Label();
            this.lblProduct = new System.Windows.Forms.Label();
            this.dgvSaleItems = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnNewSale = new System.Windows.Forms.Button();
            this.btnSaveSale = new System.Windows.Forms.Button();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.numDiscount = new System.Windows.Forms.NumericUpDown();
            this.lblFinalValue = new System.Windows.Forms.Label();
            this.lblFinal = new System.Windows.Forms.Label();
            this.lblTotalValue = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaleItems)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDiscount)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(12, 15);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(96, 21);
            this.lblCustomerName.TabIndex = 0;
            this.lblCustomerName.Text = "نام مشتری:";
            // 
            // lblCustomerPhone
            // 
            this.lblCustomerPhone.AutoSize = true;
            this.lblCustomerPhone.Location = new System.Drawing.Point(54, 36);
            this.lblCustomerPhone.Name = "lblCustomerPhone";
            this.lblCustomerPhone.Size = new System.Drawing.Size(49, 21);
            this.lblCustomerPhone.TabIndex = 0;
            this.lblCustomerPhone.Text = "تلفن:";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(124, 12);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(100, 28);
            this.txtCustomerName.TabIndex = 0;
            this.txtCustomerName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomerName_KeyDown);
            // 
            // txtCustomerPhone
            // 
            this.txtCustomerPhone.Location = new System.Drawing.Point(124, 46);
            this.txtCustomerPhone.Name = "txtCustomerPhone";
            this.txtCustomerPhone.Size = new System.Drawing.Size(100, 28);
            this.txtCustomerPhone.TabIndex = 1;
            this.txtCustomerPhone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomerPhone_KeyDown);
            // 
            // btnFindCustomer
            // 
            this.btnFindCustomer.Location = new System.Drawing.Point(124, 88);
            this.btnFindCustomer.Name = "btnFindCustomer";
            this.btnFindCustomer.Size = new System.Drawing.Size(100, 36);
            this.btnFindCustomer.TabIndex = 2;
            this.btnFindCustomer.Text = "🔍 جستجو";
            this.btnFindCustomer.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddItem);
            this.groupBox1.Controls.Add(this.numQuantity);
            this.groupBox1.Controls.Add(this.cmbProduct);
            this.groupBox1.Controls.Add(this.lblStockValue);
            this.groupBox1.Controls.Add(this.txtUnitPrice);
            this.groupBox1.Controls.Add(this.lblStock);
            this.groupBox1.Controls.Add(this.lblQty);
            this.groupBox1.Controls.Add(this.lblUnitPrice);
            this.groupBox1.Controls.Add(this.lblProduct);
            this.groupBox1.Location = new System.Drawing.Point(16, 130);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(294, 511);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "افزودن کالا به فاکتور";
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(56, 258);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(130, 56);
            this.btnAddItem.TabIndex = 4;
            this.btnAddItem.Text = "➕ افزودن به فاکتور";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // numQuantity
            // 
            this.numQuantity.Location = new System.Drawing.Point(56, 120);
            this.numQuantity.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(120, 28);
            this.numQuantity.TabIndex = 3;
            this.numQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQuantity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numQuantity_KeyDown);
            // 
            // cmbProduct
            // 
            this.cmbProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProduct.FormattingEnabled = true;
            this.cmbProduct.Location = new System.Drawing.Point(56, 39);
            this.cmbProduct.Name = "cmbProduct";
            this.cmbProduct.Size = new System.Drawing.Size(121, 29);
            this.cmbProduct.TabIndex = 2;
            this.cmbProduct.SelectedIndexChanged += new System.EventHandler(this.cmbProduct_SelectedIndexChanged);
            // 
            // lblStockValue
            // 
            this.lblStockValue.AutoSize = true;
            this.lblStockValue.Location = new System.Drawing.Point(115, 157);
            this.lblStockValue.Name = "lblStockValue";
            this.lblStockValue.Size = new System.Drawing.Size(54, 21);
            this.lblStockValue.TabIndex = 4;
            this.lblStockValue.Text = "label5";
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.Location = new System.Drawing.Point(76, 82);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.ReadOnly = true;
            this.txtUnitPrice.Size = new System.Drawing.Size(100, 28);
            this.txtUnitPrice.TabIndex = 1;
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Location = new System.Drawing.Point(217, 157);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(75, 21);
            this.lblStock.TabIndex = 3;
            this.lblStock.Text = "موجودی:";
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Location = new System.Drawing.Point(246, 120);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(50, 21);
            this.lblQty.TabIndex = 2;
            this.lblQty.Text = "تعداد:";
            // 
            // lblUnitPrice
            // 
            this.lblUnitPrice.AutoSize = true;
            this.lblUnitPrice.Location = new System.Drawing.Point(205, 84);
            this.lblUnitPrice.Name = "lblUnitPrice";
            this.lblUnitPrice.Size = new System.Drawing.Size(91, 21);
            this.lblUnitPrice.TabIndex = 1;
            this.lblUnitPrice.Text = "قیمت واحد:";
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Location = new System.Drawing.Point(217, 42);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(69, 21);
            this.lblProduct.TabIndex = 0;
            this.lblProduct.Text = "محصول:";
            // 
            // dgvSaleItems
            // 
            this.dgvSaleItems.AllowUserToAddRows = false;
            this.dgvSaleItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSaleItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSaleItems.Location = new System.Drawing.Point(316, 12);
            this.dgvSaleItems.MultiSelect = false;
            this.dgvSaleItems.Name = "dgvSaleItems";
            this.dgvSaleItems.ReadOnly = true;
            this.dgvSaleItems.RowHeadersWidth = 51;
            this.dgvSaleItems.RowTemplate.Height = 24;
            this.dgvSaleItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSaleItems.Size = new System.Drawing.Size(406, 629);
            this.dgvSaleItems.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnNewSale);
            this.groupBox2.Controls.Add(this.btnSaveSale);
            this.groupBox2.Controls.Add(this.btnRemoveItem);
            this.groupBox2.Controls.Add(this.numDiscount);
            this.groupBox2.Controls.Add(this.lblFinalValue);
            this.groupBox2.Controls.Add(this.lblFinal);
            this.groupBox2.Controls.Add(this.lblTotalValue);
            this.groupBox2.Controls.Add(this.lblDiscount);
            this.groupBox2.Controls.Add(this.lblTotal);
            this.groupBox2.Location = new System.Drawing.Point(728, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(242, 629);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "جمع فاکتور";
            // 
            // btnNewSale
            // 
            this.btnNewSale.Location = new System.Drawing.Point(109, 316);
            this.btnNewSale.Name = "btnNewSale";
            this.btnNewSale.Size = new System.Drawing.Size(96, 54);
            this.btnNewSale.TabIndex = 2;
            this.btnNewSale.Text = "🔄 فاکتور جدید";
            this.btnNewSale.UseVisualStyleBackColor = true;
            // 
            // btnSaveSale
            // 
            this.btnSaveSale.Location = new System.Drawing.Point(7, 316);
            this.btnSaveSale.Name = "btnSaveSale";
            this.btnSaveSale.Size = new System.Drawing.Size(96, 54);
            this.btnSaveSale.TabIndex = 7;
            this.btnSaveSale.Text = "💾 ثبت فاکتور";
            this.btnSaveSale.UseVisualStyleBackColor = true;
            this.btnSaveSale.Click += new System.EventHandler(this.btnSaveSale_Click);
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.Location = new System.Drawing.Point(57, 376);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(96, 54);
            this.btnRemoveItem.TabIndex = 2;
            this.btnRemoveItem.Text = "🗑️ حذف ردیف";
            this.btnRemoveItem.UseVisualStyleBackColor = true;
            this.btnRemoveItem.Click += new System.EventHandler(this.btnRemoveItem_Click);
            // 
            // numDiscount
            // 
            this.numDiscount.Location = new System.Drawing.Point(45, 262);
            this.numDiscount.Name = "numDiscount";
            this.numDiscount.Size = new System.Drawing.Size(120, 28);
            this.numDiscount.TabIndex = 6;
            this.numDiscount.ValueChanged += new System.EventHandler(this.numDiscount_ValueChanged);
            this.numDiscount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numDiscount_KeyDown);
            // 
            // lblFinalValue
            // 
            this.lblFinalValue.AutoSize = true;
            this.lblFinalValue.Location = new System.Drawing.Point(57, 165);
            this.lblFinalValue.Name = "lblFinalValue";
            this.lblFinalValue.Size = new System.Drawing.Size(19, 21);
            this.lblFinalValue.TabIndex = 0;
            this.lblFinalValue.Text = "0";
            // 
            // lblFinal
            // 
            this.lblFinal.AutoSize = true;
            this.lblFinal.Location = new System.Drawing.Point(128, 165);
            this.lblFinal.Name = "lblFinal";
            this.lblFinal.Size = new System.Drawing.Size(101, 21);
            this.lblFinal.TabIndex = 0;
            this.lblFinal.Text = "قابل پرداخت:";
            // 
            // lblTotalValue
            // 
            this.lblTotalValue.AutoSize = true;
            this.lblTotalValue.Location = new System.Drawing.Point(88, 84);
            this.lblTotalValue.Name = "lblTotalValue";
            this.lblTotalValue.Size = new System.Drawing.Size(19, 21);
            this.lblTotalValue.TabIndex = 0;
            this.lblTotalValue.Text = "0";
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Location = new System.Drawing.Point(166, 118);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(63, 21);
            this.lblDiscount.TabIndex = 0;
            this.lblDiscount.Text = "تخفیف:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(157, 41);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(72, 21);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "جمع کل:";
            // 
            // SalesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 653);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgvSaleItems);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnFindCustomer);
            this.Controls.Add(this.txtCustomerPhone);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.lblCustomerPhone);
            this.Controls.Add(this.lblCustomerName);
            this.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SalesForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فروش جدید";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SalesForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SalesForm_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaleItems)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDiscount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblCustomerPhone;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.TextBox txtCustomerPhone;
        private System.Windows.Forms.Button btnFindCustomer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.Label lblUnitPrice;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label lblStockValue;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.ComboBox cmbProduct;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.DataGridView dgvSaleItems;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnNewSale;
        private System.Windows.Forms.Button btnSaveSale;
        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.NumericUpDown numDiscount;
        private System.Windows.Forms.Label lblFinalValue;
        private System.Windows.Forms.Label lblFinal;
        private System.Windows.Forms.Label lblTotalValue;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtUnitPrice;
    }
}