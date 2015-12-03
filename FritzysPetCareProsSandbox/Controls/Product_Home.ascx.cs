using System;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;

using BCL.Admin.ProductMgr;
using BCL.Utility.Contents;

namespace FritzysPetCarePros.Controls
{
    public partial class Product_Home : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected void dlProducts_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if ((e.Item.ItemType != ListItemType.Header) && (e.Item.ItemType != ListItemType.Footer))
            {
                Label lblImageName = (Label)e.Item.FindControl("lblImage");

                HtmlImage ImgProduct = (HtmlImage)e.Item.FindControl("ImgProduct");

                string imagepath = Session["HomePath"] + "StoreData/Product/" + lblImageName.Text;

                string fulpath = ContentManager.GetPhysicalPath(imagepath);

                if (System.IO.File.Exists(fulpath))
                {
                    ImgProduct.Src = Session["HomePath"] + "StoreData/Product/" + lblImageName.Text;
                }
                else
                {
                }
            }
        }

        public void BindData()
        {
            Products ObjProducts = null;

            DataSet ds = new DataSet();

            try
            {
                ObjProducts = new Products();

                ds = ObjProducts.GetAllProductsHomeFront();

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

                ds = null;
            }
        }
    }
}