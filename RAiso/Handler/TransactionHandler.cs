using RAiso.Factory;
using RAiso.Model;
using RAiso.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAiso.Handler
{
    public class TransactionHandler
    {
        public static List<TransactionHeader> GetAllTh(int uID)
        {
            return TransactionRepository.GetAllTh(uID);
        }
        private static int GenerateID()
        {
            int id = 0;
            TransactionHeader tr = TransactionRepository.GetLastTransaction();
            if (tr == null)
            {
                id = 1;
            }
            else
            {
                id = tr.TransactionID;
                id++;
            }
            return id;
        }
        public static void Checkout(List<Cart> carts)
        {
            TransactionHeader th = HandleCheckoutTh(carts[0].UserID);
            TransactionRepository.InsertTransactionHeader(th);
            foreach (Cart cart in carts)
            {
                TransactionDetail td = HandleCheckoutTd(th.TransactionID, cart.StationeryID, cart.Quantity);
                TransactionRepository.InsertTransactionDetail(td);
            }
        }
        public static TransactionHeader HandleCheckoutTh(int uID)
        {
            TransactionHeader th = TransactionHeaderFactory.CreateTransactionHeader(GenerateID(), uID, DateTime.Now);
            return th;
        }
        public static TransactionDetail HandleCheckoutTd(int tID, int sID, int qty)
        {
            TransactionDetail td = TransactionDetailFactory.CreateTransactionDetail(tID, sID, qty);
            return td;
        }
        public static TransactionDetail GetTd(int tID)
        {
            return TransactionRepository.GetTd(tID);
        }
        public static TransactionHeader GetTh(int uID, int tID)
        {
            return TransactionRepository.GetTh(uID, tID);
        }
        public static List<TransactionDetail> GetAllTd(int tID)
        {
            return TransactionRepository.GetAllTd(tID);
        }
    }
}