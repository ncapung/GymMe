using GymMe.Handler;
using GymMe.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Web;

namespace GymMe.Repository
{
    public class UserRepository
    {
        private static GymMe_DatabaseEntities8 db = Singleton.createSingleton();

        public static List<MsUser> getAllCustomer()
        {
           return (from x in db.MsUsers where x.UserRole.Equals("Customer") select x).ToList(); 
        }

        public static MsUser getProfileById(int id)
        {
            return (from x in db.MsUsers where x.UserID.Equals(id) select x).FirstOrDefault();
        }

        public static void updateProfile(int id, string username, string email, string gender, DateTime dob)
        {
            if (db.MsUsers.Find(id) == null)
            {
                return;
            }
            MsUser user2 = db.MsUsers.Find(id);
            user2.UserName = username;
            user2.UserEmail = email;
            // user2.UserPassword = user.UserPassword;
            user2.UserGender = gender;
            user2.UserDOB = dob;
            db.Entry(user2).State = EntityState.Modified;
            db.SaveChanges();
        }

        public static void insertUser(MsUser user1)
        {
            db.MsUsers.Add(user1);   
            db.SaveChanges();
            return;
        }

        public static Boolean updateUserPassword(string oldPassword, string newPassword, int UserID)
        {
            MsUser user = db.MsUsers.Find(UserID);
            if (user.UserPassword != oldPassword) return false;
            user.UserPassword = newPassword;
            db.SaveChanges();
            return true;

        }
    }
}