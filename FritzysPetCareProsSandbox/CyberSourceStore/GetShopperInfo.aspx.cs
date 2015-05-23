using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace CyberSourceStore
{
	/// <summary>
	/// Summary description for GetShopperInfo.
	/// </summary>
	public class GetShopperInfo : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Label Heading;
		protected System.Web.UI.WebControls.Label LabelEmail;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.Label Label14;
		protected System.Web.UI.WebControls.Label Label15;
		protected System.Web.UI.WebControls.Label Label16;
		protected System.Web.UI.WebControls.Label Label17;
		protected System.Web.UI.WebControls.Label Label19;
		protected System.Web.UI.WebControls.Label Label20;
		protected System.Web.UI.WebControls.TextBox BillCountry;
		protected System.Web.UI.WebControls.TextBox BillPhone;
		protected System.Web.UI.WebControls.TextBox BillZip;
		protected System.Web.UI.WebControls.TextBox BillState;
		protected System.Web.UI.WebControls.TextBox BillCity;
		protected System.Web.UI.WebControls.TextBox BillAddress2;
		protected System.Web.UI.WebControls.TextBox BillAddress1;
		protected System.Web.UI.WebControls.TextBox ShipCountry;
		protected System.Web.UI.WebControls.TextBox ShipPhone;
		protected System.Web.UI.WebControls.TextBox ShipZip;
		protected System.Web.UI.WebControls.TextBox ShipState;
		protected System.Web.UI.WebControls.TextBox ShipCity;
		protected System.Web.UI.WebControls.TextBox ShipAddress2;
		protected System.Web.UI.WebControls.TextBox ShipAddress1;
		protected System.Web.UI.WebControls.TextBox Email;
		protected System.Web.UI.WebControls.TextBox LastName;
		protected System.Web.UI.WebControls.TextBox FirstName;
		protected System.Web.UI.WebControls.Label ErrorMessage;
		protected System.Web.UI.WebControls.Label Label1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			Shopper shopper;
			Address billAddress, shipToAddress;

			if (!IsPostBack)
			{
				string errorMessage = (string) Session["ErrorMessage"];
				if (errorMessage != null)
				{
					// if coming back from a failed auth, display error message
					// and current shopper and address info.

					ErrorMessage.Text = errorMessage;
					Session.Remove( "ErrorMessage" );

					shopper = (Shopper) Session["Shopper"];
					billAddress = (Address) Session["BillAddress"];
					shipToAddress = (Address) Session["ShipToAddress"];
				}
				else
				{
					shopper = (Shopper) Session["DefaultShopper"];
					billAddress = (Address) Session["DefaultAddress"];
					shipToAddress = billAddress;
				}

				FirstName.Text = shopper.FirstName;
				LastName.Text  = shopper.LastName;
				Email.Text     = shopper.Email;

				BillAddress1.Text = billAddress.Address1;
				BillAddress2.Text = billAddress.Address2;
				BillCity.Text     = billAddress.City;
				BillState.Text    = billAddress.State;
				BillZip.Text      = billAddress.Zip;
				BillCountry.Text  = billAddress.Country;
				BillPhone.Text    = billAddress.Phone;

				ShipAddress1.Text = shipToAddress.Address1;
				ShipAddress2.Text = shipToAddress.Address2;
				ShipCity.Text     = shipToAddress.City;
				ShipState.Text    = shipToAddress.State;
				ShipZip.Text      = shipToAddress.Zip;
				ShipCountry.Text  = shipToAddress.Country;
				ShipPhone.Text    = shipToAddress.Phone;
			}
			else
			{
				shopper.FirstName = FirstName.Text;
				shopper.LastName  = LastName.Text;
				shopper.Email     = Email.Text;

				billAddress.Address1  = BillAddress1.Text;
				billAddress.Address2  = BillAddress2.Text;
				billAddress.City      = BillCity.Text;
				billAddress.State     = BillState.Text;
				billAddress.Zip       = BillZip.Text;
				billAddress.Country   = BillCountry.Text;
				billAddress.Phone     = BillPhone.Text;

				shipToAddress.Address1  = ShipAddress1.Text;
				shipToAddress.Address2  = ShipAddress2.Text;
				shipToAddress.City      = ShipCity.Text;
				shipToAddress.State     = ShipState.Text;
				shipToAddress.Zip       = ShipZip.Text;
				shipToAddress.Country   = ShipCountry.Text;
				shipToAddress.Phone     = ShipPhone.Text;

				Session["Shopper"] = shopper;
				Session["BillAddress"] = billAddress;
				Session["ShipToAddress"] = shipToAddress;

				Response.Redirect( "DisplaySummary.aspx" );
			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
