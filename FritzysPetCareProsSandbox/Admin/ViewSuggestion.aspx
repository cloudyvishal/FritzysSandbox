<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ViewSuggestion.aspx.cs" Inherits="FritzysPetCareProsSandbox.Admin.ViewSuggestion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div class="innerContent">
        <div class="pageTitle">
            <h2>View Suggestions</h2>
        </div>
        <table class="adduserTable" cellpadding="6" cellspacing="0">

            <tr>
                <td style="width: 10%;">Name : </td>
                <td>
                    <asp:Label ID="lblName" runat="server" Text=""></asp:Label></td>
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
                <td>Comment : </td>
                <td>
                    <asp:Label ID="lblComment" runat="server" Text=""></asp:Label></td>
            </tr>
        </table>
        <asp:Button ID="btnBack" runat="server" Text="Back" ToolTip="Back" PostBackUrl="~/Admin/AdminHome.aspx" CssClass="btnBg" />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFooter" runat="server">
</asp:Content>
