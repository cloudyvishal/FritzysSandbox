<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ViewUserAppointment.aspx.cs" Inherits="FritzysPetCareProsSandbox.Admin.ViewUserAppointment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div class="innerContent">
        <div class="pageTitle">
            <h2>View Appointment</h2>
        </div>
    </div>
    <table class="adduserTable" cellpadding="6" cellspacing="0">
        <tr>
            <td style="width: 20%;">Date Time :
            </td>
            <td>
                <asp:Label ID="lblDate" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Address :
            </td>
            <td>
                <asp:Label ID="lblAddress" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Flexible :
            </td>
            <td>
                <asp:Label ID="lblFlexible" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>ConfirmBy :
            </td>
            <td>
                <asp:Label ID="lblConfirmBy" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Note :
            </td>
            <td>
                <asp:Label ID="lblNote" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFooter" runat="server">
</asp:Content>
