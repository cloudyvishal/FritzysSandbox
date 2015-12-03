<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="FritzysPetCareProsSandbox.Admin.AddUser" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div class="innerContent">
        <div class="pageTitle">
            <h2>Add Admin</h2>
        </div>
        <%--Region Error/Success message start--%>
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
        <%--Region Error/Success message end--%>
        <%--Region table to user information form start--%>
        <table class="adduserTable" cellpadding="6" cellspacing="0">
            <tr>
                <td style="width: 20%;">
                    <span class="star">*</span> First Name :
                </td>
                <td>
                    <asp:TextBox ID="txtFirstName" CssClass="textBox" runat="server" MaxLength="45"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFirstName"
                        Display="None" SetFocusOnError="true" ErrorMessage="<b>Required Field Missing</b><br />First Name is required."> </asp:RequiredFieldValidator>
                    <ajaxtoolkit:validatorcalloutextender runat="Server" id="ValidatorCalloutExtender0"
                        targetcontrolid="RequiredFieldValidator1" highlightcssclass="validatorCalloutHighlight" />
                </td>
            </tr>
            <tr>
                <td>
                    <span class="star">*</span> Last Name :
                </td>
                <td>
                    <asp:TextBox ID="txtLastName" CssClass="textBox" runat="server" MaxLength="45"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLastName"
                        Display="None" SetFocusOnError="true" ErrorMessage="<b>Required Field Missing</b><br />Last Name is required."> </asp:RequiredFieldValidator>
                    <ajaxtoolkit:validatorcalloutextender runat="Server" id="ValidatorCalloutExtender1"
                        targetcontrolid="RequiredFieldValidator2" highlightcssclass="validatorCalloutHighlight" />
                </td>
            </tr>
            <tr>
                <td>
                    <span class="star">*</span> Username :
                </td>
                <td>
                    <asp:TextBox ID="txtUserName" CssClass="textBox" runat="server" MaxLength="15"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtUserName"
                        Display="None" SetFocusOnError="true" ErrorMessage="<b>Required Field Missing</b><br />Username is required."> </asp:RequiredFieldValidator>
                    <ajaxtoolkit:validatorcalloutextender runat="Server" id="ValidatorCalloutExtender2"
                        targetcontrolid="RequiredFieldValidator3" highlightcssclass="validatorCalloutHighlight" />
                </td>
            </tr>
            <tr>
                <td>
                    <span class="star">*</span> Password :
                </td>
                <td>
                    <asp:TextBox ID="txtPassword" CssClass="textBox" runat="server" MaxLength="15" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPassword"
                        Display="None" SetFocusOnError="true" ErrorMessage="<b>Required Field Missing</b><br />Password is required."> </asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="Cust1" runat="server" Display="None" ControlToValidate="txtPassword"
                        ValidationGroup="val1" SetFocusOnError="true" ClientValidationFunction="CheckPassword"
                        ErrorMessage="<b>Required Field Missing</b><br />Password length should not be less than 6 characters"> </asp:CustomValidator>
                    <ajaxtoolkit:validatorcalloutextender runat="Server" id="ValidatorCalloutExtender3"
                        targetcontrolid="RequiredFieldValidator4" highlightcssclass="validatorCalloutHighlight" />
                    <ajaxtoolkit:validatorcalloutextender runat="Server" id="ValidatorCalloutExtender4"
                        targetcontrolid="Cust1" highlightcssclass="validatorCalloutHighlight" />
                </td>
            </tr>
            <tr>
                <td>
                    <span class="star">*</span> Confirm Password :
                </td>
                <td>
                    <asp:TextBox ID="txtConfirmPassword" CssClass="textBox" runat="server" MaxLength="15"
                        TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtConfirmPassword"
                        Display="None" SetFocusOnError="true" ErrorMessage="<b>Required Field Missing</b><br />Confirm Password is required."> </asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" Display="None" ControlToValidate="txtConfirmPassword"
                        SetFocusOnError="true" ClientValidationFunction="CheckConfirmPassword" ErrorMessage="<b>Required Field Missing</b><br />Password and confirm password should be same"> </asp:CustomValidator>
                    <ajaxtoolkit:validatorcalloutextender runat="Server" id="ValidatorCalloutExtender5"
                        targetcontrolid="RequiredFieldValidator6" highlightcssclass="validatorCalloutHighlight" />
                    <ajaxtoolkit:validatorcalloutextender runat="Server" id="ValidatorCalloutExtender6"
                        targetcontrolid="CustomValidator1" highlightcssclass="validatorCalloutHighlight" />
                </td>
            </tr>
            <tr>
                <td>
                    <span class="star">*</span> Email :
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" CssClass="textBox" runat="server" MaxLength="45"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtEmail"
                        Display="None" SetFocusOnError="true" ErrorMessage="<b>Required Field Missing</b><br />Email is required."> </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct email."
                        SetFocusOnError="true" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"> </asp:RegularExpressionValidator>
                    <ajaxtoolkit:validatorcalloutextender runat="Server" id="ValidatorCalloutExtender7"
                        targetcontrolid="RequiredFieldValidator5" highlightcssclass="validatorCalloutHighlight" />
                    <ajaxtoolkit:validatorcalloutextender runat="Server" id="ValidatorCalloutExtender8"
                        targetcontrolid="revEmail" highlightcssclass="validatorCalloutHighlight" />
                </td>
            </tr>
            <tr>
                <td>Mobile :
                </td>
                <td>
                    <asp:TextBox ID="txtPhone" runat="server" CssClass="textBox" MaxLength="15" onkeydown="javascript:backspacerDOWN(this,event);"
                        onkeyup="javascript:backspacerUP(this,event);"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Address1 :
                </td>
                <td>
                    <asp:TextBox ID="txtAddress1" CssClass="textBox" runat="server" MaxLength="45"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Address2 :
                </td>
                <td>
                    <asp:TextBox ID="txtAddress2" CssClass="textBox" runat="server" MaxLength="45"></asp:TextBox>
                </td>
            </tr>
        </table>
        <%--Region table to user information form start--%>


        <%--region button starts --%>
        <asp:Button ID="btnAddUser" runat="server" Text="Add User" ToolTip="Add User" CssClass="btnBg"
            OnClick="btnAddUser_Click" />
        <asp:Button ID="btnBack" runat="server" Text="Cancel" ToolTip="Cancel" CssClass="btnBg"
            CausesValidation="false" PostBackUrl="~/Admin/ManageUser.aspx?SearchFor=0&SearchText=" OnClick="btnBack_Click" />

        <%--region button end --%>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFooter" runat="server">
    <script type="text/javascript" src="../../Scripts/phone_validation.js"></script>

    <script type="text/javascript" lang="javascript">
        function CheckPassword(source, args) {
            if (document.getElementById('<%= txtPassword.ClientID %>').value == "") {
                args.IsValid = false;
            }
            else if (document.getElementById('<%= txtPassword.ClientID %>').value.length < 6) {
                args.IsValid = false;
            }
        }
        function CheckConfirmPassword(source, args) {
            if (document.getElementById('<%= txtPassword.ClientID %>').value == document.getElementById('<%= txtConfirmPassword.ClientID %>').value) {
                args.IsValid = true;
            }
            else {
                args.IsValid = false;
            }
        }
    </script>
</asp:Content>
