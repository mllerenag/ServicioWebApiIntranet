using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Configuration;
using System.Reflection;

/// <summary>
/// Summary description for BLMail
/// </summary>

namespace WebApiMovil.BusinessLayer
{
    public class MailBL
    {
        public void EnviarMail(String destinatario, String copia, string subject, string body, List<string> files, bool html = true, bool sync = true)
        {
            String SMTP_SERVER = ConfigurationManager.AppSettings["SMTP"].ToString();
            String SMTP_PORT = ConfigurationManager.AppSettings["SMTP_PORT"].ToString();
            String SMTP_USER = ConfigurationManager.AppSettings["FROM_USER"].ToString();
            String SMTP_PWD = ConfigurationManager.AppSettings["FROM_PWD"].ToString();
            MailMessage mail = new MailMessage();
            string[] dest = destinatario.Split(';');
            foreach (var item in dest)
            {
                if (!String.IsNullOrEmpty(item)) mail.To.Add(item);
            }

            string[] copiados = copia.Split(';');
            foreach (var item in copiados)
            {
                if (!String.IsNullOrEmpty(item)) mail.CC.Add(item);
            }
            mail.From = new MailAddress(ConfigurationManager.AppSettings["FROM_USER"].ToString());
            mail.Subject = subject;
            mail.Body = body;
            if (html) mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            foreach (string file in files)
            {
                if (!String.IsNullOrEmpty(file))
                    mail.Attachments.Add(new Attachment(file));
            }
            SmtpClient mSmtpClient = new SmtpClient();
            mSmtpClient.Host = SMTP_SERVER;
            mSmtpClient.Port = int.Parse(SMTP_PORT);
            mSmtpClient.UseDefaultCredentials = false;
            mSmtpClient.EnableSsl = true;
            mSmtpClient.Credentials = new System.Net.NetworkCredential(SMTP_USER, SMTP_PWD);
            if (sync)
                SendSync(mSmtpClient, mail);
            else
                SendAsync(mSmtpClient, mail);
        }

        public void SendSync(SmtpClient mSmtpClient, MailMessage mail)
        {
            try
            {
                mSmtpClient.Send(mail);
            }
            catch (Exception)
            {

            }
            finally
            {
                mail.Dispose();
                mSmtpClient.Dispose();
            }
        }

        public void SendAsync(SmtpClient mSmtpClient, MailMessage mail)
        {
            try
            {
                mSmtpClient.SendCompleted += (s, e) =>
                {
                    mail.Dispose();
                    mSmtpClient.Dispose();
                };
                mSmtpClient.SendAsync(mail, null);

            }
            catch (Exception)
            {
                mail.Dispose();
                mSmtpClient.Dispose();
            }
        }
    }
}