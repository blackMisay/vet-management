using app.core.model;
using app.core.repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app.view.Administration
{
    public partial class frmAdminModal : Form
    {
        public frmAdminModal()
        {
            InitializeComponent();
        }

        private int selectedId = 0;
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
        }

        private void frmAdminModal_Load(object sender, EventArgs e)
        {

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
            if (this.selectedId == 0)
            {
                MessageBox.Show("New user requires account password.\nKindly provide a password to proceed.","Password is required.",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                txtpass.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("The Username is invalid.\nKindly provide a valid username to proceed.", "Username is required.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUsername.Focus();
                return;
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
                MessageBox.Show("A user details has been saved successfully.","Saved Successfully",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Dispose();
            }
        }
    }
}
