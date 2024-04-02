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
        public static String ValidateAddToCart(String inp)
        {
            String res = "";
            if (inp.Equals("")) res = "Quantity must be filled";
            else if (Convert.ToInt32(inp) <= 0) res = "Quantity must be more than 0";
            return res;
        }
        public static String CheckName(String name)
        {
            String res = "";
            if (name.Equals("")) res = "Name must be filled";
            else if (name.Length < 3 || name.Length > 50) res = "Name must be between 3-50 characters";
            return res;
        }
        public static String CheckPrice(String price)
        {
            String res = "";
            if (price.Equals("")) res = "Price must be filled";
            else if (Convert.ToInt32(price)< 2000) res = "Price must be greater than or equal to 2000";
            return res;
        }
        public static String ValidateInsert(String name, String price)
        {
            String res = CheckName(name);
            if (res.Equals("")) res = CheckPrice(price);
            if (res.Equals("")) res = "Success";
            return res;
        }
        public static void InsertStationery(String name, int price)
        {
            StationeryHandler.HandleInsert(name, price);
        }
        public static void UpdateStationery(String name, int price, String nameFirst)
        {
            StationeryHandler.HandleUpdate(name, price, nameFirst);
        }
    }
}