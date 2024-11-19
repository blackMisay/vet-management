using Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace app.view.Product
{
    public partial class frmNewProductCategory : Form
    {
        public frmNewProductCategory()
        {
            InitializeComponent();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
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
            if (string.IsNullOrEmpty(txtNewCategory.Text))
            {
                MessageBox.Show("Please enter a new category.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Prepare the SQL query for checking if the product type already exists and is not marked as deleted
                string checkQuery = "SELECT * FROM product_category WHERE description = @CategoryName AND isDeleted = 0;";


                Dictionary<string, string> parameters = new Dictionary<string, string>
                {
                    { "@CategoryName", txtNewCategory.Text }
                    };


                UpgradeFile upgradeFile = new UpgradeFile();
                DataTable resultTable = upgradeFile.Load(checkQuery, parameters);

                if (resultTable != null && resultTable.Rows.Count > 0)
                {
                    // Notify the user that the product type already exists and is active
                    MessageBox.Show("This category already exists. No new entry was added.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    frmProductModal frmProductModal = new frmProductModal();
                    frmProductModal.ShowDialog();
                    return;
                }


                string insertQuery = "INSERT INTO product_category (Description) VALUES (@CategoryName);";

                bool result = upgradeFile.ExecuteQuery(insertQuery, parameters);

                if (result)
                {
                    MessageBox.Show("New category successfully added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    frmProductModal frm = new frmProductModal();
                    frm.ShowDialog();
                    frm.Refresh();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to add the new category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
