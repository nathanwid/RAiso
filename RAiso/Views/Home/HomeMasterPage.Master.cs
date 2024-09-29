using RAiso.Controllers;
using RAiso.Model;
using RAiso.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAiso.Views.Home
{
    public partial class HomeMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null && Request.Cookies["user_cookie"] == null)
            {
                NavBarGuest();
            }
            else
            {
                MsUser user;
                if (Session["user"] == null)
                {
                    var userCookie = Request.Cookies["user_cookie"];
                    if (userCookie != null && int.TryParse(userCookie.Value, out int userId))
                    {
                        user = UserController.GetUserById(userId);
                        if (user != null)
                        {
                            Session["user"] = user;
                        }
                        else
                        {
                            // Handle the case where the user is not found in the database
                            NavBarGuest();
                            return;
                        }
                    }
                    else
                    {
                        // Handle the case where the cookie value is not a valid integer
                        NavBarGuest();
                        return;
                    }
                }
            }

            if (!IsPostBack)
            {
                if (Session["user"] != null)
                {
                    var user = (MsUser)Session["user"];
                    NavBarUser(user);
                }
            }
        }

        private void NavBarGuest()
        {
            NavBtnHome.Visible = true;
            NavBtnCart.Visible = false;
            NavBtnTransaction.Visible = false;
            NavBtnUpdateProfile.Visible = false;
            NavBtnLogout.Visible = false;
            NavBtnLogin.Visible = true;
            NavBtnRegister.Visible = true;
            NavBtnTransactionReport.Visible = false;
        }

        private void NavBarUser(MsUser user)
        {
            if (user.UserRole == "Admin")
            {
                NavBtnCart.Visible = false;
                NavBtnTransaction.Visible = false;
                NavBtnTransactionReport.Visible = true;
            }
            else if (user.UserRole == "Customer")
            {
                NavBtnCart.Visible = true;
                NavBtnTransaction.Visible = true;
                NavBtnTransactionReport.Visible = false;
            }
            NavBtnHome.Visible = true;
            NavBtnUpdateProfile.Visible = true;
            NavBtnLogout.Visible = true;
            NavBtnLogin.Visible = false;
            NavBtnRegister.Visible = false;
        }

        protected void NavBtnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Home/Home.aspx");
        }

        protected void NavBtnCart_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Home/Cart.aspx");
        }

        protected void NavBtnTransaction_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Home/TransactionHistory.aspx");
        }

        protected void NavBtnTransactionReport_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Home/TransactionReport.aspx");
        }

        protected void NavBtnUpdateProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Home/UpdateProfile.aspx");
        }

        protected void NavBtnLogout_Click(object sender, EventArgs e)
        {
            Session.Remove("user");
            Response.Cookies["user_cookie"].Expires = DateTime.Now.AddDays(-1);

            Response.Redirect("~/Views/Home/Home.aspx");
        }

        protected void NavBtnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Account/Login.aspx");
        }

        protected void NavBtnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Account/Register.aspx");
        }
    }
}