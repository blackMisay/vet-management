using app.core.model;
using app.core.repository;
using System;
using Core;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            cmbBrand.SelectedValue = product.BrandID; // Assuming BrandID is a primitive type like int or string
            txtDesc.Text = product.Description ?? string.Empty; // Prevent null reference exception
            cmbCateg.SelectedValue = product.CategID; // Assuming CategID is a primitive type like int or string
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

            // Create the product object if all validations pass

            app.core.model.Product product = new app.core.model.Product
            {
                Id = this.Id,
                BrandID = new Brand() { Id = Convert.ToInt32(cmbBrand.SelectedValue) },
                Description = txtDesc.Text,
                CategID = new ProductCategory() { Id = Convert.ToInt32(cmbCateg.SelectedValue) },

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

        private void btnAddCateg_Click(object sender, EventArgs e)
        {
            frmNewProductCategory category = new frmNewProductCategory();
            category.ShowDialog();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnAddBrand_Click(object sender, EventArgs e)
        {
            frmNewProductBrand brand = new frmNewProductBrand();
            brand.ShowDialog();
            this.DialogResult= DialogResult.OK;
            this.Close();
        }

        private void txtDesc_TextChanged(object sender, EventArgs e)
        {
            if (txtDesc.Text.Length > 0)
            {
                txtDesc.Text = char.ToUpper(txtDesc.Text[0]) + txtDesc.Text.Substring(1).ToLower();
            }
            txtDesc.SelectionStart = txtDesc.Text.Length;  // Keep the cursor at the end of the text
        }
    }
}
