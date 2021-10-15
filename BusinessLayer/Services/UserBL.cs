// <copyright file="UserBL.cs" Company="MediaWare Infotech Pvt. Lmt.>
//   Copyright © 2021 Company="MediaWare Infotech Pvt. Lmt."
// </copyright>
// <creator name="Shantanu"/>
namespace BusinessLayer.Services
{
    using System;
    using System.Collections.Generic;
    using BusinessLayer.Interface;
    using CommonLayer;
    using RepositoryLayer.Entity;

    public class UserBL : IUserBL
    {
        /// <summary>
        /// The user repository layer
        /// </summary>
        private IUserRL _userRL;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserBL"/> class.
        /// </summary>
        /// <param name="userRL">The user rl.</param>
        public UserBL(IUserRL userRL)
        {
            this._userRL = userRL;
        }

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns></returns>
        public List<string> getAllUsers(long userId)
        {
            try
            {
                return this._userRL.getAllUsers(userId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Registers the user.
        /// </summary>
        /// <param name="userModel">The user model.</param>
        /// <returns>boolean</returns>
        public bool RegisterUser(UserModel userModel)
        {
            try
            {
                return this._userRL.RegisterUser(userModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Users the log in.
        /// </summary>
        /// <param name="logInModel">The log in model.</param>
        /// <returns>User</returns>
        public User UserLogIn(LogInModel logInModel)
        {
            try
            {
                return this._userRL.UserLogIn(logInModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Forgot the password.
        /// </summary>
        /// <param name="forgotPassModel">The forgot pass model.</param>
        /// <returns>User</returns>
        public User ForgotPassword(ForgotPassModel forgotPassModel)
        {
            try
            {
                return this._userRL.ForgotPassword(forgotPassModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Resets the password.
        /// </summary>
        /// <param name="resetPasswordModel">The reset password model.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>User</returns>
        public User ResetPassword(ResetPasswordModel resetPasswordModel, long userId)
        {
            try
            {
                return this._userRL.ResetPassword(resetPasswordModel, userId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
