using System;
using System.Collections.Generic;

namespace OS.Entities
{
    public class AccountUser : IEntityBase
    {
        public int Id { get; set; }  // Account User Id
        public String FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public int ContactNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordSult { get; set; }
        public int BillingAddressId { get; set; }
        public int Active { get; set; }
        public DateTime CreatedByUTC { get; set; }
        public DateTime LastLoginUTC { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }

        public AccountUser()
        {
            Addresses = new List<Address>();
        }
    }
}
