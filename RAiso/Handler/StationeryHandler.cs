using RAiso.Model;
using RAiso.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAiso.Handler
{
    public class StationeryHandler
    {
        public static List<MsStationery> GetStationeries()
        {
            return StationeryRepository.GetAll();
        }
        public static int GetIdByName(String name)
        {
            MsStationery s = StationeryRepository.GetStationery(name);
            return s.StationeryID;
        }
        public static MsStationery GetStationery(int id) 
        {
            return StationeryRepository.FindStationery(id);
        }
    }
}