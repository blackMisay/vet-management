using app.core.Repository;
using app.Core.Repository;
using System;
using System.Windows.Forms;

namespace app.view.Inventory
{
    public partial class frmInventoryModal : Form
    {
        int Id = 0;
        public frmInventoryModal()
        {
            InitializeComponent();
        }

        private void frmInventoryModal_Load(object sender, EventArgs e)
        {
            UpgradeFile upgradeFile = new UpgradeFile();

            cmbBrand.DataSource = upgradeFile.Populate("SELECT brandID, brandDesc FROM brands;");
            cmbBrand.ValueMember = "Key";
            cmbBrand.DisplayMember = "Value";

            cmbCateg.DataSource = upgradeFile.Populate("SELECT categId, categDesc FROM prod_categ;");
            cmbCateg.ValueMember = "Key";
            cmbCateg.DisplayMember = "Value";

            cmbProduct.DataSource = upgradeFile.Populate("SELECT prodID, prodDesc FROM product;");
            cmbProduct.ValueMember = "Key";
            cmbProduct.DisplayMember = "Value";

        }

        public void SaveInventory()
        {
            app.core.model.Inventory inventory = new app.core.model.Inventory();

            inventory.Id = this.Id;
            inventory.StockNumber = txtStockNum.Text;
            inventory.Description = txtDesc.Text;
            inventory.ProdID = Convert.ToInt32(cmbProduct.SelectedValue);
            inventory.BrandID = Convert.ToInt32(cmbBrand.SelectedValue);
            inventory.CategID = Convert.ToInt32(cmbCateg.SelectedValue);
            inventory.Qty = Convert.ToInt32(txtQty.Text);
            inventory.DateReceived = dtpReceived.Value.ToString("yyyy-MM-dd");
            inventory.ExpiredDate = dtpExp.Value.ToString("yyyy-MM-dd");
        
            InventoryRepository repository = new InventoryRepository();
            if (repository.SaveInventory(inventory))
            {
                MessageBox.Show("Save successfully");
            }
            else
            {
                MessageBox.Show("Unable to save record");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Ask the user for confirmation before canceling
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to cancel your work?", "Confirm Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show("Work has been cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveInventory();
            this.Dispose();
            frmInventory frm = new frmInventory();
            frm.Refresh();
        }
    }
}
