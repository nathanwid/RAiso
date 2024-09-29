using RAiso.Controllers;
using RAiso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAiso.Views.Home
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindStationeryData();
                if (Session["user"] != null)
                {
                    var user = (MsUser)Session["user"];

                    ShowAdminButton(user);
                }
                else
                {
                    BtnInsert.Visible = false;
                    foreach (RepeaterItem item in RptStationery.Items)
                    {
                        LinkButton btnViewDetails = (LinkButton)item.FindControl("BtnViewDetails");
                        LinkButton btnEdit = (LinkButton)item.FindControl("BtnEdit");
                        LinkButton btnDelete = (LinkButton)item.FindControl("BtnDelete");

                        if (btnViewDetails != null)
                        {
                            btnViewDetails.Visible = true;
                        }
                        if (btnEdit != null)
                        {
                            btnEdit.Visible = false;
                        }
                        if (btnDelete != null)
                        {
                            btnDelete.Visible = false;
                        }
                    }
                }
            }
        }

        private void ShowAdminButton(MsUser user)
        {
            if (RptStationery != null)
            {
                if (user.UserRole == "Admin")
                {
                    BtnInsert.Visible = true;
                    foreach (RepeaterItem item in RptStationery.Items)
                    {
                        LinkButton btnViewDetails = (LinkButton)item.FindControl("BtnViewDetails");
                        LinkButton btnEdit = (LinkButton)item.FindControl("BtnEdit");
                        LinkButton btnDelete = (LinkButton)item.FindControl("BtnDelete");

                        if (btnViewDetails != null)
                        {
                            btnViewDetails.Visible = true;
                        }
                        if (btnEdit != null)
                        {
                            btnEdit.Visible = true;
                        }
                        if (btnDelete != null)
                        {
                            btnDelete.Visible = true;
                        }
                    }
                }
                else
                {
                    BtnInsert.Visible = false;
                    foreach (RepeaterItem item in RptStationery.Items)
                    {
                        LinkButton btnViewDetails = (LinkButton)item.FindControl("BtnViewDetails");
                        LinkButton btnEdit = (LinkButton)item.FindControl("BtnEdit");
                        LinkButton btnDelete = (LinkButton)item.FindControl("BtnDelete");

                        if (btnViewDetails != null)
                        {
                            btnViewDetails.Visible = true;
                        }
                        if (btnEdit != null)
                        {
                            btnEdit.Visible = false;
                        }
                        if (btnDelete != null)
                        {
                            btnDelete.Visible = false;
                        }
                    }
                }
            }
        }

        protected void BindStationeryData()
        {
            List<MsStationery> stationery = StationeryController.GetAllStationery();
            RptStationery.DataSource = stationery;
            RptStationery.DataBind();
        }

        protected void BtnInsert_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Home/InsertStationery.aspx");
        }

        protected void RptStationery_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "ViewDetails")
            {
                string id = e.CommandArgument.ToString();
                Response.Redirect("~/Views/Home/StationeryDetails.aspx?Id=" + id);
            }
            else if (e.CommandName == "Edit")
            {
                string id = e.CommandArgument.ToString();
                Response.Redirect("~/Views/Home/UpdateStationery.aspx?Id=" + id);
            }
            else if (e.CommandName == "Delete")
            {
                string id = e.CommandArgument.ToString();

                StationeryController.DeleteById(int.Parse(id));

                BindStationeryData();
            }
        }
    }
}