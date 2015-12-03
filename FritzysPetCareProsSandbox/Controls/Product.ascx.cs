using System;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

using BCL.Admin.ProductMgr;
using BCL.Utility.Contents;
using System.Configuration;

namespace FritzysPetCarePros.Controls
{
    public partial class Product : BaseUserControl
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void BindData()
        {
            Products ObjProducts = null;

            DataSet ds = null;

            try
            {
                ObjProducts = new Products();

                ds = new DataSet();

                ds = ObjProducts.GetAllProductsFront();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    dlProducts.Visible = true;

                    dlProducts.DataSource = ds.Tables[0];

                    dlProducts.DataBind();
                }
                else
                {
                    dlProducts.Visible = false;
                }
            }
            finally
            {
                ObjProducts = null;

                ds.Dispose();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void dlProducts_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if ((e.Item.ItemType != ListItemType.Header) && (e.Item.ItemType != ListItemType.Footer))
            {
                Label lblImageName = (Label)e.Item.FindControl("lblImage");

                HtmlImage ImgProduct = (HtmlImage)e.Item.FindControl("ImgProduct");

                string imagepath = ConfigurationManager.AppSettings["HomePathValue"] + "StoreData/Product/" + lblImageName.Text;

                string fulpath = ContentManager.GetPhysicalPath(imagepath);

                if (System.IO.File.Exists(fulpath))
                {
                    ImgProduct.Src = ConfigurationManager.AppSettings["HomePathValue"] + "StoreData/Product/" + lblImageName.Text;
                }
                else
                {
                    //ImgProduct.Src = Session["HomePath"] + "StoreData/Product/Not.jpg";
                }
            }
        }
    }
}