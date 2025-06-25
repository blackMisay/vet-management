using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.core.model
{
    public class PetVaccination
    {
        public int Id { get; set; }
        public int PetId { get; set; }
        public string PetName { get; set; }

        public int VaccinationId { get; set; }  // maps to consultation_medication.id
        public string VaccinationName { get; set; }

        public string LotNumber { get; set; }

        public DateTime AdministeredDate { get; set; }
        public DateTime ExpirationDate { get; set; }

        public int VeterinarianId { get; set; }
        public string VeterinarianName { get; set; }

        // Optional if you want extra info for display
        public VaccineInfo VaccineDetails { get; set; }
    }

    public class VaccineInfo
    {
        public int Id { get; set; }
        public string VaccineCode { get; set; }
        public string Description { get; set; }
        public string TypicalDose { get; set; }              // NEW: corresponds to `typical_dose` enum
        public string RecommendedDosage { get; set; }        // NEW: renamed to match DB
        public string RecommendedInterval { get; set; }
        public string Notes { get; set; }
    }

}
