using GymMe.Controller;
using GymMe.Model;
using GymMe.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymMe.View
{
    public partial class loginForm : System.Web.UI.Page
    {
        private GymMe_DatabaseEntities8 db = Singleton.createSingleton();
        protected void Page_Load(object sender, EventArgs e)
        {
            errorLbl.Text = "";
           if(!IsPostBack)
            {
                if (Request.Cookies["User-Cred"] != null)
                {
                    int id = Convert.ToInt32(Request.Cookies["User-Cred"]["id"]);
                    Session["MsUser"] = UserController.getProfileById(id);
                    Response.Redirect("Home.aspx");
                }

            }
                var UserObj = (MsUser)Session["MsUser"];
                if (UserObj != null)
                {
                    string role = UserObj.UserRole;
                    if(role.Equals("Admin"))
                    {
                        Response.Redirect("Home.aspx");
                    }
                    else if(role.Equals("Customer"))
                    {
                        Response.Redirect("HomeCustomer.aspx?ID="+ UserObj.UserID);
                    }
                }
        }
        
        protected void loginBtn_Click(object sender, EventArgs e)
        {
             
            String UserName = usernameTxt.Text; 
            String UserPassword = passwordTxt.Text;
            MsUser msUser = (from x in db.MsUsers where x.UserName.Equals(UserName) select x).FirstOrDefault();

            if(string.IsNullOrWhiteSpace(UserName) || string.IsNullOrWhiteSpace(UserPassword))
            {
                errorLbl.Text = "Must be filled and appropriate with the data in the database and cannot be empty. ";
                return;
            }
            else if (msUser != null && UserPassword != msUser.UserPassword)
            {
                errorLbl.Text = "Incorrect Password";
                return;
            }
            

            if(msUser == null)
            {
                errorLbl.Text = "Incorrect username and password";
                return;
            }

            Session["MsUser"] = msUser;
            
            

            if(CB.Checked)
            {
                HttpCookie cookie = new HttpCookie("User-Cred");
                cookie["id"] = msUser.UserID.ToString();
                cookie.Expires = DateTime.Now.AddHours(1);
                Response.Cookies.Add(cookie);   
            }

            if (msUser.UserRole.Equals("Admin"))
            {
                Response.Redirect("Home.aspx");
            }
            else if(msUser.UserRole.Equals("Customer"))
            {
                Response.Redirect("HomeCustomer.aspx");
            }

        }
    }
}