using RAiso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAiso.Factory
{
    public class TransactionDetailFactory
    {
        public static TransactionDetail CreateTransactionDetail(int tID, int sID, int qty)
        {
            TransactionDetail td = new TransactionDetail
            {
                TransactionID = tID,
                StationeryID = sID,
                Quantity = qty,
            }; 
            return td;
        }
    }
}