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
    public partial class Cart : System.Web.UI.Page
    {
        protected List<Model.Cart> carts = new List<Model.Cart>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] != null)
                {
                    MsUser user = (MsUser)Session["user"];

                    int loggedUser = user.UserID;

                    carts = CartController.GetCarts(loggedUser);

                    BindCartData(carts);
                }
                else
                {
                    Response.Redirect("~/Views/Home/Home.aspx");
                }
            }
        }

        protected void BtnCheckOut_Click(object sender, EventArgs e)
        {
            MsUser user = (MsUser)Session["user"];

            TransactionController.CreateTransaction(user);

            Response.Redirect("~/Views/Home/Home.aspx");
        }

        protected void GVCart_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            MsUser user = (MsUser)Session["user"];
            MsUser loggedUser = UserController.GetUserById(user.UserID);
            int userId = loggedUser.UserID;

            GridViewRow row = GVCart.Rows[e.RowIndex];
            HiddenField stationeryId = (HiddenField)row.FindControl("StationeryID");

            CartController.DeleteCartItem(userId, int.Parse(stationeryId.Value));

            carts = CartController.GetCarts(userId);
            BindCartData(carts);
        }

        protected void BindCartData(List<Model.Cart> cart)
        {
            GVCart.DataSource = cart;
            GVCart.DataBind();
        }
    }
}