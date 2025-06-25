using System;
using System.Windows.Forms;
using app.core.repository;
using app.core.model;
using Core;
using app.view.Utilities;

namespace app.view.Immunization
{
    public partial class frmImmunizationModal : Form
    {
        private int patientId = 0;
        private int selectedRecord = 0;
        public int SelectedVaccineId { get; set; } = 0;


        public frmImmunizationModal()
        {
            InitializeComponent();
            InitializeExpirationPeriodOptions();

            dtpAdministeredDate.ValueChanged += dtpAdministeredDate_ValueChanged;
           cmbDose.SelectedIndexChanged += cmbDose_SelectedIndexChanged;

            //LoadVaccinesList();
            LoadVeterinarians();
        }

        public frmImmunizationModal(int Id) : this()
        {
            selectedRecord = Id;
            btnSelectAPatient.Visible = false;
            LoadVaccinationRecord(selectedRecord);
        }

        //private void LoadVaccinesList()
        //{
        //    PetVaccinationRepository pvr = new PetVaccinationRepository();
        //    var vaccines = pvr.LoadistofVaccine();
        //    cmbVaccine.DataSource = new BindingSource(vaccines, null);
        //    cmbVaccine.DisplayMember = "Value";
        //    cmbVaccine.ValueMember = "Key";
        //    cmbVaccine.SelectedIndex = -1;
        //}



        private void LoadVeterinarians()
        {
            UpgradeFile upgradeFile = new UpgradeFile();
            cboVeterinarian.DataSource = upgradeFile.Populate("SELECT id, name FROM doctor WHERE status='Active'");
            cboVeterinarian.ValueMember = "Key";
            cboVeterinarian.DisplayMember = "Value";
            cboVeterinarian.SelectedIndex = -1;
        }

        private void LoadVaccinationRecord(int id)
        {
            PetVaccinationRepository pvr = new PetVaccinationRepository();
            PetVaccination pv = pvr.GetById(id.ToString());
            

            if (pv == null)
            {
                MessageBox.Show("Vaccination record not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            patientId = pv.PetId;
            txtPetName.Text = pv.PetName;
            txtLotNumber.Text = pv.LotNumber;

            //if (cmbVaccine.Items.Count > 0)
            //    cmbVaccine.SelectedValue = pv.VaccinationId;

            //cmbDose.Text = pv.Dose;
            dtpAdministeredDate.Value = pv.AdministeredDate == DateTime.MinValue ? DateTime.Today : pv.AdministeredDate;
            dtpExpirationDate.Value = pv.ExpirationDate == DateTime.MinValue ? dtpAdministeredDate.Value.AddMonths(1) : pv.ExpirationDate;

            if (cboVeterinarian.Items.Count > 0)
                cboVeterinarian.SelectedValue = pv.VeterinarianId;
        }

        private void btnSelectAPatient_Click(object sender, EventArgs e)
        {
            using (frmClientPatientForm cpf = new frmClientPatientForm())
            {
                if (cpf.ShowDialog() == DialogResult.OK)
                {
                    patientId = cpf.GetPatientId();
                    txtPetName.Text = cpf.GetPatientName();
                    txtOwner.Text = cpf.GetPatientOwnerFullname();
                }
                else
                {
                    // If dialog was canceled, don't proceed
                    return;
                }
            }

            ClearVaccinationFields();

            //// ✅ Proceed to vaccine selection
            //using (frmVaccine vaccineForm = new frmVaccine())
            //{
            //    if (vaccineForm.ShowDialog() == DialogResult.OK)
            //    {
            //        txtVaccine.Text = vaccineForm.SelectedDescription;
            //        txtDosage.Text = vaccineForm.SelectedDosage;
            //        txtInterval.Text = vaccineForm.SelectedInterval;
            //    }
            //}
        }

        private void ClearVaccinationFields()
        {
            txtLotNumber.Clear();
            txtVaccine.Text = string.Empty;
            cmbDose.SelectedIndex = 0;
            txtDosage.Text = string.Empty;
            dtpAdministeredDate.Value = DateTime.Today;
            dtpExpirationDate.Value = DateTime.Today;
            cboVeterinarian.SelectedIndex = -1;
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (patientId == 0 && selectedRecord == 0)
            {
                MessageBox.Show("Please select a patient first.", "Patient Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selectedVaccineId == 0)
            {
                MessageBox.Show("Please select a vaccine.", "Vaccine Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtLotNumber.Text))
            {
                MessageBox.Show("Vaccine Lot Number is required.", "Required Lot Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (cboVeterinarian.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a veterinarian.", "Required Veterinarian", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DateTime administeredDate = dtpAdministeredDate.Value.Date;
            DateTime expirationDate = dtpExpirationDate.Value.Date;

            if (administeredDate >= expirationDate)
            {
                MessageBox.Show("Administered date must be before the expiration date.", "Invalid Dates", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var vaccination = new PetVaccination
            {
                Id = selectedRecord,
                PetId = patientId,
                VaccinationId = selectedVaccineId, // Make sure this is captured when selecting a vaccine
                LotNumber = txtLotNumber.Text.Trim(),
                AdministeredDate = administeredDate,
                ExpirationDate = expirationDate,
                VeterinarianId = Convert.ToInt32(cboVeterinarian.SelectedValue)
            };

            var repo = new PetVaccinationRepository();
            bool success = repo.Save(vaccination);

            if (success)
            {
                MessageBox.Show("Vaccine record saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to save vaccine record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to cancel patient vaccination?", "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void UpdateExpirationDate()
        {
            if (cmbDose.SelectedItem == null)
                return;

            DateTime administeredDate = dtpAdministeredDate.Value;
            DateTime expirationDate = administeredDate;

            switch (cmbDose.SelectedItem.ToString())
            {
                case "(Initial)2-4 Weeks": expirationDate = administeredDate.AddDays(14); break;
                case "(2nd Dose)2-4 Weeks": expirationDate = administeredDate.AddDays(14); break;
                case "(Initial)3-4 Weeks": expirationDate = administeredDate.AddDays(28); break;
                case "(2nd Dose)3-4 Weeks": expirationDate = administeredDate.AddDays(28); break;
                case "(Booster)3-4 Weeks": expirationDate = administeredDate.AddDays(28); break;
                case "(Initial)6 Weeks": expirationDate = administeredDate.AddDays(42); break;
                case "(Initial)8 Weeks": expirationDate = administeredDate.AddDays(56); break;
                case "(Booster)16 Weeks": expirationDate = administeredDate.AddDays(112); break;
                case "(Initial)12 Weeks": expirationDate = administeredDate.AddDays(84); break;
                case "Annually": expirationDate = administeredDate.AddYears(1); break;
                default: expirationDate = administeredDate; break;
            }

            dtpExpirationDate.Value = expirationDate;
        }

        private void InitializeExpirationPeriodOptions()
        {
            cmbDose.Items.Clear();
            cmbDose.Items.AddRange(new object[]
            {
                "(Initial)2-4 Weeks","(2nd Dose)2-4 Weeks", "(Initial)3-4 Weeks","(2nd Dose)3-4 Weeks","(Booster)3-4 Weeks", "(Initial)6 Weeks", "(Initial)8 Weeks", "(Initial)12 Weeks",
                "(Booster)16 Weeks", "Annually"
            });
            cmbDose.SelectedIndex = 0;
        }

        private void dtpAdministeredDate_ValueChanged(object sender, EventArgs e)
        {
            UpdateExpirationDate();
        }

        private int selectedVaccineId = 0; // Add this if not declared yet

        private void btnSelectVaccine_Click(object sender, EventArgs e)
        {
            using (frmVaccine frm = new frmVaccine())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    txtVaccine.Text = frm.SelectedDescription;
                    txtDosage.Text = frm.SelectedDosage;
                    //txtInterval.Text = frm.SelectedInterval;
                    selectedVaccineId = frm.SelectedVaccineId; // <-- Add this line
                }
            }

        }

        public frmImmunizationModal(string vaccine, string dose, string interval) : this()
        {
            txtVaccine.Text = vaccine;
            txtDosage.Text = dose;
            //txtInterval.Text = interval;
        }

        private void cmbDose_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateExpirationDate();
        }
    }
}
