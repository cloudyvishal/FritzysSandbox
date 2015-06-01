<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Inner_Page_MB_MasterPage.Master" AutoEventWireup="true" CodeBehind="MB_NewsDetails.aspx.cs" Inherits="MobileWeb.MB_NewsDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div class="contentinnersection">
        <div class="innerpageheading">
            <h1>
                <asp:Label ID="lblnewstitle" runat="server"></asp:Label></h1>
        </div>
        <div class="innercontent">
            <asp:Literal ID="litContent" runat="server"></asp:Literal>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBodyEnd" runat="server">
</asp:Content>
