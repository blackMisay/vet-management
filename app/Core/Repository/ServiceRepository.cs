using app.Core.Model;
using System;
using System.Collections.Generic;
using System.Data;
using MySqlConnector;
using app.Core.Repository;
using app.core.model;


namespace app.core.Repository
{
    internal class ServiceRepository
    {
        UpgradeFile upgradeFile;

        public DataTable SearchService(string searchValue)
        {
            string query = "SELECT * FROM services WHERE `serviceCode` LIKE @searchValue AND `description` LIKE @searchValue;";
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"@searchValue", "%" + searchValue + "%" }
            };
            UpgradeFile upgradeFile = new UpgradeFile();
            return upgradeFile.Load(query, parameters);
        }
        public bool SaveService(Services services)
        {
            string sql;

            bool saveState = services.Id > 0 ? true : false;

            if (saveState)
            {
                sql = "UPDATE services SET id=@Id WHERE id=@Id;";
            }
            else
            {
                sql = "INSERT INTO services(id,serviceCode,description,price) VALUES(@Id,@ServiceCode,@Description,@Price);";
            }
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                {"@Id", Convert.ToString(services.Id)},
                {"@ServiceCode", services.ServiceCode },
                {"@Description", services.Description },
                {"@Price", services.Price },
            };

            UpgradeFile upgradeFile = new UpgradeFile();
            if (upgradeFile.ExecuteQuery(sql, parameters))
                return true;
            return false;
        }
        public bool DeleteService(Services services)
        {
            UpgradeFile upgradeFile = new UpgradeFile();

            string sql = "UPDATE services SET deleted = '1' WHERE id=@Id;";

            using (MySqlCommand cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@Id", services.Id);
                cmd.ExecuteNonQuery();
                return true;
            }
        }
    }
}