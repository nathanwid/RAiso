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
    public partial class UpdateStationery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] != null)
                {
                    string id = Request.QueryString["id"];

                    MsStationery stationery = StationeryController.CheckStationery(int.Parse(id));

                    if (stationery != null)
                    {
                        TBStationeryName.Text = stationery.StationeryName;
                        TBPrice.Text = stationery.StationeryPrice.ToString();
                    }
                    else
                    {
                        Response.Redirect("~/Views/Home/Home.aspx");
                    }
                }
                else
                {
                    Response.Redirect("~/Views/Home/Home.aspx");
                }
            }    
        }

        protected void UpdateStationeryBtn_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            string name = TBStationeryName.Text;
            string priceStr = TBPrice.Text;

            String response = StationeryController.UpdateStationery(int.Parse(id), name, priceStr);
            if (response == "Success")
            {
                Response.Redirect("~/Views/Home/Home.aspx");
            }
            else
            {
                LblError.ForeColor = System.Drawing.Color.Red;
                LblError.Text = response;
            }
        }
    }
}