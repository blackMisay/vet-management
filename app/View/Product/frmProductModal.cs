using app.core.model;
using app.core.repository;
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
            cmbBrand.DataSource = upgradeFile.Populate("SELECT brandId, brandDesc from product_brands");
            cmbBrand.ValueMember = "KEY"; // Correct column name from query
            cmbBrand.DisplayMember = "VALUE"; // Correct column name from query

            cmbCateg.DataSource = upgradeFile.Populate("SELECT id, description from product_category");
            cmbCateg.ValueMember = "KEY"; // Correct column name from query
            cmbCateg.DisplayMember = "VALUE"; // Correct column name from query

            cmbTypes.DataSource = upgradeFile.Populate("SELECT id, description from product_types");
            cmbTypes.ValueMember = "KEY"; // Correct column name from query
            cmbTypes.DisplayMember = "VALUE"; // Correct column name from query
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
            cmbTypes.SelectedValue = product.TypeID.Id;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveProduct();
            UpgradeFile upgradeFile = new UpgradeFile();
            frmProducts frmProducts = new frmProducts();        
            frmProducts.dgvProducts.RefreshEdit();
            
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

          

            // Check if the required fields are empty or invalid
            if (string.IsNullOrEmpty(txtDesc.Text))
            {
                MessageBox.Show("Please enter a description before saving.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDesc.Focus(); // Set focus on the description textbox
                return; // Prevent saving if description is empty
            }

            if (cmbBrand.SelectedValue == null || Convert.ToInt32(cmbBrand.SelectedValue) == 0)
            {
                MessageBox.Show("Please select a brand.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbBrand.Focus(); // Set focus on the brand combo box
                return; // Prevent saving if no brand is selected
            }

            if (cmbCateg.SelectedValue == null || Convert.ToInt32(cmbCateg.SelectedValue) == 0)
            {
                MessageBox.Show("Please select a category.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCateg.Focus(); // Set focus on the category combo box
                return; // Prevent saving if no category is selected
            }

            if (cmbTypes.SelectedValue == null || Convert.ToInt32(cmbTypes.SelectedValue) == 0)
            {
                MessageBox.Show("Please select a type.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTypes.Focus(); // Set focus on the type combo box
                return; // Prevent saving if no type is selected
            }

            // Create the product object if all validations pass

            app.core.model.Product product = new app.core.model.Product
            {
                Id = this.Id,
                BrandID = new Brand() { Id = Convert.ToInt32(cmbBrand.SelectedValue) },
                Description = txtDesc.Text,
                CategID = new ProductCategory() { Id = Convert.ToInt32(cmbCateg.SelectedValue) },
                TypeID = new core.Types() { Id = Convert.ToInt32(cmbTypes.SelectedValue)},

            };

            // Save the product
            ProductRepository productRepository = new ProductRepository();
            if (productRepository.SaveProduct(product))
            {
                MessageBox.Show("Save successfully");
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Unable to save record");
            }

        }



        private void btnAddNewType_Click(object sender, EventArgs e)
        {
            frmNewProductType frmNew = new frmNewProductType();
            frmNew.ShowDialog();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnAddNewCateg_Click(object sender, EventArgs e)
        {
            frmNewProductCategory category = new frmNewProductCategory();
            category.ShowDialog();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
