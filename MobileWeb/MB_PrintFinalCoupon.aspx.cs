using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BCL.Utility.Contents;
using BCL.Admin.BannerMgr;

namespace MobileWeb
{
    public partial class MB_PrintFinalCoupon : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ImgName = "";

            string ImagePath;

            Banners newObj = null;

            DataSet ds = null;

            try
            {
                ImgName = Request.QueryString["CouponID"].ToString();

                newObj = new Banners();

                ds = new DataSet();

                ds = newObj.GetBannerImageNameandpath(Convert.ToInt32(Request.QueryString["CouponID"].ToString()));

                ImagePath = Session["HomePath"] + "StoreData/BannerNew/" + ds.Tables[0].Rows[0]["BannerName"].ToString();

                string imagepath = ImagePath;

                string fulpath = ContentManager.GetPhysicalPath(imagepath);

                if (System.IO.File.Exists(fulpath))
                {
                    ImgGift.ImageUrl = imagepath;
                }
            }
            finally
            {
                newObj = null;

                ds.Dispose();
            }
        }
    }
}