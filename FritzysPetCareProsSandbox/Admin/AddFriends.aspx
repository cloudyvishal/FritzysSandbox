﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AddFriends.aspx.cs" Inherits="FritzysPetCareProsSandbox.Admin.AddFriends" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div class="innerContent">
        <div class="pageTitle">
            <h2>Add Fritzy's Friend</h2>
        </div>
        <div class="errorDiv" id="divError" runat="server" visible="false">
            <table width="100%">
                <tbody>
                    <tr>
                        <td align="left" rowspan="2">
                            <asp:Label ID="lblError" runat="server" Visible="False" Font-Bold="True"></asp:Label>&nbsp;
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <table class="adduserTable" cellpadding="6" cellspacing="0">
            <tr>
                <td width="13%"><span class="star">*</span>Friend Title : </td>
                <td></td>
                <td>
                    <asp:TextBox ID="txtTitle" runat="server" MaxLength="50" CssClass="textBox"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                        ControlToValidate="txtTitle" Display="None" SetFocusOnError="true"
                        ErrorMessage="<b>Required Field Missing</b><br />Friend title is required.">  
                    </asp:RequiredFieldValidator>

                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender0" TargetControlID="RequiredFieldValidator1"
                        HighlightCssClass="validatorCalloutHighlight" />
                </td>
            </tr>
            <tr>
                <td><span class="star">*</span>Referral Link :</td>
                <td></td>
                <td>
                    <asp:TextBox ID="txtReferallink" runat="server" MaxLength="100" CssClass="textBox"></asp:TextBox>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                        ControlToValidate="txtReferallink" Display="None" SetFocusOnError="true"
                        ErrorMessage="<b>Required Field Missing</b><br />Referal link is required.">  
                    </asp:RequiredFieldValidator>

                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1" TargetControlID="RequiredFieldValidator3"
                        HighlightCssClass="validatorCalloutHighlight" />
                    <asp:CustomValidator runat="server" ID="custSpChar"
                        ControlToValidate="txtReferallink" Display="None" SetFocusOnError="true"
                        ClientValidationFunction="ValidateURL"
                        ErrorMessage="<b> Please enter correct URL</b> ."></asp:CustomValidator>

                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="VCE5" TargetControlID="custSpChar"
                        HighlightCssClass="validatorCalloutHighlight" Enabled="true" />

                </td>
            </tr>
            <tr>
                <td><span class="star">*</span>Description :
                </td>
                <td></td>
                <td>
                    <asp:TextBox Rows="5" Columns="100" TextMode="MultiLine" ID="txtDescription" runat="server" CssClass="MultilinetextBox" MaxLength="300" onkeyDown="checkTextAreaMaxLength(this,event,'300');"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" SetFocusOnError="true"
                        ControlToValidate="txtDescription" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Description is required.">  
                    </asp:RequiredFieldValidator>

                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender2" TargetControlID="RequiredFieldValidator2"
                        HighlightCssClass="validatorCalloutHighlight" />
                </td>
            </tr>
            <tr>
                <td><span class="star">*</span>Logo :
                </td>
                <td></td>
                <td>
                    <asp:FileUpload ID="flUploadDetail" onkeypress="return false;" runat="server"></asp:FileUpload>&nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" SetFocusOnError="true"
                ControlToValidate="flUploadDetail" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Logo is required.">  
            </asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="flUploadDetail" Display="None"
                        ErrorMessage="<b>Required Field Missing</b><br />File size should not be greater than 100X100." OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>

                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender3" TargetControlID="RequiredFieldValidator4"
                        HighlightCssClass="validatorCalloutHighlight" />
                    File size should be 100 X 100.
                </td>
            </tr>

        </table>
        <asp:Button ID="AddUser" runat="server" Text="Add Friends" ToolTip="Add Friend" CssClass="btnBg" OnClick="AddUser_Click" />
        &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnBack" runat="server" Text="Cancel" ToolTip="Cancel" CssClass="btnBg" CausesValidation="false" PostBackUrl="~/Admin/ManageFriends.aspx?SearchFor=0&SearchText=" />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFooter" runat="server">

    <script type="text/javascript" lang="javascript">
        function checkTextAreaMaxLength(textBox, e, length) {
            var mLen = textBox["MaxLength"];
            if (null == mLen)
                mLen = length;
            var maxLength = parseInt(mLen);
            if (!checkSpecialKeys(e)) {
                if (textBox.value.length > maxLength - 1) {
                    if (window.event)//IE
                        e.returnValue = false;
                    else//Firefox
                        e.preventDefault();
                }
            }
        }
        function checkSpecialKeys(e) {
            if (e.keyCode != 8 && e.keyCode != 46 && e.keyCode != 37 && e.keyCode != 38 && e.keyCode != 39 && e.keyCode != 40)
                return false;
            else
                return true;
        }
    </script>
    <script type="text/javascript" lang="javascript">

        function ValidateURL(source, args) {

            var regexp = /www.[a-zA-Z0-9-\.]+\.(com|org|net|mil|edu|ca|co.uk|co.in|com.au|ac.in|gov|gov.in)(\/[A-Za-z0-9\.-])?/;

            if (!regexp.test(args.Value))
                args.IsValid = false;
        }

        function checkURL(url) {

            var theurl = url;

            var tomatch = /^(http[s]?:\/\/|ftp:\/\/)(www\.)?[a-zA-Z0-9-\.]+\.(com|org|net|mil|edu|ca|co.uk|co.in|com.au|ac.in|gov|gov.in)(\/[A-Za-z0-9\.-])?/;

            if (tomatch.test(theurl)) {
                return true;
            }
            else {
                return false;
            }
        }
    </script>
</asp:Content>
