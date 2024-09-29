using GymMe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Factory
{
    public class TransactionHeaderFactory
    {
        public static TransactionHeader createTransactionHeader(int userid, DateTime transactiondate, string status)
        {
            TransactionHeader transactionHeader = new TransactionHeader()
            {
                UserID = userid,    
                TransactionDate = transactiondate,
                Status = status 
            };
            return transactionHeader;

        }
    }
}