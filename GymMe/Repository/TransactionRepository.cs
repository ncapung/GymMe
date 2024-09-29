using GymMe.Factory;
using GymMe.Handler;
using GymMe.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace GymMe.Repository
{
    public class TransactionRepository
    {

        private static GymMe_DatabaseEntities8 db = Singleton.createSingleton();

        public static void insertTransaction(int userId)
        {
            DateTime now = DateTime.Now;
            TransactionHeader transactionHeader = TransactionHeaderFactory.createTransactionHeader(userId, now, "Unhandled");
            db.TransactionHeaders.Add(transactionHeader);
            db.SaveChanges();
            
            List<MsCart> cartList = CartHandler.getCart(userId);
            foreach (MsCart cart in cartList)
            {
                insertDetail(transactionHeader.TransactionID, cart.SupplementID, cart.Quantity);
            }
        }

        public static void insertDetail(int transactionId, int supplementId, int quantity)
        {
            TransactionDetail transactionDetail = TransactionDetailFactory.createTransactionDetail(transactionId, supplementId, quantity);

            db.TransactionDetails.Add(transactionDetail);
            db.SaveChanges();
        }

        public static List<TransactionHeader> viewOrders()
        {
            return (from x in db.TransactionHeaders select x).ToList();
        }

        public static TransactionHeader getById(int id)
        {
            TransactionHeader transactionHeader = db.TransactionHeaders.Find(id);
            return transactionHeader;
        }

        public static void handleOrder(int transactionId)
        {
            TransactionHeader order = getById(transactionId);
            order.Status = "Handled";
            db.SaveChanges();
        }

        public static List<TransactionHeader> viewHistory(int userId)
        {
            return (from x in db.TransactionHeaders where x.UserID == userId select x).ToList();
        }

        public static List<TransactionDetail> viewDetail(int transactionId)
        {
            return (from x in db.TransactionDetails where x.TransactionID == transactionId select x).ToList();
        }

        public static List<TransactionDetail> getBySuppID(int suppId)
        {
            return (from x in db.TransactionDetails where x.SupplementID == suppId select x).ToList();
        }

        public static void deleteBySuppID(int suppId)
        {
            List<TransactionDetail> tdDelete = getBySuppID(suppId);
            if (tdDelete.Count > 0)
            {
                db.TransactionDetails.RemoveRange(tdDelete);
                db.SaveChanges();
            }
        }
    }
}