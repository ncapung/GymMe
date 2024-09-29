using GymMe.Handler;
using GymMe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace GymMe.Controller
{
    public class CartController
    {
        public static void clearCart(int id)
        {
            CartHandler.clearCart(id);
        }

        public static void insertCart(int userId, int supplementTypeId, int quantity)
        {
            CartHandler.insertCart(userId, supplementTypeId, quantity);
        }

        public static void checkoutCart(int UserId)
        {
            CartHandler.checkoutCart(UserId);
        }

        public static void deleteBySuppID(int suppId)
        {
            Handler.CartHandler.deleteBySuppID(suppId);
        }
    }
}