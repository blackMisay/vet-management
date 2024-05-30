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
using app.core.model;

namespace app.view.Services
{
        public partial class FrmServicesModal : Form
        {
            private int Id = 0;

            public FrmServicesModal()
            {
                InitializeComponent();
                this.Load += FrmServicesModal_Load;
            }

            public FrmServicesModal(int serviceId) : this()
            {
                this.Id = serviceId;
                LoadServiceDetails();
                btnSave.Text = "Update";
                label1.Text = "Update Service Details";
            }

            private void FrmServicesModal_Load(object sender, EventArgs e)
            {
                // Any additional initialization code can go here.
            }

            public void SaveService()
            {
                app.core.model.Services services = new app.core.model.Services
                {
                    Id = this.Id,
                    ServiceCode = txtCode.Text,
                    Description = txtDesc.Text,
                    Price = txtPrice.Text,
                };

                ServiceRepository serviceRepository = new ServiceRepository();
                if (serviceRepository.SaveService(services))
                {
                    MessageBox.Show("Saved successfully");
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
                frmServices servicesForm = new frmServices();

                // Access the dgvServices instance correctly
                servicesForm.dgvServices.DataSource = upgradeFile.Load("SELECT * FROM services WHERE isDeleted = 0");

                // Optional: Show the services form, if needed
                servicesForm.Show();

                // Dispose of the current form
                this.Dispose();
            }

            private void LoadServiceDetails()
            {
                ServiceRepository serviceRepository = new ServiceRepository();
                var fetchedService = serviceRepository.GetService(new app.core.model.Services { Id = this.Id });

                if (fetchedService != null)
                {
                    LoadDetails(fetchedService);
                }
                else
                {
                    MessageBox.Show("Service details not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            private void LoadDetails(app.core.model.Services service)
            {
                txtCode.Text = service.ServiceCode;
                txtDesc.Text = service.Description;
                txtPrice.Text = service.Price.ToString(); // Ensure correct conversion
            }
        }


    }



