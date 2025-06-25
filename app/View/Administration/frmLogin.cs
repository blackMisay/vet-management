using app.core.model;
using app.core.repository;
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
            AuthenticateUserCredential();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Do you want to exit the application?", "Confirm to exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                AuthenticateUserCredential();
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                AuthenticateUserCredential();
            }
        }

        private void AuthenticateUserCredential()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Kindly provide your correct username.", "Username is required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
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

            try
            {
                using (frmMain main = new frmMain())
                {
                    //this.Hide();
                    main.ShowDialog();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load the main form: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Show();
                txtPassword.Text = string.Empty;
                txtUsername.Focus();
            }
        }
    }
}
