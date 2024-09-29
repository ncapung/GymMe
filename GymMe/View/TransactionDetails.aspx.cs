using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymMe.View
{
    public partial class TransactionDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int transId = Convert.ToInt32(Request["TID"]);
            TransactionID.Text = "Transaction Details - " + transId;
            GridView1.DataSourceID = "SqlDataSource1";
            SqlDataSource1.SelectParameters.Clear();
            SqlDataSource1.SelectParameters.Add("TransId", transId.ToString());
            SqlDataSource1.SelectCommand = "SELECT MsSupplement.SupplementName, MsSupplement.SupplementExpiryDate, MsSupplement.SupplementPrice, TransactionDetails.Quantity, TransactionHeader.TransactionDate, TransactionHeader.Status FROM TransactionDetails INNER JOIN TransactionHeader ON TransactionDetails.TransactionID = TransactionHeader.TransactionID INNER JOIN MsSupplement ON TransactionDetails.SupplementID = MsSupplement.SupplementID WHERE (TransactionDetails.TransactionID = @TransId)";
        }

        protected void BackBtn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request["ID"]);
            int transId = Convert.ToInt32(Request["TID"]);
            Response.Redirect("HistoryCustomer.aspx?ID=" + id);
        }
    }
}