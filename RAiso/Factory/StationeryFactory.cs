using RAiso.Model;
using RAiso.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAiso.Factory
{
    public class StationeryFactory
    {
        public static MsStationery CreateStationery(int id, String name, int price)
        {
            MsStationery stationery = new MsStationery
            {
                StationeryID = id,
                StationeryName = name,
                StationeryPrice = price
            };
            return stationery;
        }
    }
}