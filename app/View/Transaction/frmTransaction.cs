using app.view.Utilities;
using System;
using System.Windows.Forms;
using app.Core.Model;
using System.Collections.Generic;
using app.view.Consultation;
using app.core.model;
using System.Diagnostics;
using app.core.repository;


namespace app.view.Transaction
{
    public partial class frmTransaction : Form
    {
        int patientId = 0;
        int selectedRecord = 0;

        double subTotalAmount = 0;
        double totalAmount = 0;
        double discountAmount = 0;
        double otherFeeAmount = 0;

        public frmTransaction()
        {
            InitializeComponent();
            decimal price = 0.000m; // Example price
            lblTotal.Text = $"{price:N2}"; // Format as currency with 2 decimal places
            lblSubTotal.Text = $"{price:N2}";
           
        }
        
        private void btnNewTrans_Click(object sender, EventArgs e)
        {
            // Set the current date and invoice number
            lblDate.Text = DateTime.Now.ToString();
            lblInvoice.Text = DateTime.Now.ToString("yyyyMMddhhmmss");

            frmClientPatientForm frmNew = new frmClientPatientForm();
            frmNew.ShowDialog();
            if (frmNew.GetPatientId() != 0) 
            {
                this.SelectedPatient = frmNew.GetPatientDetails();
                this.patientId = frmNew.GetPatientId();
                txtName.Text = frmNew.GetPatientOwnerFullname(); 
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
        private void btnVoidItem_Click(object sender, EventArgs e)
        {

        }

        private void CalculateTotalPrice()
        {
            foreach (DataGridViewRow row in dgvTransaction.Rows)
            {
                this.subTotalAmount += Convert.ToDouble(row.Cells["colQuantity"].Value) * Convert.ToDouble(row.Cells["colPrice"].Value);
            }

            this.lblSubTotal.Text = subTotalAmount.ToString("N2");

            this.totalAmount = (subTotalAmount - (discountAmount + otherFeeAmount));

            this.lblTotal.Text = totalAmount.ToString("N2");
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            if (lblSubTotal.Text == "0.00")//₱
            {
                return;
            }
            using (frmPayment pay = new frmPayment(Convert.ToDouble(lblSubTotal.Text)))
            {
                pay.ShowDialog();

                if (pay.ProceedPayment())
                {
                    TransactionPayment transPay = new TransactionPayment();
                    
                    transPay.InvoiceNumber = lblInvoice.Text;
                    transPay.Client = new app.Core.Model.Client { Id = SelectedPatient.Client.Id };
                    transPay.Pet = new Pet { Id = SelectedPatient.Id };
                    transPay.SubTotalAmount = this.subTotalAmount;
                    transPay.TotalAmount = this.totalAmount;
                    transPay.ChangeAmount = pay.GetChangeAmount();

                    TransactionPaymentRepository transPayService = new TransactionPaymentRepository();
                    if (transPayService.Save(transPay))
                    {
                        MessageBox.Show("Payment Completed!");
                    }
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
    }
}
