using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app.view.Patient.Medical
{
    public partial class frmPatientMedical : Form
    {
        public frmPatientMedical()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void frmPatientMedical_Load(object sender, EventArgs e)
        {
            lblOwner.Text = string.Concat("Owner: ","Russelle Bodo Carolino Jr.");
            lblAddress.Text = string.Concat("Address: ", "Blk 41 Lot 7, Brunei St., Harmony Hills 1 Subdivision, Muzon, San Jose Del Monte, Bulacan");
        }
    }
}
