using Color = app.Core.Model.ColourPattern;
using System.Windows.Forms;
using app.Core.Repository;
using System;
using app.core.repository;
using app.Core.Model;

namespace app.view.Client
{
    public partial class frmClientPatientModal : Form
    {
        private int Id = 0;
        private int clientId = 0;

        //Use for updating pet record
        public frmClientPatientModal(int petId)
        {
            InitializeComponent();
            this.Id = petId;
            this.Load += frmClientPatientModal_Load;
            btnSave.Text = "Update";
            label5.Text = "Update Patient Information";

        }

        // Use for adding new client's pet
        public frmClientPatientModal(int petId, int clientId)
        {
            InitializeComponent();
            this.Id = petId;
            this.clientId = clientId;
            this.Load += frmClientPatientModal_Load;
        }

        public frmClientPatientModal()
        {
            InitializeComponent();
            this.Load += frmClientPatientModal_Load;
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
                SavePet();

                // Load the data into the DataGridView of frmClient
                UpgradeFile upgradeFile = new UpgradeFile();
                frmClient clientForm = new frmClient();

            // Ensure dgvPatient is accessed properly
            clientForm.dgvPatient.DataSource = upgradeFile.Load("SELECT * FROM vwpatient WHERE isDeleted = 0");

                // Show the frmClient form (optional, depends on your application flow)
                clientForm.Show();

                // Dispose of the current form
                this.Dispose();
            }

        private void btnAddPhoto_Click(object sender, EventArgs e)
        {
            //TODO: Add photo
        }

        private void frmClientPatientModal_Load(object sender, EventArgs e)
        {
            PopulateCmb();
            if (this.Id > 0)
            {
                LoadPetDetails();
            }
        }

        private void cboSpecies_SelectionChangeCommitted(object sender, EventArgs e)
        {
            UpgradeFile upgradeFile = new UpgradeFile();

            cboBreed.DataSource = upgradeFile.Populate("SELECT id, description FROM patient_breed WHERE id='" + cboSpecies.SelectedValue.ToString() + "';");
            cboBreed.ValueMember = "Key";
            cboBreed.DisplayMember = "Value";
        }

        private void SavePet()
        {
            Pet pet = new Pet();

            pet.Id = this.Id;
            pet.Client = new Core.Model.Client() { Id = this.clientId };
            pet.Name = txtName.Text;
            pet.BirthDate = dtpBday.Value.ToString("yyyy-MM-dd");
            pet.Gender = new Gender() { Id = Convert.ToInt32(cboGender.SelectedValue) };
            pet.Specie = new Species() { Id = Convert.ToInt32(cboSpecies.SelectedValue) };
            pet.Breed = new Breed() { Id = Convert.ToInt32(cboBreed.SelectedValue) };
            pet.ColourPattern = new Color() { Id = Convert.ToInt32(cboColor.SelectedValue) };
            //pet.Image = Path.GetFileName(); //TODO: image directory

            PetRepository petRepository = new PetRepository();
            if (petRepository.Save(pet))
            {
                MessageBox.Show("Save successfully");
            }
            else
            {
                MessageBox.Show("Unable to save record");
            }
        }
        private void LoadDetails(app.Core.Model.Pet pet)
        {
            txtName.Text = pet.Name;
            dtpBday.Text = pet.BirthDate;
            cboGender.SelectedValue = pet.Gender.Id;
            cboColor.SelectedValue = pet.ColourPattern.Id;
            cboSpecies.SelectedValue = pet.Specie.Id;
            cboBreed.SelectedValue = pet.Breed.Id;
            //picturePet.Image = pet.Image; rfds
            // ito ba yun te? opo
        }
        private void LoadPetDetails()
        {
            PetRepository petRepository = new PetRepository();
            var pet = petRepository.GetPetDetails(new app.Core.Model.Pet() { Id = this.Id });
            if (pet != null)
            {
                LoadDetails(pet);
            } 
        }
        private void PopulateCmb()
        {
            UpgradeFile upgradeFile = new UpgradeFile();

            cboGender.DataSource = upgradeFile.Populate("SELECT id, description FROM patient_gender ;");
            cboGender.ValueMember = "KEY";
            cboGender.DisplayMember = "VALUE";

            cboBreed.DataSource = upgradeFile.Populate("SELECT id, description FROM patient_breed;");
            cboBreed.ValueMember = "KEY";
            cboBreed.DisplayMember = "VALUE";

            cboColor.DataSource = upgradeFile.Populate("SELECT id, description FROM patient_colour_pattern;");
            cboColor.ValueMember = "KEY";
            cboColor.DisplayMember = "VALUE";

            cboSpecies.DataSource = upgradeFile.Populate("SELECT id, description FROM patient_species;");
            cboSpecies.ValueMember = "KEY";
            cboSpecies.DisplayMember = "VALUE";
        }

    }
}


