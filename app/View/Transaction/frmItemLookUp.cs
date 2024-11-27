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

namespace app.view.Product
{
    public partial class frmItemLookUp : Form
    {
        public frmItemLookUp()
        {
            InitializeComponent();
        }

        private void frmItemLookUp_Load(object sender, EventArgs e)
        {
            UpgradeFile upgradeFile = new UpgradeFile();
            dgvProduct.DataSource = upgradeFile.Load("SELECT * FROM vwinventory WHERE isDeleted = 0;");
        }
    }
}
