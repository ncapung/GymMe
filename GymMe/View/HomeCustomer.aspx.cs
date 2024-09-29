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
    public partial class HomeCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request["ID"]);
            MsUser user = UserController.getProfileById(id);
            if (user != null) 
            {
                LoginLbl.Text = "Hi, Customer " + user.UserName;
            }
        }
    }
}