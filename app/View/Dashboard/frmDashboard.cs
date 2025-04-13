using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using Core;
using System.Drawing;

namespace app.view.Dashboard
{
    public partial class frmDashboard : Form
    {
        private string connectionString = "";
        public frmDashboard()
        {
            InitializeComponent();
            CheckExpiringItems();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {

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
    }
    }

