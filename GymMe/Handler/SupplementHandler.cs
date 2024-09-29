using GymMe.Model;
using GymMe.Repository;
using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;

namespace GymMe.Handler
{
    public class SupplementHandler
    {
        public static List<Model.MsSupplement> getAllSupplements()
        {
            return SupplementRepository.getAllSupplements();
        }

        public static Boolean insertSupplement(string supplementName, DateTime expiry, int price, int supplementtypeid)
        {
            SupplementRepository.insertSupplement(supplementName, expiry, price, supplementtypeid);
            return true;
        }

        public static List<MsSupplementType> getAllSupplementTypes()
        {
            return SupplementRepository.getAllSupplementType();
        }

        public static Boolean updateSupplement(int id, string supplementName, DateTime expiry, int price, int supplementtypeid)
        {
            if(SupplementRepository.getById(id) != null)
            {
                SupplementRepository.updateSupplement(id, supplementName, expiry, price, supplementtypeid);
                return true;
            }
            return false;
        }

        public static Boolean deleteSupplement(int id)
        {
            if(SupplementRepository.getById(id) != null)
            {
                SupplementRepository.deleteSupplement(id);
                return true;
            }
            return false;
        }

        public static MsSupplement getById(int id)
        {
            return SupplementRepository.getById(id);
        }
    }
}