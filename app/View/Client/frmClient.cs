using app.Core.Model;
using app.Core.Repository;
using System;
using System.Windows.Forms;
using System.Xml.Linq;

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
            dgvPatient.CellDoubleClick += dgvPatient_CellDoubleClick;
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
            if (dgvClient.RowCount > 0 && dgvClient.SelectedRows.Count > 0)
            {
                MessageBox.Show("Are you sure you want to UPDATE pet owner record?", "Please Provide the Information Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                int clientId = Convert.ToInt32(dgvClient.SelectedRows[0].Cells["Id"].Value);
                frmClientModal newClientForm = new frmClientModal(clientId);
                newClientForm.ShowDialog();
                this.LoadClient();
            }
            else
            {
                MessageBox.Show("No pet owner record selected, please select pet owner record first before UPDATE.", "No Selected Pet Owner Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
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
            // Ignore header clicks
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            var cellValue = dgvClient.Rows[e.RowIndex].Cells["Id"]?.Value;

            if (cellValue == null || !int.TryParse(cellValue.ToString(), out int clientId))
            {
                MessageBox.Show("Invalid client id.");
                return;
            }

            // Optional: Do something with clientId
        }

        private void dgvClient_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            try
            {
                var cellValue = dgvClient.Rows[e.RowIndex].Cells["Id"].Value;

                if (cellValue == null)
                {
                    MessageBox.Show("No client ID found.");
                    return;
                }

                int clientId = Convert.ToInt32(cellValue);

                // Set the class-level selectedClientId for LoadClient and LoadPets to use
                this.selectedClientId = clientId;

                var repo = new ClientRepository();
                var client = repo.GetClientInformation(new app.Core.Model.Client { Id = clientId });

                if (client != null)
                {
                    MessageBox.Show("Client: " + client.GetFullName()); // or GetClientFullName() if implemented

                    // Load details into UI using the selectedClientId
                    this.LoadClient();
                    this.LoadPets();
                }
                else
                {
                    MessageBox.Show("Client not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message);
            }

        }

        private void btnAddPatient_Click(object sender, EventArgs e)
        {
            if (dgvClient.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a pet owner, you cannot add a new patient/pet if there's no selected pet owner", "Select Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult addConfirmation = MessageBox.Show("Are you sure you want to ADD new pet record?", "Add New Pet Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (addConfirmation == DialogResult.Yes)
                {
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
                MessageBox.Show("Please select a pet record first to update.", "Select Pet Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult updateConfirmation = MessageBox.Show("Are you sure you want to UPDATE the pet record?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (updateConfirmation == DialogResult.Yes)
                {
                    int petId = Convert.ToInt32(dgvPatient.SelectedRows[0].Cells["Id"].Value);
                    frmClientPatientModal frm = new frmClientPatientModal(petId);
                    frm.ShowDialog();
                    dgvPatient.RefreshEdit();
                }
            }
        }

        private void LoadClient()
        {
            ClientRepository repo = new ClientRepository();
            client = repo.GetClientInformation(new app.Core.Model.Client() { Id = this.selectedClientId });

            if (client == null)
            {
                MessageBox.Show("Client not found.");
                ClearClientFields();
                return;
            }

            if (txtFullname != null)
                txtFullname.Text = client.GetFullName();

            if (txtContacts != null)
                txtContacts.Text = client.GetAllContact();

            if (txtAddress != null)
                txtAddress.Text = client.GetFullAddress();
        }

        private void ClearClientFields()
        {
            if (txtFullname != null) txtFullname.Text = "";
            if (txtContacts != null) txtContacts.Text = "";
            if (txtAddress != null) txtAddress.Text = "";
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
                MessageBox.Show("Please select a pet record first to DELETE.", "Select Pet Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult deleteConfirmation = MessageBox.Show("Are you sure you want to DELETE the pet record?", "Delete Record", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (deleteConfirmation == DialogResult.OK)
                {
                    int petId = Convert.ToInt32(dgvPatient.SelectedRows[0].Cells["Id"].Value);

                    PetRepository pet = new PetRepository();
                    bool isDeleted = pet.Delete(petId);

                    if (isDeleted)
                    {
                        dgvPatient.Rows.Remove(dgvPatient.SelectedRows[0]);
                        dgvPatient.RefreshEdit();
                        MessageBox.Show("Record deleted successfully.", "Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete record.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnSearchPet_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtSearchPet.Text))
            {
                PetRepository repo = new PetRepository();
                dgvPatient.DataSource = repo.RetrieveSelectedPatient(txtSearchPet.Text);
                this.dgvPatient.Columns["Id"].Visible = false;
            }
            else
            {
                MessageBox.Show("The search field is empty, please provide.", "Empty field", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string name = txtSearch.Text;
            if (!string.IsNullOrEmpty(name))
            {
                name = char.ToUpper(name[0]) + name.Substring(1).ToLower();
                txtSearch.Text = name;
                txtSearch.SelectionStart = name.Length;
            }
        }

        private void txtSearchPet_TextChanged(object sender, EventArgs e)
        {
            string name = txtSearchPet.Text;
            if (!string.IsNullOrEmpty(name))
            {
                name = char.ToUpper(name[0]) + name.Substring(1).ToLower();
                txtSearchPet.Text = name;
                txtSearchPet.SelectionStart = name.Length;
            }
        }

        private void dgvPatient_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvPatient.Enabled = false;

                try
                {
                    int petId = Convert.ToInt32(dgvPatient.Rows[e.RowIndex].Cells["Id"].Value);
                    PetRepository repo = new PetRepository();
                    Pet selectedPet = repo.GetPetCompleteDetails(petId);

                    if (selectedPet != null)
                    {
                        using (frmClientPatientModal modal = new frmClientPatientModal())
                        {
                            modal.IsViewOnly = true;
                            modal.LoadDetails(selectedPet);
                            modal.ShowDialog();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Unable to find details for the selected pet.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                finally
                {
                    dgvPatient.Enabled = true;
                }
            }

        }
    }
    }

