using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FritzysPetCareProsSandbox
{
    public partial class ServicesDetails : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bool Ismobile = false;

                string[] mobiles =
                new[]
                {
                    "midp","android","j2me", "avant", "docomo", 
                    "novarra", "palmos", "palmsource", 
                     "opwv", "chtml","320x480",
                    "pda", "windows ce", "mmp/", 
                    "blackberry", "mib/", "symbian", 
                    "wireless", "nokia", "hand", "mobi", 
                    "phone", "cdm", "up.b", "audio", 
                    "SIE-", "SEC-", "samsung", "HTC", 
                    "mot-", "mitsu", "sagem", "sony"
                    , "alcatel", "lg", "eric", "vx", 
                     "philips", "mmm", "xx", 
                    "panasonic", "sharp", "wap", "sch",
                    "rover", "pocket", "benq", "java", 
                    "pt", "pg", "vox", "amoi", 
                    "bird", "compal", "kg", "voda",
                    "sany", "kdd", "dbt", "sendo", 
                    "sgh", "gradi", "jb", "dddi", 
                    "moto", "iphone"
                };
                //Loop through each item in the list created above 
                //and check if the header contains that text
                foreach (string s in mobiles)
                {
                    if (Request.ServerVariables["HTTP_USER_AGENT"].ToLower().Contains(s.ToLower()))
                    {
                        Ismobile = true;
                    }
                }

                if (Ismobile.Equals(true))
                {
                    Response.Redirect("../fritzymobile/MB_services.aspx".ToLower());

                    HttpContext.Current.Response.Status = "301 Moved Permanently";

                    HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().Replace("../", "../fritzymobile/MB_services.aspx"));
                }

                else
                {
                    if (SessionManagement.UserType.ToString() == "3")
                    {
                        Control bodyCntrl = LoadControl("Controls/Services_Common.ascx");

                        plcServices.Controls.Add(bodyCntrl);
                    }
                    if (SessionManagement.UserType.ToString() == "4")
                    {
                        Control bodyCntrl = LoadControl("Controls/Services_Common.ascx");

                        plcServices.Controls.Add(bodyCntrl);
                    }
                    if (SessionManagement.UserType.ToString() == "1")
                    {
                        Control bodyCntrl = LoadControl("Controls/Services_Common.ascx");

                        plcServices.Controls.Add(bodyCntrl);
                    }

                    if (SessionManagement.UserType.ToString() == "2")
                    {
                        Control bodyCntrl = LoadControl("Controls/Services_Common.ascx");

                        plcServices.Controls.Add(bodyCntrl);
                    }
                    if ((SessionManagement.UserType.ToString() == "") || SessionManagement.UserType == null)
                    {
                        Control bodyCntrl = LoadControl("Controls/Services_Common.ascx");

                        plcServices.Controls.Add(bodyCntrl);
                    }
                }
            }
        }
    }
}