using System;
using System.Windows.Forms;
using InventoryApp.Classes;

namespace InventoryApp
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }

        // ---------- بارگذاری تنظیمات ----------
        private void LoadSettings()
        {
            SettingsHelper.ClearCache();
            txtShopName.Text = SettingsHelper.ShopName;
            txtAddress.Text = SettingsHelper.ShopAddress;
            txtPhone.Text = SettingsHelper.ShopPhone;
            txtSlogan.Text = SettingsHelper.ShopSlogan;
            txtFooter.Text = SettingsHelper.InvoiceFooter;
            chkShowLogo.Checked = SettingsHelper.ShowLogo;
        }

        // ---------- ذخیره تنظیمات ----------
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtShopName.Text))
            {
                MessageBox.Show("نام فروشگاه را وارد کنید.", "خطا",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtShopName.Focus();
                return;
            }

            try
            {
                SettingsHelper.ShopName = txtShopName.Text.Trim();
                SettingsHelper.ShopAddress = txtAddress.Text.Trim();
                SettingsHelper.ShopPhone = txtPhone.Text.Trim();
                SettingsHelper.ShopSlogan = txtSlogan.Text.Trim();
                SettingsHelper.InvoiceFooter = txtFooter.Text.Trim();
                SettingsHelper.ShowLogo = chkShowLogo.Checked;

                MessageBox.Show("✅ تنظیمات با موفقیت ذخیره شد.",
                    "موفق", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا:\n" + ex.Message, "خطا",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("تنظیمات ذخیره‌نشده پاک شود؟", "تأیید",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LoadSettings();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void lblSlogan_Click(object sender, EventArgs e)
        {

        }
        
    }
}