using app.Core.Repository;
using app.View.Administration;
using app.View.Inventory;
using app.View.Product;
using app.View.Reports;
using app.View.Transaction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace app.View.Patient
{
    public partial class PetDetails : Form
    {
        int clientId = 0;
        public PetDetails(int selectedClientId)// Si selectedClientId yung tumatanggap kay selectedPatient
        {
            InitializeComponent();

            // Pass the selected client Id to the datagrid query to use as a filter in 
            // order to return or display pets based on the client's id.
            //LoadClientsPatients(selectedClientId);// and then pinapasa ulit natin yun kay LoadClientsPatients, para iload yung data ng pets
            this.clientId = selectedClientId; // ipapasa rin natin dito yung value ng selected ClientId yan kasi gagamitin natin kapag iapapasa naman natin sa AddPet kapag clinic natin yung Add
        }

        public PetDetails()
        {
            InitializeComponent();
        }

        private void PetDetails_Load(object sender, EventArgs e)
        {
            
        }

        

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (AddPet addPet = new AddPet(0, this.clientId))
            {
                addPet.ShowDialog();
            }
            //LoadClientsPatients(this.clientId);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvPet.SelectedRows.Count > 0)
            {
                int petId = Convert.ToInt32(dgvPet.SelectedRows[0].Cells["Id"].Value);
                MessageBox.Show(petId.ToString());
                AddPet addPet = new AddPet(petId);
                addPet.ShowDialog();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
          if (dgvPet.SelectedRows.Count > 0)
            {
                int petId = Convert.ToInt32(dgvPet.SelectedRows[0].Cells["Id"].Value);
                MessageBox.Show(petId.ToString());
                PetDetails details = new PetDetails(petId);
                details.ShowDialog();
            }
        }

        private void tspClient_Click(object sender, EventArgs e)
        {
            PetDetails petDetails = new PetDetails();
            petDetails.ShowDialog();
        }

        private void tspProduct_Click(object sender, EventArgs e)
        {
            Products products = new Products();
            products.ShowDialog();
        }

        private void tspInventory_Click(object sender, EventArgs e)
        {
            FrmInventory inventory = new FrmInventory();
            inventory.ShowDialog();
        }

        private void tspReport_Click(object sender, EventArgs e)
        {
            Report report = new Report();
            report.ShowDialog();
        }

        private void tspTransact_Click(object sender, EventArgs e)
        {
            FrmTransaction transaction = new FrmTransaction();
            transaction.ShowDialog();
        }

        private void tspAdmin_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            admin.ShowDialog();
        }
    }
    }

