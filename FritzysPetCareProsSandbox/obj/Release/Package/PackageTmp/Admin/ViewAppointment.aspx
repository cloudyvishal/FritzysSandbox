<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ViewAppointment.aspx.cs" Inherits="FritzysPetCareProsSandbox.Admin.ViewAppointment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div class="innerContent">
        <div class="pageTitle">
            <h2>Appointment Details
            </h2>
        </div>
        <div class="errorDiv" id="divError" runat="server" visible="false">
            <table width="100%">
                <tbody>
                    <tr>
                        <td align="left" rowspan="2">
                            <asp:Label ID="lblError" runat="server"></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>

        <table class="adduserTable" cellpadding="6" cellspacing="0">
            <tr>
                <td style="width: 15%;">Name :
                </td>
                <td>
                    <asp:Label ID="lblName" runat="server"></asp:Label>
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
                <td>Email :
                </td>
                <td>
                    <asp:Label ID="lblEmail" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Phone :
                </td>
                <td>
                    <asp:Label ID="lblPhone" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Date :
                </td>
                <td>
                    <asp:Label ID="lblDate" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Confirm By :
                </td>
                <td>
                    <asp:Label ID="lblConfirmBy" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Flexible :
                </td>
                <td>
                    <asp:Label ID="lblFlex" runat="server"></asp:Label>
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

        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btnBg"
            ToolTip="Cancel" OnClick="btnCancel_Click" />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFooter" runat="server">
</asp:Content>
