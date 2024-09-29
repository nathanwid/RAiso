using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAiso.Views.Account
{
    public partial class AccountMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void NavBtnHome_Click(object sender, EventArgs e)
        {
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