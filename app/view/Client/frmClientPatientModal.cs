using Color = app.Core.Model.ColourPattern;
using System.Windows.Forms;
using app.Core.Repository;
using System;
using app.Core.Model;
using Core;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Collections.Generic;
using MySqlConnector;
using System.Data;
using System.Data.SqlClient;


namespace app.view.Client
{
    public partial class frmClientPatientModal : Form
    {
        private int Id = 0;
        private int clientId = 0;
        private int selectedBreedId;

        //Use for updating pet record
        public frmClientPatientModal(int petId)
        {
            InitializeComponent();
            this.Id = petId;
            btnSave.Text = "Update";
            label5.Text = "Update Pet Information";
            cboSpecies.SelectedIndexChanged += cboSpecies_SelectedIndexChanged;

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
            dtpBday.ValueChanged += new EventHandler(dtpBday_ValueChanged);
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
            UpgradeFile upgradeFile = new UpgradeFile();
            frmClient clientForm = new frmClient();

            clientForm.dgvPatient.DataSource = upgradeFile.Load("SELECT * FROM vwpatient WHERE isDeleted = 0");
            clientForm.Show();
            this.Dispose();
        }

        private string imagePath = "";
        private void btnAddPhoto_Click(object sender, EventArgs e)
        {
            // enhance/VCMS49
            if (MessageBox.Show("Do you want to add/change photo?", "Confirm to add/change photo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.InitialDirectory = "Downloads";
                openFileDialog.Filter = "Jpg Files (*.jpg)|*.jpg|Jpeg Files (*.jpeg)|*.jpeg|Png Files (*.png)|*.png|All Files(*.*)|*.*";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.imagePath = openFileDialog.FileName;
                    pbPetPhoto.ImageLocation = imagePath;
                }
            }
        }

        private void frmClientPatientModal_Load(object sender, EventArgs e)
        {
            PopulateCmb();
            if (this.Id > 0)
            {
                LoadPetDetails();
            }
        }

        private void SavePet()
        {
            Pet pet = new Pet
            {
                Id = this.Id, // Assuming this is the pet's Id
                Client = new Core.Model.Client { Id = this.clientId },
                Name = txtName.Text,
                BirthDate = dtpBday.Value.ToString("yyyy-MM-dd"),
                Age = txtAge.Text,
                Size = cmbSize.Text,
                Weight = txtWeight.Text,
                Gender = new Gender { Id = Convert.ToInt32(cboGender.SelectedValue) },
                Specie = new Species { Id = Convert.ToInt32(cboSpecies.SelectedValue) },
                ColourPattern = new Color { Id = Convert.ToInt32(cboColor.SelectedValue) },
                Image = this.imagePath, // Assuming imagePath is the file path of the pet image
                Breed = new Breed { Id = this.selectedBreedId }  // Use the selected breed ID
            };

            // Perform validation and save as before
            PetRepository petRepository = new PetRepository();
            bool isSaved = petRepository.Save(pet);

            if (isSaved)
            {
                MessageBox.Show("Pet saved successfully!");
            }
            else
            {
                MessageBox.Show("Unable to save the pet record.");
            }
        }
        private void LoadDetails(app.Core.Model.Pet pet)
        {
            txtName.Text = pet.Name;
            //dtpBday.Value = pet.BirthDate;
            txtAge.Text = pet.Age.ToString();
            cmbSize.Text = pet.Size.ToString();
            txtWeight.Text = pet.Weight;
            cboGender.SelectedValue = pet.Gender.Id;
            cboColor.SelectedValue = pet.ColourPattern.Id;
            cboSpecies.SelectedValue = pet.Specie.Id;
            txtBreed.Text = pet.Breed.ToString();
            pbPetPhoto.ImageLocation = pet.Image; //enhance/VCMS49

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

        public void PopulateCmb()
        {
            UpgradeFile upgradeFile = new UpgradeFile();

            cboColor.DataSource = upgradeFile.Populate("SELECT id, description FROM patient_colour_pattern ORDER BY description;");
            cboColor.ValueMember = "KEY";
            cboColor.DisplayMember = "VALUE";

            cboGender.DataSource = upgradeFile.Populate("SELECT id, description FROM patient_gender ORDER BY description;");
            cboGender.ValueMember = "KEY";
            cboGender.DisplayMember = "VALUE";

            cboSpecies.DataSource = upgradeFile.Populate("SELECT id, description FROM patient_species ORDER BY description;");
            cboSpecies.ValueMember = "KEY";
            cboSpecies.DisplayMember = "VALUE";

        }

        private void dtpBday_ValueChanged(object sender, EventArgs e)
        {
            DateTime birthDate = dtpBday.Value;

            if (birthDate > DateTime.Today)
            {
                txtAge.Text = "Invalid date of birth";
                return;
            }

            (int years, int months, int days) = CalculateAge(birthDate);

            // Update the textbox with the formatted age
            txtAge.Text = $"{years} years, {months} months, {days} days";
        }

        private (int, int, int) CalculateAge(DateTime birthDate)
        {
            DateTime today = DateTime.Today;

            int years = today.Year - birthDate.Year;
            int months = today.Month - birthDate.Month;
            int days = today.Day - birthDate.Day;

            // Adjust for months and days
            if (days < 0)
            {
                months--;
                days += DateTime.DaysInMonth(today.Year, today.AddMonths(-1).Month);
            }

            if (months < 0)
            {
                years--;
                months += 12;
            }

            return (years, months, days);
        }

        private void btnAddColor_Click(object sender, EventArgs e)
        {
            frmNewPetColor frm = new frmNewPetColor();
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // Refresh the combobox to include the new color
                    PopulateCmb();
                }
            }
        }

        private void btnBreed_Click(object sender, EventArgs e)
        {
            if (cboSpecies.SelectedValue == null)
            {
                MessageBox.Show("Please select a species first.");
                return;
            }

            // Convert species ID to string
            string selectedSpecies = cboSpecies.SelectedValue.ToString();

            // Open breed selection form
            frmBreed breedForm = new frmBreed();
            UpgradeFile upgradeFile = new UpgradeFile();

            // SQL query to fetch breeds based on selected species
            string query = "SELECT id, description FROM patient_breed WHERE species_id = @species_id ORDER BY description";

            // Define query parameters (using string values)
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                { "@species_id", selectedSpecies }
            };

            // Load breed data
            DataTable dt = upgradeFile.Load(query, parameters);

            // Check if data exists
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("No breeds found for the selected species.");
                return;
            }

            // Assign data to DataGridView
            breedForm.dgvBreed.DataSource = dt;

            // Show the breed form
            breedForm.ShowDialog();

        }
        public string GetBreedDescription(int breedId)
        {

            string breedDescription = string.Empty;
            UpgradeFile db = new UpgradeFile();

            try
            {
                db.Connect(); // Now accessible

                string query = "SELECT description FROM patient_breed WHERE id = @id;";

                using (MySqlCommand cmd = new MySqlCommand(query, db.connection))
                {
                    cmd.Parameters.AddWithValue("@id", breedId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            breedDescription = reader["description"].ToString();
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception($"MySQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Unexpected Error: {ex.Message}");
            }
            finally
            {
                if (db.connection.State == ConnectionState.Open)
                {
                    db.connection.Close();
                }
            }

            return breedDescription;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            // Get the text from the TextBox
            string name = txtName.Text;

            // Check if the text is not empty
            if (!string.IsNullOrEmpty(name))
            {
                // Trim any leading or trailing spaces
                name = name.Trim();

                // If there is any text, convert it to sentence case
                if (name.Length > 0)
                {
                    // Convert the first character to uppercase and the rest to lowercase
                    name = char.ToUpper(name[0]) + name.Substring(1).ToLower();
                }

                // To avoid triggering the TextChanged event, use this:
                txtName.Text = name;
                txtName.SelectionStart = name.Length;  // Keep the cursor at the end of the text
            }
        }

        private void cboSpecies_SelectedIndexChanged(object sender, EventArgs e)
        {
            frmBreed frm = new frmBreed();
            // Ensure a species is selected before loading breeds
            if (cboSpecies.SelectedValue != null)
            {
                UpgradeFile upgradeFile = new UpgradeFile();

                // Define the query properly with parameterized query (Avoid SQL injection)
                string query = "SELECT id, description FROM patient_breed WHERE species_id = @species_id ORDER BY description";

                // Define parameters correctly
                Dictionary<string, string> parameters = new Dictionary<string, string>
        {
            { "@species_id", cboSpecies.SelectedValue.ToString() } // Convert to string
        };

                // Load breed data into DataGridView
                frm.dgvBreed.DataSource = upgradeFile.Load(query, parameters);
            }
        }
    }
}