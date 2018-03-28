using System;
using System.Collections.Generic;
using System.Text;

namespace OS.Entities
{
    public class AccountUserRole : IEntityBase
    {
        public int Id { get; set; }
        public int AccountUserId { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
