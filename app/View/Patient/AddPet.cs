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
    public partial class AddPet : Form
    {
        public AddPet()
        {
            InitializeComponent();
        }
        private void AddPet_Load(object sender, EventArgs e)
        {
            {
                using (UpgradeFile upgradeFile = new UpgradeFile())
                {
                    cboGender.DataSource = upgradeFile.Populate("SELECT sexID, sexName FROM gender;");
                    cboGender.ValueMember = "Key";
                    cboGender.DisplayMember = "Value";

                    cboBreed.DataSource = upgradeFile.Populate("SELECT breedID, breedDesc FROM breed;");
                    cboBreed.ValueMember = "Key";
                    cboBreed.DisplayMember = "Value";

                    cboColor.DataSource = upgradeFile.Populate("SELECT colorID, colorName FROM color;");
                    cboColor.ValueMember = "Key";
                    cboColor.DisplayMember = "Value";

                    cboSpecies.DataSource = upgradeFile.Populate("SELECT speciesID, speciesName FROM species;");
                    cboSpecies.ValueMember = "Key";
                    cboSpecies.DisplayMember = "Value";

                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
