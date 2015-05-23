using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BCL.Admin.StoreFrontMgr;
using System.Configuration;

namespace FritzysPetCareProsSandbox
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {          
            if (!IsPostBack)
            {
                try
                {
                    StoreFront objStoreFront = new StoreFront();

                    //string login = SessionManagement.UserType.ToString();

                    //Session["IsLogin"] = SessionManagement.IsLogin;

                    if (Session["MemberName"] != null)
                    {
                        divUserName.Attributes.Add("style", "Display:block");
                        lblWelcome.Text = "Welcome - " + Session["MemberName"].ToString();
                    }
                    else
                    {
                        divUserName.Attributes.Add("style", "Display:none");
                    }
                    if (Session["MemberName"] != null)
                    {
                        DataSet ds = new DataSet();
                        if (!(null == Session["UserName"]))
                        {
                            ds = objStoreFront.GetAppInfoforPayment(Session["UserName"].ToString());

                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                ctlZipcode.Visible = false;

                                imgbtnMakePayment.Visible = true;

                                Session["Amt"] = "";
                            }
                            else
                            {
                                imgbtnMakePayment.Visible = true;
                            }

                        }
                        else
                        {
                            ctlZipcode.Visible = true;
                            imgbtnMakePayment.Visible = false;
                        }
                    }
                    else
                    {
                        ctlZipcode.Visible = true;
                        imgbtnMakePayment.Visible = false;
                    }
                    BindData();
                }
                finally
                { }
            }
        }

        public void BindData()
        {
            StoreFront ObjStoreFront = null;

            DataSet ds = null;

            try
            {
                if (Request.Cookies["IsLogin"] == null)
                {
                    HttpCookie c = new HttpCookie("IsLogin", "0");
                    c.Expires = new DateTime(2015, 12, 1);
                    Response.Cookies.Add(c);
                }

                ObjStoreFront = new StoreFront();

                ds = new DataSet();

                if (Session["UserType"] == "4")
                {
                    ds = ObjStoreFront.GetHomePageServices(4);
                }
                else
                {
                    ds = ObjStoreFront.GetHomePageServices(Convert.ToInt32(Session["UserType"]));
                }

                if (ds.Tables.Count > 0)
                {
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
            finally
            {
                ObjStoreFront = null;
            }
        }

        protected void imgbtnMakePayment_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("http://localhost:50372/PayList.aspx");
        }
    }
}