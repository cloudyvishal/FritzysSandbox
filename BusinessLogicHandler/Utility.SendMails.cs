using System;
using System.Text;
using System.Configuration;
using System.Collections.Generic;
using System.Net.Mail;

namespace BCL.Utility.SendMailMgr
{
    public class SendMails
    {
        public SendMails()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public void SendEmails(string FromEmailId, string ToEmailId, string Subject, string message)
        {
            MailMessage myMessage = new System.Net.Mail.MailMessage();

            try
            {
                string smtpHost = ConfigurationManager.AppSettings["SmtpServer"].ToString();

                myMessage.To.Add(ToEmailId);

                myMessage.From = new MailAddress(ConfigurationManager.AppSettings["FromEmail"].ToString(), "Fritzy's Pet Care Pros");

                myMessage.Subject = Subject;

                myMessage.Body = message;

                myMessage.IsBodyHtml = true;

                System.Net.NetworkCredential myCredential = new System.Net.NetworkCredential("info@fritzys.net", "");

                SmtpClient mySmtpClient = new SmtpClient();

                mySmtpClient.Host = ConfigurationManager.AppSettings["SmtpServer"].ToString();

                mySmtpClient.UseDefaultCredentials = false;

                mySmtpClient.Credentials = myCredential;

                mySmtpClient.ServicePoint.MaxIdleTime = 1;

                mySmtpClient.Send(myMessage);
            }
            finally
            {
                myMessage.Dispose();
            }
        }

        public bool SendEmailsWithVal(string FromEmailId, string ToEmailId, string Subject, string message)
        {
            MailMessage myMessage = new System.Net.Mail.MailMessage();

            try
            {
                string smtpHost = ConfigurationManager.AppSettings["SmtpServer"].ToString();

                myMessage.To.Add(ToEmailId);

                myMessage.From = new MailAddress(ConfigurationManager.AppSettings["FromEmail"].ToString(), "Fritzy's Pet Care Pros");

                myMessage.Subject = Subject;

                myMessage.Body = message;

                myMessage.IsBodyHtml = true;

                System.Net.NetworkCredential myCredential = new System.Net.NetworkCredential("info@fritzys.net", "");

                SmtpClient mySmtpClient = new SmtpClient();

                mySmtpClient.Host = ConfigurationManager.AppSettings["SmtpServer"].ToString();

                mySmtpClient.UseDefaultCredentials = false;

                mySmtpClient.Credentials = myCredential;

                mySmtpClient.ServicePoint.MaxIdleTime = 1;

                mySmtpClient.Send(myMessage);
            }
            finally
            {
                myMessage.Dispose();
            }
            return true;
        }

        public void SendRequestEmails(string FromEmailId, string ToEmailId, string Subject, string FName, string LName, string SenderName)
        {
            MailMessage myMessage = new System.Net.Mail.MailMessage();
            try
            {
                string smtpHost = ConfigurationManager.AppSettings["SmtpServer"].ToString();

                myMessage.To.Add(ToEmailId);

                myMessage.From = new MailAddress(ConfigurationManager.AppSettings["FromEmail"].ToString(), "Fritzy's Pet Care Pros");

                myMessage.Subject = Subject;

                myMessage.IsBodyHtml = true;

                string message = "<div style='font-family: Arial; font-size: 12px;'>";

                message = message + "<p>Hi&nbsp;<b>" + FName + "&nbsp;" + LName + "</b> </p>";

                message = message + "<p>" + SenderName + "&nbsp;has requested to be your friend on Hicpics. </p>";

                message = message + "<p>To accept or reject this request, please visit www.hicpics.com  <br />  <p>";

                message = message + "Thanks,&nbsp;" + SenderName + "</p>";

                message = message + "</div>";

                myMessage.Body = message;

                System.Net.NetworkCredential myCredential = new System.Net.NetworkCredential("info@fritzys.net", "");

                SmtpClient mySmtpClient = new SmtpClient();

                mySmtpClient.Host = ConfigurationManager.AppSettings["SmtpServer"].ToString();

                mySmtpClient.UseDefaultCredentials = false;

                mySmtpClient.Credentials = myCredential;

                mySmtpClient.ServicePoint.MaxIdleTime = 1;

                mySmtpClient.Send(myMessage);
            }
            finally
            {
                myMessage = null;
            }

        }

        public void SendProviderRequestEmails(string FromEmailId, string ToEmailId, string Subject, string FName, string LName, string SenderName)
        {
            MailMessage myMessage = new System.Net.Mail.MailMessage();

            try
            {

                string smtpHost = ConfigurationManager.AppSettings["SmtpServer"].ToString();

                myMessage.To.Add(ToEmailId);

                myMessage.From = new MailAddress(ConfigurationManager.AppSettings["FromEmail"].ToString(), "Fritzy's Pet Care Pros");

                myMessage.Subject = Subject;

                myMessage.IsBodyHtml = true;

                string message = "<div style='font-family: Arial; font-size: 12px;'>";

                message = message + "<p>Hi&nbsp;<b>" + FName + "&nbsp;" + LName + "</b> </p>";

                message = message + "<p>" + SenderName + "&nbsp;is now added to your subscriber list. </p>";

                message = message + "<p>For more information visit www.hicpics.com  <br />  <p>";

                message = message + "Thanks,&nbsp;" + SenderName + "</p>";

                message = message + "</div>";

                myMessage.Body = message;

                System.Net.NetworkCredential myCredential = new System.Net.NetworkCredential("info@fritzys.net", "");

                SmtpClient mySmtpClient = new SmtpClient();

                mySmtpClient.Host = ConfigurationManager.AppSettings["SmtpServer"].ToString();

                mySmtpClient.UseDefaultCredentials = false;

                mySmtpClient.Credentials = myCredential;

                mySmtpClient.ServicePoint.MaxIdleTime = 1;

                mySmtpClient.Send(myMessage);
            }
            finally
            {
                myMessage = null;
            }
        }

        public void AppointmentMail(string ToMail, string subject, string MailBody)
        {
            MailMessage myMessage = new System.Net.Mail.MailMessage();

            try
            {
                string smtpHost = ConfigurationManager.AppSettings["SmtpServer"].ToString();

                myMessage.To.Add(ToMail);

                myMessage.From = new MailAddress(ConfigurationManager.AppSettings["FromEmail"].ToString(), "Fritzy's Pet Care Pros");

                myMessage.Subject = subject;

                myMessage.Body = MailBody;

                myMessage.IsBodyHtml = true;

                System.Net.NetworkCredential myCredential = new System.Net.NetworkCredential("info@fritzys.net", "");

                SmtpClient mySmtpClient = new SmtpClient();

                mySmtpClient.Host = ConfigurationManager.AppSettings["SmtpServer"].ToString();

                mySmtpClient.UseDefaultCredentials = false;

                mySmtpClient.Credentials = myCredential;

                mySmtpClient.ServicePoint.MaxIdleTime = 1;

                mySmtpClient.Send(myMessage);
            }
            finally
            {
                myMessage.Dispose();
            }
        }

        public void PaymentMail(string p, string datenew, string Appoinment, string Appoinment_Date, string emailadd, string totalprice, string CC_Name, string mMessage, string Mailbody)
        {
            MailMessage myMessage = new System.Net.Mail.MailMessage();
            try
            {
                string smtpHost = ConfigurationManager.AppSettings["SmtpServer"].ToString();

                myMessage.To.Add(emailadd);

                myMessage.From = new MailAddress(ConfigurationManager.AppSettings["FromEmail"].ToString(), "Fritzy's Pet Care Pros");

                myMessage.Subject = "Payment Details For Fritzys Pet Care Pros Mobile Grooming Services";

                myMessage.Body = Mailbody;

                myMessage.IsBodyHtml = true;

                System.Net.NetworkCredential myCredential = new System.Net.NetworkCredential("info@fritzys.net", "");

                SmtpClient mySmtpClient = new SmtpClient();

                mySmtpClient.Host = ConfigurationManager.AppSettings["SmtpServer"].ToString();

                mySmtpClient.UseDefaultCredentials = false;

                mySmtpClient.Credentials = myCredential;

                mySmtpClient.ServicePoint.MaxIdleTime = 1;

                mySmtpClient.Send(myMessage);
            }
            catch (Exception ex)
            {
                string error = ex.Source + "_" + ex.Message + "_" + ex.ToString();
            }
        }

        public void PrePaymentMail(string p, string datenew, string emailadd, string totalprice, string CC_Name, string mMessage, string Mailbody)
        {
            MailMessage myMessage = new System.Net.Mail.MailMessage();
            try
            {
                string smtpHost = ConfigurationManager.AppSettings["SmtpServer"].ToString();

                myMessage.To.Add(emailadd);

                myMessage.From = new MailAddress(ConfigurationManager.AppSettings["FromEmail"].ToString(), "Fritzy's Pet Care Pros");

                myMessage.Subject = "Payment Details For Fritzys Pet Care Pros Mobile Grooming Services";

                myMessage.Body = Mailbody;

                myMessage.IsBodyHtml = true;

                System.Net.NetworkCredential myCredential = new System.Net.NetworkCredential("info@fritzys.net", "");

                SmtpClient mySmtpClient = new SmtpClient();

                mySmtpClient.Host = ConfigurationManager.AppSettings["SmtpServer"].ToString();

                mySmtpClient.UseDefaultCredentials = false;

                mySmtpClient.Credentials = myCredential;

                mySmtpClient.ServicePoint.MaxIdleTime = 1;

                mySmtpClient.Send(myMessage);
            }
            catch (Exception ex)
            {
                string error = ex.Source + "_" + ex.Message + "_" + ex.ToString();
            }
        }
    }
}
