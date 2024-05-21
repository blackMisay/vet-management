using System;
using System.Windows.Forms;
using System.Drawing;

namespace app.view
{
    public partial class frmMain : Form
    {
        private Form activeFormModule = null;

        private static readonly int MIN_WIDTH = 70;
        private static readonly int MAX_WIDTH = 230;

        private static readonly string DASHBOARD = "&Dashboard";
        private static readonly string MEDICAL = "&View Medical";
        private static readonly string CLIENT = "&Client";
        private static readonly string DIAGNOSIS = "Diag&nosis";
        private static readonly string ITEM = "I&tems";
        private static readonly string INVENTORY = "&Inventory";
        private static readonly string SETTING = "Se&ttings";
        private static readonly string LOGOUT = "Lo&gout";

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

        private void ToggleMenu()
        {
            if (pnlMenu.Width == MIN_WIDTH)
            {
                foreach (Control control in this.pnlMenu.Controls)
                {
                    if (control is Button button)
                    {
                        button.ImageAlign = ContentAlignment.MiddleLeft;
                    }
                }

                btnDashboard.Text = DASHBOARD;
                btnMedicalRecords.Text = MEDICAL;
                btnClient.Text = CLIENT;
                btnDiagnosis.Text = DIAGNOSIS;
                btnItem.Text = ITEM;
                btnInventory.Text = INVENTORY;
                btnSettings.Text = SETTING;
                btnLogout.Text = LOGOUT;
            }

            if (pnlMenu.Width == MAX_WIDTH)
            {
                foreach (Control control in this.pnlMenu.Controls)
                {
                    if (control is Button button)
                    {
                        button.Text = string.Empty;
                        button.ImageAlign = ContentAlignment.MiddleCenter;
                    }
                }
            }

            pnlMenu.Width = pnlMenu.Width == MIN_WIDTH ? MAX_WIDTH : MIN_WIDTH;
        }

        private void btnToggle_Click(object sender, EventArgs e)
        {
            this.ToggleMenu();
        }
        private void btnMedicalRecords_Click(object sender, EventArgs e)
        {
            this.openFormModule(new Transaction.frmTransaction());
        }

        private void btnDiagnosis_Click(object sender, EventArgs e)
        {
            this.openFormModule(new Services.frmServices());
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            this.openFormModule(new Product.frmProducts());
        }
    }
}
