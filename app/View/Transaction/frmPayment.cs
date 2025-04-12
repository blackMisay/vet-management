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
    public partial class frmPayment : Form
    {

        double totalAmount = 0;
        double changeAmount = 0;
        bool isPaymentSuccess = false;
        
        public frmPayment()
        {
            InitializeComponent();
        }

        public frmPayment(double amount)
        {
            InitializeComponent();
            this.totalAmount = amount;
            this.lblTotalAmount.Text = "Total Amount: " + amount.ToString("N2");
        }

        public double GetChangeAmount()
        {
            return this.changeAmount;
        }

        public bool ProceedPayment()
        {
            return this.isPaymentSuccess;
        }

        private void frmPayment_Load(object sender, EventArgs e)
        {

        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtEnterAmount.Text) || String.IsNullOrWhiteSpace(txtEnterAmount.Text))
            {
                MessageBox.Show("Please enter amount.");
                return;
            }

            if (Convert.ToDouble(txtEnterAmount.Text) < this.totalAmount)
            {
                MessageBox.Show("Invalid entered amount");
                return;
            }

            this.changeAmount = Convert.ToDouble(txtEnterAmount.Text) - this.totalAmount;
            
            this.lblChangeAmount.Text = "Change Amount: " + this.changeAmount.ToString("N2");

            if (MessageBox.Show("Do you want to proceed on the payment?","Payment",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                isPaymentSuccess = true;
                this.Close();
            }
        }
    }
}
