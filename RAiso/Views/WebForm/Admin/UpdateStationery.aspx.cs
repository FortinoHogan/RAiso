using RAiso.Controller;
using RAiso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAiso.Views.WebForm.Admin
{
    public partial class UpdateStationery : System.Web.UI.Page
    {
        static String nameFirst;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] != null)
                {
                    String role = UserController.GetRole(Session["user"].ToString());
                    if (!role.Equals("Admin"))
                    {
                        Response.Redirect("~/Views/WebForm/Home.aspx");
                    }
                }
                else
                {
                    Response.Redirect("~/Views/WebForm/Home.aspx");
                }
                if (Request["ID"] == null)
                {
                    Response.Redirect("~/Views/WebForm/Home.aspx");
                }
                int id = Convert.ToInt32(Request["ID"]);
                MsStationery s = StationeryController.GetStationery(id);

                nameFirst = s.StationeryName;

                nameTxt.Text = s.StationeryName;
                priceTxt.Text = s.StationeryPrice.ToString();
            }
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            String name = nameTxt.Text;
            String price = priceTxt.Text;

            errorMsg.Text = StationeryController.ValidateInsert(name, price);
            if (errorMsg.Text.Equals("Success"))
            {
                StationeryController.UpdateStationery(name, Convert.ToInt32(price), nameFirst);
                Response.Redirect("~/Views/WebForm/Home.aspx");
            }
        }
    }
}