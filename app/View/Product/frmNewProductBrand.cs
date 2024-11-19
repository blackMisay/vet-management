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

namespace app.view.Product
{
    public partial class frmNewProductBrand : Form
    {
        public frmNewProductBrand()
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
            if (string.IsNullOrEmpty(txtNewBrand.Text))
            {
                MessageBox.Show("Please enter a new product brand.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Prepare the SQL query for checking if the product type already exists and is not marked as deleted
                string checkQuery = "SELECT * FROM product_brands WHERE Description = @Brand AND isDeleted = 0;";


                Dictionary<string, string> parameters = new Dictionary<string, string>
                {
                    { "@Brand", txtNewBrand.Text }
                    };


                UpgradeFile upgradeFile = new UpgradeFile();
                DataTable resultTable = upgradeFile.Load(checkQuery, parameters);

                if (resultTable != null && resultTable.Rows.Count > 0)
                {
                    // Notify the user that the product type already exists and is active
                    MessageBox.Show("This product brand already exists. No new entry was added.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    frmProductModal frmProductModal = new frmProductModal();
                    frmProductModal.ShowDialog();
                    return;
                }


                string insertQuery = "INSERT INTO product_types (Description) VALUES (@Brand);";

                bool result = upgradeFile.ExecuteQuery(insertQuery, parameters);

                if (result)
                {
                    MessageBox.Show("New product type successfully added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    frmProductModal frm = new frmProductModal();
                    frm.ShowDialog();
                    frm.Refresh();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to add the new product type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
