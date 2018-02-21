using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SuperDevStore
{
    public partial class AdminUnfinishOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(Request["id"]);

                Order.UnfinishOrder(id);

                Alerts.successMessages.Add("Order unfinished with success!");
            }
            catch (Exception error)
            {
                Alerts.errorMessages.Add(error.Message);
            }

            Response.Redirect("AdminFinishedOrders.aspx");
        }
    }
}