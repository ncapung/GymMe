using GymMe.Controller;
using GymMe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymMe.View
{
    public partial class Header_Customer : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MsUser"] == null)
            {
                if (Request.Cookies["User-Cred"] != null)
                {
                    int id = Convert.ToInt32(Request.Cookies["User-Cred"]["id"]);
                    Session["MsUser"] = UserController.getProfileById(id);
                }
                if (Request.Cookies["User-Cred"] == null)
                {
                    Response.Redirect("loginForm.aspx");
                }
            }
            var UserObj = (MsUser)Session["MsUser"];
            if (UserObj != null)
            {
                string role = UserObj.UserRole;
                if (role.Equals("Admin"))
                {
                    Response.Redirect("Home.aspx");
                }else if(role.Equals("Customer"))
                {
                    Response.Redirect("HomeCustomer.aspx?ID=" + UserObj.UserID);
                }
            }
        }

        protected void OrderBtn_Click(object sender, EventArgs e)
        { 
            Response.Redirect("OrderSupplement.aspx");
        }

        protected void HistoryBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("HistoryCustomer.aspx");
        }

        protected void ProfileBtn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request["ID"]);
            Response.Redirect("ProfileCustomer.aspx");
        }

        protected void LogOutBtn_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            HttpCookie SessionCookie = Request.Cookies["ASP.NET_SessionId"];
            if (SessionCookie != null)
            {
                SessionCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(SessionCookie);
            }
            if (Request.Cookies["User-Cred"] != null)
            {
                HttpCookie cookie = new HttpCookie("User-Cred");
                cookie.Expires = DateTime.Now.AddHours(-1);
                Response.Cookies.Add(cookie);

            }
            Response.Redirect("loginForm.aspx");
        }

    }
}