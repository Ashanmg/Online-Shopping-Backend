using OS.Entities;
using OS.Infastructures.Repositories.Abstracts;
using OS.Services.Core;
using OS.Services.Serivices.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace OS.Services.Serivices
{
    public class UserService : IUserService
    {
        #region fields
        private readonly IRoleRepository _roleRepository;
        private readonly IAccountUserRepository _accountUserRepository;
        private readonly IEncryptionService _encryptionService;
        private readonly IAccountUserRoleRepository _accountUserRoleRepository;
        #endregion

        #region constructor
        public UserService(
            IRoleRepository roleRepository,
            IAccountUserRepository accountUserRepository,
            IEncryptionService encryptionService,
            IAccountUserRoleRepository accountUserRoleRepository
            )
        {
            this._roleRepository = roleRepository;
            this._accountUserRepository = accountUserRepository;
            this._encryptionService = encryptionService;
            this._accountUserRoleRepository = accountUserRoleRepository;
        }
        #endregion

        #region Methods
        public MembershipContext ValidateUser(string username, string password)
        {
            var membershipContext = new MembershipContext();
            var user = _accountUserRepository.GetSingleByUsername(username);
            if (user != null && isUserValid(user, password))
            {
                var userRoles = GetUserRoles(user.UserName);
                membershipContext.User = user;

                var identity = new GenericIdentity(user.UserName);
                membershipContext.Principal = new GenericPrincipal(
                    identity,
                    userRoles.Select(x => x.Name).ToArray());
            }
            return membershipContext;
        }

        public List<Role> GetUserRoles(string username)
        {
            List<Role> _result = new List<Role>();

            var existingUser = _accountUserRepository.GetSingleByUsername(username);

            if (existingUser != null)
            {
                foreach (var userRole in existingUser.AccountUserRoles)
                {
                    _result.Add(userRole.Role);
                }
            }
            return _result.Distinct().ToList();
        }
        #endregion

        #region Helper Methods
        private void addUserToRole(AccountUser user, int roleId)
        {
            var role = _roleRepository.GetSingle(roleId);
            if (role == null)
            {
                throw new Exception("Role does not exist.");
            }

            var userRole = new AccountUserRole()
            {
                RoleId = role.Id,
                AccountUserId = user.Id
            };

            _accountUserRoleRepository.Add(userRole);
            _accountUserRoleRepository.Commit();  // change from base
        }

        private bool isUserValid(AccountUser user, string password)
        {
            if (isPasswordValid(user, password))
            {
                if (user.Active == 1)
                    return true;
                else
                    return false;
            }
            return false;
        }

        private bool isPasswordValid(AccountUser user, string password)
        {
            return string.Equals(_encryptionService.EncryptPassword(password, user.PasswordSult), user.Password);
        }
        #endregion
    }
}
