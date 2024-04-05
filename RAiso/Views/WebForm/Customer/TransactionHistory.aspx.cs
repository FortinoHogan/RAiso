using RAiso.Controller;
using RAiso.Model;
using RAiso.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAiso.Views.WebForm.Customer
{
    public partial class TransactionHistory : System.Web.UI.Page
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
                BindTransaction();
            }
        }
        private void BindTransaction()
        {
            List<TransactionHeader> tHs = TransactionController.GetAllTh(Convert.ToInt32(Session["user"]));
            List<dynamic> tr = new List<dynamic>();
            foreach (var th in tHs)
            {
                MsUser user = UserRepository.GetUserById((Session["user"]).ToString());
                tr.Add(new
                {
                    TransactionID = th.TransactionID,
                    TransactionDate = th.TransactionDate.ToShortDateString(),
                    UserName = user.UserName,
                });
            }
            transactionGV.DataSource = tr;
            transactionGV.DataBind();
        }

        protected void viewDetailBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            String id = row.Cells[0].Text;

            Response.Redirect("~/Views/WebForm/Customer/TransactionDetailPage.aspx?ID=" + id);
        }
    }
}