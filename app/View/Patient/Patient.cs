using app.Core.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app.View.Patient
{
    public partial class Patient : Form
    {
        public Patient()
        {
            InitializeComponent();
        }

        private void Patient_Load(object sender, EventArgs e)
        {
            {
                using (UpgradeFile upgradeFile = new UpgradeFile())
                {
                    cboRegion.DataSource = upgradeFile.Populate("SELECT regCode, regDesc FROM region;");
                    cboRegion.ValueMember = "Key";
                    cboRegion.DisplayMember = "Value";

                    cboProvince.DataSource = upgradeFile.Populate("SELECT provCode, provDesc FROM province;");
                    cboProvince.ValueMember = "Key";
                    cboProvince.DisplayMember = "Value";

                    cboCity.DataSource = upgradeFile.Populate("SELECT citymunCode, citymunDesc FROM city;");
                    cboCity.ValueMember = "Key";
                    cboCity.DisplayMember = "Value";

                    cboBrgy.DataSource = upgradeFile.Populate("SELECT brgyCode, brgyDesc FROM brgy;");
                    cboBrgy.ValueMember = "Key";
                    cboBrgy.DisplayMember = "Value";
                    
                }
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
           this.Close();
        }
    }
}
