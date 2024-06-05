﻿using app.Core.Model;
using app.Core.Repository;
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
using System.Xml.Linq;

namespace app.view.Client
{
    public partial class frmClientModal : Form
    {
        app.Core.Model.Client client;
        private int Id = 0;
        public frmClientModal()
        {
            InitializeComponent();
            this.Load += frmClientModal_Load;
            //TODO: Populating combobox data.
        }

        public frmClientModal(int clientId)
        {
            InitializeComponent();
            this.Id = clientId;
            this.Load += frmClientModal_Load;
            btnSave.Text = "Update";
            label1.Text = "Update Client Information";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Ask the user for confirmation before canceling
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to cancel your work?", "Confirm Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show("Work has been cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Save pet details
            SaveClient();

            // Load the data into the DataGridView of frmClient
            UpgradeFile upgradeFile = new UpgradeFile();
            frmClient clientForm = new frmClient();

            // Ensure dgvPatient is accessed properly
            clientForm.dgvClient.DataSource = upgradeFile.Load("SELECT * FROM vwclient WHERE isDeleted = 0");

            // Show the frmClient form (optional, depends on your application flow)
            clientForm.Show();

            // Dispose of the current form
            this.Dispose();
        }

        private void frmClientModal_Load(object sender, EventArgs e)
        {
            PopulateCmb();
            if (this.Id > 0)
            {
                LoadClientDetails();
            }
        }

        private void cboRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpgradeFile upgradeFile = new UpgradeFile();

            cboProvince.DataSource = upgradeFile.Populate("SELECT province_code, description FROM addr_province WHERE region_code='" + cboRegion.SelectedValue.ToString() + "';");
            cboProvince.ValueMember = "Key";
            cboProvince.DisplayMember = "Value";
        }


        private void cboProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpgradeFile upgradeFile = new UpgradeFile();

            cboCity.DataSource = upgradeFile.Populate("SELECT citymun_code, description FROM addr_city where province_code='" + cboProvince.SelectedValue.ToString() + "';");
            cboCity.ValueMember = "Key";
            cboCity.DisplayMember = "Value";
        }

        private void SaveClient()
        {
            Core.Model.Client client = new Core.Model.Client();
            client.Id = this.Id;
            client.FirstName = txtFname.Text;
            client.LastName = txtLname.Text;
            client.MiddleName = txtMname.Text;
            client.Suffix = txtSuffix.Text;
            client.CivilStatus = cboStatus.Text;
            client.Gender = cboSex.Text;
            client.PhoneNumber = txtPhone.Text;
            client.MobileNumber = txtMobile.Text;
            client.BirthDate = dtpBday.Value.ToString("yyyy-MM-dd");
            client.EmailAddress = txtEmail.Text;
            client.StreetNo = richHousenum.Text;
            client.Region = new Core.Model.Region() { Id = Convert.ToInt32(cboRegion.SelectedValue) };
            client.City = new City() { Id = Convert.ToInt32(cboCity.SelectedValue) };
            client.Brgy = new Barangay() { Id = Convert.ToInt32(cboBrgy.SelectedValue) };
            client.Province = new Province() { Id = Convert.ToInt32(cboProvince.SelectedValue) };


            ClientRepository clientRepository = new ClientRepository();
            if (clientRepository.Save(client))
            {
                MessageBox.Show("Save successfully");
            }
            else
            {
                MessageBox.Show("Unable to save record");
            }
        }      
        private void cboCity_Click(object sender, EventArgs e)
        {
            UpgradeFile upgradeFile = new UpgradeFile();

            cboBrgy.DataSource = upgradeFile.Populate("SELECT id, description FROM addr_brgy where citymun_code='" + cboCity.SelectedValue.ToString() + "';");
            cboBrgy.ValueMember = "Key";
            cboBrgy.DisplayMember = "Value";
        }

        private void cboBrgy_Click(object sender, EventArgs e)
        {
            UpgradeFile upgradeFile = new UpgradeFile();

            cboBrgy.DataSource = upgradeFile.Populate("SELECT id, description FROM addr_brgy where citymun_code='" + cboCity.SelectedValue.ToString() + "';");
            cboBrgy.ValueMember = "Key";
            cboBrgy.DisplayMember = "Value";
        }
        private void LoadDetails(app.Core.Model.Client client)
        {
            txtFname.Text = client.FirstName;
            txtLname.Text = client.LastName;
            txtMname.Text = client.MiddleName;
            txtSuffix.Text = client.Suffix;
            cboStatus.Text = client.CivilStatus;
            cboSex.Text = client.Gender;
            txtPhone.Text = client.PhoneNumber;
            txtMobile.Text = client.MobileNumber;
            dtpBday.Text = client.BirthDate;
            txtEmail.Text = client.EmailAddress;
            richHousenum.Text = client.StreetNo;
            cboRegion.SelectedIndex = client.Region.Id-1;
            cboCity.SelectedIndex = client.City.Id-1;
            cboBrgy.SelectedIndex = client.Brgy.Id - 1;
            cboProvince.SelectedIndex = client.Province.Id - 1;
        }
        private void LoadClientDetails()
        {
            ClientRepository client = new ClientRepository();
            var clients = client.GetClientInfoDetails(new app.Core.Model.Client() { Id = this.Id });
            if (clients != null)
            {
                LoadDetails(clients);
            }
        }

        private void PopulateCmb()
        {
            //TODO: When updating load all fetch data to each components.
            UpgradeFile upgradeFile = new UpgradeFile();

            cboRegion.DataSource = upgradeFile.Populate("SELECT code, description FROM addr_region;");
            cboRegion.ValueMember = "Key";
            cboRegion.DisplayMember = "Value";

            cboProvince.DataSource = upgradeFile.Populate("SELECT province_code, description FROM addr_province;");
            cboProvince.ValueMember = "Key";
            cboProvince.DisplayMember = "Value";

            cboBrgy.DataSource = upgradeFile.Populate("SELECT brgy_code, description FROM addr_brgy;");
            cboBrgy.ValueMember = "Key";
            cboBrgy.DisplayMember = "Value";

            cboCity.DataSource = upgradeFile.Populate("SELECT citymun_code, description FROM addr_city;");
            cboCity.ValueMember = "Key";
            cboCity.DisplayMember = "Value";
        }
    }
}
