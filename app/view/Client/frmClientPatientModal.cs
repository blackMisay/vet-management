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
    public partial class frmClientPatientModal : Form
    {
        public frmClientPatientModal()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //TODO: Save function for pet
        }

        private void btnAddPhoto_Click(object sender, EventArgs e)
        {
            //TODO: Add photo
        }

        private void frmClientPatientModal_Load(object sender, EventArgs e)
        {

        }
    }
}
