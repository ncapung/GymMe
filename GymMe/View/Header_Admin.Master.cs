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
    public partial class Header_Admin : System.Web.UI.MasterPage
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
                if (role.Equals("Customer"))
                {
                    Response.Redirect("HomeCustomer.aspx?ID=" + UserObj.UserID);
                }
            }

        }

        protected void HomeBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void ManageBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageSupplement.aspx");
        }

        protected void OrderQueueBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrderQueue.aspx");
        }

        protected void ProfileBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProfileAdmin.aspx");
        }

        protected void TransactionBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("TransactionReport.aspx");
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