using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SuperDevStore
{
    public partial class AdminLowStockProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            gvProducts.Columns.Clear();
            gvProducts.DataSource = null;
            gvProducts.DataBind();

            DataTable data = Product.LowStockDataTable();

            if (data == null || data.Rows.Count == 0) return;

            // Setup Columns
            // Id
            BoundField bfNProduct = new BoundField();
            bfNProduct.HeaderText = "#";
            bfNProduct.DataField = "id";
            gvProducts.Columns.Add(bfNProduct);

            // Name
            BoundField bfName = new BoundField();
            bfName.HeaderText = "Name";
            bfName.DataField = "name";
            gvProducts.Columns.Add(bfName);

            // Price
            BoundField bfPrice = new BoundField();
            bfPrice.HeaderText = "Price";
            bfPrice.DataField = "price";
            bfPrice.DataFormatString = "{0:C}";
            gvProducts.Columns.Add(bfPrice);

            // Stock
            BoundField bfStock = new BoundField();
            bfStock.HeaderText = "Stock";
            bfStock.DataField = "stock";
            gvProducts.Columns.Add(bfStock);

            gvProducts.DataSource = data;
            gvProducts.AutoGenerateColumns = false;

            // Details Button
            HyperLinkField hlDetails = new HyperLinkField();
            hlDetails.HeaderText = "Actions";
            hlDetails.Text = "Details";
            hlDetails.ControlStyle.CssClass = "btn btn-primary btn-sm";
            hlDetails.DataNavigateUrlFormatString = "AdminProductDetails.aspx?id={0}";
            hlDetails.DataNavigateUrlFields = new string[] { "id" };
            gvProducts.Columns.Add(hlDetails);

            gvProducts.DataBind();
        }
    }
}