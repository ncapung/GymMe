using GymMe.Controller;
using GymMe.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymMe.View
{
    public partial class InsertSupplement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            errorLbl.Text = "";
        }

        protected void InsertBtn_Click(object sender, EventArgs e)
        {
            MsUser user = (MsUser)Session["MsUser"];
            int UserId = Convert.ToInt32(user.UserID);
            string name = SNameTxt.Text;
            string price = SPriceTxt.Text;
            DateTime exp;
            string typeId = STypeTxt.Text;

            if (string.IsNullOrEmpty(name))
            {
                errorLbl.Text = "Please input supplement name.";
                return;
            }
            else
            {
                if (!name.Contains("supplement"))
                {
                    errorLbl.Text = "Supplement name must contain \'supplement\'.";
                    return;
                }
            }

            if (!DateTime.TryParseExact(SExpTxt.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out exp))
            {
                errorLbl.Text = "Invalid date format. Please use yyyy-MM-dd. Tried to parse: " + SExpTxt.Text;
                return;
            }
            if (exp == null)
            {
                errorLbl.Text = "Please input expiry date.";
                return;
            }
            else
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
            }
            else
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
            SupplementController.insertSupplement(name, exp, Convert.ToInt32(price), Convert.ToInt32(typeId));
            errorLbl.ForeColor = System.Drawing.Color.Green;
            errorLbl.Text = "Insert Success";
        }
    }
}