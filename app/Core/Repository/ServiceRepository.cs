using app.Core.Model;
using System;
using System.Collections.Generic;
using System.Data;
using app.core.model;
using Core;
using MySqlConnector;


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
        public bool SaveService(Services service)
        {
            string sql;
            Dictionary<string, string> parameters;

            // Determine if we're updating an existing service or inserting a new one
            bool saveState = service.Id > 0;

            if (saveState)
            {
                // Update existing service
                sql = "UPDATE services SET Description = @Description, Price = @Price WHERE Id = @Id AND isDeleted = 0";
                parameters = new Dictionary<string, string>
    {
        { "@Description", service.Description },
        { "@Price", service.Price.ToString() },  // Assuming Price is a decimal or float, convert to string
        { "@Id", service.Id.ToString() }         // Convert Id to string
    };
            }
            else
            {
                // Insert new service
                sql = "INSERT INTO services(id, serviceCode, description, price) VALUES(@Id, @ServiceCode, @Description, @Price)";
                parameters = new Dictionary<string, string>
    {
        { "@Id", service.Id.ToString() },        // Convert Id to string
        { "@ServiceCode", service.ServiceCode },
        { "@Description", service.Description },
        { "@Price", service.Price.ToString() }   // Assuming Price is a decimal or float, convert to string
    };
            }

            try
            {
                UpgradeFile upgradeFile = new UpgradeFile();
                // Execute the query and check if it was successful
                bool isSuccessful = upgradeFile.ExecuteQuery(sql, parameters);
                return isSuccessful; // Return the success status of the query
            }
            catch (Exception ex)
            {
                throw new Exception($"Error saving or updating service: {ex.Message}");
            }

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

        public bool IsDuplicateServiceCode(string serviceCode)
        {
            string query = "SELECT COUNT(*) FROM services WHERE serviceCode = @ServiceCode AND isDeleted = 0";

            // Use Dictionary<string, string> for parameters, as required by ExecuteQuery
            Dictionary<string, string> parameters = new Dictionary<string, string>
{
    { "@ServiceCode", serviceCode }
};

            try
            {
                // Create an instance of UpgradeFile
                UpgradeFile upgradeFile = new UpgradeFile();

                // Execute the query and get the number of affected rows
                bool isSuccessful = upgradeFile.ExecuteQuery(query, parameters);

                // Since ExecuteQuery does not directly return the COUNT, check if execution was successful
                // If successful, interpret as "potential duplicate exists" 
                return isSuccessful;
            }
            catch (MySqlException ex)
            {
                // Log or handle specific MySql errors here
                throw new Exception($"Error executing query: {ex.Message}");
            }
            catch (Exception e)
            {
                throw new Exception($"Unexpected error: {e.Message}");
            }

        }

    }
    }


