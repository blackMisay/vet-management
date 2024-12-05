using System;
using System.Collections.Generic;
using System.Data;
using app.core.model;
using Core;


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
                sql = "UPDATE services SET serviceCode = @ServiceCode,serviceType = @ServiceType, description = @Description, Price = @Price WHERE Id = @Id AND status = 'Active' ";
                parameters = new Dictionary<string, string>
                {
                    { "@ServiceType", service.ServiceType.Id.ToString() },
                    { "@ServiceCode", service.ServiceCode },
                    { "@Description", service.Description },
                    { "@Price", service.Price.ToString() },  // Assuming Price is a decimal or float, convert to string
                    { "@Id", service.Id.ToString() }         // Convert Id to string
                };
            }
            else
            {
                // Insert new service
                sql = "INSERT INTO services(id, serviceCode, serviceType, description, price) VALUES(@Id,@ServiceType, @ServiceCode, @Description, @Price)";
                parameters = new Dictionary<string, string>
                {
                    { "@Id", service.Id.ToString() },        // Convert Id to string
                    { "@ServiceCode", service.ServiceCode },
                    { "@ServiceType", service.ServiceType.Id.ToString() },
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
                    Id = service.Id,
                    ServiceCode = row["serviceCode"].ToString(),
                    ServiceType = new Types() { Id = Convert.ToInt32(row["serviceType"]) },
                    Description = row["description"].ToString(),
                    Price = row["price"].ToString(),
                };
            }
            return null;
        }

        public bool IsDuplicateServiceCode(string serviceCode, int serviceId)
        {
            UpgradeFile upgradeFile = new UpgradeFile();
 
            if (string.IsNullOrEmpty(serviceCode))
            {
                throw new ArgumentException("Service code cannot be null or empty.", nameof(serviceCode));
            }

            string query = "SELECT * FROM services WHERE serviceCode = @ServiceCode AND status = 'Active'";

            if (serviceId > 0)
            {
                query += " AND Id != @ServiceId";
            }
            
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                { "@ServiceCode", serviceCode }
            };

            if (serviceId > 0)
            {
                parameters.Add("@ServiceId", serviceId.ToString());
            }
            DataTable result = upgradeFile.Load(query, parameters);
            return result.Rows.Count > 0;
        }

        }

    }

    

    
   


