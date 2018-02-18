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
            if (!IsPostBack) Alerts.ClearMessages();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Alerts.ClearMessages();

            try
            {
                string email = txtEmailLogin.Text;
                string password = txtPasswordLogin.Text;

                if (!UserAuth.Instance.Attempt(email, password))
                {
                    Alerts.errorMessages.Add("Login failed!");
                }
                else
                {
                    Alerts.successMessages.Add($"Wellcome back {UserAuth.Instance.User().name}");
                }
            }
            catch (Exception error)
            {
                Alerts.errorMessages.Add(error.Message);
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Alerts.ClearMessages();

            try
            {
                string name = txtNameRegister.Text;
                string email = txtEmailRegister.Text;
                string password = txtPasswordRegister.Text;
                string retryPassword = txtRetryPasswordRegister.Text;

                if (name == String.Empty)
                {
                    throw new Exception("Name is required!");
                }

                if (name == String.Empty || !email.Contains('@'))
                {
                    throw new Exception("Invalid email!");
                }

                if (password == String.Empty)
                {
                    throw new Exception("Password is required!");
                }

                if (retryPassword == String.Empty)
                {
                    throw new Exception("Retry Password is required!");
                }

                if (password != retryPassword)
                {
                    throw new Exception("Passwords does not match!");
                }

                // TODO: ReCaptcha

                if (User.Create(name, email, password))
                {
                    Alerts.successMessages.Add("Account created with success!");
                }
            }
            catch (Exception error)
            {
                Alerts.errorMessages.Add(error.Message);
            }
        }
    }
}