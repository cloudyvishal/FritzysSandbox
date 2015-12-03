using System;
using System.Web;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

using BCL.Utility.GlobalFunctions;

namespace FritzysPetCarePros.Controls
{
    public partial class TestZip : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MemberName"] != null)
            {
                divUserName.Attributes.Add("style", "Display:block");

                lblWelcome.Text = "Welcome - " + Session["MemberName"].ToString();
            }
            else
            {
                divUserName.Attributes.Add("style", "Display:none");
            }
        }

        protected void btnSumbmit_Click(object sender, EventArgs e)
        {
            if (!(null == ViewState["Zip"]))
            {
                if (ViewState["Zip"].ToString() == "0")
                {
                    Response.Redirect("Services.aspx");
                }
                else
                {
                    Response.Redirect("Index.aspx");
                }
            }
        }

        protected void btnTest_Click1(object sender, EventArgs e)
        {
            lblShow.Text = "Ok";
            //ModelZip.Show();
        }

        protected void btnSuggestion_Click(object sender, EventArgs e)
        {
            if (ViewState["Zip"].ToString() == "0")
            {
                Response.Redirect("Index.aspx");
            }
            else
            {
                Response.Redirect("Services.aspx");
            }
        }

        protected void imgZipcode_Click(object sender, ImageClickEventArgs e)
        {
            Global ObjZipcode = null;

            try
            {
                if (txtZip.Text.Trim() == "")
                {
                    lblShow.Text = "Please enter zipcode";

                    lblShow.CssClass = "invalidzip";

                    lblZipcode.Text = "";
                }
                else
                {
                    ObjZipcode = new Global();

                    DataSet ds = new DataSet();

                    ds = ObjZipcode.GetZipCodeFront(txtZip.Text.Trim());

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblZipcode.Text = "Zip code :" + txtZip.Text;

                        lblShow.Text = " Yes we provide service in this area";

                        lblShow.CssClass = "zipmsg";

                        ViewState["Zip"] = "0";
                    }
                    else
                    {
                        lblZipcode.Text = "Zip code :" + txtZip.Text;

                        lblShow.Text = " - We’re sorry, we are not yet in that area. Please join Fritzy’s Club and we will let you know as soon as we are.";

                        lblShow.CssClass = "invalidzip";

                        ViewState["Zip"] = "1";
                    }

                }
                ModelZip.Show();
            }
            finally
            {
                ObjZipcode = null;
            }
        }
    }
}