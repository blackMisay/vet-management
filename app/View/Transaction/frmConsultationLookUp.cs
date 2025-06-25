using app.core.model;
using app.core.repository;
using app.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app.view.Transaction
{
    public partial class frmConsultationLookUp : Form
    {
        private Dictionary<int, app.core.model.Diagnosis> selectedDiagnosis;
        private Dictionary<int, Diagnosis> diagnosis = new Dictionary<int, Diagnosis>();

        public app.Core.Model.Client SelectedOwner { get; private set; }
        public Pet SelectedPet { get; private set; }
        public app.core.model.Diagnosis SelectedDiagnosis { get; private set; }

        private int selectedOwnerId = 0;
        private int selectedPetId = 0;

        public frmConsultationLookUp()
        {
            InitializeComponent();
            selectedDiagnosis = new Dictionary<int, Diagnosis>();
        }
        public Dictionary<int, app.core.model.Diagnosis> GetAllDiagnosis()

        {
            return selectedDiagnosis;
        }

        public frmConsultationLookUp(Dictionary<int, app.core.model.Diagnosis> diagnosis)
        {
            InitializeComponent();
            selectedDiagnosis = new Dictionary<int, app.core.model.Diagnosis>(diagnosis);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (dgvConsultation.CurrentRow != null)
            {
                var row = dgvConsultation.CurrentRow;

                SelectedOwner = new app.Core.Model.Client
                {
                    Id = Convert.ToInt32(row.Cells["owner_id"].Value),
                    FirstName = row.Cells["owner_name"].Value?.ToString(), // Already formatted full name
                    StreetNo = row.Cells["owner_address"].Value?.ToString(),
                    MobileNumber = row.Cells["mobilenumber"].Value?.ToString()
                };

                SelectedPet = new Pet
                {
                    Id = Convert.ToInt32(row.Cells["pet_id"].Value),
                    Name = row.Cells["pet_name"].Value?.ToString(),
                    Age = row.Cells["pet_age"].Value?.ToString(),
                    BirthDate = row.Cells["pet_birthdate"].Value?.ToString(),
                    Weight = row.Cells["pet_weight"].Value?.ToString(),

                    Breed = new Breed { Description = row.Cells["breed"].Value?.ToString() },
                    Specie = new Species { Description = row.Cells["species"].Value?.ToString() },
                    Gender = new Gender { Description = row.Cells["gender"].Value?.ToString() },
                    ColourPattern = new ColourPattern { Description = row.Cells["color"].Value?.ToString() },

                    // ✅ Set the link between pet and owner
                    Client = SelectedOwner
                };

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select a consultation row.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void LoadConsultationData()
        {
            var repo = new ConsultationRepository();
            DataTable dt = repo.GetAllConsultationWithMedications();

            dgvConsultation.AutoGenerateColumns = true;
            dgvConsultation.DataSource = dt;

            dgvConsultation.ReadOnly = true;
            dgvConsultation.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvConsultation.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }



        private void frmConsultationLookUp_Load(object sender, EventArgs e)
        {
            int ownerId = selectedOwnerId;
            int petId = selectedPetId;

            LoadConsultationData();

        }
    }
}
