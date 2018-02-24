using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SuperDevStore
{
    public partial class AdminEnableProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(Request["id"]);

                Product.Find(id).Enable();

                Response.Redirect(Request["url"], false);
            }
            catch (Exception error)
            {
                Alerts.errorMessages.Add(error.Message);
            }
        }
    }
}