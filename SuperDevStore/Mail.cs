using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Configuration;

namespace SuperDevStore
{
    public class Mail
    {
        private static Mail instance;

        public static Mail Instance
        {
            get
            {
                if (instance == null) instance = new Mail();

                return instance;
            }
        }

        private static string fromName = ConfigurationManager.AppSettings["Mail.FromName"];
        private static string username = ConfigurationManager.AppSettings["Mail.Username"];
        private static string password = ConfigurationManager.AppSettings["Mail.Password"];
        private static string host = ConfigurationManager.AppSettings["Mail.Host"];
        private static int port = int.Parse(ConfigurationManager.AppSettings["Mail.Port"]);

        private SmtpClient client = new SmtpClient(host, port)
        {
            Credentials = new NetworkCredential(username, password),
            EnableSsl = true
        };

        public void Send(string MailTo, string Subject, string Message)
        {
            client.Send(fromName, MailTo, Subject, Message);
        }
    }
}