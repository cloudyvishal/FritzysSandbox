﻿using System;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;

using BCL.Admin.StoreFrontMgr;
using BCL.Utility.GlobalFunctions;
using System.Configuration;

namespace FritzysPetCarePros.Pages.Master
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Global ObjGlobal = null;

            DataSet ds_Meta = null;

            DataSet ds = null;

            StoreFront objStoreFront = null;

            try
            {
                if (Request.Cookies["IsLogin"] == null)
                {
                    HttpCookie c = new HttpCookie("IsLogin", "0");

                    c.Expires = new DateTime(2015, 12, 1);

                    Response.Cookies.Add(c);
                }

                if ((Request.Cookies["remUsername"] != null) && (Request.Cookies["remPassword"] != null) && (Request.Cookies["IsLogin"].Value.ToString() == "1"))
                {
                    if ((Session["MemberName"] == null) || (Session["UserID"] == null) || Session["UserType"] == null)
                    {
                        string UserName = Request.Cookies["remUsername"].Value.ToString();

                        string Password = Request.Cookies["remPassword"].Value.ToString();

                        objStoreFront = new StoreFront();

                        ds = new DataSet();

                        ds = objStoreFront.GetLoginUser(UserName, Password);

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            Session["MemberName"] = ds.Tables[0].Rows[0]["FullName"].ToString();

                            Session["UserID"] = ds.Tables[0].Rows[0]["UserID"].ToString();

                            Session["UserType"] = ds.Tables[0].Rows[0]["UserType"].ToString();

                            Session["IsLogin"] = "1";
                        }
                    }
                }

                if (Session["MemberName"] != null)
                {
                    Control bodyCntrl = LoadControl("../Controls/Header_Logout.ascx");

                    PhHeader.Controls.Add(bodyCntrl);
                }
                else
                {
                    Control bodyCntrl = LoadControl("../Controls/Header_Login.ascx");

                    PhHeader.Controls.Add(bodyCntrl);
                }

                string sPath = GetCurrentPageName();

                ObjGlobal = new Global();

                ds_Meta = ObjGlobal.GetMetaFront(sPath);

                if (ds_Meta.Tables[0].Rows.Count > 0)
                {

                    DataRow row = ds_Meta.Tables[0].Rows[0];

                    string Description = Convert.ToString(row["MetaContent"]);

                    string Keywords = Convert.ToString(row["Keywords"]);

                    if (Description != string.Empty)
                    {
                        HtmlMeta meta = new HtmlMeta();

                        meta.Name = "Description";

                        meta.Content = Description;

                        Page.Header.Controls.Add(meta);

                    }
                    if (Keywords != string.Empty)
                    {
                        HtmlMeta Keyword = new HtmlMeta();

                        Keyword.Name = "keywords";

                        Keyword.Content = Keywords;

                        Page.Header.Controls.Add(Keyword);

                    }

                }
                if (ds_Meta.Tables[1].Rows.Count > 0)
                {
                    Page.Title = ds_Meta.Tables[1].Rows[0]["PageTitle"].ToString();
                }
            }
            finally
            {
                objStoreFront = null;

                ObjGlobal = null;
            }
        }

        public string GetCurrentPageName()
        {
            string pageUrl = Request.Url.PathAndQuery.ToString().ToLower();

            char[] separator = new char[] { '/' };

            string[] str = pageUrl.Split(separator);

            int i = str[str.Length - 1].LastIndexOf('?');

            if (i == -1)
            {
                pageUrl = str[str.Length - 1].ToString();
            }
            else
            {
                pageUrl = str[str.Length - 1].Substring(0, i);
            }

            return pageUrl;
        }
    }
}