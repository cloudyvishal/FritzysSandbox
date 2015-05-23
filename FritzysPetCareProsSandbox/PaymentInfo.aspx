<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="PaymentInfo.aspx.cs" Inherits="FritzysPetCareProsSandbox.PaymentInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntBody" runat="server">
    <div id="mainPlaceholder">
        <!-- main place holder start here -->
        <div class="wrappercontainer">
            <div id="wrapper">
                <!--wrapper start here -->
                <div id="mainInnerContent">
                    <!-- Main Content Starts Here -->
                    <!-- reg main start here -->
                    <table align="center" style="width: 100%">
                        <tr>
                            <td>
                                <table align="center" style="width: 50%">
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="lblsmsg" runat="server" Text="Your Payment Submitted Successfully!!!"
                                                ForeColor="Green" Font-Bold="true" Font-Size="Larger" Visible="false"></asp:Label>
                                            <asp:Label ID="lblerrormsg" runat="server" Text="Negative Values are Not Allowed."
                                                ForeColor="Red" Font-Bold="true" Font-Size="Larger" Visible="false"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" colspan="2">
                                            <asp:ImageMap ID="ImageMap2" runat="server" ImageUrl="~/Images/cybersource.png">
                                            </asp:ImageMap>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px">
                                            <asp:Label ID="lblDateTime" runat="server" Text="Appt Date/Time:" CssClass="appnt_lbl"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lbl_time" runat="server" Text="" CssClass="appnt_lbl"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px">
                                            <asp:Label ID="lblString" runat="server" Text="Description:" CssClass="appnt_lbl"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lbl_description" runat="server" CssClass="appnt_lbl" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table align="center" style="width: 100%">
                                    <tr>
                                        <td align="left" colspan="2">
                                            <h2>Payment Information</h2>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" width="108">
                                            <asp:Label ID="lblRevenue" runat="server" Text="Revenue:" CssClass="appnt_lbl"></asp:Label>
                                            &nbsp;
                                        </td>
                                        <td align="left" width="210">
                                            <span class="appnt_lbl">$</span>
                                            <asp:Label ID="lblRevenueCost" runat="server" CssClass="appnt_lbl"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" width="108">
                                            <asp:Label ID="lblTip" runat="server" Text="Tip:" CssClass="appnt_lbl"></asp:Label>
                                            &nbsp;
                                        </td>
                                        <td align="left">
                                            <span class="appnt_lbl">$</span>
                                            <asp:TextBox ID="txtTipCost" runat="server" Height="22px" OnTextChanged="txtTipCost_TextChanged"
                                                AutoPostBack="true"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" width="108">
                                            <asp:Label ID="lblPriorRevenue" runat="server" Text="Prior Revenue:" CssClass="appnt_lbl"></asp:Label>
                                            &nbsp;
                                        </td>
                                        <td align="left">
                                            <span class="appnt_lbl">$</span>
                                            <asp:Label ID="lblPriorRevenueCost" runat="server" CssClass="appnt_lbl"></asp:Label>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" width="108">&nbsp;
                                            <asp:Localize ID="Localize2" runat="server"></asp:Localize>
                                            <asp:Label ID="lblNewTotal" runat="server" Text="Total Amount:" CssClass="appnt_lbl"></asp:Label>
                                            &nbsp;
                                        </td>
                                        <td align="left">
                                            <span class="appnt_lbl" style="color: #CC3300;">$</span>
                                            <asp:Label ID="lblTotalCost" runat="server" CssClass="appnt_lbl" ForeColor="#CC3300"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table class="payment_page" width="100%">
                                    <tr>
                                        <td colspan="3">&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <h2>Billing Information</h2>
                                            <hr />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3">
                                            <asp:Label ID="lblMessage" runat="server" CssClass="error_msg" ForeColor="#CC3300"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" width="33%">
                                            <div class="label_new">
                                                <asp:Label ID="lblCustomerName" runat="server" Text="First Name:" CssClass="appnt_lbl"></asp:Label>
                                                <span style="color: Red">*</span>
                                            </div>
                                        </td>
                                        <td width="33%" align="left">
                                            <asp:TextBox ID="txtFirstName" runat="server" CssClass="txt txt117" MaxLength="20"
                                                AutoCompleteType="Disabled"></asp:TextBox>
                                        </td>
                                        <td width="33%" align="left">
                                            <asp:RequiredFieldValidator ID="rfvfname" runat="server" ControlToValidate="txtFirstName"
                                                CssClass="error_msg" Display="Dynamic" ErrorMessage="Enter First Name" ValidationGroup="Payment_Validation"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td align="right" width="33%">
                                            <asp:Label ID="lblCustomerLastName" runat="server" Text="Last Name:" CssClass="appnt_lbl"></asp:Label>
                                            <span style="color: Red">*</span>
                                        </td>
                                        <td width="33%" align="left">
                                            <asp:TextBox ID="txtLastName" runat="server" CssClass="txt txt117" MaxLength="20"
                                                AutoCompleteType="Disabled"></asp:TextBox>
                                        </td>
                                        <td width="33%" align="left">
                                            <asp:RequiredFieldValidator ID="rfvlastname" runat="server" ControlToValidate="txtLastName"
                                                CssClass="error_msg" Display="Dynamic" ErrorMessage="Enter Last Name" ValidationGroup="Payment_Validation"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblAddress1" runat="server" Text="Address 1:" CssClass="appnt_lbl"></asp:Label>
                                            <span style="color: Red">*</span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAddress1" runat="server" MaxLength="100" CssClass="txt txt117"
                                                AutoCompleteType="Disabled"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfvaddr1" runat="server" ControlToValidate="txtAddress1"
                                                CssClass="error_msg" Display="Dynamic" ErrorMessage="Enter Address 1" ValidationGroup="Payment_Validation"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblAddress2" runat="server" Text="Address 2: " CssClass="appnt_lbl"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAddress2" runat="server" MaxLength="20" CssClass="txt txt117"
                                                AutoCompleteType="Disabled"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblCity" runat="server" Text="City:" CssClass="appnt_lbl"></asp:Label>
                                            <span style="color: Red">*</span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCity" runat="server" MaxLength="18" CssClass="txt txt117" AutoCompleteType="Disabled"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfvcity" runat="server" ControlToValidate="txtCity"
                                                CssClass="error_msg" Display="Dynamic" ErrorMessage="Enter City" ValidationGroup="Payment_Validation"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblstate" runat="server" Text="State:" CssClass="appnt_lbl"></asp:Label>
                                            <span style="color: Red">*</span>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtState" runat="server" MaxLength="18" CssClass="txt txt117" AutoCompleteType="Disabled"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfvstate" runat="server" ControlToValidate="txtCity"
                                                CssClass="error_msg" Display="Dynamic" ErrorMessage="Enter State" ValidationGroup="Payment_Validation"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblZip" runat="server" Text="Zip:" CssClass="appnt_lbl"></asp:Label>
                                            <span style="color: Red">*</span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtZip" runat="server" MaxLength="5" CssClass="txt txt117" AutoCompleteType="Disabled"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfvzip" runat="server" ControlToValidate="txtZip"
                                                CssClass="error_msg" Display="Dynamic" ErrorMessage="Enter Zip Code" ValidationGroup="Payment_Validation"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblCountry" runat="server" Text="Country:" CssClass="appnt_lbl"></asp:Label>

                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCountry" runat="server" CssClass="txt txt117" AutoCompleteType="Disabled"
                                                Text="USA"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfvcountry" runat="server" ControlToValidate="txtCountry"
                                                CssClass="error_msg" Display="Dynamic" ErrorMessage="Enter Country" ValidationGroup="Payment_Validation"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblPhone" runat="server" Text="Phone:" CssClass="appnt_lbl"></asp:Label>
                                            <span style="color: Red">*</span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPhone" runat="server" MaxLength="20" CssClass="txt txt117" AutoCompleteType="Disabled"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfvphone" runat="server" ControlToValidate="txtPhone"
                                                CssClass="error_msg" Display="Dynamic" ErrorMessage="Enter Phone Number" ValidationGroup="Payment_Validation"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <h2>Credit Card Information</h2>
                                            <hr />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" align="center">
                                            <asp:ImageMap ID="ImageMap1" runat="server" ImageUrl="~/Images/credit_card.png">
                                            </asp:ImageMap>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblCreditCardNumber0" runat="server" Text="   CC Type :" CssClass="appnt_lbl"></asp:Label>
                                            <span style="color: Red">*</span>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="drpCardType" runat="server" CssClass="txt117" Style="border: 1px solid #90734B;">
                                                <asp:ListItem Selected="True">Select Card Type</asp:ListItem>
                                                <asp:ListItem Value="1">Visa</asp:ListItem>
                                                <asp:ListItem Value="2">Master Card</asp:ListItem>
                                                <asp:ListItem Value="3">American Express</asp:ListItem>
                                                <asp:ListItem Value="4">Discover</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:CompareValidator ID="cfvcardtype" runat="server" ControlToValidate="drpCardType"
                                                CssClass="error_msg" ErrorMessage="Select Card Type" Operator="NotEqual" ValidationGroup="Payment_Validation"
                                                ValueToCompare="Select Card Type" Display="Dynamic"></asp:CompareValidator>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblCreditCardNumber" runat="server" Text="CC Number:" CssClass="appnt_lbl"></asp:Label>
                                            <span style="color: Red">*</span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCardNumber" runat="server" MaxLength="20" CssClass="txt txt117"
                                                AutoCompleteType="Disabled"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfvcardnum" runat="server" ControlToValidate="txtCardNumber"
                                                CssClass="error_msg" Display="Dynamic" ErrorMessage="Enter Credit Card Number"
                                                ValidationGroup="Payment_Validation"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblExpirationMonth" runat="server" Text="Exp Month:" CssClass="appnt_lbl"></asp:Label>
                                            <span style="color: Red">*</span>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="drpMonth" runat="server" CssClass="txt117">
                                                <asp:ListItem>Select Month</asp:ListItem>
                                                <asp:ListItem Value="1">January</asp:ListItem>
                                                <asp:ListItem Value="2">February</asp:ListItem>
                                                <asp:ListItem Value="3">March</asp:ListItem>
                                                <asp:ListItem Value="4">April</asp:ListItem>
                                                <asp:ListItem Value="5">May</asp:ListItem>
                                                <asp:ListItem Value="6">June</asp:ListItem>
                                                <asp:ListItem Value="7">July</asp:ListItem>
                                                <asp:ListItem Value="8">August</asp:ListItem>
                                                <asp:ListItem Value="9">September</asp:ListItem>
                                                <asp:ListItem Value="10">October</asp:ListItem>
                                                <asp:ListItem Value="11">November</asp:ListItem>
                                                <asp:ListItem Value="12">December</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:CompareValidator ID="cfvcardtype0" runat="server" ControlToValidate="drpMonth"
                                                CssClass="error_msg" ErrorMessage="Select Month" Operator="NotEqual" ValidationGroup="Payment_Validation"
                                                ValueToCompare="Select Month" Display="Dynamic"></asp:CompareValidator>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblExpirationYear" runat="server" Text="Exp Year:" CssClass="appnt_lbl"></asp:Label>
                                            <span style="color: Red">*</span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtExpYear" runat="server" MaxLength="4" CssClass="txt txt117" AutoCompleteType="Disabled"></asp:TextBox>
                                        </td>
                                        <td align="left" colspan="2">
                                            <asp:RequiredFieldValidator ID="rfvcyear" runat="server" ControlToValidate="txtExpYear"
                                                CssClass="error_msg" Display="Dynamic" ErrorMessage="Enter Expiration Year" ValidationGroup="Payment_Validation"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblVerificationNo" runat="server" Text="CCV No:" CssClass="appnt_lbl"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtVerificationNo" runat="server" MaxLength="6" CssClass="txt txt117"
                                                AutoCompleteType="Disabled"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <table align="center" style="width: 100%">
                                    <tr>
                                        <td align="center">
                                            <asp:Label ID="ErrorMessage" runat="server" CssClass="error_msg" ForeColor="#CC3300"></asp:Label>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:Button ID="btnSubmitInfo" runat="server" CssClass="btnBg" Text="Submit Payment"
                                                OnClick="btnSubmitInfo_Click" ValidationGroup="Payment_Validation" />
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:Label ID="lblReason" runat="server" CssClass="error_msg" ForeColor="#CC3300"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <!-- reg top end here -->
                <div style="clear: both;">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cntFooter" runat="server">
    <script type="text/javascript" language="javascript">
        function AppTimeError() {
            alert('Appt.timings required.');
        }
    </script>
</asp:Content>
