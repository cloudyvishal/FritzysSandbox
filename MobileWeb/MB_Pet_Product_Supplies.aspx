<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Inner_Page_MB_MasterPage.Master" AutoEventWireup="true" CodeBehind="MB_Pet_Product_Supplies.aspx.cs" Inherits="MobileWeb.MB_Pet_Product_Supplies" %>

<%@ Register Src="MB_Controls/Product_Flea.ascx" TagName="Product" TagPrefix="PR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div class="contentinnersection">
        <div class="innerpageheading">
            <h1>Pet Products &amp; Supplies</h1>
        </div>
        <PR:Product ID="Pro" runat="server" />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBodyEnd" runat="server">
</asp:Content>
