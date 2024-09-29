using GymMe.Model;
using GymMe.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Handler
{
    public class UserHandler
    {
        public static List<MsUser> getAllCustomer()
        {
            return UserRepository.getAllCustomer();
        }

        public static MsUser getProfileById(int id)
        {
            return UserRepository.getProfileById(id);

        }

        public static Boolean updateProfile(int id, string username, string email, string gender, DateTime dob)
        {
            if(getProfileById(id) == null)
            {
                return false;
            }
            UserRepository.updateProfile(id, username, email, gender, dob);
            return true;
        }

        public static void insertUser(MsUser user)
        {
            UserRepository.insertUser(user);
            return;
        }

        public static Boolean updateUserPassword(string oldPassword, string newPassword, int UserID)
        {
            return UserRepository.updateUserPassword(oldPassword, newPassword, UserID);

        }
    }


}