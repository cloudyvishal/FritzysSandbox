<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ContactUsDetail.aspx.cs" Inherits="FritzysPetCareProsSandbox.Admin.ContactUsDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div class="innerContent">
        <div class="pageTitle">
            <h2>Contact Us Detail</h2>
        </div>
        <table class="adduserTable" cellpadding="6" cellspacing="0">
            <tr>
                <td style="width: 10%;">First Name : </td>
                <td>
                    <asp:Label ID="lblFName" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>Last Name : </td>
                <td>
                    <asp:Label ID="lblLName" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>Email :</td>
                <td>
                    <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>Phone :</td>
                <td>
                    <asp:Label ID="lblPhone" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>Message : </td>
                <td>
                    <div class="ContactDtlsOverflow">
                        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                    </div>
                </td>
            </tr>
        </table>
        <asp:Button ID="btnBack" runat="server" Text="Cancel" ToolTip="Cancel"
            CssClass="btnBg" OnClick="btnBack_Click" />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFooter" runat="server">
</asp:Content>
