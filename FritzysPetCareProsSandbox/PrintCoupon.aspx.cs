using System;
using System.Web;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

using BCL.Admin.BannerMgr;
using BCL.Utility.Contents;
using FritzysPetCarePros.Controls;

namespace FritzysPetCareProsSandbox
{
    public partial class PrintCoupon : System.Web.UI.Page
    {
        int PageId = 0;
        int UserId = 0;

        public void ErrMessage(string Message)
        {
            divError.Visible = true;
            lblError.Attributes.Add("Class", "errorTable");
            lblError.Visible = true;
            lblError.Text = Message;
        }

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
                    string repData = Request.Url.ToString();
                    string p = repData.Replace(".com/", ".com/MB_PrintCoupon.aspx").ToLower();

                    HttpContext.Current.Response.Status = "301 Moved Permanently";
                    HttpContext.Current.Response.AddHeader("Location",
                    Request.Url.ToString().Replace(Request.Url.ToString(), ("http://mobile.naturesfreshpet.com/").ToLower()));

                }

                else
                {
                    string ImgName = "";
                    string ImagePath = "";
                    if (Request.QueryString["PageId"].ToString() != "" && Request.QueryString["UserId"].ToString() != "")
                    {
                        PageId = Convert.ToInt32(Request.QueryString["PageId"].ToString());
                        UserId = Convert.ToInt32(Request.QueryString["UserId"].ToString());
                    }
                    Banners objB = new Banners();
                    DataSet ds = new DataSet();
                    ds = objB.GetPageIdandUserId(PageId, UserId);

                    Banners newObj = new Banners();
                    DataSet dsCoupon = newObj.GetDefaultCopon(PageId, UserId);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dlCoupon.Visible = true;
                        dvNocoupon.Visible = false;
                        dvDefaultCoupon.Visible = false;
                        dlCoupon.DataSource = ds;
                        dlCoupon.DataBind();
                    }
                    else if (dsCoupon.Tables[0].Rows.Count > 0)
                    {
                        dlCoupon.Visible = false;
                        dvNocoupon.Visible = false;
                        dvDefaultCoupon.Visible = true;
                        ImagePath = Session["HomePath"] + "StoreData/BannerNew/" + dsCoupon.Tables[0].Rows[0]["bannername"].ToString();
                        string imagepath = ImagePath;
                        string fulpath = ContentManager.GetPhysicalPath(imagepath);
                        if (System.IO.File.Exists(fulpath))
                        {
                            ImgGift.ImageUrl = imagepath;
                        }
                        else
                        {
                            dvNocoupon.Visible = true;
                            dlCoupon.Visible = false;
                            dvDefaultCoupon.Visible = false;
                        }
                    }
                    else
                    {
                        dvNocoupon.Visible = true;
                        dlCoupon.Visible = false;
                        dvDefaultCoupon.Visible = false;
                    }
                }


            }
        }

        protected void dlCoupon_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            Banner objB = new Banner();
            for (int i = 0; i <= dlCoupon.Items.Count - 1; i++)
            {
                Label lblBannerId = (Label)dlCoupon.Items[i].FindControl("lblBannerId");
                Button btnPrint = (Button)dlCoupon.Items[i].FindControl("btnPrint");
                btnPrint.PostBackUrl = "~/PrintfinalCoupon.aspx?CouponID=" + lblBannerId.Text;
            }
        }

        protected void dlCoupon_ItemCommand(object source, DataListCommandEventArgs e)
        {
            int BannerId = (int)dlCoupon.DataKeys[e.Item.ItemIndex];
            if (e.CommandName == "Print")
            {
                MessageBox1(string.Concat("PrintfinalCoupon.aspx?&CouponID=", BannerId));
            }
        }

        private void MessageBox1(string strmsg)
        {

            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.open(" + "'" + strmsg + "','popuppage','status=no,toolbar=no,width=850,height=550,menubar=no,resizable=yes,location=no,scrollbars=yes,left=0,top=0'" + ")</script>";
            Page.Controls.Add(lbl);
        }
    }
}