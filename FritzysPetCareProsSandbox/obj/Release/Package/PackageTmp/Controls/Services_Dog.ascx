﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Services_Dog.ascx.cs" Inherits="FritzysPetCarePros.Controls.Services_Dog" %>
<style type="text/css">
    .prevlink {
        color: #503414;
        font-size: 12px;
        text-decoration: underline;
    }

        .prevlink:hover {
            text-decoration: none;
        }

    .inactivelink {
        color: #ccc;
        text-decoration: none;
    }
</style>
<%--<div class="title">
    <img src="images/services_title.jpg" alt="Services" />
</div>--%>
<div class="ServicesDatalistDiv">
    <div class="serviceTitle">
        <div class="gradient">
            <h1>
                <span></span>Mobile Grooming Services</h1>
        </div>
    </div>
</div>
<div class="leftInner">
    <div class="ServicesforCats">
        <div class="ServicesinnerTitle">
            <img src="http://naturesfreshpet.com/Images/for_your_dogs_title.jpg" alt="Dog Grooming" />
        </div>
        <%--Region for Service header that is main service set from admin Start--%>
        <div class="ServicesDatalistDiv">
            <div class="left1">
                <asp:Image ID="imgDogservice" runat="server" AlternateText=" " />
                <%--<img src="Images/servicesDogImg.jpg" alt="" />--%>
            </div>
            <div class="ServicesRightCats">
                <div id="divDogService" runat="server">
                    <p>
                    </p>
                </div>
            </div>
        </div>
        <%--Region for Service header that is main service set from admin End --%>
        <%--  Data list is use to bind all services of cat Start --%>
        <div class="ServicesInnerDatalistDiv">
            <p>
                Fritzy's Pet Care Pros offer the following services for your dog:
            </p>
            <asp:UpdatePanel ID="up" runat="server">
                <ContentTemplate>
                    <asp:DataList ID="dlDog" runat="server" RepeatColumns="1" Width="100%" CellPadding="0"
                        CellSpacing="0">
                        <ItemTemplate>
                            <div class="news">
                                <div class="servicesImages">
                                    <asp:Image ID="Image1" ImageUrl="http://naturesfreshpet.com/Images/dogPaw.jpg" runat="server" AlternateText=" " />
                                </div>
                                <div class="ServicesCatsoverflowDiv">
                                    <asp:HyperLink ID="hypService" CssClass="newstitle" runat="server" NavigateUrl='<%#"http://naturesfreshpet.com/" + Eval("ServicePageNames") %>'
                                        Text='<%#Eval("ServiceTitle") %>'></asp:HyperLink>
                                    <div style="margin: 4px 0;">
                                    </div>
                                    <asp:Label ID="lblDesc" CssClass="description" Text='<%#Eval("ServiceDescription") %>'
                                        runat="server"></asp:Label>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                    <div class="prevNext" id="divprevNext" runat="server">
                        <ul>
                            <li>
                                <asp:LinkButton ID="lnkPrev" runat="server" Text="Previous" OnClick="lnkPrev_Click"
                                    ToolTip="Previous" CssClass="prevlink"></asp:LinkButton></li>
                            <li>
                                <asp:Label ID="lblDivider" runat="server" Text="|"></asp:Label>
                            </li>
                            <li>
                                <asp:LinkButton ID="lnkNext" runat="server" Text="Next" OnClick="lnkNext_Click" ToolTip="Next"
                                    CssClass="prevlink"></asp:LinkButton></li>
                        </ul>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <%--  Data list is use to bind all services of cat End --%>
        </div>
    </div>
</div>
