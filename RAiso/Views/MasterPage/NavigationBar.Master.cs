using RAiso.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAiso.Views.MasterPage
{
    public partial class NavigationBar : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.Cookies["userCookie"] != null)
            {
                Session["user"] = Request.Cookies["userCookie"].Value;
            }
            if (Session["user"] != null)
            {
                String role = UserController.GetRole(Session["user"].ToString());
                loginBtn.Visible = false;
                registerBtn.Visible = false;
                updateProfileBtn.Visible = true;
                logoutBtn.Visible = true;
                if (role.Equals("Admin"))
                {
                    transactionReportBtn.Visible = true;
                }
                else if (role.Equals("Customer"))
                {
                    transactionBtn.Visible = true;
                    cartBtn.Visible = true;
                }
            }
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/WebForm/Guest/Login.aspx");
        }

        protected void registerBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/WebForm/Guest/Register.aspx");
        }

        protected void logoutBtn_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            if (Request.Cookies["userCookie"] != null)
            {
                var cookie = new HttpCookie("userCookie");
                cookie.Expires = DateTime.Now.AddHours(-1);
                Response.Cookies.Add(cookie);
            }
            Response.Redirect("~/Views/WebForm/Home.aspx");
        }

        protected void homeBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/WebForm/Home.aspx");
        }

        protected void updateProfileBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/WebForm/UpdateProfile.aspx");
        }

        protected void cartBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/WebForm/Customer/CartPage.aspx");
        }

        protected void transactionBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/WebForm/Customer/TransactionHistory.aspx");
        }

        protected void transactionReportBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/WebForm/Admin/TransactionReport.aspx");
        }
    }
}