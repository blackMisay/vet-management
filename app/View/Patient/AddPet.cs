using app.Core.Repository;
using System;
using System.Windows.Forms;
using app.Core.Model;
using System.IO;
using System.Drawing;
using Color = app.Core.Model.Color;

namespace app.View.Patient
{
    public partial class AddPet : Form
    {
        int Id = 0;
        int clientId = 0;
        public AddPet()
        {
            InitializeComponent();
        }

        // Use for updating pet reccrd
        public AddPet(int petId)
        {
            InitializeComponent();
            this.Id = petId;
        }

        // Use for adding new client's pet
        public AddPet(int petId, int clientId)
        {
            InitializeComponent();
            this.Id = petId;
            this.clientId = clientId;
        }

        private void AddPet_Load(object sender, EventArgs e)
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
            PetDetails petDetails = new PetDetails();
            petDetails.ShowDialog();
        }

        private void cboSpecies_SelectionChangeCommitted(object sender, EventArgs e)
        {
            UpgradeFile upgradeFile = new UpgradeFile();
            
                cboBreed.DataSource = upgradeFile.Populate("SELECT breedID, breedDesc FROM breed WHERE speciesID='" + cboSpecies.SelectedValue.ToString() + "';");
                cboBreed.ValueMember = "Key";
                cboBreed.DisplayMember = "Value";
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SaveFileDialog svf = new SaveFileDialog();

            if (svf.ShowDialog() == DialogResult.OK)
           {
                picturePet.Image.Save(svf.FileName);
            }


            SavePet();
            this.Dispose();
        }

        private void SavePet()
        {
            Pet pet = new Pet();
            
            pet.Id = this.Id;
            pet.Client = new Client() { Id = this.clientId };
            pet.Name = txtlname.Text;
            pet.BirthDate = dtpdob.Value.ToString("yyyy-MM-dd");
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
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofp = new OpenFileDialog();
            //Images Type
            ofp.Filter = "Choose Image (*.jpg;*.png*.gif;*.jpeg)|*.jpg;*.png*.gif*.jpeg|All Files(*.*)|*.*";
            ofp.FilterIndex = 1;

            if (ofp.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                picturePet.Image = Image.FromFile(ofp.FileName);
            }
        }
    }
}

     
