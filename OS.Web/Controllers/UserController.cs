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
using AutoMapper;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace OS.Web.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        #region fields
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IAccountUserRepository _accountUserRepository;
        #endregion

        #region constructor
        public UserController(
            IMapper mapper,
            IUserService userService,
            IAccountUserRepository accountUserRepository)
        {
            this._mapper = mapper;
            this._userService = userService;
            this._accountUserRepository = accountUserRepository;
        }
        #endregion

        #region API Methods
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> AccountUserLogin([FromBody]UserCredentialModel user)
        {
            ActionResult _result = new ObjectResult(false);
            BaseResponse _authenticationResponse = null;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                MembershipContext _membershipContext = _userService.ValidateUser(user.Username, user.Password);

                if (_membershipContext.User != null)
                {
                    // generate Json Web Token
                    string token = GenerateToken(user.Username);

                    _authenticationResponse = new BaseResponse()
                    {
                        Succeeded = true,
                        Message = token
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

        [HttpPost]
        [Route("register")]
        public IActionResult AccountUserRegister([FromBody]UserGeneralModel user)
        {
            IActionResult _result = new ObjectResult(false);
            BaseResponse _registerResponse = null;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var accountUser = _mapper.Map<UserGeneralModel, AccountUser>(user);

                AccountUser _accountUser = _userService.CreateUser(accountUser);

                _registerResponse = new BaseResponse()
                {
                    Succeeded = true,
                    Message = "Registration succeeded"
                };
            }
            catch (Exception ex)
            {
                _registerResponse = new BaseResponse()
                {
                    Succeeded = false,
                    Message = ex.Message
                };
            }

            _result = new ObjectResult(_registerResponse);
            return _result;
        }

        [HttpGet]
        [Route("test")]
        [DisableCors]
        public IActionResult getalluser()
        {
            return new ObjectResult(false);
        }
        #endregion

        #region Helper Methods
        private string GenerateToken(string username)
        {
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(JwtRegisteredClaimNames.Nbf,
                new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp,
                new DateTimeOffset(DateTime.UtcNow.AddDays(1)).ToUnixTimeSeconds().ToString())
            };

            var token = new JwtSecurityToken(
            new JwtHeader(new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes("at-least-16-character-secret-key")),
               SecurityAlgorithms.HmacSha256)),
            new JwtPayload(claims));

            return new JwtSecurityTokenHandler().WriteToken(token);


        }
        #endregion
    }
}
