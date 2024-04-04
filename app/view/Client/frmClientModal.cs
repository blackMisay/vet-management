using app.Core.Model;
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

namespace app.view.Client
{
    public partial class frmClientModal : Form
    {
        app.Core.Model.Client client;
        int Id = 0;
        public frmClientModal()
        {
            InitializeComponent();
            //TODO: Populating combobox data.
        }

        public frmClientModal(int clientId)
        {
            InitializeComponent();
            this.Id = clientId;
            btnSave.Text = "Update Client";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //TODO: Save function
            SaveClient();
            this.Dispose();
        }

        private void frmClientModal_Load(object sender, EventArgs e)
        {
            //TODO: When updating load all fetch data to each components.
            UpgradeFile upgradeFile = new UpgradeFile();

            cboRegion.DataSource = upgradeFile.Populate("SELECT regCode, regDesc FROM region;");
            cboRegion.ValueMember = "Key";
            cboRegion.DisplayMember = "Value";
        }

        private void cboRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpgradeFile upgradeFile = new UpgradeFile();

            cboProvince.DataSource = upgradeFile.Populate("SELECT provCode, provDesc FROM province WHERE regCode='" + cboRegion.SelectedValue.ToString() + "';");
            cboProvince.ValueMember = "Key";
            cboProvince.DisplayMember = "Value";
        }


        private void cboProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpgradeFile upgradeFile = new UpgradeFile();

            cboCity.DataSource = upgradeFile.Populate("SELECT citymunCode, citymunDesc FROM city where provCode='" + cboProvince.SelectedValue.ToString() + "';");
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

            cboBrgy.DataSource = upgradeFile.Populate("SELECT brgyID, brgyDesc FROM brgy where citymunCode='" + cboCity.SelectedValue.ToString() + "';");
            cboBrgy.ValueMember = "Key";
            cboBrgy.DisplayMember = "Value";
        }

        private void cboBrgy_Click(object sender, EventArgs e)
        {
            UpgradeFile upgradeFile = new UpgradeFile();

            cboBrgy.DataSource = upgradeFile.Populate("SELECT brgyID, brgyDesc FROM brgy where citymunCode='" + cboCity.SelectedValue.ToString() + "';");
            cboBrgy.ValueMember = "Key";
            cboBrgy.DisplayMember = "Value";
        }
    }
}
