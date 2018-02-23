using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SuperDevStore
{
    public partial class AddToCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int productId = int.Parse(Request["id"]);

                ShoppingCart.Instance.AddProduct(Product.Find(productId));

                Response.Redirect(Request["url"], false);
            }
            catch (Exception error)
            {
                Alerts.errorMessages.Add(error.Message);
            }
        }
    }
}