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
            if (patientId == 0 && selectedRecord == 0)
            {
                MessageBox.Show("Please select a patient first.");
                return;
            }

            if (dtpAdministeredDate.Value >= dtpExpirationDate.Value) 
            {
                MessageBox.Show("You're administering an expired vaccine to the patient"
                                ,"Expired Vaccine",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                return;
            }
            
            if (string.IsNullOrEmpty(txtLotNumber.Text) || string.IsNullOrWhiteSpace(txtLotNumber.Text))
            {
                MessageBox.Show("Vaccine Lot Number is required"
                                , "Required Lot Number",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                return;
            }

            PetVaccination pv = new PetVaccination()
            {
                Id = selectedRecord,
                PetId = patientId,
                VaccinationId = Convert.ToInt32(cmbVaccine.SelectedValue),
                LotNumber = txtLotNumber.Text,
                Dosage = cmbDosage.Text,
                AdministeredDate = dtpAdministeredDate.Value.ToString("yyyy-MM-dd"),
                ExpirationDate = dtpExpirationDate.Value.ToString("yyyy-MM-dd"),
                VeterinarianId = Convert.ToInt32(cboVeterinarian.SelectedValue)
            };

            PetVaccinationRepository pvr = new PetVaccinationRepository();
            if(pvr.Save(pv))
            {
                MessageBox.Show("Save successfully!");
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
    }
}
