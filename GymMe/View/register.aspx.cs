using GymMe.Controller;
using GymMe.Factory;
using GymMe.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace GymMe.View
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           errorLbl.Text = "";
            if(IsPostBack)
            {
                usernameTxt.Attributes["Value"] = usernameTxt.Text;
                emailTxt.Attributes["Value"] = emailTxt.Text;
                genderList.Attributes["Value"] = genderList.SelectedValue;
                passwordTxt.Attributes["Value"] = passwordTxt.Text;
                cpasswordTxt.Attributes["Value"] = cpasswordTxt.Text;
    

            }
        }

        protected void registerBtn_Click(object sender, EventArgs e)
        {
            string username = usernameTxt.Text;
            string email = emailTxt.Text;
            string gender = genderList.SelectedValue;

            string password = passwordTxt.Text;
            string cpassword = cpasswordTxt.Text;

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

            if(email.Equals(""))
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

            Boolean isAlphaNumeric = password.Any(char.IsDigit) && password.Any(char.IsLetter);
            if (!isAlphaNumeric)
            {
                errorLbl.Text = "Password must be alphanumeric";
                return;
            }

            if (cpassword.Equals(""))
            {
                errorLbl.Text = "Please confirm your password";
                return;
            }
            else
            {
                if (!cpassword.Equals(password))
                {
                    errorLbl.Text = "Password doesn't match";
                    return;
                }
            }

            if (string.IsNullOrWhiteSpace(dobTxt.Text))
            {
                errorLbl.Text = "Please input your birth date";
                return;
            }

            DateTime dob;
            if (!DateTime.TryParseExact(dobTxt.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dob))
            {
                errorLbl.Text = "Invalid date format. Please use yyyy-MM-dd. Tried to parse: " + dobTxt.Text;
                return;
            }

            MsUser user = UserFactory.createUser(username, password, email, dob, gender);
            string CheckRegister = UserController.insertUser(user);
            if(user != null)
            {
                errorLbl.Text = CheckRegister;
            }
            
            else
            {
                errorLbl.Text = "Failed To Register";
            }
            return;
        }
    }
}