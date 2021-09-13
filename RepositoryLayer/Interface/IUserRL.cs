using CommonLayer;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IUserRL
    {
        List<UserModel> getAllUsers();
        bool RegisterUser(UserModel userModel);
        User UserLogIn(LogInModel logInModel);
    }
}
