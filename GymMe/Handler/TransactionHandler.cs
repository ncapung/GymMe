using GymMe.Model;
using GymMe.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Handler
{
    public class TransactionHandler
    {
        public static Boolean insertTransaction(int userId)
        {
            TransactionRepository.insertTransaction(userId);
            return true;
        }

        public static List<TransactionHeader> viewOrders()
        {
            return TransactionRepository.viewOrders();
        }

        public static void handleOrder(int transactionId)
        {
            TransactionRepository.handleOrder(transactionId);
        }

        public static List<TransactionHeader> viewHistory(int userId)
        {
            return TransactionRepository.viewHistory(userId);
        }

        public static void viewDetail(int transactionId)
        {
            TransactionRepository.viewDetail(transactionId);
        }

        public static void deleteBySuppID(int suppId)
        {
            TransactionRepository.deleteBySuppID(suppId);
        }

    }
}