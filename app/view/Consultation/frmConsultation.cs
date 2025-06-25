using app.core.repository;
using Core;
using System;
using System.Data;
using System.Windows.Forms;

namespace app.view.Consultation
{
    public partial class frmConsultation : Form
    {
        private int selectedId = 0;
        private readonly ConsultationRepository consultationRepo = new ConsultationRepository();

        public frmConsultation()
        {
            InitializeComponent();
            dgvConsultation.CellClick += dgvConsultation_CellClick;


        }

        private void frmConsultation_Load(object sender, EventArgs e)
        {
            dgvConsultation.CellClick += dgvConsultation_CellClick;
            LoadAllConsultationRecords();

            

            // Map your database fields to the DataGridView columns
            Id.DataPropertyName = "consultation_id";
            Owner.DataPropertyName = "client_fullname";
            Patient.DataPropertyName = "petname";
            Column4.DataPropertyName = "complaint";
            Column5.DataPropertyName = "findings";
            date.DataPropertyName = "consult_date";
        }

        private void btnNewConsultation_Click(object sender, EventArgs e)
        {
            //var result = MessageBox.Show(
            // "Do you want a patient to undergo consultation?\nClick Yes to proceed consultation.",
            //     "New Consultation",
            // MessageBoxButtons.YesNo,
            // MessageBoxIcon.Question);

            //if (result == DialogResult.Yes)
            //{
                using (var form = new frmConsultationModal())
                {
                    form.Owner = this; //  This line is critical
                    form.ShowDialog();
                }

                LoadAllConsultationRecords(); // Optional fallback refresh
            }

        //}

        private void dgvConsultation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Ignore clicks on the header row
                if (e.RowIndex == -1)
                    return;

                // Optional: check if the "Id" column exists first
                if (!dgvConsultation.Columns.Contains("id"))
                {
                    MessageBox.Show("The 'Id' column was not found in dgvConsultation.");
                    return;
                }

                // Safely access the row and cell
                var row = dgvConsultation.Rows[e.RowIndex];
                var cell = row.Cells["id"];

                if (cell?.Value != null && int.TryParse(cell.Value.ToString(), out int id))
                {
                    selectedId = id;
                }
                else
                {
                    selectedId = 0;
                }
            }
            catch { 
            }
        }

        private void btnRemoveConsultation_Click(object sender, EventArgs e)
        {
            if (selectedId == 0)
            {
                MessageBox.Show("Select a record first.", "Unable to delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show(
                "Do you want to remove an existing consultation?\nThis action cannot be undone.",
                "Remove Consultation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                bool deleted = consultationRepo.Delete(selectedId);
                if (deleted)
                {
                    MessageBox.Show("Consultation removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAllConsultationRecords();
                    selectedId = 0;
                }
                else
                {
                    MessageBox.Show("Failed to remove consultation.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEditConsultation_Click(object sender, EventArgs e)
        {
            if (selectedId == 0)
            {
                MessageBox.Show("Select a record first.", "Unable to update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show(
                "Do you want to update an existing consultation?\nClick Yes to proceed.",
                "Update Consultation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                using (var form = new frmConsultationModal(selectedId))
                {
                    form.ShowDialog();
                }
                LoadAllConsultationRecords();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();

            dgvConsultation.DataSource = string.IsNullOrWhiteSpace(searchText)
                ? consultationRepo.GetAllConsultations()
                : consultationRepo.GetSpecificConsultations(searchText);
        }

        public void LoadAllConsultationRecords()
        {
            dgvConsultation.DataSource = consultationRepo.GetAllConsultations();

            // 👇 Print column names to Output window
            foreach (DataGridViewColumn col in dgvConsultation.Columns)
            {
                Console.WriteLine("Column: " + col.Name);
            }
        }

        public app.Core.Model.Pet SelectedRecord { get; private set; }

        private void dgvConsultation_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore clicks on the header row
            if (e.RowIndex < 0)
                return;

            // Optional: check if the "Id" column exists first
            if (!dgvConsultation.Columns.Contains("id"))
            {
                MessageBox.Show("The 'Id' column was not found in dgvConsultation.");
                return;
            }

            // Safely access the row and cell
            var row = dgvConsultation.Rows[e.RowIndex];
            var cell = row.Cells["id"];

            if (cell?.Value != null && int.TryParse(cell.Value.ToString(), out int id))
            {
                selectedId = id;
            }
            else
            {
                selectedId = 0;
            }
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            // Create instance of the form you want to open
            frmConsultationHistory explorer = new frmConsultationHistory();

            // Show the form as a modal dialog (blocks parent until closed)
            explorer.ShowDialog();

            // Or show it as a non-modal window (independent)
            // explorer.Show();
        }

    }
}
