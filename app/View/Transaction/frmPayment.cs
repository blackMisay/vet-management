using app.core.model;
using app.core.repository;
using app.Core.Model;
using app.view.Client;
using app.view.Utilities;
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
    public partial class frmPayment : Form
    {

        double totalAmount = 0;
        double changeAmount = 0;
        bool isPaymentSuccess = false;
        frmClientPatientForm frmClientPatientForm;
        private int clientId;
        private int petId;
        private string clientName;
        private string petName;
        private string invoiceNumber;
        private List<TransactionDetail> _details;
        private app.Core.Model.Client selectedClient;
        private Pet selectedPet;

        public frmPayment()
        {
            InitializeComponent();
        }
        public frmPayment(frmTransaction frm)
        {
            InitializeComponent();

        }
        public frmPayment(List<TransactionDetail> transactionDetails, double totalAmount,
            int clientId, string clientName, int petId, string petName, string invoiceNumber,
            app.Core.Model.Client selectedClient = null,
            Pet selectedPet = null)
        {
            InitializeComponent();
            this.transactionDetails = transactionDetails;
            this.totalAmount = totalAmount;
            this.clientId = clientId;
            this.clientName = clientName;
            this.petId = petId;
            this.petName = petName;
            this.invoiceNumber = invoiceNumber;
            this.selectedClient = selectedClient;
            this.selectedPet = selectedPet;
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
            lblClient.Text = selectedClient != null
        ? $"{selectedClient.FirstName} {selectedClient.LastName}"
        : clientName;

            lblPet.Text = selectedPet?.Name ?? petName;
            lblTotalAmount.Text = totalAmount.ToString("N2");
        }

        private TransactionPayment payment = new TransactionPayment();
        private bool PaymentSuccess = false;
        private void btnPay_Click(object sender, EventArgs e)
        {
            double enteredAmount;

            if (!double.TryParse(txtTotal.Text, out enteredAmount))
            {
                MessageBox.Show("Invalid amount. Please enter a valid number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (enteredAmount < totalAmount)
            {
                MessageBox.Show("Entered amount is less than the total due.", "Insufficient Amount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            changeAmount = enteredAmount - totalAmount;
            lblChangeAmount.Text = "Change Amount: " + changeAmount.ToString("N2");

            if (MessageBox.Show("Do you want to proceed with the payment?", "Confirm Payment", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                payment.TotalAmount = totalAmount;
                payment.ChangeAmount = changeAmount;
                payment.Cash = enteredAmount; // ✅ this is now in scope

                payment.Client = selectedClient ?? new app.Core.Model.Client { Id = clientId };
                payment.Pet = selectedPet ?? new Pet { Id = petId };
                payment.InvoiceNumber = invoiceNumber;
                payment.Date = DateTime.Now;
                payment.PaymentDetails = paymentDetails;
                payment.TransactionDetails = transactionDetails;

                try
                {
                    var repository = new TransactionPaymentRepository();
                    bool saved = repository.SavePayment(payment);

                    if (saved)
                    {
                        isPaymentSuccess = true;
                        MessageBox.Show("Payment Complete. Success.", "Save Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ShowReceiptPrintPreview(payment, paymentDetails);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed to save payment. Please try again.", "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ShowReceiptPrintPreview(TransactionPayment payment, List<PaymentDetail> paymentDetails)
        {
            if (payment == null)
                throw new ArgumentNullException(nameof(payment));

            if (paymentDetails == null)
                paymentDetails = new List<PaymentDetail>(); // fallback to empty if not available

             var receiptForm = new frmReceipt(payment, paymentDetails);
            receiptForm.ShowPreview();
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
        private List<TransactionDetail> transactionDetails = new List<TransactionDetail>();
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

