using RAiso.Controller;
using RAiso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAiso.Views.WebForm.Customer
{
    public partial class CartPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] != null)
                {
                    String role = UserController.GetRole(Session["user"].ToString());
                    if (!role.Equals("Customer"))
                    {
                        Response.Redirect("~/Views/WebForm/Home.aspx");
                    }
                }
                else
                {
                    Response.Redirect("~/Views/WebForm/Home.aspx");
                }
                BindCart();
                List<Cart> carts = CartController.GetCarts(Convert.ToInt32(Session["user"]));
                if (carts.Count == 0) checkoutBtn.Visible = false;  
            }
        }
        private void BindCart()
        {
            List<Cart> carts = CartController.GetCarts(Convert.ToInt32(Session["user"]));

            List<dynamic> cartDetails = new List<dynamic>();
            foreach (var cart in carts)
            {
                MsStationery stationery = StationeryController.GetStationeryById(cart.StationeryID);
                cartDetails.Add(new
                {
                    StationeryName = stationery.StationeryName,
                    StationeryPrice = stationery.StationeryPrice,
                    Quantity = cart.Quantity,
                });
            }
            cartGV.DataSource = cartDetails;
            cartGV.DataBind();
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            String name = row.Cells[0].Text;

            int uId = Convert.ToInt32(Session["user"]);
            int sId = StationeryController.GetIdByName(name);
            Response.Redirect("~/Views/WebForm/Customer/UpdateCart.aspx?sID=" + sId);
        }

        protected void removeBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            String name = row.Cells[0].Text;

            int uId = Convert.ToInt32(Session["user"]);
            int sId = StationeryController.GetIdByName(name);

            Cart cart = CartController.GetCart(Convert.ToInt32(Session["user"]), sId);
            CartController.RemoveCart(cart);
            BindCart();
        }

        protected void checkoutBtn_Click(object sender, EventArgs e)
        {
            List<Cart> carts = CartController.GetCarts(Convert.ToInt32(Session["user"]));
            CartController.Checkout(carts);
            foreach(Cart c in carts)
            {
                CartController.RemoveCart(c);
            }
            Response.Redirect("~/Views/WebForm/Home.aspx");
        }
    }
}