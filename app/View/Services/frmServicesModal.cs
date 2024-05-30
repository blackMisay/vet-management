using app.Core.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using app.Core.Model;
using System.Xml.Linq;
using app.core.Repository;
using app.view.Services;
using app.view.Product;

namespace app.view.Services
{
    public partial class FrmServicesModal : Form
    {
       private int Id = 0;
        public FrmServicesModal()   
        {
            InitializeComponent();
            this.Load += frmServicesModal_Load;
            
        }
        public FrmServicesModal(int serviceId) : this()
        {
            this.Id = serviceId;
            LoadServiceDetails();
            btnSave.Text = "Update";
            label1.Text = "Update Service Details";
        }

        private void frmServicesModal_Load(object sender, EventArgs e)
        {
            UpgradeFile upgradeFile = new UpgradeFile();

        }
        public void SaveService()
        {
            app.core.model.Services services = new app.core.model.Services();
           
            services.Id = this.Id;
            services.ServiceCode = txtCode.Text;
            services.Description = txtDesc.Text;
            services.Price = txtPrice.Text;
            ServiceRepository serviceRepository = new ServiceRepository();
            if (serviceRepository.SaveService(services))
            {
                MessageBox.Show("Save successfully");
            }
            else
            {
                MessageBox.Show("Unable to save record");
            }
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
            SaveService();
            UpgradeFile upgradeFile = new UpgradeFile();

            // Ensure that frmServices is properly instantiated
            frmServices services = new frmServices();

            // Access the dgvServices instance correctly
            services.dgvServices.DataSource = upgradeFile.Load("SELECT * FROM services WHERE isDeleted = 0");

            // Optional: Show the services form, if needed
            services.Show();

            // Dispose of the current form
            this.Dispose();
        }


        private void LoadServiceDetails()
        {
            ServiceRepository serviceRepository = new ServiceRepository();
            var service = serviceRepository.GetService(new app.core.model.Services() { Id = this.Id });
        }

        private void LoadDetails(app.core.model.Services services)
        {
            txtCode.Text = services.ServiceCode;
            txtDesc.Text = services.Description;
            txtPrice.Text = services.Price;
        }
    }

}
    

