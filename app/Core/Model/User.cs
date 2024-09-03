using System;

namespace app.core.model
{
    public class User
    {
        public int Id { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public String Key { get; set; }

        public string Email { get; set; }

        public string MobilePhone { get; set; }

        public string UserType { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

    }
}
