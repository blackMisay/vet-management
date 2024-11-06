using app.Core.Model;
using System;
using System.Collections.Generic;
using System.Data;
using app.core.model;
using Core;
using MySqlConnector;
using System.Windows.Forms;


namespace app.core.Repository
{
    internal class ServiceRepository
    {
        UpgradeFile upgradeFile;

        public DataTable SearchService(string searchValue)
        {
            string query = "SELECT * FROM services WHERE `serviceCode` LIKE @searchValue OR `description` LIKE @searchValue;";
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
                sql = "UPDATE services SET Description = @Description, Price = @Price WHERE Id = @Id AND status = 'Active' ";
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
            // Updated SQL query to set the Status as 'Inactive'
            string sql = "UPDATE services SET status = 'Inactive' WHERE id = @Id;";

            // Create an instance of UpgradeFile
            UpgradeFile upgradeFile = new UpgradeFile();

            // Define parameters with the service ID
            Dictionary<string, string> parameters = new Dictionary<string, string>
{
    { "@Id", service.ToString() }
};


            // Execute the query to mark the service as 'Inactive'
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

        public bool IsDuplicateServiceCode(string serviceCode, int serviceId)
        {
            // Ensure upgradeFile is instantiated
            UpgradeFile upgradeFile = new UpgradeFile();

            // Check for null or empty service code
            if (string.IsNullOrEmpty(serviceCode))
            {
                throw new ArgumentException("Service code cannot be null or empty.", nameof(serviceCode));
            }

            // Construct the query to check for duplicate service code
            string query = "SELECT * FROM services WHERE serviceCode = @ServiceCode AND status = 'Active'";

            // If serviceId is greater than 0 (indicating an update), add a condition to exclude it
            if (serviceId > 0)
            {
                query += " AND Id != @ServiceId";
            }

            // Create a dictionary for the parameters
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                { "@ServiceCode", serviceCode }
            };

            // Add serviceId parameter only if it is provided for update
            if (serviceId > 0)
            {
                parameters.Add("@ServiceId", serviceId.ToString());
            }

            // Execute the query and load the result into a DataTable
            DataTable result = upgradeFile.Load(query, parameters);

            // Check if the DataTable has rows to determine if a duplicate exists
            return result.Rows.Count > 0;

        }
    }
}


    

    
   


