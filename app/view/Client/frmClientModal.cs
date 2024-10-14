using app.Core.Model;
using app.Core.Repository;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using app.Core;
using Core;

namespace app.view.Client
{
    public partial class frmClientModal : Form
    {
        app.Core.Model.Client client;
        private int Id = 0;
        public frmClientModal()
        {
            InitializeComponent();

            UpgradeFile upgradeFile = new UpgradeFile();

            cboRegion.DataSource = upgradeFile.Populate("SELECT code, description FROM addr_region;");
            cboRegion.ValueMember = "Key";
            cboRegion.DisplayMember = "Value";
        }

        public frmClientModal(int clientId)
        {
            InitializeComponent();
            this.Id = clientId;
            btnSave.Text = "Update";
            label1.Text = "Update Client Information";
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


        int SelectedRegion = 0;
        private void cboRegion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.SelectedRegion.Equals(cboRegion.SelectedValue))
            {
                return; // No need to update cboProvince, if no changes were committed in cboRegion.
            }

            UpgradeFile upgradeFile = new UpgradeFile();
            cboProvince.DataSource = upgradeFile.Populate("SELECT province_code, description FROM addr_province WHERE region_code=@regionCode;",
                                                           new Dictionary<string, string> { { "@regionCode", cboRegion.SelectedValue.ToString() } });
            cboProvince.ValueMember = "Key";
            cboProvince.DisplayMember = "Value";

            this.SelectedRegion = Convert.ToInt32(cboRegion.SelectedValue);
        }


        private void cboProvince_SelectionChangeCommitted(object sender, EventArgs e)
        {
            UpgradeFile upgradeFile = new UpgradeFile();

            cboCity.DataSource = upgradeFile.Populate("SELECT citymun_code, description FROM addr_city where province_code=@provinceCode;",
                                                       new Dictionary<string, string> { { "@provinceCode", cboProvince.SelectedValue.ToString() } });
            cboCity.ValueMember = "Key";
            cboCity.DisplayMember = "Value";            
        }

        private void cboCity_SelectionChangeCommitted(object sender, EventArgs e)
        {
            UpgradeFile upgradeFile = new UpgradeFile();

            cboBrgy.DataSource = upgradeFile.Populate("SELECT brgy_code, description FROM addr_brgy where citymun_code=@citymunCode;",
                                                       new Dictionary<string, string> { { "@citymunCode", cboCity.SelectedValue.ToString() } });
            cboBrgy.ValueMember = "Key";
            cboBrgy.DisplayMember = "Value";
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
            if (!client.EmailAddress.Contains("@") || !client.EmailAddress.Contains(".com"))
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
    
