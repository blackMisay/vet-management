using app.Core.Model;
using app.Core.Repository;
using System;
using System.Windows.Forms;

namespace app.view.Client
{
    public partial class frmClient : Form
    {
        app.Core.Model.Client client;
        int selectedClientId = 0;
        public frmClient()
        {
            InitializeComponent();
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
                dgvClient.DataSource =  repo.RetrieveSelectedClient(txtSearch.Text);
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
            using (frmClientPatientModal newClientPatientForm = new frmClientPatientModal())
            { 
                    if (dgvClient.RowCount > 0)
                {
                    MessageBox.Show("Are you sure you want to ADD new pet?","Please Provide the Information Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    newClientPatientForm.ShowDialog();
                }
                else
                {
                    
                    MessageBox.Show("No pet owner selected, please select.", "Empty Pet Owner", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
        }

        private void btnEditPatient_Click(object sender, EventArgs e)
        {
            using (frmClientPatientModal newClientPatientForm = new frmClientPatientModal())
            {
                if(dgvClient.RowCount > 0)
                {
                    MessageBox.Show("Are you sure you want to EDIT?", "Please Provide the Information Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    newClientPatientForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No pet owner selected, please select.", "Empty Pet Owner", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            using (frmClientPatientModal newClientPatientForm = new frmClientPatientModal())
            {
                if (dgvClient.RowCount > 0)
                {
                    
                    MessageBox.Show("Are you sure you want to DELETE?", "Delete Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                else
                {
                    MessageBox.Show("No pet owner selected, please select.", "Empty Pet Owner", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        
    }
}
