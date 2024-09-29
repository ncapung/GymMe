using GymMe.Model;
using GymMe.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Handler
{
    public class CartHandler
    {
        public static Boolean insertCart(int userId, int supplementId, int quantity)
        {
            CartRepository.insertToCart(userId, supplementId, quantity);
            return true;
        }

        public static Boolean clearCart(int userId)
        {
            CartRepository.clearCart(userId);
            return true;
        }

        public static List<MsCart> getCart(int userId)
        {
            return CartRepository.getCart(userId);
        }

        public static Boolean getById(int id)
        {
            CartRepository.getById(id);
            return true;
        }

        public static Boolean checkoutCart(int userId)
        {
            CartRepository.clearCart(userId);
            return true;
        }
        public static void deleteBySuppID(int suppId)
        {
            CartRepository.deleteBySuppID(suppId);
        }
    }
}