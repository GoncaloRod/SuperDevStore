﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SuperDevStore
{
    public partial class AdminLogout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!AdminAuth.Instance.Check()) Response.Redirect("Index.aspx");

            AdminAuth.Instance.Destroy();

            Response.Redirect("Index.aspx");
        }
    }
}