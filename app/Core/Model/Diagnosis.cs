using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.core.model
{
    internal class Diagnosis
    {
        public int Id { get; set; }
        public int Patient { get; set; }
        public string Weight { get; set; }
        public string Temperature { get; set; }
        public Complaint ComplaintRequest { get; set; }
        public Findings Findings { get; set; }
        public Treatment PlanTreatment { get; set; }
        public Medication Medication { get; set; }
        public DateTime ConsultDate { get; set; }
    }
}
