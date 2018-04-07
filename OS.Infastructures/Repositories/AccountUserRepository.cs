using OS.Entities;
using OS.Infastructures.Core;
using OS.Infastructures.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace OS.Infastructures.Repositories
{
    public class AccountUserRepository : EntityBaseRepository<AccountUser> , IAccountUserRepository
    {
        IRoleRepository _roleRepository;
        public AccountUserRepository(OnlineShoppingDbContext context, IRoleRepository roleRepository) : base(context)
        {
            this._roleRepository = roleRepository;
        }

        public AccountUser GetSingleByUsername(string username)
        {
            return this.GetSingle(x => x.UserName == username);
        }

        public IEnumerable<Role> GetUserRoles(string username)
        {
            List<Role> _roles = null;
            AccountUser _user = this.GetSingle(u => u.UserName == username, u => u.AccountUserRoles);
            if (_user != null)
            {
                _roles = new List<Role>();
                foreach (var _userRole in _user.AccountUserRoles)
                    _roles.Add(_roleRepository.GetSingle(_userRole.RoleId));
            }

            return _roles;
        }
    }
}
