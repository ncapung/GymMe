using GymMe.Factory;
using GymMe.Model;
using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;

namespace GymMe.Repository
{
    public class SupplementRepository
    {

        private static GymMe_DatabaseEntities8 db = Singleton.createSingleton();

        public static List<MsSupplement> getAllSupplements()
        {
            return db.MsSupplements.ToList();
        }

        public static List<MsSupplementType> getAllSupplementType()
        {
            return db.MsSupplementTypes.ToList();
        }

        public static MsSupplement getById(int id)
        {
            MsSupplement supplement = db.MsSupplements.Find(id);
            return supplement;
        }

        public static void insertSupplement(string supplementName, DateTime expiry, int price, int supplementtypeid)
        {
            MsSupplement supplement1 = SupplementFactory.createSupplement(supplementName, expiry, price, supplementtypeid);
            db.MsSupplements.Add(supplement1);
            db.SaveChanges();
        }

        public static void updateSupplement(int id, string supplementName, DateTime expiry, int price, int supplementtypeid)
        {
            MsSupplement supplement = getById(id);

            supplement.SupplementName = supplementName;
            supplement.SupplementPrice = price;
            supplement.SupplementExpiryDate = expiry;
            supplement.SupplementTypeID = supplementtypeid;
            db.SaveChanges();
        }

        public static void deleteSupplement(int id)
        {
            MsSupplement msSupplement = getById(id);
            db.MsSupplements.Remove(msSupplement);
            db.SaveChanges();
        }
        
    }
}