using app.core.model;
using Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace app.view.Product
{
    public partial class frmNewProductCategory : Form
    {
        private int id;
        public frmNewProductCategory()
        {
            InitializeComponent();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            // Ask the user for confirmation before canceling
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to cancel your work?", "Confirm Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show("Work has been cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            id = 0;
            panel3.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnAdd.Enabled = true;
            txtNewCategory.Clear();
            txtNewCategory.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ProductRepository categoryRepository = new ProductRepository();

            if (string.IsNullOrWhiteSpace(txtNewCategory.Text))
            {
                MessageBox.Show("Please input a valid category.", "VET App", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (categoryRepository.CheckCategory(txtNewCategory.Text, this.id))
                {
                    MessageBox.Show("The same category is already existing.", "VET App", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNewCategory.Clear();
                    return;
                }

                Category category = new Category()
                {
                    Id = this.id,
                    Name = txtNewCategory.Text
                };
                if (categoryRepository.AddCategory(category))
                {
                    MessageBox.Show("A new category has been added.", "VET App", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                categoryRepository.LoadCategory(dgvCategory);
            }
            txtNewCategory.Clear();
        }

        private void frmNewProductCategory_Load(object sender, EventArgs e)
        {
            ProductRepository categoryRepository = new ProductRepository();
            categoryRepository.LoadCategory(dgvCategory);
        }

        private void dgvCategory_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCategory.SelectedRows.Count > 0)
            {
                id = Convert.ToInt32(dgvCategory.SelectedRows[0].Cells["Column1"].Value);
                txtNewCategory.Text = dgvCategory.SelectedRows[0].Cells["Column2"].Value.ToString();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCategory.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a category to edit.", "POS App", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            txtNewCategory.Focus();
            txtNewCategory.SelectAll();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this category?", "VET App", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int Id = Convert.ToInt32(dgvCategory.SelectedRows[0].Cells["Id"].Value);
                ProductRepository categoryRepository = new ProductRepository();
                {
                    if (categoryRepository.Delete(Id))
                    {
                        MessageBox.Show("The selected category has been deleted successfully", "VET App", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    categoryRepository.LoadCategory(dgvCategory);
                }
            }
        }

        private void dgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Prevent header row issues
            {
                DataGridViewRow row = dgvCategory.Rows[e.RowIndex];
                txtNewCategory.Text = row.Cells["column2"].Value.ToString();
            }
        }
    }
}
