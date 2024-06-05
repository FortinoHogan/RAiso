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
        public static void InsertTransactionHeader(TransactionHeader th)
        {
            db.TransactionHeaders.Add(th);
            db.SaveChanges();
        }
        public static void InsertTransactionDetail(TransactionDetail td)
        {
            db.TransactionDetails.Add(td);
            db.SaveChanges();
        }
        public static List<TransactionHeader> GetAllTh(int uID)
        {
            return (from th in db.TransactionHeaders
                    where th.UserID == uID
                    select th).ToList();
        }
        public static List<TransactionDetail> GetAllTd(int tID)
        {
            return (from td in db.TransactionDetails
                    where td.TransactionID == tID
                    select td).ToList();
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
        private static Boolean FindTdById(int tID)
        {
            TransactionDetail td = (from t in db.TransactionDetails
                                    where t.TransactionID == tID
                                    select t).FirstOrDefault();
            if (td != null) return true;
            return false;
        }
        public static void DeleteTransactionDetail(TransactionDetail td)
        {
            db.TransactionDetails.Remove(td);
            db.SaveChanges();
            if (FindTdById(td.TransactionID) == false) DeleteTransactionHeader(td.TransactionID);
            db.SaveChanges();
        }
    }
}