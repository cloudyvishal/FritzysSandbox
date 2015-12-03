<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Services_Cat.ascx.cs" Inherits="MobileWeb.MB_Controls.Services_Cat" %>
<div class="contentinnersection">
    <div class="innerpageheading">
        <h1>Mobile Grooming Services</h1>
    </div>
    <div class="innercontent">
        <div class="productlistdiv">
            <div class="productimg">
                <asp:Image ID="imgCatservice" runat="server" Height="62" Width="73" AlternateText=" " />
            </div>
            <div class="product_shortdesc" id="divCatService" runat="server">
            </div>
        </div>
        <div class="servicetitle">
            Fritzy&acute;s Pet Care Pros Offer the following services for your cat:          
        </div>
        <div style="clear: both;"></div>
        <asp:DataList ID="dlCat" runat="server" RepeatColumns="1" Width="100%" CellPadding="0"
            CellSpacing="0">
            <ItemTemplate>
                <div class="news">
                    <div class="servicesImages">
                        <asp:Image ID="Image1" ImageUrl="http://localhost:50372/FritzysMobile/Images/catPaw.jpg" runat="server" AlternateText=" " />
                    </div>
                    <div class="ServicesCatsoverflowDiv">
                        <asp:HyperLink ID="hypService" CssClass="newstitle" runat="server" NavigateUrl='<%# "http://localhost:50372/FritzysMobile/" + Eval("ServicePageNames") %>' Text='<%#Eval("ServiceTitle") %>'></asp:HyperLink>
                        <div style="margin: 4px 0;">
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:DataList>
    </div>
</div>
