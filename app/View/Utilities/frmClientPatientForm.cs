using app.Core.Model;
using app.Core.Repository;
using app.view.Transaction;
using System;
using System.Windows.Forms;
using app.view.Client;

namespace app.view.Utilities
{
    public partial class frmClientPatientForm : Form
    {
        private Pet patient = new Pet();

        public frmClientPatientForm()
        {
            InitializeComponent();
        }

        public int GetPatientOwnerId()
        {
            return patient.Client.Id;
        }

        public int GetPatientId()
        {
            return patient.Id;
        }
        public string GetPatientName()
        {
            return patient.Name;
        }

        public string GetPatientOwnerFullname()
        {
            return patient.Client.GetClientFullName();
        }
        public string GetPatientOwnerAddress()
        {
            return patient.Client.GetFullAddress();
        }
        public string GetPatientOwnerContact()
        {
            return patient.Client.GetAllContact();
        }
        public Pet GetPatientDetails()
        {
            return this.patient;
        }
        public string GetPatientAge()
        {
            return patient.Age;
        }
        public Breed GetPatientBreed()
        {
            return patient.Breed;
        }
        public ColourPattern GetPatientColor()
        {
            return patient.ColourPattern;
        }
        public Gender GetPatientGender()
        {
            return patient.Gender;
        }
        public string GetPatientWeight()
        {
            return patient.Weight;
        }
        public string GetPatientBday()
        {
            return patient.BirthDate;
        }
        public Species GetPatientSpecie()
        {
            return patient.Specie;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ClientRepository c = new ClientRepository();
            c.LoadClientsNameAsList(dgvOwner, txtSearch.Text);
            c.LoadPetNameAsList(dgvPet, txtSearch.Text);
        }

        private void frmClientPatientForm_Load(object sender, EventArgs e)
        {
            ClientRepository c = new ClientRepository();
            c.LoadClientsNameAsList(dgvOwner, string.Empty);

        }

        int ownerId = 0;
        private void dgvOwner_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOwner.RowCount > 0)
            {
                int selectedRowIndex = dgvOwner.SelectedCells[0].RowIndex;
                this.ownerId = Convert.ToInt32(dgvOwner.Rows[selectedRowIndex].Cells[0].Value?.ToString());

            }
        }

        private void dgvOwner_DoubleClick(object sender, EventArgs e)
        {
            if (dgvOwner.CurrentRow == null || dgvOwner.CurrentRow.Index < 0)
                return;

            // Extract owner ID
            object selectedOwnerId = dgvOwner.CurrentRow.Cells["id"].Value;
            if (selectedOwnerId == null)
            {
                MessageBox.Show("Owner ID not found.");
                return;
            }

            this.ownerId = Convert.ToInt32(selectedOwnerId);

            // Extract owner name (assuming your grid has fname, mi, lname columns)
            string fname = dgvOwner.CurrentRow.Cells["Owner"].Value?.ToString() ?? "";

            // Set the full name to the text box
            txtOwner.Text = fname;

            // Load pets related to this owner
            PetRepository p = new PetRepository();
            p.GetAllPetsByOwner(dgvPet, this.ownerId.ToString());
        }

        int selectedRecord = 0;
        public void dgvPet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPet.RowCount > 0)
            {
                int selectedRowIndex = dgvPet.SelectedCells[0].RowIndex;
                this.selectedRecord = Convert.ToInt32(dgvPet.Rows[selectedRowIndex].Cells[0].Value?.ToString());
            }
        }

        private void dgvPet_DoubleClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to proceed with the selected patient?", "Confirm to select", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                GetDetails();

                if (this.patient != null && this.patient.Id != 0) // Ensure patient is valid
                {
                    this.DialogResult = DialogResult.OK; // Mark dialog as successful
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No valid patient details found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void GetDetails()
        {
            PetRepository pr = new PetRepository();

            this.patient = pr.GetPatientWithClientById(this.selectedRecord);

            if (this.patient == null)
            {
                MessageBox.Show("Failed to retrieve patient details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (dgvPet.RowCount > 0 && dgvPet.SelectedCells.Count > 0)
            {
                int selectedRowIndex = dgvPet.SelectedCells[0].RowIndex;
                int petId;

                if (int.TryParse(dgvPet.Rows[selectedRowIndex].Cells[0].Value?.ToString(), out petId))
                {
                    selectedRecord = petId;

                    // Confirm selection with user
                    var confirmResult = MessageBox.Show(
                        "Do you want to proceed with the selected patient?",
                        "Confirm to select",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (confirmResult == DialogResult.Yes)
                    {
                        GetDetails();

                        if (this.patient != null) // Make sure patient is set properly
                        {
                            this.DialogResult = DialogResult.OK; // Close with OK result
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No valid patient details found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Failed to get pet ID from selected row.");
                }
            }
            else
            {
                MessageBox.Show("Please select a pet first.");
            }
        }

        private void btnAddPet_Click(object sender, EventArgs e)
        {
            if (dgvOwner.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a pet owner, you cannot add a new patient/pet if there's no selected pet owner", "Select Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult addConfirmation = MessageBox.Show("Are you sure you want to ADD new pet record?", "Add New Pet Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (addConfirmation == DialogResult.Yes)
                {
                    int clientId = Convert.ToInt32(dgvOwner.SelectedRows[0].Cells["Id"].Value);
                    int petId = 0;
                    frmClientPatientModal frm = new frmClientPatientModal(petId, clientId);
                    frm.ShowDialog();
                    dgvPet.Refresh();
                    // Load pets related to this owner
                    PetRepository p = new PetRepository();
                    p.GetAllPetsByOwner(dgvPet, this.ownerId.ToString());

                }
            }
        }
    }
}
    

