using app.view.Utilities;
using System;
using System.Windows.Forms;
using app.Core.Model;
using System.Collections.Generic;
using app.view.Consultation;
using app.core.model;
using System.Diagnostics;
using app.core.repository;
using System.Reflection.Emit;
using System.Linq;
using Core;


namespace app.view.Transaction
{
    public partial class frmTransaction : Form
    {
        int patientId = 0;
        int selectedRecord = 0;
        private Dictionary<int, int> localStockCount = new Dictionary<int, int>();
        double subTotalAmount = 0;
        double totalAmount = 0;
        double discountAmount = 0;
        double otherFeeAmount = 0;

        public frmTransaction()
        {
            InitializeComponent();
            decimal price = 0.000m; // Example price
            lblTotalAmount.Text = $"{price:N2}"; // Format as currency with 2 decimal places
           
        }

        public void New()
        {
            lblInvoice.Text = DateTime.Now.ToString("yyMMddHHmmss");
            btnNewTrans.Enabled = false;
            btnServiceLookUp.Enabled = true;
            btnVoidItem.Enabled = true;
            btnVoidTrans.Enabled = true;
            btnPayment.Enabled = true;
            btnItemLookUp.Enabled = true;
            panel1.Enabled = true;
        }

        public void NewTransaction()
        {
            lblInvoice.Text = "000000000000";
            btnNewTrans.Enabled = true;
            btnServiceLookUp.Enabled = false;
            btnVoidItem.Enabled = false;
            btnVoidTrans.Enabled = false;
            btnItemLookUp.Enabled = false;
            btnPayment.Enabled = false;
            this.KeyPreview = true;
            txtPet.Text = "";
            lblTotalAmount.Text = "0.00";
            dgvTransaction.Rows.Clear();
        }

        private void btnNewTrans_Click(object sender, EventArgs e)
        {
            this.New();
            // Set the current date and invoice number
            lblDate.Text = DateTime.Now.ToString();
            lblInvoice.Text = DateTime.Now.ToString("yyyyMMddhhmmss");

            frmClientPatientForm frmNew = new frmClientPatientForm();
            frmNew.ShowDialog();
            if (frmNew.GetPatientId() != 0) 
            {
                this.SelectedPatient = frmNew.GetPatientDetails();
                this.patientId = frmNew.GetPatientId();
                txtPet.Text = frmNew.GetPatientName();
            }
            else
            {
                MessageBox.Show("No valid patient details found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            frmClientPatientForm cpf = new frmClientPatientForm();
            cpf.ShowDialog();
            this.patientId = cpf.GetPatientId();
            txtPet.Text = cpf.GetPatientName();
            cpf.Dispose();
        }

        
        private void btnItemLookUp_Click(object sender, EventArgs e)
        {
            if (dgvTransaction.RowCount > 0)
            {
                using (frmItemLookUp frm = new frmItemLookUp(items))
                {
                    frm.ShowDialog();

                    items = frm.GetAllItems();
                    dgvTransaction.Rows.Clear();
                    LoadServiceList(service);
                    LoadItemList(items);

                    frm.Dispose();
                }
            }
            else
            {
                using (frmItemLookUp frm = new frmItemLookUp())
                {
                    frm.ShowDialog();

                    items = frm.GetAllItems();
                    LoadServiceList(service);
                    LoadItemList(items);

                    frm.Dispose();
                }
            }
        }

        Dictionary<int, app.core.model.Inventory> items = new Dictionary<int, core.model.Inventory>();
        void LoadItemList(Dictionary<int, app.core.model.Inventory> items)
        {
            app.core.model.Inventory item = new app.core.model.Inventory();
           
            foreach (KeyValuePair<int, app.core.model.Inventory> kvp in items)
            {
                item = kvp.Value;
                dgvTransaction.Rows.Add(item.Id,"ClientId",item.Description,item.Qty,item.UnitPrice.ToString("N2"));

            }

            CalculateTotalPrice();
        }
        private void btnServiceLookUp_Click(object sender, EventArgs e)
        {
            if (dgvTransaction.RowCount > 0)
            {
                using (frmServiceLookUp frm = new frmServiceLookUp(service))
                {
                    frm.ShowDialog();

                    service = frm.GetAllServices();
                    dgvTransaction.Rows.Clear();
                    LoadServiceList(service);
                    LoadItemList(items);

                    frm.Dispose();
                }
            }
            else
            {
                using (frmServiceLookUp frm = new frmServiceLookUp())
                {
                    frm.ShowDialog();

                    service = frm.GetAllServices();
                    LoadServiceList(service);
                    LoadItemList(items);

                    frm.Dispose();
                }
            }
        }
        
        Dictionary<int, app.core.model.Services> service = new Dictionary<int, core.model.Services>();
        void LoadServiceList(Dictionary<int, app.core.model.Services> service)
        {
            foreach (KeyValuePair<int, app.core.model.Services> key in service)
            {
                var serviceItem = key.Value; // Get the service item
                dgvTransaction.Rows.Add(serviceItem.Id, "ClientId", serviceItem.Description, 1,serviceItem.Price);
            }

            CalculateTotalPrice();
        }

        private void VoidItem()
        {
            if (dgvTransaction.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvTransaction.SelectedRows[0];
                int id = Convert.ToInt32(selectedRow.Cells["colId"].Value);
                string productDesc = Convert.ToString(selectedRow.Cells["colDescription"].Value);
                int quantity = Convert.ToInt32(selectedRow.Cells["colQuantity"].Value);
                decimal price = Convert.ToDecimal(selectedRow.Cells["colPrice"].Value);

                decimal itemTotal = price * quantity;

                dgvTransaction.Rows.Remove(selectedRow);

                if (localStockCount.ContainsKey(id))
                {
                    localStockCount[id] -= quantity;
                    if (localStockCount[id] < 0)
                    {
                        localStockCount[id] = 0;
                    }
                }

                // If no more rows, clear the label
                if (dgvTransaction.Rows.Count == 0)
                {
                    lblTotalAmount.Text = "0.00";
                }
                else
                {
                    // Recalculate from lblTotalAmount
                    if (decimal.TryParse(lblTotalAmount.Text, System.Globalization.NumberStyles.Currency, null, out decimal currentTotal))
                    {
                        decimal newTotal = currentTotal - itemTotal;
                        lblTotalAmount.Text = newTotal.ToString("0.00");
                    }
                    else
                    {
                        lblTotalAmount.Text = "0.00";
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an item to delete.", "Remove", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnVoidItem_Click(object sender, EventArgs e)
        {
            this.VoidItem();
        }

        private void CalculateTotalPrice()
        {
            foreach (DataGridViewRow row in dgvTransaction.Rows)
            {
                this.subTotalAmount += Convert.ToDouble(row.Cells["colQuantity"].Value) * Convert.ToDouble(row.Cells["colPrice"].Value);
            }

            
            this.totalAmount = (subTotalAmount - (discountAmount + otherFeeAmount));

            this.lblTotalAmount.Text = totalAmount.ToString("N2");
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            using (frmPayment pay = new frmPayment(Convert.ToDouble(lblTotalAmount.Text)))
            {
                pay.ShowDialog();

                if (pay.ProceedPayment())
                {
                    TransactionPayment transPay = new TransactionPayment();
                    
                    transPay.InvoiceNumber = lblInvoice.Text;
                    transPay.Client = new app.Core.Model.Client { Id = SelectedPatient.Client.Id };
                    transPay.Pet = new Pet { Id = SelectedPatient.Id };
                    transPay.TotalAmount = this.totalAmount;
                    transPay.ChangeAmount = pay.GetChangeAmount();

                    TransactionPaymentRepository transPayService = new TransactionPaymentRepository();
                    if (transPayService.Save(transPay))
                    {
                        MessageBox.Show("Payment Completed!");
                        
                    }
                    this.NewTransaction();
                }
            }
        }

        public Pet SelectedPatient { get; set; }
        private void GetPatient()
        {
            frmClientPatientForm frm = new frmClientPatientForm();

            if (frm.ShowDialog() == DialogResult.OK) // Ensure user confirms selection
            {
                Pet selectedPet = frm.GetPatientDetails(); // ✅ Retrieve patient details correctly

                if (selectedPet != null) // Ensure a valid patient is selected
                {
                    SelectedPatient = selectedPet;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No valid patient details found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnVoidTrans_Click(object sender, EventArgs e)
        {
            VoidEntireTransaction();
        }
        private void VoidEntireTransaction()
        {
            if (dgvTransaction.Rows.Count == 0)
            {
                MessageBox.Show("There are no items to void.", "Void Transaction", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult confirm = MessageBox.Show("Are you sure you want to void the entire transaction?",
                                                   "Confirm Void", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                // Loop through and restore stock
                foreach (DataGridViewRow row in dgvTransaction.Rows)
                {
                    if (row.IsNewRow) continue;

                    int id = Convert.ToInt32(row.Cells["colId"].Value);
                    int quantity = Convert.ToInt32(row.Cells["colQuantity"].Value);

                    if (localStockCount.ContainsKey(id))
                    {
                        localStockCount[id] -= quantity;
                        if (localStockCount[id] < 0)
                            localStockCount[id] = 0;
                    }
                }

                // Clear DataGridView
                dgvTransaction.Rows.Clear();
                txtPet.Text = string.Empty;
                btnNewTrans .Enabled = true;
                lblDate.Text = string.Empty;
                lblInvoice.Text = string.Empty;

                // Clear total amount label
                lblTotalAmount.Text = "0.00";

                MessageBox.Show("Transaction has been voided.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
