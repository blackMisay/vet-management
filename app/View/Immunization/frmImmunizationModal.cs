using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.view.Utilities;
using System.Windows.Forms;
using app.core.repository;
using app.core.model;
using System.Security.Cryptography;
using Core;

namespace app.view.Immunization
{
    public partial class frmImmunizationModal : Form
    {

        int patientId = 0;
        int selectedRecord = 0;
        public frmImmunizationModal()
        {
            InitializeComponent();
            InitializeExpirationPeriodOptions();

            // Attach event handlers to automatically update expiration date
            dtpAdministeredDate.ValueChanged += dtpAdministeredDate_ValueChanged;
            cmbExpirationPeriod.SelectedIndexChanged += cmbExpirationPeriod_SelectedIndexChanged;
        }

        public frmImmunizationModal(int Id)
        {
            InitializeComponent();
            this.selectedRecord = Id;
            btnSelectAPatient.Visible = false;
            PetVaccinationRepository pvr = new PetVaccinationRepository();
            pvr.LoadListOfVaccine(cmbVaccine);

            PetVaccination pv = new PetVaccination();
            pv = pvr.GetVaccinationDetails(selectedRecord.ToString());
            patientId = pv.PetId;
            txtPetName.Text = pv.PetName;
            txtLotNumber.Text = pv.LotNumber;
            cmbVaccine.Text = pv.VaccinationName;
            cmbDosage.Text = pv.Dosage;
            dtpAdministeredDate.Text = pv.AdministeredDate;
            dtpExpirationDate.Text = pv.ExpirationDate;
        }

        private void frmImmunizationModal_Load(object sender, EventArgs e)
        {
            UpgradeFile upgradeFile = new UpgradeFile();
            cboVeterinarian.DataSource = upgradeFile.Populate("SELECT * FROM doctor WHERE status='Active'");
            cboVeterinarian.ValueMember = "Key";
            cboVeterinarian.DisplayMember = "Value";
        }

        private void btnSelectAPatient_Click(object sender, EventArgs e)
        {
            frmClientPatientForm cpf = new frmClientPatientForm();
            cpf.ShowDialog();
            this.patientId = cpf.GetPatientId();
            txtPetName.Text = cpf.GetPatientName();
            cpf.Dispose();
            PetVaccinationRepository pvr = new PetVaccinationRepository();
            pvr.LoadListOfVaccine(cmbVaccine);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Ensure a patient is selected before proceeding
            if (patientId == 0 && selectedRecord == 0)
            {
                MessageBox.Show("Please select a patient first.", "Patient Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate Lot Number
            if (string.IsNullOrWhiteSpace(txtLotNumber.Text))
            {
                MessageBox.Show("Vaccine Lot Number is required.", "Required Lot Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Get the expiration date from the date picker (which is already auto-calculated)
            DateTime administeredDate = dtpAdministeredDate.Value;
            DateTime expirationDate = dtpExpirationDate.Value;

            // Prevent administering an expired vaccine
            if (administeredDate >= expirationDate)
            {
                MessageBox.Show("You're administering an expired vaccine to the patient.", "Expired Vaccine", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Create a new PetVaccination object with data
            PetVaccination pv = new PetVaccination()
            {
                Id = selectedRecord,
                PetId = patientId,
                VaccinationId = Convert.ToInt32(cmbVaccine.SelectedValue),
                LotNumber = txtLotNumber.Text,
                Dosage = cmbDosage.Text,
                AdministeredDate = administeredDate.ToString("yyyy-MM-dd"),
                ExpirationDate = expirationDate.ToString("yyyy-MM-dd"),
                VeterinarianId = Convert.ToInt32(cboVeterinarian.SelectedValue)
            };

            // Save the vaccination record
            PetVaccinationRepository pvr = new PetVaccinationRepository();
            if (pvr.Save(pv))
            {
                MessageBox.Show("Vaccine record saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to cancel patient vaccination?"
                                ,"Confirm to cancel",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }    
        }

        private void UpdateExpirationDate()
        {
            if (cmbExpirationPeriod.SelectedItem == null) return;

            DateTime administeredDate = dtpAdministeredDate.Value;
            DateTime expirationDate = administeredDate;

            switch (cmbExpirationPeriod.SelectedItem.ToString())
            {
                case "3-4 Weeks":
                    expirationDate = administeredDate.AddDays(28); // 4 weeks (28 days)
                    break;
                case "6 Weeks":
                    expirationDate = administeredDate.AddDays(42); // 6 weeks (42 days)
                    break;
                case "8 Weeks":
                    expirationDate = administeredDate.AddDays(56); // 8 weeks (56 days)
                    break;
                case "10 Weeks":
                    expirationDate = administeredDate.AddDays(70); // 10 weeks (70 days)
                    break;
                case "12 Weeks":
                    expirationDate = administeredDate.AddDays(84); // 12 weeks (84 days)
                    break;
                case "3 Months":
                    expirationDate = administeredDate.AddMonths(3); // 3 months
                    break;
                case "3-13 Weeks":
                    expirationDate = administeredDate.AddDays(91); // 13 weeks (91 days)
                    break;
                case "Every 6 Months":
                    expirationDate = administeredDate.AddMonths(6); // 6 months
                    break;
                case "Annually":
                    expirationDate = administeredDate.AddYears(1); // 1 year
                    break;
                default:
                    expirationDate = administeredDate;
                    break;
            }

            dtpExpirationDate.Value = expirationDate;
        }

        private void InitializeExpirationPeriodOptions()
        {
            cmbExpirationPeriod.Items.Add("3-4 Weeks");
            cmbExpirationPeriod.Items.Add("6 Weeks");
            cmbExpirationPeriod.Items.Add("8 Weeks");
            cmbExpirationPeriod.Items.Add("10 Weeks");
            cmbExpirationPeriod.Items.Add("12 Weeks");
            cmbExpirationPeriod.Items.Add("3 Months");
            cmbExpirationPeriod.Items.Add("3-13 Weeks");
            cmbExpirationPeriod.Items.Add("Every 6 Months");
            cmbExpirationPeriod.Items.Add("Annually");

            cmbExpirationPeriod.SelectedIndex = 0; // Default selection
        }

        private void dtpAdministeredDate_ValueChanged(object sender, EventArgs e)
        {
            UpdateExpirationDate();
        }

        private void cmbExpirationPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateExpirationDate();
        }
    }
}
