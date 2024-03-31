using RAiso.Controller;
using RAiso.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAiso.Views.WebForm.Guest
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null || Request.Cookies["userCookie"] != null)
            {
                Response.Redirect("~/Views/WebForm/Home.aspx");
            }
        }

        protected void registerBtn_Click(object sender, EventArgs e)
        {
            String name = nameTxt.Text;
            String dob = dobTxt.Text;
            String gender = (male.Checked) ? "Male" : (female.Checked) ? "Female" : "";
            String address = addressTxt.Text;
            String password = passwordTxt.Text;
            String phone = phoneTxt.Text;

            registerError.Text = AuthController.ValidateRegister(name, dob, gender, address, password, phone);
            if (registerError.Text.Equals("Success"))
            {
                UserHandler.InsertUser(name, DateTime.Parse(dob), gender, address, password, phone);
                Response.Redirect("~/Views/WebForm/Home.aspx");
            }
        }
    }
}