<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header_Logout.ascx.cs" Inherits="FritzysPetCarePros.Controls.Header_Logout" %>
<%@ Register Src="~/Controls/TempSuggestion.ascx" TagName="ucSuggestion" TagPrefix="uc" %>

<script type="text/ecmascript" lang="ecmascript">
    function CheckSearch1() {
        if (document.getElementById('<%=txtSearchLogout.ClientID %>').value == "") {
            return false;
        }
    }
</script>

<div id="mainHeader">
    <!-- main header start here -->
    <div id="mainHeaderContent">
        <!-- main header content start here -->
        <div id="headerLogo">
            <!-- header logo start here -->
            <a id="lnkLogo" runat="server" title="Fritzy's pet care pros">
                <asp:Image ID="mainLogo" ImageUrl="http://naturesfreshpet.com/Images/mainLogo.jpg" runat="server" AlternateText="Fritzy's pet care pros" /></a>
        </div>
        <!-- header logo end here -->
        <div id="hederRightNav">
            <!-- header right nav start here -->
            <div id="toplinks">
                <a href="../Aboutus.aspx" id="linkAboutus" title="Fritzy's pet care pros : About Us"
                    runat="server">About Us</a> l <a href="../Contactus.aspx" id="linkCareers" title="Fritzy's pet care pros : Careers"
                        runat="server">Careers</a> l <a href="../SiteMap.aspx" id="linkSitemap" title="Fritzy's pet care pros : Site Map"
                            runat="server">Site Map</a> l <a href="../MyAccount.aspx" id="lnkMyAccount"
                                runat="server" title="Fritzy's pet care pros : My Account">My Account</a>
                l
                <uc:ucSuggestion ID="ctlTempSug" runat="server" />
            </div>
            <div id="callToday">
            </div>
            <div class="cart">
                <!-- cart start here -->
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <div class="search">
                                <label class="searchlbl">
                                    Search</label>
                            </div>
                        </td>
                        <td>
                            <div class="textbox">
                                <asp:TextBox ID="txtSearchLogout" class="textfield" runat="server"></asp:TextBox>
                            </div>
                        </td>
                        <td>
                            <div class="go">
                                <asp:ImageButton ID="btnSearchLogin" runat="server" ImageUrl="http://naturesfreshpet.com/Images/btn_go.gif"
                                    alt="Go" OnClientClick="return CheckSearch1();" OnClick="btnSearchLogin_Click" />
                            </div>
                        </td>
                        <td valign="bottom"></td>
                    </tr>
                </table>
            </div>
            <!-- cart end here -->
        </div>
        <!-- header right nav end here -->
        <div id="topnavigation">
            <!-- top navigation start here -->
            <div id="topnav">
                <ul id="nav1">
                    <li><a href="Index.aspx" id="home" title="Fritzy's pet care pros "></a></li>
                    <li><a href="Services.aspx" id="services" title="Fritzy's pet care pros : SERVICES"></a></li>
                    <li><a href="Products.aspx" id="products" title="Fritzy's pet care pros : PRODUCTS"></a></li>
                    <li><a href="FleaTick.aspx" id="flea" title="Fritzy's pet care pros : FLEA, TICK &amp; HOT SPOT"></a></li>
                    <li><a href="FritzyFriends.aspx" id="fritzyfriends" title="Fritzy's pet care pros : FRITZY'S FRIENDS"></a></li>
                    <li><a href="Contactus.aspx" id="contactus" title="Fritzy's pet care pros : CONTACT US"></a></li>
                    <li><a href="LogOut.aspx" id="logout" title="LOGOUT"></a></li>
                </ul>
            </div>
        </div>
        <!-- top nav ends here -->
    </div>
    <!-- main header content end here -->
</div>
