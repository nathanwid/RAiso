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
    public partial class InsertStationery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] != null)
                {
                    BindStationeryData();
                }
                else
                {
                    Response.Redirect("~/Views/Home/Home.aspx");
                }
            }
        }

        protected void BtnInsertStationery_Click(object sender, EventArgs e)
        {
            string name = TBName.Text;
            string priceStr = TBPrice.Text;

            String response = StationeryController.Insert(name, priceStr);

            if(response == "Success")
            {
                LblError.ForeColor = System.Drawing.Color.Green;
                LblError.Text = "Insert Success";

                TBName.Text = "";
                TBPrice.Text = "";

                BindStationeryData();             
            }
            else
            {
                LblError.ForeColor = System.Drawing.Color.Red;
                LblError.Text = response;
            }
        }

        protected void BindStationeryData()
        {
            GVStationery.DataSource = StationeryController.GetAllStationery();
            GVStationery.DataBind();
        }

        protected void BacktoHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Home/Home.aspx");
        }
    }
}