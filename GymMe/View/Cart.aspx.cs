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
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MsUser user = (MsUser)Session["MsUser"];
            GridView1.DataSourceID = "SqlDataSource1";
            SqlDataSource1.SelectParameters.Clear();
            SqlDataSource1.SelectParameters.Add("userId", user.UserID.ToString());
            SqlDataSource1.SelectCommand = "SELECT MsSupplement.SupplementID, MsSupplement.SupplementName, MsSupplement.SupplementPrice, MsSupplement.SupplementExpiryDate, MsSupplementType.SupplementTypeName, MsCart.Quantity FROM MsCart INNER JOIN MsSupplement ON MsSupplement.SupplementID = MsCart.SupplementID INNER JOIN MsSupplementType ON MsSupplement.SupplementTypeID = MsSupplementType.SupplementTypeID INNER JOIN MsUser ON MsUser.UserID = MsCart.UserID WHERE (MsCart.UserID = @userId)";

        }

        protected void ClearCartBtn_Click(object sender, EventArgs e)
        {
            MsUser user = (MsUser)Session["MsUser"];
            CartController.clearCart(user.UserID);
        }

        protected void CheckoutBtn_Click(object sender, EventArgs e)
        {
            MsUser user = (MsUser)Session["MsUser"];
            TransactionController.insertTransaction(user.UserID);
            CartController.clearCart(user.UserID);
        }
    }
}