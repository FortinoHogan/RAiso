using RAiso.Handler;
using RAiso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAiso.Controller
{
    public class StationeryController
    {
        public static List<MsStationery> GetStationeries()
        {
            return StationeryHandler.GetStationeries();
        }
        public static MsStationery GetStationery(int id)
        {
            return StationeryHandler.GetStationery(id);
        }
    }
}