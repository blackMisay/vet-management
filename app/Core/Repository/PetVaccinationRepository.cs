using app.core.model;
using Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace app.core.repository
{
    internal class PetVaccinationRepository
    {
        private readonly UpgradeFile _db;

        public PetVaccinationRepository()
        {
            _db = new UpgradeFile();
        }

        public void LoadVaccinations(DataGridView grid)
        {
            string query = @"SELECT record_id,patient_name,vaccine_name,administered_date,expiration_date,veterinarian_name FROM vw_patient_vaccine_record";
            grid.DataSource = _db.Load(query);
        }

        public void SearchVaccination(DataGridView dgv, string keyword)
        {
            string query = @"
        SELECT * FROM vw_patient_vaccination 
        WHERE pet_name LIKE @Keyword 
           OR vaccine_name LIKE @Keyword 
           OR lot_number LIKE @Keyword 
           OR veterinarian_name LIKE @Keyword";

            var parameters = new Dictionary<string, string>
    {
        { "@Keyword", $"%{keyword}%" }
    };

            var result = _db.Load(query, parameters);
            dgv.DataSource = result;
        }


        public bool Save(PetVaccination vaccination)
        {
            bool isUpdate = vaccination.Id > 0;

            string query;
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            if (isUpdate)
            {
                query = @"
            UPDATE patient_pet_vaccine
            SET patient_id = @PetId,
                vaccine_id = @VaccineId,
                lot_number = @LotNumber,
                administered_date = @AdministeredDate,
                expiration_date = @ExpirationDate,
                veterinarian_id = @VeterinarianId
            WHERE patient_vaccine_id = @Id";

                parameters.Add("@Id", vaccination.Id.ToString());
            }
            else
            {
                query = @"
            INSERT INTO patient_pet_vaccine
            (patient_id, vaccine_id, lot_number, administered_date, expiration_date, veterinarian_id)
            VALUES
            (@PetId, @VaccineId, @LotNumber, @AdministeredDate, @ExpirationDate, @VeterinarianId)";
            }

            parameters.Add("@PetId", vaccination.PetId.ToString());
            parameters.Add("@VaccineId", vaccination.VaccinationId.ToString());
            parameters.Add("@LotNumber", vaccination.LotNumber ?? "");
            parameters.Add("@AdministeredDate", vaccination.AdministeredDate.ToString("yyyy-MM-dd"));
            parameters.Add("@ExpirationDate", vaccination.ExpirationDate.ToString("yyyy-MM-dd"));
            parameters.Add("@VeterinarianId", vaccination.VeterinarianId.ToString());

            return _db.ExecuteQuery(query, parameters);
        }

        public bool Delete(int vaccinationId)
        {
            string query = "DELETE FROM patient_pet_vaccine WHERE patient_vaccine_id = @Id";
            var parameters = new Dictionary<string, string> { { "@Id", vaccinationId.ToString() } };
            return _db.ExecuteQuery(query, parameters);
        }

        public PetVaccination GetById(string id)
        {
            string query = "SELECT record_id,patient_name,vaccine_name,administered_date,expiration_date,veterinarian_name FROM vw_patient_vaccine_record WHERE record_id = @Id";
            var parameters = new Dictionary<string, string> { { "@Id", id } };
            var dt = _db.Load(query, parameters);

            if (dt.Rows.Count == 0) return null;

            var row = dt.Rows[0];
            return new PetVaccination
            {
                Id = Convert.ToInt32(row["record_id"]),
                PetName = row["patient_name"].ToString(),
                VaccinationName = row["vaccine_name"].ToString(),
                AdministeredDate = DateTime.Parse(row["administered_date"].ToString()),
                ExpirationDate = DateTime.Parse(row["expiration_date"].ToString()),
                VeterinarianName = row["veterinarian_name"].ToString()
            };
        }

        public DataTable GetUpcomingExpirations()
        {
            string query = @"SELECT pet_name, vaccine_name, administered_date, expiration_date, veterinarian_name
                             FROM vw_patient_vaccination
                             WHERE expiration_date BETWEEN CURDATE() AND DATE_ADD(CURDATE(), INTERVAL 7 DAY)
                             ORDER BY expiration_date";

            return _db.Load(query);
        }
        public List<KeyValuePair<int, string>> LoadistofVaccine()
        {
            var vaccines = new List<KeyValuePair<int, string>>();
            string query = "SELECT id, description FROM consultation_medication"; // <- Fix this if needed
            var dt = _db.Load(query);

            if (dt == null || dt.Rows.Count == 0)
                return vaccines;

            foreach (DataRow row in dt.Rows)
            {
                int id = Convert.ToInt32(row["id"]);
                string description = row["description"].ToString();
                vaccines.Add(new KeyValuePair<int, string>(id, description));
            }

            return vaccines;
        }

        public void LoadListOfVaccine(ComboBox comboBox)
        {
            string query = "SELECT id AS Key, description AS Value FROM consultation_medication WHERE type = 'Vaccine'";
            var dt = _db.Load(query);

            comboBox.DataSource = dt;
            comboBox.DisplayMember = "Value";
            comboBox.ValueMember = "Key";
            comboBox.SelectedIndex = -1;
        }

        public DataTable GetUpcomingVaccinations(int daysAhead = 7)
        {
            string query = $@"
        SELECT * FROM vw_patient_vaccination
        WHERE expiration_date BETWEEN CURDATE() AND DATE_ADD(CURDATE(), INTERVAL {daysAhead} DAY)";

            return _db.Load(query, null);
        }



    }
}
