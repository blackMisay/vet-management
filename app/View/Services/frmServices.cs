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
using app.Core.Model;

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

            dgvServices.DataSource = upgradeFile.Load("SELECT * FROM services;");

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
                    FrmServicesModal frmServicesModal = new FrmServicesModal();
                    frmServicesModal.ShowDialog();
                    dgvServices.RefreshEdit();
                }
            }
        }

        private void btnRemoveService_Click(object sender, EventArgs e)
        {
           

        }

        private void btnSaveService_Click(object sender, EventArgs e)
        {
            FrmServicesModal frm = new FrmServicesModal();
            frm.ShowDialog();
            dgvServices.Refresh();
        }
    }
        }
    


