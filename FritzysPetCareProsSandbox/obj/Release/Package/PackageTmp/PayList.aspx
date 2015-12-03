<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="PayList.aspx.cs" Inherits="FritzysPetCareProsSandbox.PayList" %>

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
                    <!-- reg main start here -->
                    <table align="center" style="width: 100%">
                        <tr>
                            <td>
                                <table align="center" style="width: 100%">
                                    <tr>
                                        <td align="left" colspan="2">
                                            <h2>Payments
                                                <br />
                                            </h2>
                                            <p style="text-align: center">
                                                <asp:label id="lblsmsg" runat="server" text="Your Payment Submitted Successfully!!!"
                                                    forecolor="Green" font-bold="true" font-size="Medium" visible="false"></asp:label>
                                            </p>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" width="108">
                                            <span style="font-size: medium; font-weight: bolder">
                                                <asp:label id="lblSyncPayment" runat="server" text="Sync Payment :" cssclass="appnt_lbl"></asp:label>
                                            </span>
                                            &nbsp;
                                        </td>
                                        <td align="left" width="210">
                                            <span style="font-size: medium; font-weight: bolder">
                                                <asp:linkbutton id="btnSycAppLink" runat="server" enabled="false" onclick="btnSycAppLink_Click">Sync Appointment Payment</asp:linkbutton>
                                            </span>
                                        </td>
                                    </tr>

                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <!-- reg top end here -->
                <div style="clear: both;">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cntFooter" runat="server">
</asp:Content>
