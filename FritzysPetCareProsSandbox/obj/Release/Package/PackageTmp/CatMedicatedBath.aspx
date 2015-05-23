<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="CatMedicatedBath.aspx.cs" Inherits="FritzysPetCareProsSandbox.CatMedicatedBath" %>

<%@ Register Src="~/Controls/Suggestion.ascx" TagName="Suggestion" TagPrefix="Sg" %>
<%@ Register Src="~/Controls/TestZip.ascx" TagName="Zipcode1" TagPrefix="Z1" %>
<%@ Register Src="~/Controls/JoinFritzyClub.ascx" TagName="Join" TagPrefix="Jo" %>
<%@ Register Src="~/Controls/Appointment.ascx" TagName="Appointment" TagPrefix="AP" %>
<%@ Register Src="~/Controls/GiftCard.ascx" TagName="Gift" TagPrefix="GF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                            <asp:LinkButton ToolTip="Click for Coupon." runat="server" ID="lnkHoverBanner">
                                <asp:PlaceHolder ID="plh" runat="server"></asp:PlaceHolder>
                            </asp:LinkButton>
                            
                        </div>
                        <!-- -------------------Middle body content here---------------------- -->
                        <div class="ServicesDatalistDiv">
                            <div class="serviceTitle">
                                <h1>
                                    <asp:Label ID="lblServiceTitle" runat="server"></asp:Label></h1>
                            </div>
                            <div class="title">
                            </div>
                            <div class="backlinkDiv">
                                <a class="servbacklink" href="javascript: window.history.back()">Go Back</a>
                            </div>                            
                            <div class="ServicesMidDiv">
                                <asp:Image ID="ImgService" runat="server" AlternateText="" CssClass="imgfloatleft" />
                                <div id="divDogService" runat="server">
                                    <asp:Label ID="lblServiceDesc" CssClass="shortDesc" runat="server"></asp:Label>
                                </div>
                                <%--Literal control will show content of services--%>
                                <asp:Literal ID="litContent" runat="server"></asp:Literal>
                            </div>
                        </div>
                        <!-- ----------------------------------------------------------------- -->
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
