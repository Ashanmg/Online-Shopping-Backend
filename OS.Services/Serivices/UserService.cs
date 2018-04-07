using OS.Services.Core;
using OS.Services.Serivices.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace OS.Services.Serivices
{
    public class UserService : IUserService
    {
        public MembershipContext ValidateUser(string username, string password)
        {
            var _membershipContext = new MembershipContext();

            return _membershipContext;
        }
    }
}
