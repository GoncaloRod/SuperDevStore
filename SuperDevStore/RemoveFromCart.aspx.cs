using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SuperDevStore
{
    public partial class RemoveFromCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int index = int.Parse(Request["index"]);

                ShoppingCart.Instance.Products.Remove(ShoppingCart.Instance.Products[index]);

                Alerts.successMessages.Add("Product removed from shopping cart!");

                Response.Redirect("ShoppingCart.aspx", false);
            }
            catch (Exception error)
            {
                Alerts.errorMessages.Add(error.Message);
            }
        }
    }
}