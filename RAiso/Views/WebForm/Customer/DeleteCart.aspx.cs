using RAiso.Controller;
using RAiso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAiso.Views.WebForm.Customer
{
    public partial class DeleteCart : System.Web.UI.Page
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
                if (Request["sId"] == null)
                {
                    Response.Redirect("~/Views/WebForm/Home.aspx");
                }
                int sId = Convert.ToInt32(Request["sId"]);
                Cart cart = CartController.GetCart(Convert.ToInt32(Session["user"]), sId);
                CartController.RemoveCart(cart);
                Response.Redirect("~/Views/WebForm/Customer/CartPage.aspx");
            }
        }
    }
}