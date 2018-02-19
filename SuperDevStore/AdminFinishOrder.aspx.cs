using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SuperDevStore
{
    public partial class AdminFinishOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!AdminAuth.Instance.Check()) Response.Redirect("Index.aspx");

            try
            {
                int id = int.Parse(Request["id"]);

                Order.FinishOrder(id);

                Alerts.successMessages.Add("Order finished with success!");
            }
            catch (Exception error)
            {
                Alerts.errorMessages.Add(error.Message);
            }

            Response.Redirect("AdminOrders.aspx");
        }
    }
}