﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserSecDAL;
using UserSecBE;
using System.Data;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace UserSecBAL
{
    public class UserBAL
    {

        #region Methods

        public DataSet GetSecretQuestion()
        {
            UserDAL userDAL = new UserDAL();
            return userDAL.GetSecretQuestion();
        }

        public bool GetAllUserDetails(ref DataTable dt)
        {
            UserDAL userDAL = new UserDAL();

            if (userDAL.GetAllUserDetails(ref dt))
                return true;
            else
                return false;
        }
        public bool Delete(UserBE user)
        {
            UserDAL userDAL = new UserDAL();
            if (userDAL.Delete(user))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Modify(UserBE user)
        {
            UserDAL userDAL = new UserDAL();
            if (userDAL.Modify(user))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ViewUser(UserBE viewuser)
        {
            UserDAL userDAL = new UserDAL();
            if (userDAL.ViewUser(viewuser))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void PasswordChange()
        {
        }


        public bool Validate(ref UserBE user)
        {
            UserDAL userDAL = new UserDAL();

            if (userDAL.Validate(ref user))
                return true;
            else
                return false;
        }


        public bool AddUser(UserBE addUserBE , ref int ReturnOutput)
        {
            UserDAL userDAL = new UserDAL();
            if (userDAL.AddUser(addUserBE, ref ReturnOutput))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateData(UserBE user)
        {
            //Check required fields 
            // Check specific field wise check - email, phone, country,...

            Regex re = new Regex("^[0-9]{10}");
            Regex rex = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");

            if (re.IsMatch(user.MobileNo.Trim()) == false || user.MobileNo.Length > 10)
            {
                return false;
            }
            else
            {
                return true;
            }


            //if (rex.IsMatch(user.PrimaryEmailId.Trim()) == false || user.PrimaryEmailId.Length > 50)
            //{
            //    return false;
            //}
            //else
            //{
            //    return true;
            //}
        }

        public bool UserAccessRight(UserBE user, ref DataTable dt)
        {
            UserDAL userDAL = new UserDAL();
            if(userDAL.UserAccessRight(user,ref dt))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ResetPassword(UserBE user)
        {
            UserDAL userDAL = new UserDAL();
            if (userDAL.ResetPassword(user))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public DataSet GetUsers()
        {
            try
            {
                UserDAL userDAL = new UserDAL();
                return userDAL.GetUsers();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }
        public DataSet InsertUser(UserBE UserBE)
        {
            try
            {

                UserDAL userDAL = new UserDAL();

                return userDAL.InsertUser(UserBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }

        public DataSet CheckConfirmationRequest(string UserId, string key)
        {
            try
            {
                UserDAL userDAL = new UserDAL();

                return userDAL.CheckConfirmationRequest(UserId, key);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }

        public int SaveConfirmation(string UserId, string Key, string Password)
        {
            try
            {
                UserDAL userDAL = new UserDAL();

                return userDAL.SaveConfirmation(UserId, Key, Password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }

        #endregion Methods
    }
}
