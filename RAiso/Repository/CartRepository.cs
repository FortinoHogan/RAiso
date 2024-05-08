using RAiso.Handler;
using RAiso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAiso.Repository
{
    public class CartRepository
    {
        static DatabaseEntities db = DatabaseSingleton.GetInstance();
        public static List<Cart> GetAll(int uId)
        {
            return (from c in db.Carts
                    where c.UserID == uId
                    select c).ToList();
        }
        public static void AddToCart(Cart cart)
        {
            db.Carts.Add(cart);
            db.SaveChanges();
        }
        public static Cart GetCart(int uId, int sId)
        {
            return (from c in db.Carts
                    where c.UserID == uId &&
                    c.StationeryID == sId
                    select c).ToList().FirstOrDefault();
        }
        public static void UpdateCart(Cart cart, int qty) 
        {
            cart.Quantity = qty;
            db.SaveChanges();
        }
        public static void DeleteCart(Cart cart)
        {
            db.Carts.Remove(cart);
            db.SaveChanges();
        }
        public static List<Cart> GetCartByStationery(int id) 
        {
            return (from c in db.Carts
                    where c.StationeryID == id
                    select c).ToList();
        }
    }
}