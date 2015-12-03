using BCL.Admin.StoreFrontMgr;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MobileWeb
{
    public partial class MB_Flea_Tick : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserType"].ToString() != "0")
            {
                if (!IsPostBack)
                {
                    BindData();
                }
            }
            else
            {
                Session["UserType"] = "3";

                if (!IsPostBack)
                {
                    BindData();
                }
            }
        }

        public void BindData()
        {
            StoreFront ObjStoreFront = new StoreFront();
            DataSet ds = new DataSet();
            if (Session["UserType"].ToString() == "4")
            {
                ds = ObjStoreFront.GetFleaandTickServices(4);
            }
            else
            {
                ds = ObjStoreFront.GetFleaandTickServices(Convert.ToInt32(Session["UserType"].ToString()));
            }

            if ((ds.Tables[0].Rows.Count > 0) && (ds.Tables[0].Rows[0]["PetType"].ToString() == "1"))
            {
                divCatService.Text = ds.Tables[0].Rows[0]["Description"].ToString();
                imgCatservice.ImageUrl = Session["HomePath"] + "StoreData/HomeServices/" + ds.Tables[0].Rows[0]["ImageName"].ToString();
                imgCatservice.ToolTip = ds.Tables[0].Rows[0]["Description"].ToString();
            }
            if ((ds.Tables[0].Rows.Count > 0) && (ds.Tables[0].Rows[1]["PetType"].ToString() == "2"))
            {
                divDogService.Text = ds.Tables[0].Rows[0]["Description"].ToString();
                imgDogservice.ImageUrl = Session["HomePath"] + "StoreData/HomeServices/" + ds.Tables[0].Rows[1]["ImageName"].ToString();
                imgDogservice.ToolTip = ds.Tables[0].Rows[1]["Description"].ToString();
            }


        }
    }
}