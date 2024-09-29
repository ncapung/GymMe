using GymMe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymMe.View
{
    public partial class HistoryCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MsUser user = (MsUser)Session["MsUser"];
            //int UserId = Convert.ToInt32(Request["ID"]);
            GridView1.DataSourceID = "SqlDataSource1";
            SqlDataSource1.SelectParameters.Clear();
            SqlDataSource1.SelectParameters.Add("userId", user.UserID.ToString());
            SqlDataSource1.SelectCommand = "SELECT TransactionID, TransactionDate FROM TransactionHeader WHERE (TransactionHeader.UserID = @UserId)";
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = GridView1.SelectedIndex;
            int TransId = Convert.ToInt32(GridView1.DataKeys[index].Value);
            Response.Redirect("TransactionDetails.aspx?TID=" + TransId);
        }
    }
}