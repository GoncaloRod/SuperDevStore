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
        }
    }
}