using app.Core.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app.view.Utilities
{
    public partial class frmClientPatientForm : Form
    {
        private int PatientId = 0;
        private string PatientName = "";
        public frmClientPatientForm()
        {
            InitializeComponent();
        }

        public int GetPatientId()
        {
            return PatientId;
        }
        public string GetPatientName()
        {
            return PatientName;
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

        int petId = 0;
        private void dgvPet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPet.RowCount > 0)
            {
                int selectedRowIndex = dgvPet.SelectedCells[0].RowIndex;
                this.PatientId = Convert.ToInt32(dgvPet.Rows[selectedRowIndex].Cells[0].Value?.ToString());
                this.PatientName = dgvPet.Rows[selectedRowIndex].Cells[1].Value?.ToString();
            }
        }

        private void dgvPet_DoubleClick(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("Do you want to proceed with the selected patient?","Confirm to select",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
