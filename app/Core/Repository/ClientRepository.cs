using app.Core.Model;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Core.Repository
{
    internal class ClientRepository : ClientRepositoryBase
    {
        public bool Save(Client client)
        {
            string sql;

            bool saveState = client.Id > 0 ? true : false;

            if (saveState)
            {
                sql = "UPDATE clients SET clientid=@ClientID,fname=@FirstName,lname=@LastName,mi=@MiddleName,suffix=@Suffix,dob=@DateofBirth,sex=@Sex,civilstat=@CivilStatus,tellnum=@TelePhone,cellnum=@CellPhone,email=@EmailAddress,street_no=@StreetNo,regionID=@Region,cityID=@City,brgyID=@Brgy,provinceID=@Province WHERE clientid=@ClientID;";
            }
            else
            {
                sql = "INSERT INTO clients(clientid,fname,lname,mi,suffix,dob,sex,civilstat,tellnum,cellnum,email,street_no,regionID,cityID,brgyID,provinceID) VALUES(@ClientID,@FirstName,@LastName,@MiddleName,@Suffix,@DateofBirth,@Sex,@CivilStatus,@TelePhone,@CellPhone,@EmailAddress,@StreetNo,@Region,@City,@Brgy,@Province);";
            }
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                {"@ClientID", Convert.ToString(client.Id)},
                {"@FirstName", client.FirstName },
                {"@LastName", client.LastName },
                {"@MiddleName", client.MiddleName },
                {"@Suffix", client.Suffix },
                {"@DateofBirth", client.DateofBirth },
                {"@Sex", client.Sex },
                {"@CivilStatus", client.CivilStatus },
                {"@CellPhone", client.CellPhone },
                {"@TelePhone", client.TelePhone },
                {"@EmailAddress", client.EmailAddress },
                {"@StreetNo", client.StreetNo },
                {"@Region", client.Region.Id.ToString() },
                {"@City", client.City.Id.ToString() },
                {"@Brgy", client.Brgy.Id.ToString() },
                {"@Province", client.Province.Id.ToString() },
            };

            UpgradeFile upgradeFile = new UpgradeFile();
            if (upgradeFile.ExecuteQuery(sql, parameters))
                return true;
            return false;
        }
        public Client GetClientDetails(Client client)
        {
            DataTable dt;
            Client clients;

            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                { "@Id", client.Id.ToString() }
            };

            using (UpgradeFile upgradeFile = new UpgradeFile())
            {
                dt = upgradeFile.Load("SELECT * FROM clients WHERE clientId=@Id;", parameters);
                if (dt.Rows.Count > 0)
                {
                    clients = new Client()
                    {
                        Id = Convert.ToInt32(dt.Rows[0][1]),
                        FirstName = dt.Rows[0][2].ToString(),
                        LastName = dt.Rows[0][3].ToString(),
                        MiddleName = dt.Rows[0][4].ToString(),
                        Suffix = dt.Rows[0][5].ToString(),
                        DateofBirth = dt.Rows[0][6].ToString(),
                        Sex = dt.Rows[0][7].ToString(),
                        CivilStatus = dt.Rows[0][8].ToString(),
                        CellPhone = dt.Rows[0][9].ToString(),
                        TelePhone = dt.Rows[0][10].ToString(),
                        EmailAddress = dt.Rows[0][11].ToString(),
                        StreetNo = dt.Rows[0][12].ToString(),
                        Region = new Region() { Id = Convert.ToInt32(dt.Rows[0][13]) },
                        City = new City() { Id = Convert.ToInt32(dt.Rows[0][14]) },
                        Brgy = new Barangay() { Id = Convert.ToInt32(dt.Rows[0][115]) },
                        Province = new Province() { Id = Convert.ToInt32(dt.Rows[0][16]) },
                    };
                    return clients;
                }

            }
        }
    }


}
