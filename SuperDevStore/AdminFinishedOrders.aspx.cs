using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SuperDevStore
{
    public partial class AdminFinishedOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!AdminAuth.Instance.Check()) Response.Redirect("Index.aspx");

            if (!IsPostBack) Alerts.ClearMessages();

            UpdateGridView();
        }

        private void UpdateGridView()
        {
            gvOrders.Columns.Clear();
            gvOrders.DataSource = null;
            gvOrders.DataBind();

            DataTable data = Order.AllDoneDataTable();

            if (data == null || data.Rows.Count == 0) return;

            // Setup Columns
            // Id
            BoundField bfNOrder = new BoundField();
            bfNOrder.HeaderText = "#";
            bfNOrder.DataField = "id";
            gvOrders.Columns.Add(bfNOrder);

            // Shipping Address
            BoundField bfShippingAddress = new BoundField();
            bfShippingAddress.HeaderText = "Shippig Address";
            bfShippingAddress.DataField = "shipping_address";
            gvOrders.Columns.Add(bfShippingAddress);

            // Date
            BoundField bfDate = new BoundField();
            bfDate.HeaderText = "Ordered At";
            bfDate.DataField = "date";
            bfDate.DataFormatString = "{0:dd-MM-yyyy}";
            gvOrders.Columns.Add(bfDate);

            gvOrders.DataSource = data;
            gvOrders.AutoGenerateColumns = false;

            // Details Button
            HyperLinkField hlDetails = new HyperLinkField();
            hlDetails.HeaderText = "Actions";
            hlDetails.Text = "Details";
            hlDetails.ControlStyle.CssClass = "btn btn-primary btn-sm";
            hlDetails.DataNavigateUrlFormatString = "AdminOrderDetails.aspx?id={0}";
            hlDetails.DataNavigateUrlFields = new string[] { "id" };
            gvOrders.Columns.Add(hlDetails);

            // Finish Button
            HyperLinkField hlFinish = new HyperLinkField();
            hlFinish.Text = "Unfinish";
            hlFinish.ControlStyle.CssClass = "btn btn-danger btn-sm";
            hlFinish.DataNavigateUrlFormatString = "AdminUnfinishOrder.aspx?id={0}";
            hlFinish.DataNavigateUrlFields = new string[] { "id" };
            gvOrders.Columns.Add(hlFinish);

            gvOrders.DataBind();
        }
    }
}