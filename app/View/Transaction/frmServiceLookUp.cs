using Core;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using app.core.model;

namespace app.view.Transaction
{
    public partial class frmServiceLookUp : Form

    {
        private Dictionary<int, app.core.model.Services> selectedService;
        
        public frmServiceLookUp()
        {
            InitializeComponent();
            selectedService = new Dictionary<int, app.core.model.Services>();
        }
        public frmServiceLookUp(Dictionary<int, app.core.model.Services> service)
        {
            InitializeComponent();
            selectedService = service;
        }
        public Dictionary<int, app.core.model.Services> GetAllServices()
        {
            return selectedService;
        }

        private void frmServiceLookUp_Load(object sender, EventArgs e)
        {
            lblDesc.Text = "This form allows the user to select services.";

            UpgradeFile upgradeFile = new UpgradeFile();

            dgvServices.DataSource = upgradeFile.Load("SELECT * FROM vwservices WHERE status = 'Active'");
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            app.core.model.Services service = new app.core.model.Services
            {
                Id = selectedId,
                Description = selectedItemDescription,
                Price = selectedItemPrice // Use the price directly from the selected service
            };

            // Add the service to the dictionary
            selectedService.Add(selectedId, service);

            // Show success message
            MessageBox.Show(
                $"Service \"{selectedItemDescription}\" has been added successfully with a price of {selectedItemPrice:F2}.",
                "Added Successfully",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            // Reset UI elements
            btnRemove.Enabled = false;
            ResetItemField();
 


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ResetItemField()
        {
            txtTotal.Text = string.Empty;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (selectedService.Count > 0 && selectedService.ContainsKey(selectedId))
            {
                if (MessageBox.Show("Do you want to remove the selected service?", "Confirm to remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    selectedService.Remove(selectedId);
                    btnRemove.Enabled = false;
                }
            }
        }
        int selectedId = 0;
        double selectedItemPrice;
        string selectedItemDescription;
        private void dgvServices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvServices.RowCount > 0)
            {
                int selectedRowIndex = dgvServices.SelectedCells[0].RowIndex;

                this.selectedId = Convert.ToInt32(dgvServices.Rows[selectedRowIndex].Cells[0].Value?.ToString());
                this.selectedItemPrice = Convert.ToDouble(dgvServices.Rows[selectedRowIndex].Cells[4].Value?.ToString());
                this.selectedItemDescription = dgvServices.Rows[selectedRowIndex].Cells[1].Value?.ToString() + " - " + dgvServices.Rows[selectedRowIndex].Cells[3].Value?.ToString();

                if (selectedService.Count > 0)
                {
                    if (selectedService.ContainsKey(selectedId))
                    {
                        btnRemove.Enabled = true;

                        if (MessageBox.Show("Do you want to update already selected service ?", "Confirm to update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            app.core.model.Services service = new app.core.model.Services();
                            service = selectedService[selectedId];

                            txtTotal.Text = service.Price.ToString();
                        }
                    }
                    else
                    {
                        btnRemove.Enabled = false;
                    }
                }
                else
                {
                    ResetItemField();
                }
            }


        }
    }
}
