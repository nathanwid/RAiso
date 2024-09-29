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
    public partial class TransactionReport : System.Web.UI.Page
    {
        protected List<TransactionHeader> transactions = new List<TransactionHeader>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] != null)
                {
                    transactions = TransactionController.GetTransactions();
                }
                else
                {
                    Response.Redirect("~/Views/Home/Home.aspx");
                }
            }
        }
    }
}