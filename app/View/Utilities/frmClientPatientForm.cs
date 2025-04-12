using app.Core.Model;
using app.Core.Repository;
using app.view.Transaction;
using System;
using System.Windows.Forms;

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

        public Pet GetPatientDetails()
        {
            return this.patient;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ClientRepository c = new ClientRepository();
            c.LoadClientsNameAsList(dgvOwner, txtSearch.Text);
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

                if (this.patient != null) // Ensure patient is set
                {

                    this.DialogResult = DialogResult.OK; // ✅ Mark dialog as successful
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

            this.patient = pr.GetPetCompleteDetails(this.selectedRecord);

            if (this.patient == null)
            {
                MessageBox.Show("Failed to retrieve patient details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

       
      
    }
}
