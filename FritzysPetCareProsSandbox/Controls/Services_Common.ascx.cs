﻿using System;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

using BCL.Utility.Contents;
using BCL.Admin.StoreFrontMgr;

namespace FritzysPetCarePros.Controls
{
    public partial class Services_Common : BaseUserControl
    {
        PagedDataSource PageDs = new PagedDataSource();

        PagedDataSource PageDsCat = new PagedDataSource();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        
        public void BindData()
        {
            // Dataset will countain 4 table 0 - all cat services,
            // Table 1 - all dog services, 
            // Table 2 - Dog main service which is displayed on homepage 
            // Table 3 - cat main service which is displayed on homepage

            StoreFront ObjService = null;

            DataSet ds = null;

            StoreFront ObjStoreFront = null;

            DataSet ds_Service = null;

            try
            {
                ObjService = new StoreFront();

                ds = new DataSet();

                ObjStoreFront = new StoreFront();

                ds_Service = new DataSet();

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

                        lnkPrev.Visible = false;

                        lnkNext.Visible = true;

                    }
                    else if (PageDs.IsLastPage)
                    {
                        check = true;

                        lnkPrev.Visible = true;

                        lnkNext.Visible = false;
                    }
                    if (PageDs.PageCount == 1)
                    {
                        lnkPrev.Visible = false;

                        lnkNext.Visible = false;

                        lnkPrev.CssClass = "inactivelink";

                        lnkNext.CssClass = "inactivelink";
                    }
                    else if (PageDs.PageCount > 1 && check == false)
                    {
                        lnkPrev.Visible = true;

                        lnkNext.Visible = true;
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
                    if ((lnkPrev.Visible == true) && (lnkNext.Visible == true))
                    {
                        lblDivider.Visible = true;
                    }
                    else
                    {
                        lblDivider.Visible = false;
                    }
                }
                else
                {
                    dlDog.Visible = false;

                    lnkPrev.Visible = false;

                    lnkNext.Visible = false;
                }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    int currpage;

                    PageDsCat.DataSource = ds.Tables[0].DefaultView;

                    PageDsCat.AllowPaging = true;

                    PageDsCat.PageSize = 50;

                    if (ViewState["CurrentPage_Cat"] != null)
                    {
                        currpage = Convert.ToInt32(ViewState["CurrentPage_Cat"]);
                    }
                    else
                    {
                        currpage = 1;
                    }

                    ViewState["CurrentPage_Cat"] = currpage;

                    PageDsCat.CurrentPageIndex = currpage - 1;

                    bool check = false;

                    if (PageDsCat.IsFirstPage)
                    {
                        check = true;

                        lnkPrev_Cat.Visible = false;

                        lnkNext_Cat.Visible = true;

                    }
                    else if (PageDsCat.IsLastPage)
                    {
                        check = true;

                        lnkPrev_Cat.Visible = true;

                        lnkNext_Cat.Visible = false;
                    }
                    if (PageDsCat.PageCount == 1)
                    {
                        lnkPrev_Cat.Visible = false;

                        lnkNext_Cat.Visible = false;

                        lnkPrev_Cat.CssClass = "inactivelink";

                        lnkNext_Cat.CssClass = "inactivelink";
                    }
                    else if (PageDsCat.PageCount > 1 && check == false)
                    {
                        lnkPrev_Cat.Visible = true;

                        lnkNext_Cat.Visible = true;
                    }
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        dlCat.Visible = false;
                    }
                    else
                    {
                        Session["PDSAllNewestProviders_Cat"] = PageDsCat;

                        dlCat.DataSource = PageDsCat;

                        dlCat.DataBind();
                    }

                    if ((lnkPrev_Cat.Visible == true) && (lnkNext_Cat.Visible == true))
                    {
                        lblLink_Cat.Visible = true;
                    }
                    else
                    {
                        lblLink_Cat.Visible = false;
                    }

                }
                else
                {
                    dlCat.Visible = false;
                }

                if (Request.Cookies["IsLogin"].Value.ToString() == "0")
                {
                    ds_Service = ObjStoreFront.GetAllServicePageServices(4);
                }
                else
                {
                    ds_Service = ObjStoreFront.GetAllServicePageServices(Convert.ToInt32(Session["UserType"].ToString()));
                }
                if (ds_Service.Tables[1].Rows.Count > 0)
                {
                    ImgDog.ImageUrl = Session["HomePath"] + "StoreData/ServicePageServices/" + ds_Service.Tables[1].Rows[0]["ImageName"].ToString();

                    ImgDog.ToolTip = ds_Service.Tables[1].Rows[0]["Description"].ToString();

                    divDogService.InnerText = ds_Service.Tables[1].Rows[0]["Description"].ToString();
                }
                if (ds_Service.Tables[0].Rows.Count > 0)
                {
                    imgCatservice.ImageUrl = Session["HomePath"] + "StoreData/ServicePageServices/" + ds_Service.Tables[0].Rows[0]["ImageName"].ToString();

                    imgCatservice.ToolTip = ds_Service.Tables[0].Rows[0]["Description"].ToString();

                    divCatService.InnerText = ds_Service.Tables[0].Rows[0]["Description"].ToString();
                }
            }
            finally
            {
                ObjService = null;

                ObjStoreFront = null;

                ds_Service.Dispose();

                ds.Dispose();
            }

        }

        protected void lnkPrev_Cat_Click(object sender, EventArgs e)
        {
            PageDsCat = (PagedDataSource)Session["PDSAllNewestProviders_Cat"];

            if (!PageDsCat.IsFirstPage)
            {
                int currPage = (Convert.ToInt32(ViewState["CurrentPage_Cat"])) - 1;

                ViewState["CurrentPage_Cat"] = currPage.ToString();

                BindData();
            }
        }

        protected void lnkNext_Cat_Click(object sender, EventArgs e)
        {
            PageDsCat = (PagedDataSource)Session["PDSAllNewestProviders_Cat"];

            if (!PageDsCat.IsLastPage)
            {
                int currPage = (Convert.ToInt32(ViewState["CurrentPage_Cat"])) + 1;

                ViewState["CurrentPage_Cat"] = currPage.ToString();

                BindData();
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