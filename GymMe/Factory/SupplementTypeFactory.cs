using GymMe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Factory
{
    public class SupplementTypeFactory
    {
        public static MsSupplementType createSupplementType(int supplementtypeid, string supplementtypename)
        {
            MsSupplementType supplementType = new MsSupplementType()
            {
                SupplementTypeID = supplementtypeid,
                SupplementTypeName = supplementtypename
            };
            return supplementType;
        }
    }
}