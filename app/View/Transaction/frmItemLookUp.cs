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

            dgvProducts.DataSource = upgradeFile.Load("SELECT stockID,batchNum,categoryDescription,typeDescription,brandDesc,stockDescription,price,qty,expDate FROM vwinventory WHERE isDeleted = 0");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtQuantity.Text) || string.IsNullOrWhiteSpace(txtQuantity.Text))
            {
                MessageBox.Show("Please input a quantity for the selected item", "Invalid Quantity");
                return;
            }

            // Ensure the quantity is a valid integer
            if (!int.TryParse(txtQuantity.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Please enter a valid quantity greater than 0.", "Invalid Quantity");
                return;
            }

            // Calculate total price for the item
            double unitPrice = this.selectedItemPrice;
            double totalPrice = quantity * unitPrice;

            // Create item object
            app.core.model.Inventory item = new app.core.model.Inventory()
            {
                Id = selectedId,
                Description = selectedItemDescription,
                Qty = quantity,
                UnitPrice = unitPrice,
            };

            // Update selectedItem dictionary
            if (selectedItem.ContainsKey(selectedId))
            {
                selectedItem[selectedId] = item;
            }
            else
            {
                selectedItem.Add(selectedId, item);
            }

            // **Update subtotal and display**
            //UpdateSubTotal();

            MessageBox.Show($"Item {this.selectedItemDescription} has been added successfully",
                            "Added successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            if (dgvProducts.RowCount > 0)
            {
                int selectedRowIndex = dgvProducts.SelectedCells[0].RowIndex;

                this.selectedId = Convert.ToInt32(dgvProducts.Rows[selectedRowIndex].Cells[0].Value?.ToString());
                
                this.selectedItemPrice = Convert.ToInt32(dgvProducts.Rows[selectedRowIndex].Cells[6].Value?.ToString());
                this.selectedItemDescription = dgvProducts.Rows[selectedRowIndex].Cells[5].Value?.ToString() + " - " + dgvProducts.Rows[selectedRowIndex].Cells[5].Value?.ToString();

                if (selectedItem.Count > 0)
                {
                    if (selectedItem.ContainsKey(selectedId))
                    {
                        btnRemove.Enabled = true;

                        if (MessageBox.Show("Do you want to update already selected item?", "Confirm to update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            app.core.model.Inventory item = new app.core.model.Inventory();
                            item = selectedItem[selectedId];

                            txtQuantity.Text = item.Qty.ToString();
                            //txtTotal.Text = item.TotalAmount.ToString();
                        }
                    }
                    else
                    {
                        btnRemove.Enabled = false;
                    }
                }
                else
                {
                    ResetItemField();
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
