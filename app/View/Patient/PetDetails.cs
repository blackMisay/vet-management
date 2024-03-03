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
    public partial class PetDetails : Form
    {
        public PetDetails()
        {
            InitializeComponent();
        }

        private void PetDetails_Load(object sender, EventArgs e)
        {
            using (UpgradeFile upgradeFile = new UpgradeFile())
            {
                dgvPet.DataSource = upgradeFile.Load("SELECT * FROM vwpet;");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddPet addPet = new AddPet();  
            addPet.ShowDialog();
        }
    }
}
