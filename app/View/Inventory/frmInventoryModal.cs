using app.core.repository;
using app.core.Repository;
using app.Core.Repository;
using System;
using System.Windows.Forms;

namespace app.view.Inventory
{
    public partial class frmInventoryModal : Form
    {
       private int Id;

        public frmInventoryModal()
        {
            InitializeComponent();
            this.Load += frmInventoryModal_Load;
        }

        public frmInventoryModal(int inventoryID) : this()
        {
            this.Id = inventoryID;
            LoadInventoryDetails();
            btnSave.Text = "Update";
            label1.Text = "Update Item";
        }

        private void frmInventoryModal_Load(object sender, EventArgs e)
        {
            PopulateCmb();
        }

        public void SaveInventory()
        {
            app.core.model.Inventory inventory = new app.core.model.Inventory();

            inventory.Id = this.Id;
            inventory.StockNumber = Convert.ToInt32(txtStockNum.Text);
            inventory.Description = txtDesc.Text;
            inventory.ProdID = new app.core.model.Product() { Id = Convert.ToInt32(cmbProduct.SelectedValue) };
            inventory.BrandID = new app.core.model.Brand() { Id = Convert.ToInt32(cmbBrand.SelectedValue) };
            inventory.CategID = new app.core.model.ProductCategory { Id = Convert.ToInt32(cmbCateg.SelectedValue) };
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
            UpgradeFile upgradeFile = new UpgradeFile();
            frmInventory frm = new frmInventory();
            frm.dgvInventory.DataSource = upgradeFile.Load("Select * FROM vwinventory WHERE isDeleted=0");
            this.Dispose();
        }

        private void LoadDetails(app.core.model.Inventory inventory)
        {
            txtStockNum.Text = inventory.StockNumber.ToString();
            cmbBrand.SelectedValue = inventory.BrandID.Id;
            cmbProduct.SelectedValue = inventory.ProdID.Id;
            txtDesc.Text = inventory.Description;
            cmbCateg.SelectedValue = inventory.CategID.Id;
            txtQty.Text = inventory.Qty.ToString();
            dtpReceived.Text = inventory.DateReceived.ToString();
            dtpExp.Text = inventory.ExpiredDate.ToString();
        }

        private void LoadInventoryDetails()
        {
            InventoryRepository inventoryRepository = new InventoryRepository();
            var inventory = inventoryRepository.GetInventory(new app.core.model.Inventory() { Id = this.Id });
            if (inventory != null)
            {
                LoadDetails(inventory);
            }
        }

        private void PopulateCmb()
        {
            UpgradeFile upgradeFile = new UpgradeFile();

            cmbBrand.DataSource = upgradeFile.Populate("SELECT id, description FROM product_brand;");
            cmbBrand.ValueMember = "Key";
            cmbBrand.DisplayMember = "Value";

            cmbCateg.DataSource = upgradeFile.Populate("SELECT id, description FROM product_category;");
            cmbCateg.ValueMember = "Key";
            cmbCateg.DisplayMember = "Value";

            cmbProduct.DataSource = upgradeFile.Populate("SELECT prodID, prodDesc FROM product;");
            cmbProduct.ValueMember = "Key";
            cmbProduct.DisplayMember = "Value";

        }
    }
}
