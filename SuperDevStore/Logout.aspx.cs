using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SuperDevStore
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) Alerts.ClearMessages();

            if (!UserAuth.Instance.Check()) Response.Redirect("Index.aspx", false);

            // Call logout method
            UserAuth.Instance.Destroy();

            // Redirect to Homepage
            Response.Redirect("Index.aspx", false);
        }
    }
}