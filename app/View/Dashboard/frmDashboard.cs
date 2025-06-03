using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using Core;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using app.core.repository;

namespace app.view.Dashboard
{
    public partial class frmDashboard : Form
    {
        private string connectionString = "";
        public frmDashboard()
        {
            InitializeComponent();
            CheckExpiringItems();
            ComputeTotalSales();
            ComputeTotalClients();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            dgvReminders.CellFormatting += dgvReminders_CellFormatting;
            LoadVaccinationReminders(); // The method that loads the reminders
        }

        private void CheckExpiringItems()
        {
            UpgradeFile upgradeFile = new UpgradeFile();

            string query = @"
        SELECT stockID, stockDescription, DATE(expDate) AS expDate
        FROM vwinventory
        WHERE expDate <= CURDATE() + INTERVAL 7 DAY";

            DataTable dt = upgradeFile.Load(query, null);

            if (dt != null && dt.Rows.Count > 0)
            {
                // Add Status column
                if (!dt.Columns.Contains("Status"))
                    dt.Columns.Add("Status", typeof(string));

                DateTime today = DateTime.Today;

                foreach (DataRow row in dt.Rows)
                {
                    if (DateTime.TryParse(row["expDate"].ToString(), out DateTime expDate))
                    {
                        if (expDate < today)
                            row["Status"] = "Expired";
                        else
                            row["Status"] = "Expiring Soon";
                    }
                }

                dgvExpiredItems.DataSource = dt;

                // Color-code rows based on expiration
                foreach (DataGridViewRow row in dgvExpiredItems.Rows)
                {
                    if (row.Cells["expDate"].Value != null)
                    {
                        DateTime expDate = Convert.ToDateTime(row.Cells["expDate"].Value);

                        if (expDate < today)
                        {
                            row.DefaultCellStyle.BackColor = Color.LightCoral; // Expired - red
                        }
                        else if (expDate <= today.AddDays(7))
                        {
                            row.DefaultCellStyle.BackColor = Color.Khaki; // Expiring soon - yellow
                        }
                    }
                }
            }
            else
            {
                dgvExpiredItems.DataSource = null;
            }
        }

        private void ComputeTotalSales()
        {
            MainRepository MainRepository = new MainRepository();
            string sales = MainRepository.ComputeAll();

            if (double.TryParse(sales, out double salesfr))
            {
                lblTodaySales.Text = salesfr.ToString("#,##0.00");
            }
            else
            {
                lblTodaySales.Text = "0.00";
            }
        }

        private void ComputeTotalClients()
        {
            MainRepository mainRepository = new MainRepository();
            string clients = mainRepository.ComputeAllClients();

            if (int.TryParse(clients, out int clientsCount))
            {
                lblTotalPatients.Text = clientsCount.ToString("N0"); // formatted with comma (e.g., 1,000)
            }
            else
            {
                lblTotalPatients.Text = "0";
            }
        }

        private void dgvReminders_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvReminders.Columns[e.ColumnIndex].Name == "expiration_date")
            {
                DateTime expDate = Convert.ToDateTime(e.Value);
                if (expDate <= DateTime.Now.AddDays(2))
                {
                    dgvReminders.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightSalmon;
                }
                else
                {
                    dgvReminders.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightYellow;
                }
            }
        }

        private void LoadVaccinationReminders()
        {
            PetVaccinationRepository repo = new PetVaccinationRepository();
            DataTable upcomingVaccines = repo.GetUpcomingVaccinations();

            dgvReminders.DataSource = upcomingVaccines; // Make sure dgvReminders exists
        }

    }
}

    

