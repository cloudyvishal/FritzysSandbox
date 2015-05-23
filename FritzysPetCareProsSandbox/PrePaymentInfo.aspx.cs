using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Excel = Microsoft.Office.Interop.Excel;
using System.Xml.Linq;
using System.IO;
using CyberSourceStore;
using CyberSource;
using BCL.Admin.StoreFrontMgr;
using BCL.Utility.Contents;
using BCL.Utility.SendMailMgr;
using System.Data.SqlClient;

namespace FritzysPetCareProsSandbox
{
    public partial class PrePaymentInfo : System.Web.UI.Page
    {
        StoreFront objStoreFront = new StoreFront();
        decimal RevenueCost = 0;
        decimal TipCost = 0;
        decimal PriorRevenueCost = 0;
        private ICSReply mReply;
        int apptID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!(null == Session["UserName"]))
                {
                    if (!(null == Request.QueryString["AppID"]))
                    {

                    }
                }
                else
                {
                    Response.Redirect("Index.aspx");
                }
                Session["Paycount"] = 1;
                Session["IsExecuted"] = "0";
            }
        }

        protected string GetOrderRefNumber()
        {
            string OrdNumber = "";

            bool IsOrdnoPresent=false;

            try
            {
                OrdNumber = (new Random()).Next().ToString();

                IDataReader rdr = objStoreFront.CheckOrderRefNo(OrdNumber);

                if (rdr != null)
                {
                    IsOrdnoPresent = true;
                }

                if (IsOrdnoPresent.Equals(true))
                {
                    OrdNumber = GetOrderRefNumber();
                }
            }
            catch (Exception ex)
            {
            }
            return OrdNumber;
        }

        protected void btnSubmitInfo_Click(object sender, EventArgs e)
        {
            string email = "info@fritzyspetcarepros.com";

            try
            {

                if (Page.IsValid.Equals(true))
                {
                    //check to avoid duplicate transactions.
                    if (!(null == Session["IsExecuted"]))
                    {
                        if (Session["IsExecuted"].Equals("0"))
                        {
                            Session["IsExecuted"] = "1";

                            btnSubmitInfo.Enabled = false;
                            lblerrormsg.Visible = false;
                            // set up Order number uniquely.
                            string OrderRefNo = GetOrderRefNumber();
                            Session["OrderNumber"] = OrderRefNo;

                            objStoreFront.GetShopperInfo(0, txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtAddress1.Text.Trim(), txtAddress2.Text.Trim(), txtCity.Text.Trim(),
                         txtState.Text.Trim(), txtZip.Text.Trim(), txtCountry.Text.Trim(), txtPhone.Text.Trim(), email, drpCardType.SelectedItem.Text, txtCardNumber.Text.Trim(),
                         txtExpYear.Text.Trim(), drpMonth.SelectedValue, "", Convert.ToDecimal(lblTotalAmt.Text),
                         decimal.Parse("0"), decimal.Parse("0"), OrderRefNo);

                            Session["emailid"] = email;
                            Session["totalprice"] = lblTotalAmt.Text.Trim().ToString();
                            Session["CC_Name"] = txtFirstName.Text.Trim().ToString();
                            Session["CC_Name1"] = txtLastName.Text.Trim().ToString();

                            string errorMessage = (string)Session["ErrorMessage"];

                            Item[] shoppingCart = new Item[1];

                            shoppingCart[0].ProductName = "Pets Treatment";
                            shoppingCart[0].UnitPrice = Convert.ToDecimal(lblTotalAmt.Text);
                            shoppingCart[0].Quantity = 1;
                            shoppingCart[0].TaxwareCode = "default";

                            Session["ShoppingCart"] = shoppingCart;

                            // set up customer info.
                            Shopper shopper;
                            shopper.FirstName = txtFirstName.Text.Trim();
                            shopper.LastName = txtLastName.Text.Trim();
                            // shopper.Email = txtEmail.Text.Trim();
                            shopper.Email = "info@fritzyspetcarepros.com";
                            Session["Shopper"] = shopper;
                            // set up address info.
                            Address address;
                            address.Address1 = txtAddress1.Text.Trim();
                            address.Address2 = txtAddress2.Text.Trim();
                            address.City = txtCity.Text.Trim();
                            address.State = txtState.Text.Trim();

                            address.Zip = txtZip.Text.Trim();
                            address.Country = txtCountry.Text.Trim();
                            address.Phone = txtPhone.Text.Trim();

                            Session["BillAddress"] = address;

                            // set up credit card info.
                            CreditCard card;
                            card.Number = txtCardNumber.Text.Trim();
                            card.ExpMonth = drpMonth.SelectedValue.ToString();
                            card.ExpYear = txtExpYear.Text.Trim();
                            card.CV = txtVerificationNo.Text.Trim();
                            // Calulates the Tax. 
                            GlobalStore obj = new GlobalStore();

                            GlobalStore global = (GlobalStore)Context.ApplicationInstance;

                            Authorize(global.icsClient, ref card);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void Authorize(ICSClient client, ref CreditCard card)
        {
            try
            {
                // create request object
                ICSRequest request = new ICSRequest();
                // add general fields
                if (!(null == Session["OrderNumber"]))
                {
                    request["merchant_ref_number"] = (string)Session["OrderNumber"];
                }
                request["ics_applications"] = "ics_auth,ics_bill";
                request["currency"] = "USD";

                Shopper shopper = (Shopper)Session["Shopper"];
                Address billAddress = (Address)Session["BillAddress"];
                Address shipToAddress = (Address)Session["BillAddress"];

                // add shopper and address info
                GlobalStore.AddShopperFields(request, ref shopper);
                GlobalStore.AddBillAddressFields(request, ref billAddress);
                GlobalStore.AddShipToAddressFields(request, ref shipToAddress);

                // add an offer for the total amount
                if (lblTotalAmt.Text != "")
                {
                    request["offer0"] = "amount:" + Convert.ToDecimal(lblTotalAmt.Text);
                }
                // add credit card info
                request["customer_cc_number"] = card.Number;
                request["customer_cc_expmo"] = card.ExpMonth;
                request["customer_cc_expyr"] = card.ExpYear;
                request["customer_cc_cv_number"] = card.CV;

                // send request now
                mReply = client.Send(request);
                // extract needed information from mReply.  A couple of reply fields
                // are extracted below for example.
                //   string requestId = mReply["request_id"];
                // process the transaction as per response.
                HandleReply();
            }
            catch (BugException e)
            {
                Session["Exception"] = e;
                HandleReply();
                //  Response.Redirect("DisplayError.aspx", false);
            }
            catch (NonCriticalTransactionException e)
            {
                Session["Exception"] = e;
                HandleReply();
                //  Response.Redirect("DisplayError.aspx", false);
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
                HandleReply();
                //   Response.Redirect("DisplayError.aspx", false);
            }
        }

        private void HandleReply()
        {
            try
            {
                string rFlag = "", ResponseID = "", Responsemsg = "", billtxnrefno = "", authCode = "";
                if (!(null == mReply))
                {
                    rFlag = mReply["ics_rflag"];
                    ResponseID = mReply["request_id"];
                    Responsemsg = mReply["ics_rmsg"];
                    billtxnrefno = mReply["bill_trans_ref_no"];
                    authCode = mReply["auth_auth_code"];
                }
                // For AVS Smart Authentication service.
                if (rFlag.Equals("DSETTINGS"))
                {
                    authCode = "SMART";
                }
                bool IsResponsefound = false;
                lblMessage.Text = "";
                lblReason.Text = "";
                string OrdNumber = (string)Session["OrderNumber"];
                int ID = 0;
                //DSETTINGS Response processed as a successfull transaction caused that will be captured by Merchant later by login through Cybersouce account.
                //if (rFlag.Equals("SOK") || rFlag.Equals("DSETTINGS"))
                //{
                //    IsResponsefound = true;

                //    //new
                //    // Session["DailyLogID"] = "";
                //}
                //update the response from payment gateway.
                //Dec2013 ID is removed from list

                if (rFlag.Equals("SOK") || rFlag.Equals("DSETTINGS"))
                {
                    //Dec2013
                    IsResponsefound = true;

                    //if (!(String.IsNullOrEmpty(Session["PayID"].ToString())))
                    //{
                    objStoreFront.UpdatePGResponseDetails(rFlag, "0", ResponseID, Session["PayID"].ToString(), Responsemsg, billtxnrefno, authCode);
                    if (txtRevenueCost.Text != "")
                    {
                        RevenueCost = Convert.ToDecimal(txtRevenueCost.Text);
                    }
                    if (txtPriorRevenue.Text != "")
                    {
                        PriorRevenueCost = Convert.ToDecimal(txtPriorRevenue.Text);
                    }
                    if (txtTipAmt.Text != "")
                    {
                        TipCost = Convert.ToDecimal(txtTipAmt.Text);
                    }
                    apptID = Convert.ToInt32(Request.QueryString["AppID"]);
                    objStoreFront.InsertAppointmentPrePayment(Convert.ToInt32(Session["UserID"]), RevenueCost, PriorRevenueCost, TipCost, Convert.ToDecimal(lblTotalAmt.Text), txtDescription.Text, Convert.ToInt32(Session["PayID"]), apptID);
                    
                    PaymentDoneMessage("Your payment is made for groomer service.");
                    lblsmsg.Visible = true;
                    btnSubmitInfo.Enabled = false;
                    Session["Amt"] = "Paid";
                    Response.Redirect("MyAccount.aspx?msg=s");

                }
                if (rFlag.Equals("DAVSNO"))
                {
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "Please verify that your address is correct.";
                }
                if (rFlag.Equals("DINVALIDADDRESS"))
                {
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "City,state or postal code entered was invalid.";
                }
                else if (rFlag.Equals("DCALL"))
                {
                    IsResponsefound = true;
                    string msg = String.Format("Your payment transaction has been UnSuccessful. Your order number is {0}. Please keep it handy for your reference.", OrdNumber);
                    Session["ErrorMessage"] = "Your transaction can not be processed at this time,contact the payment processor to proceed with the transaction";
                }
                else if (rFlag.Equals("DCARDEXPIRED"))
                {
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "Your card has expired.";
                    string msg = String.Format("Your payment transaction has been UnSuccessful. Your order number is {0}. Please keep it handy for your reference.", OrdNumber);
                    string Transresult = String.Format("Transaction unsuccessful due to:" + (string)Session["ErrorMessage"]);
                }
                else if (rFlag.Equals("DCARDREFUSED"))
                {
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "Card Authorization failed.";
                    string msg = String.Format("Your payment transaction has been UnSuccessful. Your order number is {0}. Please keep it handy for your reference.", OrdNumber);
                    string Transresult = String.Format("Transaction unsuccessful due to:" + (string)Session["ErrorMessage"]);
                }
                else if (rFlag.Equals("DCV"))
                {
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "Incorrect Card Verification Number.";
                    string msg = String.Format("Your payment transaction has been UnSuccessful. Your order number is {0}. Please keep it handy for your reference.", OrdNumber);
                    string Transresult = String.Format("Transaction unsuccessful due to:" + (string)Session["ErrorMessage"]);
                }
                else if (rFlag.Equals("DINVALIDCARD"))
                {
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "Invalid credit card number.";
                    string msg = String.Format("Your payment transaction has been UnSuccessful. Your order number is {0}. Please keep it handy for your reference.", OrdNumber);
                    string Transresult = String.Format("Transaction unsuccessful due to:" + (string)Session["ErrorMessage"]);
                }
                else if (rFlag.Equals("DRESTRICTED"))
                {
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "declined restriced card.";
                    string msg = String.Format("Your payment transaction has been UnSuccessful. Your order number is {0}. Please keep it handy for your reference.", OrdNumber);
                    string Transresult = String.Format("Transaction unsuccessful due to:" + (string)Session["ErrorMessage"]);
                }
                else if (rFlag.Equals("DSCORE"))
                {
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "Card not successfully authenticated.";
                    string msg = String.Format("Your payment transaction has been UnSuccessful. Your order number is {0}. Please keep it handy for your reference.", OrdNumber);
                    string Transresult = String.Format("Transaction unsuccessful due to:" + (string)Session["ErrorMessage"]);
                }
                else if (rFlag.Equals("ESYSTEM"))
                {
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "System Internal error.";
                    string msg = String.Format("Your payment transaction has been UnSuccessful. Your order number is {0}. Please keep it handy for your reference.", OrdNumber);
                    string Transresult = String.Format("Transaction unsuccessful due to:" + (string)Session["ErrorMessage"]);
                }
                else if (rFlag.Equals("DINVALIDDATA"))
                {
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "Invalid Data";
                    string msg = String.Format("Your payment transaction has been UnSuccessful. Your order number is {0}. Please keep it handy for your reference.", OrdNumber);
                    string Transresult = String.Format("Transaction unsuccessful due to:" + (string)Session["ErrorMessage"]);
                }
                else if (rFlag.Equals("ETIMEOUT"))
                {
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "Payment Transaction Timeout.";
                    string msg = String.Format("Your payment transaction has been UnSuccessful. Your order number is {0}. Please keep it handy for your reference.", OrdNumber);
                    string Transresult = String.Format("Transaction unsuccessful due to:" + (string)Session["ErrorMessage"]);
                }
                else if (rFlag.Equals(""))
                {
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "Payment can not be processed please select another form of payment";
                }

                if (!(rFlag.Equals("SOK")))
                {
                    Session["IsExecuted"] = "0";
                    if (IsResponsefound.Equals(false))
                    {
                        Session["ErrorMessage"] = "Payment can not be processed please select another form of payment";
                    }
                    int PayCount = 0;
                    if (!(null == Session["Paycount"]))
                    {
                        PayCount = Convert.ToInt32(Session["Paycount"].ToString());
                    }
                    if (PayCount < 3)
                    {
                        btnSubmitInfo.Enabled = true;

                        txtFirstName.Focus();
                        if (!(null == Session["ErrorMessage"]))
                        {
                            lblMessage.Text = Session["ErrorMessage"].ToString() + " Please try again";
                            Session["Paycount"] = PayCount + 1;
                        }
                    }
                    else
                    {
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void PaymentDoneMessage(string body)
        {
            try
            {
                string Date_time = DateTime.Now.ToString();
                string datenew = Date_time.ToString();
                string emailadd = Session["emailid"].ToString();
                string totalprice = Session["totalprice"].ToString();
                string CC_Name1 = Session["CC_Name"].ToString();
                string CC_Name2 = Session["CC_Name1"].ToString();
                string CC_Name = CC_Name1 + " " + CC_Name2;
                string orderno = (string)Session["OrderNumber"];
                string UserAppID = "AppID" + apptID.ToString();
                string Mailbody = ContentManager.GetStaticeContentEmail("PrePaymentEmail.htm").Replace("~", "#");
                Mailbody = Mailbody.Replace("<!-- Date -->", Date_time);
                Mailbody = Mailbody.Replace("<!-- UserAppId -->", UserAppID);
                Mailbody = Mailbody.Replace("<!-- Total_Amount -->", totalprice);
                Mailbody = Mailbody.Replace("<!-- CC_Name -->", CC_Name);
                Mailbody = Mailbody.Replace("<!-- orderNumber -->", orderno);
                Mailbody = Mailbody.Replace("<!-- Rev_Amount -->", RevenueCost.ToString());
                Mailbody = Mailbody.Replace("<!-- Prior_Amount -->", PriorRevenueCost.ToString());
                Mailbody = Mailbody.Replace("<!-- Tip_Amount -->", TipCost.ToString());
                Mailbody = Mailbody.Replace("<!-- Details -->", body);
                SendMails ObjMail = new SendMails();

                ObjMail.PrePaymentMail(ConfigurationManager.AppSettings["FromEmail"].ToString(),
                                    datenew, emailadd, totalprice, CC_Name, body, Mailbody);


            }
            catch (Exception ex)
            {
                string error = ex.Source + "_" + ex.Message + "_" + ex.ToString();
            }
        }

        private void CalculateTax(ICSClient client)
        {
            try
            {
                // create request object
                ICSRequest request = new ICSRequest();
                // add general fields
                request["merchant_ref_number"] = (string)Session["OrderNumber"];
                request["ics_applications"] = "ics_tax";
                request["currency"] = "USD";

                Shopper shopper = (Shopper)Session["Shopper"];
                Address billAddress = (Address)Session["BillAddress"];
                Address shipToAddress = (Address)Session["BillAddress"];

                // add shopper and address info
                GlobalStore.AddShopperFields(request, ref shopper);
                GlobalStore.AddBillAddressFields(request, ref billAddress);
                GlobalStore.AddShipToAddressFields(request, ref shipToAddress);

                // add an offer for each item in the shopping cart
                ICSOffer offer;
                Item[] shoppingCart = (Item[])Session["ShoppingCart"];
                int i = 0;
                foreach (Item item in shoppingCart)
                {
                    offer = new ICSOffer();
                    offer["amount"] = item.UnitPrice.ToString();
                    offer["quantity"] = item.Quantity.ToString();
                    offer["product_code"] = item.TaxwareCode;
                    request.SetOffer(i++, offer);
                }
                // add another offer for shipping and handling
                offer = new ICSOffer();
                offer["amount"] = "0";
                // replace shipping_and_handling with a more appropriate
                // taxware S&H code.
                offer["product_code"] = "shipping_and_handling";
                request.SetOffer(i, offer);
                // send request now
                ICSReply reply = client.Send(request);
                // ics_rcode of 1 means the transaction was processed successfully.
                if (reply["ics_rcode"] != "1")
                {
                    Session["ErrorMessage"] = "Error calculating tax.";
                    Response.Redirect("DisplayError.aspx", false);
                }
                // extract information from reply
                decimal mTax = Decimal.Parse(reply["tax_total_tax"]);
                decimal mTotal = Decimal.Parse(reply["tax_total_grand"]);
            }
            catch (BugException e)
            {
                Session["Exception"] = e;
                Response.Redirect("DisplayError.aspx", false);
            }
            catch (NonCriticalTransactionException e)
            {
                Session["Exception"] = e;
                Response.Redirect("DisplayError.aspx", false);
            }
            catch (CriticalTransactionException e)
            {
                // no need to handle a CriticalTransactionException differently
                // for ics_tax.
                Session["Exception"] = e;
                Response.Redirect("DisplayError.aspx", false);
            }
        }
        protected void txtRevenueCost_TextChanged(object sender, EventArgs e)
        {

        }
        protected void txtPriorRevenue_TextChanged(object sender, EventArgs e)
        {

        }
        protected void txtTipAmt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}