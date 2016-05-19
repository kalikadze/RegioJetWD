using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace RegioJetWD
{
    class Mailer
    {
        public string sendit(string ReciverMail)
        {
            MailMessage msg = new MailMessage();

            msg.From = new MailAddress("kalipi.mailer@gmail.com");
            msg.To.Add(ReciverMail);
            msg.Subject = "Strazny Pes RegioJetu" + DateTime.Now.ToString();
            msg.Body = "Prave sa uvolnil minimalne jeden listok pre tvoje sledovane vlaky.";

            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("kalipi.mailer@gmail.com", "GfKLoQvRXAmMvMYcJs7G");
            client.Timeout = 200000;
            try
            {
                client.Send(msg);
                return "Mail has been successfully sent!";
            }
            catch (Exception ex)
            {
                return "Fail Has error" + ex.Message;
            }
            finally
            {
                msg.Dispose();
            }
        }
    }
}
