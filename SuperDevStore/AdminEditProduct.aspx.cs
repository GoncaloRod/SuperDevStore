using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SuperDevStore
{
    public partial class AdminEditProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            try
            {
                int id = int.Parse(Request["id"]);

                Product product = Product.Find(id);
                
                if (product != null)
                {
                    txtName.Text = product.name;
                    txtPrice.Text = product.price.ToString();
                    txtDescription.Text = product.description;
                    txtStock.Text = product.stock.ToString();
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;
                double price = double.Parse(txtPrice.Text);
                string description = txtDescription.Text;
                int stock = int.Parse(txtStock.Text);

                if (name == String.Empty)
                {
                    throw new Exception("Name is required!");
                }

                if (description == String.Empty)
                {
                    throw new Exception("Description is required!");
                }

                Product.Find(int.Parse(Request["id"])).Update(name, price, description, stock);

                Alerts.successMessages.Add("Product updated with success!");

                Response.Redirect($"AdminProductDetails.aspx?id={Request["id"]}");
            }
            catch (Exception error)
            {
                Alerts.errorMessages.Add(error.Message);
            }
        }
    }
}