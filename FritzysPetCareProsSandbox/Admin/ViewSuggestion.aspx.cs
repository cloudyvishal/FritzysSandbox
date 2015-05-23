
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
    public partial class ViewSuggestion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    int SuggestionID = 0;

                    if (Request.QueryString["SuggestionID"].ToString() != "")
                    {
                        SuggestionID = int.Parse(Request.QueryString["SuggestionID"].ToString());

                        Bind(SuggestionID);

                    }
                }
                finally
                { }
            }
        }

        public void Bind(int SuggestionID)
        {
            try
            {
                Global Obj_Global = new Global();

                DataSet ds = new DataSet();

                ds = Obj_Global.GetSuggestion(SuggestionID);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblName.Text = ds.Tables[0].Rows[0]["VisiterName"].ToString();

                    lblEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();

                    lblPhone.Text = ds.Tables[0].Rows[0]["Phone"].ToString();

                    lblComment.Text = ds.Tables[0].Rows[0]["Comment"].ToString();

                }
            } finally{}
        }
    }
}