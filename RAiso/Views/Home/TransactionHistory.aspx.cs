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
    public partial class TransactionHistory : System.Web.UI.Page
    {
        protected List<TransactionHeader> transactions = new List<TransactionHeader>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] != null)
                {
                    MsUser user = (MsUser)Session["user"];

                    int loggedUser = user.UserID;

                    transactions = TransactionController.GetTransactionsByUser(loggedUser);

                    GVTransaction.DataSource = transactions;
                    GVTransaction.DataBind();
                }
                else
                {
                    Response.Redirect("~/Views/Home/Home.aspx");
                }
            }
        }
    }
}