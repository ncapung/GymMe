using GymMe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Factory
{
    public class UserFactory
    {
        public static MsUser createUser(string username, string password, string email, DateTime dob, string gender)
        {
            MsUser user = new MsUser()
            {
                UserName = username,
                UserEmail = email,
                UserPassword = password,
                UserDOB = dob,  
                UserGender = gender,
                UserRole = "Customer"
            };
            return user;
        }
    }
}