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
        public string ComplaintRequest { get; set; }
        public string Findings { get; set; }
        public string PlanTreatment { get; set; }
        public string Medication { get; set; }
    }
}
