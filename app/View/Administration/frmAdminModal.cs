using app.core.model;
using app.core.repository;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace app.view.Administration
{
    public partial class frmAdminModal : Form
    {
        public frmAdminModal()
        {
            InitializeComponent();
            // Hide the Status dropdown, this must be defaulted to Active for New Users.
            lblStatus.Visible = false;
            cbStatus.Visible = false;
            cboUserType.SelectedIndex = 0;
        }

        private int selectedId = 0;
        private readonly string UserKey = "";
        public frmAdminModal(int selectedAccountId)
        {
            InitializeComponent();
            this.selectedId = selectedAccountId;

            btnSave.Text = "Update";

            User user = new User();
            UserRepository userRepository = new UserRepository();

            user = userRepository.LoadAccountDetails(selectedAccountId);
            txtfname.Text = user.FirstName;
            txtmi.Text = user.MiddleName;
            txtlname.Text = user.LastName;
            txtEmail.Text = user.Email;
            txtmobilenum.Text = user.MobilePhone;
            txtUsername.Text = user.Username;
            // Password will not be loaded during update 
            cboUserType.Text = user.UserType;
            cbStatus.Text = user.Status;

            this.UserKey = user.UniqueKey();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to discard your update changes?\nThis will lose all your changes.","Discard changes",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string userKey = string.Concat(cboUserType.Text, txtUsername.Text, txtfname.Text, txtmi.Text, txtlname.Text, txtmobilenum.Text, txtEmail.Text, cbStatus.Text);
            if (this.UserKey.Equals(userKey))
            {
                MessageBox.Show("No update was done\nCannot proceed on the update.", "No changes detected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (cboUserType.SelectedIndex == 0)
            {
                MessageBox.Show("User type is required.\nKindly provide a `User type` to proceed.", "User type is required.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboUserType.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("The Username is invalid.\nKindly provide a valid username to proceed.", "Username is required.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUsername.Focus();
                return;
            }
            
            if (this.selectedId == 0)
            {
                if (string.IsNullOrEmpty(txtpass.Text) || string.IsNullOrWhiteSpace(txtpass.Text))
                {
                    MessageBox.Show("New user requires account password.\nKindly provide a password to proceed.", "Password is required.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtpass.Focus();
                    return;
                }
            }

            if (string.IsNullOrEmpty(txtfname.Text) || string.IsNullOrWhiteSpace(txtfname.Text) &&
                string.IsNullOrEmpty(txtlname.Text) || string.IsNullOrWhiteSpace(txtlname.Text))
            {
                MessageBox.Show("Kindly provide a valid user details (Name) to proceed.", "User detail is required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!isValidEmail)
            {
                MessageBox.Show("The email you provided is not valid.\nPlease provide a valid email address.", "Incorrect email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            if (this.selectedId == 0)
            {
                if (MessageBox.Show("Do you want to create a new user record?", "Confirm to create", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }
            else
            {
                if (MessageBox.Show("Do you want to update the record?", "Confirm to update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }

            User user = new User();
            user.Id = this.selectedId;
            user.FirstName = txtfname.Text;
            user.MiddleName = txtmi.Text;
            user.LastName = txtlname.Text;
            user.Email = txtEmail.Text;
            user.MobilePhone = txtmobilenum.Text;
            user.Username = txtUsername.Text;
            user.Password = (string.IsNullOrEmpty(txtpass.Text) || string.IsNullOrWhiteSpace(txtpass.Text)) ? "" : txtpass.Text;
            user.UserType = cboUserType.Text;
            user.Status = cbStatus.Text;

            UserRepository userRepository = new UserRepository();
            if (userRepository.Save(user))
            {
                MessageBox.Show((this.selectedId == 0) ? "New User has been successfully created." : "User details has been successfully updated.", "Saved Successfully",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Dispose();
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                isValidEmail = true;
            }
            else if (string.IsNullOrWhiteSpace(txtEmail.Text) || !IsValidEmail(txtEmail.Text)) 
            {
                MessageBox.Show("The email you provided is not valid.\nPlease provide a valid email address.", "Incorrect email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                isValidEmail = false;
            }
            else
            {
                isValidEmail = true;
            }
        }

        private bool isValidEmail = true;
        private bool IsValidEmail(string email)
        {
            // Define a regular expression for validating an email address
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }
    }
}
