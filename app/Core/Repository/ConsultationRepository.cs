using app.core.model;
using app.Core.Model;
using Core;
using System;
using System.Collections.Generic;
using System.Data;

namespace app.core.repository
{
    internal class ConsultationRepository
    {
        private readonly UpgradeFile uf = new UpgradeFile();

        public List<KeyValuePair<int, string>> LoadMedicines()
        {
            const string query = "SELECT id, description FROM consultation_medication ORDER BY description";
            return uf.Populate(query);
        }

        private bool SaveMedicationDetails(Diagnosis diagnosis)
        {
            const string insertMedQuery = @"
INSERT INTO patient_consultation_medicines
(consultation_id, medicine_id, frequency, days_intake, notes)
VALUES (@ConsultationId, @MedicineId, @Frequency, @DaysIntake, @Notes)";


            foreach (var med in diagnosis.MedicationsWithFrequency)
            {
                if (med.MedicineId <= 0)
                    continue;

                var parameters = new Dictionary<string, object>
                {
                    ["@ConsultationId"] = diagnosis.Id,
                    ["@MedicineId"] = med.MedicineId,
                    ["@Frequency"] = med.Frequency ?? "",
                    ["@DaysIntake"] = med.DaysIntake ?? "",
                    ["@Notes"] = med.Notes ?? ""
                };

                if (!uf.ExecuteNonQuery(insertMedQuery, parameters))
                    return false;
            }

            return true;


        }

        public List<MedicationWithFrequency> LoadMedicationDetails(int consultationId)
        {
            const string query = @"
                SELECT cmd.id AS MedicineId, cmd.description AS MedicineDescription, cmd_detail.frequency
                FROM consultation_medication_detail cmd_detail
                JOIN consultation_medication cmd ON cmd.id = cmd_detail.medication_id
                WHERE cmd_detail.consultation_id = @ConsultationId";

            var parameters = new Dictionary<string, object> { ["@ConsultationId"] = consultationId };
            var results = uf.Query(query, parameters);

            var meds = new List<MedicationWithFrequency>();

            foreach (var row in results)
            {
                meds.Add(new MedicationWithFrequency
                {
                    MedicineId = Convert.ToInt32(row["MedicineId"]),
                    MedicineDescription = row["MedicineDescription"].ToString(),
                    Frequency = row["frequency"].ToString()
                });
            }

            return meds;
        }

        public bool Save(Diagnosis diagnosis)
        {
            var parameters = BuildDiagnosisParameters(diagnosis);

            if (diagnosis.Id == 0)
            {
                return InsertDiagnosis(diagnosis, parameters);
            }
            else
            {
                return UpdateDiagnosis(diagnosis, parameters);
            }
        }

        private Dictionary<string, object> BuildDiagnosisParameters(Diagnosis diagnosis)
        {
            var parameters = new Dictionary<string, object>
            {
                ["@Patient"] = diagnosis.Patient,
                ["@Weight"] = diagnosis.Weight ?? string.Empty,
                ["@BloodPressure"] = diagnosis.BloodPressure ?? string.Empty,
                ["@HeartRate"] = diagnosis.HeartRate ?? string.Empty,
                ["@Temperature"] = diagnosis.Temperature ?? string.Empty,
                ["@Complaint"] = diagnosis.Complaint ?? string.Empty,
                ["@Findings"] = diagnosis.Findings ?? string.Empty,
                ["@Plantreatment"] = diagnosis.PlanTreatment ?? string.Empty,
                ["@ConsultDate"] = diagnosis.ConsultDate.ToString("yyyy-MM-dd HH:mm:ss")
                
            };

            if (diagnosis.FollowUpDate.HasValue)
            {
                parameters["@FollowUpDate"] = diagnosis.FollowUpDate.Value.ToString("yyyy-MM-dd");
            }
            else
            {
                parameters["@FollowUpDate"] = DBNull.Value;
            }

            return parameters;

        }

        private bool InsertDiagnosis(Diagnosis diagnosis, Dictionary<string, object> parameters)
        {
            const string insertQuery = @"
        INSERT INTO patient_consultation 
        (patient, weight,blood_pressure,heart_rate, temperature, complaint, findings, plantreatment, consult_date,follow_up_date)
        VALUES
        (@Patient, @Weight,@BloodPressure,@HeartRate, @Temperature, @Complaint, @Findings, @Plantreatment, @ConsultDate,@FollowUpDate);
        SELECT LAST_INSERT_ID();";

            int insertedId = uf.ExecuteInsertWithId(insertQuery, parameters);
            if (insertedId <= 0) return false;

            diagnosis.Id = insertedId;
            return SaveMedicationDetails(diagnosis);
        }

        private bool UpdateDiagnosis(Diagnosis diagnosis, Dictionary<string, object> parameters)
        {
            const string updateQuery = @"
        UPDATE patient_consultation SET
        patient = @Patient,
        weight = @Weight,
        blood_pressure = @BloodPressure,
        heart_rate = @HeartRate,
        temperature = @Temperature,
        complaint = @Complaint,
        findings = @Findings,
        plantreatment = @Plantreatment,
        consult_date = @ConsultDate
        WHERE id = @Id";

            parameters["@Id"] = diagnosis.Id;

            if (!uf.ExecuteNonQuery(updateQuery, parameters))
                return false;

            DeleteExistingMedications(diagnosis.Id);
            return SaveMedicationDetails(diagnosis);
        }

        private void DeleteExistingMedications(int consultationId)
        {
            const string deleteQuery = "DELETE FROM consultation_medication_detail WHERE consultation_id = @ConsultationId";
            var deleteParams = new Dictionary<string, object> { ["@ConsultationId"] = consultationId };
            uf.ExecuteNonQuery(deleteQuery, deleteParams);
        }


        public bool Delete(int id)
        {
            const string query = "DELETE FROM patient_consultation WHERE id = @Id";
            var parameters = new Dictionary<string, object> { ["@Id"] = id };
            return uf.ExecuteNonQuery(query, parameters);
        }

        public DataTable GetAllConsultations()
        {
            const string query = @"
        SELECT consultation_id, client_fullname, petname, complaint, findings, consult_date
        FROM vwpatientconsultation
        WHERE DATE(consult_date) = CURDATE()
        ORDER BY consult_date DESC";

            return uf.Load(query);
        }

        public DataTable GetSpecificConsultations(string searchText)
        {
            const string query = @"
                SELECT consultation_id, client_fullname, petname, complaint, findings, consult_date AS ConsultDate
                FROM vwpatientconsultation 
                WHERE client_fullname LIKE @text OR petname LIKE @text";

            var parameters = new Dictionary<string, string> { ["@text"] = $"%{searchText}%" };
            return uf.Load(query, parameters);
        }

        public DataTable GetDetails(int id)
        {
            const string query = "SELECT * FROM vwpatientconsultation WHERE id = @Id";
            var parameters = new Dictionary<string, string> { ["@Id"] = id.ToString() };
            return uf.Load(query, parameters);
        }

        public DataTable GetUniqueOwnersWithConsultations()
        {
            const string query = "SELECT * FROM vw_unique_consulting_owners";
            return uf.Load(query);
        }

        public DataTable GetPetsByOwner(int ownerId, int petId)
        {
            const string query = @"
             SELECT 
            pet_id, 
            pet_name, 
            breed, 
            species 
            FROM vw_pets_by_owner 
            WHERE client_id = @OwnerId";

            var parameters = new Dictionary<string, string>
            {
                ["@OwnerId"] = ownerId.ToString(),
                ["@PetId"] = petId.ToString(),
            };

            return uf.Load(query, parameters);
        }

        public DataTable GetConsultationHistoryByOwnerAndPet(int ownerId, int petId)
        {
            const string query = @"
        SELECT *
        FROM vw_pet_consultation_history
        WHERE owner_id = @OwnerId AND pet_id = @PetId
        ORDER BY consult_date DESC";

            var parameters = new Dictionary<string, string>
            {
                ["@OwnerId"] = ownerId.ToString(),
                ["@PetId"] = petId.ToString()
            };

            return uf.Load(query, parameters);
        }

        public DataTable GetUpcomingFollowUps()
        {
            const string query = @"
        SELECT
            pet_name AS 'Pet Name',
            owner_name AS 'Owner Name',
            owner_contact_number AS 'Contact Number',
            owner_email AS 'Email Address',
            follow_up_date AS 'Follow-Up Date'
        FROM vw_pet_followup_with_contact
        WHERE follow_up_date IS NOT NULL
          AND follow_up_date >= CURDATE()
        ORDER BY follow_up_date ASC;
    ";

            return uf.Load(query, new Dictionary<string, string>());
        }
        public string ComputeUpcomingFollowUpsCount()
        {
            const string query = @"
        SELECT COUNT(*) AS TotalFollowUps
        FROM vw_pet_followup_with_contact
        WHERE follow_up_date IS NOT NULL
          AND follow_up_date >= CURDATE();
    ";

            var dt = uf.Load(query, new Dictionary<string, string>());

            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0]["TotalFollowUps"].ToString();
            }

            return "0";
        }

        public DataTable GetAllConsultationWithMedications()
        {
            const string query = @"SELECT * FROM vw_pet_consultation_details WHERE consult_date = CURDATE() ORDER BY consult_date DESC;";

            return uf.Load(query, new Dictionary<string, string>()); // using your UpgradeFile helper
        }






    }
}
