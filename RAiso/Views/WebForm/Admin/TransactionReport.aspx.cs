using RAiso.Controller;
using RAiso.Dataset;
using RAiso.Model;
using RAiso.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAiso.Views.WebForm.Admin
{
    public partial class TransactionReport : System.Web.UI.Page
    {
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
                    else
                    {
                        BindReport();
                    }
                }
                else
                {
                    Response.Redirect("~/Views/WebForm/Home.aspx");
                }
            }
            else
            {
                BindReport();
            }
        }
        private void BindReport()
        {
            CrystalReport report = new CrystalReport();
            CRViewer.ReportSource = report;
            DataSet data = GetData(TransactionController.GetThReport());
            report.SetDataSource(data);
        }
        private DataSet GetData(List<TransactionHeader> ths)
        {
            DataSet data = new DataSet();
            var headerTable = data.TransactionHeader;
            var detailTable = data.TransactionDetail;

            foreach (TransactionHeader th in ths)
            {
                var hrow = headerTable.NewRow();
                hrow["TransactionID"] = th.TransactionID;
                hrow["UserID"] = th.UserID;
                hrow["TransactionDate"] = th.TransactionDate;
                hrow["GrandTotalValue"] = TransactionController.GetGrandTotal(th.TransactionID);
                headerTable.Rows.Add(hrow);

                foreach (TransactionDetail td in th.TransactionDetails)
                {
                    var drow = detailTable.NewRow();
                    MsStationery s = StationeryController.GetStationeryById(td.StationeryID);

                    drow["TransactionID"] = td.TransactionID;
                    drow["StationeryName"] = s.StationeryName;
                    drow["Quantity"] = td.Quantity;
                    drow["StationeryPrice"] = s.StationeryPrice;
                    drow["SubTotalValue"] = TransactionController.GetSubTotal(s.StationeryPrice, td.Quantity);
                    detailTable.Rows.Add(drow);
                }
            }
            return data;
        }
    }
}