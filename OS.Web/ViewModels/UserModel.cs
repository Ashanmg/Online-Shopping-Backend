using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OS.Web.ViewModels
{
    public class UserCredentialModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }

    public class UserGeneralModel :UserCredentialModel
    {
        public String FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public int ContactNumber { get; set; }
        public int Active { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public int ZipPostalCode { get; set; }
        public int CountryId { get; set; }
    }
}
