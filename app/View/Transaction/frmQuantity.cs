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
    public partial class frmQuantity : Form
    {
        private int quantity = 0;
        public frmQuantity()
        {
            InitializeComponent();
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            quantity++;
            txtQuantity.Text = quantity.ToString();
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (quantity > 0) // Prevents negative quantities
            {
                quantity--;
                txtQuantity.Text = quantity.ToString();
            }
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            // Validate input to ensure it is numeric
            if (int.TryParse(txtQuantity.Text, out int newQuantity))
            {
                quantity = newQuantity;
            }
            else
            {
                // Reset to the last valid value if input is invalid
                txtQuantity.Text = quantity.ToString();
                txtQuantity.SelectionStart = txtQuantity.Text.Length; // Keep cursor at the end
            }
        }
    }
}