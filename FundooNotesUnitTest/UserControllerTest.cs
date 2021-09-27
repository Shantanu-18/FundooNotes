using System;
using Moq;
using Xunit;
using BusinessLayer.Interface;
using RepositoryLayer.Entity;
using CommonLayer;
using FundooNotes.Controllers;
using Microsoft.Extensions.Configuration;

namespace FundooNotesUnitTest
{
    public class UserControllerTest
    {
        private Mock<IUserRL> _userRL;
        private Mock<IUserBL> _userBL;
        private IConfiguration _config;
        User user = new User();
        UserModel userModel = new UserModel();

        public UserControllerTest(Mock<IUserRL> userRL, Mock<IUserBL> userBL, IConfiguration config)
        {
            this._userRL = userRL;
            this._userBL = userBL;
            this._config = config;
        }

        [Fact]
        public void RegisterUser_TrueOrFalse_UserAddedOrNot()
        {
            //user.Id = 1;
            //user.FirstName = "Shantanu";
            //user.LastName = "Borkar";
            //user.Email = "xyz@gmail.com";
            //user.Password = "Zxcvbn@12";
            //user.CreatedAt = DateTime.Now;
            //user.ModifiedAt = null;

            userModel.FirstName = "Shantanu";
            userModel.LastName = "Borkar";
            userModel.Email = "xyz@gmail.com";
            userModel.Password = "Zxcvbn@12";

            _userRL.Setup(e => e.RegisterUser(userModel)).Returns(true);

            UserController userController = new UserController(_userBL.Object,_config);
            var result = userController.RegisterUser(userModel);
            Assert.True(result.Equals(true));
        }
    }
}
