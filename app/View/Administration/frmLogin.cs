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
            //SaveLogin();
            UpgradeFile upgradeFile = new UpgradeFile();
            frmMain main = new frmMain();
            main.ShowDialog();
            this.Dispose();
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

        public void SaveLogin()
        {
            core.model.User user = new core.model.User();
            user.Id = this.Id;
            user.Username = txtusername.Text;
            user.Password = txtpass.Text;

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
