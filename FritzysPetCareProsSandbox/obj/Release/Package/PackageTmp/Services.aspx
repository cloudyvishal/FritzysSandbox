﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="Services.aspx.cs" Inherits="FritzysPetCareProsSandbox.ServicesDetails" %>

<%@ Register Src="~/Controls/Suggestion.ascx" TagName="Suggestion" TagPrefix="Sg" %>
<%@ Register Src="~/Controls/TestZip.ascx" TagName="Zipcode1" TagPrefix="Z1" %>
<%@ Register Src="~/Controls/JoinFritzyClub.ascx" TagName="Join" TagPrefix="Jo" %>
<%@ Register Src="~/Controls/Appointment.ascx" TagName="Appointment" TagPrefix="AP" %>
<%@ Register Src="~/Controls/GiftCard.ascx" TagName="Gift" TagPrefix="GF" %>
<%@ Register Src="~/Controls/Banner.ascx" TagName="Banner" TagPrefix="BN" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!--[if IE]>
	
	    <link href="ie.css" rel="stylesheet" type="text/css" />
   
    <![endif]-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntBody" runat="server">
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
                        <asp:PlaceHolder ID="plcServices" runat="server"></asp:PlaceHolder>

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
                                <a href="commingsoon.aspx" title="Groomers blog">
                                    <img src="http://naturesfreshpet.com/Images/btn_groomers_blog.jpg" border="0" alt="Groomers Blog" class="groomersBlogImg" /></a>
                            </div>
                            <div class="img">
                                <a href="commingsoon.aspx" title="Pet lovers blog">
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
