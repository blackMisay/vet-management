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
        private int inventoryID;
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
            this.inventoryID = inventoryID;
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
            // Convert and validate the input values
            int quantity = Convert.ToInt32(txtQty.Text);
            double unitPrice = Convert.ToDouble(txtUnitPrice.Text);

            // Calculate the total amount
            double amount = quantity * unitPrice;

            // Display the computed amount in the Amount field
            txtTotalAmount.Text = amount.ToString("F2"); // Formats to 2 decimal places

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
                TypeID = new app.core.Types { Id = Convert.ToInt32(cmbProduct.SelectedValue) },
                BrandID = new app.core.model.Brand { Id = Convert.ToInt32(cmbBrand.SelectedValue) },
                CategID = new app.core.model.ProductCategory { Id = Convert.ToInt32(cmbCateg.SelectedValue) },
                Qty = quantity,
                UnitPrice = unitPrice,
                TotalAmount = amount,
                DateReceived = dtpReceived.Value,  
                ExpiredDate = dtpExp.Value       
            };


            // Save the inventory
            if (new InventoryRepository().SaveInventory(inventory))
            {
                MessageBox.Show($"Inventory saved successfully with stock number: {nextStockNumber}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmInventory frm = new frmInventory();
                frm.dgvInventory.RefreshEdit();
                this.Close();
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
            frmInventory frm = new frmInventory();
            UpgradeFile upgradeFile = new UpgradeFile();
            frm.dgvInventory.DataSource = upgradeFile.Load("SELECT * FROM vwinventory WHERE isDeleted=0;");
            frm.dgvInventory.Refresh();


        }
        private void LoadDetails(app.core.model.Inventory inventory)
        {
            
            lblStockNumber.Text = inventory.StockNumber.ToString();
            cmbBrand.SelectedValue = inventory.BrandID.Id;
            cmbProduct.SelectedValue = inventory.TypeID.Id;
            cmbCateg.SelectedValue = inventory.CategID.Id;
            txtDesc.Text = inventory.Description;
            txtQty.Text = inventory.Qty.ToString();
            txtUnitPrice.Text = inventory.UnitPrice.ToString();
            txtTotalAmount.Text = inventory.TotalAmount.ToString();
            dtpReceived.Text = inventory.DateReceived.ToString();
            dtpExp.Text = inventory.ExpiredDate.ToString();
        }

        private void LoadInventoryDetails()
        {
            if (!string.IsNullOrEmpty(StockNumber))
            {
                lblStockNumber.Text = StockNumber; // Display the stock number
            }
            else
            {
                lblStockNumber.Text = "N/A"; // Or a default message
            }

            InventoryRepository inventoryRepository = new InventoryRepository();
            var inventory = inventoryRepository.GetInventory(new app.core.model.Inventory() { Id = this.inventoryID });

            if (inventory != null)
            {
               LoadDetails(inventory);
            }
        }

        private void PopulateCmb()
        {
            if (!string.IsNullOrEmpty(StockNumber))
            {
                lblStockNumber.Text = StockNumber; // Display the stock number
            }
            else
            {
                lblStockNumber.Text = "N/A"; // Or a default message
            }

            UpgradeFile upgradeFile = new UpgradeFile();

            cmbBrand.DataSource = upgradeFile.Populate("SELECT brandId, brandDesc FROM product_brands;");
            cmbBrand.ValueMember = "Key";
            cmbBrand.DisplayMember = "Value";

            cmbCateg.DataSource = upgradeFile.Populate("SELECT id, description FROM product_category;");
            cmbCateg.ValueMember = "Key";
            cmbCateg.DisplayMember = "Value";

            cmbProduct.DataSource = upgradeFile.Populate("SELECT id, description FROM product_types;");
            cmbProduct.ValueMember = "Key";
            cmbProduct.DisplayMember = "Value";

        }

        private void txtTotalAmount_TextChanged(object sender, EventArgs e)
        {
            // Convert and validate the input values
            int quantity = Convert.ToInt32(txtQty.Text);
            double unitPrice = Convert.ToDouble(txtUnitPrice.Text);

            // Calculate the total amount
            double amount = quantity * unitPrice;

            // Display the computed amount in the Amount field
            txtTotalAmount.Text = amount.ToString("F2"); // Formats to 2 decimal places

        }
    }
}
