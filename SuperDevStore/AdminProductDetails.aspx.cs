using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SuperDevStore
{
    public partial class AdminProductDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(Request["id"]);

                Product product = Product.Find(id);

                if (product != null)
                {
                    productName.InnerHtml += product.name;
                    productPrice.InnerHtml += product.price;
                    productDescription.InnerHtml += product.description;
                    productStock.InnerHtml += product.stock;
                }
                else
                {
                    throw new Exception("Invalid product!");
                }
            }
            catch (Exception error)
            {
                Alerts.errorMessages.Add(error.Message);

                Response.Redirect("Products.aspx");
            }
        }
    }
}