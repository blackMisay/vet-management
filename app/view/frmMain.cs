using System;
using System.Windows.Forms;

namespace app.view
{
    public partial class frmMain : Form
    {
        private Form activeFormModule = null;
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm to logout","You're logging out, are you sure do you want to proceed?",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // TODO: Implement activity logging for user
                this.Dispose();
            }
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            this.openFormModule(new Client.frmClient());
        }

        private void openFormModule(Form formModule)
        {
            if (!(activeFormModule == null))
            {
                activeFormModule.Close();
            }

            activeFormModule = formModule;
            formModule.TopLevel = false;
            formModule.FormBorderStyle = FormBorderStyle.None;
            formModule.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(formModule);
            pnlBody.Tag = formModule;
            formModule.BringToFront();
            formModule.Show();
        }
    }
}
