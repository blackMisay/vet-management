using app.core.repository;
using app.core.Repository;
using app.Core.Repository;
using app.view.Services;
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
    public partial class frmProducts : Form
    {
        public frmProducts()
        {
            InitializeComponent();
        }

        private void frmProducts_Load(object sender, EventArgs e)
        {
            UpgradeFile upgradeFile = new UpgradeFile();
            dgvProducts.DataSource = upgradeFile.Load("Select * FROM product");
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //TODO: Populate the datagridview based on the filtered name provided in Search box.
            if (!string.IsNullOrEmpty(txtSearch.Text) || !string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                ProductRepository productRepository = new ProductRepository();
                dgvProducts.DataSource = productRepository.SearchProduct(txtSearch.Text);
                this.dgvProducts.Columns["Id"].Visible = false;
            }
            else
            {
                MessageBox.Show("The search field is empty, please provide.", "Empty field", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
                    int id = Convert.ToInt32(dgvProducts.SelectedRows[0].Cells["Id"].Value);
                    frmProductModal Modal = new frmProductModal();
                    Modal.ShowDialog();
                    dgvProducts.RefreshEdit();
                }
            }


        }
    }
}
