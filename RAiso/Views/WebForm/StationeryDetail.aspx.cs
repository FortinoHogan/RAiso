using RAiso.Controller;
using RAiso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAiso.Views.WebForm
{
    public partial class StationeryDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] != null)
                {
                    String role = UserController.GetRole(Session["user"].ToString());
                    if (role.Equals("Admin"))
                    {
                        quantityTxt.Visible = false;
                        addToCartBtn.Visible = false;
                    }
                }
                if (Request["ID"] == null)
                {
                    Response.Redirect("~/Views/WebForm/Home.aspx");
                }
                int id = Convert.ToInt32(Request["ID"]);
                MsStationery s = StationeryController.GetStationery(id);

                nameTxt.Text = s.StationeryName;
                priceTxt.Text = s.StationeryPrice.ToString();
            }
        }
    }
}