using System;
using System.Windows.Forms;
using app.Core.Model;
using app.core.Repository;
using Core;

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
            try
            {
                // Validate input
                if (string.IsNullOrEmpty(txtDesc.Text) || string.IsNullOrEmpty(txtPrice.Text))
                {
                    MessageBox.Show("Description and Price are required.");
                    return;
                }

                // Remove spaces from the price text and try to parse it
                string priceText = txtPrice.Text.Replace(" ", string.Empty);
                if (!decimal.TryParse(priceText, out decimal price))
                {
                    MessageBox.Show("Price must be a valid number without spaces.");
                    return;
                }

                // Create service instance with values
                app.core.model.Services service = new app.core.model.Services
                {
                    Id = this.Id, // Assuming this.Id will be 0 for new services
                    ServiceCode = txtCode.Text,
                    Description = txtDesc.Text,
                    Price = price.ToString("F2") // Format price to 2 decimal places
                };

                // Use repository to check if service code already exists
                ServiceRepository serviceRepository = new ServiceRepository();

                if (service.Id == 0) // If ID is 0, it's a new service
                {
                    // Check for duplicate service code for new service
                    if (serviceRepository.IsDuplicateServiceCode(service.ServiceCode, 0)) // Pass 0 for new service
                    {
                        MessageBox.Show("The service code already exists. Please use a different code.", "Duplicate Service Code", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Save new service
                    if (serviceRepository.SaveService(service))
                    {
                        MessageBox.Show("Saved successfully.");
                        this.DialogResult = DialogResult.OK; // Indicate success
                        this.Close(); // Close the form
                    }
                    else
                    {
                        MessageBox.Show("Unable to save record. Please check the details and try again.");
                    }
                }
                else // If ID is not 0, it's an update
                {
                    // Check for duplicate service code when updating an existing service
                    if (serviceRepository.IsDuplicateServiceCode(service.ServiceCode, service.Id)) // Pass current service ID to exclude it from the check
                    {
                        MessageBox.Show("The service code already exists. Please use a different code.", "Duplicate Service Code", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Update the service
                    if (serviceRepository.SaveService(service))
                    {
                        MessageBox.Show("Service updated successfully.");
                        this.DialogResult = DialogResult.OK; // Indicate success
                        this.Close(); // Close the form
                    }
                    else
                    {
                        MessageBox.Show("Unable to update service. Please check the details and try again.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
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



