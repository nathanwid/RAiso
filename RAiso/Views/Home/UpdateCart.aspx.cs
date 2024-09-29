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
    public partial class UpdateCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] != null)
                {
                    string id = Request.QueryString["id"];
                    MsUser user = (MsUser)Session["user"];

                    Model.Cart item = CartController.GetCart(user.UserID ,int.Parse(id));
                    MsStationery stationery = StationeryController.FindById(int.Parse(id));

                    TBStationeryName.Text = stationery.StationeryName;
                    TBQuantity.Text = item.Quantity.ToString();
                }
                else
                {
                    Response.Redirect("~/Views/Home/Home.aspx");
                }
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            MsUser user = (MsUser)Session["user"];

            string id = Request.QueryString["id"];
            string qty = TBQuantity.Text;

            String response = CartController.Update(user.UserID, int.Parse(id), qty);

            if (response == "Success")
            {
                Response.Redirect("~/Views/Home/Cart.aspx");
            }
            else
            {
                LblError.ForeColor = System.Drawing.Color.Red;
                LblError.Text = response;
            }
        }
    }
}