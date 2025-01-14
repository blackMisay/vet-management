using app.core.repository;
using app.Properties;
using Core;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
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

        private void Header(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.PageSettings.Landscape = true;
            // Define fonts for title, address, title bar, datetime, totalSales, and quantity
            Font titleFont = new Font("Century Gothic", 14, FontStyle.Bold);
            Font addressFont = new Font("Century Gothic", 8, FontStyle.Regular);
            Font titlebarFont = new Font("Century Gothic", 13, FontStyle.Underline);
            Font datetimeFont = new Font("Century Gothic", 8, FontStyle.Regular); // Font for DateTime

            int pageWidth = e.PageBounds.Width;

            // Define the content for title, address, title bar, datetime
            string title = "SAHAGUN VETERINARY CLINIC";
            string address = "6418 Zapote Street Area D., Camarin Road, Caloocan City";
            string titlebar = "Product Report";
            string datetime = "Date: " + DateTime.Now.ToString("MMMM dd, yyyy hh:mm tt"); // Current DateTime formatted

            // Measure sizes of text strings to adjust positioning
            SizeF titleSize = e.Graphics.MeasureString(title, titleFont);
            SizeF addressSize = e.Graphics.MeasureString(address, addressFont);
            SizeF titlebarSize = e.Graphics.MeasureString(titlebar, titlebarFont);
            SizeF datetimeSize = e.Graphics.MeasureString(datetime, datetimeFont);

            Image logo = Resources.sahagun;
            float logoX = (pageWidth - logo.Width) / 2;

            float currentY = 10;  // Starting Y position

            // Draw Logo
            e.Graphics.DrawImage(logo, logoX, currentY);
            currentY += logo.Height + 20; // Move Y down after logo

            // Draw Title
            float titleX = (pageWidth - titleSize.Width) / 2;
            e.Graphics.DrawString(title, titleFont, Brushes.Black, new PointF(titleX, currentY));
            currentY += titleSize.Height + 5; // Adjust Y for spacing after title

            // Draw Address
            float addressX = (pageWidth - addressSize.Width) / 2;
            e.Graphics.DrawString(address, addressFont, Brushes.Black, new PointF(addressX, currentY));
            currentY += addressSize.Height + 10; // Adjust Y for spacing after address

            // Draw Titlebar
            float titlebarX = (pageWidth - titlebarSize.Width) / 2;
            e.Graphics.DrawString(titlebar, titlebarFont, Brushes.Black, new PointF(titlebarX, currentY));
            currentY += titlebarSize.Height + 10; // Adjust Y for spacing after titlebar

            // Draw DateTime (positioned at the right side of the page)
            float datetimeX = pageWidth - datetimeSize.Width - 50;  // 50 pixels from the right
            e.Graphics.DrawString(datetime, datetimeFont, Brushes.Black, new PointF(datetimeX, currentY));


        }
        private int GetColumnWidth(string headerText, int typeWidth, int brandWidth, int descriptionWidth, int categoryWidth)
        {
            if (headerText == "Type of Product")
                return typeWidth;
            if (headerText == "Category")
                return categoryWidth;
            if (headerText == "Brand")
                return brandWidth;
            if (headerText == "Description")
                return descriptionWidth;


            return 100;

        }
        private void printDocument1_PrintPage_1(object sender, PrintPageEventArgs e)
        {

            // Define fonts for header and cells
            Font headerFont = new Font("Century Gothic", 8, FontStyle.Bold);
                Font cellFont = new Font("Century Gothic", 8, FontStyle.Regular);

                // Predefined column widths
                int typeWidth = 100;
                int categoryWidth = 100;
                int brandWidth = 220;
                int descriptionWidth = 200;

                // Calculate total table width based on visible columns
                int totalTableWidth = 0;
                foreach (DataGridViewColumn col in dgvProducts.Columns)
                {
                    if (col.Visible)
                    {
                        totalTableWidth += GetColumnWidth(col.HeaderText, typeWidth, brandWidth, descriptionWidth, categoryWidth);
                    }
                }

                // Page layout configuration
                e.PageSettings.Landscape = true;
                int pageWidth = e.MarginBounds.Width;
                int centeredX = e.MarginBounds.Left + (pageWidth - totalTableWidth) / 2;
                int x = centeredX;
                int y = e.MarginBounds.Top;

                // Draw the header (add any custom header logic here)
                this.Header(sender, e);
                y += 210; // Adjust based on your header's height

                // Draw table headers
                foreach (DataGridViewColumn col in dgvProducts.Columns)
                {
                    if (col.Visible)
                    {
                        int cellWidth = GetColumnWidth(col.HeaderText, typeWidth, brandWidth, descriptionWidth, categoryWidth);
                        e.Graphics.DrawRectangle(Pens.Black, new Rectangle(x, y, cellWidth, dgvProducts.ColumnHeadersHeight));
                        e.Graphics.DrawString(col.HeaderText, headerFont, Brushes.Black, new RectangleF(x, y, cellWidth, dgvProducts.ColumnHeadersHeight), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                        x += cellWidth;
                    }
                }

                y += dgvProducts.ColumnHeadersHeight; // Move down after header row
                x = centeredX; // Reset X position for row drawing

                // Draw the rows
                while (currentRowIndex < dgvProducts.Rows.Count)
                {
                    DataGridViewRow row = dgvProducts.Rows[currentRowIndex];
                    if (!row.IsNewRow)
                    {
                        int cellHeight = row.Height;
                        x = centeredX;

                        // Draw each cell in the row
                        for (int i = 0; i < dgvProducts.Columns.Count; i++)
                        {
                            DataGridViewColumn col = dgvProducts.Columns[i];
                            if (col.Visible)
                            {
                                int cellWidth = GetColumnWidth(col.HeaderText, typeWidth, brandWidth, descriptionWidth, categoryWidth);
                                e.Graphics.DrawRectangle(Pens.Black, new Rectangle(x, y, cellWidth, cellHeight));

                                // Draw the cell content
                                string cellValue = row.Cells[i].FormattedValue.ToString();
                                e.Graphics.DrawString(cellValue, cellFont, Brushes.Black, new RectangleF(x, y, cellWidth, cellHeight), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

                                x += cellWidth; // Move X position for next cell
                            }
                        }

                        y += cellHeight; // Move down after the current row

                        // Check if the next row will overflow the page
                        if (y + cellHeight > e.MarginBounds.Bottom)
                        {
                            e.HasMorePages = true;
                            currentRowIndex++; // Increment to the next row for the next page
                            return;
                        }
                    }

                    currentRowIndex++; // Move to the next row
                }

                e.HasMorePages = false; // No more pages after all rows are printed
                currentRowIndex = 0; // Reset the row index for the next print job

            }

    }
}

