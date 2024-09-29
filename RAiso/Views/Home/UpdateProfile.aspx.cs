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
    public partial class UpdateProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] != null)
                {
                    MsUser user = (MsUser)Session["user"];
                    string id = user.UserID.ToString();

                    MsUser loggedUser = UserController.GetUserById(int.Parse(id));

                    TBUsername.Text = loggedUser.UserName;
                    if (loggedUser.UserGender.Equals("Male")) RBMale.Checked = true;
                    else if (loggedUser.UserGender.Equals("Female")) RBFemale.Checked = true;
                    DOBButton.Text = loggedUser.UserDOB.ToString("yyyy-MM-dd");
                    TBPhone.Text = loggedUser.UserPhone;
                    TBAddress.Text = loggedUser.UserAddress;
                    TBPassword.Text = loggedUser.UserPassword;
                }
                else
                {
                    Response.Redirect("~/Views/Home/Home.aspx");
                }
            }
        }

        protected void UpdateProfileBtn_Click(object sender, EventArgs e)
        {
            MsUser user = (MsUser)Session["user"];
            int userId = user.UserID;

            string username = TBUsername.Text;
            string password = TBPassword.Text;
            string phone = TBPhone.Text;
            string address = TBAddress.Text;
            string gender = "";
            DateTime dob;

            DateTime.TryParse(DOBButton.Text, out dob);

            if (RBFemale.Checked) gender = "Female";
            else if (RBMale.Checked) gender = "Male";

            String response = UserController.UpdateProfile(userId, username, password, gender, phone, address, dob);

            if (response == "Success")
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