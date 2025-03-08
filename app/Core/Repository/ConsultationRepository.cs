using app.core.model;
using Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.core.repository
{
    internal class ConsultationRepository
    {

        public bool Save(Diagnosis diagnosis)
        {
            UpgradeFile ug = new UpgradeFile();
            Dictionary<string, string> fields = new Dictionary<string, string>()
            {
                {"@Id", diagnosis.Id.ToString() },
                {"@Patient", diagnosis.Patient.ToString() },
                {"@Weight", diagnosis.Weight },
                {"@Temperature", diagnosis.Temperature },
                {"@Complaint", diagnosis.ComplaintRequest.Id.ToString() },
                {"@Findings", diagnosis.Findings.Id.ToString() },
                {"@Plantreatment", diagnosis.PlanTreatment.Id.ToString() },
                {"@Medication", diagnosis.Medication.Id.ToString() }
            };
            string query = "";

            if (diagnosis.Id == 0)
            {
                query = "INSERT INTO consultation(patient,weight,temperature,complaint_id,findings_id,plantreatment_id,medication_id) VALUES(@Patient,@Weight,@Temperature,@Complaint,@Findings,@Plantreatment,@Medication);";
            }
            else
            {
                query = "UPDATE consultation SET patient=@Patient,weight=@Weight,temperature=@Temperature,complaint_id=@Complaint,findings_id=@Findings,plantreatment_id=@Plantreatment,medication_id=@Medication WHERE id=@Id;";
            }

            return ug.ExecuteQuery(query, fields); 
        }

        public bool Delete(int id)
        {
            UpgradeFile upgradeFile = new UpgradeFile();
            return upgradeFile.ExecuteQuery("DELETE FROM consultation WHERE id=@Id", new Dictionary<string, string> { { "@Id", id.ToString() } });
        }

        public DataTable GetAllConsultation()
        {
            UpgradeFile upgradeFile = new UpgradeFile();

            return upgradeFile.Load("SELECT id,client_fullname,petname,complaint,findings,consult_date FROM vwconsultation");
        }

        public DataTable GetSpecificConsultation(string text)
        {
            UpgradeFile upgradeFile = new UpgradeFile();

            return upgradeFile.Load("SELECT id,client_fullname,petname,complaint,findings,`consult_date` AS `ConsultDate` FROM vwconsultation WHERE client_fullname LIKE @text OR petname LIKE @text;", new Dictionary<string, string> { { "@text", text } });
        }

        public DataTable GetDetails(int id)
        {
            UpgradeFile upgradeFile = new UpgradeFile();
            return upgradeFile.Load("SELECT * FROM vwconsultation WHERE id=@Id", new Dictionary<string, string> { { "@Id", id.ToString() } });
        }
    }
}
