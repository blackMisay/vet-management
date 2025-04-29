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

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtTotal.Text) || String.IsNullOrWhiteSpace(txtTotal.Text))
            {
                MessageBox.Show("Please enter amount.");
                return;
            }

            if (Convert.ToDouble(txtTotal.Text) < this.totalAmount)
            {
                MessageBox.Show("Invalid entered amount");
                return;
            }

            this.changeAmount = Convert.ToDouble(txtTotal.Text) - this.totalAmount;
            
            this.lblChangeAmount.Text = "Change Amount: " + this.changeAmount.ToString("N2");

            if (MessageBox.Show("Do you want to proceed on the payment?","Payment",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                isPaymentSuccess = true;
                this.Close();
            }
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
            double total = Convert.ToDouble(this.lblTotalAmount.Text);
            double paid = dgvPayment.Rows.Cast<DataGridViewRow>().Sum(row => Convert.ToDouble(row.Cells["Amount"].Value.ToString()));
            double change = paid - total;

            if (change > 0)
            {
                txtChange.Text = change.ToString("#,##0.00");
            }
            else
            {
                txtChange.Text = "0.00";
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string modeOfPayment = Mode(cboMode.SelectedIndex);
            string referenceNumber = txtRefNum.Text;
            double amount;

            if (!double.TryParse(txtCashTendered.Text, out amount))
            {
                MessageBox.Show("Invalid amount entered. Please enter a valid numeric value.", "POS App", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if ((modeOfPayment == "GCash" || modeOfPayment == "PayMaya") && string.IsNullOrEmpty(referenceNumber))
            {
                MessageBox.Show("Please input the reference number for " + modeOfPayment + " payment.", "POS App", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            AddToDGV(modeOfPayment, referenceNumber, amount);

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

