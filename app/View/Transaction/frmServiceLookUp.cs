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
        public event Action<string, decimal> ServiceSelected;
        public frmServiceLookUp()
        {
            InitializeComponent();
        }

        private void frmServiceLookUp_Load(object sender, EventArgs e)
        {
            UpgradeFile upgradeFile = new UpgradeFile();
            dgvService.DataSource = upgradeFile.Load("SELECT * FROM services WHERE status = 'Active';");
        }
    }
}
