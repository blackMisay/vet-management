using Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app.view.Transaction
{
    public partial class frmServiceLookUp : Form
    {
        public frmServiceLookUp()
        {
            InitializeComponent();
        }

        private void frmServiceLookUp_Load(object sender, EventArgs e)
        {
            lblDesc.Text = "This form allows the user to select services.";

            UpgradeFile upgradeFile = new UpgradeFile();

            dgvServices.DataSource = upgradeFile.Load("SELECT * FROM vwservices WHERE status = 'Active'");
        }
    }
}
