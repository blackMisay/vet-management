using app.core.Repository;
using app.Core.Repository;
using app.view.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core;

namespace app.view.Services
{
    public partial class frmServices : Form
    {
        
        public frmServices()
        {
            InitializeComponent();
        }

        private void frmServices_Load(object sender, EventArgs e)
        {
            UpgradeFile upgradeFile = new UpgradeFile();

            dgvServices.DataSource = upgradeFile.Load("SELECT * FROM services WHERE isDeleted=0;");

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //TODO: Populate the datagridview based on the filtered name provided in Search box.
            if (!string.IsNullOrEmpty(txtSearch.Text) || !string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                ServiceRepository repository = new ServiceRepository();
                dgvServices.DataSource = repository.SearchService(txtSearch.Text);
                this.dgvServices.Columns["Id"].Visible = false;
            }
            else
            {
                MessageBox.Show("The search field is empty, please provide.", "Empty field", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEditService_Click(object sender, EventArgs e)
        {
            if (dgvServices.SelectedRows.Count == 0)
            {
                // Inform the user to select a record to update
                MessageBox.Show("Please select a service.", "Select Service", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Confirm with the user before updating the record
                DialogResult updateConfirmation = MessageBox.Show("Are you sure you want to UPDATE the service?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (updateConfirmation == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dgvServices.SelectedRows[0].Cells["Id"].Value);
                    FrmServicesModal frmServicesModal = new FrmServicesModal(id);
                    frmServicesModal.ShowDialog();
                    dgvServices.RefreshEdit();
                }
                UpgradeFile upgradeFile = new UpgradeFile();
                dgvServices.DataSource = upgradeFile.Load("SELECT * FROM services WHERE isDeleted =0");
            }
        }

        private void btnRemoveService_Click(object sender, EventArgs e)
        {
            if (dgvServices.SelectedRows.Count == 0)
            {
                // Inform the user to select a record to update
                MessageBox.Show("Please select a service first to DELETE.", "Select Product Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Confirm with the user before deleting the record
                DialogResult deleteConfirmation = MessageBox.Show("Are you sure you want to DELETE the service record?", "Delete Record", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (deleteConfirmation == DialogResult.OK)
                {
                    // Get the ID of the selected record
                    int serviceId = Convert.ToInt32(dgvServices.SelectedRows[0].Cells["Id"].Value);

                    // Call a method to delete the record from the database
                    ServiceRepository service = new ServiceRepository();
                    bool isDeleted = service.DeleteService(serviceId);

                    if (isDeleted)
                    {
                        // Remove the selected row from the DataGridView
                        dgvServices.Rows.Remove(dgvServices.SelectedRows[0]);
                        dgvServices.Refresh();

                        MessageBox.Show("Record deleted successfully.", "Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete record.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void btnSaveService_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure you want to ADD new Service Offered?", "Please Provide the Information Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FrmServicesModal frm = new FrmServicesModal();
            frm.ShowDialog();
            dgvServices.Refresh();
        }
    }
        }
    


