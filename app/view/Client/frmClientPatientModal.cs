using app.Core.Repository;
using app.View.Patient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using app.Core.Model;
using Color = app.Core.Model.Color;

namespace app.view.Client
{
    public partial class frmClientPatientModal : Form
    {
        int Id = 0;
        int clientId = 0;

        //Use for updating pet record
        public frmClientPatientModal(int petId)
        {
            InitializeComponent();
            this.Id = petId;
        }

        // Use for adding new client's pet
        public frmClientPatientModal(int petId, int clientId)
        {
            InitializeComponent();
            this.Id = petId;
            this.clientId = clientId;
        }
        public frmClientPatientModal()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Pet pet = new Pet();

            pet.Id = this.Id;
            pet.Client = new Core.Model.Client() { Id = this.clientId };
            pet.Name = txtName.Text;
            pet.BirthDate = dtpBday.Value.ToString("yyyy-MM-dd");
            pet.Gender = new Gender() { Id = Convert.ToInt32(cboGender.SelectedValue) };
            pet.Specie = new Species() { Id = Convert.ToInt32(cboSpecies.SelectedValue) };
            pet.Breed = new Breed() { Id = Convert.ToInt32(cboBreed.SelectedValue) };
            pet.Color = new Color() { Id = Convert.ToInt32(cboColor.SelectedValue) };
            // pet.Image = Path.GetFileName(); //TODO: image directory

            PetRepository petRepository = new PetRepository();
            if (petRepository.Save(pet))
            {
                MessageBox.Show("Save successfully");
                
            }
            else
            {
                MessageBox.Show("Unable to save record");
            }

            this.Dispose();                           
        }
           

        private void btnAddPhoto_Click(object sender, EventArgs e)
        {
            //TODO: Add photo
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmClientPatientModal_Load(object sender, EventArgs e)
        {
            {
                UpgradeFile upgradeFile = new UpgradeFile();
                
                cboGender.DataSource = upgradeFile.Populate("SELECT sexID, sexName FROM gender;");
                cboGender.ValueMember = "Key";
                cboGender.DisplayMember = "Value";

                cboBreed.DataSource = upgradeFile.Populate("SELECT breedID, breedDesc FROM breed;");
                cboBreed.ValueMember = "Key";
                cboBreed.DisplayMember = "Value";

                cboColor.DataSource = upgradeFile.Populate("SELECT colorID, colorName FROM color;");
                cboColor.ValueMember = "Key";
                cboColor.DisplayMember = "Value";

                cboSpecies.DataSource = upgradeFile.Populate("SELECT speciesID, speciesName FROM species;");
                cboSpecies.ValueMember = "Key";
                cboSpecies.DisplayMember = "Value";
            }
            }

        private void cboSpecies_SelectionChangeCommitted(object sender, EventArgs e)
        {
            UpgradeFile upgradeFile = new UpgradeFile();

            cboBreed.DataSource = upgradeFile.Populate("SELECT breedID, breedDesc FROM breed WHERE speciesID='" + cboSpecies.SelectedValue.ToString() + "';");
            cboBreed.ValueMember = "Key";
            cboBreed.DisplayMember = "Value";
        }
    }
    }

