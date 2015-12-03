using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MobileWeb.Shared.CommonValues;
using BCL.Utility.Contents;
using System.Data;
using BCL.Admin.StoreFrontMgr;


namespace MobileWeb
{
    public partial class Cat_Blueberry_Facial : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData((int)(Enumeration.ServiceId.CAT_BLUEBERRY_FACIAL_SERVICEID), (int)(Enumeration.ServiceId.COMMON_PAGE_ID));
            }
        }

        public void BindData(int ServiceID, int PageID)
        {
            StoreFront ObjService = new StoreFront();
            DataSet ds = new DataSet();
            ds = ObjService.GetServiceDetailFront(ServiceID, PageID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (PageID == 1)
                {
                    ImgService.ImageUrl = Session["HomePath"] + "StoreData/Images/" + ds.Tables[0].Rows[0]["Image"].ToString();
                    lblTitle.Text = ds.Tables[0].Rows[0]["ServiceTitle"].ToString();
                    Page.Title = ds.Tables[0].Rows[0]["ServiceTitle"].ToString();
                    lblServiceDesc.Text = ds.Tables[0].Rows[0]["ServiceDescription"].ToString();
                    litContent.Text = ContentManager.GetFileContentView(ContentManager.GetPhysicalPath(Session["HomePath"] + "StoreData/" + ds.Tables[0].Rows[0]["PageName"].ToString()));
                }
                if (PageID == 2)
                {
                    ImgService.ImageUrl = Session["HomePath"] + "StoreData/HomeServices/" + ds.Tables[0].Rows[0]["Image"].ToString();
                    lblTitle.Text = ds.Tables[0].Rows[0]["ServiceTitle"].ToString();
                    Page.Title = ds.Tables[0].Rows[0]["ServiceTitle"].ToString();
                    lblServiceDesc.Text = ds.Tables[0].Rows[0]["ServiceDescription"].ToString();
                }
                if (PageID == 3)
                {
                    ImgService.ImageUrl = Session["HomePath"] + "StoreData/ServicePageServices/" + ds.Tables[0].Rows[0]["Image"].ToString();
                    lblTitle.Text = ds.Tables[0].Rows[0]["ServiceTitle"].ToString();
                    Page.Title = ds.Tables[0].Rows[0]["ServiceTitle"].ToString();
                    lblServiceDesc.Text = ds.Tables[0].Rows[0]["ServiceDescription"].ToString();
                }
            }
            else
            {

            }

        }
    }
}