using BusinessLayer.Interface;
using CommonLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserBL _userBL;
        private IConfiguration _config;

        public UserController(IUserBL userBL, IConfiguration configuration)
        {
            this._userBL = userBL;
            _config = configuration;
        }

        [HttpGet]
        [Authorize]
        public IActionResult userData()
        {
            var useList = this._userBL.getAllUsers();
            return this.Ok(new { Success = true, message = "Get User Data SuccessFully.", Data = useList });
        }

        [HttpPost]
        public IActionResult RegisterUser(UserModel userModel)
        {
            try
            {
                bool result = this._userBL.RegisterUser(userModel);

                if (result == true)
                {
                    return this.Ok(new { Success = true, message = "Registered User Successfully!" });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "User registration failed!!" });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.Message, stackTrace = e.StackTrace });
            }
        }


        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Login([FromBody] LogInModel login)
        {
            try
            {
                IActionResult response = Unauthorized();
                User user = _userBL.UserLogIn(login);

                if (user != null)
                {
                    var tokenString = GenerateJSONWebToken(user.Id,user.Email);
                    var userData = new { Id = user.Id, FirstName = user.FirstName, LastName = user.LastName, Email = user.Email, CreatedAt = user.CreatedAt };
                    response = Ok(new { Success = true, Message = "Log In Successful!!", token = tokenString, Data = userData });
                }

                return response;
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        private string GenerateJSONWebToken(long Id,string email)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] { 
                new Claim("Id",Id.ToString()),
                new Claim(ClaimTypes.Email,email)
            };

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
