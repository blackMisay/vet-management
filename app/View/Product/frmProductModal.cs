using app.core.model;
using app.core.repository;
using app.core.Repository;
using app.Core.Repository;
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
    public partial class frmProductModal : Form
    {
        int Id = 0;
        public frmProductModal()
        {
            InitializeComponent();
        }

        private void frmProductModal_Load(object sender, EventArgs e)
        {
            UpgradeFile upgradeFile = new UpgradeFile();
            cmbBrand.DataSource = upgradeFile.Populate("SELECT brandId, brandDesc from brands");
            cmbBrand.ValueMember = "Key";
            cmbBrand.DisplayMember = "Value";

            cmbCateg.DataSource = upgradeFile.Populate("SELECT categId, categDesc from prod_categ");
            cmbCateg.ValueMember = "Key";
            cmbCateg.DisplayMember = "Value";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveProduct();
            this.Dispose();
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

        public void SaveProduct()
        {
            app.core.model.Product product = new app.core.model.Product();

            product.Id = this.Id;
            product.BrandID = Id = Convert.ToInt32(cmbBrand.SelectedValue);
            product.Description = txtDesc.Text;
            product.CategID = Id = Convert.ToInt32(cmbCateg.SelectedValue);
            product.Quantity = Convert.ToInt32(txtQty.Text);
            product.UnitPrice = Convert.ToInt32(txtUnitPrice.Text);
            product.Amount = Convert.ToInt32(txtAmount.Text);

            ProductRepository productRepository = new ProductRepository();
            if (productRepository.SaveProduct(product))
            {
                MessageBox.Show("Save successfully");
            }
            else
            {
                MessageBox.Show("Unable to save record");
            }
        }
    }
}
