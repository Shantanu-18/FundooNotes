using CommonLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IUserRL
    {
        List<UserModel> getAllUsers();
        bool RegisterUser(UserModel userModel);
        bool UserLogIn(LogInModel logInModel);
    }
}
