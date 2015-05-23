using BCL.Utility.GlobalFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FritzysPetCareProsSandbox.Admin
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnApply_Click(object sender, EventArgs e)
        {
            Global ObjGlobal = null;

            try
            {
                ObjGlobal = new Global();

                int i = ObjGlobal.ChangeUserName(Convert.ToInt32(Session["UserID"].ToString()), txtCurrentPassword.Text.Trim(), txtNewPassword.Text.Trim());

                if (i == 0)
                {
                    ErrMessage("Please enter correct password.");

                }
                else
                {
                    SuccesfullMessage("Password changed successfully.");
                }
            }
            finally
            {
                ObjGlobal = null;
            }
        }

        public void ErrMessage(string Message)
        {
            divError.Visible = true;
            divError.Attributes.Add("Class", "errorTable");
            lblError.Visible = true;
            lblError.Text = Message;
        }

        public void SuccesfullMessage(string Message)
        {
            divError.Visible = true;
            divError.Attributes.Add("Class", "successTable");
            lblError.Visible = true;
            lblError.Text = Message;
        }
    }
}