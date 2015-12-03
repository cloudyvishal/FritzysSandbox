<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Inner_Page_MB_MasterPage.Master" AutoEventWireup="true" CodeBehind="MB_AboutUs.aspx.cs" Inherits="MobileWeb.MB_AboutUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div class="contentinnersection">
        <div class="innerpageheading">
            <h1>About Us</h1>
        </div>
        <div class="innercontent">
            <img src="Images/about_us_image.jpg" height="71" width="73" alt="" />
            <asp:Literal ID="litContent" runat="server"></asp:Literal>
            <div class="servicetitle">
                Pet Care Pros News:          
            </div>
            <asp:DataList ID="dtlNews" DataKeyField="NewsID" runat="server" RepeatColumns="1" Width="100%" OnItemDataBound="dtlNews_ItemDataBound" CellPadding="0" CellSpacing="0" Style="float: left;">
                <ItemTemplate>
                    <div class="news">
                        <div class="servicesImages">
                            <asp:Image ID="Image1" ImageUrl="Images/catPaw.jpg" runat="server" AlternateText=" " />
                        </div>
                        <div class="ServicesCatsoverflowDiv">
                            <asp:HyperLink ID="hypService" CssClass="newstitle" runat="server" NavigateUrl='<%# "MB_newsdetails.aspx?ID=" + Eval("NewsID") %>' Text='<%#Eval("NewsTitle") %>'></asp:HyperLink>                        
                        </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBodyEnd" runat="server">
</asp:Content>
