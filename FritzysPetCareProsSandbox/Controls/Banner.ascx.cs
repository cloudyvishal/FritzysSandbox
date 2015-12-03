using System;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using BCL.Admin.StoreFrontMgr;

namespace FritzysPetCarePros.Controls
{
    public partial class Banner : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StoreFront ObjStore = null;
            try
            {
                int Count = 0;
                string PageName = GetCurrentPageName();
                if (Session["UserType"] == "3")
                    Count = 3;
                if (Session["UserType"] == "2")
                    Count = 2;
                if (Session["UserType"] == "1")
                    Count = 1;
                if (Session["IsLogin"] == null || Session["IsLogin"] == "0")
                {
                    Count = 0;
                }
                DataSet ds = new DataSet();
                ObjStore = new StoreFront();
                ds = ObjStore.GetBanerID(Count, PageName);
                if (ds.Tables[0].Rows.Count > 0)
                    Count = Convert.ToInt32(ds.Tables[0].Rows[0]["BannerID"].ToString()) + 1;

                string file = "XML_Banner_Cat.swf?page=" + Count.ToString();

                string plyr = "<embed src=" + file + "  quality='high' pluginspage='http://www.adobe.com/shockwave/download/download.cgi?P1_Prod_Version=ShockwaveFlash' type='application/x-shockwave-flash' wmode='transparent' width='668' height='271'></embed> <script src='ieupdate.js' type='text/javascript'></script> <script type='text/javascript' src='ieupdate.js'></script>";
                
                plh.Controls.Add(new LiteralControl(plyr));
            }
            finally
            {
                ObjStore = null;
            }
        }

        public string GetCurrentPageName()
        {
            string pageUrl = Request.Url.PathAndQuery.ToString().ToLower();

            char[] separator = new char[] { '/' };
            string[] str = pageUrl.Split(separator);
            int i = str[str.Length - 1].LastIndexOf('?');
            if (i == -1)
                pageUrl = str[str.Length - 1].ToString();
            else
                pageUrl = str[str.Length - 1].Substring(0, i);
            return pageUrl;
        }
    }
}