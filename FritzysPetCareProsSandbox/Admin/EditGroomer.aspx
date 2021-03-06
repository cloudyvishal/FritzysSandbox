﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="EditGroomer.aspx.cs" Inherits="FritzysPetCareProsSandbox.Admin.EditGroomer" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div class="innerContent">
        <div class="pageTitle">
            <h2>Edit Groomer</h2>
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
                <td align="right">
                    <span class="star">*</span><asp:Label ID="lblEmailID" runat="server" Text="Email ID :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEmailID" runat="server" MaxLength="70" Width="230px" CssClass="textBox"> 
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqContactEmailID" runat="server" ValidationGroup="valContactus"
                        SetFocusOnError="true" ControlToValidate="txtEmailID" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Email ID is required">      </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="REEmailId" runat="server" ValidationGroup="valContactus"
                        ErrorMessage="<b>Required Field Missing</b><br />Invalid Email ID" ControlToValidate="txtEmailID"
                        SetFocusOnError="true" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        Display="None">  </asp:RegularExpressionValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="valContactEmailID" Enabled="true"
                        TargetControlID="reqContactEmailID" HighlightCssClass="validatorCalloutHighlight" />
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="EmailId" Enabled="true"
                        TargetControlID="REEmailId" HighlightCssClass="validatorCalloutHighlight" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    <span class="star">*</span><asp:Label ID="lblName" runat="server" Text="Name :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" MaxLength="50" Width="130px" CssClass="textBox"> 
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="valContactus"
                        SetFocusOnError="true" ControlToValidate="txtName" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Name is required">  
                    </asp:RequiredFieldValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender3"
                        Enabled="true" TargetControlID="RequiredFieldValidator3" HighlightCssClass="validatorCalloutHighlight" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblAddress" runat="server" Text="Address :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtAddress" runat="server" MaxLength="100" CssClass="txt_address"
                        TextMode="MultiLine"> 
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <span class="star">*</span><asp:Label ID="Label2" runat="server" Text="Base City :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtBaseCity" runat="server" MaxLength="30" CssClass="textBox"> 
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ValidationGroup="valContactus"
                        SetFocusOnError="true" ControlToValidate="txtBaseCity" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Base City is required">  
                    </asp:RequiredFieldValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender10"
                        Enabled="true" TargetControlID="RequiredFieldValidator9" HighlightCssClass="validatorCalloutHighlight" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    <span class="star">*</span><asp:Label ID="Label3" runat="server" Text="State :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtState" runat="server" MaxLength="30" CssClass="textBox"> 
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="valContactus"
                        SetFocusOnError="true" ControlToValidate="txtState" Display="None" ErrorMessage="<b>Required Field Missing</b><br />State is required">  
                    </asp:RequiredFieldValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender2"
                        Enabled="true" TargetControlID="RequiredFieldValidator2" HighlightCssClass="validatorCalloutHighlight" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    <span class="star">*</span><asp:Label ID="lblZipcode" runat="server" Text="Zip Code :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtZipCode" runat="server" MaxLength="5" Width="130px" CssClass="textBox"> 
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="valContactus"
                        SetFocusOnError="true" ControlToValidate="txtZipCode" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Zip Code is required">  
                    </asp:RequiredFieldValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1"
                        Enabled="true" TargetControlID="RequiredFieldValidator1" HighlightCssClass="validatorCalloutHighlight" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    <span class="star">*</span><asp:Label ID="lblHomePhone" runat="server" Text="Phone 1 :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtHomePhone" runat="server" Width="130px" CssClass="textBox" onkeydown="javascript:backspacerDOWN(this,event);"
                        onkeyup="javascript:backspacerUP(this,event);"> 
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="valContactus"
                        SetFocusOnError="true" ControlToValidate="txtHomePhone" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Phone Number 1 is required">  </asp:RequiredFieldValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender5"
                        Enabled="true" TargetControlID="RequiredFieldValidator5" HighlightCssClass="validatorCalloutHighlight" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblPersonalCell" runat="server" Text="Phone 2 :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPersonalCell" runat="server" Width="130px" CssClass="textBox"
                        onkeydown="javascript:backspacerDOWN(this,event);" onkeyup="javascript:backspacerUP(this,event);"> 
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <span class="star">*</span><asp:Label ID="Label1" runat="server" Text="Sheet Name :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSheetName" runat="server" MaxLength="50" Width="130px" CssClass="textBox"> 
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="valContactus"
                        SetFocusOnError="true" ControlToValidate="txtSheetName" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Sheet name is required">  </asp:RequiredFieldValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender4"
                        Enabled="true" TargetControlID="RequiredFieldValidator4" HighlightCssClass="validatorCalloutHighlight" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    <span class="star">*</span><asp:Label ID="Label4" runat="server" Text="Time Zone :"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlTimeZone" runat="server">
                        <asp:ListItem>Select</asp:ListItem>
                        <asp:ListItem>Atlantic Standard Time</asp:ListItem>
                        <asp:ListItem>Central Standard Time</asp:ListItem>
                        <asp:ListItem>Eastern Standard Time</asp:ListItem>
                        <asp:ListItem>Mountain Standard Time</asp:ListItem>
                        <asp:ListItem>Pacific Standard Time</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvddlTimeZone" runat="server" ValidationGroup="valContactus"
                        SetFocusOnError="true" ControlToValidate="ddlTimeZone" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Time Zone is required"
                        InitialValue="Select">  
                    </asp:RequiredFieldValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender7"
                        Enabled="true" TargetControlID="rfvddlTimeZone" HighlightCssClass="validatorCalloutHighlight" />
                </td>
            </tr>
        </table>
        <asp:Button ID="btnUpdate" runat="server" Text="Update" ToolTip="Update" CssClass="btnBg"
            ValidationGroup="valContactus" OnClick="btnUpdate_Click" />&nbsp;
        <asp:Button ID="btnCancel" runat="server" CausesValidation="false" Text="Cancel"
            PostBackUrl="http://localhost:50372/Admin/ManageGroomer.aspx?SearchFor=0&SearchText=" ToolTip="Cancel"
            CssClass="btnBg" />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFooter" runat="server">
    <script type="text/javascript" lang="javascript" src="../Script/Phone_Validation.js"></script>

    <script type="text/javascript" lang="javascript" src="../Script/Validation.js"></script>
</asp:Content>
