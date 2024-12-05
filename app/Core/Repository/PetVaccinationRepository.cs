using app.Core.Model;
using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using app.core.model;
using System.Windows.Forms;

namespace app.core.repository
{
    internal class PetVaccinationRepository
    {
        public PetVaccinationRepository() { }

        public void LoadVaccination(DataGridView datagridview)
        {
            UpgradeFile ug = new UpgradeFile();
            datagridview.DataSource = ug.Load("SELECT patient_vaccine_id,`name`,vaccine,lot_number,dosage,administered_date,expiration_date FROM vwpatientvaccination;");
        }

        public void SearchVaccination(DataGridView datagridview, string petName)
        {
            UpgradeFile ug = new UpgradeFile();
            datagridview.DataSource = ug.Load("SELECT patient_vaccine_id,`name`,vaccine,lot_number,dosage,administered_date,expiration_date FROM vwpatientvaccination WHERE `name`=@PetName;", new Dictionary<string, string> { { "@PetName", petName } });
        }

        public bool Save(PetVaccination vaccination)
        {
            string sql;

            bool saveState = vaccination.Id > 0 ? true : false;


            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                {"@Id", Convert.ToString(vaccination.Id) },
                {"@PetId", Convert.ToString(vaccination.PetId) },
                {"@VaccinationId", vaccination.VaccinationId.ToString() },
                {"@LotNumber", vaccination.LotNumber },
                {"@Dosage", vaccination.Dosage},
                {"@AdministeredDate", vaccination.AdministeredDate},
                {"@ExpirationDate", vaccination.ExpirationDate },
                {"@VeterinarianId", vaccination.VeterinarianId.ToString() }
            };

            if (saveState)
            {
                sql = "UPDATE patient_vaccine SET patient_id=@PetId,vaccine_id=@VaccinationId,lot_number=@LotNumber,dosage=@Dosage,administered_date=@AdministeredDate,expiration_date=@ExpirationDate,veterinarian_id=@VeterinarianId WHERE patient_vaccine_id=@Id;";
            }
            else
            {
                sql = "INSERT INTO patient_vaccine(patient_id,vaccine_id,lot_number,dosage,administered_date,expiration_date,veterinarian_id) VALUES(@PetId,@VaccinationId,@LotNumber,@Dosage,@AdministeredDate,@ExpirationDate,@VeterinarianId);";
            }

            UpgradeFile upgradeFile = new UpgradeFile();
            if (upgradeFile.ExecuteQuery(sql, parameters))
                return true;
            return false;
        }

        public bool Delete(int VaccinationId)
        {
            UpgradeFile ug = new UpgradeFile();
            return ug.ExecuteQuery("DELETE FROM patient_vaccine WHERE patient_vaccine_id=@Id;",new Dictionary<string, string> { { "@Id", VaccinationId.ToString() } });
        }

        public void LoadListOfVaccine(ComboBox cmb)
        {
            string sql = "SELECT id,serviceCode FROM services WHERE serviceType=5;";
            UpgradeFile ug = new UpgradeFile();
            cmb.DataSource = ug.Load(sql);
            cmb.ValueMember = "id";
            cmb.DisplayMember = "serviceCode";
        }

        public PetVaccination GetVaccinationDetails(string vaccinationId)
        {
            UpgradeFile ug = new UpgradeFile();
            DataTable dt = new DataTable();
            dt = ug.Load("SELECT * FROM vwpatientvaccination WHERE patient_vaccine_id=@Id;",new Dictionary<string, string> { { "@Id", vaccinationId } });

            if (dt.Rows.Count == 0)
            {
                return null;
            }

            PetVaccination pv = new PetVaccination()
            {
                Id = Convert.ToInt32(dt.Rows[0][0]),
                PetId = Convert.ToInt32(dt.Rows[0][1]),
                PetName = dt.Rows[0][2].ToString(),
                VaccinationName = dt.Rows[0][3].ToString(),
                LotNumber = dt.Rows[0][4].ToString(),
                Dosage = dt.Rows[0][5].ToString(),
                AdministeredDate = dt.Rows[0][6].ToString(),
                ExpirationDate = dt.Rows[0][7].ToString()
            };
            return pv;
        }
    }
}
