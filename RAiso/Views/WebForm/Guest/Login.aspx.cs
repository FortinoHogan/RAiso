﻿using RAiso.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAiso.Views.WebForm.Guest
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null || Request.Cookies["userCookie"] != null)
            {
                Response.Redirect("~/Views/WebForm/Home.aspx");
            }
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            String name = nameTxt.Text;
            String password = passwordTxt.Text;

            loginError.Text = AuthController.ValidateLogin(name, password);
            if (loginError.Text.Equals("Success"))
            {
                Session["user"] = name;
                if (rememberCB.Checked)
                {
                    HttpCookie cookie = new HttpCookie("userCookie");
                    cookie.Value = name;
                    cookie.Expires = DateTime.Now.AddHours(1);

                    Response.Cookies.Add(cookie);
                }
                Response.Redirect("~/Views/WebForm/Home.aspx");
            }
        }
    }
}