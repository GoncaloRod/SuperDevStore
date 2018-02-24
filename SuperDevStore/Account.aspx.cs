using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SuperDevStore
{
    public partial class Account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UserAuth.Instance.Check()) Response.Redirect("Index.aspx");

            UpdatePendingOrdersGV();
            UpdateFinishedOrdersGV();
        }

        private void UpdatePendingOrdersGV()
        {
            gvPendingOrders.Columns.Clear();
            gvPendingOrders.DataSource = null;
            gvPendingOrders.DataBind();

            DataTable data = UserAuth.Instance.User().PendingOrdersDB();

            if (data == null || data.Rows.Count == 0) return;

            // Setup Columns
            // Id
            BoundField bfNOrder = new BoundField();
            bfNOrder.HeaderText = "#";
            bfNOrder.DataField = "id";
            gvPendingOrders.Columns.Add(bfNOrder);

            // Shipping Address
            BoundField bfShippingAddress = new BoundField();
            bfShippingAddress.HeaderText = "Shippig Address";
            bfShippingAddress.DataField = "shipping_address";
            gvPendingOrders.Columns.Add(bfShippingAddress);

            // Date
            BoundField bfDate = new BoundField();
            bfDate.HeaderText = "Ordered At";
            bfDate.DataField = "date";
            bfDate.DataFormatString = "{0:dd-MM-yyyy}";
            gvPendingOrders.Columns.Add(bfDate);

            gvPendingOrders.DataSource = data;
            gvPendingOrders.AutoGenerateColumns = false;

            // Details Button
            HyperLinkField hlDetails = new HyperLinkField();
            hlDetails.HeaderText = "Actions";
            hlDetails.Text = "Details";
            hlDetails.ControlStyle.CssClass = "btn btn-primary btn-sm";
            hlDetails.DataNavigateUrlFormatString = "OrderDetails.aspx?id={0}";
            hlDetails.DataNavigateUrlFields = new string[] { "id" };
            gvPendingOrders.Columns.Add(hlDetails);

            gvPendingOrders.DataBind();
        }

        private void UpdateFinishedOrdersGV()
        {
            gvFinishedOrders.Columns.Clear();
            gvFinishedOrders.DataSource = null;
            gvFinishedOrders.DataBind();

            DataTable data = Order.AllDoneDataTable();

            if (data == null || data.Rows.Count == 0) return;

            // Setup Columns
            // Id
            BoundField bfNOrder = new BoundField();
            bfNOrder.HeaderText = "Order Number";
            bfNOrder.DataField = "id";
            gvFinishedOrders.Columns.Add(bfNOrder);

            // Shipping Address
            BoundField bfShippingAddress = new BoundField();
            bfShippingAddress.HeaderText = "Shippig Address";
            bfShippingAddress.DataField = "shipping_address";
            gvFinishedOrders.Columns.Add(bfShippingAddress);

            // Date
            BoundField bfDate = new BoundField();
            bfDate.HeaderText = "Ordered At";
            bfDate.DataField = "date";
            bfDate.DataFormatString = "{0:dd-MM-yyyy}";
            gvFinishedOrders.Columns.Add(bfDate);

            gvFinishedOrders.DataSource = data;
            gvFinishedOrders.AutoGenerateColumns = false;

            // Details Button
            HyperLinkField hlDetails = new HyperLinkField();
            hlDetails.HeaderText = "Actions";
            hlDetails.Text = "Details";
            hlDetails.ControlStyle.CssClass = "btn btn-primary btn-sm";
            hlDetails.DataNavigateUrlFormatString = "OrderDetails.aspx?id={0}";
            hlDetails.DataNavigateUrlFields = new string[] { "id" };
            gvFinishedOrders.Columns.Add(hlDetails);

            gvFinishedOrders.DataBind();
        }
    }
}