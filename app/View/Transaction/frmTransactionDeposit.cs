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
    public partial class frmTransactionDeposit : Form
    {
        public frmTransactionDeposit()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            // Find the currently open frmTransaction instance
            frmTransaction frm = Application.OpenForms.OfType<frmTransaction>().FirstOrDefault();

            if (frm == null)
            {
                MessageBox.Show("Transaction form is not open.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate input
            if (string.IsNullOrWhiteSpace(txtDeposit.Text))
            {
                MessageBox.Show("Please enter a deposit amount.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ensure input is a valid number
            if (!double.TryParse(txtDeposit.Text, out double depositAmount) || depositAmount < 0)
            {
                MessageBox.Show("Please enter a valid deposit amount.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Convert lblSubtotal and lblBalance safely after removing currency symbols
            double subtotal = 0, balance = 0, total = 0;
            // Compute the correct total
            total = (subtotal + balance) - depositAmount;  // Ensuring proper computation

            // Update lblTotal
            frm.lblTotalAmount.Text = total.ToString("C2"); // Display as currency format

            // Optional: Clear txtDeposit after updating
            txtDeposit.Clear();


        }
    }
}
