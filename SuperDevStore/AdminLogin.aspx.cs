using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SuperDevStore
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) Alerts.ClearMessages();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Alerts.ClearMessages();

            try
            {
                string email = txtEmailLogin.Text;
                string password = txtPasswordLogin.Text;

                if (!AdminAuth.Instance.Attempt(email, password))
                {
                    Alerts.errorMessages.Add("Login failed!");
                }
                else
                {
                    Alerts.successMessages.Add($"Wellcome back {AdminAuth.Instance.Admin().name}");

                    Response.Redirect("AdminDashboard.aspx");
                }
            }
            catch (Exception error)
            {
                Alerts.errorMessages.Add(error.Message);
            }
        }
    }
}