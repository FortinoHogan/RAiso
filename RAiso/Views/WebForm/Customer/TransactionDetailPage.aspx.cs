using RAiso.Controller;
using RAiso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

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

                            List<TransactionDetail> tds = TransactionController.GetAllTd(tID);
                            List<dynamic> tranDetails = new List<dynamic>();
                            foreach (var td in tds)
                            {
                                MsStationery stationery = StationeryController.GetStationeryById(td.StationeryID);
                                tranDetails.Add(new
                                {
                                    StationeryName = stationery.StationeryName,
                                    StationeryPrice = stationery.StationeryPrice,
                                    Quantity = td.Quantity,
                                });
                            }
                            detailGV.DataSource = tranDetails;
                            detailGV.DataBind();
                        }
                    }
                }
                else Response.Redirect("~/Views/WebForm/Home.aspx");
            }
        }

    }
}