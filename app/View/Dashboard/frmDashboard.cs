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
        private ConsultationRepository consultationRepo;
        public frmDashboard()
        {
            InitializeComponent();
            CheckLowStock();
            ComputeTotalSales();
            ComputeTotalClients();
            consultationRepo = new ConsultationRepository();
            ComputeTotalUpcomingFollowUps();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            dgvReminders.CellFormatting += dgvReminders_CellFormatting;
            LoadVaccinationReminders(); // The method that loads the reminders

            LoadUpcomingFollowUps();

            dgvLowStock.CellClick += dgvLowStock_CellClick;

        }

        private void CheckLowStock()
        {
            UpgradeFile upgradeFile = new UpgradeFile();

            string query = @"
                    SELECT id, description, stock,
                           CASE 
                               WHEN stock = 0 THEN 'No Stock'
                               WHEN stock <= 10 THEN 'Low Stock'
                               ELSE 'OK'
                           END AS Status
                    FROM vw_inventory_products
                    WHERE stock <= 10";

            DataTable dt = upgradeFile.Load(query, null);

            if (dt != null && dt.Rows.Count > 0)
            {
                dgvLowStock.DataSource = dt;

                if (dt != null && dt.Rows.Count > 0)
                {
                    ////Show low stock alert before populating DataGridView
                    //MessageBox.Show($"⚠ {dt.Rows.Count} item(s) are low or out of stock.", "Stock Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    dgvLowStock.DataSource = dt;

                    // Apply row colors based on stock level
                    foreach (DataGridViewRow row in dgvLowStock.Rows)
                    {
                        string status = row.Cells["Status"]?.Value?.ToString();

                        if (status == "No Stock")
                            row.DefaultCellStyle.BackColor = Color.LightCoral;
                        else if (status == "Low Stock")
                            row.DefaultCellStyle.BackColor = Color.Khaki;
                    }
                }
                else
                {
                    dgvLowStock.DataSource = null;
                }
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

        private void LoadUpcomingFollowUps()
        {
            ConsultationRepository repo = new ConsultationRepository();
            DataTable dt = repo.GetUpcomingFollowUps();

            dgvFollowUps.DataSource = dt;
            dgvFollowUps.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFollowUps.ReadOnly = true;
            dgvFollowUps.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // ✅ Count follow-ups for today
            int todayCount = dt.Select($"CONVERT([Follow-Up Date], System.DateTime) = '{DateTime.Today.ToShortDateString()}'").Length;

            // ✅ Show total count in label
            lblUpcomingCount.Text = todayCount.ToString();
        }
        private void ComputeTotalUpcomingFollowUps()
        {
            ConsultationRepository consultationRepository = new ConsultationRepository();
            string followUps = consultationRepository.ComputeUpcomingFollowUpsCount();

            if (int.TryParse(followUps, out int followUpCount))
            {
                lblUpcomingCount.Text = followUpCount.ToString("N0"); // just the number with commas
            }
            else
            {
                lblUpcomingCount.Text = "0";
            }
        }

        private void dgvLowStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            string id = dgvLowStock.Rows[e.RowIndex].Cells["id"].Value?.ToString();
            string desc = dgvLowStock.Rows[e.RowIndex].Cells["description"].Value?.ToString();
            string stock = dgvLowStock.Rows[e.RowIndex].Cells["stock"].Value?.ToString();

            MessageBox.Show($"Selected: {desc}\nStock: {stock}", "Item Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

    

