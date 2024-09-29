using RAiso.Controllers;
using RAiso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Util;

namespace RAiso.Views.Home
{
    public partial class TransactionDetails : System.Web.UI.Page
    {
        protected TransactionHeader transaction = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] != null)
                {
                    string id = Request.QueryString["id"];
                    MsUser user = (MsUser)Session["user"];

                    transaction = TransactionController.CheckTransaction(int.Parse(id));

                    if (user.UserRole == "Admin")
                    {
                        if (transaction != null)
                        {
                            transaction = TransactionController.FindById(int.Parse(id));
                        }
                        else
                        {
                            Response.Redirect("~/Views/Home/TransactionReport.aspx");

                        }
                    }
                    else if (transaction == null || transaction.MsUser.UserID != user.UserID)
                    {
                        Response.Redirect("~/Views/Home/TransactionHistory.aspx");
                    }
                }
                else
                {
                    Response.Redirect("~/Views/Home/Home.aspx");
                }
            }
        }

        protected void BackToHistory_Click(object sender, EventArgs e)
        {
            MsUser user = (MsUser)Session["user"];

            if (user.UserRole == "Customer")
            {
                Response.Redirect("~/Views/Home/TransactionHistory.aspx");
            }
            else
            {
                Response.Redirect("~/Views/Home/TransactionReport.aspx");
            }
        }
    }
}