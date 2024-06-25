using app.Core.Repository;
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
            MessageBox.Show("Are you sure you want to ADD new pet owner record?", "Please Provide the Information Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            frmClientModal newClientForm = new frmClientModal();
            newClientForm.ShowDialog();
            dgvClient.Refresh();
               
            }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            // TODO: Create another constructor for Updating Client record by passing
            // the Id as parameter.
            if (dgvClient.RowCount > 0)
            {
                MessageBox.Show("Are you sure you want to UPDATE pet owner record?", "Please Provide the Information Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                int clientId = Convert.ToInt32(dgvClient.SelectedRows[0].Cells["Id"].Value);
                frmClientModal newClientForm = new frmClientModal(clientId);
                newClientForm.ShowDialog();
            }
            else
            { 
                MessageBox.Show("No pet owner record selected, please select pet owner record first before UPDATE.", "No Selected Pet Owner Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (dgvClient.SelectedRows.Count == 0)
            {
                // If the user wants to add a record, inform them to select a pet owner
                MessageBox.Show("Please select a pet owner, you cannot add a new patient/pet if there's no selected pet owner", "Select Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Confirm with the user before adding new record
                DialogResult addConfirmation = MessageBox.Show("Are you sure you want to ADD new pet record?", "Add New Pet Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (addConfirmation == DialogResult.Yes)
                {
                    // Proceed with adding a new record
                    int clientId = Convert.ToInt32(dgvClient.SelectedRows[0].Cells["Id"].Value);
                    int petId = 0;
                    frmClientPatientModal frm = new frmClientPatientModal(petId, clientId);
                    frm.ShowDialog();
                    dgvPatient.Refresh();

                }
            }

        }

        private void btnEditPatient_Click(object sender, EventArgs e)
        {
            if (dgvPatient.SelectedRows.Count == 0)
            {
                // Inform the user to select a record to update
                MessageBox.Show("Please select a pet record first to update.", "Select Pet Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Confirm with the user before updating the record
                DialogResult updateConfirmation = MessageBox.Show("Are you sure you want to UPDATE the pet record?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (updateConfirmation == DialogResult.Yes)
                {
                    int petId = Convert.ToInt32(dgvPatient.SelectedRows[0].Cells["Id"].Value);
                    //string color = dgvPatient.SelectedRows[0].Cells["Color"].Value.ToString();
                    //string breed = dgvPatient.SelectedRows[0].Cells["Breed"].Value.ToString();
                    //string gender = dgvPatient.SelectedRows[0].Cells["Gender"].Value.ToString();
                    //string species = dgvPatient.SelectedRows[0].Cells["Species"].Value.ToString();
                    frmClientPatientModal frm = new frmClientPatientModal(petId);
                    frm.ShowDialog();   
                    dgvPatient.RefreshEdit();
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
            txtAddress.Text = client.GetFullAddress();
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
                // Inform the user to select a record to update
                MessageBox.Show("Please select a pet record first to DELETE.", "Select Pet Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Confirm with the user before deleting the record
                DialogResult deleteConfirmation = MessageBox.Show("Are you sure you want to DELETE the pet record?", "Delete Record", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (deleteConfirmation == DialogResult.OK)
                {
                    // Get the ID of the selected record
                    int petId = Convert.ToInt32(dgvPatient.SelectedRows[0].Cells["Id"].Value);

                    // Call a method to delete the record from the database
                    PetRepository pet = new PetRepository();
                    bool isDeleted = pet.Delete(petId);

                    if (isDeleted)
                    {
                        // Remove the selected row from the DataGridView
                        dgvPatient.Rows.Remove(dgvPatient.SelectedRows[0]);
                        dgvPatient.Refresh();

                        MessageBox.Show("Record deleted successfully.", "Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete record.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void frmClient_Load(object sender, EventArgs e)
        {

        }
    }
}