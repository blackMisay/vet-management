using app.core.repository;
using Core;
using System;
using System.Data;
using System.Windows.Forms;

namespace app.view.Product
{
    public partial class frmProducts : Form
    {
       
        public frmProducts()
        {
            InitializeComponent();
        }

        private void frmProducts_Load(object sender, EventArgs e)
        {
            UpgradeFile upgradeFile = new UpgradeFile();
            dgvProducts.DataSource = upgradeFile.Load("Select * FROM vwproduct WHERE isDeleted=0");

            ProductRepository productRepository = new ProductRepository();

        }

        private void btnSaveProduct_Click(object sender, EventArgs e)
        {
            frmProductModal frmProductModal = new frmProductModal();
            frmProductModal.ShowDialog();
            dgvProducts.Refresh();
        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0)
            {
                // Inform the user to select a record to update
                MessageBox.Show("Please select a product.", "Select Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                
                // Confirm with the user before updating the record
                DialogResult updateConfirmation = MessageBox.Show("Are you sure you want to UPDATE the Product?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (updateConfirmation == DialogResult.Yes)
                {
                    int productId = Convert.ToInt32(dgvProducts.SelectedRows[0].Cells["Id"].Value);
                    frmProductModal frmProductModal = new frmProductModal(productId);
                    frmProductModal.ShowDialog();
                }
            }
            UpgradeFile upgradeFile = new UpgradeFile();
            dgvProducts.DataSource = upgradeFile.Load("Select * FROM vwproduct WHERE isDeleted=0");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //TODO: Populate the datagridview based on the filtered name provided in Search box.
            if (!string.IsNullOrEmpty(txtSearch.Text) || !string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                ProductRepository productRepository = new ProductRepository();
                DataTable dt = productRepository.SearchProduct(txtSearch.Text);

                if (dt != null && dt.Rows.Count > 0)
                {
                    dgvProducts.DataSource = dt;
                    this.dgvProducts.Columns["Id"].Visible = false;
                }
                else
                {
                    MessageBox.Show("No results found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("The search field is empty, please provide.", "Empty field", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        
    }

        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0)
            {
                // Inform the user to select a record to update
                MessageBox.Show("Please select a product first to DELETE.", "Select Product Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Confirm with the user before deleting the record
                DialogResult deleteConfirmation = MessageBox.Show("Are you sure you want to DELETE the product record?", "Delete Record", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (deleteConfirmation == DialogResult.OK)
                {
                    // Get the ID of the selected record
                    int prodId = Convert.ToInt32(dgvProducts.SelectedRows[0].Cells["Id"].Value);

                    // Call a method to delete the record from the database
                    ProductRepository productRepository = new ProductRepository();
                    bool isDeleted = productRepository.DeleteProduct(prodId);

                    if (isDeleted)
                    {
                        // Remove the selected row from the DataGridView
                        dgvProducts.Rows.Remove(dgvProducts.SelectedRows[0]);
                        dgvProducts.Refresh();

                        MessageBox.Show("Record deleted successfully.", "Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete record.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }
    }
}
