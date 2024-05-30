using app.core.Repository;
using app.Core.Repository;
using app.view.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            dgvInventory.DataSource = upgradeFile.Load("SELECT * FROM vwinventory;");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //TODO: Populate the datagridview based on the filtered name provided in Search box.
            if (!string.IsNullOrEmpty(txtSearch.Text) || !string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                InventoryRepository inventoryRepository = new InventoryRepository();
                dgvInventory.DataSource = inventoryRepository.SearchInventory(txtSearch.Text);
                this.dgvInventory.Columns["Id"].Visible = false;
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
                MessageBox.Show("Please select an Item.", "Select Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Confirm with the user before updating the record
                DialogResult updateConfirmation = MessageBox.Show("Are you sure you want to UPDATE the Item?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (updateConfirmation == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dgvInventory.SelectedRows[0].Cells["Id"].Value);
                    frmInventoryModal frmInventoryModal = new frmInventoryModal();
                    frmInventoryModal.ShowDialog();
                    dgvInventory.RefreshEdit();
                }
            }
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            frmInventoryModal frmInventory = new frmInventoryModal();
            frmInventory.ShowDialog();
            dgvInventory.Refresh();
        }
    }
}
