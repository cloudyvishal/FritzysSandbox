<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Inner_Page_MB_MasterPage.Master" AutoEventWireup="true" CodeBehind="MB_Menu.aspx.cs" Inherits="MobileWeb.MB_Menu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div style="width: 317px; margin: 0; padding: 0 2px 0 1px; float: left;">
        <a href="MB_Index.aspx">
            <img src="Images/home_menu_title.jpg" width="317" height="37" alt="" title="Home" /></a>
        <a href="MB_Services.aspx">
            <img src="Images/mobile_grooming_services_title.jpg" width="317" height="37" alt=""
                title="Mobile Grooming Services" /></a> <a href="MB_pet-product-supplies.aspx">
                    <img src="Images/pet_product_and-_supplies_title.jpg" width="317" height="37" alt=""
                        title="Pet Products & Supplies" /></a> <a href="MB_Flea-Tick.aspx">
                            <img src="images/flea_tick_title.jpg" width="317" height="37" alt="" title="Flea,Tick & Hot Spot" /></a>
        <a href="MB_Registration.aspx">
            <img src="Images/join_fritzy_club_title.jpg" width="317" height="37" alt="" title="Join Fritzy's Club" /></a>
        <a href="MB_Visit_Our_Van.aspx">
            <img src="Images/visit_our_van_title.jpg" width="317" height="37" alt="" title="Visitor Our Van" /></a>
        <a href="MB_ContactUs.aspx">
            <img src="Images/contact_us_title.jpg" width="317" height="37" alt="" title="Contact Us" /></a>
        <a href="MB_AboutUs.aspx">
            <img src="Images/about_us_title.jpg" width="317" height="37" alt="" title="About Us" /></a>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBodyEnd" runat="server">
</asp:Content>
