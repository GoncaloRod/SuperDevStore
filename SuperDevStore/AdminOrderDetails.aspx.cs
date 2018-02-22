using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SuperDevStore
{
    public partial class AdminOrderDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(Request["id"]);

                Order order = Order.Find(id);

                if (order != null)
                {
                    // Order's info
                    buyersName.InnerText += order.User().name;
                    shippingAddress.InnerText += order.shipping_address;
                    shippingMethod.InnerText += order.ShippingMethod().name;
                    orderedAt.InnerText += order.date.ToShortDateString();

                    // Order's details
                    gvDatails.Columns.Clear();
                    gvDatails.DataSource = null;
                    gvDatails.DataBind();

                    DataTable details = order.DetailsDataTable();

                    // Setup columns
                    // Product Name
                    BoundField bfProductName = new BoundField();
                    bfProductName.HeaderText = "Product";
                    bfProductName.DataField = "product_name";
                    gvDatails.Columns.Add(bfProductName);

                    // Quantity
                    BoundField bfQuantity = new BoundField();
                    bfQuantity.HeaderText = "Quantity";
                    bfQuantity.DataField = "quantity";
                    gvDatails.Columns.Add(bfQuantity);

                    // Unit Price
                    BoundField bfUnitPrice = new BoundField();
                    bfUnitPrice.HeaderText = "Unit Price";
                    bfUnitPrice.DataField = "unit_price";
                    gvDatails.Columns.Add(bfUnitPrice);

                    gvDatails.DataSource = details;
                    gvDatails.AutoGenerateColumns = false;
                    gvDatails.DataBind();
                }
                else
                {
                    throw new Exception("Invalid order!");
                }
            }
            catch (Exception error)
            {
                Alerts.errorMessages.Add(error.Message);

                Response.Redirect("Orders.aspx", false);
            }
        }
    }
}