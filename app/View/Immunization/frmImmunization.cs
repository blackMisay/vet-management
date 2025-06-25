using app.core.repository;
using System;
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
            vr.LoadVaccinations(this.dgvImmunization);
        }

        void SearchPatientVaccinationRecords()
        {
            PetVaccinationRepository vr = new PetVaccinationRepository();
            vr.SearchVaccination(this.dgvImmunization, txtSearch.Text);
        }

        int selectedId = 0;
        private void dgvImmunication_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Step 1: Prevent actions on header row
                if (e.RowIndex == -1 || e.ColumnIndex < 0)
                    return;

                // Step 2: Ensure column "Id" exists
                if (!dgvImmunization.Columns.Contains("id"))
                {
                    MessageBox.Show("Column 'Id' not found in the grid.");
                    return;
                }

                // Step 3: Get the clicked row
                var row = dgvImmunization.Rows[e.RowIndex];
                if (row == null)
                    return;

                // Step 4: Get the "Id" cell value
                var cell = row.Cells["id"];
                if (cell?.Value == null)
                {
                    MessageBox.Show("No ID found in selected row.");
                    return;
                }

                // Step 5: Try parsing the ID
                if (int.TryParse(cell.Value.ToString(), out int immunizationId))
                {
                    selectedId = immunizationId;
                }
                else
                {
                    MessageBox.Show("Invalid ID format.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnVaccination_Click(object sender, EventArgs e)
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
    }
}
