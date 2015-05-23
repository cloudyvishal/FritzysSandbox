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
	/// Summary description for DisplaySummar2.
	/// </summary>
	public class DisplaySummary : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Table Table1;
		decimal mShippingAndHandling;
		decimal mTax;
		protected System.Web.UI.WebControls.Button Button1;
		decimal mTotal;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
                GlobalStore global = (GlobalStore)Context.ApplicationInstance;
				CalculateShippingAndHandling();
				CalculateTax( global.icsClient );

                decimal subTotal = GlobalStore.DisplayItems(Table1, Session);
                GlobalStore.DisplayAmount(Table1, "Subtotal", subTotal);
                GlobalStore.DisplayAmount(Table1, "S&H", mShippingAndHandling);
                GlobalStore.DisplayAmount(Table1, "Tax", mTax);
                GlobalStore.DisplayAmount(Table1, "Total", mTotal);

				Session["TotalAmount"] = mTotal;
			}
			else
			{
				Response.Redirect( "GetCreditCardInfo.aspx" );
			}
		}

		private void CalculateShippingAndHandling()
		{
			mShippingAndHandling = 2.95m;
		}

		private void CalculateTax( ICSClient client )
		{
			try
			{
				// create request object
				ICSRequest request = new ICSRequest();
				
				// add general fields
				request["merchant_ref_number"] = (string) Session["OrderNumber"];
				request["ics_applications"] = "ics_tax";
				request["currency"] = "USD";

				Shopper shopper = (Shopper) Session["Shopper"];
				Address billAddress = (Address) Session["BillAddress"];
				Address shipToAddress = (Address) Session["ShipToAddress"];

				// add shopper and address info
                GlobalStore.AddShopperFields(request, ref shopper);
                GlobalStore.AddBillAddressFields(request, ref billAddress);
                GlobalStore.AddShipToAddressFields(request, ref shipToAddress);

				// add an offer for each item in the shopping cart
				ICSOffer offer;
				Item[] shoppingCart = (Item[]) Session["ShoppingCart"];
				int i = 0;
				foreach (Item item in shoppingCart)
				{
					offer = new ICSOffer();
					offer["amount"] = item.UnitPrice.ToString();
					offer["quantity"] = item.Quantity.ToString();
					offer["product_code"] = item.TaxwareCode;
					request.SetOffer( i++, offer );
				}

				// add another offer for shipping and handling
				offer = new ICSOffer();
				offer["amount"] = mShippingAndHandling.ToString();
				// replace shipping_and_handling with a more appropriate
				// taxware S&H code.
				offer["product_code"] = "shipping_and_handling";
				request.SetOffer( i, offer );

				// send request now
				ICSReply reply = client.Send( request );

				// ics_rcode of 1 means the transaction was processed successfully.
				if (reply["ics_rcode"] != "1")
				{
					Session["ErrorMessage"] = "Error calculating tax.";
					Response.Redirect( "DisplayError.aspx" );
				}

				// extract information from reply
				mTax = Decimal.Parse( reply["tax_total_tax"] );
				mTotal = Decimal.Parse( reply["tax_total_grand"] );
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
				// no need to handle a CriticalTransactionException differently
				// for ics_tax.
				Session["Exception"] = e;
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
