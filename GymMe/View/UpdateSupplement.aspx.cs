using GymMe.Controller;
using GymMe.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymMe.View
{
    public partial class UpdateSupplement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_Init(object sender, EventArgs e)
        {
            int SuppId = Convert.ToInt32(Request["ID"]);
            MsSupplement supp = SupplementController.getById(SuppId);

            // Set values to textboxes
            errorLbl.Text = "";
            SNameTxt.Text = supp.SupplementName.ToString();
            SPriceTxt.Text = supp.SupplementPrice.ToString();
            SExpTxt.Text = supp.SupplementExpiryDate.ToString("yyyy-MM-dd");
            STypeTxt.Text = supp.SupplementTypeID.ToString();
        }

        protected void BackBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageSupplement.aspx");
        }

        protected void ConfirmBtn_Click(object sender, EventArgs e)
        {
            MsUser user = (MsUser)Session["MsUser"];
            int UserId = Convert.ToInt32(user.UserID);
            int SuppId = Convert.ToInt32(Request["ID"]);
            string name = SNameTxt.Text;
            string price = SPriceTxt.Text;
            DateTime exp;
            if (!DateTime.TryParseExact(SExpTxt.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out exp))
            {
                errorLbl.Text = "Invalid date format. Please use yyyy-MM-dd. Tried to parse: " + SExpTxt.Text;
                return;
            }
            string typeId = STypeTxt.Text;
            int typeIdInt = Convert.ToInt32(STypeTxt.Text);

            if (string.IsNullOrEmpty(name))
            {
                errorLbl.Text = "Please input supplement name.";
                return;
            } else
            {
                if (!name.Contains("supplement")){
                    errorLbl.Text = "Supplement name must contain \'supplement\'.";
                    return;
                }
            }

            if (exp == null)
            {
                errorLbl.Text = "Please input expiry date.";
                return;
            } else
            {
                if (exp < DateTime.Now)
                {
                    errorLbl.Text = "Expiry date must be greater than today.";
                    return;
                }
            }

            if (string.IsNullOrEmpty(price))
            {
                errorLbl.Text = "Please input the supplement price.";
                return;
            } else
            {
                if (Convert.ToInt32(price) < 3000)
                {
                    errorLbl.Text = "Price cannot be lower than 3000.";
                    return;
                }
            }

            if (string.IsNullOrEmpty(typeId))
            {
                errorLbl.Text = "Please input supplement type ID.";
                return;
            }

            int priceInt = Convert.ToInt32(price);
            SupplementController.updateSupplement(SuppId, name, exp, priceInt, typeIdInt);
            Response.Redirect("ManageSupplement.aspx");
        }
    }
}