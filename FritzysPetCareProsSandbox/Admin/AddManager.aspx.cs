using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BCL.Users.Management;

namespace FritzysPetCareProsSandbox.Admin
{
    public partial class AddManager : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void ErrMessage(string Message)
        {
            divError.Visible = true;

            lblError.Attributes.Add("Class", "errorTable");

            lblError.Visible = true;

            lblError.Text = Message;
        }

        public void SuccesfullMessage(string Message)
        {
            divError.Visible = true;

            lblError.Attributes.Add("Class", "successTable");

            lblError.Visible = true;

            lblError.Text = Message;
        }

        protected void AddUser_Click(object sender, EventArgs e)
        {
            User ObjUser = null;

            try
            {
                ObjUser = new User();

                int Count = ObjUser.AddAdminUser(txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtUserName.Text.Trim(), txtPassword.Text.Trim(), txtEmail.Text.Trim(), txtPhone.Text.Trim(), txtAddress1.Text.Trim(), txtAddress2.Text.Trim(), 1);
                if (Count == 1)
                {
                    SuccesfullMessage("Manager added successfully");
                    txtFirstName.Text = "";
                    txtLastName.Text = "";
                    txtUserName.Text = "";
                    txtPassword.Text = "";
                    txtEmail.Text = "";
                    txtPhone.Text = "";
                    txtAddress1.Text = "";
                    txtAddress2.Text = "";
                }
                else
                {
                    ErrMessage("Duplicate username or Email");
                }
            }
            finally
            {
                ObjUser = null;
            }
        }
    }
}