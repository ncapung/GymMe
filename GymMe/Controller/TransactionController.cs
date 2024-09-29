using GymMe.Handler;
using GymMe.Model;
using GymMe.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Controller
{
    public class TransactionController
    {
        public static void insertTransaction(int userId)
        {
            Handler.TransactionHandler.insertTransaction(userId);
        }

        public static void deleteBySuppID(int suppId)
        {
            Handler.TransactionHandler.deleteBySuppID(suppId);
        }
        public static void handleOrder(int transactionId)
        {
            Handler.TransactionHandler.handleOrder(transactionId);
        }

        public static List<TransactionHeader> getTransactionHeaders() 
        {
           return TransactionHandler.viewOrders();
        }
    }
}