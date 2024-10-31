using app.core.model;
using app.core.repository;
using Core;
using System;
using System.Windows.Forms;

namespace app.view.Administration
{
    public partial class frmLogin : Form
    {
        private int Id;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {            
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Kindly provide your correct username.", "Username is required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Kindly provide your correct password.", "Password is required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            User account = new User() { Username = txtUsername.Text, Password = txtPassword.Text };
            if (!UserAuthentication.IsAuthenticated(account))
            {
                MessageBox.Show("The username or password you've entered is invalid.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (frmMain main = new frmMain())
            {
                this.Hide();
                main.ShowDialog();
                this.Show();
                txtPassword.Text = String.Empty;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Do you want to exit the application?", "Confirm to exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        public void SaveLogin()
        {
            core.model.User user = new core.model.User();
            user.Id = this.Id;
            user.Username = txtUsername.Text;
            user.Password = txtPassword.Text;

            UserRepository userRepository = new UserRepository();
            if (userRepository.Save(user))
            {
                MessageBox.Show("Login successfully");
            }
            else
            {
                MessageBox.Show("Unable to Login.", "Username or Password not Match",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
    }
}
