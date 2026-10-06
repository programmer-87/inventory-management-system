using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using InventoryApp.Classes;

namespace InventoryApp
{
    public partial class StockForm : Form
    {
        public StockForm()
        {
            InitializeComponent();
        }

        private void StockForm_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadTypeFilter();
            LoadMovements();
        }

        // ---------- پر کردن Dropdown محصولات ----------
        private void LoadProducts()
        {
            string query = "SELECT ProductID, ProductName FROM Products ORDER BY ProductName";
            DataTable dt = DatabaseConnection.ExecuteQuery(query);

            // اضافه کردن گزینه "همه"
            DataRow allRow = dt.NewRow();
            allRow["ProductID"] = -1;
            allRow["ProductName"] = "--- همه محصولات ---";
            dt.Rows.InsertAt(allRow, 0);

            cmbProductFilter.DataSource = dt;
            cmbProductFilter.DisplayMember = "ProductName";
            cmbProductFilter.ValueMember = "ProductID";
            cmbProductFilter.SelectedIndex = 0;
        }

        // ---------- پر کردن Dropdown نوع ----------
        private void LoadTypeFilter()
        {
            cmbTypeFilter.Items.Clear();
            cmbTypeFilter.Items.Add("همه");
            cmbTypeFilter.Items.Add("ورود (IN)");
            cmbTypeFilter.Items.Add("خروج (OUT)");
            cmbTypeFilter.SelectedIndex = 0;
        }

        // ---------- بارگذاری حرکات انبار ----------
        private void LoadMovements()
        {
            string query = @"
                SELECT m.MovementID, m.MovementDate, p.ProductName,
                       m.MovementType, m.Quantity, m.Description
                FROM StockMovements m
                INNER JOIN Products p ON m.ProductID = p.ProductID
                WHERE (@pid = -1 OR m.ProductID = @pid)
                  AND (@type = N'' OR m.MovementType = @type)
                ORDER BY m.MovementID DESC";

            int productID = Convert.ToInt32(cmbProductFilter.SelectedValue);
            string typeFilter = "";
            if (cmbTypeFilter.SelectedIndex == 1) typeFilter = "IN";
            if (cmbTypeFilter.SelectedIndex == 2) typeFilter = "OUT";

            SqlParameter[] param =
            {
                new SqlParameter("@pid", productID),
                new SqlParameter("@type", typeFilter)
            };

            DataTable dt = DatabaseConnection.ExecuteQuery(query, param);
            dgvMovements.DataSource = dt;

            if (dgvMovements.Columns.Count > 0)
            {
                dgvMovements.Columns["MovementID"].HeaderText = "کد";
                dgvMovements.Columns["MovementDate"].HeaderText = "تاریخ";
                dgvMovements.Columns["ProductName"].HeaderText = "محصول";
                dgvMovements.Columns["MovementType"].HeaderText = "نوع";
                dgvMovements.Columns["Quantity"].HeaderText = "تعداد";
                dgvMovements.Columns["Description"].HeaderText = "توضیحات";

                dgvMovements.Columns["MovementID"].Width = 60;
                dgvMovements.Columns["MovementDate"].Width = 140;
                dgvMovements.Columns["Quantity"].Width = 80;
                dgvMovements.Columns["MovementType"].Width = 70;

                dgvMovements.Columns["MovementDate"].DefaultCellStyle.Format = "yyyy/MM/dd HH:mm";

                // رنگ‌بندی بر اساس نوع
                foreach (DataGridViewRow row in dgvMovements.Rows)
                {
                    if (row.Cells["MovementType"].Value?.ToString() == "IN")
                        row.DefaultCellStyle.ForeColor = System.Drawing.Color.DarkGreen;
                    else if (row.Cells["MovementType"].Value?.ToString() == "OUT")
                        row.DefaultCellStyle.ForeColor = System.Drawing.Color.DarkRed;
                }
            }

            UpdateSummary();
        }

        // ---------- خلاصه ----------
        private void UpdateSummary()
        {
            int count = dgvMovements.Rows.Count;
            int totalIn = 0;
            int totalOut = 0;

            foreach (DataGridViewRow row in dgvMovements.Rows)
            {
                string type = row.Cells["MovementType"].Value?.ToString();
                int qty = Convert.ToInt32(row.Cells["Quantity"].Value ?? 0);
                if (type == "IN") totalIn += qty;
                else if (type == "OUT") totalOut += qty;
            }

            lblCountValue.Text = count.ToString("N0");
            lblInValue.Text = totalIn.ToString("N0");
            lblOutValue.Text = totalOut.ToString("N0");
        }

        // ---------- فیلتر ----------
        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            LoadMovements();
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            cmbProductFilter.SelectedIndex = 0;
            cmbTypeFilter.SelectedIndex = 0;
            LoadMovements();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadProducts();
            LoadMovements();
        }

        // ---------- ثبت ورود جدید ----------
        private void btnNewEntry_Click(object sender, EventArgs e)
        {
            StockEntryForm form = new StockEntryForm("IN");
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadProducts();
                LoadMovements();
            }
        }

        // ---------- ثبت خروج جدید ----------
        private void btnNewExit_Click(object sender, EventArgs e)
        {
            StockEntryForm form = new StockEntryForm("OUT");
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadProducts();
                LoadMovements();
            }
        }

        private void StockForm_KeyDown(object sender, KeyEventArgs e)
        {
            // Ctrl+F → فوکوس روی فیلتر محصول
            if (e.Control && e.KeyCode == Keys.F)
            {
                cmbProductFilter.Focus();
                e.Handled = true;
            }
            // Ctrl+R → بروزرسانی
            else if (e.Control && e.KeyCode == Keys.R)
            {
                btnRefresh.PerformClick();
                e.Handled = true;
            }
            // Escape → پاک کردن فیلترها
            else if (e.KeyCode == Keys.Escape)
            {
                btnClearFilter.PerformClick();
                e.Handled = true;
            }
        }

        private void dgvMovements_KeyDown(object sender, KeyEventArgs e)
        {
            // Enter → برو به دکمه "ثبت ورود"
            if (e.KeyCode == Keys.Enter)
            {
                btnNewEntry.Focus();
                e.Handled = true;
            }
            // Delete → برو به دکمه "ثبت خروج"
            else if (e.KeyCode == Keys.Delete)
            {
                btnNewExit.Focus();
                e.Handled = true;
            }
        }
    }
}