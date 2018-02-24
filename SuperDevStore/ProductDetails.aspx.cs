using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SuperDevStore
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(Request["id"]);

                Product product = Product.Find(id);

                if (product.active)
                {
                    ProductVisits.Create(id, UserAuth.Instance.User().id);

                    productName.InnerHtml = product.name;
                    productPrice.InnerHtml = string.Format("{0:C}", product.price);

                    if (product.stock > 4)
                    {
                        productAvailable.Style.Value = "color: green;";
                        productAvailable.InnerHtml = "Available";
                    }
                    else if (product.stock > 0)
                    {
                        productAvailable.Style.Value = "color: orange;";
                        productAvailable.InnerHtml = "Few Units";
                    }
                    else
                    {
                        productAvailable.Style.Value = "color: red;";
                        productAvailable.InnerHtml = "Out of Stock";
                    }

                    productDescriprion.InnerHtml = product.description;
                }
                else
                {
                    Response.Redirect("Index.aspx", false);
                }
            }
            catch (Exception error)
            {
                Alerts.errorMessages.Add(error.Message);
            }
        }
    }
}