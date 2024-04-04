﻿using app.Core.Repository;
using app.View.Patient;
using System;
using System.Windows.Forms;
using app.Core.Model;

namespace app.view.Client
{
    public partial class frmClient : Form
    {
        app.Core.Model.Client client;
        int selectedClientId = 0;
        int clientId = 0;
        public frmClient()
        {
            InitializeComponent();
        }

        public frmClient(int selectedClientId)
        {
            InitializeComponent();  
            this.clientId = selectedClientId;
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            using (frmClientModal newClientForm = new frmClientModal())
            {
                newClientForm.ShowDialog();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // TODO: Create another constructor for Updating Client record by passing
            // the Id as parameter.
            using (frmClientModal newClientForm = new frmClientModal())
            {
                newClientForm.ShowDialog();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //TODO: Populate the datagridview based on the filtered name provided in Search box.
            if (!string.IsNullOrEmpty(txtSearch.Text) || !string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                ClientRepository repo = new ClientRepository();
                dgvClient.DataSource = repo.RetrieveSelectedClient(txtSearch.Text);
                this.dgvClient.Columns["Id"].Visible = false;
            }
            else
            {
                MessageBox.Show("The search field is empty, please provide.", "Empty field", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvClient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //TODO: Get the id of the selected record.
            if (dgvClient.RowCount > 0)
            {
                int selectedRowIndex = dgvClient.SelectedCells[0].RowIndex;
                this.selectedClientId = Convert.ToInt32(dgvClient.Rows[selectedRowIndex].Cells[0].Value?.ToString());
            }
        }

        private void dgvClient_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //TODO: Using the returned id from the cellClick event. Used it to
            // retrieve the record from the database.
        }

        private void btnAddPatient_Click(object sender, EventArgs e)
        {
            if (dgvClient.SelectedRows.Count == 0 || dgvClient.Rows.Count < 0)
            {
                DialogResult result = MessageBox.Show("No record is selected. Would you like to ADD a record?", "No Record Found", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // If the user wants to add a record, inform them to select a pet owner
                    MessageBox.Show("Please select a pet owner.", "Select Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                // Confirm with the user before adding new record
                DialogResult addConfirmation = MessageBox.Show("Are you sure you want to ADD new record?", "Add New Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (addConfirmation == DialogResult.Yes)
                {
                    // Proceed with adding a new record
                    frmClientPatientModal frm = new frmClientPatientModal(this.clientId);
                    frm.ShowDialog();
                }
            }

        }

        private void btnEditPatient_Click(object sender, EventArgs e)
        {
            if (dgvPatient.SelectedRows.Count == 0)
            {
                DialogResult result = MessageBox.Show("No record is selected. Would you like to UPDATE a record?", "No Record Found", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Inform the user to select a record to update
                    MessageBox.Show("Please select a record to update.", "Select Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                // Confirm with the user before updating the record
                DialogResult updateConfirmation = MessageBox.Show("Are you sure you want to UPDATE?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (updateConfirmation == DialogResult.Yes)
                { 
                    frmClientPatientModal frm = new frmClientPatientModal(this.clientId); 
                    frm.ShowDialog();
                }
            }

        }
        private void dgvClient_DoubleClick(object sender, EventArgs e)
        {
            this.LoadClient();
            this.LoadPets();
        }

        private void LoadClient()
        {
            ClientRepository repo = new ClientRepository();
            client = new Core.Model.Client();
            client = repo.GetClientInformation(new Core.Model.Client() { Id = this.selectedClientId });

            txtFullname.Text = client.GetFullName();
            txtContacts.Text = client.GetAllContact();
            txtAddress.Text = client.StreetNo;
        }

        private void LoadPets()
        {
            PetRepository petRepository = new PetRepository();
            dgvPatient.DataSource = petRepository.LoadClientsPatients(this.selectedClientId);
        }
        private void btnRemovePatient_Click(object sender, EventArgs e)
        {
            if (dgvPatient.SelectedRows.Count == 0)
            {
                DialogResult result = MessageBox.Show("No record is selected. Would you like to DELETE a record?", "No Record Found", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Inform the user to select a record to delete
                    MessageBox.Show("Please select a record to DELETE.", "Select Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                // Confirm with the user before deleting the record
                DialogResult deleteConfirmation = MessageBox.Show("Are you sure you want to DELETE?", "Delete Record", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (deleteConfirmation == DialogResult.OK)
                {
                    
                    dgvPatient.Rows.RemoveAt(dgvPatient.SelectedRows[0].Index);
                    dgvPatient.Refresh();
                }
            }

        }
    }
}
