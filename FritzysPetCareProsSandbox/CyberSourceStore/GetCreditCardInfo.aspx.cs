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
using CyberSource;

namespace CyberSourceStore
{
	/// <summary>
	/// Summary description for GetCreditCardInfo.
	/// </summary>
	public class GetCreditCardInfo : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox CCNumber;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox ExpMonth;
		protected System.Web.UI.WebControls.TextBox ExpYear;
		protected System.Web.UI.WebControls.TextBox CV;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label ErrorMessage;

		private ICSReply mReply;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				CreditCard card;

				string errorMessage = (string) Session["ErrorMessage"];
				if (errorMessage != null)
				{
					// if coming back from a failed auth, display error message
					// and current credit card info.

					ErrorMessage.Text = errorMessage;
					Session.Remove( "ErrorMessage" );

					card = (CreditCard) Session["CreditCard"];
				}
				else
				{
					card = (CreditCard) Session["DefaultCard"];
				}

				CCNumber.Text = card.Number;
				ExpMonth.Text = card.ExpMonth;
				ExpYear.Text  = card.ExpYear;
				CV.Text       = card.CV;
			}
			else
			{			
				CreditCard card;
				card.Number   = CCNumber.Text;
				card.ExpMonth = ExpMonth.Text;
				card.ExpYear  = ExpYear.Text;
				card.CV       = CV.Text;
				Session["CreditCard"] = card;

                GlobalStore global = (GlobalStore)Context.ApplicationInstance;
				Authorize( global.icsClient, ref card );
			}
		}

		private void Authorize( ICSClient client, ref CreditCard card )
		{
			try
			{
				// create request object
				ICSRequest request = new ICSRequest();
				
				// add general fields
				request["merchant_ref_number"] = (string) Session["OrderNumber"];
				request["ics_applications"] = "ics_score,ics_auth";
				request["currency"] = "USD";

				Shopper shopper = (Shopper) Session["Shopper"];
				Address billAddress = (Address) Session["BillAddress"];
				Address shipToAddress = (Address) Session["ShipToAddress"];

				// add shopper and address info
                GlobalStore.AddShopperFields(request, ref shopper);
                GlobalStore.AddBillAddressFields(request, ref billAddress);
                GlobalStore.AddShipToAddressFields(request, ref shipToAddress);

				// add an offer for the total amount
				request["offer0"] = "amount:" + ((decimal) Session["TotalAmount"]).ToString();

				// add credit card info
				request["customer_cc_number"]    = card.Number;
				request["customer_cc_expmo"]     = card.ExpMonth;
				request["customer_cc_expyr"]     = card.ExpYear;
				request["customer_cc_cv_number"] = card.CV;
				
				// send request now
				mReply = client.Send( request );

				// extract needed information from mReply.  A couple of reply fields
				// are extracted below for example.
				string requestId = mReply["request_id"];
				string authCode  = mReply["auth_auth_code"];

				HandleReply();
			}
			catch (BugException e)
			{
				Session["Exception"] = e;
				Response.Redirect( "DisplayError.aspx" );
			}
			catch (NonCriticalTransactionException e)
			{
				Session["Exception"] = e;
				Response.Redirect( "DisplayError.aspx" );
			}
			catch (CriticalTransactionException e)
			{
				// The transaction may have been successfully processed by
				// CyberSource.  Aside from redirecting to an error page, you should
				// make sure that someone gets notified of the occurrence of this
				// exception so that they could check the outcome of the transaction
				// on the CyberSource Support Screens.  For example, you could
				// post an event log or send an email to a monitored address.
				Session["Exception"] = e;
				Response.Redirect( "DisplayError.aspx" );
			}
		}

		private void HandleReply()
		{
			string rFlag = mReply["ics_rflag"];

			if (rFlag.Equals( "SOK" ))
			{
				Response.Redirect( "DisplaySuccess.aspx" );
			}
			
			if (rFlag.Equals( "DAVSNO" ))
			{
				Session["ErrorMessage"] = "Please verify that your address is correct.";
				Response.Redirect( "GetShopperInfo.aspx" );
			}
			else if (rFlag.Equals( "DCALL" ))
			{
				// handle DCALL appropriately.  You should at least notify someone
				// so that they could call the payment processor.
			}
			else if (rFlag.Equals( "DCARDEXPIRED" ))
			{
				Session["ErrorMessage"] = "Your card has expired.";
				Response.Redirect( "GetCreditCardInfo.aspx" );
			}
			else if (rFlag.Equals( "DCARDREFUSED" ))
			{
				Session["ErrorMessage"] = "Authorization failed.";
				Response.Redirect( "GetCreditCardInfo.aspx" );
			}
			else if (rFlag.Equals( "DCV" ))
			{
				Session["ErrorMessage"] = "Incorrect Card Verification Number.";
				Response.Redirect( "GetCreditCardInfo.aspx" );
			}
			else if (rFlag.Equals( "DINVALIDCARD" ))
			{
				Session["ErrorMessage"] = "Invalid credit card number.";
				Response.Redirect( "GetCreditCardInfo.aspx" );
			}
			else if (rFlag.Equals( "DRESTRICTED" ))
			{
				Session["ErrorMessage"] = "Your order cannot be processed at this time.";
				Response.Redirect( "DisplayError.aspx" );
			}
			else if (rFlag.Equals( "DSCORE" ))
			{
				Session["ErrorMessage"] = "Your order cannot be processed at this time.";
				Response.Redirect( "DisplayError.aspx" );
			}
			else if (rFlag.Equals( "ESYSTEM" ))
			{
				Session["ErrorMessage"] = "Internal error.";
				Response.Redirect( "DisplayError.aspx" );
			}
			else if (rFlag.Equals( "ETIMEOUT" ))
			{
				Session["ErrorMessage"] = "Internal error.";
				Response.Redirect( "DisplayError.aspx" );
			}
			// handle all other non-SOK rflags
			else
			{
				Session["ErrorMessage"] = "Internal error.";
				Response.Redirect( "DisplayError.aspx" );
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
