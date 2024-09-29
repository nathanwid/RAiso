using RAiso.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAiso.Views.Account
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            string username = TBUsername.Text;
            string password = TBPassword.Text;
            string phone = TBPhone.Text;
            string address = TBAddress.Text;
            string role = "Customer";
            string gender = "";
            DateTime dob;

            DateTime.TryParse(DOBButton.Value, out dob);

            if (RBFemale.Checked) gender = "Female";
            else if (RBMale.Checked) gender = "Male";

            String response = UserController.Register(username, password, gender, phone, address, role, dob);

            if (response == "Success")
            {
                Response.Redirect("~/Views/Account/Login.aspx");
            }
            else
            {
                LblError.ForeColor = System.Drawing.Color.Red;
                LblError.Text = response;
            }
        }
    }
}