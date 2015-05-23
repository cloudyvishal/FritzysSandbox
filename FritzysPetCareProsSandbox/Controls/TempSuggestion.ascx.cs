using System;
using System.Web;
using System.Web.UI;
using System.Net.Mail;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Collections.Generic;

using BCL.Utility.Contents;
using BCL.Utility.GlobalFunctions;

namespace FritzysPetCarePros.Controls
{
    public partial class TempSuggestion : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSumbmit_Click(object sender, ImageClickEventArgs e)
        {
            Global Obj_Suggest = null;

            try
            {
                Obj_Suggest = new Global();

                Obj_Suggest.AddSuggestion(txtName.Text.Trim(), txtEmail.Text.Trim(), txtPhone.Text.Trim(), txtComment.Text.Trim());


                string Message = ContentManager.GetStaticeContentEmail("Suggestion.htm").Replace("~", "#");

                Message = Message.Replace("<!-- Name -->", txtName.Text.Trim());

                Message = Message.Replace("<!-- Email -->", txtEmail.Text.Trim());

                Message = Message.Replace("<!-- Phone -->", txtPhone.Text.Trim());

                Message = Message.Replace("<!-- Suggestion -->", txtComment.Text.Trim());

                string smtpHost = ConfigurationManager.AppSettings["SmtpServer"].ToString();

                string smtpPort = ConfigurationManager.AppSettings["SmtpPort"].ToString();

                MailMessage mail = new MailMessage();

                mail.From = new MailAddress(txtEmail.Text);

                mail.To.Add(new MailAddress(ConfigurationManager.AppSettings["ToEmail"]));

                mail.Subject = "Suggestion from : " + txtName.Text.Trim();

                mail.IsBodyHtml = true;

                mail.Priority = MailPriority.Normal;

                string message = Message;

                mail.Body = message;

                SmtpClient client = new SmtpClient();

                client.Credentials = new System.Net.NetworkCredential("info@fritzys.net", "");

                client.Host = smtpHost;

                client.Port = !string.IsNullOrEmpty(smtpPort) ? Convert.ToInt32(smtpPort) : 0;

                client.Send(mail);
            }
            finally
            {
                txtName.Text = "";
                
                txtEmail.Text = "";
                
                txtPhone.Text = "";
             
                txtComment.Text = "";
            }
        }
    }
}