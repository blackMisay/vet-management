using app.Core.Model;
using app.Core.Repository;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Core;
using System.Text.RegularExpressions;

namespace app.view.Client
{
    public partial class frmClientModal : Form
    {
        app.Core.Model.Client client;
        private int Id = 0;
        public frmClientModal()
        {
            InitializeComponent();
            CapitalizeAllTextBoxes(this);
            SetupMobileNumberTextbox(txtMobile);
            SetupTelephoneTextbox(txtPhone);

            UpgradeFile upgradeFile = new UpgradeFile();
            cboRegion.DataSource = upgradeFile.Populate("SELECT code, description FROM addr_region;");
            cboRegion.ValueMember = "Key";
            cboRegion.DisplayMember = "Value";

            if (this.Id > 0)
            {
                LoadClientDetails();
            }
        }

        public frmClientModal(int clientId)
        {
            InitializeComponent();
            this.Id = clientId;
            btnSave.Text = "Update";
            label1.Text = "Update Client Information";
            CapitalizeAllTextBoxes(this);
            SetupMobileNumberTextbox(txtMobile);
            SetupTelephoneTextbox(txtPhone);
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            bool saved = SaveClient(); // SaveClient returns true if successful, false otherwise

            if (saved)
            {
                this.Close();  // Close form only if saved successfully
            }
            // else: do nothing, so the form stays open for corrections
        }

        private void frmClientModal_Load(object sender, EventArgs e)
        {
            if (this.Id > 0)
            {
                LoadClientDetails();
            }
        }


        int SelectedRegion = 0;


        private void cboRegion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Check if the selected value is null to avoid exceptions
            if (cboRegion.SelectedValue == null || this.SelectedRegion.Equals(cboRegion.SelectedValue))
            {
                return; // No need to update cboProvince if no changes were committed in cboRegion.
                
            }

            Console.WriteLine(cboRegion.SelectedValue);

            UpgradeFile upgradeFile = new UpgradeFile();
            cboProvince.DataSource = upgradeFile.Populate("SELECT province_code, description FROM addr_province WHERE region_code=@regionCode;",
                                                           new Dictionary<string, string> { { "@regionCode", cboRegion.SelectedValue.ToString() } });
            cboProvince.ValueMember = "Key";
            cboProvince.DisplayMember = "Value";

            // Update the selected region after successful change
            this.SelectedRegion = Convert.ToInt32(cboRegion.SelectedValue);
        }



        private void cboProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpgradeFile upgradeFile = new UpgradeFile();

            cboCity.DataSource = upgradeFile.Populate("SELECT citymun_code, description FROM addr_city where province_code=@provinceCode;",
                                                       new Dictionary<string, string> { { "@provinceCode", cboProvince.SelectedValue.ToString() } });
            cboCity.ValueMember = "Key";
            cboCity.DisplayMember = "Value";            
        }

        private void cboCity_SelectionChangeCommitted(object sender, EventArgs e)
        {
            UpgradeFile upgradeFile = new UpgradeFile();

            cboBrgy.DataSource = upgradeFile.Populate("SELECT brgy_code, description FROM addr_brgy where citymun_code=@citymunCode;",
                                                       new Dictionary<string, string> { { "@citymunCode", cboCity.SelectedValue.ToString() } });
            cboBrgy.ValueMember = "Key";
            cboBrgy.DisplayMember = "Value";

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

        private bool SaveClient()
        {
            // Create new client from input with trimmed values
            Core.Model.Client client = new Core.Model.Client
            {
                Id = this.Id,
                FirstName = txtFname.Text.Trim(),
                LastName = txtLname.Text.Trim(),
                MiddleName = txtMname.Text.Trim(),
                Suffix = txtSuffix.Text.Trim(),
                PhoneNumber = txtPhone.Text.Trim(),
                MobileNumber = txtMobile.Text.Trim(),
                EmailAddress = txtEmail.Text.Trim(),
                StreetNo = richHousenum.Text.Trim(),
                Region = new Core.Model.Region() { Id = Convert.ToInt32(cboRegion.SelectedValue) },
                City = new City() { Id = Convert.ToInt32(cboCity.SelectedValue) },
                Brgy = new Barangay() { Id = Convert.ToInt32(cboBrgy.SelectedValue) },
                Province = new Province() { Id = Convert.ToInt32(cboProvince.SelectedValue) }
            };

            // Email validation
            if (!client.EmailAddress.Contains("@") || !client.EmailAddress.Contains(".com"))
            {
                MessageBox.Show("Invalid Email Address");
                txtEmail.Focus();
                return false;
            }

            // Mobile number validation
            if (!IsValidPhilippineCellphone(client.MobileNumber))
            {
                MessageBox.Show("Invalid Philippine mobile number format. It should start with 09 or +639 and be 11 digits.");
                txtMobile.Focus();
                return false;
            }

           //string phone = client.PhoneNumber?.Trim();

           // if (!string.IsNullOrWhiteSpace(phone) && !IsValidPhilippineTelephone(phone))
           // {
           //     MessageBox.Show("Invalid Philippine telephone number format.");
           //     txtPhone.Focus();
           //     return false;
           // }



            // Check duplicate client by full name
            ClientRepository clientRepository = new ClientRepository();

            if (clientRepository.ClientExists(client.FirstName, client.LastName, client.MiddleName))
            {
                MessageBox.Show("Client with the same full name already exists.");
                txtFname.Focus();
                return false;
            }

            // Save client
            if (clientRepository.Save(client))
            {
                MessageBox.Show("Saved successfully");
                return true;
            }
            else
            {
                MessageBox.Show("Unable to save record");
                return false;
            }
        }

        private bool IsValidPhilippineCellphone(string number)
        {

            string pattern = @"^(09|\+639)\d{9}$";
            return Regex.IsMatch(number.Trim(), pattern);
        }

       private bool IsValidPhilippineTelephone(string number)
{
    if (string.IsNullOrWhiteSpace(number))
        return false;

    string pattern = @"^\d{2,4}[- ]?\d{6,8}$";
    return Regex.IsMatch(number.Trim(), pattern);
}
        private void LoadDetails(app.Core.Model.Client client)
        {
            PopulateCmb();
            txtFname.Text = client.FirstName;
            txtLname.Text = client.LastName;
            txtMname.Text = client.MiddleName;
            txtSuffix.Text = client.Suffix;
            txtPhone.Text = client.PhoneNumber;
            txtMobile.Text = client.MobileNumber;
            txtEmail.Text = client.EmailAddress;
            richHousenum.Text = client.StreetNo;
            //TODO: Fix fetch
            cboRegion.SelectedValue = client.Region.Id;
            cboCity.SelectedValue = client.City.Id;
            cboBrgy.SelectedValue = client.Brgy.Id;
            cboProvince.SelectedValue = client.Province.Id;
        }
        private void LoadClientDetails()
        {
            ClientRepository client = new ClientRepository();
            var clients = client.GetClientInfoDetails(new app.Core.Model.Client() { Id = this.Id });
            if (clients != null)
            {
                LoadDetails(clients);
            }
        }

        private void PopulateCmb()
        {
            //TODO: When updating load all fetch data to each components.
            UpgradeFile upgradeFile = new UpgradeFile();

            cboRegion.DataSource = upgradeFile.Populate("SELECT code, description FROM addr_region;");
            cboRegion.ValueMember = "Key";
            cboRegion.DisplayMember = "Value";

            cboProvince.DataSource = upgradeFile.Populate("SELECT province_code, description FROM addr_province;");
            cboProvince.ValueMember = "Key";
            cboProvince.DisplayMember = "Value";

            cboBrgy.DataSource = upgradeFile.Populate("SELECT brgy_code, description FROM addr_brgy;");
            cboBrgy.ValueMember = "Key";
            cboBrgy.DisplayMember = "Value";

            cboCity.DataSource = upgradeFile.Populate("SELECT citymun_code, description FROM addr_city;");
            cboCity.ValueMember = "Key";
            cboCity.DisplayMember = "Value";
        }

        private void cboRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(this.Id == 0))
            {
                // Check if the selected value is null to avoid exceptions
                if (cboRegion.SelectedValue == null || this.SelectedRegion.Equals(cboRegion.SelectedValue))
                {
                    return; // No need to update cboProvince if no changes were committed in cboRegion.

                }

                Console.WriteLine(cboRegion.SelectedValue);

                UpgradeFile upgradeFile = new UpgradeFile();
                cboProvince.DataSource = upgradeFile.Populate("SELECT province_code, description FROM addr_province WHERE region_code='@regionCode';",
                                                               new Dictionary<string, string> { { "@regionCode", cboRegion.SelectedValue.ToString() } });
                cboProvince.ValueMember = "Key";
                cboProvince.DisplayMember = "Value";

                // Update the selected region after successful change
                this.SelectedRegion = Convert.ToInt32(cboRegion.SelectedValue);// TODO:
            }
        }

        private void cboProvince_SelectionChangeCommitted(object sender, EventArgs e)
        {
            UpgradeFile upgradeFile = new UpgradeFile();

            cboCity.DataSource = upgradeFile.Populate("SELECT citymun_code, description FROM addr_city where province_code=@provinceCode;",
                                                       new Dictionary<string, string> { { "@provinceCode", cboProvince.SelectedValue.ToString() } });
            cboCity.ValueMember = "Key";
            cboCity.DisplayMember = "Value";
        }

        private void cboProvince_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            UpgradeFile upgradeFile = new UpgradeFile();

            cboCity.DataSource = upgradeFile.Populate("SELECT citymun_code, description FROM addr_city where province_code=@provinceCode;",
                                                       new Dictionary<string, string> { { "@provinceCode", cboProvince.SelectedValue.ToString() } });
            cboCity.ValueMember = "Key";
            cboCity.DisplayMember = "Value";
        }

        private void CapitalizeAllTextBoxes(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is TextBox tb)
                {
                    tb.TextChanged += (s, e) =>
                    {
                        int selStart = tb.SelectionStart;
                        string original = tb.Text;
                        string capitalized = CapitalizeWords(original);

                        if (capitalized != original)
                        {
                            tb.Text = capitalized;
                            tb.SelectionStart = selStart; // Preserve caret position
                        }
                    };
                }
                else if (ctrl.Controls.Count > 0)
                {
                    CapitalizeAllTextBoxes(ctrl);
                }
            }
        }

        private string CapitalizeWords(string input)
        {
            var words = input.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(words[i]))
                    words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
            }
            return string.Join(" ", words);
        }
        private void SetupMobileNumberTextbox(TextBox textBox)
        {
            textBox.Text = "+639"; // Set default on form load

            textBox.Enter += (s, e) =>
            {
                if (!textBox.Text.StartsWith("+639"))
                    textBox.Text = "+639";
                textBox.SelectionStart = textBox.Text.Length;
            };

            textBox.KeyPress += (s, e) =>
            {
                if (textBox.SelectionStart < 4)
                {
                    // Allow navigation keys like arrow, backspace (only when caret is not at start)
                    if (!char.IsControl(e.KeyChar))
                        e.Handled = true;
                }
                else if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            };

            textBox.TextChanged += (s, e) =>
            {
                if (!textBox.Text.StartsWith("+639"))
                {
                    int sel = textBox.SelectionStart;
                    textBox.Text = "+639";
                    textBox.SelectionStart = Math.Max(sel, textBox.Text.Length);
                }
            };
        }

        private void SetupTelephoneTextbox(TextBox textBox)
        {
            textBox.Text = "(0";

            textBox.Enter += (s, e) =>
            {
                if (!textBox.Text.StartsWith("(0"))
                    textBox.Text = "(0";
                textBox.SelectionStart = textBox.Text.Length;
            };

            textBox.KeyPress += (s, e) =>
            {
                if (textBox.SelectionStart < 2)
                {
                    if (!char.IsControl(e.KeyChar))
                        e.Handled = true;
                }
                else if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            };

            textBox.TextChanged += (s, e) =>
            {
                if (!textBox.Text.StartsWith("(0"))
                {
                    int sel = textBox.SelectionStart;
                    textBox.Text = "(0";
                    textBox.SelectionStart = Math.Max(sel, textBox.Text.Length);
                }
            };
        }
    }
}
    
