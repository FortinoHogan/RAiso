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
    public partial class TransactionDetailPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] != null)
                {
                    String role = UserController.GetRole(Session["user"].ToString());
                    if (!role.Equals("Customer")) Response.Redirect("~/Views/WebForm/Home.aspx");
                    else
                    {
                        if (Request["ID"] == null) Response.Redirect("~/Views/WebForm/Home.aspx");
                        else
                        {
                            int uID = Convert.ToInt32(Session["user"]);
                            int tID = Convert.ToInt32(Request["ID"]);
                            TransactionHeader th = TransactionController.GetTh(uID, tID);
                            if (th == null) Response.Redirect("~/Views/WebForm/Home.aspx");

                            TransactionDetail td = TransactionController.GetTd(tID);
                            nameTxt.Text = td.MsStationery.StationeryName;
                            priceTxt.Text = td.MsStationery.StationeryPrice.ToString();
                            quantityTxt.Text = td.Quantity.ToString();
                        }
                    }
                }
                else Response.Redirect("~/Views/WebForm/Home.aspx");
            }
        }

    }
}