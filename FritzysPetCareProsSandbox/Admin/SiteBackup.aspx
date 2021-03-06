﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SiteBackup.aspx.cs" Inherits="FritzysPetCareProsSandbox.Admin.SiteBackup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div class="innerContent">
        <div class="pageTitle">
            <h2>Web site backup</h2>
        </div>
        <%--Region Error/Success message start--%>
        <div class="errorDiv" id="divError" runat="server" visible="false">
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
        <%--Region Error/Success message end--%>
        <div class="FooterTableDiv" onkeypress="javascript:return FormPanel_FireDefaultButton(event,'ctl00_ContentPlaceHolder1_btnApply')">
            <table border="0" width="100%">
                <tr>
                    <td style="font-size: small">
                        <p align="left">
                            <b></b>
                        </p>
                        <p>
                            <br />
                            Click on the <b>Site Download</b> button to download complete web site backup.
                        </p>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <div id="divProgress" style="display: none; visibility: hidden;">
                            <img src="images/loader.gif" alt="" />
                            <span class="a2">&nbsp;&nbsp;Processing...Please wait</span>
                        </div>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnSiteDownload" runat="server" CssClass="btnBg" Text="Site Download" OnClick="btnSiteDownload_Click" />
                    </td>
                </tr>
                <tr>
                    <td style="font-size: small">
                        <p align="left">
                            <b></b>
                        </p>
                        <asp:ListView ID="FileListView" runat="server" Visible="false">

                            <LayoutTemplate>
                                <table>
                                    <tr id="itemPlaceholder" runat="server" />
                                </table>
                            </LayoutTemplate>

                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="include" runat="server" /></td>
                                    <td>
                                        <asp:Label ID="label" runat="server" Text="<%# Container.DataItem %>" /></td>
                                </tr>
                            </ItemTemplate>

                            <EmptyDataTemplate>
                                <div>Nothing to see here...</div>
                            </EmptyDataTemplate>

                        </asp:ListView>
                        <p>
                            <br />
                            Click on the <b>Database Backup</b> button to take the backup for database.
                        </p>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btndatabasedwn" runat="server" CssClass="btnBg" Text="Database Backup" OnClick="btndatabasedwn_Click" />
                    </td>
                </tr>
                <tr>
                    <td style="font-size: small">
                        <p align="left">
                            <b></b>
                        </p>
                        <p>
                            <br />
                            Click on the <b>Database Download</b> button to download the recent database backup.
                        </p>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnDatabaseDownload" runat="server" CssClass="btnBg" Text="Database Download" OnClick="btnDatabaseDownload_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFooter" runat="server">
</asp:Content>
