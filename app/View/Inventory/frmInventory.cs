using app.core.Repository;
using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Drawing;
using app.Properties;
using System.Collections.Generic;
using app.core.Extensions;
using Core;
using app.core.model;
using System.Linq;

namespace app.view.Inventory
{
    public partial class frmInventory : Form
    {
        private int currentRowIndex = 0;
        private readonly PrintPreviewDialog previewDialog1 = new PrintPreviewDialog();
        private readonly InventoryRepository inventoryRepository;
        private int MAX_RECORD_COUNT = 10;
        private int displayRecord = 0;

        public frmInventory()
        {
            InitializeComponent();
            inventoryRepository = new InventoryRepository();
            previewDialog1.Document = printDocument1;

            //LoadCategories();
            LoadAllProducts();
            //this.CustomDGV();
            //dgvInventory.RowPrePaint += dgvInventory_RowPrePaint;

        }

        private void InventoryLoad()
        {
            Dictionary<string, int> parameter = new Dictionary<string, int>
            {
                {"@RecordCount", this.MAX_RECORD_COUNT},
                {"@Record", this.displayRecord}
            };
            InventoryRepository inventoryRepository = new InventoryRepository();
            {
                inventoryRepository.InventoryLoad(dgvInventory, parameter);
            };
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                MessageBox.Show("The search field is empty, please provide.", "Empty field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataTable dt = inventoryRepository.SearchInventory(keyword);
            if (dt != null && dt.Rows.Count > 0)
            {
                dgvInventory.DataSource = dt;
                dgvInventory.Columns["Id"].Visible = false;
            }
            else
            {
                MessageBox.Show("No results found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            
        }

        private void HighlightLowStock()
        {
            foreach (DataGridViewRow row in dgvInventory.Rows)
            {
                if (row.IsNewRow) continue;

                var stockCell = row.Cells["stock"];
                var thresholdCell = row.Cells["low_stock_threshold"];

                if (stockCell != null && thresholdCell != null &&
                    int.TryParse(stockCell.Value?.ToString(), out int stock) &&
                    int.TryParse(thresholdCell.Value?.ToString(), out int threshold))
                {
                    if (stock <= threshold)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightCoral;
                        row.DefaultCellStyle.ForeColor = Color.White;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = dgvInventory.DefaultCellStyle.BackColor;
                        row.DefaultCellStyle.ForeColor = dgvInventory.DefaultCellStyle.ForeColor;
                    }
                }
            }
        }



        //private void LoadCategories()
        //{
        //    UpgradeFile upgradeFile = new UpgradeFile();
        //    DataTable dt = upgradeFile.Load("SELECT id, name FROM categories ORDER BY name;");

        //    var categories = new List<KeyValuePair<int, string>>
        //    {
        //        new KeyValuePair<int, string>(-1, "All Categories")
        //    };

        //    foreach (DataRow row in dt.Rows)
        //    {
        //        categories.Add(new KeyValuePair<int, string>((int)row["id"], row["name"].ToString()));
        //    }

        //    cmbCategory.DataSource = new BindingSource(categories, null);
        //    cmbCategory.DisplayMember = "Value";
        //    cmbCategory.ValueMember = "Key";
        //}

        private void txtSearch_TextChanged(object sender, EventArgs e) => LoadAllProducts();
        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e) => LoadAllProducts();

        private void frmInventory_Load(object sender, EventArgs e)
        {
            //LoadCategoryComboBox();
            LoadAllProducts();

            //cmbCategory.SelectedIndexChanged += FilterProducts;

            //InventoryRepository inventoryRepository = new InventoryRepository();
            //this.InventoryLoad();
        }

        //private void LoadCategoryComboBox()
        //{
        //    UpgradeFile upgradeFile = new UpgradeFile();
        //    DataTable dt = upgradeFile.Load("SELECT id, name FROM categories ORDER BY name;");

        //    var categories = new List<KeyValuePair<int, string>>
        //    {
        //        new KeyValuePair<int, string>(-1, "All Categories")
        //    };

        //    foreach (DataRow row in dt.Rows)
        //    {
        //        categories.Add(new KeyValuePair<int, string>((int)row["id"], row["name"].ToString()));
        //    }

        //    cmbCategory.DataSource = new BindingSource(categories, null);
        //    cmbCategory.DisplayMember = "Value";
        //    cmbCategory.ValueMember = "Key";
        //}

        private void LoadAllProducts()
        {
            UpgradeFile upgradeFile = new UpgradeFile();

            string sql = @"SELECT * FROM vw_inventory_products";

            DataTable dt = upgradeFile.Load(sql);
            dgvInventory.DataSource = dt;

            FormatDataGridView();
            HighlightLowStock();

        }

        private void FormatDataGridView()
        {

            if (dgvInventory.Columns["id"] != null)
                dgvInventory.Columns["id"].Visible = false;

            if (dgvInventory.Columns["sku"] != null)
                dgvInventory.Columns["sku"].Visible = false;

            if (dgvInventory.Columns["brand"] != null)
                dgvInventory.Columns["brand"].HeaderText = "Brand";

            if (dgvInventory.Columns["description"] != null)
                dgvInventory.Columns["description"].HeaderText = "Description";

            if (dgvInventory.Columns["supplier"] != null)
                dgvInventory.Columns["supplier"].Visible = false;


            if (dgvInventory.Columns["category"] != null)
                dgvInventory.Columns["category"].Visible = false;


            if (dgvInventory.Columns["price"] != null)
            {
                dgvInventory.Columns["price"].HeaderText = "Price";
                dgvInventory.Columns["price"].DefaultCellStyle.Format = "C2"; // currency format
                dgvInventory.Columns["price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; // right align
            }

            dgvInventory.Columns["id"].DisplayIndex = 0;
            dgvInventory.Columns["sku"].DisplayIndex = 1;
            dgvInventory.Columns["brand"].DisplayIndex = 2;
            dgvInventory.Columns["description"].DisplayIndex = 3;
            dgvInventory.Columns["category"].DisplayIndex = 4;
            dgvInventory.Columns["supplier"].DisplayIndex = 5;
            dgvInventory.Columns["price"].DisplayIndex = 6;



        }

        //private void FilterProducts(object sender, EventArgs e)
        //{
        //    int selectedCategoryId = ((KeyValuePair<int, string>)cmbCategory.SelectedItem).Key;

        //    UpgradeFile upgradeFile = new UpgradeFile();

        //    string sql = @"
        //        SELECT 
        //            p.id, 
        //            p.sku, 
        //            pb.brandDesc AS brand, 
        //            p.description, 
        //            c.name AS category, 
        //            s.name AS supplier, 
        //            p.price 
        //        FROM products p
        //        LEFT JOIN categories c ON p.category_id = c.id
        //        LEFT JOIN suppliers s ON p.supplier_id = s.id
        //        LEFT JOIN product_brand pb ON p.brand_id = pb.brandId
        //        WHERE (@CategoryId = -1 OR p.category_id = @CategoryId)
        //        ORDER BY c.name, pb.brandDesc, p.description, p.price DESC;
        //    ";

        //    // Use parameters to avoid SQL injection
        //    var parameters = new Dictionary<string, object>
        //    {
        //        { "@CategoryId", selectedCategoryId }
        //    };

        //    DataTable dt = upgradeFile.LoadDataTable(sql, parameters);
        //    dgvInventory.DataSource = dt;
        //    FormatDataGridView();
        //    HighlightLowStock();

        //}

        private void btnInventory_Click(object sender, EventArgs e)
        {
            frmInventoryModal frm = new frmInventoryModal();
            frm.ShowDialog();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            frmStockTransaction frm = new frmStockTransaction();
            frm.ShowDialog();
        }

        int selectedId = 0;
        private void dgvInventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1 || e.ColumnIndex < 0)
                    return;

                var row = dgvInventory.Rows[e.RowIndex];
                if (row == null)
                    return;

                // Find the column with name "Id" (case-insensitive)
                DataGridViewColumn idColumn = null;
                foreach (DataGridViewColumn col in dgvInventory.Columns)
                {
                    if (string.Equals(col.Name, "Id", StringComparison.OrdinalIgnoreCase))
                    {
                        idColumn = col;
                        break;
                    }
                }

                if (idColumn == null)
                {
                    MessageBox.Show("No column named 'Id' found.");
                    return;
                }

                var cell = row.Cells[idColumn.Index];
                if (cell?.Value == null)
                {
                    MessageBox.Show("ID cell is empty.");
                    return;
                }

                if (int.TryParse(cell.Value.ToString(), out int immunizationId))
                {
                    selectedId = immunizationId;
                }
                else
                {
                    MessageBox.Show("Invalid ID format.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message);
            }

        }

        private void CustomDGV()
        {
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                BackColor = SystemColors.Control,
                Font = new Font("Century Gothic", 13.2F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))),
                ForeColor = SystemColors.WindowText,
                SelectionBackColor = SystemColors.Highlight,
                SelectionForeColor = SystemColors.HighlightText,
                WrapMode = DataGridViewTriState.True
            };
            dgvInventory.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle
            {
                Font = new Font("Century Gothic", 13.2F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)))
            };
            dgvInventory.DefaultCellStyle = rowStyle;
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            //  Set this BEFORE dialogs
            printDocument1.DefaultPageSettings.Landscape = true;

            // Optional: set A4 size explicitly
            // printDocument1.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1169);

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
        
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            e.PageSettings.Landscape = true;

            // Layout constants
            int topMargin = e.MarginBounds.Top;
            int leftMargin = e.MarginBounds.Left;
            int bottomMargin = e.MarginBounds.Bottom;
            int reorderThreshold = 10;

            // Fonts
            Font companyFont = new Font("Century Gothic", 16, FontStyle.Bold);
            Font titleFont = new Font("Century Gothic", 14, FontStyle.Bold);
            Font headerFont = new Font("Century Gothic", 10, FontStyle.Bold);
            Font cellFont = new Font("Century Gothic", 10);
            Font reorderFont = new Font("Century Gothic", 10, FontStyle.Bold);

            // Brushes and Pen
            Brush blackBrush = Brushes.Black;
            Brush redBrush = Brushes.Red;
            Pen gridPen = Pens.Gray;

            // Column layout
            int[] columnWidths = { 200, 600, 100, 100 };
            string[] columnTitles = { "Brand", "Product Description", "Price", "Stock" };
            int totalTableWidth = columnWidths.Sum();
            int tableStartX = leftMargin;

            // Tight row height
            int lineHeight = (int)cellFont.GetHeight(g);
            int rowHeight = lineHeight + 6; // tighter padding

            // Header
            int yPosition = topMargin;
            Image logo = Resources.logo2;
            if (logo != null)
                g.DrawImage(logo, tableStartX, yPosition, 60, 60);

            g.DrawString("SAHAGUN VETERINARY CLINIC", companyFont, blackBrush, tableStartX + 70, yPosition + 10);
            yPosition += 60 + 10;

            g.DrawString("Product Inventory Report", titleFont, blackBrush, tableStartX, yPosition);
            yPosition += titleFont.Height + 3;
            g.DrawString("Date: " + DateTime.Now.ToString("g"), cellFont, blackBrush, tableStartX, yPosition);
            yPosition += cellFont.Height + 5;

            // Table bounds
            int maxRowsPerPage = (bottomMargin - yPosition) / rowHeight;
            int rowCount = Math.Min(maxRowsPerPage - 2, dgvInventory.Rows.Count - printRowIndex);
            int tableTop = yPosition;
            int tableBottom = tableTop + (rowCount + 1) * rowHeight;

            // Draw horizontal lines
            for (int i = 0; i <= rowCount + 1; i++)
            {
                int y = yPosition + i * rowHeight;
                g.DrawLine(gridPen, tableStartX, y, tableStartX + totalTableWidth, y);
            }

            // Draw vertical lines
            int x = tableStartX;
            g.DrawLine(gridPen, x, yPosition, x, tableBottom);
            for (int i = 0; i < columnWidths.Length; i++)
            {
                x += columnWidths[i];
                g.DrawLine(gridPen, x, yPosition, x, tableBottom);
            }

            // Draw header text
            x = tableStartX;
            for (int i = 0; i < columnTitles.Length; i++)
            {
                Rectangle headerRect = new Rectangle(x, yPosition, columnWidths[i], rowHeight);
                g.DrawString(columnTitles[i], headerFont, blackBrush, headerRect, new StringFormat { LineAlignment = StringAlignment.Center });
                x += columnWidths[i];
            }
            yPosition += rowHeight;

            // Draw rows
            for (int r = 0; r < rowCount && printRowIndex < dgvInventory.Rows.Count; r++, printRowIndex++)
            {
                DataGridViewRow row = dgvInventory.Rows[printRowIndex];
                x = tableStartX;

                // Brand
                string brand = row.Cells["brand"].Value?.ToString() ?? "";
                g.DrawString(brand, cellFont, blackBrush, new RectangleF(x, yPosition, columnWidths[0], rowHeight));
                x += columnWidths[0];

                // Description
                string desc = row.Cells["description"].Value?.ToString() ?? "";
                StringFormat descFormat = new StringFormat { Trimming = StringTrimming.EllipsisCharacter, FormatFlags = StringFormatFlags.NoWrap };
                RectangleF descRect = new RectangleF(x, yPosition + 2, columnWidths[1], rowHeight - 4);
                g.DrawString(desc, cellFont, blackBrush, descRect, descFormat);
                x += columnWidths[1];

                // Price (right aligned)
                decimal price = Convert.ToDecimal(row.Cells["price"].Value);
                string priceText = price.ToString("C2");
                SizeF priceSize = g.MeasureString(priceText, cellFont);
                g.DrawString(priceText, cellFont, blackBrush, new RectangleF(x + columnWidths[2] - priceSize.Width, yPosition, priceSize.Width, rowHeight));
                x += columnWidths[2];

                // Stock (right aligned)
                int stock = Convert.ToInt32(row.Cells["stock"].Value);
                string stockText = stock.ToString();
                Brush stockBrush = blackBrush;
                Font stockFont = cellFont;
                if (stock < reorderThreshold)
                {
                    stockText += "  [REORDER]";
                    stockBrush = redBrush;
                    stockFont = reorderFont;
                }
                SizeF stockSize = g.MeasureString(stockText, stockFont);
                g.DrawString(stockText, stockFont, stockBrush, new RectangleF(x + columnWidths[3] - stockSize.Width, yPosition, stockSize.Width, rowHeight));

                totalInventoryValue += price * stock;
                yPosition += rowHeight;
            }

            // Footer
            if (printRowIndex >= dgvInventory.Rows.Count)
            {
                yPosition += 8;
                string totalText = $"Total Inventory Value: {totalInventoryValue:C2}";
                SizeF totalSize = g.MeasureString(totalText, headerFont);
                g.DrawString(totalText, headerFont, blackBrush, tableStartX + totalTableWidth - totalSize.Width, yPosition);

                printRowIndex = 0;
                totalInventoryValue = 0;
                e.HasMorePages = false;
            }
            else
            {
                e.HasMorePages = true;
            }
        }
    }
}
