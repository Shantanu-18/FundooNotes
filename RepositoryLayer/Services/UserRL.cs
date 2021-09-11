﻿using BusinessLayer.Interface;
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
            catch (Exception e)
            {
                throw;
            }
        }

        public bool RegisterUser(UserModel userModel)
        {
            try
            {
                User user = new User();
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
            catch (Exception e)
            {
                throw;
            }
        }

        public bool UserLogIn(LogInModel logInModel)
        {
            try
            {
                var result = _userContext.Users.SingleOrDefault(e => e.Email == logInModel.email 
                                                                    && e.Password == logInModel.password);

                if (result == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
