using app.Core.Model;
using MySqlConnector;
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
            string query = "SELECT `client`.`id` AS `Id`, CONCAT(`client`.`firstname`,' ',`client`.`middlename`,' ',`client`.`lastname`) AS `Name` FROM client WHERE `firstname` LIKE @searchValue OR `middlename` LIKE @searchValue OR `lastname` LIKE @searchValue;";
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
                sql = "UPDATE client SET id=@ClientID,firstname=@FirstName,lastname=@LastName,middlename=@MiddleName,suffix=@Suffix,birthdate=@DateofBirth,gender=@Sex,civilstatus=@CivilStatus,phonenumber=@TelePhone,mobilenumber=@CellPhone,emailaddress=@EmailAddress,streetnumber=@StreetNo,region_id=@Region,city_id=@City,brgy_id=@Brgy,province_id=@Province WHERE id=@ClientID;";
            }
            else
            {
                sql = "INSERT INTO client(id,firstname,lastname,middlename,suffix,birthdate,gender,civilstatus,phonenumber,mobilenumber,emailaddress,streetnumber,region_id,city_id,brgy_id,province_id) VALUES(@ClientID,@FirstName,@LastName,@MiddleName,@Suffix,@DateofBirth,@Sex,@CivilStatus,@TelePhone,@CellPhone,@EmailAddress,@StreetNo,@Region,@City,@Brgy,@Province);";
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

            dt = upgradeFile.Load("SELECT * FROM client WHERE id=@Id;", parameters);
            if (dt.Rows.Count == 0)
                    throw new Exception("Empty DataTable");

            return clients = new Client()
            {
                Id = Convert.ToInt32(dt.Rows[0][1]),
                FirstName = dt.Rows[0][2].ToString(),
                MiddleName = dt.Rows[0][3].ToString(),
                LastName = dt.Rows[0][4].ToString(),
                Suffix = dt.Rows[0][5].ToString(),
                BirthDate = dt.Rows[0][6].ToString(),
                Gender = dt.Rows[0][7].ToString(),
                CivilStatus = dt.Rows[0][8].ToString(),
                PhoneNumber = dt.Rows[0][9].ToString(),
                MobileNumber = dt.Rows[0][10].ToString(),
                EmailAddress = dt.Rows[0][11].ToString(),
                StreetNo = dt.Rows[0][12].ToString(),
                Brgy = new Barangay() { Id = Convert.ToInt32(dt.Rows[0][13]) },
                City = new City() { Id = Convert.ToInt32(dt.Rows[0][14]) },
                Province = new Province() { Id = Convert.ToInt32(dt.Rows[0][15]) },
                Region = new Region() { Id = Convert.ToInt32(dt.Rows[0][16]) },                                            
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
                MiddleName = dt.Rows[0][2].ToString(),
                LastName = dt.Rows[0][3].ToString(),
                Suffix = dt.Rows[0][4].ToString(),
                MobileNumber = dt.Rows[0][5].ToString(),
                //PhoneNumber = dt.Rows[0][2].ToString(),
                EmailAddress = dt.Rows[0][6].ToString(),
                StreetNo = dt.Rows[0][7].ToString(),
            };
        }
        public bool Delete(Client client)
        {
            UpgradeFile upgradeFile = new UpgradeFile();

            string sql = "UPDATE client SET deleted = '1' WHERE clientId=@Id;";

            using (MySqlCommand cmd =  new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@Id", client.Id);
                cmd.ExecuteNonQuery();
                return true;
            }
        }
        public Client GetClientInfoDetails(Client client)
        {
            // Define the query to retrieve client information based on the client ID
            string query = "SELECT * FROM client WHERE id=@Id;";

            // Create a dictionary to hold the parameters for the query
            Dictionary<string, string> parameters = new Dictionary<string, string>()
                {
                     { "@Id", client.Id.ToString() }
                };

            // Initialize the UpgradeFile object to interact with the database
            UpgradeFile upgrade = new UpgradeFile();

            // Load the data from the database into a DataTable
            DataTable dt = upgrade.Load(query, parameters);

            // Check if any rows were returned
            if (dt.Rows.Count > 0)
            {
                // Retrieve the first row of the DataTable
                DataRow row = dt.Rows[0];

                // Create and return a new Client object populated with data from the DataTable
                return new Client()
                {
                    Id = client.Id,
                    FirstName = row["firstname"].ToString(),
                    MiddleName = row["middlename"].ToString(),
                    LastName = row["lastname"].ToString(),
                    Suffix = row["suffix"].ToString(),
                    BirthDate = row["birthdate"].ToString(),
                    Gender = row["gender"].ToString(),
                    CivilStatus = row["civilstatus"].ToString(),
                    PhoneNumber = row["phonenumber"].ToString(),
                    MobileNumber = row["mobilenumber"].ToString(),
                    EmailAddress = row["emailaddress"].ToString(),
                    StreetNo = row["streetnumber"].ToString(),
                    Brgy = new Barangay() { Id = Convert.ToInt32(row["brgy_id"]) },
                    City = new City() { Id = Convert.ToInt32(row["city_id"]) },
                    Province = new Province() { Id = Convert.ToInt32(row["province_id"]) },
                    Region = new Region() { Id = Convert.ToInt32(row["region_id"]) },
                };
            }

            // If no rows were returned, return null
            return null;
        }

    }
}
