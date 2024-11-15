using Core;
using app.core.Repository;
using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;

namespace app.view.Inventory
{
    public partial class frmInventory : Form
    {
        public frmInventory()
        {
            InitializeComponent();
        }

        private void frmInventory_Load(object sender, EventArgs e)
        {
            UpgradeFile upgradeFile = new UpgradeFile();

            dgvInventory.DataSource = upgradeFile.Load("SELECT * FROM vwinventory WHERE isDeleted=0;");

            InventoryRepository inventory = new InventoryRepository();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //TODO: Populate the datagridview based on the filtered name provided in Search box.
            if (!string.IsNullOrEmpty(txtSearch.Text) || !string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                InventoryRepository inventory = new InventoryRepository();
                DataTable dt = inventory.SearchInventory(txtSearch.Text);

                if (dt != null && dt.Rows.Count > 0)
                {
                    dgvInventory.DataSource = dt;
                    this.dgvInventory.Columns["Id"].Visible = false;
                }
                else
                {
                    MessageBox.Show("No results found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("The search field is empty, please provide.", "Empty field", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvInventory.SelectedRows.Count == 0)
            {
                // Inform the user to select a record to update
                MessageBox.Show("Please select a product.", "Select Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                // Confirm with the user before updating the record
                DialogResult updateConfirmation = MessageBox.Show("Are you sure you want to UPDATE the Product?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (updateConfirmation == DialogResult.Yes)
                {
                    int inventoryID = Convert.ToInt32(dgvInventory.SelectedRows[0].Cells["Id"].Value);
                    frmInventoryModal Modal = new frmInventoryModal(inventoryID);
                    Modal.ShowDialog();
                }
            }
            UpgradeFile upgradeFile = new UpgradeFile();
            dgvInventory.DataSource = upgradeFile.Load("Select * FROM vwinventory WHERE isDeleted=0");
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            string nextStockNumber = GenerateNextStockNumber();

            if (nextStockNumber == null)
            {
                MessageBox.Show("Failed to generate stock number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Pass the generated stock number to the modal form
            frmInventoryModal frmInventory = new frmInventoryModal();
            frmInventory.StockNumber = nextStockNumber;  // Set the stock number

            // Show the modal form
            frmInventory.ShowDialog();
      
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvInventory.SelectedRows.Count == 0)
            {
                // Inform the user to select a record to update
                MessageBox.Show("Please select a product first to DELETE.", "Select Product Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Confirm with the user before deleting the record
                DialogResult deleteConfirmation = MessageBox.Show("Are you sure you want to DELETE the product record?", "Delete Record", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (deleteConfirmation == DialogResult.OK)
                {
                    // Get the ID of the selected record
                    int inventoryID = Convert.ToInt32(dgvInventory.SelectedRows[0].Cells["Id"].Value);

                    // Call a method to delete the record from the database
                    InventoryRepository Repository = new InventoryRepository();
                    bool isDeleted = Repository.DeleteInventory(inventoryID);

                    if (isDeleted)
                    {
                        // Remove the selected row from the DataGridView
                        dgvInventory.Rows.Remove(dgvInventory.SelectedRows[0]);
                        dgvInventory.Refresh();  

                        MessageBox.Show("Record deleted successfully.", "Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete record.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }
        public string GenerateNextStockNumber()
        {
            string prefix = "SN";
            int nextNumber = 1;  // Default start value

            // Get the last stock number from the database (this is just an example, you should retrieve the actual last stock number from the DB)
            string lastStockNumber = GetLastStockNumberFromDatabase();  // Replace with your actual logic to get the last stock number

            if (!string.IsNullOrEmpty(lastStockNumber))
            {
                // Strip "SN" and convert to integer
                int lastNumber = Convert.ToInt32(lastStockNumber.Substring(2));  // Remove "SN" prefix
                nextNumber = lastNumber + 1;  // Increment the last number
            }

            return prefix + nextNumber.ToString("D8");  // Format as SN00000001 (8 digits)
        }

        public string GetLastStockNumberFromDatabase()
        {
            try
            {
                // SQL query to fetch the last stock number where isDeleted = 0
                string query = " SELECT stocksNum FROM prod_stocks WHERE isDeleted = 0 ORDER BY stocksNum DESC LIMIT 1; ";

                // Create parameters for the query (if needed, for example, in case of parameterized queries)
                Dictionary<string, string> parameters = new Dictionary<string, string>();

                // Execute the query using UpgradeFile
                UpgradeFile upgradeFile = new UpgradeFile();
                DataTable resultTable = upgradeFile.Load(query, parameters);

                if (resultTable != null && resultTable.Rows.Count > 0)
                {
                    // Ensure StockNumber is returned as a string (or cast accordingly)
                    var stockNumber = resultTable.Rows[0]["stocksNum"];

                    // If StockNumber is not null or DBNull
                    if (stockNumber != DBNull.Value)
                    {
                        return stockNumber.ToString();  // Return the StockNumber as a string
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching last stock number: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;  // Return null if there's an issue or no data found

        }

    }
}
