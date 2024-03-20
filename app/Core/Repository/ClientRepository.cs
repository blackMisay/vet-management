using app.Core.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace app.Core.Repository
{
    internal class ClientRepository
    {

        UpgradeFile upgradeFile;
        public DataTable RetrieveSelectedClient(string searchValue)
        {
            string query = "SELECT `clients`.`clientID` AS `Id`, CONCAT(`clients`.`fname`,' ',`clients`.`mi`,' ',`clients`.`lname`) AS `Name` FROM clients WHERE `fname` LIKE @searchValue OR `mi` LIKE @searchValue OR `lname` LIKE @searchValue;";
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"@searchValue", "%" + searchValue + "%" }
            };
            upgradeFile = new UpgradeFile();
            return upgradeFile.Load(query, parameters);
        }
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
                {"@DateofBirth", client.BirthDate },
                {"@Sex", client.Gender },
                {"@CivilStatus", client.CivilStatus },
                {"@CellPhone", client.MobileNumber },
                {"@TelePhone", client.PhoneNumber },
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

            UpgradeFile upgradeFile = new UpgradeFile();

            dt = upgradeFile.Load("SELECT * FROM clients WHERE clientId=@Id;", parameters);
            if (dt.Rows.Count == 0)
                throw new Exception("Empty DataTable");

            return clients = new Client()
            {
                Id = Convert.ToInt32(dt.Rows[0][1]),
                FirstName = dt.Rows[0][2].ToString(),
                LastName = dt.Rows[0][3].ToString(),
                MiddleName = dt.Rows[0][4].ToString(),
                Suffix = dt.Rows[0][5].ToString(),
                BirthDate = dt.Rows[0][6].ToString(),
                Gender = dt.Rows[0][7].ToString(),
                CivilStatus = dt.Rows[0][8].ToString(),
                MobileNumber = dt.Rows[0][9].ToString(),
                PhoneNumber = dt.Rows[0][10].ToString(),
                EmailAddress = dt.Rows[0][11].ToString(),
                StreetNo = dt.Rows[0][12].ToString(),
                Region = new Region() { Id = Convert.ToInt32(dt.Rows[0][13]) },
                City = new City() { Id = Convert.ToInt32(dt.Rows[0][14]) },
                Brgy = new Barangay() { Id = Convert.ToInt32(dt.Rows[0][115]) },
                Province = new Province() { Id = Convert.ToInt32(dt.Rows[0][16]) },
            };
        }

        public Client GetClientInformation(Client client)
        {
            DataTable dt;
            Client clients;

            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                { "@Id", client.Id.ToString() }
            };

            UpgradeFile upgradeFile = new UpgradeFile();

            dt = upgradeFile.Load("SELECT * FROM vwclient WHERE clientId=@Id;", parameters);
            if (dt.Rows.Count == 0)
                throw new Exception("Empty DataTable");

            return clients = new Client()
            {
                Id = Convert.ToInt32(dt.Rows[0][0]),
                FirstName = dt.Rows[0][1].ToString(),
                LastName = dt.Rows[0][2].ToString(),
                MiddleName = dt.Rows[0][3].ToString(),
                Suffix = dt.Rows[0][4].ToString(),
                MobileNumber = dt.Rows[0][5].ToString(),
                //PhoneNumber = dt.Rows[0][2].ToString(),
                EmailAddress = dt.Rows[0][6].ToString(),
                StreetNo = dt.Rows[0][7].ToString(),
            };
        }
    }
}
