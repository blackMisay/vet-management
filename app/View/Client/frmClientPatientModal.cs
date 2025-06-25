using Color = app.Core.Model.ColourPattern;
using System.Windows.Forms;
using app.Core.Repository;
using System;
using app.Core.Model;
using Core;
using System.Collections.Generic;
using MySqlConnector;
using System.Data;
using System.Linq;

namespace app.view.Client
{
    public partial class frmClientPatientModal : Form
    {
        private int Id = 0;
        private int clientId = 0;
        private int selectedBreedId;
        private Pet pet;
        public bool IsViewOnly { get; set; } = false;

        private UpgradeFile upgradeFile;
        private List<KeyValuePair<int, string>> breedList;


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
            LoadBreedComboBox();


        }
        private void LoadBreedComboBox()
        {
            upgradeFile = new UpgradeFile();

            // Load breed data from DB
            breedList = upgradeFile.Populate("SELECT id, description FROM patient_breed ORDER BY description;");

            if (breedList == null || breedList.Count == 0)
            {
                MessageBox.Show("No breed data found.");
                return;
            }

            // Setup AutoComplete source with breed descriptions
            var autoCompleteSource = new AutoCompleteStringCollection();
            autoCompleteSource.AddRange(breedList.Select(b => b.Value).ToArray());

            cboBreed.DropDownStyle = ComboBoxStyle.DropDown;
            cboBreed.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboBreed.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cboBreed.AutoCompleteCustomSource = autoCompleteSource;

            // Bind full breed list as DataSource
            cboBreed.DataSource = breedList.ToList(); // Use ToList to detach any binding references
            cboBreed.DisplayMember = "Value";
            cboBreed.ValueMember = "Key";

            // Attach event for filtering dropdown on typing
            cboBreed.TextChanged += cboBreed_TextChanged;
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
            clientForm.Refresh();
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
                frmClient frm = new frmClient();
                frm.dgvPatient.RefreshEdit();
            }
            else
            {
                MessageBox.Show("Unable to save the pet record.");
            }
        }
        public void LoadDetails(app.Core.Model.Pet pet)
        {
            // 1. Populate all combo boxes first (including breed)
            // This method should populate Gender, Color, Species combo boxes
            PopulateCmb();

            // 2. Set pet info fields
            if (DateTime.TryParse(pet.BirthDate, out DateTime birthDate))
            {
                dtpBday.Value = birthDate;
            }

            txtName.Text = pet.Name;
            txtAge.Text = pet.Age?.ToString();
            cmbSize.Text = pet.Size?.ToString();
            txtWeight.Text = pet.Weight;

            cboGender.SelectedValue = pet.Gender?.Id;
            cboColor.SelectedValue = pet.ColourPattern?.Id;

            // Temporarily detach SelectedIndexChanged to avoid auto reload of breeds overriding breed selection
            cboSpecies.SelectedIndexChanged -= cboSpecies_SelectedIndexChanged;

            cboSpecies.SelectedValue = pet.Specie?.Id;

            // Now load breeds for this species
            LoadBreedsBySpecies(pet.Specie?.Id ?? 0);

            // Set breed selected value
            cboBreed.SelectedValue = pet.Breed?.Id;

            cboSpecies.SelectedIndexChanged += cboSpecies_SelectedIndexChanged;

            pbPetPhoto.ImageLocation = pet.Image;

            // Disable controls if view-only mode
            if (IsViewOnly)
            {
                btnSave.Visible = false;
                btnCancel.Visible = false;

                txtName.ReadOnly = true;
                txtAge.ReadOnly = true;
                txtWeight.ReadOnly = true;
                cboBreed.Enabled = false;
                cmbSize.Enabled = false;
                cboGender.Enabled = false;
                cboColor.Enabled = false;
                cboSpecies.Enabled = false;
                dtpBday.Enabled = false;
                pbPetPhoto.Enabled = false;
            }

        }
        private void LoadBreedsBySpecies(int speciesId)
        {
            UpgradeFile upgradeFile = new UpgradeFile();

            string query = "SELECT id, description FROM patient_breed WHERE species_id = @species_id ORDER BY description";
            var parameters = new Dictionary<string, string> { { "@species_id", speciesId.ToString() } };

            var breeds = upgradeFile.Populate(query, parameters);

            cboBreed.DataSource = breeds;
            cboBreed.ValueMember = "KEY";
            cboBreed.DisplayMember = "VALUE";
        }


        public void LoadPetDetails()
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
            // Make sure selected value is valid and is an integer id
            if (cboSpecies.SelectedValue == null || !(cboSpecies.SelectedValue is int))
            {
                // Clear breed combobox if species not selected properly
                cboBreed.DataSource = null;
                cboBreed.Items.Clear();
                return;
            }

            int selectedSpeciesId = (int)cboSpecies.SelectedValue;

            UpgradeFile upgradeFile = new UpgradeFile();

            string query = "SELECT id, description FROM patient_breed WHERE species_id = @species_id ORDER BY description";

            var parameters = new Dictionary<string, string>
    {
        { "@species_id", selectedSpeciesId.ToString() }
    };

            try
            {
                // Use Populate method to get List<KeyValuePair<int, string>>
                var breedList = upgradeFile.Populate(query, parameters);

                if (breedList != null && breedList.Count > 0)
                {
                    cboBreed.DataSource = breedList;
                    cboBreed.DisplayMember = "Value";
                    cboBreed.ValueMember = "Key";
                }
                else
                {
                    // Clear if no breeds found
                    cboBreed.DataSource = null;
                    cboBreed.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading breeds: " + ex.Message);
            }
        }

        private void cboBreed_TextChanged(object sender, EventArgs e)
        {
            string typedText = cboBreed.Text;

            if (breedList == null || breedList.Count == 0)
                return;

            if (string.IsNullOrWhiteSpace(typedText))
            {
                // Reset to full list if empty
                cboBreed.DataSource = breedList.ToList();
                cboBreed.DroppedDown = false;
                return;
            }

            // Filter breeds by typed text (case-insensitive contains)
            var filtered = breedList
                .Where(b => b.Value != null && b.Value.IndexOf(typedText, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();

            if (filtered.Count > 0)
            {
                cboBreed.DataSource = filtered;
                cboBreed.DisplayMember = "Value";
                cboBreed.ValueMember = "Key";

                cboBreed.DroppedDown = true;
                cboBreed.SelectionStart = typedText.Length;
                cboBreed.SelectionLength = 0;
            }
            else
            {
                cboBreed.DroppedDown = false;
            }
        }
        private void cboBreed_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBreed.SelectedValue != null && int.TryParse(cboBreed.SelectedValue.ToString(), out int breedId))
            {
                selectedBreedId = breedId;
            }
            else
            {
                selectedBreedId = 0; // or some invalid value
            }
        }
    }
}