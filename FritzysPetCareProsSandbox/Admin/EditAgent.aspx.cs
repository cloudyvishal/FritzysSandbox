using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BCL.Users.Management;

namespace FritzysPetCareProsSandbox.Admin
{
    public partial class EditAgent : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["UserId"] != "")
                {
                    int UserID = int.Parse(Request.QueryString["UserID"]);

                    Bind(UserID);
                }
                else
                {
                    Response.Redirect("ManageUser.aspx");
                }
            }
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

        public void Bind(int UserID)
        {
            DataSet ds = null;

            User ObjUser = null;

            try
            {
                ds = new DataSet();

                ObjUser = new User();

                ds = ObjUser.GetUserDetail(UserID);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtFirstName.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();

                    txtLastName.Text = ds.Tables[0].Rows[0]["LastName"].ToString();

                    txtUserName.Text = ds.Tables[0].Rows[0]["Username"].ToString();

                    lblUserName.Text = ds.Tables[0].Rows[0]["Username"].ToString();

                    txtPassword.Text = ds.Tables[0].Rows[0]["Password"].ToString();

                    txtConfirmPassword.Text = ds.Tables[0].Rows[0]["Password"].ToString();

                    txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();

                    lblEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();

                    txtPhone.Text = ds.Tables[0].Rows[0]["Phone"].ToString();

                    txtAddress1.Text = ds.Tables[0].Rows[0]["Address1"].ToString();

                    txtAddress2.Text = ds.Tables[0].Rows[0]["Address2"].ToString();
                }
                else
                {

                }
            }
            finally
            {
                ObjUser = null;

                ds.Dispose();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            User ObjUser = null;

            try
            {
                ObjUser = new User();

                int Count = ObjUser.UpdateAdminUser(int.Parse(Request.QueryString["UserID"]), txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtUserName.Text.Trim(), txtPassword.Text.Trim(), txtEmail.Text.Trim(), txtPhone.Text.Trim(), txtAddress1.Text.Trim(), txtAddress2.Text.Trim(), 2);
               
                SuccesfullMessage("User updated successfully");
            }
            finally
            {
                ObjUser = null;
            }
        }
    }
}