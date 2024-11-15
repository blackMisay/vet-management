using Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace app.view.Client
{
    public partial class frmNewBreed : Form
    {
        public frmNewBreed()
        {
            InitializeComponent();
            UpgradeFile upgradeFile = new UpgradeFile();
            cmbSpecie.DataSource = upgradeFile.Populate("SELECT id, description FROM patient_species;");
            cmbSpecie.ValueMember = "KEY";
            cmbSpecie.DisplayMember = "VALUE";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Ask the user for confirmation before canceling
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to cancel your work?", "Confirm Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show("Work has been cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate input field
            if (string.IsNullOrEmpty(txtNewPetBreed.Text))
            {
                MessageBox.Show("Please enter a new pet breed.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Prepare the SQL query for checking if the breed already exists and is not deleted
                string checkQuery = "SELECT * FROM patient_breed WHERE description = @BreedName AND species_id = @SpeciesId;";

                // Create parameter dictionary
                Dictionary<string, string> parameters = new Dictionary<string, string>
                {
                    { "@BreedName", txtNewPetBreed.Text },
                    { "@SpeciesId", cmbSpecie.SelectedValue.ToString() }
                };

                // Load data to check for duplicates
                UpgradeFile upgradeFile = new UpgradeFile();
                DataTable resultTable = upgradeFile.Load(checkQuery, parameters);

                if (resultTable != null && resultTable.Rows.Count > 0)
                {
                    MessageBox.Show("This pet breed already exists. No new entry was added.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNewPetBreed.Focus();
                    return;
                }

                // Insert new pet breed
                string insertQuery = "INSERT INTO patient_breed (description, species_id) VALUES (@BreedName, @SpeciesId);";
                bool result = upgradeFile.ExecuteQuery(insertQuery, parameters);

                if (result)
                {
                    MessageBox.Show("New pet breed successfully added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Show modal form (remove redundant refresh)
                    frmClientPatientModal frm = new frmClientPatientModal();
                    frm.ShowDialog();
                    this.Close(); // Close current form after adding
                }
                else
                {
                    MessageBox.Show("Failed to add the new pet breed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
