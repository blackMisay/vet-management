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
            string sales = "";
            DataTable dt;

            UpgradeFile upgradeFile = new UpgradeFile();
            dt = upgradeFile.Load("SELECT SUM(total_amount - change_amount) AS todaysales FROM transaction WHERE DATE(date) = CURDATE();");

        if (dt.Rows.Count > 0)
            {
                sales = dt.Rows[0]["todaysales"].ToString();
            }
        return sales;
        }

        public string ComputeAllClients()
        {
            string clients = "";
            DataTable dt;

            UpgradeFile upgradeFile = new UpgradeFile();
            dt = upgradeFile.Load("SELECT patient FROM consultation WHERE DATE(consult_date) = CURDATE();");

            int totalClients = dt.Rows.Count;
            clients = totalClients.ToString();

            return clients;
        }
        }
}
