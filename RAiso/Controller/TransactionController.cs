using RAiso.Handler;
using RAiso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAiso.Controller
{
    public class TransactionController
    {
        public static List<TransactionHeader> GetAllTh(int uID)
        {
            return TransactionHandler.GetAllTh(uID);
        }
        public static TransactionDetail GetTd(int tID)
        {
            return TransactionHandler.GetTd(tID);
        }
        public static TransactionHeader GetTh(int uID, int tID)
        {
            return TransactionHandler.GetTh(uID, tID);
        }
    }
}