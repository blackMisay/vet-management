using System;
using System.Windows.Forms;
using app.core.Repository;

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
                if (string.IsNullOrWhiteSpace(txtDesc.Text) || string.IsNullOrWhiteSpace(txtPrice.Text))
                {
                    MessageBox.Show("Description and Price are required.");
                    return;
                }

                // Check if the price text contains any spaces
                if (txtPrice.Text.Contains(" "))
                {
                    MessageBox.Show("Price must not contain any spaces.");
                    return;
                }

                // Check for leading zeros (excluding valid "0" case)
                if (txtPrice.Text.StartsWith("0") && txtPrice.Text.Length > 1 && !txtPrice.Text.StartsWith("0."))
                {
                    MessageBox.Show("Price cannot have leading zeros. Please enter a valid positive number.");
                    return;
                }

                // Try to parse the price as a decimal
                if (!decimal.TryParse(txtPrice.Text, out decimal price))
                {
                    MessageBox.Show("Price must be a valid number.");
                    return;
                }

                // Check if the price is negative
                if (price < 0)
                {
                    MessageBox.Show("Price cannot be negative. Please enter a valid positive number.");
                    return;
                }

                // Create a service instance with values
                var service = new app.core.model.Services
                {
                    Id = this.Id, // Assuming this.Id will be 0 for new services
                    ServiceCode = txtCode.Text.Trim(), // Trim to remove extra spaces
                    Description = txtDesc.Text.Trim(),
                    Price = price.ToString("F2") // Format price to 2 decimal places
                };

                // Use repository to check for duplicate service code
                var serviceRepository = new ServiceRepository();
                bool isDuplicate = service.Id == 0
                    ? serviceRepository.IsDuplicateServiceCode(service.ServiceCode, 0) // Check for new service
                    : serviceRepository.IsDuplicateServiceCode(service.ServiceCode, service.Id); // Check for updates

                if (isDuplicate)
                {
                    MessageBox.Show("The service code already exists. Please use a different code.", "Duplicate Service Code", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Save or update the service
                bool success = serviceRepository.SaveService(service);
                if (success)
                {
                    MessageBox.Show(service.Id == 0 ? "Saved successfully." : "Service updated successfully.");
                    this.Close(); // Close the form
                }
                else
                {
                    MessageBox.Show("Unable to save/update the service. Please check the details and try again.");
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



