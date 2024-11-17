using app.core.Repository;
using System;
using System.Windows.Forms;
using Core; 

namespace app.view.Inventory
{
    public partial class frmInventoryModal : Form
    {
       private int Id;
        private string stockNumber;
        private string nextStockNumber;
        public string StockNumber { get; set; }

        public frmInventoryModal()
        {
            InitializeComponent();
            this.Load += frmInventoryModal_Load;

        }
        public frmInventoryModal(string nextStockNumber)
        {
            stockNumber = nextStockNumber;
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
            // Check if StockNumber is set and display it
            if (!string.IsNullOrEmpty(StockNumber))
            {
                lblStockNumber.Text = StockNumber;  // Display the stock number
            }
            else
            {
                lblStockNumber.Text = "N/A";  // Or a default message
            }
        }

        public void SaveInventory()
        {
            // Validate required fields
            if (string.IsNullOrEmpty(txtDesc.Text))
            {
                MessageBox.Show("Please enter a description.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDesc.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtQty.Text) || Convert.ToInt32(txtQty.Text) <= 0)
            {
                MessageBox.Show("Please enter a valid quantity greater than zero.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQty.Focus();
                return;
            }
            if (cmbProduct.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a product.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbProduct.Focus();
                return;
            }
            if (cmbBrand.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a brand.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbBrand.Focus();
                return;
            }
            if (cmbCateg.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a category.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCateg.Focus();
                return;
            }

            // Generate the next stock number using the repository directly or calling a helper function
            InventoryRepository repository = new InventoryRepository();
            string nextStockNumber = repository.GenerateNextStockNumber();

            if (string.IsNullOrEmpty(nextStockNumber))
            {
                MessageBox.Show("Failed to generate stock number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // Create inventory object
            var inventory = new app.core.model.Inventory
            {
                Id = this.Id,
                StockNumber = nextStockNumber,
                Description = txtDesc.Text,
                ProdID = new app.core.model.Product { Id = Convert.ToInt32(cmbProduct.SelectedValue) },
                BrandID = new app.core.model.Brand { Id = Convert.ToInt32(cmbBrand.SelectedValue) },
                CategID = new app.core.model.ProductCategory { Id = Convert.ToInt32(cmbCateg.SelectedValue) },
                Qty = Convert.ToInt32(txtQty.Text),
                DateReceived = dtpReceived.Value.ToString("yyyy-MM-dd"),
                ExpiredDate = dtpExp.Value.ToString("yyyy-MM-dd")
            };

            // Save the inventory
            if (new InventoryRepository().SaveInventory(inventory))
            {
                MessageBox.Show($"Inventory saved successfully with stock number: {nextStockNumber}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                new frmInventory().dgvInventory.Refresh();
            }
            else
            {
                MessageBox.Show("Unable to save the record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            
        }

        private void LoadDetails(app.core.model.Inventory inventory)
        {
            lblStockNumber.Text = inventory.StockNumber.ToString();
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

            cmbBrand.DataSource = upgradeFile.Populate("SELECT brandId, brandDesc FROM product_brands;");
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
