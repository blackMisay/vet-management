using app.core.model;
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
            this.lblTotalAmount.Text = amount.ToString("N2");
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

        private TransactionPayment payment = new TransactionPayment();
        private bool PaymentSuccess = false;
        private void btnPay_Click(object sender, EventArgs e)
        {
           if (string.IsNullOrWhiteSpace(txtTotal.Text))
{
    MessageBox.Show("Please enter an amount.", "Missing Amount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    return;
}

if (!double.TryParse(txtTotal.Text, out double enteredAmount))
{
    MessageBox.Show("Invalid amount. Please enter a valid number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    return;
}

if (enteredAmount < this.totalAmount)
{
    MessageBox.Show("Entered amount is less than the total due.", "Insufficient Amount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    return;
}

// Calculate change
this.changeAmount = enteredAmount - this.totalAmount;
lblChangeAmount.Text = "Change Amount: " + this.changeAmount.ToString("N2");

// Confirm payment
var result = MessageBox.Show("Do you want to proceed with the payment?", "Confirm Payment",
    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

if (result == DialogResult.Yes)
{
    // Assign values to payment model
    payment.TotalAmount = this.totalAmount;
    payment.ChangeAmount = this.changeAmount;
    payment.Cash = enteredAmount;

    // Save to database
    bool saved = SavePayment(payment);
    if (saved)
    {
        PaymentSuccess = true;

        // Show receipt
        var receiptForm = new frmReceipt(payment);
        receiptForm.ShowPreview();

        this.Close(); // Optionally close this form
    }
    else
    {
        MessageBox.Show("Failed to save payment. Please try again.", "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}


        }
        private bool SavePayment(TransactionPayment payment)
        {
            // Your real database saving logic
            return true;
        }

        private string Mode(int index)
        {
            switch (index)
            {
                case 0:
                    return "Cash";
                case 1:
                    return "GCash";
                case 2:
                    return "PayMaya";
                default:
                    return "Cash";
            }
        }

        private void AddToDGV(string modeOfPayment, string referenceNumber, double amount)
        {
            if (dgvPayment.Columns["ModeOfPayment"] == null)
            {
                dgvPayment.Columns.Add("ModeOfPayment", "Mode of Payment");
            }
            if (dgvPayment.Columns["Reference"] == null)
            {
                dgvPayment.Columns.Add("Reference", "Reference Number");
            }
            if (dgvPayment.Columns["Amount"] == null)
            {
                dgvPayment.Columns.Add("Amount", "Amount");
            }

            dgvPayment.Rows.Add(modeOfPayment, referenceNumber, amount);
            ComputeChange();
        }

        private void ComputeChange()
        {
            double total = Convert.ToDouble(lblTotalAmount.Text);
            double paid = dgvPayment.Rows.Cast<DataGridViewRow>()
                            .Sum(row => Convert.ToDouble(row.Cells["Amount"].Value.ToString()));

            double change = paid - total;
            txtChange.Text = change > 0 ? change.ToString("#,##0.00") : "0.00";
        }

        private List<PaymentDetail> paymentDetails = new List<PaymentDetail>();
        private void btnConfirm_Click(object sender, EventArgs e)
        {
           string modeOfPayment = Mode(cboMode.SelectedIndex);
    string referenceNumber = txtRefNum.Text.Trim();
    double amount;

    if (!double.TryParse(txtCashTendered.Text, out amount) || amount <= 0)
    {
        MessageBox.Show("Invalid amount entered. Please enter a valid positive number.", "POS App", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
    }

    if ((modeOfPayment == "GCash" || modeOfPayment == "PayMaya") && string.IsNullOrEmpty(referenceNumber))
    {
        MessageBox.Show($"Please input the reference number for {modeOfPayment} payment.", "POS App", MessageBoxButtons.OK, MessageBoxIcon.Information);
        return;
    }

    // Add payment detail to list
    paymentDetails.Add(new PaymentDetail
    {
        Mode = modeOfPayment,
        ReferenceNumber = referenceNumber,
        Amount = amount
    });

    AddToDGV(modeOfPayment, referenceNumber, amount);

    // Reset inputs
    cboMode.SelectedIndex = 0;
    txtCashTendered.Clear();
    txtRefNum.Clear();
        }

        private void cboMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRefNum.Enabled = cboMode.SelectedItem.ToString() != "Cash";
        }

        private void txtChange_TextChanged(object sender, EventArgs e)
        {
            ComputeChange();
        }

        private void dgvPayment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPayment.Columns[e.ColumnIndex].Name == "Cancel")
            {
                if (dgvPayment.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow row in dgvPayment.SelectedRows)
                    {
                        dgvPayment.Rows.Remove(row);
                    }
                }
                else if (dgvPayment.SelectedCells.Count > 0)
                {
                    int rowIndex = dgvPayment.SelectedCells[0].RowIndex;
                    dgvPayment.Rows.RemoveAt(rowIndex);
                }

                ComputeChange();
            }
        }
         private void ComputeTotalCashTendered()
        {
            double amount = 0;
            foreach (DataGridViewRow row in dgvPayment.Rows)
            {
                amount += Convert.ToDouble(row.Cells["Amount"].Value);
            }
            txtTotal.Text = amount.ToString("#,##0.00");
        }

        private void dgvPayment_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            this.ComputeTotalCashTendered(); // Updates computation when a new row is added in the dgvPayment.
        }

        private void dgvPayment_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            this.ComputeTotalCashTendered(); // Same with line 331, but when removed.
        }

        private void txtCashTendered_TextChanged(object sender, EventArgs e)
        {
            string currentText = txtCashTendered.Text;
            string filteredText = "";
            bool decimals = false;
            int decimalCount = 0;

            foreach (char ch in currentText)
            {
                if (char.IsDigit(ch))
                {
                    if (decimals)
                    {
                        decimalCount++;
                        if (decimalCount <= 2)
                        {
                            filteredText += ch;
                        }
                    }
                    else
                    {
                        filteredText += ch;
                    }
                }
                else if (ch == '.')
                {
                    if (!decimals)
                    {
                        decimals = true;
                        filteredText += ch;
                    }
                }
            }
            txtCashTendered.Text = filteredText;
            txtCashTendered.SelectionStart = txtCashTendered.Text.Length;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Transaction is not yet processed. Are you sure you want to close this form?", "VETCLINIC App", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        public void GetTotalAmount(double totalAmount, double discount)
        {
            label4.Text = totalAmount.ToString("#,##0.00");
            txtTotal.Text = totalAmount.ToString("#,##0.00");
        }
    }
    }

