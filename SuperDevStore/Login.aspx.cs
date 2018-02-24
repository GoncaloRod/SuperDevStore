using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SuperDevStore
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserAuth.Instance.Check()) Response.Redirect("Index.aspx", false);
        }

        protected void btnLoginForm_Click(object sender, EventArgs e)
        {
            try
            {
                string email = txtEmailLoginForm.Text;
                string password = txtPasswordLoginForm.Text;

                if (!UserAuth.Instance.Attempt(email, password))
                {
                    Alerts.errorMessages.Add("Login failed!");
                }
                else
                {
                    Alerts.successMessages.Add($"Wellcome back {UserAuth.Instance.User().name}");

                    Response.Redirect("Index.aspx", false);
                }
            }
            catch (Exception error)
            {
                Alerts.errorMessages.Add(error.Message);
            }
        }

        protected void btnRegisterForm_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtNameRegisterForm.Text;
                string email = txtEmailRegisterForm.Text;
                string password = txtPasswordRegisterForm.Text;
                string retryPassword = txtRetryPasswordRegisterForm.Text;

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

                if (SuperDevStore.User.Create(name, email, password))
                {
                    Alerts.successMessages.Add("Account created with success!");

                    Response.Redirect("Index.aspx", false);
                }
            }
            catch (Exception error)
            {
                Alerts.errorMessages.Add(error.Message);
            }
        }
    }
}