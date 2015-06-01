<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Services_Common.ascx.cs" Inherits="MobileWeb.MB_Controls.Services_Common" %>
<link href="../Style/Style.css" rel="stylesheet" type="text/css" />
<div class="contentinnersection">
    <div class="innerpageheading">
        <h1>Mobile Grooming Services<br />
            For Your Dogs</h1>
    </div>
    <div class="innercontent">
        <div class="productlistdiv">
            <div class="productimg">
                <asp:Image ID="ImgDog" runat="server" ImageUrl="http://localhost:50372/FritzysMobile/StoreData/ServicePageServices/GINN3221TVJ.jpg" />
            </div>
            <div class="product_shortdesc" id="divDogService" runat="server">
                <p>
                    Keep your pet looking great between regular appointments with our brush-out service.              
                </p>
            </div>
            <div style="clear: both;"></div>
            <asp:DataList ID="dlDog" runat="server" RepeatColumns="1" Width="100%" CellPadding="0"
                CellSpacing="0">
                <ItemTemplate>
                    <div class="news">
                        <div class="servicesImages">
                            <asp:Image ID="Image1" ImageUrl="~/Images/dogPaw.jpg" runat="server" AlternateText=" " />
                        </div>
                        <div class="overflowDiv">
                            <asp:HyperLink ID="hypService" CssClass="newstitle" runat="server" NavigateUrl='<%#"http://localhost:50372/FritzysMobile/" + Eval("ServicePageNames") %>' Text='<%#Eval("ServiceTitle") %>'></asp:HyperLink>
                            <div style="margin: 4px 0;">
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
    <div class="innerpageheading">
        <h1>For Your Cats</h1>
    </div>
    <div class="innercontent">
        <div class="productlistdiv">
            <div class="productimg">
                <asp:Image ID="imgCatservice" runat="server" />
            </div>
            <div class="product_shortdesc" id="divCatService" runat="server">
                <p>
                    Keep your pet looking great between regular appointments with our brush-out service.              
                </p>
            </div>
            <div style="clear: both;"></div>
            <asp:DataList ID="dlCat" runat="server" RepeatColumns="1" Width="100%" CellPadding="0"
                CellSpacing="0">
                <ItemTemplate>
                    <div class="news">
                        <div class="servicesImages">
                            <asp:Image ID="Image1" ImageUrl="~/Images/catPaw.jpg" runat="server" AlternateText=" " />
                        </div>
                        <div class="overflowDiv">

                            <asp:HyperLink ID="hypService" CssClass="newstitle" runat="server" NavigateUrl='<%# "http://localhost:50372/FritzysMobile/" + Eval("ServicePageNames") %>' Text='<%#Eval("ServiceTitle") %>'></asp:HyperLink>
                            <div style="margin: 4px 0;">
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>

    </div>
</div>


