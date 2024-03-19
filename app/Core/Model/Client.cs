using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Core.Model
{
    internal class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Suffix { get; set; }  
        public string DateofBirth { get; set; }
        public string Sex { get; set; }
        public string CivilStatus { get; set; }
        public string CellPhone { get; set; }
        public string TelePhone { get; set; }
        public string EmailAddress { get; set; }
        public string StreetNo { get; set; }
        public Region Region { get; set; }
        public City City { get; set; }
        public Barangay Brgy { get; set; }
        public Province Province { get; set; }

        


        
    }
}
