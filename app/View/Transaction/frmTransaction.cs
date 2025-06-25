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
using System.Globalization;


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
        int TransactionId = 0;
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
            lblDate.Text = DateTime.Now.ToString();
            lblInvoice.Text = DateTime.Now.ToString("yyyyMMddhhmmss");

            using (frmClientPatientForm frmNew = new frmClientPatientForm())
            {
                var result = frmNew.ShowDialog();

                if (result == DialogResult.OK && frmNew.GetPatientId() != 0)
                {
                    this.SelectedPatient = frmNew.GetPatientDetails();
                    this.patientId = frmNew.GetPatientId();

                    txtOwner.Text = frmNew.GetPatientOwnerFullname();
                    txtAddress.Text = frmNew.GetPatientOwnerAddress();
                    txtContact.Text = frmNew.GetPatientOwnerContact();
                    txtPet.Text = frmNew.GetPatientName();
                    txtAge.Text = frmNew.GetPatientAge();
                    txtColor.Text = frmNew.GetPatientColor().Description;
                    txtBreed.Text = frmNew.GetPatientBreed().Description;
                    txtGender.Text = frmNew.GetPatientGender().Description;
                    txtWeight.Text = frmNew.GetPatientWeight();
                    txtBday.Text = frmNew.GetPatientBday();
                    txtSpecie.Text = frmNew.GetPatientSpecie().Description;
                }
                else
                {
                    MessageBox.Show("No valid patient details found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

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
                dgvTransaction.Rows.Add(item.Id, "ClientId", item.Description, item.Stock, item.Price.ToString("N2"));

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
                dgvTransaction.Rows.Add(serviceItem.Id, "ClientId", serviceItem.Description, 1, serviceItem.Price);
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
            double subtotal = 0;

            foreach (DataGridViewRow row in dgvTransaction.Rows)
            {
                if (row.IsNewRow) continue;

                // Parse quantity
                int quantity = int.TryParse(row.Cells["colQuantity"].Value?.ToString(), out int q) ? q : 1;

                // Parse price
                double unitPrice = double.TryParse(row.Cells["colPrice"].Value?.ToString(), out double p) ? p : 0;

                subtotal += quantity * unitPrice;
            }

            // Update subtotal display
            subTotalAmount = subtotal;
            lblSubtotal.Text = subTotalAmount.ToString("N2");

            // Parse doctor fee from label
            double doctorFee = double.TryParse(lblDoctorFee.Text, out double fee) ? fee : 0;

            // Calculate total (subtotal + doctor fee - discounts/other fees)
            totalAmount = subTotalAmount + doctorFee - (discountAmount + otherFeeAmount);
            lblTotalAmount.Text = totalAmount.ToString("N2");
        }

        private List<PaymentDetail> paymentDetails = new List<PaymentDetail>();
        private List<TransactionDetail> transactionDetails = new List<TransactionDetail>();
        private void btnPayment_Click(object sender, EventArgs e)
        {
            ProcessPayment();
        }
        private bool TryGetTotalAmount(out double totalAmount)
        {
            if (!double.TryParse(lblTotalAmount.Text, out totalAmount))
            {
                MessageBox.Show("Invalid total amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private bool ValidateSelectedPatient()
        {
            if (SelectedPatient == null || SelectedPatient.Client == null)
            {
                MessageBox.Show("Patient or client information is missing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private TransactionPayment BuildTransactionPayment(frmPayment payForm, double totalAmount)
        {
            var transPay = new TransactionPayment
            {
                Id = TransactionId,
                InvoiceNumber = lblInvoice.Text,
                Client = new Core.Model.Client { Id = SelectedPatient.Client.Id },
                Pet = new Pet { Id = SelectedPatient.Id },
                TotalAmount = totalAmount,
                ChangeAmount = payForm.GetChangeAmount(),
                Date = DateTime.Now,
                PaymentDetails = new List<PaymentDetail>(),
                TransactionDetails = new List<TransactionDetail>()
            };

            // Add payment details
            foreach (DataGridViewRow row in payForm.dgvPayment.Rows)
            {
                if (row.IsNewRow) continue;

                string mode = row.Cells["ModeOfPayment"]?.Value?.ToString();
                string reference = row.Cells["Reference"]?.Value?.ToString() ?? "";
                if (!double.TryParse(row.Cells["Amount"]?.Value?.ToString(), out double amount))
                {
                    throw new InvalidOperationException("Invalid payment amount in payment details.");
                }

                transPay.PaymentDetails.Add(new PaymentDetail
                {
                    Mode = mode,
                    ReferenceNumber = reference,
                    Amount = amount
                });

                switch (mode)
                {
                    case "Cash": transPay.Cash += amount; break;
                    case "GCash":
                        transPay.GCash += amount;
                        transPay.GCashReferenceNumber = reference;
                        break;
                    case "PayMaya":
                        transPay.PayMaya += amount;
                        transPay.PayMayaReferenceNumber = reference;
                        break;
                }
            }

            // Add transaction details
            foreach (DataGridViewRow row in dgvTransaction.Rows)
            {
                if (row.IsNewRow) continue;

                string description = row.Cells["colDescription"]?.Value?.ToString();

                if (!double.TryParse(row.Cells["colPrice"]?.Value?.ToString(), out double price))
                    throw new InvalidOperationException("Invalid price in transaction details.");

                if (!int.TryParse(row.Cells["colQuantity"]?.Value?.ToString(), out int quantity))
                    throw new InvalidOperationException("Invalid quantity in transaction details.");

                transPay.TransactionDetails.Add(new TransactionDetail
                {
                    Description = description,
                    Quantity = quantity,
                    UnitPrice = price,
                    TotalAmount = quantity * price
                });
            }

            return transPay;
        }

        private bool ValidatePaymentInputs()
        {
            if (string.IsNullOrWhiteSpace(txtOwner.Text) ||
                string.IsNullOrWhiteSpace(txtPet.Text) ||
                string.IsNullOrWhiteSpace(lblInvoice.Text))
            {
                MessageBox.Show("Please make sure owner, pet, and invoice details are filled in.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void ProcessPayment()
        {
            if (!ValidatePaymentInputs()) return;

            if (!TryGetTotalAmount(out double totalAmount)) return;

            string clientName = txtOwner.Text.Trim();
            string petName = txtPet.Text.Trim();
            string invoiceNumber = lblInvoice.Text.Trim();
            int clientId = SelectedPatient?.Client?.Id ?? 0;
            int petId = SelectedPatient?.Id ?? 0;

            var transactionDetails = BuildTransactionDetails();
            if (transactionDetails == null || transactionDetails.Count == 0)
            {
                MessageBox.Show("No valid transaction details found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (frmPayment payForm = new frmPayment(
                transactionDetails,
                totalAmount,
                clientId,
                clientName,
                petId,
                petName,
                invoiceNumber,
                SelectedPatient?.Client,
                SelectedPatient
            ))
            {
                payForm.ShowDialog();

                if (payForm.ProceedPayment())
                {
                    NewTransaction();
                    ClearFields();
                }
            }
        }
        private List<TransactionDetail> BuildTransactionDetails()
        {
            var transactionDetails = new List<TransactionDetail>();

            foreach (DataGridViewRow row in dgvTransaction.Rows)
            {
                if (row.IsNewRow) continue;

                string description = row.Cells["colDescription"]?.Value?.ToString() ?? "";

                int productId = 0;
                if (row.Cells["colId"]?.Value != null)
                {
                    int.TryParse(row.Cells["colId"].Value.ToString(), out productId);
                }

                if (!double.TryParse(row.Cells["colPrice"]?.Value?.ToString(), out double price))
                {
                    MessageBox.Show("Invalid price in transaction details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

                if (!int.TryParse(row.Cells["colQuantity"]?.Value?.ToString(), out int quantity))
                {
                    MessageBox.Show("Invalid quantity in transaction details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

                transactionDetails.Add(new TransactionDetail
                {
                    ProductId = productId,
                    Description = description,
                    Quantity = quantity,
                    UnitPrice = price,
                    TotalAmount = quantity * price
                });
            }

            return transactionDetails;
        }



        public Pet SelectedPatient { get; set; }


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

                dgvTransaction.Rows.Clear();
                lblTotalAmount.Text = "0.00";
                localStockCount.Clear();
            }
        }

        public void ClearFields()
        {
            txtOwner.Text = "";
            txtAddress.Text = "";
            txtContact.Text = "";
            txtPet.Text = "";
            txtAge.Text = "";
            txtColor.Text = "";
            txtBreed.Text = "";
            txtGender.Text = "";
            txtWeight.Text = "";
            txtBday.Text = "";
            txtSpecie.Text = "";
            lblTotalAmount.Text = "0.00";
            lblDoctorFee.Text = "0.00";
            lblSubtotal.Text = "0.00";
            dgvTransaction.Rows.Clear();
            localStockCount.Clear();
            SelectedPatient = null;
        }

        private Dictionary<int, Diagnosis> diagnosis = new Dictionary<int, Diagnosis>(); //  class-level field
        private Diagnosis SelectedPet = null;

        private void btnAddConsult_Click(object sender, EventArgs e)
        {
            this.New();
            lblDate.Text = DateTime.Now.ToString();
            using (var frm = new frmConsultationLookUp())
            {
                if (frm.ShowDialog() == DialogResult.OK && frm.SelectedOwner != null && frm.SelectedPet != null)
                {
                    var owner = frm.SelectedOwner;
                    var pet = frm.SelectedPet;

                    // Owner Info
                    txtOwner.Text = owner.GetFullName();
                    txtAddress.Text = owner.GetFullAddress();
                    txtContact.Text = owner.GetAllContact();

                    // Pet Info
                    txtPet.Text = pet.Name;
                    txtAge.Text = pet.Age;
                    txtColor.Text = pet.ColourPattern.Description;
                    txtBreed.Text = pet.Breed.Description;
                    txtGender.Text = pet.Gender.Description;
                    txtWeight.Text = pet.Weight; // optional, if you included in Pet
                    txtBday.Text = pet.BirthDate;
                    txtSpecie.Text = pet.Specie.Description;

                    // Clear and reset
                    lblDoctorFee.Text = "200.00";
                    lblSubtotal.Text = lblDoctorFee.Text;
                    lblTotalAmount.Text = "0.00";
                    dgvTransaction.Rows.Clear();
                    localStockCount.Clear();

                    SelectedPatient = pet;
                }
            }
        }
            //Dictionary<int, app.core.model.Diagnosis> diagnosis = new Dictionary<int, core.model.Diagnosis>();
            void LoadConsultationList(Dictionary<int, app.core.model.Diagnosis> diagnosis)
            {
                foreach (KeyValuePair<int, app.core.model.Diagnosis> key in diagnosis)
                {
                    var consultationItem = key.Value; // Get the service item
                    dgvTransaction.Rows.Add(consultationItem.Id, "ClientId", consultationItem.Patient, consultationItem.MedicationsWithFrequency, 1);
                }

                CalculateTotalPrice();
            }
        }
    }

