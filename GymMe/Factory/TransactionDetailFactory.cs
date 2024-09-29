using GymMe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Factory
{
    public class TransactionDetailFactory
    {
        public static TransactionDetail createTransactionDetail(int transactionID, int supplementID, int quantity)
        {
            TransactionDetail transactionDetail = new TransactionDetail()
            {
                TransactionID = transactionID,
                SupplementID = supplementID,
                Quantity = quantity
            };
            return transactionDetail;
        }
    }
}