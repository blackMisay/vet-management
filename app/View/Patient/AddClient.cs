using app.Core.Model;
using app.Core.Repository;
using System;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using app.Core;
using System.Runtime.Remoting;

namespace app.View.Patient
{
    public partial class AddClient : Form
    {
        int Id = 0;
        public AddClient()
        {
            InitializeComponent();
        }
        public AddClient(int clientId)
        {
            InitializeComponent();
            this.Id = clientId;
        }
        private void Patient_Load(object sender, EventArgs e)
        {
            UpgradeFile upgradeFile = new UpgradeFile();
            
                cboRegion.DataSource = upgradeFile.Populate("SELECT regCode, regDesc FROM region;");
                cboRegion.ValueMember = "Key";
                cboRegion.DisplayMember = "Value";
            
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
            PatientList patientList = new PatientList();
            patientList.ShowDialog();
        }

        private void cboRegion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            UpgradeFile upgradeFile = new UpgradeFile();
            
                cboProvince.DataSource = upgradeFile.Populate("SELECT provCode, provDesc FROM province WHERE regCode='" + cboRegion.SelectedValue.ToString() + "';");
                cboProvince.ValueMember = "Key";
                cboProvince.DisplayMember = "Value";
            
        }

        private void cboCity_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void cboProvince_SelectedValueChanged(object sender, EventArgs e)
        {
            UpgradeFile upgradeFile = new UpgradeFile();
            
                cboCity.DataSource = upgradeFile.Populate("SELECT citymunCode, citymunDesc FROM city where provCode='" + cboProvince.SelectedValue.ToString() + "';");
                cboCity.ValueMember = "Key";
                cboCity.DisplayMember = "Value";
            
        }

        private void cboBrgy_Click(object sender, EventArgs e)
        {
            UpgradeFile upgradeFile = new UpgradeFile();
            
                cboBrgy.DataSource = upgradeFile.Populate("SELECT brgyID, brgyDesc FROM brgy where citymunCode='" + cboCity.SelectedValue.ToString() + "';");
                cboBrgy.ValueMember = "Key";
                cboBrgy.DisplayMember = "Value";
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SavePatient();
            this.Dispose();
        }

        private void pnlAdd_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SavePatient()
        {
            Client client = new Client();
            client.Id = this.Id;
            client.FirstName = txtfname.Text;
            client.LastName = txtlname.Text;
            client.MiddleName = txtmi.Text;
            client.Suffix = cmbSuffix.Text;
            client.CivilStatus = cmbCivilStat.Text;
            client.PhoneNumber = txttellnum.Text;
            client.MobileNumber = txtcellnum.Text;
            client.BirthDate = dtpdob.Value.ToString("yyyy-MM-dd");
            client.Gender = cmbSex.Text;
            client.EmailAddress = txtemail.Text;
            client.StreetNo = txtstreet.Text;
            client.Region = new Region() { Id = Convert.ToInt32(cboRegion.SelectedValue) };
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

        private void Label11_Click(object sender, EventArgs e)
        {

        }
    }
}
