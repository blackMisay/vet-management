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
        public event Action<string> BreedSelected;
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

        public frmBreed(DataTable breedData)
        {
            InitializeComponent();
            dgvBreed.DataSource = breedData; // Assign the DataTable to the DataGridView
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

        public void LoadBreedData()
        {
            frmClientPatientModal frm = new frmClientPatientModal();
            UpgradeFile upgradeFile = new UpgradeFile();

            // Define the query properly
            string query = "SELECT id, description FROM patient_breed WHERE species_id = @species_id ORDER BY description";

            // Define parameters correctly
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                { "@species_id", frm.cboSpecies.SelectedValue.ToString() }
            };

            // Pass both query and parameters to Load
            dgvBreed.DataSource = upgradeFile.Load(query, parameters);

        }

        private void dgvBreed_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Get the selected breed description
                string breedDescription = dgvBreed.Rows[e.RowIndex].Cells["description"].Value.ToString();

                // Invoke the event and pass the selected breed description
                BreedSelected?.Invoke(breedDescription);

                // Close the form
                this.Close();
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

