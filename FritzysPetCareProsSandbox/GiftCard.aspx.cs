using BCL.Utility.Contents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FritzysPetCareProsSandbox
{
    public partial class GiftCard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            litContent.Text = ContentManager.GetFileContentView(ContentManager.GetPhysicalPath(Session["HomePath"] + "StoreData/StaticeContent/GiftCard.htm"));
        }
    }
}