<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ManageEmail.aspx.cs" Inherits="FritzysPetCareProsSandbox.Admin.ManageEmail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div class="innerContent">
        <div class="pageTitle">
            <h2>Manage Email</h2>
        </div>
        <asp:GridView ID="grdEmail" runat="server" Width="100%" GridLines="Horizontal"
            CellPadding="4" HeaderStyle-CssClass="headerStyle" CssClass="gridStyle" AlternatingRowStyle-CssClass="altGridStyle"
            AutoGenerateColumns="False">
            <AlternatingRowStyle CssClass="altGridStyle" />
            <Columns>
                <asp:TemplateField HeaderText="Sr. No.">
                    <ItemStyle CssClass="itemstyle" Width="5%" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="srno" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:HyperLinkField HeaderText="Email Name" ItemStyle-CssClass="itemstyle" HeaderStyle-CssClass="headerStyle"
                    DataNavigateUrlFields="PageName" DataNavigateUrlFormatString="ViewEmail.aspx?File={0}"
                    DataTextField="Name" NavigateUrl="ViewEmail.aspx" />

            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFooter" runat="server">
</asp:Content>
