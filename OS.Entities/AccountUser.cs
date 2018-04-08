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
        public string Username { get; set; }
        public string HashedPassword { get; set; }
        public string PasswordSalt { get; set; }
        public int AddressId { get; set; }
        public int Active { get; set; }
        public DateTime CreatedByUTC { get; set; }
        public DateTime LastLoginUTC { get; set; }
        public virtual Address Address { get; set; }
        public virtual ICollection<AccountUserRole> AccountUserRoles { get; set; }

        public AccountUser()
        {
            AccountUserRoles = new List<AccountUserRole>();
        }
    }
}
