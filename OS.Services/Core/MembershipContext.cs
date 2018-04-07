using OS.Entities;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace OS.Services.Core
{
    public class MembershipContext
    {
        public IPrincipal Principal { get; set; }
        public AccountUser User { get; set; }
        public bool IsValid()
        {
            return Principal != null;
        }
    }
}
