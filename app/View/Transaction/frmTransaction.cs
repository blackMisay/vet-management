using app.core.model;
using app.view.Product;
using Core;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace app.view.Transaction
{
    public partial class frmTransaction : Form
    {
        private int voidItem = 0;
        public frmTransaction()
        {
            InitializeComponent();
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString();
            lblInvoice.Text = DateTime.Now.ToString("yyMMddHHmmss");
            
        }

        private void btnQuantity_Click(object sender, EventArgs e)
        {
            frmQuantity frm = new frmQuantity();
            frm.ShowDialog();
        }

        private void btnVoidItem_Click(object sender, EventArgs e)
        {
            voidItem = 0; // Reset the quantity
            lblSubTotal.Text = voidItem.ToString();
            lblTotal.Text = voidItem.ToString();
        }

        private void frmTransaction_Load(object sender, EventArgs e)
        {
            UpgradeFile upgradeFile = new UpgradeFile();
            dgvTransaction.DataSource = upgradeFile.Load("SELECT * FROM transaction;");
        }

        private void btnItemLookup_Click(object sender, EventArgs e)
        {
           frmItemLookUp frmItem = new frmItemLookUp();
          
            frmItem.ShowDialog();
        }

        private void btnService_Click(object sender, EventArgs e)
        {
            frmServiceLookUp lookUp = new frmServiceLookUp();
            lookUp.ShowDialog();
        }
    }
}
