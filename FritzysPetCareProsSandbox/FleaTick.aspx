<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="FleaTick.aspx.cs" Inherits="FritzysPetCareProsSandbox.FleaTick" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Suggestion.ascx" TagName="Suggestion" TagPrefix="Sg" %>
<%@ Register Src="~/Controls/TestZip.ascx" TagName="Zipcode1" TagPrefix="Z1" %>
<%@ Register Src="~/Controls/JoinFritzyClub.ascx" TagName="Join" TagPrefix="Jo" %>
<%@ Register Src="~/Controls/Appointment.ascx" TagName="Appointment" TagPrefix="AP" %>
<%@ Register Src="~/Controls/giftcard.ascx" TagName="Gift" TagPrefix="GF" %>
<%@ Register Src="~/Controls/Banner.ascx" TagName="Banner" TagPrefix="BN" %>
<%@ Register Src="~/Controls/Product_Flea.ascx" TagName="Product" TagPrefix="PR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntBody" runat="server">
    <div style="width: 95%" id="divError" runat="server" visible="false">
        <table width="100%">
            <tbody>
                <tr>
                    <td align="left" rowspan="2">
                        <asp:Label ID="lblError" runat="server" Visible="False" Font-Bold="True"></asp:Label>&nbsp;
                             
                    </td>
                </tr>
            </tbody>
        </table>
    </div>

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

                        <div class="ServicesDatalistDiv">
                            <div class="serviceTitle">
                                <div class="gradient">
                                    <h1><span></span>Flea, Tick & Hotspot Treatments</h1>
                                </div>
                            </div>
                        </div>
                        <div class="HomeleftInner">
                            <div class="innerPannelLeft">
                                <div class="innerTitle">
                                    <img src="http://localhost:50372/Images/for_your_dogs_title.jpg" alt="Flea Treatment, Tick Treatment" />
                                </div>
                                <div class="left1">
                                    <asp:Image ID="imgDogservice" runat="server" AlternateText="" />
                                </div>
                                <div class="right1">
                                    <div id="divDogService" runat="server" class="innerParaDiv">
                                        <p>
                                        </p>
                                    </div>

                                    <a href="Services.aspx" class="more" title="more">more</a>
                                </div>

                            </div>
                            <div class="innerPannelRight">
                                <div class="innerTitle">
                                    <asp:Image ID="forcats" ImageUrl="http://localhost:50372/Images/for_your_cats_title.jpg" runat="server" AlternateText="Flea Treatment, Tick Treatment" />
                                </div>


                                <div class="left">
                                    <asp:Image ID="imgCatservice" runat="server" AlternateText="" />

                                </div>
                                <div class="right">

                                    <div id="divCatService" runat="server" class="innerParaDiv">
                                        <p>
                                        </p>
                                    </div>

                                    <a href="Services.aspx" class="more" title="more">more</a>
                                </div>

                            </div>
                        </div>
                        <div class="title">
                            <asp:Image ID="productHeader" ImageUrl="http://localhost:50372/Images/products_title.jpg" runat="server" AlternateText="" />
                        </div>

                        <div class="HomeleftInner">

                            <PR:Product ID="Pro" runat="server" />
                        </div>
                        <div class="titleBar">
                            <img src="http://localhost:50372/Images/content_shadow3.jpg" width="668" height="39" alt="" />
                        </div>
                        <div class="leftInner">
                            <div class="visitOurVan">
                                <a href="Visitourvan.aspx" title="Visit our van">
                                    <img src="http://localhost:50372/Images/visit_our_van.jpg" width="668" height="243" border="0" alt="Visit Our Van" /></a>
                            </div>
                        </div>
                    </div>
                    <!-- inner left pannel end here -->
                    <div id="innerRightPannel">
                        <!-- innere right pannel start here -->
                        <div class="img1">

                            <Z1:Zipcode1 ID="ctlZipcode" runat="server" />

                            <Jo:Join ID="asd" runat="server" />

                            <AP:Appointment ID="Appointment1" runat="server" />
                            <GF:Gift ID="GF" runat="server" />


                            <div class="img">
                                <a href="comingsoon.aspx" title="GROOMERS BLOG">
                                    <img src="http://localhost:50372/Images/btn_groomers_blog.jpg" border="0" alt="GROOMERS BLOG" class="groomersBlogImg" /></a>
                            </div>
                            <div class="img">
                                <a href="comingsoon.aspx" title="PET LOVERS BLOG">
                                    <img src="http://localhost:50372/Images/btn_pet_lovers_blog.jpg" width="234" height="78" border="0" alt="PET LOVERS BLOG" /></a>
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
    <!--[if IE]>
	
	    <link href="ie.css" rel="stylesheet" type="text/css" />
   
    <![endif]-->
    <script type="text/javascript" src="Scripts/phone_validation.js"></script>
    <script type="text/javascript" language="javascript">
        // function Use to check maxlength of textbox 
        function checkTextAreaMaxLength(textBox, e, length) {
            var mLen = textBox["MaxLength"];
            if (null == mLen)
                mLen = length;
            var maxLength = parseInt(mLen);
            if (!checkSpecialKeys(e)) {
                if (textBox.value.length > maxLength - 1) {
                    if (window.event)//IE
                        e.returnValue = false;
                    else//Firefox
                        e.preventDefault();
                }
            }
        }
        function checkSpecialKeys(e) {
            if (e.keyCode != 8 && e.keyCode != 46 && e.keyCode != 37 && e.keyCode != 38 && e.keyCode != 39 && e.keyCode != 40)
                return false;
            else
                return true;
        }
    </script>
</asp:Content>
