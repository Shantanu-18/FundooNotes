using CommonLayer;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IUserBL
    {
        List<string> getAllUsers(long userId);

        bool RegisterUser(UserModel userModel);

        User UserLogIn(LogInModel logInModel);

        User ForgotPassword(ForgotPassModel forgotPassModel);

        User ResetPassword(ResetPasswordModel resetPasswordModel, long UserId);
    }
}
