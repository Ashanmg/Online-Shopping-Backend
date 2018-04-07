using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OS.Services.Serivices.Abstracts;
using OS.Infastructures.Repositories.Abstracts;
using OS.Web.ViewModels;
using OS.Services.Core;
using OS.Entities;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace OS.Web.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAccountUserRepository _accountUserRepository;

        public UserController(
            IUserService userService,
            IAccountUserRepository accountUserRepository)
        {
            this._userService = userService;
            this._accountUserRepository = accountUserRepository;
        }
        
        [HttpPost]
        [Route("/login")]
        public async Task<IActionResult> AccountUserLogin([FromBody]UserModel user)
        {
            IActionResult _result = new ObjectResult(false);
            BaseResponse _authenticationResponse = null;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                MembershipContext _membershipContext = _userService.ValidateUser(user.Username, user.Password);

                if (_membershipContext.User != null)
                {
                    IEnumerable<Role> _roles = _accountUserRepository.GetUserRoles(user.Username);
                    List<Claim> _claims = new List<Claim>();

                    foreach (Role role in _roles)
                    {
                        Claim _claim = new Claim(ClaimTypes.Role, "Admin", ClaimValueTypes.String, user.Username);
                        _claims.Add(_claim);
                    }
                    await HttpContext.Authentication.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(new ClaimsIdentity(_claims, CookieAuthenticationDefaults.AuthenticationScheme)),
                        new Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties { IsPersistent = user.RememberMe });

                    _authenticationResponse = new BaseResponse()
                    {
                        Succeeded = true,
                        Message = "Authentication succeeded"
                    };
                }
                else
                {
                    _authenticationResponse = new BaseResponse()
                    {
                        Succeeded = false,
                        Message = "Authentication failed"
                    };
                }
            }
            catch (Exception ex)
            {
                _authenticationResponse = new BaseResponse()
                {
                    Succeeded = false,
                    Message = ex.Message
                };
            }
            _result = new ObjectResult(_authenticationResponse);
            return _result;
        }
    }
}
