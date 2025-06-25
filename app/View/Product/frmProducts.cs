using app.core.repository;
using app.Properties;
using Core;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace app.view.Product
{
    public partial class frmProducts : Form
    {
        private int currentRowIndex = 0;
        PrintPreviewDialog previewDialog1 = new PrintPreviewDialog();

        public frmProducts()
        {
            InitializeComponent();
            previewDialog1.Document = printDocument1;
            
        }

        private void frmProducts_Load(object sender, EventArgs e)
        {
            LoadCategoryComboBox();
            LoadAllProducts();

            cboCategory.SelectedIndexChanged += FilterProducts;
            
        }

        private void LoadCategoryComboBox()
        {
            UpgradeFile upgradeFile = new UpgradeFile();
            DataTable dt = upgradeFile.Load("SELECT id, name FROM categories ORDER BY name;");

            var categories = new List<KeyValuePair<int, string>>
            {
                new KeyValuePair<int, string>(-1, "All Categories")
            };

            foreach (DataRow row in dt.Rows)
            {
                categories.Add(new KeyValuePair<int, string>((int)row["id"], row["name"].ToString()));
            }

            cboCategory.DataSource = new BindingSource(categories, null);
            cboCategory.DisplayMember = "Value";
            cboCategory.ValueMember = "Key";
        }

        private const string LoadProductsQuery = @"
    SELECT 
        p.id, 
        p.sku, 
        pb.brandDesc AS brand, 
        p.description, 
        c.name AS category, 
        s.name AS supplier, 
        p.price, 
        p.stock
    FROM products p
    LEFT JOIN categories c ON p.category_id = c.id
    LEFT JOIN suppliers s ON p.supplier_id = s.id
    LEFT JOIN product_brand pb ON p.brand_id = pb.brandId
    ORDER BY c.name, pb.brandDesc, p.description;
";

        private void LoadAllProducts()
        {
            var upgradeFile = new UpgradeFile();
            DataTable dt = upgradeFile.Load(LoadProductsQuery);

            dgvProducts.DataSource = dt;
            FormatDataGridView();
        }

        private void FormatDataGridView()
        {

            if (dgvProducts.Columns["id"] != null)
                dgvProducts.Columns["id"].Visible = false;

            if (dgvProducts.Columns["sku"] != null)
                dgvProducts.Columns["sku"].Visible = false;

            if (dgvProducts.Columns["supplier"] != null)
                dgvProducts.Columns["supplier"].Visible = false;


            if (dgvProducts.Columns["category"] != null)
                dgvProducts.Columns["category"].Visible = false;

            if (dgvProducts.Columns["brand"] != null)
                dgvProducts.Columns["brand"].HeaderText = "Brand";

            if (dgvProducts.Columns["description"] != null)
                dgvProducts.Columns["description"].HeaderText = "Product Description";

            if (dgvProducts.Columns["price"] != null)
            {
                dgvProducts.Columns["price"].HeaderText = "Price";
                dgvProducts.Columns["price"].DefaultCellStyle.Format = "C2"; // currency format
                dgvProducts.Columns["price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; // right align
            }

            if (dgvProducts.Columns["stock"] != null)
            {
                dgvProducts.Columns["stock"].Visible = false;
                dgvProducts.Columns["stock"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; // right align
            }
        }


        private void FilterProducts(object sender, EventArgs e)
        {
            var selectedItem = cboCategory.SelectedItem;

            // Ensure the selected item is valid
            if (selectedItem == null || !(selectedItem is KeyValuePair<int, string> selectedCategory))
                return;

            int selectedCategoryId = selectedCategory.Key;

            UpgradeFile upgradeFile = new UpgradeFile();

            // Base SQL query with parameter placeholder
            string sql = @"
        SELECT 
            p.id, 
            p.sku, 
            pb.brandDesc AS brand, 
            p.description, 
            c.name AS category, 
            s.name AS supplier, 
            p.price, 
            p.stock
        FROM products p
        LEFT JOIN categories c ON p.category_id = c.id
        LEFT JOIN suppliers s ON p.supplier_id = s.id
        LEFT JOIN product_brand pb ON p.brand_id = pb.brandId
        WHERE (@CategoryId = -1 OR p.category_id = @CategoryId)
        ORDER BY c.name, pb.brandDesc, p.description;
    ";

            // Add parameter for category
            Dictionary<string, object> parameters = new Dictionary<string, object>
    {
        { "@CategoryId", selectedCategoryId }
    };

            // Load data with parameterized query
            DataTable dt = upgradeFile.LoadDataTable(sql, parameters);
            dgvProducts.DataSource = dt;
            FormatDataGridView();
        }


        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product to edit.", "Select Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult confirm = MessageBox.Show("Are you sure you want to edit this product?", "Confirm Edit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                int productId = Convert.ToInt32(dgvProducts.SelectedRows[0].Cells["id"].Value);
                frmProductModal frmProductModal = new frmProductModal(productId);
                frmProductModal.ShowDialog();
                LoadAllProducts();
            }
        }

        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product to delete.", "Select Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult confirm = MessageBox.Show("Are you sure you want to delete this product?", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (confirm == DialogResult.OK)
            {
                int productId = Convert.ToInt32(dgvProducts.SelectedRows[0].Cells["id"].Value);
                ProductRepository productRepository = new ProductRepository();
                bool isDeleted = productRepository.DeleteProduct(productId);
                if (isDeleted)
                {
                    LoadAllProducts();
                    MessageBox.Show("Product deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to delete product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Printing methods remain unchanged, but you can adjust column headers accordingly

        private void btnReport_Click_1(object sender, EventArgs e)
        {
            DialogResult preresult = previewDialog1.ShowDialog();
            if (preresult == DialogResult.OK)
            {
                PrintDialog print = new PrintDialog();
                print.Document = printDocument1;

                DialogResult result = print.ShowDialog();
                if (result == DialogResult.OK)
                {
                    printDocument1.Print();
                }
            }
        }

        private int printRowIndex = 0;
        private decimal totalInventoryValue = 0;

        private void printDocument1_PrintPage_1(object sender, PrintPageEventArgs e)
        {

            int leftMargin = e.MarginBounds.Left;
            int topMargin = e.MarginBounds.Top;
            int rightMargin = e.MarginBounds.Right;
            int lineHeight = (int)Font.GetHeight(e.Graphics) + 5;
            int yPosition = topMargin;
            int rowPadding = 4;
            int reorderThreshold = 10;

            Font companyFont = new Font("Arial", 16, FontStyle.Bold);
            Font titleFont = new Font("Arial", 14, FontStyle.Bold);
            Font headerFont = new Font("Arial", 10, FontStyle.Bold);
            Font cellFont = new Font("Arial", 10);
            Font reorderFont = new Font("Arial", 10, FontStyle.Bold);

            Brush blackBrush = Brushes.Black;
            Brush redBrush = Brushes.Red;
            Pen gridPen = Pens.Gray;

            int[] columnWidths = { 100, 200, 80, 100 }; // brand, description, price, stock
            string[] columnTitles = { "Brand", "Description", "Price", "Stock" };

            // --- Draw Logo ---
            Image logo = Resources.logo2; // Make sure you have a Resources.Logo in your project
            int logoSize = 60;
            if (logo != null)
            {
                e.Graphics.DrawImage(logo, leftMargin, yPosition, logoSize, logoSize);
            }

            // --- Draw Company Name next to logo ---
            e.Graphics.DrawString("SAHAGUN VETERINARY CLINIC", companyFont, blackBrush, leftMargin + logoSize + 10, yPosition + 10);

            yPosition += logoSize + 10;

            // --- Draw Report Title ---
            e.Graphics.DrawString("Product Inventory Report", titleFont, blackBrush, leftMargin, yPosition);
            yPosition += titleFont.Height + 5;

            // --- Date ---
            e.Graphics.DrawString("Date: " + DateTime.Now.ToString("g"), cellFont, blackBrush, leftMargin, yPosition);
            yPosition += cellFont.Height + 10;

            // --- Column Headers ---
            int x = leftMargin;
            for (int i = 0; i < columnTitles.Length; i++)
            {
                Rectangle rect = new Rectangle(x, yPosition, columnWidths[i], lineHeight);
                e.Graphics.FillRectangle(Brushes.LightGray, rect);
                e.Graphics.DrawRectangle(gridPen, rect);
                e.Graphics.DrawString(columnTitles[i], headerFont, blackBrush, rect);
                x += columnWidths[i];
            }
            yPosition += lineHeight;

            // --- Rows ---
            while (printRowIndex < dgvProducts.Rows.Count)
            {
                if (yPosition + (lineHeight * 2) > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }

                DataGridViewRow row = dgvProducts.Rows[printRowIndex];
                x = leftMargin;

                // Brand
                string brand = row.Cells["brand"].Value?.ToString() ?? "";
                e.Graphics.DrawString(brand, cellFont, blackBrush, new RectangleF(x, yPosition, columnWidths[0], lineHeight * 2));
                x += columnWidths[0];

                // Description (2-line wrap)
                string desc = row.Cells["description"].Value?.ToString() ?? "";
                StringFormat format = new StringFormat
                {
                    Trimming = StringTrimming.EllipsisCharacter,
                    FormatFlags = StringFormatFlags.LineLimit
                };
                e.Graphics.DrawString(desc, cellFont, blackBrush, new RectangleF(x, yPosition, columnWidths[1], lineHeight * 2), format);
                x += columnWidths[1];

                // Price
                decimal price = Convert.ToDecimal(row.Cells["price"].Value);
                e.Graphics.DrawString(price.ToString("C2"), cellFont, blackBrush, new RectangleF(x, yPosition, columnWidths[2], lineHeight * 2));
                x += columnWidths[2];

                // Stock + REORDER
                int stock = Convert.ToInt32(row.Cells["stock"].Value);
                string stockText = stock.ToString();
                Brush stockBrush = blackBrush;

                if (stock < reorderThreshold)
                {
                    stockText += "  [REORDER]";
                    stockBrush = redBrush;
                }

                e.Graphics.DrawString(stockText, stock < reorderThreshold ? reorderFont : cellFont, stockBrush, new RectangleF(x, yPosition, columnWidths[3], lineHeight * 2));

                // Accumulate total inventory value
                totalInventoryValue += price * stock;

                yPosition += (lineHeight * 2) + rowPadding;
                printRowIndex++;
            }

            // --- Footer with Total Value ---
            if (printRowIndex >= dgvProducts.Rows.Count)
            {
                yPosition += 10;
                e.Graphics.DrawLine(Pens.Black, leftMargin, yPosition, rightMargin, yPosition);
                yPosition += 10;

                string totalText = $"Total Inventory Value: {totalInventoryValue:C2}";
                e.Graphics.DrawString(totalText, headerFont, blackBrush, leftMargin, yPosition);

                // Reset for next time
                printRowIndex = 0;
                totalInventoryValue = 0;
                e.HasMorePages = false;
            }

        }

        private void Header(object sender, PrintPageEventArgs e)
        {
            // Your header printing code...
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try {
                if (e.RowIndex == -1 || e.ColumnIndex < 0)
                    return;
            }
            catch { }
            }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmProductModal frmProductModal = new frmProductModal();
            frmProductModal.ShowDialog();
            LoadAllProducts();
        }
    }


}

