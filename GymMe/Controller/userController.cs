using GymMe.Handler;
using GymMe.Model;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace GymMe.Controller
{
    public class UserController
    {
        public static string insertUser(MsUser user)
        {
            if (user != null)
            {
                string username = user.UserName;
                string gender = user.UserGender;
                string email = user.UserEmail;
                DateTime dob = user.UserDOB;
                string password = user.UserPassword;
                Boolean isAlphaNumeric = password.Any(char.IsDigit) && password.Any(char.IsLetter);
                if (username.Length < 5 || username.Length > 15) return "username";
                if (!(gender.Equals("Male") || gender.Equals("Female"))) return "gender";
                if (!email.EndsWith(".com")) return "email";
                if (!isAlphaNumeric) return "pass";
                if (dob.Equals("")) return "dob";
                Handler.UserHandler.insertUser(user);
                return "user ada";
            }
            return "tidak ada user";
        }

        public static MsUser getProfileById(int id)
        {
            return Handler.UserHandler.getProfileById(id);
        }

        public static void updateProfile(int id, string username, string email, string gender, DateTime dob)
        {
            UserHandler.updateProfile(id, username, email, gender, dob);
        }

        public static Boolean updateUserPassword(string oldPassword, string newPassword, int UserID) 
        {
            if(oldPassword == string.Empty || newPassword == string.Empty) return false;
            if(!(oldPassword.Any(char.IsLetter) && newPassword.Any(char.IsDigit))) return false;
            return UserHandler.updateUserPassword(oldPassword, newPassword, UserID);

        }
    }
}