using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using app.Core;
using app.Core.Repository;
using app.View.Administration;
using app.View.Inventory;
using app.View.Patient;
using app.View.Product;
using app.View.Reports;
using app.View.Transaction;

namespace app
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddClient patient = new AddClient();
            patient.ShowDialog();
        }

        private void btnAddPet_Click(object sender, EventArgs e)
        {
            PetDetails pet = new PetDetails();
            pet.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            PatientList list = new PatientList();
            list.ShowDialog();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            Products prod = new Products();
            prod.ShowDialog();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            PatientList patient = new PatientList();
            patient.ShowDialog();
        }

        private void tspInventory_Click(object sender, EventArgs e)
        {
            FrmInventory invent = new FrmInventory();
            invent.ShowDialog();
        }

        private void tspReport_Click(object sender, EventArgs e)
        {
            Report report = new Report();
            report.ShowDialog();
        }

        private void tspTransact_Click(object sender, EventArgs e)
        {
            FrmTransaction transaction = new FrmTransaction();
            transaction.ShowDialog();
        }

        private void tspAdmin_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            admin.ShowDialog();
        }

        private void toolStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnOut_Click(object sender, EventArgs e)
        {
           this.Close();
        }
    }
    }