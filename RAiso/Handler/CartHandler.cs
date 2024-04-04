using RAiso.Factory;
using RAiso.Model;
using RAiso.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAiso.Handler
{
    public class CartHandler
    {
        public static List<Cart> GetCarts(int uId)
        {
            return CartRepository.GetAll(uId);
        }
        public static void HandleAddToCart(int uId, int sId, int qty)
        {
            Cart cart = CartFactory.CreateCart(uId, sId, qty);
            CartRepository.AddToCart(cart);
        }
        public static Cart GetCart(int uId, int sId)
        {
            return CartRepository.GetCart(uId, sId);
        }
        public static void HandleUpdate(Cart cart, int qty)
        {
            CartRepository.UpdateCart(cart, qty);
        }
        public static void HandleDelete(Cart cart)
        {
            CartRepository.DeleteCart(cart);
        }
    }
}