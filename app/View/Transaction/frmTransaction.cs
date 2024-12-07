using app.view.Utilities;
using System;
using System.Windows.Forms;
using app.Core.Model;


namespace app.view.Transaction
{
    public partial class frmTransaction : Form
    {
        int patientId = 0;
        int selectedRecord = 0;

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
            frmItemLookUp frm = new frmItemLookUp();
            frm.ShowDialog();
        }

        private void btnServiceLookUp_Click(object sender, EventArgs e)
        {
            frmServiceLookUp frm = new frmServiceLookUp();
            frm.ShowDialog();
        }

        private void btnQuantity_Click(object sender, EventArgs e)
        {
            frmItemQuantity frm = new frmItemQuantity();
            frm.ShowDialog();
        }
    }
}
