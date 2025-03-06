using app.view.Utilities;
using System;
using System.Windows.Forms;
using app.Core.Model;
using System.Collections.Generic;


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
            lblProductPrice.Text = $"₱   {price:N2}";
        }

        private void btnNewTrans_Click(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString();
            lblInvoice.Text = DateTime.Now.ToString("yyyyMMddhhmmss");
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
            frmItemQuantity frm = new frmItemQuantity();
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
    }
}
