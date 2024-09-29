using GymMe.Controller;
using GymMe.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymMe.View
{
    public partial class OrderSupplement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorLbl.Text = "";
            //GridViewSupplement.DataSource = SupplementController.getAllSupplements();
            //GridViewSupplement.DataBind();
            this.GridViewSupplement.Columns[4].Visible = false;
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cart.aspx");
        }

        protected void GridViewSupplement_SelectedIndexChanged(object sender, EventArgs e)
        {
            MsUser user = (MsUser)Session["MsUser"];
            int index = GridViewSupplement.SelectedIndex;
            int pk = Convert.ToInt32(GridViewSupplement.DataKeys[index].Value);
            MsSupplement supp = SupplementController.getById(pk);
            int suppId = (int)supp.SupplementID;
            TextBox OrderQuantity = (TextBox)GridViewSupplement.Rows[index].FindControl("OrderQuantity");
            int quantity = Convert.ToInt32(OrderQuantity.Text);
            
            if (quantity <= 0)
            {
                ErrorLbl.Text = "Quantity must be more than 0";
                return;
            }

            CartController.insertCart(user.UserID, suppId, quantity);
            Response.Redirect("OrderSupplement.aspx");
        }
    }
}