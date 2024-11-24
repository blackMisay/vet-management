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
                {"@Complaint", diagnosis.ComplaintRequest },
                {"@Findings", diagnosis.Findings },
                {"@Plantreatment", diagnosis.PlanTreatment },
                {"@Medication", diagnosis.Medication },
            };
            string query = "";

            if (diagnosis.Id == 0)
            {
                query = "INSERT INTO consultation(patient,weight,temperature,complaint,findings,plantreatment,medication) VALUES(@Patient,@Weight,@Temperature,@Complaint,@Findings,@Plantreatment,@Medication);";
            }
            else
            {
                query = "UPDATE consultation SET patient=@Patient,weight=@Weight,temperature=@Temperature,complaint=@Complaint,findings=@Findings,plantreatment=@Plantreatment,medication=@Medication WHERE id=@Id;";
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

            return upgradeFile.Load("SELECT id,client_fullname,petname,complaint,findings,`date` AS `ConsultDate` FROM vwconsultation");
        }

        public DataTable GetSpecificConsultation(string text)
        {
            UpgradeFile upgradeFile = new UpgradeFile();

            return upgradeFile.Load("SELECT id,client_fullname,petname,complaint,findings,`date` AS `ConsultDate` FROM vwconsultation WHERE client_fullname LIKE @text OR petname LIKE @text;", new Dictionary<string, string> { { "@text", text } });
        }

        public DataTable GetDetails(int id)
        {
            UpgradeFile upgradeFile = new UpgradeFile();
            return upgradeFile.Load("SELECT * FROM vwconsultation WHERE id=@Id", new Dictionary<string, string> { { "@Id", id.ToString() } });
        }
    }
}
