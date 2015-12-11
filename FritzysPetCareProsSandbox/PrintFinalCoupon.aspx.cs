using System;
using System.Web;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using FritzysPetCarePros.Controls;

using BCL.Admin.BannerMgr;
using BCL.Utility.Contents;

namespace FritzysPetCareProsSandbox
{
    public partial class PrintFinalCoupon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ImgName = "";
            string ImagePath;
            try
            {
                ImgName = Request.QueryString["CouponID"].ToString();
            }
            catch (Exception ex)
            {
            }
            Banners newObj = new Banners();
            DataSet ds = newObj.GetBannerImageNameandpath(Convert.ToInt32(Request.QueryString["CouponID"].ToString()));
            ImagePath = Session["HomePath"] + "StoreData/BannerNew/" + ds.Tables[0].Rows[0]["BannerName"].ToString();

            string imagepath = ImagePath;
            string fulpath = ContentManager.GetPhysicalPath(imagepath);
            if (System.IO.File.Exists(fulpath))
            {
                ImgGift.ImageUrl = imagepath;
            }
        }
    }
}