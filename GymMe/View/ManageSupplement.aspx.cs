using GymMe.Controller;
using GymMe.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymMe.View
{
    public partial class ManageSupplement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            gridViewDataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells[0].Text);
            CartController.deleteBySuppID(id);
            TransactionController.deleteBySuppID(id);
            SupplementController.deleteSupplement(id);
            gridViewDataBind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.NewEditIndex];
            int id = Convert.ToInt32(row.Cells[0].Text);
            Response.Redirect("UpdateSupplement.aspx?ID=" + id);
        }

        private void gridViewDataBind()
        {
            var getAllSupplement = SupplementController.getAllSupplements();
            var getAlltypes = SupplementController.getAllSupplementTypes();
            var joinSupplement = (from supplement in getAllSupplement
                                  join type in getAlltypes on supplement.SupplementTypeID equals type.SupplementTypeID
                                  select new
                                  {
                                      supplement.SupplementID,
                                      supplement.SupplementName,
                                      supplement.SupplementExpiryDate,
                                      supplement.SupplementPrice,
                                      type.SupplementTypeName
                                  }
            );

                                  
            GridView1.DataSource = joinSupplement.ToList();
            GridView1.DataBind();
        }

        protected void InsertBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertSupplement.aspx");
        }
    }
}