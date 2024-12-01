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
        public int VaccinationId { get; set; }
        public string VaccinationName { get; set; }
        public string LotNumber { get; set; }
        public string Dosage { get; set; }
        public string AdministeredDate { get; set; }
        public string ExpirationDate { get; set; }
        public int VeterinarianId { get; set; }

    }

}
