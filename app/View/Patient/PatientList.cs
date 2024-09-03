using app.Core.Model;
using app.Core.Repository;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core;

namespace app.View.Patient
{
    public partial class PatientList : Form
    {
        public PatientList()
        {
            InitializeComponent();
        }

        private void PatientList_Load(object sender, EventArgs e)
        {
            UpgradeFile upgradeFile = new UpgradeFile();
            
                dgvPatient.DataSource = upgradeFile.Load("SELECT * FROM vwpatient;");
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnPetDetails_Click(object sender, EventArgs e)
        {
            // If there is no selected client (selectedPatient is equal to zero), Notify to select first before proceeding. 
            if (this.selectedPatient == 0)
            {// KAPAG DI KA PUMILI NG RECORD SA DATAGRID, IBIG SABIHIN ZERO YUNG `selectedPatient`. kasi di sya naoverwrite sa CellClick
                MessageBox.Show("Please select a client in the list", "No client selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }// So kapag may sinelect tayo sa datagrid, ibig sabihin yung `selectedPatient` may value.

            // Pass the selected client Id to PetDetails form.
            PetDetails pet = new PetDetails(this.selectedPatient);// pinapasa natin yun as a Paramter sa PetDetails form
            pet.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddClient addPatient = new AddClient();
            addPatient.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvPatient.SelectedRows.Count > 0)
            {
                int clientId = Convert.ToInt32(dgvPatient.SelectedRows[0].Cells["Id"].Value);
                MessageBox.Show(clientId.ToString());
                AddClient addClient = new AddClient(clientId);
                addClient.ShowDialog();
            }
        }

        int selectedPatient = 0;
        private void dgvPatient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // KAPAG YUNG DATAGRID MO IS MAY ROW/RECORD, SAKA LANG MAGEEXECUTE YUNG CODE
            if (dgvPatient.RowCount > 0)
            {
                // KINUKUHA NYA YUNG ID, TAPOS PINAPASA NYA SA `selectedPatient`
                int selectedRowIndex = dgvPatient.SelectedCells[0].RowIndex;
                this.selectedPatient = Convert.ToInt32(dgvPatient.Rows[selectedRowIndex].Cells[0].Value?.ToString());
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvPatient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {  
    }

    private void btnSearch_Click(object sender, EventArgs e)
        {
            }

        private void toolStripStatusLabel3_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = DateTime.Now.ToLongDateString();
        }

    }
}
