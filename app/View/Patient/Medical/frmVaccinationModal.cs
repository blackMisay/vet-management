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
    public partial class frmVaccinationModal : Form
    {
        public frmVaccinationModal()
        {
            InitializeComponent();
        }

        private void frmVaccinationModal_Load(object sender, EventArgs e)
        {
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure that you want to cancel the vaccination?",
                                "Confirm to close form",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }    
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure that you want to cancel the vaccination?",
                                "Confirm to save vaccination",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MessageBox.Show("Saved successfully!",
                                "Sucess",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }

        static int cacheWeight = 0;
        private void chkUpdateWeight_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUpdateWeight.Checked)
            {
                MessageBox.Show("By checking the `Update weight`, you will agree to update the current weight of the pet.",
                                "Important",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                txtWeight.Enabled = true;
            }
            else
            {
                txtWeight.Enabled = false;
                txtWeight.Text = cacheWeight.ToString();
            }
        }

        private void dtpVaxDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpVaxDate.Value < DateTime.Now)
            {
                MessageBox.Show("Vaccination date should not be in the future.",
                                "Incorrect vaccination date",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                dtpVaxDate.Value = DateTime.Now;
            }
        }
    }
}
