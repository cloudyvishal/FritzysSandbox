<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="SiteMap.aspx.cs" Inherits="FritzysPetCareProsSandbox.SiteMap" %>

<%@ Register Src="~/Controls/Suggestion.ascx" TagName="Suggestion" TagPrefix="Sg" %>
<%@ Register Src="~/Controls/TestZip.ascx" TagName="Zipcode1" TagPrefix="Z1" %>
<%@ Register Src="~/Controls/JoinFritzyClub.ascx" TagName="Join" TagPrefix="Jo" %>
<%@ Register Src="~/Controls/Appointment.ascx" TagName="Appointment" TagPrefix="AP" %>
<%@ Register Src="~/Controls/GiftCard.ascx" TagName="Gift" TagPrefix="GF" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntBody" runat="server">
    <div id="mainPlaceholder">
        <div class="wrappercontainer">
            <div id="wrapper">
                <div id="mainInnerContent">
                    <div id="innerLeftPannel">
                        <div class="title">
                            <asp:Image ID="aboutustitle" ImageUrl="http://naturesfreshpet.com/Images/sitemapTitle.jpg" runat="server"
                                AlternateText="" />
                        </div>
                        <div class="leftInner">
                            <div class="sitemapDiv">
                                <ul class="sitemap">
                                    <li><a href="Index.aspx" title="Home">Home</a></li>
                                    <li><a href="Services.aspx" title="Services">Services</a>
                                        <ul>
                                            <li><a href="Services.aspx" title="For your Cat">For Your Dog</a></li>
                                            <li><a href="Services.aspx" title="For Your Dog">For Your Dog </a></li>
                                        </ul>
                                    </li>
                                    <li><a href="Contactus.aspx" title="Products">Products</a></li>
                                    <li><a href="Contactus.aspx" title="Fles Tick & Hot Spot">Fles Tick & Hot Spot</a></li>
                                    <li><a href="FritzyFriends.aspx" title="Fritzy Friend">Fritzy Friend</a></li>
                                    <li><a href="Visitourvan.aspx" title="Visit Our Van">Visit Our Van </a></li>
                                    <li><a href="Registration.aspx" title="oin Fritzy’s Club">Join Fritzy’s Club</a></li>
                                    <li><a href="Aboutus.aspx" title="About Us">About Us </a></li>
                                    <li><a href="Contactus.aspx" title="Contact us">Contact us</a></li>
                                    <li><a href="Registration.aspx" title="Registration Basic">Registration Basic</a></li>
                                    <li><a href="Contactus.aspx" title="Careers">Careers</a></li>

                                </ul>
                            </div>
                        </div>
                    </div>
                    <div id="innerRightPannel">
                        <div class="img">
                            <Z1:Zipcode1 ID="ctlZipcode" runat="server" />
                            <Jo:Join ID="asd" runat="server" />
                            <AP:Appointment ID="Appointment1" runat="server" />
                            <GF:Gift ID="GF" runat="server" />
                            <div class="img">
                                <a href="#" title="Groomers blog">
                                    <img src="http://naturesfreshpet.com/Images/btn_groomers_blog.jpg" border="0" alt="Groomers Blog" class="groomersBlogImg" /></a>
                            </div>
                            <div class="img">
                                <a href="#" title="Pet lovers blog">
                                    <img src="http://naturesfreshpet.com/Images/btn_pet_lovers_blog.jpg" width="234" height="78" border="0" alt="Pet Lovers Blog" /></a>
                            </div>
                            <Sg:Suggestion ID="ctlSuggestion" runat="server" />
                        </div>
                    </div>
                </div>
                <div style="clear: both;">
                </div>
                <div id="mainBottomImg">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cntFooter" runat="server">
</asp:Content>
