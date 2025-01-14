using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app.view.Transaction
{
    public partial class frmItemQuantity : Form
    {
        public frmItemQuantity()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Increment the quantity
            int quantity = int.TryParse(txtQty.Text, out quantity) ? quantity : 0;
            txtQty.Text = (quantity + 1).ToString();
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            // Decrement the quantity but ensure it doesn't go below 1
            int quantity = int.TryParse(txtQty.Text, out quantity) ? quantity : 1;
            if (quantity > 1)
            {
                txtQty.Text = (quantity - 1).ToString();
            }
        }
    }
}
