using System;
using System.IO;
using System.Web;
using System.Text;
using System.Configuration;

namespace BCL.Common.ErrorLog
{
    public class ErrorLogging : Exception
    {
        public ErrorLogging(string message)
            : base(message)
        {
            string fileName = "ErrorLogFile" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt";

            if (File.Exists(fileName))
            {
                FileStream fs = File.Create(ConfigurationManager.AppSettings["ErrerLogPath"] + fileName);
            }

            StringBuilder inputParameter = null;

            try
            {
                inputParameter = new StringBuilder();

                inputParameter.Append("Error Message: ");

                inputParameter.Append(message);

                inputParameter.Append(Environment.NewLine);

                inputParameter.Append(Environment.NewLine);

                inputParameter.Append("  Error Timestamp: ");

                inputParameter.Append(DateTime.Now.ToString());

                inputParameter.Append(Environment.NewLine);

                inputParameter.Append("------------------------------------------");

                inputParameter.Append(Environment.NewLine);

                //File.AppendAllText(ConfigurationManager.AppSettings["ErrerLogPath"] + fileName, inputParameter.ToString());
            }
            finally
            {
                inputParameter = null;
            }
            //if (HttpContext.Current.Session["AdminPath"] != null)
            //{
            //    HttpContext.Current.Response.Redirect(HttpContext.Current.Session["AdminPath"] + "ErrorPage.aspx");
            //}
            //else
            //{
            //    HttpContext.Current.Response.Redirect("~/ErrorPage.aspx");
            //}
        }

        ~ErrorLogging() { }
    }   
}
