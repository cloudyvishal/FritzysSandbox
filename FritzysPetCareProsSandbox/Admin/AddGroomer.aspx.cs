using BCL.Admin.GroomerMngmt;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FritzysPetCareProsSandbox.Admin
{
    public partial class AddGroomer : System.Web.UI.Page
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Groomer ObjGroomer = new Groomer();

                int Count = ObjGroomer.AddGroomer(txtEmailID.Text.Trim(), txtPassword.Text.Trim(), txtName.Text.Trim(), txtAddress.Text.Trim(), txtHomePhone.Text.Trim(), txtPersonalCell.Text.Trim(), txtZipCode.Text, txtSheetName.Text, txtBaseCity.Text, txtState.Text, ddlTimeZone.SelectedValue.ToString());
               
                if (Count == 2)
                {
                    SuccesfullMessage("Groomer updated successfully.");

                    txtEmailID.Text = "";

                    txtPassword.Text = "";

                    txtName.Text = "";

                    txtAddress.Text = "";

                    txtHomePhone.Text = "";

                    txtPersonalCell.Text = "";

                    txtZipCode.Text = "";

                    txtSheetName.Text = "";

                    txtState.Text = "";

                    txtBaseCity.Text = "";
                }
                if (Count == 0)
                {
                    ErrMessage("Duplicate email id.");
                }
                if (Count == 1)
                {
                    ErrMessage("Duplicate sheet name.");
                }
            } finally{}
        }
    }
}