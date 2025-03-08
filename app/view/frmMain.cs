using System;
using System.Windows.Forms;
using System.Drawing;
using app.view.Administration;
using app.view.Immunization;
using app.view.Transaction;

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
        private static readonly string CONSULTATION = "Con&sultation";
        private static readonly string VACCINATION = "&Vaccination";
        private static readonly string ITEM = "I&tems";
        private static readonly string INVENTORY = "&Inventory";
        private static readonly string SERVICES = "Se&rvices";
        private static readonly string ACCOUNT = "&Accounts";
        private static readonly string SETTING = "Se&ttings";
        private static readonly string LOGOUT = "Lo&gout";

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You're logging out, are you sure do you want to proceed?", "Confirm to logout",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
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
                        button.ImageAlign = ContentAlignment.BottomRight;
                    }
                }

                btnDashboard.Text = DASHBOARD;
                btnMedicalRecords.Text = MEDICAL;
                btnClient.Text = CLIENT;
                btnConsultation.Text = CONSULTATION;
                btnVaccination.Text = VACCINATION;
                btnItem.Text = ITEM;
                btnInventory.Text = INVENTORY;
                btnServices.Text = SERVICES;
                btnAccount.Text = ACCOUNT;
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

        private void btnConsultation_Click(object sender, EventArgs e)
        {
            this.openFormModule(new Consultation.frmConsultation());
        }

        private void btnItem_Click(object sender, EventArgs e)
        {
            this.openFormModule(new Product.frmProducts());
        }
        private void btnInventory_Click(object sender, EventArgs e)
        {
            this.openFormModule(new Inventory.frmInventory());
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            view.Maintenance.frmMaintenanceModal maintenance = new view.Maintenance.frmMaintenanceModal();
            maintenance.ShowDialog();
        }

        private void btnServices_Click(object sender, EventArgs e)
        {
            this.openFormModule(new Services.frmServices());
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            this.openFormModule(new frmAdmin());
        }

        private void btnVaccination_Click(object sender, EventArgs e)
        {
            this.openFormModule(new frmImmunization());
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            this.openFormModule(new Dashboard.frmDashboard());
        }

        private void btnMedicalRecords_Click(object sender, EventArgs e)
        {
            this.openFormModule(new Transaction.frmTransaction());
           
        }
    }
}
