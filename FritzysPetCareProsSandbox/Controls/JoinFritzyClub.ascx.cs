using System;
using System.Web;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

namespace FritzysPetCarePros.Controls
{
    public partial class JoinFritzyClub : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MemberName"] != null)
            {
                ImgRegORMyAccount.ImageUrl = Session["HomePath"] + "Images/myaccount.jpg";

                ImgRegORMyAccount.ToolTip = "MY ACCOUNT";
            }
            else
            {
                ImgRegORMyAccount.ImageUrl = Session["HomePath"] + "Images/join_fritzys_club.jpg";

                ImgRegORMyAccount.ToolTip = "JOIN FRITZY'S CLUB";
            }
        }

        protected void ImgRegORMyAccount_Click(object sender, ImageClickEventArgs e)
        {
            if (Session["MemberName"] != null)
            {
                Response.Redirect(Session["HomePath"] + "MyAccount.aspx");
            }
            else
            {
                Response.Redirect(Session["HomePath"] + "Registration.aspx");
            }
        }
    }
}