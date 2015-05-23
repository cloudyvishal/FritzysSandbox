using BCL.Admin.StoreFrontMgr;

using BCL.Utility.Contents;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FritzysPetCareProsSandbox
{
    public partial class CatBlueberryFacial : BasePage
    {
        int ServiceId = 97;

        int pageid = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = null;

            StoreFront ObjStore = null;

            try
            {
                int Count = 0;

                if (Session["UserType"] == "3")
                    Count = 3;
                if (Session["UserType"] == "2")
                    Count = 2;
                if (Session["UserType"] == "1")
                    Count = 1;
                if (Session["IsLogin"] == "" || Session["IsLogin"] == null || Session["IsLogin"] == "0")
                {
                    Count = 0;
                }
                 ds = new DataSet();

                 ObjStore = new StoreFront();

                ds = ObjStore.GetBanerID(Count, "ServiceDetails.aspx");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    Count = Convert.ToInt32(ds.Tables[0].Rows[0]["BannerID"].ToString()) + 1;
                }

                string file = "XML_Banner_Cat.swf?page=" + Count.ToString();

                string plyr = "<embed src=" + file + "  quality='high' pluginspage='http://www.adobe.com/shockwave/download/download.cgi?P1_Prod_Version=ShockwaveFlash' type='application/x-shockwave-flash' wmode='transparent' width='668' height='271'></embed> <script src='ieupdate.js' type='text/javascript'></script> <script type='text/javascript' src='ieupdate.js'></script>";
               
                plh.Controls.Add(new LiteralControl(plyr));

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
                    foreach (string s in mobiles)
                    {
                        if (Request.ServerVariables["HTTP_USER_AGENT"].ToLower().Contains(s.ToLower()))
                        {
                            Ismobile = true;
                        }
                    }

                    if (Ismobile.Equals(true))
                    {
                        Response.Redirect("http://localhost:50372/fritzymobile/Cat_Blueberry_Facial.aspx".ToLower());
                       
                        HttpContext.Current.Response.Status = "301 Moved Permanently";
                        
                        HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().Replace("http://localhost:50372/", "http://www.localhost:50372/fritzymobile/Cat_Blueberry_Facial.aspx"));

                        int ServiceID = ServiceId;
                        
                        int PageID = pageid;
                       
                        BindData(ServiceID, PageID);
                    }

                    else
                    {
                        BindData(ServiceId, pageid);
                    }
                }
            } 
            finally
            {
                if (ObjStore != null)
                {
                    ObjStore = null;
                }
            }
        }

        public void BindData(int ServiceID, int PageID)
        {
            StoreFront ObjService = null;

            DataSet ds = null;

            try
            {
                ObjService = new StoreFront();

                ds = new DataSet();

                ds = ObjService.GetServiceDetailFront(ServiceID, PageID);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (PageID == 1)
                    {
                        ImgService.ImageUrl = Session["HomePath"] + "StoreData/Images/" + ds.Tables[0].Rows[0]["Image"].ToString();

                        lblServiceTitle.Text = ds.Tables[0].Rows[0]["ServiceTitle"].ToString();

                        Page.Title = ds.Tables[0].Rows[0]["ServiceTitle"].ToString();

                        lblServiceDesc.Text = ds.Tables[0].Rows[0]["ServiceDescription"].ToString();

                        litContent.Text = ContentManager.GetFileContentView(ContentManager.GetPhysicalPath(Session["HomePath"] + "StoreData/" + ds.Tables[0].Rows[0]["PageName"].ToString()));
                    }
                    if (PageID == 2)
                    {
                        ImgService.ImageUrl = Session["HomePath"] + "StoreData/HomeServices/" + ds.Tables[0].Rows[0]["Image"].ToString();

                        lblServiceTitle.Text = ds.Tables[0].Rows[0]["ServiceTitle"].ToString();

                        Page.Title = ds.Tables[0].Rows[0]["ServiceTitle"].ToString();

                        lblServiceDesc.Text = ds.Tables[0].Rows[0]["ServiceDescription"].ToString();
                    }
                    if (PageID == 3)
                    {
                        ImgService.ImageUrl = Session["HomePath"] + "StoreData/ServicePageServices/" + ds.Tables[0].Rows[0]["Image"].ToString();

                        lblServiceTitle.Text = ds.Tables[0].Rows[0]["ServiceTitle"].ToString();

                        Page.Title = ds.Tables[0].Rows[0]["ServiceTitle"].ToString();

                        lblServiceDesc.Text = ds.Tables[0].Rows[0]["ServiceDescription"].ToString();
                    }
                }
                else
                {

                }
            } 
            finally
            {
                if (ObjService != null)
                {
                    ObjService = null;
                }
                if (ds != null)
                {
                    ds.Dispose();
                }
            }
        }
    }
}