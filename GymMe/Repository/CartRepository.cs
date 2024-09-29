using GymMe.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace GymMe.Repository
{
    public class CartRepository
    {
        private static GymMe_DatabaseEntities8 db = Singleton.createSingleton();

        public static void insertToCart(int userId, int supplementId, int quantity)
        {
            MsCart cart = new MsCart();
            cart.UserID = userId;
            cart.SupplementID = supplementId;
            cart.Quantity = quantity;

            db.MsCarts.Add(cart);
            db.SaveChanges();
        }

        public static void clearCart(int userId)
        {
            List<MsCart> msCarts = (from x in  db.MsCarts where x.UserID == userId select x).ToList();
            db.MsCarts.RemoveRange(msCarts);
            db.SaveChanges();
        }

        public static List<MsCart> getCart(int userId)
        {
            return (from x in db.MsCarts where x.UserID == userId select x).ToList();
        }

        public static MsCart getById(int id)
        {
            MsCart msCart = db.MsCarts.Find(id);
            return msCart;
        }

        public static void checkoutCart(int cartId)
        {
            MsCart msCart = getById(cartId);
            db.MsCarts.Remove(msCart);
            db.SaveChanges();
        }

        public static List<MsCart> getBySuppID(int suppId)
        {
            return (from x in db.MsCarts where x.SupplementID == suppId select x).ToList();
        }

        public static void deleteBySuppID(int suppId)
        {
            List<MsCart> cartDelete = getBySuppID(suppId);
            if (cartDelete.Count > 0) {
                db.MsCarts.RemoveRange(cartDelete);
                db.SaveChanges();
            }
        }
    }
}