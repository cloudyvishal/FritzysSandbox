
using BCL.Utility.GlobalFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FritzysPetCareProsSandbox.Admin
{
    public partial class AddServiceLocation : System.Web.UI.Page
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
            try
            {
                Global ObjGlobal = new Global();

                int Count = ObjGlobal.AddZipCode(txtZipCode.Text.Trim(), txtCity.Text.Trim(), txtState.Text.Trim(), Convert.ToInt32(ddlStatus.SelectedValue), ddlZipType.SelectedValue.ToString());
                
                if (Count == 1)
                {
                    SuccesfullMessage("Zip Code added successfully");
                   
                    txtZipCode.Text = "";
                    
                    txtCity.Text = "";
                   
                    txtState.Text = "";

                }
                else
                {
                    ErrMessage("Duplicate Zip Code");
                }
            } finally{}
        }
    }
}