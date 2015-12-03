<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Inner_Page_MB_MasterPage.Master" AutoEventWireup="true" CodeBehind="MB_Services.aspx.cs" Inherits="MobileWeb.MB_Services" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div>
        <asp:PlaceHolder ID="plcServices" runat="server"></asp:PlaceHolder>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBodyEnd" runat="server">
</asp:Content>
