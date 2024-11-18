using app.core.repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app.view.Immunization
{
    public partial class frmImmunization : Form
    {
        public frmImmunization()
        {
            InitializeComponent();
        }

        private void frmImmunization_Load(object sender, EventArgs e)
        {
            LoadPatientVaccinationRecords();
        }

        void LoadPatientVaccinationRecords()
        {
            PetVaccinationRepository vr = new PetVaccinationRepository();
            vr.LoadVaccination(this.dgvImmunization);
        }

        void SearchPatientVaccinationRecords()
        {
            PetVaccinationRepository vr = new PetVaccinationRepository();
            vr.SearchVaccination(this.dgvImmunization, txtSearch.Text);
        }

        int selectedId = 0;
        private void dgvImmunication_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvImmunization.RowCount > 0)
            {
                int selectedRowIndex = dgvImmunization.SelectedCells[0].RowIndex;
                this.selectedId = Convert.ToInt32(dgvImmunization.Rows[selectedRowIndex].Cells[0].Value?.ToString());
            }
        }

        private void btnImmunization_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to create new vaccination for a patient?",
                                "Confirm to proceed",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                frmImmunizationModal im = new frmImmunizationModal();
                im.ShowDialog();
                LoadPatientVaccinationRecords();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedId > 0)
            {
                if (MessageBox.Show("Do you want to update an existing vaccination of a patient?",
                    "Confirm to update",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    frmImmunizationModal im = new frmImmunizationModal(selectedId);
                    im.ShowDialog();
                    LoadPatientVaccinationRecords();
                }
            }
            else
            {
                MessageBox.Show("Please select a record to delete.",
                                "No record selected",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (selectedId > 0)
            {
                if (MessageBox.Show("Do you want to delete the selected patient vaccination?",
                                "Confirm to remove",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    PetVaccinationRepository pv = new PetVaccinationRepository();
                    pv.Delete(selectedId);
                    LoadPatientVaccinationRecords();
                }
            }
            else
            {
                MessageBox.Show("Please select a record to delete.",
                                "No record selected",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchPatientVaccinationRecords();

            if (dgvImmunization.RowCount == 0)
            {
                MessageBox.Show("Unable to found the provided Pet Name.\nKindly check if the pet name provided is correct.",
                                "No record found",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                LoadPatientVaccinationRecords() ;
            }
            if (txtSearch.Text == string.Empty || string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                LoadPatientVaccinationRecords();
            }
        }
    }
}
