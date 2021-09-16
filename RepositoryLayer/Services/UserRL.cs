using BusinessLayer.Interface;
using CommonLayer;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer.Services
{
    public class UserRL : IUserRL
    {
        private UserContext _userContext;
        User user = new User();

        public UserRL(UserContext userContext)
        {
            this._userContext = userContext;
        }


        public List<UserModel> getAllUsers()
        {
            try
            {
                List<UserModel> userModels = new List<UserModel>();
                //userModels.Add(new UserModel { FirstName = "Shantanu", LastName = "Borkar", Email = "asasd@ga" });
                //userModels.Add(new UserModel { FirstName = "Xyz", LastName = "Abc", Email = "asasd@ga" });

                return userModels;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool RegisterUser(UserModel userModel)
        {
            try
            {
                user.FirstName = userModel.FirstName;
                user.LastName = userModel.LastName;
                user.Email = userModel.Email;
                user.Password = userModel.Password;
                user.CreatedAt = DateTime.Now;
                user.ModifiedAt = null;

                this._userContext.Users.Add(user);
                int result = _userContext.SaveChanges();

                if (result > 0)
                {
                    return true;
                }
                else { return false; }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public User UserLogIn(LogInModel logInModel)
        {
            try
            {
                var result = _userContext.Users.SingleOrDefault(e => e.Email == logInModel.email
                                                                    && e.Password == logInModel.password);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public User ForgotPassword(ForgotPassModel forgotPassModel)
        {
            try
            {
                var result = _userContext.Users.SingleOrDefault(e => e.Email == forgotPassModel.Email);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public User ResetPassword(ResetPasswordModel resetPasswordModel, long UserId)
        {
            try
            {
                var result = _userContext.Users.SingleOrDefault(e => e.Id == UserId);

                if (result != null)
                {
                    result.Password = resetPasswordModel.Password;
                    result.ModifiedAt = DateTime.Now;
                    _userContext.SaveChanges();
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
