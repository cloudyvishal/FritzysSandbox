using System;
using System.Web;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

using BCL.Utility.Contents;
using BCL.Admin.StoreFrontMgr;

namespace FritzysPetCareProsSandbox
{
    public partial class ServiceDetails : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int ServiceID = Convert.ToInt32(Request.QueryString["ID"].ToString());

                int PageID = Convert.ToInt32(Request.QueryString["Page"].ToString());

                BindData(ServiceID, PageID);
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
            } finally{}
        }
    }
}