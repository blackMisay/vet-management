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
using System.Text.RegularExpressions;
using Core;
using System.Windows.Forms.VisualStyles;

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
            PopulateCmb();
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

            this.Dispose();
        }

        private void frmClientModal_Load(object sender, EventArgs e)
        {
      
            if (this.Id > 0)
            {
                LoadClientDetails();
            }
        }

        private void cboRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cboRegion_SelectionChangeCommitted(object sender, EventArgs e)
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

        private void cboCity_SelectionChangeCommitted(object sender, EventArgs e)
        {
            UpgradeFile upgradeFile = new UpgradeFile();

            cboBrgy.DataSource = upgradeFile.Populate("SELECT brgy_code, description FROM addr_brgy where citymun_code='" + cboCity.SelectedValue.ToString() + "';");
            cboBrgy.ValueMember = "Key";
            cboBrgy.DisplayMember = "Value";
        }


        //private void cboBrgy_Click(object sender, EventArgs e)
        //{
        //    UpgradeFile upgradeFile = new UpgradeFile();

        //    cboBrgy.DataSource = upgradeFile.Populate("SELECT id, description FROM addr_brgy where citymun_code='" + cboCity.SelectedValue.ToString() + "';");
        //    cboBrgy.ValueMember = "Key";
        //     cboBrgy.DisplayMember = "Value";
        // }

        private void SaveClient()
        {
            // Create a new client instance and set properties from input fields
            Core.Model.Client client = new Core.Model.Client
            {
                Id = this.Id,
                FirstName = txtFname.Text,
                LastName = txtLname.Text,
                MiddleName = txtMname.Text,
                Suffix = txtSuffix.Text,
                PhoneNumber = txtPhone.Text,
                MobileNumber = txtMobile.Text,
                EmailAddress = txtEmail.Text,
                StreetNo = richHousenum.Text,
                Region = new Core.Model.Region() { Id = Convert.ToInt32(cboRegion.SelectedValue) },
                City = new City() { Id = Convert.ToInt32(cboCity.SelectedValue) },
                Brgy = new Barangay() { Id = Convert.ToInt32(cboBrgy.SelectedValue) },
                Province = new Province() { Id = Convert.ToInt32(cboProvince.SelectedValue) }
            };

            // Validate email address format
            if (!client.EmailAddress.Contains("@"))
            {
                MessageBox.Show("Invalid Email Address");
                txtEmail.Focus(); // Set focus to the email input field
                return; // Exit the method if the email is invalid
            }

            // Attempt to save the client
            ClientRepository clientRepository = new ClientRepository();
            if (clientRepository.Save(client))
            {
                MessageBox.Show("Saved successfully");
            }
            else
            {
                MessageBox.Show("Unable to save record");
            }
        }

        private void LoadDetails(app.Core.Model.Client client)
        {
            PopulateCmb();
            txtFname.Text = client.FirstName;
            txtLname.Text = client.LastName;
            txtMname.Text = client.MiddleName;
            txtSuffix.Text = client.Suffix;
            txtPhone.Text = client.PhoneNumber;
            txtMobile.Text = client.MobileNumber;
            txtEmail.Text = client.EmailAddress;
            richHousenum.Text = client.StreetNo;
            //TODO: Fix fetch
            cboRegion.SelectedValue = client.Region.Id;
            cboCity.SelectedValue = client.City.Id;
            cboBrgy.SelectedValue = client.Brgy.Id;
            cboProvince.SelectedValue = client.Province.Id;
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
    
