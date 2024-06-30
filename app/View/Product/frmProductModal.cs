using app.core.model;
using app.core.repository;
using app.Core.Repository;
using System;
using Core;
using System.Windows.Forms;

namespace app.view.Product
{
    public partial class frmProductModal : Form
    {
        private int Id;

        public frmProductModal()
        {
            InitializeComponent();
            this.Load += frmProductModal_Load;
        }
        public frmProductModal(int productId) : this()
        {
            this.Id = productId;
            LoadProductDetails();
            btnSave.Text = "Update";
            label1.Text = "Update Product";
        }

        private void frmProductModal_Load(object sender, EventArgs e)
        {
            PopulateCmb();
        }

        private void PopulateCmb()
        {
            UpgradeFile upgradeFile = new UpgradeFile();
            cmbBrand.DataSource = upgradeFile.Populate("SELECT brandID, brandDesc from brands");
            cmbBrand.ValueMember = "KEY"; // Correct column name from query
            cmbBrand.DisplayMember = "VALUE"; // Correct column name from query

            cmbCateg.DataSource = upgradeFile.Populate("SELECT categID, categDesc from prod_categ");
            cmbCateg.ValueMember = "KEY"; // Correct column name from query
            cmbCateg.DisplayMember = "VALUE"; // Correct column name from query
        }

        private void LoadProductDetails()
        {
            ProductRepository productRepository = new ProductRepository();
            var product = productRepository.GetProduct(new app.core.model.Product() { Id = this.Id });
            if (product != null)
            {
                LoadDetails(product);
            }
        }

        private void LoadDetails(app.core.model.Product product)
        {
            cmbBrand.SelectedValue = product.BrandID.Id;
            txtDesc.Text = product.Description;
            cmbCateg.SelectedValue = product.CategID.Id;
            txtQty.Text = product.Quantity.ToString();
            txtUnitPrice.Text = product.UnitPrice.ToString();
            txtAmount.Text = product.Amount.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveProduct();
            UpgradeFile upgradeFile = new UpgradeFile();
            frmProducts frmProducts = new frmProducts();        
            frmProducts.dgvProducts.DataSource = upgradeFile.Load("Select * FROM vwproduct WHERE isDeleted=0");
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
            app.core.model.Product product = new app.core.model.Product
            {
                Id = this.Id,
                BrandID = new Brand() { Id = Convert.ToInt32(cmbBrand.SelectedValue) },
                Description = txtDesc.Text,
                CategID = new ProductCategory() { Id = Convert.ToInt32(cmbCateg.SelectedValue) },
                Quantity = Convert.ToInt32(txtQty.Text),
                UnitPrice = Convert.ToDouble(txtUnitPrice.Text),
                Amount = Convert.ToDouble(txtAmount.Text)
            };

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
