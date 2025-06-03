

using System.Linq;

namespace app.Core.Model
{
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Suffix { get; set; }  
        public string MobileNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string StreetNo { get; set; }
        public Region Region { get; set; }
        public City City { get; set; }
        public Barangay Brgy { get; set; }
        public Province Province { get; set; }

        public string GetFullName()
        {
            return this.FirstName + " " + MiddleName + " " + LastName + " " + Suffix;
        }

        public string GetAllContact()
        {
            if (string.IsNullOrEmpty(this.EmailAddress) || string.IsNullOrWhiteSpace(this.EmailAddress))
                return this.MobileNumber;

            return this.MobileNumber + " / " + this.EmailAddress;
        }
        public string GetFullAddress()
        {
            return this.StreetNo + " " + Region + " " + City + " " + Brgy + " " + Province;
        }

        public string GetClientFullName()
        {
            return string.Join(" ", new[] { FirstName, MiddleName, LastName, Suffix }
        .Where(s => !string.IsNullOrWhiteSpace(s)));
        }
    }
}
