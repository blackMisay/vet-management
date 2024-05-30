using app.Core.Model;
using System;
using System.Collections.Generic;
using System.Data;
using MySqlConnector;
using app.Core.Repository;
using app.core.model;
using System.Runtime.InteropServices.WindowsRuntime;


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
        public bool DeleteService(int service)
        {
            UpgradeFile upgradeFile = new UpgradeFile();

            string sql = "UPDATE services SET deleted = '1' WHERE id=@Id;";

            UpgradeFile upgrade = new UpgradeFile();
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "@Id", service.ToString() }
            };
            return upgradeFile.ExecuteQuery(sql, parameters);
        }

        public Services GetService(Services service)
        {
            string query = "SELECT * FROM services WHERE id = @Id;";
            Dictionary<string, string> parameters = new Dictionary<string, string>()
                {
                 { "@Id", service.Id.ToString() }
                };
            UpgradeFile upgradeFile = new UpgradeFile();
            DataTable dt = upgradeFile.Load(query, parameters);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new Services
                {
                    Id = Convert.ToInt32(dt.Rows[0][0]),
                    ServiceCode = dt.Rows[0][1].ToString(),
                    Description = dt.Rows[0][2].ToString(),
                    Price = dt.Rows[0][3].ToString(),
                };
            }
            return null;
        }

    }
}

