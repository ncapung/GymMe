using GymMe.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace GymMe.Factory
{
    public class SupplementFactory
    {
        public static MsSupplement createSupplement(string supplementName, DateTime expiry, int price, int supplementtypeid)
        {
            MsSupplement supplement = new MsSupplement()
            {
                SupplementName = supplementName,    
                SupplementExpiryDate = expiry,
                SupplementPrice = price,
                SupplementTypeID = supplementtypeid 
            };
            return supplement;

        }



    }
}