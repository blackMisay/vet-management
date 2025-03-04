using app.Core.Model;
using app.Core.Repository;
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

namespace app.view.Client
{

    public partial class frmBreed : Form
    {
        public event Action<int> BreedSelected;
        private string _speciesId;

        public frmBreed()
        {
            InitializeComponent();
        }

        public frmBreed(string speciesId)
        {
            InitializeComponent();
            _speciesId = speciesId;

            // Load breeds based on the selected species
            LoadBreedData();
        }

        private void frmBreed_Load(object sender, EventArgs e)
        {
            UpgradeFile upgradeFile = new UpgradeFile();
            dgvBreed.DataSource = upgradeFile.Load("SELECT * FROM patient_breed ORDER BY description;");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text) || !string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                dgvBreed.DataSource = RetrieveBreed(txtSearch.Text);
                this.dgvBreed.Columns["Id"].Visible = false;
            }
            else
            {
                MessageBox.Show("The search field is empty, please provide.", "Empty field", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        UpgradeFile file = new UpgradeFile();
        public DataTable RetrieveBreed(string searchValue)
        {
            string query = "SELECT *  FROM `patient_breed` WHERE `description` LIKE @searchValue;";
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"@searchValue", "%" + searchValue + "%" }
            };
            file = new UpgradeFile();
            return file.Load(query, parameters);
        }

        private void LoadBreedData()
        {
            UpgradeFile upgradeFile = new UpgradeFile();
            string query = $"SELECT * FROM patient_breed WHERE species_id = '{_speciesId}' ORDER BY description;";
            dgvBreed.DataSource = upgradeFile.Load(query);
        }

        private void dgvBreed_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a valid row is selected
            {
                DataGridViewRow selectedRow = dgvBreed.Rows[e.RowIndex];

                // Ensure the value is not null and convert it safely to string
                string breedDescription = selectedRow.Cells["description"].Value?.ToString() ?? string.Empty;

                BreedSelected?.Invoke(breedDescription); // Raise event with description
                this.Close(); // Close selection form

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmClientPatientModal frm = new frmClientPatientModal();
            frmNewBreed frmbreed = new frmNewBreed();
            {
                if (frmbreed.ShowDialog() == DialogResult.OK)
                {
                    // Refresh the combobox to include the new color
                    frm.PopulateCmb();
                }
            }
        }
    }
}

