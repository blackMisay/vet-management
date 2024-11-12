using app.core.repository;
using System;
using System.Windows.Forms;

namespace app.view.Administration
{
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
        }

        private void LoadAccounts()
        {
            UserRepository user = new UserRepository();
            dgvAdmin.DataSource = user.LoadUserAccount();
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            LoadAccounts();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to create a new user account?","Confirm to create new user",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (frmAdminModal modal = new frmAdminModal())
                {
                    modal.ShowDialog();
                }
                LoadAccounts();
            }
            this.selectedAccountId = 0;
        }

        int selectedAccountId = 0;
        private void dgvAdmin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAdmin.RowCount > 0)
            {
                int selectedRowIndex = dgvAdmin.SelectedCells[0].RowIndex;
                this.selectedAccountId = Convert.ToInt32(dgvAdmin.Rows[selectedRowIndex].Cells[0].Value?.ToString());
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.selectedAccountId > 0)
            {
                if (MessageBox.Show("Do you want to update the selected record?","Confirm to update",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (frmAdminModal modal = new frmAdminModal(selectedAccountId))
                    {
                        modal.ShowDialog();
                    }
                    LoadAccounts();
                }
                this.selectedAccountId = 0;
            }
            else
            {
                MessageBox.Show("Please select a record first before updating.","Unknown record to update",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text) || !string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                UserRepository userRepository = new UserRepository();
                dgvAdmin.DataSource = userRepository.LoadUserAccount(txtSearch.Text);
          }
            else
            {
                MessageBox.Show("The search field is empty, please provide.", "Empty field", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            txtSearch.Text = String.Empty;

            LoadAccounts();
        }
    }
}
