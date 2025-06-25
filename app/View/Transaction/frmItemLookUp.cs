using app.core.model;
using Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace app.view.Transaction
{
    public partial class frmItemLookUp : Form
    {

        private Dictionary<int, app.core.model.Inventory> selectedItem;

        public frmItemLookUp()
        {
            InitializeComponent();

            selectedItem = new Dictionary<int, app.core.model.Inventory>();
        }

        public frmItemLookUp(Dictionary<int, app.core.model.Inventory> items)
        {
            InitializeComponent();

            selectedItem = new Dictionary<int, app.core.model.Inventory>();
            selectedItem = items;
        }

        public Dictionary<int, app.core.model.Inventory> GetAllItems()
        {
            return selectedItem;
        }

        private void frmItemLookUp_Load(object sender, EventArgs e)
        {
            lblDesc.Text = "This form allows the user to select product.";
           
            UpgradeFile upgradeFile = new UpgradeFile();

            dgvProducts.DataSource = upgradeFile.Load("SELECT * FROM vw_inventory_products");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Validate quantity input
            if (string.IsNullOrWhiteSpace(txtQuantity.Text))
            {
                MessageBox.Show("Please input a quantity for the selected item.", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtQuantity.Text.Trim(), out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Please enter a valid quantity greater than 0.", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Calculate total price
            double price = this.selectedItemPrice;
            double totalPrice = quantity * price;

            // Create or update Inventory item
            var item = new app.core.model.Inventory
            {
                Id = selectedId,
                Description = selectedItemDescription,
                Stock = quantity,
                Price = price
            };

            // Add or update in dictionary
            selectedItem[selectedId] = item;

            // Optionally update UI like subtotal
            // UpdateSubTotal();

            MessageBox.Show($"Item \"{selectedItemDescription}\" has been added/updated successfully.",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Reset form
            btnRemove.Enabled = false;
            ResetItemField();
            this.Close();
        }



        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only numeric input, backspace, and control characters
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        int selectedId = 0;
        double selectedItemPrice;
        string selectedItemDescription;
        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProducts.RowCount > 0 && dgvProducts.SelectedCells.Count > 0)
            {
                int selectedRowIndex = dgvProducts.SelectedCells[0].RowIndex;

                // Get selected product details
                int selectedId = Convert.ToInt32(dgvProducts.Rows[selectedRowIndex].Cells[0].Value);
                int selectedPrice = Convert.ToInt32(dgvProducts.Rows[selectedRowIndex].Cells[6].Value);
                string selectedDescription = dgvProducts.Rows[selectedRowIndex].Cells[3].Value?.ToString() + " - " +
                                             dgvProducts.Rows[selectedRowIndex].Cells[4].Value?.ToString();

                // Store to class-level variables
                this.selectedId = selectedId;
                this.selectedItemPrice = selectedPrice;
                this.selectedItemDescription = selectedDescription;

                // Check if product was already selected
                if (selectedItem.ContainsKey(selectedId))
                {
                    btnRemove.Enabled = true;

                    DialogResult result = MessageBox.Show(
                        "This product is already selected. Do you want to update it?",
                        "Confirm Update",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Load item data to fields for editing
                        var item = selectedItem[selectedId];
                        txtQuantity.Text = item.Stock.ToString();
                        // txtTotal.Text = item.TotalAmount.ToString(); // if applicable
                    }
                    // If user says No, nothing happens — keeps current selection
                }
                else
                {
                    btnRemove.Enabled = false;

                    // Prepare for new item entry
                    ResetItemField();

                    //// Optionally pre-fill quantity field or other fields
                    //txtQuantity.Text = "1";
                }
            }

        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtQuantity.Text) || string.IsNullOrWhiteSpace(txtQuantity.Text))
            {
                ResetItemField();
                return;
            }

            txtTotal.Text = (selectedItemPrice * Convert.ToDouble(txtQuantity.Text)).ToString();
        }

        private void ResetItemField()
        {
            txtQuantity.Text = string.Empty;
            txtTotal.Text = string.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (selectedItem.Count > 0 && selectedItem.ContainsKey(selectedId))
            {
                if (MessageBox.Show("Do you want to remove the selected item?", "Confirm to remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    selectedItem.Remove(selectedId);
                    btnRemove.Enabled = false;
                }
            }
        }
    }
}
