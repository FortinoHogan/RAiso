using RAiso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAiso.Factory
{
    public class TransactionHeaderFactory
    {
        public static TransactionHeader CreateTransactionHeader(int tID, int uID, DateTime date)
        {
            TransactionHeader th = new TransactionHeader
            {
                TransactionID = tID,
                UserID = uID,
                TransactionDate = date,
            };
            return th;
        }
    }
}