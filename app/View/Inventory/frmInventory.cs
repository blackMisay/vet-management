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
        PrintPreviewDialog previewDialog = new PrintPreviewDialog();
        public frmInventory()
        {
            InitializeComponent();
            previewDialog.Document = printDocument1;
        }

        private void frmInventory_Load(object sender, EventArgs e)
        {
            UpgradeFile upgradeFile = new UpgradeFile();

            dgvInventory.DataSource = upgradeFile.Load("SELECT * FROM vwinventory WHERE isDeleted=0;");

            InventoryRepository inventory = new InventoryRepository();
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
            frmInventoryModal frmInventory = new frmInventoryModal();
            frmInventory.ShowDialog();
            dgvInventory.Refresh();
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

        private void btnReports_Click(object sender, EventArgs e)
        {
            DialogResult preresult = previewDialog.ShowDialog();
            if(preresult == DialogResult.OK)
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
            Font titleFont = new Font("Century Gothic", 18,FontStyle.Bold);
            Font addressFont = new Font("Century Gothic", 15, FontStyle.Regular);
            int pageWidth = e.PageBounds.Width;

            string title = "SAHAGUN VETERINARY CLINIC";
            string addressLine1 = "6418 Zapote Street Area D.";
            string addressLine2 = "Camarin Road, Caloocan City";
            
            SizeF titleSize = e.Graphics.MeasureString(title, titleFont);
            SizeF addressSize1 = e.Graphics.MeasureString(addressLine1, addressFont);
            SizeF addressSize2 = e.Graphics.MeasureString(addressLine2, addressFont);

            float centerX = pageWidth / 2;
            float titleX = centerX - titleSize.Width / 2;
            float addressX = centerX - titleSize.Width / 2;

            float currentY = 10;

            e.Graphics.DrawString(title, titleFont, Brushes.Black, new PointF(titleX, currentY));
            currentY += titleSize.Height + 5;

            e.Graphics.DrawString(addressLine1, addressFont, Brushes.Black, new PointF(addressX, currentY));
            currentY += addressSize1.Height;

            e.Graphics.DrawString(addressLine2, addressFont, Brushes.Black, new PointF(addressX, currentY));
            currentY += addressSize2.Height;
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.PageSettings.Landscape = true;
            int x = e.MarginBounds.Left;
            int y = e.MarginBounds.Top;

            this.Header(sender, e);
            y += 130;

            Font headerFont = new Font("Century Gothic", 10, FontStyle.Bold);
            Font cellFont = new Font("Century Gothic", 8, FontStyle.Regular);

            int stockNumberWidth = 20;
            int brandWidth = 100;
            int DescriptionWidth = 200;
            int ProductWidth = 100;
            int categoryWidth = 80;
            int quantityWidth = 80;
            int dateReceiveWidth = 150;
            int expDateReceiveWidth = 150;

            foreach (DataGridViewColumn col in dgvInventory.Columns)
            {
                if (col.Visible)
                {
                    int cellWidth = GetColumnWidth(col.HeaderText, stockNumberWidth,brandWidth,DescriptionWidth,ProductWidth,categoryWidth,quantityWidth,dateReceiveWidth,expDateReceiveWidth);
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(x, y, cellWidth, dgvInventory.ColumnHeadersHeight));
                    e.Graphics.DrawString(col.HeaderText, headerFont, Brushes.Black, new RectangleF(x, y, cellWidth,dgvInventory.ColumnHeadersHeight), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
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
                                Alignment = (col.HeaderText == "Stock Number" || col.HeaderText == "Quantity") ? StringAlignment.Far : StringAlignment.Near,
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
            currentRowIndex=0;
        }
        private int GetColumnWidth(string headerText, int stockNumberWidth,int brandWidth, int DescriptionWidth, int ProductWidth, int categoryWidth, int quantityWidth, int dateReceivedWidth, int expDateReceiveWidth)
        {
            if (headerText == "Stock #")
                return stockNumberWidth;
            if (headerText == "Brand")
                return brandWidth;
            if (headerText == "Description")
                return DescriptionWidth;
            if (headerText == "Product")
                return ProductWidth;
            if (headerText == "Category")
                return categoryWidth;
            if (headerText == "Quantity")
                return quantityWidth;
            if (headerText == "Date Received")
                return dateReceivedWidth;
            if (headerText == "Expiration Date")
                return expDateReceiveWidth;

            return 100;

        }
    }
}
