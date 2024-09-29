using GymMe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Factory
{
    public class CartFactory
    {
        public static MsCart createCart(int userid, int supplementid, int quantity)
        {
            MsCart cart = new MsCart()
            {
                UserID = userid,
                SupplementID = supplementid,
                Quantity = quantity
            };
            return cart;
        }
    }
}