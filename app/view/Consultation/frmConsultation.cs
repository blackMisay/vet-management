using app.core.repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app.view.Consultation
{
    public partial class frmConsultation : Form
    {
        public frmConsultation()
        {
            InitializeComponent();
        }

        private void btnNewConsultation_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want a patient to undergo consultation?\nClick Yes to proceed consultation.","New Consultation",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                frmConsultationModal form = new frmConsultationModal();
                form.ShowDialog();
                LoadAllConsultationRecords();
            }
        }

        int selectedId = 0;
        private void dgvConsultation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvConsultation.RowCount > 0)
            {
                int selectedRowIndex = dgvConsultation.SelectedCells[0].RowIndex;
                this.selectedId = Convert.ToInt32(dgvConsultation.Rows[selectedRowIndex].Cells[0].Value?.ToString());
            }
        }

        private void btnRemoveConsultation_Click(object sender, EventArgs e)
        {
            if (selectedId > 0)
            {
                if (MessageBox.Show("Do you want to remove an existing consultation?\nThis action won't be reverted.", "Remove Consultation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ConsultationRepository cmd = new ConsultationRepository();
                    cmd.Delete(selectedId);
                    LoadAllConsultationRecords();
                }
            }
            else
            {
                MessageBox.Show("Select a record first.", "Unable to delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEditConsultation_Click(object sender, EventArgs e)
        {
            if (selectedId > 0)
            {
                if (MessageBox.Show("Do you want to update an existing consultation?\nClick Yes to proceed.", "Update Consultation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    frmConsultationModal form = new frmConsultationModal(this.selectedId);
                    form.ShowDialog();
                    LoadAllConsultationRecords();
                }
            }
            else
            {
                MessageBox.Show("Select a record first.", "Unable to update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmConsultation_Load(object sender, EventArgs e)
        {
            LoadAllConsultationRecords();
        }

        public void LoadAllConsultationRecords()
        {
            ConsultationRepository cr = new ConsultationRepository();

            dgvConsultation.DataSource =  cr.GetAllConsultation();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ConsultationRepository cr = new ConsultationRepository();

            cr.GetSpecificConsultation(txtSearch.Text);
        }

        public app.Core.Model.Pet SelectedRecord { get; private set; }


        private void dgvConsultation_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SelectedRecord = new app.Core.Model.Pet
                {
                    Id = Convert.ToInt32(dgvConsultation.Rows[e.RowIndex].Cells["Id"].Value),
                    Client = new app.Core.Model.Client
                    {
                        FirstName = dgvConsultation.Rows[e.RowIndex].Cells["Owner"].Value.ToString(),

                    },
                    Name = dgvConsultation.Rows[e.RowIndex].Cells["Patient"].Value.ToString()
                };

                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }
    }
}
