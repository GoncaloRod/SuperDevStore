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

        public void Send(string MailTo, string Subject, string Message)
        {
            MailMessage message = new MailMessage();
            NetworkCredential credential = new NetworkCredential(username, password);
            MailAddress from = new MailAddress(fromName);
            SmtpClient client = new SmtpClient();

            // Message
            message.To.Add(MailTo);
            message.From = from;
            message.Subject = Subject;
            message.Body = Message;
            message.IsBodyHtml = true;

            // Server
            client.Host = host;
            client.Port = port;
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = credential;

            // Send Mail
            client.Send(message);
        }
    }
}