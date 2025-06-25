using app.core.model;
using app.core.repository;
using Core;
using System;
using System.Data;
using System.Windows.Forms;

namespace app.view.Product
{
    public partial class frmProductModal : Form
    {
        private int productId = 0; // Renamed from Id for clarity
        private ProductRepository repo = new ProductRepository();
        app.core.model.Product product;

        public frmProductModal()
        {
            InitializeComponent();
            this.Load += frmProductModal_Load;
            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;
            btnAddCateg.Click += btnAddCateg_Click;
            btnAddBrand.Click += btnAddBrand_Click;
            txtDesc.TextChanged += txtDesc_TextChanged;
        }

        public frmProductModal(int productId) : this()
        {
            this.productId = productId;
            LoadProductDetails();
            btnSave.Text = "Update";
            label1.Text = "Update Product";
        }

        private void frmProductModal_Load(object sender, EventArgs e)
        {
            PopulateComboBoxes();
        }

    private void PopulateComboBoxes()
        {
           UpgradeFile file = new UpgradeFile();

            cmbBrand.DataSource = file.Populate("SELECT  brandId, brandDesc FROM product_brand WHERE isDeleted = 0 ORDER BY brandDesc ");
            cmbBrand.ValueMember = "KEY";
            cmbBrand.DisplayMember = "VALUE";

            cmbCateg.DataSource = file.Populate("SELECT  id, name FROM categories ORDER BY name");
            cmbCateg.ValueMember = "KEY";
            cmbCateg.DisplayMember = "VALUE";
        }

        private void LoadProductDetails()
        {
            DataRow productRow = repo.GetProductDataRow(productId);
            if (productRow != null)
            {
                core.model.Product product = repo.DataRowToProduct(productRow);
                LoadDetails(product);
            }
        }

        private void LoadDetails(app.core.model.Product product)
        {
            cmbBrand.SelectedValue = product.Brand;   // Assuming BrandID is int or string
            txtDesc.Text = product.Description ?? string.Empty;
            cmbCateg.SelectedValue = product.Category; // Assuming CategoryID is int or string

            // Set other controls if you have them (SKU, Price, Stock, etc.)
            txtSKU.Text = product.SKU;
            txtPrice.Text = product.Price.ToString("0.00");
            txtStock.Text = product.Stock.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveProduct();
        }

        private void SaveProduct()
        {
            // Validate inputs (add more validation as needed)
            if (string.IsNullOrWhiteSpace(txtSKU.Text))
            {
                MessageBox.Show("SKU is required.");
                return;
            }

            if (!double.TryParse(txtPrice.Text, out double price))
            {
                MessageBox.Show("Invalid price.");
                return;
            }

            if (!int.TryParse(txtStock.Text, out int stock))
            {
                MessageBox.Show("Invalid stock.");
                return;
            }

            app.core.model.Product product = new core.model.Product
            {
                Id = productId,
                SKU = txtSKU.Text.Trim(),
                Brand = new Brand {Id = Convert.ToInt32(cmbBrand.SelectedValue) },
                Description = txtDesc.Text.Trim(),
                Category = new Category {Id= Convert.ToInt32(cmbCateg.SelectedValue) },
                Price = price,
                Stock = stock
                // Add SupplierID and others if you have them
            };

            bool saved = repo.SaveProduct(product);
            if (saved)
            {
                MessageBox.Show("Product saved successfully.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to save product.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Are you sure you want to cancel your work?", "Confirm Cancellation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnAddCateg_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
            frmNewProductCategory frm = new frmNewProductCategory();
            frm.ShowDialog();
            this.PopulateCategory();
        }

        private void PopulateCategory()
        {
            ProductRepository categoryRepository = new ProductRepository();
            {
                categoryRepository.Populate(cmbCateg);

                cmbCateg.ValueMember = categoryRepository.KEY;
                cmbCateg.DisplayMember = categoryRepository.VALUE;
                if (cmbCateg.Items.Count > 0)
                    cmbCateg.SelectedIndex = 0;
            }
        }

        private void btnAddBrand_Click(object sender, EventArgs e)
        {
            var brandForm = new frmNewProductBrand();
            if (brandForm.ShowDialog() == DialogResult.OK)
            {
                PopulateComboBoxes(); // Reload brands after adding new one
            }
        }

        private void txtDesc_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDesc.Text))
            {
                var text = txtDesc.Text;
                var corrected = char.ToUpper(text[0]) + text.Substring(1).ToLower();

                if (corrected != text)
                {
                    int cursorPos = txtDesc.SelectionStart;
                    txtDesc.Text = corrected;
                    txtDesc.SelectionStart = cursorPos;
                }
            }
        }
    }
}
