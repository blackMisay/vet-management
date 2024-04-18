using app.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using System.Xml.Linq;
namespace app.Core.Repository
{
    internal class PetRepository
    {

        public bool Save(Pet pet)
        {
            string sql;

            bool saveState =  pet.Id > 0 ? true : false;
            
            
            Dictionary<string, string> parameters = new Dictionary<string, string>() 
            {
                {"@Id", Convert.ToString(pet.Id) },
                {"@Name", pet.Name },
                {"@BirthDate", pet.BirthDate },
                {"@Gender", pet.Gender.Id.ToString() },
                {"@Color", pet.Color.Id.ToString() },
                {"@Specie", pet.Specie.Id.ToString() },
                {"@Breed", pet.Breed.Id.ToString() },
                {"@Image", pet.Image}
            };

            if (saveState)
            {
                sql = "UPDATE animals SET petname=@Name,bday=@BirthDate,sexid=@Gender,colorid=@Color,speciesid=@Specie,breedid=@Breed,image=@Image WHERE petid=@Id;";
            }
            else
            {
                sql = "INSERT INTO animals(clientid,petname,bday,sexid,colorid,speciesid,breedid,image) VALUES(@Client,@Name,@BirthDate,@Gender,@Color,@Specie,@Breed,@Image);";
                parameters.Add("@Client", pet.Client.Id.ToString());
            }

            UpgradeFile upgradeFile = new UpgradeFile();
            if (upgradeFile.ExecuteQuery(sql, parameters))
                return true;
            return false;
        }

        public DataTable LoadClientsPatients(int clientId)
        {
            UpgradeFile upgradeFile = new UpgradeFile();

            // If the provided client ID is not zero
            if (clientId > 0)
            {
                // Use the client Id to filter out pets list

                return upgradeFile.Load("SELECT * FROM vwpet WHERE clientId=" + clientId + ";");
            }
            else
            {
                // If there's no client Id (zero), load all pets list
                return upgradeFile.Load("SELECT * FROM vwpet;");

            }

        }

        public bool Delete(int petId)
        {
            string sql = "DELETE from animals WHERE petId=@Id";

            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                {"@Id", Convert.ToString(petId) }
            };

            UpgradeFile upgradeFile = new UpgradeFile();
            return upgradeFile.ExecuteQuery(sql, parameters);
        }

    }
}