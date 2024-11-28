using Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace app.view.Client
{
    public partial class frmNewPetColor : Form
    {
        public frmNewPetColor()
        {
            InitializeComponent();
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
            if (string.IsNullOrEmpty(txtNewPetColor.Text))
            {
                MessageBox.Show("Please enter a new pet color.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Prepare the SQL query for checking if the product type already exists and is not marked as deleted
                string checkQuery = "SELECT * FROM patient_colour_pattern WHERE description = @ColorName;";


                Dictionary<string, string> parameters = new Dictionary<string, string>
                {
                    { "@ColorName", txtNewPetColor.Text }
                    };


                UpgradeFile upgradeFile = new UpgradeFile();
                DataTable resultTable = upgradeFile.Load(checkQuery, parameters);

                if (resultTable != null && resultTable.Rows.Count > 0)
                {
                    // Notify the user that the product type already exists and is active
                    MessageBox.Show("This pet color already exists. No new entry was added.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Focus();
                    txtNewPetColor.Focus();
                    return;
                }


                string insertQuery = "INSERT INTO patient_colour_pattern (Description) VALUES (@ColorName);";

                bool result = upgradeFile.ExecuteQuery(insertQuery, parameters);

                if (result)
                {
                    MessageBox.Show("New pet color successfully added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();

            
                }
                else
                {
                    MessageBox.Show("Failed to add the new pet color.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
