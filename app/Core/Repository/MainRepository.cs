using app.view.Dashboard;
using Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace app.core.repository
{
    internal class MainRepository
    {
           public string ComputeAll()
        {
            decimal total = 0m;
            DataTable dt;

            UpgradeFile upgradeFile = new UpgradeFile();
            dt = upgradeFile.Load("SELECT IFNULL(SUM(total - `change`), 0) AS todaysales FROM transaction_payment WHERE DATE(date) = CURDATE();");

            if (dt != null && dt.Rows.Count > 0 && dt.Rows[0]["todaysales"] != DBNull.Value)
            {
                decimal.TryParse(dt.Rows[0]["todaysales"].ToString(), out total);
            }

            return total.ToString("N2"); // Format with 2 decimal places, e.g. 1234.56
        }

        

        public string ComputeAllClients()
        {
            string clients = "";
            DataTable dt;

            UpgradeFile upgradeFile = new UpgradeFile();
            dt = upgradeFile.Load("SELECT patient FROM patient_consultation WHERE DATE(consult_date) = CURDATE();");

            int totalClients = dt.Rows.Count;
            clients = totalClients.ToString();

            return clients;
        }

    }
}
