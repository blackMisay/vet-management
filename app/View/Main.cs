using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using app.Core;
using app.Core.Repository;
using app.View.Patient;

namespace app
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            using (UpgradeFile upgradeFile = new UpgradeFile())
            {
                dgv.DataSource = upgradeFile.Load("SELECT * FROM vwclient;");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Patient patient = new Patient();
            patient.ShowDialog();
        }

        private void btnAddPet_Click(object sender, EventArgs e)
        {
            PetDetails pet = new PetDetails();
            pet.ShowDialog();
        }
    }
    }