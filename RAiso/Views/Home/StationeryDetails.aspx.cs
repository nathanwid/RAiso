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
    public partial class StationeryDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["id"];

                MsStationery stationery = StationeryController.CheckStationery(int.Parse(id));

                if (stationery != null)
                {
                    StationeryName.Text = stationery.StationeryName;
                    StationeryPrice.Text = stationery.StationeryPrice.ToString();
                }
                else
                {
                    Response.Redirect("~/Views/Home/Home.aspx");
                }
            }
        }

        protected void BtnAddtoCart_Click(object sender, EventArgs e)
        {
            var user = (MsUser)Session["user"];
            string id = Request.QueryString["id"];

            MsStationery stationery = StationeryController.FindById(int.Parse(id));

            int userId = user.UserID;
            int stationeryId = stationery.StationeryID;
            string quantity = TBQuantity.Text;

            String response = CartController.AddToCart(userId, stationeryId, quantity);

            if(response == "Success")
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