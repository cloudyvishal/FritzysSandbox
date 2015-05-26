using BCL.Utility.Contents;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FritzysPetCareProsSandbox
{
    public partial class VisitOurVan : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            litContent.Text = ContentManager.GetFileContentView(ContentManager.GetPhysicalPath(ConfigurationManager.AppSettings["HomePathValue"].ToString() + "StoreData/StaticeContent/VisitOurVan.htm"));
        }
    }
}