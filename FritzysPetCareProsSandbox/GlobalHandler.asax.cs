using System;
using System.IO;
using System.Web;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Configuration;
using System.Web.SessionState;
using System.Collections.Generic;

namespace FritzysPetCareProsSandbox
{
    public class GlobalHandler : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            
        }

        protected void Session_Start(object sender, EventArgs e)
        {
          
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session == null)
            {
                Session["HomePath"] = ConfigurationManager.AppSettings["HomePathValue"].ToString();     // Session["Homepath"] use to set root directory path and this path can be set from Web.config

                Session["AdminPath"] = Session["HomePath"] + "Admin/";                             // Session["AdminPath"] use to set root directory path of admin folder 

                Session["StaticContentPhysicalPath"] = Session["HomePath"] + "StoreData/";

                Session["MemberName"] = null;                                                      // Session["MemberName"] Use to store member name display on home page 

                Session["IsLogin"] = "0";                                                          // Session["IsLogin"] is use to check whether user is Loged in or not default Not  

                Session["UserType"] = "4";                                                         // Session["UserType"] is use to set UseType 0 (Cat) ,1(Dog), 2(CatDog)

                Session["AdminUserType"] = "1";                                                    // Session["AdminUserType"] is user to set Admin user type 0 for admin and 1 for Subadmin

                Session["MobilePath"] = Session["HomePath"] + "mobileweb/";
            }
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            // Get exception
            Exception lastException = Server.GetLastError();

            // Check if exception is not null
            if (lastException != null)
            {
                // Get message from exception
                string error = lastException.Message;

                // Check if inner exception is not null
                if (lastException.InnerException != null)
                {
                    // Append message from inner exception to variable of type 'string' containing exception
                    error += lastException.InnerException.Message;

                    // Append stack trace from inner exception to variable of type 'string' containing exception
                    error += lastException.InnerException.StackTrace;
                }

                // Log exception details
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

                    inputParameter.Append(error);

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
            }

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}