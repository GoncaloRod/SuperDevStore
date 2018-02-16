using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SuperDevStore
{
    public partial class App : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Alerts.Instance.ClearMessages();

            try
            {
                string email = txtEmailLogin.Text;
                string password = txtPasswordLogin.Text;

                if (!UserAuth.Instance.Attempt(email, password))
                {
                    Alerts.Instance.errorMessages.Add("Login failed!");
                }
                else
                {
                    Alerts.Instance.successMessages.Add($"Wellcome back {UserAuth.Instance.User().name}");
                }
            }
            catch (Exception error)
            {
                Alerts.Instance.errorMessages.Add(error.Message);
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}