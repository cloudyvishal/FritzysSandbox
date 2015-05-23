<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Inner_Page_MB_MasterPage.Master" AutoEventWireup="true" CodeBehind="MB_ContactUs.aspx.cs" Inherits="MobileWeb.MB_ContactUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div class="contentinnersection">
        <div class="innerpageheading">
            <h1>Contact Us <a href="tel:18773748997"><span class="subheading">&nbsp;&nbsp;Call! 877-374-8997</span></a></h1>
        </div>
        <div class="innercontent">
            <p class="contactustxt">
                <b>Fritzy's Pet Care Pros, Incorporated</b>
            </p>
            <p class="contactustxt">
                15540 Rockfield Blvd., STE D,<br />
                Irvine, CA, 92618.
				 <p>
                     <p class="contactustxt">
                         Email:&nbsp;<a href="mailto:customerservice@fritzyspetcarepros.com" class="contactus"><b>customerservice@fritzyspetcarepros.com</b></a>
                     </p>
                     <div id="divError" runat="server" visible="false">
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
                     <div class="forform">
                         <form action="#">
                             <asp:Label runat="server" ID="LblLastName" CssClass="label">First Name<span class="mand">*</span></asp:Label><br />
                             <asp:TextBox CssClass="txtbox" ID="txtFName" runat="server" onFocus="this.value=''"></asp:TextBox><br />
                             <asp:Label runat="server" ID="lastname" CssClass="label">Last Name<span class="mand">*</span></asp:Label><br />
                             <asp:TextBox runat="server" ID="txtLName" CssClass="txtbox" onFocus="this.value=''"></asp:TextBox><br />
                             <asp:Label runat="server" ID="emaillabel" CssClass="label">Email<span class="mand">*</span></asp:Label><br />
                             <asp:TextBox runat="server" ID="txtContactEmail" CssClass="txtbox" onFocus="this.value=''"></asp:TextBox>
                             <br />
                             <asp:Label runat="server" ID="phonelabel" CssClass="label">Phone</asp:Label><br />
                             <asp:TextBox runat="server" ID="txtMobile" CssClass="txtbox" onkeydown="javascript:backspacerDOWN(this,event);"
                                 onkeyup="javascript:backspacerUP(this,event);" onFocus="this.value=''"></asp:TextBox><br />
                             <asp:Label runat="server" ID="msglabel" CssClass="label">Message<span class="mand">*</span></asp:Label><br />
                             <asp:TextBox runat="server" ID="txtMessage" CssClass="txtarea" TextMode="MultiLine"></asp:TextBox><br />
                             <asp:Button runat="server" CssClass="button" ID="btnSave" OnClientClick="return validate();"
                                 OnClick="btnSave_Click" Text="SEND" />
                         </form>
                     </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBodyEnd" runat="server">
    <script type="text/javascript" src="../Scripts/phone_validation.js" defer="defer"></script>

    <script language="javascript" type="text/javascript" defer="defer">
        function validate() {

            if (document.getElementById('<%=txtFName.ClientID %>').value == "") {

                alert("Please Enter First Name.");
                document.getElementById('<%=txtFName.ClientID %>').focus();
                return false;
            }
            if (document.getElementById('<%=txtLName.ClientID %>').value == "") {

                alert("Please Enter Last Name.");
                document.getElementById('<%=txtLName.ClientID %>').focus();
                return false;
            }

            if (validateForm(document.getElementById('<%=txtContactEmail.ClientID %>').value) == false) {

                return false;

            }
            if ((document.getElementById('<%=txtContactEmail.ClientID %>').value) == "") {

                alert("Please Enter Email.");
                document.getElementById('<%=txtContactEmail.ClientID %>').focus();
                return false;
            }
            if ((document.getElementById('<%=txtMobile.ClientID %>').value) == "") {
                alert("Not a valid Phone No.");
                document.getElementById('<%=txtMobile.ClientID %>').focus();
                return false;
            }
            if (document.getElementById('<%=txtMessage.ClientID %>').value == "") {

                alert("Please Enter Message.");
                document.getElementById('<%=txtMessage.ClientID %>').focus();
                return false;
            }

        }

        function IsNumeric(sText) {
            var ValidChars = "0123456789";
            var IsNumber = true;
            var Char;


            for (i = 0; i < sText.length && IsNumber == true; i++) {
                Char = sText.charAt(i);
                if (ValidChars.indexOf(Char) == -1) {
                    IsNumber = false;
                }
            }
            return IsNumber;

        }
        function validateForm() {
            var x = document.forms["aspnetForm"]["ctl00_ContentPlaceHolder1_txtContactEmail"].value
            var atpos = x.indexOf("@");
            var dotpos = x.lastIndexOf(".");
            if (atpos < 1 || dotpos < atpos + 2 || dotpos + 2 >= x.length) {
                alert("Not a valid e-mail address");
                document.getElementById('ctl00_ContentPlaceHolder1_txtContactEmail').focus();
                return false;
            }
        }
    </script>
</asp:Content>
