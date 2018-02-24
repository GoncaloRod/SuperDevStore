using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SuperDevStore
{
    public partial class Checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UserAuth.Instance.Check())
            {
                Alerts.errorMessages.Add("You need to be logged in to checkout!");

                Response.Redirect("Login.aspx", false);
            }

            if (ShoppingCart.Instance.Products.Count() == 0)
            {
                Alerts.errorMessages.Add("You cannot checkout an empty shopping cart!");

                Response.Redirect("Index.aspx", false);
            }

            UpdateDropDowns();
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                string shippingAddress = txtShippingAddress.Text;
                int shippingMethodId = int.Parse(ddShippingMethod.SelectedValue);

                if (shippingAddress == String.Empty)
                {
                    throw new Exception("Shipping Address is required!");
                }

                if (shippingMethodId < 1 || shippingMethodId < ShippingMethod.AllActive().Count)
                {
                    throw new Exception("Choose a valid shipping method!");
                }

                Order.Create(shippingAddress, shippingMethodId, ShoppingCart.Instance.Products);

                Alerts.successMessages.Add("Order placed with success! Check your profile to see order's state.");

                ShoppingCart.Instance.Products.Clear();

                Response.Redirect("Index.aspx", false);
            }
            catch (Exception error)
            {
                Alerts.errorMessages.Add(error.Message);
            }
        }

        private void UpdateDropDowns()
        {
            ddShippingMethod.DataSource = ShippingMethod.AllActiveDataTable();
            ddShippingMethod.DataBind();
            ddShippingMethod.DataTextField = "name";
            ddShippingMethod.DataValueField = "id";
            ddShippingMethod.DataBind();
        }
    }
}