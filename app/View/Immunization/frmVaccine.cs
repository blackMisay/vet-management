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
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace app.view.Immunization
{
    public partial class frmVaccine : Form
    {
        public string SelectedDescription { get; private set; }
        public string SelectedDosage { get; private set; }
        public string SelectedInterval { get; private set; }
        public int SelectedVaccineId { get; set; } = 0;
        public string SelectedDose { get; private set; }


        public frmVaccine()
        {
            InitializeComponent();
        }

        public void LoadVaccineAsList(DataGridView dgv, string search)
        {
            UpgradeFile ug = new UpgradeFile();
            if (string.IsNullOrEmpty(search) || string.IsNullOrWhiteSpace(search))
            {
                dgv.DataSource = ug.Load("SELECT id,`description`, vaccine_code, recommended_dosage,typical_dose price FROM consultation_medication;");
            }
            else
            {
                dgv.DataSource = ug.Load("SELECT id,`description`,vaccine_code, recommended_dosage,typical_dose price FROM  consultation_medication WHERE description LIKE @search OR vaccine_code LIKE @search ;", new Dictionary<string, string> { { "@search", search } });
            }

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadVaccineAsList(dgvVaccine, txtSearch.Text);
        }

        private void frmVaccine_Load(object sender, EventArgs e)
        {
            UpgradeFile ug = new UpgradeFile();
            dgvVaccine.DataSource = ug.Load("SELECT id, description,vaccine_code, recommended_dosage,typical_dose, price FROM consultation_medication;");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmImmunizationModal frm = new frmImmunizationModal();
            string desc = frm.txtVaccine.Text.Trim();
            string dose = frm.txtDosage.Text.Trim();
            string dosage = frm.txtDosage.Text.Trim();
            //string interval = frm.txtInterval.Text.Trim();
            //string dosage = frm.txtDosage.Text.Trim();

            this.Dispose();


        }

        private void dgvVaccine_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0)
            //{
            //    DataGridViewRow row = dgvVaccine.Rows[e.RowIndex];

            //    SelectedVaccineId = Convert.ToInt32(row.Cells["id"].Value); // <-- Add this
            //    SelectedDescription = row.Cells["description"].Value?.ToString() ?? "";
            //    SelectedDosage = row.Cells["recommended_dosage"].Value?.ToString() ?? "";
            //    SelectedInterval = row.Cells["recommended_interval"].Value?.ToString() ?? "";

            //    this.DialogResult = DialogResult.OK;
            //    this.Close();
            //}
        }

        private void dgvVaccine_Click(object sender, EventArgs e)
        {
            var mouseEvent = e as MouseEventArgs;
            if (mouseEvent != null)
            {
                DataGridView.HitTestInfo hit = dgvVaccine.HitTest(mouseEvent.X, mouseEvent.Y);
                if (hit.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvVaccine.Rows[hit.RowIndex];

                    SelectedVaccineId = Convert.ToInt32(row.Cells["id"].Value); // <-- Add this
                    SelectedDescription = row.Cells["description"].Value?.ToString() ?? "";
                    SelectedDosage = row.Cells["recommended_dosage"].Value?.ToString() ?? "";
                    SelectedDose = row.Cells["typical_dose"].Value?.ToString() ?? "";
                    //SelectedInterval = row.Cells["recommended_interval"].Value?.ToString() ?? "";

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
    }
}
