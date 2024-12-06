using Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app.view.Transaction
{
    public partial class frmItemLookUp : Form
    {
        public frmItemLookUp()
        {
            InitializeComponent();
        }

        private void frmItemLookUp_Load(object sender, EventArgs e)
        {
            lblDesc.Text = "This form allows the user to select product.";
           
            UpgradeFile upgradeFile = new UpgradeFile();

            dgvProducts.DataSource = upgradeFile.Load("SELECT * FROM vwinventory WHERE isDeleted = 0");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmTransaction frm = new frmTransaction();
            // Check if a row is selected in dgvProducts
            if (dgvProducts.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dgvProducts.SelectedRows[0];

                // Create a new row for dgvTransaction
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(frm.dgvTransaction);

                // Copy values from the selected row in dgvProducts to the new row
                for (int i = 0; i < selectedRow.Cells.Count; i++)
                {
                    newRow.Cells[i].Value = selectedRow.Cells[i].Value;
                }

                // Add the new row to dgvTransaction
                frm.dgvTransaction.Rows.Add(newRow);
            }
            else
            {
                // Display a message if no row is selected
                MessageBox.Show("Please select a product from the list.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
