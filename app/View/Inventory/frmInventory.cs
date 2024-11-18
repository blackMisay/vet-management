using Core;
using app.core.Repository;
using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Drawing;

namespace app.view.Inventory
{
   
    public partial class frmInventory : Form
    {
        private int currentRowIndex = 0;
        PrintPreviewDialog previewDialog1 = new PrintPreviewDialog();

        public frmInventory()
        {
            InitializeComponent();
            previewDialog1.Document = printDocument1;
        }

        private void frmInventory_Load(object sender, EventArgs e)
        {
            InventoryRepository repository = new InventoryRepository();
            UpgradeFile upgradeFile = new UpgradeFile();
            dgvInventory.DataSource = upgradeFile.Load("SELECT * FROM vwinventory WHERE isDeleted=0;");

            // Attach the CellFormatting event after setting the data source
            dgvInventory.CellFormatting += repository.dgvInventory_CellFormatting;


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //TODO: Populate the datagridview based on the filtered name provided in Search box.
            if (!string.IsNullOrEmpty(txtSearch.Text) || !string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                InventoryRepository inventory = new InventoryRepository();
                DataTable dt = inventory.SearchInventory(txtSearch.Text);

                if (dt != null && dt.Rows.Count > 0)
                {
                    dgvInventory.DataSource = dt;
                    this.dgvInventory.Columns["Id"].Visible = false;
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvInventory.SelectedRows.Count == 0)
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
                    int inventoryID = Convert.ToInt32(dgvInventory.SelectedRows[0].Cells["Id"].Value);
                    frmInventoryModal Modal = new frmInventoryModal(inventoryID);
                    Modal.ShowDialog();
                }
            }
            UpgradeFile upgradeFile = new UpgradeFile();
            dgvInventory.DataSource = upgradeFile.Load("Select * FROM vwinventory WHERE isDeleted=0");
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            InventoryRepository inventory = new InventoryRepository();
            string nextStockNumber = inventory.GenerateNextStockNumber();

            if (nextStockNumber == null)
            {
                MessageBox.Show("Failed to generate stock number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Pass the generated stock number to the modal form
            frmInventoryModal frmInventory = new frmInventoryModal();
            frmInventory.StockNumber = nextStockNumber;  // Set the stock number

            // Show the modal form
            frmInventory.ShowDialog();
      
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvInventory.SelectedRows.Count == 0)
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
                    int inventoryID = Convert.ToInt32(dgvInventory.SelectedRows[0].Cells["Id"].Value);

                    // Call a method to delete the record from the database
                    InventoryRepository Repository = new InventoryRepository();
                    bool isDeleted = Repository.DeleteInventory(inventoryID);

                    if (isDeleted)
                    {
                        // Remove the selected row from the DataGridView
                        dgvInventory.Rows.Remove(dgvInventory.SelectedRows[0]);
                        dgvInventory.Refresh();  

                        MessageBox.Show("Record deleted successfully.", "Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete record.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void Header(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Define fonts for title, address, title bar, and datetime
            Font titleFont = new Font("Century Gothic", 20, FontStyle.Bold);
            Font addressFont = new Font("Century Gothic", 12, FontStyle.Regular);
            Font titlebarFont = new Font("Century Gothic", 25, FontStyle.Underline);
            Font datetimeFont = new Font("Century Gothic", 10, FontStyle.Regular); // Font for DateTime
            int pageWidth = e.PageBounds.Width;

            // Define the content for title, address, title bar, and datetime
            string title = "SAHAGUN VETERINARY CLINIC";
            // Combine address lines into a single string
            string address = "6418 Zapote Street Area D., Camarin Road, Caloocan City";
            string titlebar = "Inventory Report";
            string datetime = "Date: " + DateTime.Now.ToString("MMMM dd, yyyy hh:mm tt"); // Current DateTime formatted

            // Measure the sizes of the title, combined address, title bar, and datetime strings
            SizeF titleSize = e.Graphics.MeasureString(title, titleFont);
            SizeF addressSize = e.Graphics.MeasureString(address, addressFont);
            SizeF titlebarSize = e.Graphics.MeasureString(titlebar, titlebarFont);
            SizeF datetimeSize = e.Graphics.MeasureString(datetime, datetimeFont);

            // Load the clinic logo image (assumed to be in the project directory)
            Image logo = Image.FromFile(@"C:\Users\Lyka\Source\Repos\blackMisay\vet-management\app\icons\logo1-removebg-preview (2).ico");  // Replace with your logo path

            // Calculate the position to center the logo horizontally
            float logoX = (pageWidth - logo.Width) / 2; // Center logo horizontally
            float currentY = 10;  // Starting Y position for the logo

            // Draw the logo in the center of the page
            e.Graphics.DrawImage(logo, logoX, currentY);

            // Move currentY directly after the logo without adding extra space (no space between logo and title)
            currentY += logo.Height;  // Position directly after the logo

            // Draw the title centered horizontally
            float titleX = (pageWidth - titleSize.Width) / 2; // Center the title horizontally
            e.Graphics.DrawString(title, titleFont, Brushes.Black, new PointF(titleX, currentY));

            // Move currentY directly after the title without adding extra space (no space between title and address)
            currentY += titleSize.Height;  // Position directly after the title

            // Draw the combined address centered horizontally
            float addressX = (pageWidth - addressSize.Width) / 2; // Center the combined address horizontally
            e.Graphics.DrawString(address, addressFont, Brushes.Black, new PointF(addressX, currentY));

            // Add space after the address before drawing the title bar
            currentY += addressSize.Height + 10;  // Add 10 units of space between address and title bar

            // Draw the title bar centered horizontally
            float titlebarX = (pageWidth - titlebarSize.Width) / 2; // Center the titlebar horizontally
            e.Graphics.DrawString(titlebar, titlebarFont, Brushes.Black, new PointF(titlebarX, currentY));

            // Move currentY to the next position after title bar
            currentY += titlebarSize.Height + 10;  // Add space after the title bar

            // Draw the datetime on the right side of the page
            float datetimeX = pageWidth - datetimeSize.Width - 10; // Right side position (10px margin from the right edge)
            e.Graphics.DrawString(datetime, datetimeFont, Brushes.Black, new PointF(datetimeX, currentY));

        }
        private int GetColumnWidth(string headerText, int stockNumberWidth,int brandWidth, int DescriptionWidth, int ProductWidth, int categoryWidth, int quantityWidth, int dateReceivedWidth, int expDateReceiveWidth)
        {
            if (headerText == "Stock No.")
                return stockNumberWidth;
            if (headerText == "Brand")
                return brandWidth;
            if (headerText == "Category")
                return categoryWidth;
            if (headerText == "Product")
                return ProductWidth;
            if (headerText == "Description")
                return DescriptionWidth;
            if (headerText == "Quantity")
                return quantityWidth;
            if (headerText == "Date Received")
                return dateReceivedWidth;
            if (headerText == "Expiration Date")
                return expDateReceiveWidth;

            return 150;

        }

        private void btnReports_Click(object sender, EventArgs e)
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

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.PageSettings.Landscape = true;
            int x = e.MarginBounds.Left;
            int y = e.MarginBounds.Top;

            this.Header(sender, e);
            y += 250;

            Font headerFont = new Font("Century Gothic", 10, FontStyle.Bold);
            Font cellFont = new Font("Century Gothic", 8, FontStyle.Regular);

            int stockNumberWidth = 80;
            int brandWidth = 100;
            int DescriptionWidth = 220;
            int ProductWidth = 120;
            int categoryWidth = 80;
            int quantityWidth = 80;
            int dateReceiveWidth = 100;
            int expDateReceiveWidth = 100;

            foreach (DataGridViewColumn col in dgvInventory.Columns)
            {
                if (col.Visible)
                {
                    int cellWidth = GetColumnWidth(col.HeaderText, stockNumberWidth, brandWidth, DescriptionWidth, ProductWidth, categoryWidth, quantityWidth, dateReceiveWidth, expDateReceiveWidth);
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(x, y, cellWidth, dgvInventory.ColumnHeadersHeight));
                    e.Graphics.DrawString(col.HeaderText, headerFont, Brushes.Black, new RectangleF(x, y, cellWidth, dgvInventory.ColumnHeadersHeight), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    x += cellWidth;
                }
            }
            y += dgvInventory.ColumnHeadersHeight;
            x = e.MarginBounds.Left;

            while (currentRowIndex < dgvInventory.Rows.Count)
            {
                DataGridViewRow row = dgvInventory.Rows[currentRowIndex];
                if (!row.IsNewRow)
                {
                    int cellHeight = row.Height;
                    x = e.MarginBounds.Left;

                    for (int i = 0; i < dgvInventory.Columns.Count; i++)
                    {
                        DataGridViewColumn col = dgvInventory.Columns[i];
                        if (col.Visible)
                        {
                            int cellWidth = GetColumnWidth(col.HeaderText, stockNumberWidth, brandWidth, DescriptionWidth, ProductWidth, categoryWidth, quantityWidth, dateReceiveWidth, expDateReceiveWidth);
                            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(x, y, cellWidth, cellHeight));
                            StringFormat cellFormat = new StringFormat
                            {
                                Alignment = (col.HeaderText == "Stock No." || col.HeaderText == "Quantity") ? StringAlignment.Far : StringAlignment.Near,
                                LineAlignment = StringAlignment.Center
                            };
                            e.Graphics.DrawString(row.Cells[col.Index].FormattedValue.ToString(), cellFont, Brushes.Black, new RectangleF(x + 2, y, cellWidth - 4, cellHeight), cellFormat);

                            x += cellWidth;
                        }
                    }
                    y += cellHeight;

                    if (y + cellHeight > e.MarginBounds.Bottom)
                    {
                        e.HasMorePages = true;
                        currentRowIndex++;
                        return;
                    }
                }
                currentRowIndex++;
            }
            e.HasMorePages = false;
            currentRowIndex = 0;
        }
    }
}
