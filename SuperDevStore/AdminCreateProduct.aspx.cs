using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SuperDevStore
{
    public partial class AdminCreateProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreate_Click(object sender, EventArgs e)
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

                Product.Crate(name, price, description, stock);

                Alerts.successMessages.Add("Product created with success!");

                Response.Redirect("AdminProducts.aspx");
            }
            catch (Exception error)
            {
                Alerts.errorMessages.Add(error.Message);
            }
        }
    }
}