using RAiso.Controller;
using RAiso.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAiso.Views.WebForm
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindStationery();
                if (Session["user"]!=null)
                {
                    String role = UserController.GetRole(Session["user"].ToString());
                    if (role.Equals("Admin"))
                    {
                        stationeryGV.Columns[3].Visible = true;
                    }
                }
            }
        }
        private void BindStationery()
        {
            stationeryGV.DataSource = StationeryController.GetStationeries();
            stationeryGV.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void stationeryGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void stationeryGV_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void stationeryGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = stationeryGV.SelectedRow;
            String id = StationeryHandler.GetIdByName(row.Cells[0].Text).ToString();

            Response.Redirect("~/Views/WebForm/StationeryDetail.aspx?ID=" + id);
        }
    }
}