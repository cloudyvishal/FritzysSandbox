using System;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;


using BCL.Utility.Contents;
using BCL.Utility.GlobalFunctions;

namespace FritzysPetCareProsSandbox
{
    public partial class Aboutus : BasePage
    {
        PagedDataSource PageDs = new PagedDataSource();

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
                    // if (Request.ServerVariables["HTTP_USER_AGENT"].
                    if (Request.ServerVariables["HTTP_USER_AGENT"].ToLower().Contains(s.ToLower()))
                    {
                        Ismobile = true;
                    }
                }

                if (Ismobile.Equals(true))
                {
                    HttpContext.Current.Response.Status = "301 Moved Permanently";
                    HttpContext.Current.Response.AddHeader("Location",
                    Request.Url.ToString().Replace(Request.Url.ToString(), ("http://localhost:50372/fritzymobile/MB_aboutus.aspx").ToLower()));

                }

                else
                {
                    BindData();

                    litContent.Text = ContentManager.GetFileContentView(ContentManager.GetPhysicalPath(SessionManagement.HomePath + "StoreData/StaticeContent/AboutUs.htm"));
                }
            }
        }

        protected void BindData()
        {
            Global ObjGlobal = null;

            DataSet ds = null;
            try
            {
                ObjGlobal = new Global();

                ds = new DataSet();

                ds = ObjGlobal.GetNewsOnStoreFront();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    PageDs.DataSource = ds.Tables[0].DefaultView;

                    PageDs.AllowPaging = true;

                    PageDs.PageSize = 8;

                    dtlNews.DataSource = PageDs;

                    dtlNews.DataBind();
                }
            }
            finally
            {
                ObjGlobal = null;

                ds.Dispose();
            }
        }

        protected void dtlNews_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }
    }
}