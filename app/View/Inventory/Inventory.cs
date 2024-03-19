﻿using app.View.Administration;
using app.View.Patient;
using app.View.Product;
using app.View.Reports;
using app.View.Transaction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace app.View.Inventory
{
    public partial class FrmInventory : Form
    {
        public FrmInventory()
        {
            InitializeComponent();
        }

        private void Inventory_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void tspInventory_Click(object sender, EventArgs e)
        {
            
        }

        private void tspProduct_Click(object sender, EventArgs e)
        {
            Products products = new Products();
            products.ShowDialog();
        }

        private void tspClient_Click(object sender, EventArgs e)
        {
            PatientList patientList = new PatientList();
            patientList.ShowDialog();
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
    }
}
