using GymMe.Controller;
using GymMe.Factory;
using GymMe.Model;
using GymMe.Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymMe.View
{
    public partial class ProfileCustomer : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            MsUser user = (MsUser)Session["MsUser"];
            DateTime dob = user.UserDOB;
            errorLbl1.Text = "";
            // Set values to textboxes
            errorLbl.Text = "";
            UsernameTxt.Text = user.UserName;
            EmailTxt.Text = user.UserEmail;
            genderList.SelectedValue = user.UserGender;
            DOBTxt.Text = user.UserDOB.ToString("yyyy-MM-dd");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            errorLbl.ForeColor = System.Drawing.Color.Red;
            MsUser user = (MsUser)Session["MsUser"];
            string username = UsernameTxt.Text;
            string email = EmailTxt.Text;
            string gender = genderList.SelectedValue;

            if (username.Equals(""))
            {
                errorLbl.Text = "Please input username";
                return;
            }
            else
            {
                if (username.Length < 5 || username.Length > 15)
                {
                    errorLbl.Text = "username length must between 5 and 15 characters";
                    return;
                }
            }

            if (email.Equals(""))
            {
                errorLbl.Text = "Please input your email";
                return;
            }
            else
            {
                if (!email.EndsWith(".com"))
                {
                    errorLbl.Text = "Must End With \".com\" ";
                    return;
                }
            }

            if (gender.Equals(""))
            {
                errorLbl.Text = "Please select your gender";
                return;
            }

            if (string.IsNullOrWhiteSpace(DOBTxt.Text))
            {
                errorLbl.Text = "Please input your birth date";
                return;
            }

            DateTime dob;
            if (!DateTime.TryParseExact(DOBTxt.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dob))
            {
                errorLbl.Text = "Invalid date format. Please use yyyy-MM-dd. Tried to parse: " + DOBTxt.Text;
                return;
            }

            UserController.updateProfile(user.UserID, username, email, gender, dob);
            errorLbl.Text = "Profile Updated";
            errorLbl.ForeColor = System.Drawing.Color.Green;
        }

        protected void UpdatePwdBtn_Click(object sender, EventArgs e)
        {
            string oldPassword = opasswordTxt.Text;
            string newPassword = npasswordTxt.Text;
            MsUser user = (MsUser)Session["MsUser"];
            Boolean message = UserController.updateUserPassword(oldPassword, newPassword, user.UserID);
            if (message)
            {
                errorLbl1.Text = "Password Updated";
                errorLbl1.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                errorLbl1.Text = "Failed to Update Password";
                errorLbl1.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}