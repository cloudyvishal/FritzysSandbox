﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="FritzyFriends.aspx.cs" Inherits="FritzysPetCareProsSandbox.FritzyFriends" %>

<%@ Register Src="~/Controls/Suggestion.ascx" TagName="Suggestion" TagPrefix="Sg" %>
<%@ Register Src="~/Controls/TestZip.ascx" TagName="Zipcode1" TagPrefix="Z1" %>
<%@ Register Src="~/Controls/JoinFritzyClub.ascx" TagName="Join" TagPrefix="Jo" %>
<%@ Register Src="~/Controls/Appointment.ascx" TagName="Appointment" TagPrefix="AP" %>
<%@ Register Src="~/Controls/giftcard.ascx" TagName="Gift" TagPrefix="GF" %>
<%@ Register Src="~/Controls/Banner.ascx" TagName="Banner" TagPrefix="BN" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntBody" runat="server">
    <!--[if IE]>
	
	    <link href="ie.css" rel="stylesheet" type="text/css" />
   
    <![endif]-->
    <div id="mainPlaceholder">
        <!-- main place holder start here -->
        <div class="wrappercontainer">
            <div id="wrapper">
                <!--wrapper start here -->
                <div id="mainInnerContent">
                    <!-- Main Content Starts Here -->
                    <div id="innerLeftPannel">
                        <!-- inner left pannel start here -->
                        <div class="flashImg">
                            <BN:Banner ID="Banner" runat="server" />
                        </div>
                        <div class="title">
                            <asp:Image ID="fritzyfriendtitle" ImageUrl="http://naturesfreshpet.com/Images/fritzyfriendTitle.jpg" runat="server"
                                AlternateText="" />
                        </div>
                        <div class="leftInner">
                            <div class="aboutinnerleft">
                                <asp:Image ID="leftimage" ImageUrl="http://naturesfreshpet.com/Images/fritzyfriendleft.jpg" runat="server"
                                    AlternateText="" />
                            </div>
                            <div class="aboutinnerright">
                                <asp:Literal ID="litContent" runat="server"></asp:Literal>
                            </div>
                        </div>
                        <div class="title">
                            <asp:Image ID="blanktitle" ImageUrl="http://naturesfreshpet.com/Images/pageTitle.jpg" runat="server" AlternateText="" />
                        </div>
                        <div class="leftInner">
                            <div class="petcareBg">
                                <asp:DataList ID="dtlFriends" runat="server" RepeatColumns="2" Width="100%" CellPadding="0"
                                    CellSpacing="0">
                                    <ItemTemplate>
                                        <div class="friends">
                                            <div class="imagesfriends">
                                                <asp:Image ID="Image1" ImageUrl='<%# Session["HomePath"] + "StoreData/FriendLogo/" + Eval("Logo") %>'
                                                    runat="server" AlternateText="" />
                                            </div>
                                            <div class="overflowfriendsDiv">
                                                <asp:HyperLink ID="hypURL" CssClass="friendsLink" Target="_blank" NavigateUrl='<%# "http://" + Eval("RefLink") %>'
                                                    Text='<%#Eval("RefLink") %>' runat="server"></asp:HyperLink>
                                                <br />
                                                <asp:Label CssClass="description" ID="lblDesc" Text='<%#Eval("Description") %>' runat="server"></asp:Label>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:DataList>
                            </div>
                        </div>
                        <div class="titleBar">
                            <asp:Image ID="pagetitle" ImageUrl="http://naturesfreshpet.com/Images/pageTitle.jpg" runat="server" AlternateText="" />
                        </div>
                        <div class="leftInner">
                            <div class="visitOurVan">
                                <a href="Visitourvan.aspx" title="Visit our van">
                                    <img src="http://naturesfreshpet.com/Images/visit_our_van.jpg" width="668" height="243" border="0" alt="Visit Our Van" /></a>
                            </div>
                        </div>
                    </div>
                    <!-- inner left pannel end here -->
                    <div id="innerRightPannel">
                        <!-- innere right pannel start here -->
                        <div class="img1">
                            <Z1:Zipcode1 ID="ctlZipcode" runat="server" />
                            <Jo:Join ID="asd" runat="server" />
                            <AP:Appointment ID="Appointment2" runat="server" />
                            <GF:Gift ID="GF" runat="server" />
                            <div class="img">
                                <a href="comingsoon.aspx" title="Groomers blog">
                                    <img src="http://naturesfreshpet.com/Images/btn_groomers_blog.jpg" border="0" alt="Groomers Blog" class="groomersBlogImg" /></a>
                            </div>
                            <div class="img">
                                <a href="comingsoon.aspx" title="Pet lovers blog">
                                    <img src="http://naturesfreshpet.com/Images/btn_pet_lovers_blog.jpg" width="234" height="78" border="0" alt="Pet Lovers Blog" /></a>
                            </div>
                            <Sg:Suggestion ID="ctlSuggestion" runat="server" />
                        </div>
                    </div>
                    <!-- inner right pannel end here -->
                </div>
                <!-- main content end here -->
                <div style="clear: both;">
                </div>
                <div id="mainBottomImg">
                </div>
            </div>
            <!-- wrapper end here -->
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cntFooter" runat="server">
</asp:Content>
