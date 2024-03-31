using RAiso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAiso.Repository
{
    public class StationeryRepository
    {
        static DatabaseEntities db = DatabaseSingleton.GetInstance();
        public static List<MsStationery> GetAll()
        {
            return (db.MsStationeries).ToList();
        }
        public static MsStationery GetStationery(String name)
        {
            return (from s in  db.MsStationeries
                    where s.StationeryName == name
                    select s).FirstOrDefault();
        }
        public static MsStationery FindStationery(int id) 
        { 
            return db.MsStationeries.Find(id);
        }
    }
}