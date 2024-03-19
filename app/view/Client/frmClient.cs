using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app.view.Client
{
    public partial class frmClient : Form
    {
        public frmClient()
        {
            InitializeComponent();
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            using (frmClientModal newClientForm = new frmClientModal())
            {
                newClientForm.ShowDialog();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // TODO: Create another constructor for Updating Client record by passing
            // the Id as parameter.
            using (frmClientModal newClientForm = new frmClientModal())
            {
                newClientForm.ShowDialog();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //TODO: Populate the datagridview based on the filtered name provided in Search box.
        }

        private void dgvClient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //TODO: Get the id of the selected record.
        }

        private void dgvClient_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //TODO: Using the returned id from the cellClick event. Used it to
            // retrieve the record from the database.
        }
    }
}
