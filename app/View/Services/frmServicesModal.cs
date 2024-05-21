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

namespace app.view.Services
{
    public partial class FrmServicesModal : Form
    {
        int Id = 0;
        public FrmServicesModal()   
        {
            InitializeComponent();
            
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
            this.Dispose();
        }
    }

}
    

