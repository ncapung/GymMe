using GymMe.Handler;
using GymMe.Model;
using GymMe.Repository;
using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Net;
using System.Web;

namespace GymMe.Controller
{
    public class SupplementController
    {
        public static List<MsSupplement> getAllSupplements()
        {
            return SupplementHandler.getAllSupplements();
        }

        public static MsSupplement getById(int id)
        {
            return SupplementHandler.getById(id);
        }

        public static List<MsSupplementType> getAllSupplementTypes()
        {
            return SupplementHandler.getAllSupplementTypes();
        }

        public static void updateSupplement(int id, string supplementName, DateTime expiry, int price, int supplementtypeid)
        {
            SupplementHandler.updateSupplement(id, supplementName, expiry, price, supplementtypeid);
        }

        public static void deleteSupplement(int id)
        {
            SupplementHandler.deleteSupplement(id);
            return;
        }

        public static void insertSupplement(string supplementName, DateTime expiry, int price, int supplementtypeid)
        {
            SupplementHandler.insertSupplement(supplementName, expiry, price, supplementtypeid);
            return;
        }
    }
}