using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using InventoryApp.Classes;

namespace InventoryApp
{
    public partial class SalesForm : Form
    {
        // کلاس کمکی برای نگه داشتن اقلام فاکتور
        private class SaleItem
        {
            public int ProductID { get; set; }
            public string ProductName { get; set; }
            public decimal UnitPrice { get; set; }
            public int Quantity { get; set; }
            public decimal TotalPrice => UnitPrice * Quantity;
        }

        private List<SaleItem> saleItems = new List<SaleItem>();

        public SalesForm()
        {
            InitializeComponent();
        }

        private void SalesForm_Load(object sender, EventArgs e)
        {
            LoadProducts();
            dgvSaleItems.Columns.Add("ProductID", "کد");
            dgvSaleItems.Columns.Add("ProductName", "نام کالا");
            dgvSaleItems.Columns.Add("UnitPrice", "قیمت واحد");
            dgvSaleItems.Columns.Add("Quantity", "تعداد");
            dgvSaleItems.Columns.Add("TotalPrice", "جمع");
            dgvSaleItems.Columns["ProductID"].Visible = false;
        }

        // ---------- بارگذاری محصولات ----------
        private void LoadProducts()
        {
            string query = "SELECT ProductID, ProductName, Price, Quantity FROM Products WHERE Quantity > 0 ORDER BY ProductName";
            DataTable dt = DatabaseConnection.ExecuteQuery(query);

            cmbProduct.DataSource = dt;
            cmbProduct.DisplayMember = "ProductName";
            cmbProduct.ValueMember = "ProductID";
            cmbProduct.SelectedIndex = -1;
        }

        // ---------- انتخاب محصول از ComboBox ----------
        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProduct.SelectedIndex == -1) return;

            DataRowView row = cmbProduct.SelectedItem as DataRowView;
            if (row == null) return;

            txtUnitPrice.Text = row["Price"].ToString();
            lblStockValue.Text = row["Quantity"].ToString();
            numQuantity.Maximum = Convert.ToInt32(row["Quantity"]);
            numQuantity.Value = 1;
        }

        // ---------- افزودن به فاکتور ----------
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (cmbProduct.SelectedIndex == -1)
            {
                MessageBox.Show("محصول را انتخاب کنید.", "خطا");
                return;
            }

            DataRowView row = cmbProduct.SelectedItem as DataRowView;
            int productID = Convert.ToInt32(row["ProductID"]);
            string productName = row["ProductName"].ToString();
            decimal price = Convert.ToDecimal(row["Price"]);
            int stock = Convert.ToInt32(row["Quantity"]);
            int qty = (int)numQuantity.Value;

            // چک موجودی
            int alreadyAdded = 0;
            foreach (var item in saleItems)
                if (item.ProductID == productID)
                    alreadyAdded += item.Quantity;

            if (alreadyAdded + qty > stock)
            {
                MessageBox.Show(
                    $"❌ موجودی کافی نیست.\nموجودی: {stock}\nدر فاکتور: {alreadyAdded}",
                    "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // اگه محصول قبلاً اضافه شده، تعداد رو زیاد کن
            SaleItem existing = saleItems.Find(i => i.ProductID == productID);
            if (existing != null)
            {
                existing.Quantity += qty;
            }
            else
            {
                saleItems.Add(new SaleItem
                {
                    ProductID = productID,
                    ProductName = productName,
                    UnitPrice = price,
                    Quantity = qty
                });
            }

            RefreshGrid();
        }

        // ---------- نمایش اقلام توی جدول ----------
        private void RefreshGrid()
        {
            dgvSaleItems.Rows.Clear();
            foreach (var item in saleItems)
            {
                dgvSaleItems.Rows.Add(
                    item.ProductID,
                    item.ProductName,
                    item.UnitPrice.ToString("N0"),
                    item.Quantity,
                    item.TotalPrice.ToString("N0"));
            }
            UpdateTotals();
        }

        // ---------- محاسبه جمع کل ----------
        private void UpdateTotals()
        {
            decimal total = 0;
            foreach (var item in saleItems)
                total += item.TotalPrice;

            decimal discount = numDiscount.Value;
            decimal final = total - discount;
            if (final < 0) final = 0;

            lblTotalValue.Text = total.ToString("N0") + " ریال";
            lblFinalValue.Text = final.ToString("N0") + " ریال";
        }

        private void numDiscount_ValueChanged(object sender, EventArgs e)
        {
            UpdateTotals();
        }

        // ---------- حذف ردیف ----------
        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (dgvSaleItems.SelectedRows.Count == 0)
            {
                MessageBox.Show("ابتدا یک ردیف انتخاب کنید.", "هشدار");
                return;
            }

            int index = dgvSaleItems.SelectedRows[0].Index;
            if (index >= 0 && index < saleItems.Count)
            {
                saleItems.RemoveAt(index);
                RefreshGrid();
            }
        }

        // ---------- فاکتور جدید ----------
        private void btnNewSale_Click(object sender, EventArgs e)
        {
            if (saleItems.Count > 0)
            {
                if (MessageBox.Show("فاکتور فعلی پاک شود؟", "تأیید",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
            }

            saleItems.Clear();
            dgvSaleItems.Rows.Clear();
            txtCustomerName.Clear();
            txtCustomerPhone.Clear();
            cmbProduct.SelectedIndex = -1;
            txtUnitPrice.Clear();
            lblStockValue.Text = "";
            numQuantity.Value = 1;
            numDiscount.Value = 0;
            UpdateTotals();
            LoadProducts();
        }

        // ---------- ثبت فاکتور ----------
        private void btnSaveSale_Click(object sender, EventArgs e)
        {
            if (saleItems.Count == 0)
            {
                MessageBox.Show("فاکتور خالی است. ابتدا کالا اضافه کنید.", "خطا");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                MessageBox.Show("نام مشتری را وارد کنید.", "خطا");
                txtCustomerName.Focus();
                return;
            }

            try
            {
                // ۱) ثبت مشتری
                int customerID = GetOrCreateCustomer(
                    txtCustomerName.Text.Trim(),
                    txtCustomerPhone.Text.Trim());

                // ۲) محاسبه جمع
                decimal total = 0;
                foreach (var item in saleItems)
                    total += item.TotalPrice;
                decimal discount = numDiscount.Value;
                decimal final = total - discount;
                if (final < 0) final = 0;

                // ۳) درج فاکتور اصلی
                string saleQuery = @"
            INSERT INTO Sales (CustomerID, UserID, TotalAmount, Discount, FinalAmount)
            VALUES (@cid, @uid, @total, @disc, @final);
            SELECT SCOPE_IDENTITY();";

                SqlParameter[] saleParams =
                {
            new SqlParameter("@cid", customerID),
            new SqlParameter("@uid", Session.UserID),
            new SqlParameter("@total", total),
            new SqlParameter("@disc", discount),
            new SqlParameter("@final", final)
        };

                object result = DatabaseConnection.ExecuteScalar(saleQuery, saleParams);
                int saleID = Convert.ToInt32(result);

                // ۴) درج اقلام + کاهش موجودی + ثبت حرکت
                foreach (var item in saleItems)
                {
                    // درج قلم فاکتور
                    string detailQuery = @"
                INSERT INTO SaleDetails (SaleID, ProductID, Quantity, UnitPrice, TotalPrice)
                VALUES (@sid, @pid, @qty, @price, @total)";
                    SqlParameter[] detailParams =
                    {
                new SqlParameter("@sid", saleID),
                new SqlParameter("@pid", item.ProductID),
                new SqlParameter("@qty", item.Quantity),
                new SqlParameter("@price", item.UnitPrice),
                new SqlParameter("@total", item.TotalPrice)
            };
                    DatabaseConnection.ExecuteNonQuery(detailQuery, detailParams);

                    // کاهش موجودی
                    string stockQuery = "UPDATE Products SET Quantity = Quantity - @qty WHERE ProductID = @pid";
                    SqlParameter[] stockParams =
                    {
                new SqlParameter("@qty", item.Quantity),
                new SqlParameter("@pid", item.ProductID)
            };
                    DatabaseConnection.ExecuteNonQuery(stockQuery, stockParams);

                    // ثبت حرکت انبار
                    string moveQuery = @"
                INSERT INTO StockMovements (ProductID, MovementType, Quantity, Description)
                VALUES (@pid, 'OUT', @qty, @desc)";
                    SqlParameter[] moveParams =
                    {
                new SqlParameter("@pid", item.ProductID),
                new SqlParameter("@qty", item.Quantity),
                new SqlParameter("@desc", $"فروش - فاکتور #{saleID}")
            };
                    DatabaseConnection.ExecuteNonQuery(moveQuery, moveParams);
                }

                MessageBox.Show(
                    $"✅ فاکتور شماره {saleID} با موفقیت ثبت شد.\n" +
                    $"مبلغ قابل پرداخت: {final:N0} ریال",
                    "موفق", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnNewSale_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا در ثبت فاکتور:\n" + ex.Message,
                    "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---------- گرفتن یا ساختن مشتری ----------
        private int GetOrCreateCustomer(string name, string phone)
        {
            string findQuery = "SELECT CustomerID FROM Customers WHERE FullName = @n AND Phone = @p";
            SqlParameter[] findParams =
            {
                new SqlParameter("@n", name),
                new SqlParameter("@p", string.IsNullOrWhiteSpace(phone) ? (object)DBNull.Value : phone)
            };

            object existing = DatabaseConnection.ExecuteScalar(findQuery, findParams);
            if (existing != null && existing != DBNull.Value)
                return Convert.ToInt32(existing);

            string insertQuery = @"
                INSERT INTO Customers (FullName, Phone) VALUES (@n, @p);
                SELECT SCOPE_IDENTITY();";
            SqlParameter[] insertParams =
            {
                new SqlParameter("@n", name),
                new SqlParameter("@p", string.IsNullOrWhiteSpace(phone) ? (object)DBNull.Value : phone)
            };
            return Convert.ToInt32(DatabaseConnection.ExecuteScalar(insertQuery, insertParams));
        }
        private void SalesForm_KeyDown(object sender, KeyEventArgs e)
        {
            // F2 → فوکوس روی محصول
            if (e.KeyCode == Keys.F2)
            {
                cmbProduct.Focus();
                e.Handled = true;
            }
            // F4 → فوکوس روی نام مشتری
            else if (e.KeyCode == Keys.F4)
            {
                txtCustomerName.Focus();
                e.Handled = true;
            }
            // Ctrl+S → ثبت فاکتور
            else if (e.Control && e.KeyCode == Keys.S)
            {
                btnSaveSale.PerformClick();
                e.Handled = true;
            }
            // Ctrl+N → فاکتور جدید
            else if (e.Control && e.KeyCode == Keys.N)
            {
                btnNewSale.PerformClick();
                e.Handled = true;
            }
        }

        private void txtCustomerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtCustomerPhone.Focus();
            }
        }

        private void txtCustomerPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                cmbProduct.Focus();
            }
        }

        private void numQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnAddItem.PerformClick();  // Enter = افزودن محصول به فاکتور
            }
        }

        private void numDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnSaveSale.Focus();  // Enter = رفتن به دکمه ثبت
            }
        }
    }
}