<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MB_MasterPage.Master" AutoEventWireup="true" CodeBehind="MB_Index.aspx.cs" Inherits="MobileWeb.MB_Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div class="contentsection">
        <div class="hometitle">
            <img src="images/home_title.jpg" height="15" width="294" alt="" />
        </div>
        <div class="dogtitle">
            <div class="divfordogtitle">
                <a href="MB_services.aspx?PetID=Dog" title="For Your Dogs">
                    <img src="images/for_dog.jpg" border="0" height="70" width="157" alt="For Your Dogs" /></a>
            </div>
            <div class="divforcattitle">
                <a href="MB_services.aspx?PetID=Cat" title="For Your Cats">
                    <img src="images/for_cat.jpg" height="70" width="157" alt="For Your Cats" border="0" /></a>
            </div>
            <asp:Label ID="lblUser" runat="server"></asp:Label>
        </div>
    </div>
    <div class="homebottom" id="dvloginusernew" runat="server">
        <a href="MB_visit-our-van.aspx" title="Visit Our Van">
            <div class="visitourvan" title="Visit Our Van">
            </div>
        </a><a href="MB_login.aspx" title="Login">
            <div class="makeappoint" title="Login">
            </div>
        </a><a href="tel:18773748997">
            <div class="phonecall">
            </div>
        </a>
    </div>
    <div class="homebottom" id="dvloginusernew1" runat="server">
        <a href="MB_visit-our-van.aspx" title="Visit Our Van">
            <div class="visitourvan" title="Visit Our Van">
            </div>
        </a><a href="MB_schedule_appointment.aspx" title="Make An Appointment Now">
            <div class="makeappoint" title="Make An Appointment Now">
            </div>
        </a><a href="tel:18773748997">
            <div class="phonecall">
            </div>
        </a>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBodyEnd" runat="server">
</asp:Content>
