using app.core.model;
using app.core.repository;
using app.Core.Model;
using app.view.Utilities;
using System;
using System.Data;
using System.Windows.Forms;

namespace app.view.Consultation
{
    public partial class frmConsultationModal : Form
    {
        public frmConsultationModal()
        {
            InitializeComponent();
        }

        public frmConsultationModal(int Id)
        {
            InitializeComponent();
            this.consultationId = Id;

            ConsultationRepository cr = new ConsultationRepository();

            DataTable dt = cr.GetDetails(this.consultationId);

            DataRow row = dt.Rows[0];
            txtPetName.Text = row["petname"].ToString();
            txtAge.Text = row["age"].ToString();
            txtType.Text = row["speciesName"].ToString();
            txtWeight.Text = row["weight"].ToString();
            txtTemperature.Text = row["temperature"].ToString();
            rtxtComplaintRequest.Text = row["complaint"].ToString();
            rtxtFindings.Text = row["findings"].ToString();
            rtxPlanTreatment.Text = row["plantreatment"].ToString();
            rtxMedication.Text = row["medication"].ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to cancel the current consultation?","Confirm to Exit",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        int consultationId = 0;
        int patientId = 0;
        private void btnSelectAPatient_Click(object sender, EventArgs e)
        {
            frmClientPatientForm cpf = new frmClientPatientForm();
            cpf.ShowDialog();

            Pet patient = cpf.GetPatientDetails();
            this.patientId = patient.Id;
            txtPetName.Text = patient.Name;
            txtAge.Text = patient.Age;
            txtType.Text = patient.Specie.Description;
            txtAge.Text = ParseAge(patient.Age);
            cpf.Dispose();
        }

        private string ParseAge(string age)
        {
            string[] parts = age.Split(',');

            int years = int.Parse(parts[0].Trim().Substring(0, 2));
            int months = int.Parse(parts[1].Trim().Substring(0, 2));
            int days = int.Parse(parts[2].Trim().Substring(0, 2));

            if (years > 0)
                return $"{years} {(years == 1 ? "year" : "years")}, {months} {(months == 1 ? "month" : "months")}, {days} {(days == 1 ? "day" : "days")}";
        
            if (months > 0)
                return $"{months} {(months == 1 ? "month" : "months")}, {days} {(days == 1 ? "day" : "days")}";

            if (days > 0)
                return $"{days} {(days == 1 ? "day" : "days")}";

            return "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ConsultationRepository cr = new ConsultationRepository();
            Diagnosis diagnosis = new Diagnosis();

            diagnosis.Id = consultationId;
            diagnosis.Patient = patientId;
            diagnosis.Weight = txtWeight.Text;
            diagnosis.Temperature = txtTemperature.Text;
            diagnosis.Findings = rtxtFindings.Text;
            diagnosis.PlanTreatment = rtxPlanTreatment.Text;
            diagnosis.ComplaintRequest = rtxtComplaintRequest.Text;
            diagnosis.Medication = rtxMedication.Text;
            
            if (cr.Save(diagnosis))
            {
                MessageBox.Show("Consultation details was saved successfully", "Successfully saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
        }

        private void frmConsultationModal_Load(object sender, EventArgs e)
        {

        }

        private void txtWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only numeric input, backspace, control characters, and period
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
    }
}
