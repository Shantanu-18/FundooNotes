using BusinessLayer.Interface;
using CommonLayer;
using CommonLayer.MSMQ;
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

        private long GetTokenId()
        {
            long userId = Convert.ToInt64(User.FindFirst("Id").Value);
            return userId;
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
                    return Ok(new { Success = true, message = "Registered User Successfully!" });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "User registration failed!!" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { success = false, message = e.Message, stackTrace = e.StackTrace });
            }
        }


        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public IActionResult Login([FromBody] LogInModel login)
        {
            try
            {
                IActionResult response = Unauthorized();
                User user = _userBL.UserLogIn(login);

                if (user != null)
                {
                    var tokenString = GenerateJSONWebToken(user.Id, user.Email);
                    var userData = new { Id = user.Id, FirstName = user.FirstName, LastName = user.LastName, Email = user.Email, CreatedAt = user.CreatedAt };
                    response = Ok(new { Success = true, Message = "Log In Successfull.", token = tokenString, Data = userData });
                }

                return response;
            }
            catch (Exception e)
            {
                return BadRequest(new { success = false, message = e.Message, stackTrace = e.StackTrace });
            }

        }

        [AllowAnonymous]
        [HttpPost("ForgotPassword")]
        public IActionResult ForgotPassword(ForgotPassModel forgotModel)
        {
            try
            {
                User user = _userBL.ForgotPassword(forgotModel);

                if (user != null)
                {
                    string tokenString = GenerateJSONWebToken(user.Id, user.Email);

                    new MsmqOperations().SendingData(tokenString);

                    return Ok(new { Success = true, message = "Reset password link is sent via mail to you." });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Unsuccessfull." });
                }
            }
            catch (Exception e)
            {

                return BadRequest(new { success = false, message = e.Message, stackTrace = e.StackTrace });
            }
        }

        [Authorize]
        [HttpPut("ResetPassword")]
        public IActionResult ResetPassword(ResetPasswordModel resetPasswordModel)
        {
            try
            {
                if (resetPasswordModel.Password == resetPasswordModel.ConfirmPassword)
                {
                    long UserId = GetTokenId();
                    User user = _userBL.ResetPassword(resetPasswordModel, UserId);

                    if (user != null)
                    {
                        return this.Ok(new { Success = true, message = "Password Changed Successfully." });
                    }
                    else
                    {
                        return this.BadRequest(new { Success = false, message = "Something went wrong." });
                    }
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Password should be same." });
                }

            }
            catch (Exception e)
            {
                return BadRequest(new { success = false, message = e.Message, stackTrace = e.StackTrace });
            }
        }


        private string GenerateJSONWebToken(long Id, string email)
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
