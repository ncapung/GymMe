using GymMe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Repository
{
    public class Singleton
    {
        private static GymMe_DatabaseEntities8 db;
        public static GymMe_DatabaseEntities8 createSingleton()
        {
            if(db == null)
            {
                db = new GymMe_DatabaseEntities8();
            }
            return db;
        }
    }
}