
using BCL.Utility.GlobalFunctions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FritzysPetCareProsSandbox.Admin
{
    public partial class ContactUsDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    int ContatID = 0;

                    if (Request.QueryString["ID"].ToString() != "")
                    {
                        ContatID = int.Parse(Request.QueryString["ID"].ToString());

                        Bind(ContatID);

                    }
                }
                finally
                { }
            }
        }

        public void Bind(int ContatID)
        {
            try
            {
                Global Obj_Global = new Global();

                DataSet ds = new DataSet();

                ds = Obj_Global.GetContactInfo(ContatID);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblFName.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();

                        lblLName.Text = ds.Tables[0].Rows[0]["LastName"].ToString();

                        lblEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();

                        lblPhone.Text = ds.Tables[0].Rows[0]["Mobile"].ToString();

                        lblMessage.Text = ds.Tables[0].Rows[0]["Message"].ToString();
                    }
                }
            } finally{}
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["p"].ToString() == "1")
                Response.Redirect("AdminHome.aspx");
            else
                Response.Redirect("ContactUs.aspx?SearchFor=0&SearchText=");
        }
    }
}