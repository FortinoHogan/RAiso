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
                if (Session["user"] != null)
                {
                    String role = UserController.GetRole(Session["user"].ToString());
                    if (role.Equals("Admin"))
                    {
                        stationeryGV.Columns[3].Visible = true;
                        insertBtn.Visible = true;
                    }
                }
                BindStationery();
            }
        }
        private void BindStationery()
        {
            stationeryGV.DataSource = StationeryController.GetStationeries();
            stationeryGV.DataBind();
        }

        protected void stationeryGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = stationeryGV.Rows[e.RowIndex];
            String id = StationeryController.GetIdByName(row.Cells[0].Text).ToString();

            StationeryController.DeleteStationery(Convert.ToInt32(id));
            BindStationery();
        }

        protected void stationeryGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = stationeryGV.SelectedRow;
            String id = StationeryController.GetIdByName(row.Cells[0].Text).ToString();

            Response.Redirect("~/Views/WebForm/StationeryDetail.aspx?ID=" + id);
        }

        protected void insertBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/WebForm/Admin/InsertStationery.aspx");
        }

        protected void stationeryGV_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = stationeryGV.Rows[e.NewEditIndex];
            String id = StationeryController.GetIdByName(row.Cells[0].Text).ToString();

            Response.Redirect("~/Views/WebForm/Admin/UpdateStationery.aspx?ID=" + id);
            BindStationery();
        }
    }
}