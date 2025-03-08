using app.view.Utilities;
using System;
using System.Windows.Forms;
using app.Core.Model;
using System.Collections.Generic;
using app.view.Consultation;


namespace app.view.Transaction
{
    public partial class frmTransaction : Form
    {
        int patientId = 0;
        int selectedRecord = 0;
        double totalAmount = 0;
        
        public frmTransaction()
        {
            InitializeComponent();
            decimal price = 0.000m; // Example price
            lblTotal.Text = $"₱   {price:N2}"; // Format as currency with 2 decimal places
            lblDeposit.Text = $"₱   {price:N2}";
            lblSubtotal.Text = $"₱   {price:N2}";
            lblBalance.Text = $"₱   {price:N2}";
           
        }
        
        private void btnNewTrans_Click(object sender, EventArgs e)
        {
            // Set the current date and invoice number
            lblDate.Text = DateTime.Now.ToString();
            lblInvoice.Text = DateTime.Now.ToString("yyyyMMddhhmmss");

            // Ask the user if it's an existing patient
            DialogResult result = MessageBox.Show(
                "Is this transaction for an existing patient?",
                "Patient Type",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes) // Existing patient → Open Consultation Form
            {
                frmConsultation frm = new frmConsultation();

                if (frm.ShowDialog() == DialogResult.OK && frm.SelectedRecord != null)
                {
                    this.patientId = frm.SelectedRecord.Id; // Store patient ID
                    txtName.Text = frm.SelectedRecord.Client.GetFullName(); // Display full client name
                    txtPet.Text = frm.SelectedRecord.Name; // Display pet name
                }
                else
                {
                    MessageBox.Show("No patient selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else // New patient → Open Client Patient Form
            {
                //frmClientPatientForm frmNew = new frmClientPatientForm();

                if (result== DialogResult.No) 
                {
                    frmClientPatientForm frmNew = new frmClientPatientForm();
                    //Pet selectedPatient = frmNew.GetPatientDetails();

                    if (frmNew.ShowDialog() == DialogResult.OK && frmNew.SelectedPatient != null) 
                    {
                        this.patientId = frmNew.SelectedPatient.Id; 
                        txtName.Text = frmNew.SelectedPatient.Client.GetFullName(); 
                        txtPet.Text = frmNew.SelectedPatient.Name; 
                    }
                    else
                    {
                        MessageBox.Show("No valid patient details found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No new patient selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
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


        private void btnQuantity_Click(object sender, EventArgs e)
        {
            frmTransactionDeposit frm = new frmTransactionDeposit();
            frm.ShowDialog();

        }
        private void btnVoidItem_Click(object sender, EventArgs e)
        {

        }

        private void CalculateTotalPrice()
        {
            totalAmount = 0;
            foreach (DataGridViewRow row in dgvTransaction.Rows)
            {
                totalAmount += Convert.ToDouble(row.Cells["colQuantity"].Value) * Convert.ToDouble(row.Cells["colPrice"].Value);
            }

            this.lblTotal.Text = totalAmount.ToString("N2");
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {

        }

        public app.Core.Model.Pet SelectedPatient { get; private set; }
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
