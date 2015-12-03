using System;
using System.Web;
using System.Data;
using System.Web.UI;

using BCL.Utility.GlobalFunctions;

namespace FritzysPetCarePros.Controls
{
    public partial class ZipCode : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MemberName"] != null)
            {
                lblWelcome.Text = "Welcome - " + Session["MemberName"].ToString();
            }
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Global ObjZipcode = null;

            DataSet ds = null;

            try
            {
                PanelFiveImg.Attributes.Add("Style", "display: block");

                if (txtZip.Text == "")
                {
                    lblResult.Text = "Please enter zipcode";

                    btnOk.Visible = false;

                    btnCancel.Visible = true;
                }
                else
                {
                    btnCancel.Visible = false;

                    btnOk.Visible = true;

                    ObjZipcode = new Global();

                    ds = new DataSet();

                    ds = ObjZipcode.GetZipCodeFront(txtZip.Text.Trim());

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblResult.Text = txtZip.Text + " Yes we provide service in this area";

                        ViewState["IsZip"] = "1";
                    }
                    else
                    {
                        lblResult.Text = "We’re sorry, we aren’t yet in that area. Please join Fritzy’s Club and we will let you know as soon as we are.";

                        ViewState["IsZip"] = "0";

                        txtZip.Text = "";
                    }
                }
            }
            finally
            {
                ObjZipcode = null;

                ds.Dispose();
            }
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}