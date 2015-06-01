using BCL.Admin.StoreFrontMgr;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MobileWeb.MB_Controls
{
    public partial class Services_Dog : System.Web.UI.UserControl
    {
        PagedDataSource PageDs = new PagedDataSource();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();

                BindHeader();
            }
        }

        public void BindData()
        {
            StoreFront ObjService = null;

            try
            {
                ObjService = new StoreFront();

                DataSet ds = new DataSet();

                ds = ObjService.GetAllCatDogService();

                if (ds.Tables[1].Rows.Count > 0)
                {
                    int currpage;

                    PageDs.DataSource = ds.Tables[1].DefaultView;

                    PageDs.AllowPaging = true;

                    PageDs.PageSize = 50;

                    if (ViewState["CurrentPage"] != null)
                    {
                        currpage = Convert.ToInt32(ViewState["CurrentPage"]);
                    }
                    else
                    {
                        currpage = 1;
                    }

                    ViewState["CurrentPage"] = currpage;

                    PageDs.CurrentPageIndex = currpage - 1;

                    bool check = false;
                    if (PageDs.IsFirstPage)
                    {
                        check = true;
                    }
                    else if (PageDs.IsLastPage)
                    {
                        check = true;
                    }
                    if (PageDs.PageCount == 1)
                    {

                    }
                    else if (PageDs.PageCount > 1 && check == false)
                    {

                    }
                    if (ds.Tables[1].Rows.Count == 0)
                    {
                        dlDog.Visible = false;
                    }
                    else
                    {
                        Session["PDSAllNewestProviders"] = PageDs;

                        dlDog.DataSource = PageDs;

                        dlDog.DataBind();
                    }
                }
                else
                {
                    dlDog.Visible = false;
                }
                if (ds.Tables[3].Rows.Count > 0)
                {

                }
            }
            finally
            {
                ObjService = null;
            }
        }

        public void BindHeader()
        {
            StoreFront ObjStoreFront = null;

            DataSet ds = null;

            try
            {
                ObjStoreFront = new StoreFront();

                ds = new DataSet();

                if (!(null == Request.Cookies["IsLogin"]))
                {
                    ds = ObjStoreFront.GetServicePageServices(Convert.ToInt32(Session["UserType"].ToString()), 2);

                    if ((ds.Tables[0].Rows.Count > 0) && (ds.Tables[0].Rows[0]["PetType"].ToString() == "2"))
                    {
                        imgDogservice.ImageUrl = Session["HomePathValue"] + "StoreData/ServicePageServices/" + ds.Tables[0].Rows[0]["ImageName"].ToString();

                        imgDogservice.ToolTip = ds.Tables[0].Rows[0]["Description"].ToString();

                        divDogService.InnerHtml = ds.Tables[0].Rows[0]["Description"].ToString();
                    }
                }
                else
                {
                    ds = ObjStoreFront.GetServicePageServices(4, 2);

                    if ((ds.Tables[0].Rows.Count > 0) && (ds.Tables[0].Rows[0]["PetType"].ToString() == "2"))
                    {
                        imgDogservice.ImageUrl = Session["HomePath"] + "StoreData/ServicePageServices/" + ds.Tables[0].Rows[0]["ImageName"].ToString();

                        imgDogservice.ToolTip = ds.Tables[0].Rows[0]["Description"].ToString();

                        divDogService.InnerHtml = ds.Tables[0].Rows[0]["Description"].ToString();
                    }
                }
            }
            finally
            {
                ObjStoreFront = null;

                ds.Dispose();
            }
        }

        protected void lnkPrev_Click(object sender, EventArgs e)
        {
            PageDs = (PagedDataSource)Session["PDSAllNewestProviders"];

            if (!PageDs.IsFirstPage)
            {
                int currPage = (Convert.ToInt32(ViewState["CurrentPage"])) - 1;

                ViewState["CurrentPage"] = currPage.ToString();

                BindData();
            }
        }

        protected void lnkNext_Click(object sender, EventArgs e)
        {
            PageDs = (PagedDataSource)Session["PDSAllNewestProviders"];

            if (!PageDs.IsLastPage)
            {
                int currPage = (Convert.ToInt32(ViewState["CurrentPage"])) + 1;

                ViewState["CurrentPage"] = currPage.ToString();

                BindData();
            }
        }
    }
}