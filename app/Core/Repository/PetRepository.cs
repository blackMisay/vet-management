using app.Core.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;
using Core;
using app.core.model;
namespace app.Core.Repository
{
    internal class PetRepository
    {
        UpgradeFile file = new UpgradeFile();
        public DataTable RetrieveSelectedPatient(string searchValue)
        {
            string query = "SELECT *  FROM `vwpatient` WHERE `petname` LIKE @searchValue;";
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"@searchValue", "%" + searchValue + "%" }
            };
            file = new UpgradeFile();
            return file.Load(query, parameters);
        }

        public bool Save(Pet pet)
        {
            string sql;
            bool saveState = pet.Id > 0;  // Simplified: Directly use pet.Id to determine if update or insert

            // Prepare parameters for SQL query
            Dictionary<string, string> parameters = new Dictionary<string, string>()
    {
        { "@Name", pet.Name },
        { "@BirthDate", pet.BirthDate.ToString() }, // Ensure proper date format
        { "@Age", pet.Age },
        { "@Size", pet.Size },
        { "@Weight", pet.Weight },
        { "@Gender", pet.Gender.Id.ToString() },
        { "@Color", pet.ColourPattern.Id.ToString() },
        { "@Specie", pet.Specie.Id.ToString() },
        { "@Breed", pet.Breed.Id.ToString() },
        { "@Image", pet.Image }
    };

            // If updating, use the existing pet Id
            if (saveState)
            {
                sql = "UPDATE patient SET name=@Name, birthdate=@BirthDate, age=@Age, weight=@Weight, size=@Size, " +
                      "gender_id=@Gender, color_id=@Color, species_id=@Specie, breed_id=@Breed, image=@Image " +
                      "WHERE id=@Id;";
                parameters.Add("@Id", pet.Id.ToString());  // Add Id for the WHERE clause
            }
            else
            {
                // If inserting, include the client ID
                sql = "INSERT INTO patient(client_id, name, birthdate, age, weight, size, gender_id, color_id, species_id, breed_id, image) " +
                      "VALUES(@Client, @Name, @BirthDate, @Age, @Weight, @Size, @Gender, @Color, @Specie, @Breed, @Image);";
                parameters.Add("@Client", pet.Client.Id.ToString());
            }

            // Execute query
            try
            {
                UpgradeFile upgradeFile = new UpgradeFile();
                bool success = upgradeFile.ExecuteQuery(sql, parameters);
                return success;
            }
            catch (Exception ex)
            {
                // Log or display error if query execution fails
                MessageBox.Show($"Error: {ex.Message}", "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }



        public DataTable LoadClientsPatients(int clientId)
        {
            UpgradeFile upgradeFile = new UpgradeFile();

            // If the provided client ID is not zero
            if (clientId > 0)
            {
                // Use the client Id to filter out pets list

                return upgradeFile.Load("SELECT * FROM vwpatient WHERE clientId=" + clientId + " AND isDeleted = 0;");
            }
            else
            {
                // If there's no client Id (zero), load all pets list
                return upgradeFile.Load("SELECT * FROM vwpatient WHERE isDeleted = 0;");

            }

        }
        public Pet GetClientPatientDetails(Pet pet)
        {
            DataTable dt;
            Pet pets;

            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                { "@Id", pet.Id.ToString() }
            };

            UpgradeFile upgradeFile = new UpgradeFile();

            dt = upgradeFile.Load("SELECT * FROM patient WHERE id=@Id;", parameters);
            if (dt.Rows.Count == 0)
                throw new Exception("Empty DataTable");

            return pets = new Pet()
            {
                Id = Convert.ToInt32(dt.Rows[0][0]),
                Client = new Client() { Id = Convert.ToInt32(dt.Rows[0][1]) },
                Name = dt.Rows[0][6].ToString(),
                BirthDate = Convert.ToString(dt.Rows[0][7]),
                ColourPattern = new ColourPattern() { Id = Convert.ToInt32(dt.Rows[0][5]) },
                Specie = new Species() { Id = Convert.ToInt32(dt.Rows[0][2]) },
                Gender = new Gender() { Id = Convert.ToInt32(dt.Rows[0][4]) },
                Breed = new Breed() { Id = Convert.ToInt32(dt.Rows[0][3]) },
                // Image = dt.Rows[0][8].ToString(),
            };
        }

        public bool Delete(int petId)
        {
            string sql = "UPDATE patient SET isDeleted = '1' WHERE id=@Id";

            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                {"@Id", Convert.ToString(petId) }
            };

            UpgradeFile upgradeFile = new UpgradeFile();
            return upgradeFile.ExecuteQuery(sql, parameters);
        }

        public Pet GetPetDetails(Pet pet)
        {
            string query = "SELECT * FROM patient WHERE id=@Id;";
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "@Id", pet.Id.ToString() }
            };

            UpgradeFile upgrade = new UpgradeFile();
            DataTable dt = upgrade.Load(query, parameters);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new Pet()
                {
                    Id = pet.Id,
                    Client = new Client() { Id = Convert.ToInt32(row["client_id"]) },
                    Name = row["name"].ToString(),
                    BirthDate = Convert.ToString(row["birthdate"]),
                    Age = Convert.ToString(row["age"]),
                    Size = row["size"].ToString(),
                    Weight = row["weight"].ToString(),
                    ColourPattern = new ColourPattern() { Id = Convert.ToInt32(row["color_id"]) },
                    Specie = new Species() { Id = Convert.ToInt32(row["species_id"]) },
                    Gender = new Gender() { Id = Convert.ToInt32(row["gender_id"]) },
                    Breed = new Breed() { Id = Convert.ToInt32(row["breed_id"]) },
                    Image = row["image"].ToString(), //enhance/VCMS49
                };
            }
            return null;
        }

        public Pet GetPetCompleteDetails(int Id)
        {
            string query = "SELECT * FROM vwpatient WHERE petId=@Id;";
            Dictionary<string, string> parameters = new Dictionary<string, string>()
    {
        { "@Id", Id.ToString() }
    };

            UpgradeFile upgrade = new UpgradeFile();
            DataTable dt = upgrade.Load(query, parameters);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new Pet()
                {
                    Id = Id,
                    Client = new Client()
                    {
                        Id = int.TryParse(row["clientId"]?.ToString(), out int clientId) ? clientId : 0,
                        FirstName = row.IsNull("firstName") ? "" : row["firstName"].ToString(),
                        MiddleName = row.IsNull("middleName") ? "" : row["middleName"].ToString(),
                        LastName = row.IsNull("lastName") ? "" : row["lastName"].ToString(),
                        Suffix = row.IsNull("suffix") ? "" : row["suffix"].ToString(),

                    },
                    Name = row.IsNull("petname") ? "" : row["petname"].ToString(),
                    BirthDate = row.IsNull("bday") ? "" : Convert.ToDateTime(row["bday"]).ToString("yyyy-MM-dd"),
                    Age = row.IsNull("age") ? "" : row["age"].ToString(),
                    Size = row.IsNull("size") ? "" : row["size"].ToString(),
                    Weight = row.IsNull("weight") ? "" : row["weight"].ToString(),

                    ColourPattern = new ColourPattern()
                    {
                        Description = row.IsNull("colorName") ? "" : row["colorName"].ToString()
                    },
                    Specie = new Species()
                    {
                        Description = row.IsNull("speciesName") ? "" : row["speciesName"].ToString()
                    },
                    Gender = new Gender()
                    {
                        Description = row.IsNull("sexname") ? "" : row["sexname"].ToString()
                    },
                    Breed = new Breed()
                    {
                        Description = row.IsNull("breedDesc") ? "" : row["breedDesc"].ToString()
                    },
                    Image = row.IsNull("image") ? "" : row["image"].ToString()
                };

            }
            return null;
        }

        public void GetAllPetsByOwner(DataGridView dgv, string ownerId)
        {
            UpgradeFile upgrade = new UpgradeFile();
            dgv.DataSource = upgrade.Load("SELECT petId,petname,speciesName,breedDesc FROM vwpatient WHERE clientId=@owner;", new Dictionary<string, string> { { "@owner", ownerId } });
        }

        public Pet GetPatientWithClientById(int id)
        {
            var upgrade = new UpgradeFile();
            string query = "SELECT * FROM vw_pet_with_client WHERE petId = @id";
            var parameters = new Dictionary<string, object> { { "@Id", id } };
            var table = upgrade.LoadDataTable(query, parameters);

            if (table.Rows.Count == 0)
                return null;

            var row = table.Rows[0];

            var client = new Client
            {
                Id = Convert.ToInt32(row["ownerId"]),
                FirstName = row["fname"]?.ToString(),
                MiddleName = row["mi"]?.ToString(),
                LastName = row["lname"]?.ToString(),
                Suffix = row["suffix"]?.ToString(),
                MobileNumber = row["cellnum"]?.ToString(),
                EmailAddress = row["email"]?.ToString(),
                StreetNo = row["Address"]?.ToString()
            };

            var pet = new Pet
            {
                Id = Convert.ToInt32(row["petId"]),
                Name = row["petname"]?.ToString(),
                BirthDate = (row["bday"]).ToString(),
                Age = row["age"]?.ToString(),
                Gender = new Gender { Description = row["sexname"]?.ToString() },
                Specie = new Species { Description = row["speciesName"]?.ToString() },
                Size = row["size"]?.ToString(),
                Weight = row["weight"]?.ToString(),
                Breed = new Breed { Description = row["breedDesc"]?.ToString() },
                ColourPattern = new ColourPattern { Description = row["colorName"]?.ToString() },
                //Image = row["image"] is DBNull ? null : (byte[])row["image"],
                Client = client
            };

            return pet;
        }


    }
}
    
