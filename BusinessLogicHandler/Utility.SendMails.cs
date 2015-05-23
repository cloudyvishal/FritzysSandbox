using System;
using System.Text;
using System.Configuration;
using System.Collections.Generic;
using System.Web.Mail;

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
            MailMessage mail = null;

            try
            {
                string smtpHost = ConfigurationManager.AppSettings["SmtpServer"].ToString();

                //string smtpPort = "25";

                mail = new MailMessage();

                mail.To = ToEmailId;

                mail.From = FromEmailId;

                mail.Subject = Subject;

                mail.Body = message;

                mail.BodyEncoding = System.Text.Encoding.UTF8;

                mail.BodyFormat = MailFormat.Html;

                mail.Priority = MailPriority.High;

                SmtpMail.SmtpServer = ConfigurationManager.AppSettings["SmtpServer"];

                mail.Fields["http://schemas.microsoft.com/cdo/configuration/smtpserver"] = ConfigurationManager.AppSettings["SmtpServer"];

                mail.Fields["http://schemas.microsoft.com/cdo/configuration/smtpauthenticate"] = 2;

                SmtpMail.Send(mail);
            }
            finally
            {
                mail = null;
            }
        }

        public bool SendEmailsWithVal(string FromEmailId, string ToEmailId, string Subject, string message)
        {
            MailMessage mail = null;

            try
            {
                string smtpHost = ConfigurationManager.AppSettings["SmtpServer"].ToString();

                //string smtpPort = ConfigurationManager.AppSettings["SmtpPort"].ToString();

                mail = new MailMessage();

                mail.To = ToEmailId;

                mail.From = FromEmailId;

                mail.Subject = Subject;

                mail.Body = message;

                mail.BodyEncoding = System.Text.Encoding.UTF8;

                mail.BodyFormat = MailFormat.Html;

                mail.Priority = MailPriority.High;

                SmtpMail.SmtpServer = ConfigurationManager.AppSettings["SmtpServer"];

                mail.Fields["http://schemas.microsoft.com/cdo/configuration/smtpserver"] = ConfigurationManager.AppSettings["SmtpServer"];

                mail.Fields["http://schemas.microsoft.com/cdo/configuration/smtpauthenticate"] = 2;

                SmtpMail.Send(mail);

                return true;
            }
            finally
            {
                mail = null;
            }
        }

        public void SendRequestEmails(string FromEmailId, string ToEmailId, string Subject, string FName, string LName, string SenderName)
        {
            MailMessage mail = null;

            try
            {
                string smtpHost = ConfigurationManager.AppSettings["SmtpServer"].ToString();

               // string smtpPort = ConfigurationManager.AppSettings["SmtpPort"].ToString();

                mail = new MailMessage();

                mail.To = ToEmailId;

                mail.From = FromEmailId;

                mail.Subject = Subject;

                mail.BodyFormat = MailFormat.Html;

                string message = "<div style='font-family: Arial; font-size: 12px;'>";

                message = message + "<p>Hi&nbsp;<b>" + FName + "&nbsp;" + LName + "</b> </p>";

                message = message + "<p>" + SenderName + "&nbsp;has requested to be your friend on Hicpics. </p>";

                message = message + "<p>To accept or reject this request, please visit www.hicpics.com  <br />  <p>";

                message = message + "Thanks,&nbsp;" + SenderName + "</p>";

                message = message + "</div>";

                mail.Body = message;
                try
                {
                    SmtpMail.SmtpServer = ConfigurationManager.AppSettings["SmtpServer"];

                    mail.Fields["http://schemas.microsoft.com/cdo/configuration/smtpserver"] = ConfigurationManager.AppSettings["SmtpServer"];

                    mail.Fields["http://schemas.microsoft.com/cdo/configuration/smtpauthenticate"] = 2;

                    SmtpMail.Send(mail);

                }
                finally
                {
                    
                }
            }
            finally
            {
                mail = null;
            }

        }

        public void SendProviderRequestEmails(string FromEmailId, string ToEmailId, string Subject, string FName, string LName, string SenderName)
        {

            string smtpHost = ConfigurationManager.AppSettings["SmtpServer"].ToString();

            //string smtpPort = ConfigurationManager.AppSettings["SmtpPort"].ToString();

            MailMessage mail = new MailMessage();

            mail.To = ToEmailId;

            mail.From = FromEmailId;

            mail.Subject = Subject;

            mail.BodyFormat = MailFormat.Html;

            string message = "<div style='font-family: Arial; font-size: 12px;'>";

            message = message + "<p>Hi&nbsp;<b>" + FName + "&nbsp;" + LName + "</b> </p>";

            message = message + "<p>" + SenderName + "&nbsp;is now added to your subscriber list. </p>";

            message = message + "<p>For more information visit www.hicpics.com  <br />  <p>";

            message = message + "Thanks,&nbsp;" + SenderName + "</p>";

            message = message + "</div>";

            mail.Body = message;

            try
            {
                SmtpMail.SmtpServer = ConfigurationManager.AppSettings["SmtpServer"];

                mail.Fields["http://schemas.microsoft.com/cdo/configuration/smtpserver"] = ConfigurationManager.AppSettings["SmtpServer"];

                mail.Fields["http://schemas.microsoft.com/cdo/configuration/smtpauthenticate"] = 2;

                SmtpMail.Send(mail);

            }
            finally
            {
                
            }
        }

        public void AppointmentMail(string ToMail, string subject, string MailBody)
        {
            MailMessage mail = null;

            try
            {
                string smtpHost = ConfigurationManager.AppSettings["SmtpServer"].ToString();

                //string smtpPort = ConfigurationManager.AppSettings["SmtpPort"].ToString();

                mail = new MailMessage();

                mail.To = ToMail;

                mail.From = ConfigurationManager.AppSettings["FromEmail"];

                mail.Subject = subject;

                mail.Body = MailBody;

                mail.BodyEncoding = System.Text.Encoding.UTF8;

                mail.BodyFormat = MailFormat.Html;

                mail.Priority = MailPriority.High;

                SmtpMail.SmtpServer = ConfigurationManager.AppSettings["SmtpServer"];

                mail.Fields["http://schemas.microsoft.com/cdo/configuration/smtpserver"] = ConfigurationManager.AppSettings["SmtpServer"];

                mail.Fields["http://schemas.microsoft.com/cdo/configuration/smtpauthenticate"] = 2;

                SmtpMail.Send(mail);
            }
            finally
            {
                mail = null;
            }
        }

        public void PaymentMail(string p, string datenew, string Appoinment, string Appoinment_Date, string emailadd, string totalprice, string CC_Name, string mMessage, string Mailbody)
        {
            MailMessage mail = null;
            try
            {
                string smtpHost = ConfigurationManager.AppSettings["SmtpServer"].ToString();

                mail = new MailMessage();

                MailMessage msgpayment = new MailMessage();
                mail.From =  ConfigurationManager.AppSettings["FromEmail"];

                mail.To=emailadd;
                
                string Subject = "Payment Details For Fritzys Pet Care Pros Mobile Grooming Services";

                mail.Subject = Subject;

                mail.Body = Mailbody;

                mail.BodyEncoding = System.Text.Encoding.UTF8;

                mail.BodyFormat = MailFormat.Html;

                msgpayment.Priority = MailPriority.Normal;

                string payment_message = Mailbody;

                msgpayment.Body = payment_message;

                //client = new SmtpClient();

                SmtpMail.SmtpServer = ConfigurationManager.AppSettings["SmtpServer"];

                mail.Fields["http://schemas.microsoft.com/cdo/configuration/smtpserver"] = ConfigurationManager.AppSettings["SmtpServer"];

                mail.Fields["http://schemas.microsoft.com/cdo/configuration/smtpauthenticate"] = 2;

                SmtpMail.Send(mail);
            }
            catch (Exception ex)
            {
                string error = ex.Source + "_" + ex.Message + "_" + ex.ToString();
            }
        }

        public void PrePaymentMail(string p, string datenew, string emailadd, string totalprice, string CC_Name, string mMessage, string Mailbody)
        {
            MailMessage mail = null;

            //SmtpClient client = null;
            try
            {
                string smtpHost = ConfigurationManager.AppSettings["SmtpServer"].ToString();

                //string smtpPort = ConfigurationManager.AppSettings["SmtpPort"].ToString();

                mail = new MailMessage();

                MailMessage msgpayment = new MailMessage();
                mail.From = ConfigurationManager.AppSettings["FromEmail"];

                mail.To=emailadd;

                string Subject = "Payment Details For Fritzys Pet Care Pros Mobile Grooming Services";

                mail.Subject = Subject;

                mail.Body = Mailbody;

                mail.BodyEncoding = System.Text.Encoding.UTF8;

                mail.BodyFormat = MailFormat.Html;

                msgpayment.Priority = MailPriority.Normal;

                string payment_message = Mailbody;

                msgpayment.Body = payment_message;

                SmtpMail.SmtpServer = ConfigurationManager.AppSettings["SmtpServer"];

                mail.Fields["http://schemas.microsoft.com/cdo/configuration/smtpserver"] = ConfigurationManager.AppSettings["SmtpServer"];

                mail.Fields["http://schemas.microsoft.com/cdo/configuration/smtpauthenticate"] = 2;

                SmtpMail.Send(mail);
            }
            catch (Exception ex)
            {
                string error = ex.Source + "_" + ex.Message + "_" + ex.ToString();
            }
        }
    }
}
