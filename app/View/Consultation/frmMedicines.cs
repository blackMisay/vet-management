using app.core.model;
using app.core.Repository;
using Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace app.view.Consultation
{
    public partial class frmMedicines : Form
    {
        private DataTable medicineTable;
        UpgradeFile upgradeFile = new UpgradeFile();
        private List<MedicationWithFrequency> selectedMedications = new List<MedicationWithFrequency>();
        public frmMedicines()
        {
            InitializeComponent();
        }

        private void frmMedicines_Load(object sender, EventArgs e)
        {
            LoadMedicines();
            InitializeControls();
            LoadDaysIntake();
            txtSearch.TextChanged += txtSearch_TextChanged;
            dgvMedicine.CellClick += dgvMedicine_CellClick;

        }

        private List<KeyValuePair<int, string>> medicines = new List<KeyValuePair<int, string>>();
        private void LoadMedicines()
        {
            string query = @" SELECT id,brand_name,generic_name,name,dosage,route,duration,price FROM pet_medicines ORDER BY name;";

            UpgradeFile db = new UpgradeFile();
            DataTable dt = db.Load(query);

            if (dt != null && dt.Rows.Count > 0)
            {
                medicineTable = dt;
                dgvMedicine.DataSource = medicineTable;

            }
            }


        public DataTable SearchMedicine(string searchValue)
        {
            string sql = @"
        SELECT * FROM pet_medicines 
        WHERE name LIKE @search 
           OR dosage LIKE @search 
           OR route LIKE @search 
           OR duration LIKE @search 
        ORDER BY name;";

            var parameters = new Dictionary<string, string>
    {
        { "@search", "%" + searchValue + "%" }
    };

            return upgradeFile.Load(sql, parameters);
        }

        public List<MedicationWithFrequency> SelectedMedicines { get; private set; } = new List<MedicationWithFrequency>();

        private void btnAddMed_Click(object sender, EventArgs e)
        {
            if (dgvMedicine.Rows.Count == 0 || dgvMedicine.CurrentRow == null)
            {
                MessageBox.Show("No medicines selected.", "Empty List", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string frequency = cmbFrequency.SelectedItem?.ToString();
            string medIntake = cmbDaysIntake.SelectedItem?.ToString();
            string notes = txtOther.Text.Trim();

            if (string.IsNullOrWhiteSpace(frequency))
            {
                MessageBox.Show("Please select a frequency.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = dgvMedicine.CurrentRow;

            int medId = Convert.ToInt32(row.Cells["id"].Value);
            string medDescription = row.Cells["name"].Value?.ToString() ?? "";

            if (medId == 0 || string.IsNullOrWhiteSpace(medDescription))
            {
                MessageBox.Show("Invalid medicine selected.", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedMedications = new MedicationWithFrequency
            {
                MedicineId = medId,
                MedicineDescription = medDescription,
                Frequency = frequency,
                DaysIntake = medIntake,
                Notes = notes
            };

            SelectedMedicines.Add(selectedMedications);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void InitializeControls()
        {

            var frequencyOptions = new List<string>
            {
                "N/A",
                "Once a day",
                "Twice a day",
                "3 times a day",
                "4 times a day",
                "Every other day",
                "Once a week",
                "Twice a week",
                "Every 6 hours",
                "Every 8 hours",
                "At bedtime",
                "Immediately",
                "As needed",
                "Until finished"
            };

            cmbFrequency.Items.Clear();
            cmbFrequency.Items.AddRange(frequencyOptions.ToArray());
            cmbFrequency.SelectedIndex = 0; // Optional: default to "N/A"
        }
        private void LoadDaysIntake()
        {
            cmbDaysIntake.Items.Clear();

            for (int i = 1; i <= 180; i++)
            {
                cmbDaysIntake.Items.Add(i + (i == 1 ? " day" : " days"));
            }

            cmbDaysIntake.SelectedIndex = 0; // Optional
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            dgvMedicine.DataSource = SearchMedicine(searchText);
        }

        frmConsultationModal frm = new frmConsultationModal();
        private void dgvMedicine_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvMedicine.Rows.Count == 0)
                return;

            var selectedRow = dgvMedicine.Rows[e.RowIndex];

            int medId = Convert.ToInt32(selectedRow.Cells["id"].Value);
            string medDescription = selectedRow.Cells["name"].Value?.ToString() ?? "";

            string frequency = cmbFrequency.SelectedItem?.ToString() ?? "";
            string daysIntake = cmbDaysIntake.SelectedItem?.ToString() ?? "";
            string otherNotes = txtOther.Text.Trim();

            // Add row to dgvMedication
            frm.dgvMedication.Rows.Add(
                medDescription,
                frequency,
                daysIntake,
                otherNotes
            );
        }
    }
}
