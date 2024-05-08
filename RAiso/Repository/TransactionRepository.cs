using RAiso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAiso.Repository
{
    public class TransactionRepository
    {
        static DatabaseEntities db = DatabaseSingleton.GetInstance();
        public static TransactionHeader GetLastTransaction()
        {
            return (from t in db.TransactionHeaders
                    select t).ToList().LastOrDefault();
        }
        public static void InsertTransaction(TransactionHeader th, TransactionDetail td)
        {
            db.TransactionHeaders.Add(th);
            db.TransactionDetails.Add(td);
            db.SaveChanges();
        }
        public static List<TransactionHeader> GetAllTh(int uID)
        {
            return (from th in db.TransactionHeaders
                    where th.UserID == uID
                    select th).ToList();
        }
        public static TransactionDetail GetTd(int tID)
        {
            return (from td in db.TransactionDetails
                    where td.TransactionID == tID
                    select td).FirstOrDefault();
        }
        public static TransactionHeader GetTh(int uID, int tID)
        {
            return (from th in db.TransactionHeaders
                    where th.UserID == uID && th.TransactionID == tID
                    select th).FirstOrDefault();
        }
        public static List<TransactionDetail> GetTDByStationery(int id)
        {
            return (from td in db.TransactionDetails
                    where td.StationeryID == id
                    select td).ToList();
        }
        public static void DeleteTransactionHeader(int id) 
        {
            TransactionHeader th = db.TransactionHeaders.Find(id);
            db.TransactionHeaders.Remove(th);
            db.SaveChanges();
        }
        public static void DeleteTransactionDetail(TransactionDetail td)
        {
            db.TransactionDetails.Remove(td);
            DeleteTransactionHeader(td.TransactionID);
            db.SaveChanges();
        }
    }
}