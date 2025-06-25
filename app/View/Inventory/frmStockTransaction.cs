using app.core.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app.view.Inventory
{
    public partial class frmStockTransaction : Form
    {
        private readonly InventoryRepository inventoryRepository = new InventoryRepository();
        public frmStockTransaction()
        {
            InitializeComponent();
            LoadTransactionTypes();
        }

        private void frmStockTransaction_Load(object sender, EventArgs e)
        {

        }

        private void LoadTransactionTypes()
        {
            cmbTransactionType.Items.Clear();
            cmbTransactionType.Items.AddRange(new string[] { "All", "IN", "OUT" });
            cmbTransactionType.SelectedIndex = 0;
        }

        private void LoadTransactions()
        {
            if (cmbTransactionType.SelectedItem == null)
            {
                MessageBox.Show("Please select a transaction type.");
                return;
            }

            string type = cmbTransactionType.SelectedItem.ToString();
            DateTime from = dtpFrom.Value.Date;
            DateTime to = dtpTo.Value.Date.AddDays(1).AddSeconds(-1); // include the entire 'to' day

            dgvStock.DataSource = inventoryRepository.GetStockTransactions(type, from, to);

            // Format DataGridView columns
            if (dgvStock.Columns["id"] != null)
                dgvStock.Columns["id"].Visible = false;

            if (dgvStock.Columns["Quantity"] != null)
                dgvStock.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            if (dgvStock.Columns["Date"] != null)
                dgvStock.Columns["Date"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm";

        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            LoadTransactions();
        }
    }
}
