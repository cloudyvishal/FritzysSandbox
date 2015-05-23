using BCL.Admin.StoreFrontMgr;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FritzysPetCareProsSandbox
{
    public partial class FleaTick : BasePage
    {
        public void ErrMessage(string Message)
        {
            divError.Visible = true;
            divError.Attributes.Add("Class", "errorTable");
            lblError.Visible = true;
            lblError.Text = Message;
        }
        public void SuccesfullMessage(string Message)
        {
            divError.Visible = true;
            divError.Attributes.Add("Class", "successTable");
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
                    HttpContext.Current.Response.Status = "301 Moved Permanently";
                    HttpContext.Current.Response.AddHeader("Location",
                    Request.Url.ToString().Replace(Request.Url.ToString(), ("http://localhost:50372/fritzymobile/MB_Flea-Tick.aspx").ToLower()));
                }

                else
                {                   
                    BindData();
                }
            }
        }

        public void BindData()
        {
            StoreFront ObjStoreFront = new StoreFront();
            DataSet ds = new DataSet();
            if (SessionManagement.UserType.ToString() == "4")
            {
                ds = ObjStoreFront.GetFleaandTickServices(4);
            }
            else
            {
                ds = ObjStoreFront.GetFleaandTickServices(Convert.ToInt32(SessionManagement.UserType.ToString()));
            }

            if ((ds.Tables[0].Rows.Count > 0) && (ds.Tables[0].Rows[0]["PetType"].ToString() == "1"))
            {
                divCatService.InnerHtml = ds.Tables[0].Rows[0]["Description"].ToString();
                imgCatservice.ImageUrl = Session["HomePath"] + "StoreData/HomeServices/" + ds.Tables[0].Rows[0]["ImageName"].ToString();
                imgCatservice.ToolTip = ds.Tables[0].Rows[0]["Description"].ToString();
            }
            if ((ds.Tables[0].Rows.Count > 0) && (ds.Tables[0].Rows[1]["PetType"].ToString() == "2"))
            {
                divDogService.InnerHtml = ds.Tables[0].Rows[1]["Description"].ToString();
                imgDogservice.ImageUrl = Session["HomePath"] + "StoreData/HomeServices/" + ds.Tables[0].Rows[1]["ImageName"].ToString();
                imgDogservice.ToolTip = ds.Tables[0].Rows[1]["Description"].ToString();
            }
        }
    }
}