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
        private readonly IAddressRepository _addressRepository;
        #endregion

        #region constructor
        public UserService(
            IRoleRepository roleRepository,
            IAccountUserRepository accountUserRepository,
            IEncryptionService encryptionService,
            IAccountUserRoleRepository accountUserRoleRepository,
            IAddressRepository addressRepository
            )
        {
            this._roleRepository = roleRepository;
            this._accountUserRepository = accountUserRepository;
            this._encryptionService = encryptionService;
            this._accountUserRoleRepository = accountUserRoleRepository;
            this._addressRepository = addressRepository;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Validate user when account user login
        /// </summary>
        /// <param name="username">The login username</param>
        /// <param name="password">The login password</param>
        /// <returns>Return membershipcontext</returns>
        public MembershipContext ValidateUser(string username, string password)
        {
            var membershipContext = new MembershipContext();
            var user = _accountUserRepository.GetSingleByUsername(username);
            if (user != null && isUserValid(user, password))
            {
                var userRoles = GetUserRoles(user.Username);
                membershipContext.User = user;

                var identity = new GenericIdentity(user.Username);
                membershipContext.Principal = new GenericPrincipal(
                    identity,
                    userRoles.Select(x => x.Name).ToArray());
            }
            return membershipContext;
        }


        public AccountUser CreateUser(AccountUser accountUser)
        {
            var existingUser = _accountUserRepository.GetSingleByUsername(accountUser.Username);

            if (existingUser != null)
            {
                throw new Exception("Username is already in use");
            }

            var passwordSalt = _encryptionService.CreateSalt(8); // salt byte size set to length 8
            accountUser.PasswordSalt = passwordSalt;

            /*mapping normal user entered password to hashedpassword property.
              But here generate orignal hashedpassword.
            */
            accountUser.HashedPassword = _encryptionService.EncryptPassword(accountUser.HashedPassword, passwordSalt);
            var address = AddAddress(accountUser.Address);
            if (address == null)
                throw new Exception("AddressId can not be found");

            accountUser.AddressId = address.Id;
            accountUser.CreatedByUTC = DateTime.UtcNow;
            _accountUserRepository.Add(accountUser);
            _accountUserRepository.Commit();

            // add user account role for created user
            addUserToRole(accountUser, 3);
            _accountUserRepository.Commit();

            return accountUser;
        }

        public Address AddAddress(Address address)
        {
            if (address == null)
                throw new Exception("Address required to create account user");

            _addressRepository.Add(address);
            _addressRepository.Commit();

            return _addressRepository.GetInsertedAddress();
        }

        /// <summary>
        /// Get usser roles for account user
        /// </summary>
        /// <param name="username">The username</param>
        /// <returns>Return list of roles</returns>
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
        /// <summary>
        /// Add roles relation for account user
        /// </summary>
        /// <param name="user">The created account user</param>
        /// <param name="roleId">The assigned role</param>
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

        /// <summary>
        /// Login details validation
        /// </summary>
        /// <param name="user">The account user</param>
        /// <param name="password">The password</param>
        /// <returns>Retrun valid user or invalid user</returns>
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

        /// <summary>
        /// Login details validation
        /// </summary>
        /// <param name="user">The account user</param>
        /// <param name="password">The password</param>
        /// <returns>Retrun password correct or incorrect</returns>
        private bool isPasswordValid(AccountUser user, string password)
        {
            return string.Equals(_encryptionService.EncryptPassword(password, user.PasswordSalt), user.HashedPassword);
        }
        #endregion
    }
}
