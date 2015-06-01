<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Inner_Page_MB_MasterPage.Master" AutoEventWireup="true" CodeBehind="Dog_and_Pet_Anal_Gland_Expression.aspx.cs" Inherits="MobileWeb.Dog_and_Pet_Anal_Gland_Expression" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div class="contentinnersection">
        <div class="innerpageheading">
            <h1>
                <asp:Label ID="lblTitle" runat="server"></asp:Label><br />
                <br />
            </h1>
        </div>
        <div class="ServicesMidDiv">
            <asp:Image ID="ImgService" runat="server" AlternateText="" CssClass="imgfloatleft" />
            <span id="divDogService" runat="server"><b>
                <asp:Label ID="lblServiceDesc" CssClass="shortDesc" runat="server"></asp:Label></b>
            </span>
            <asp:Literal ID="litContent" runat="server"></asp:Literal>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBodyEnd" runat="server">
</asp:Content>
