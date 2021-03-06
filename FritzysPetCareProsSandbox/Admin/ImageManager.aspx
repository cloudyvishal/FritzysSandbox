﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ImageManager.aspx.cs" Inherits="FritzysPetCareProsSandbox.Admin.ImageManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div class="innerContent">
        <div class="pageTitle">
            <h2>Manage Gift Card</h2>
        </div>
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

        <table class="adduserTable" border="0" cellpadding="6">
            <tr>
                <td valign="top">Gift Card:
                </td>
                <td>
                    <asp:Image ID="ImgGift" runat="server" />
                </td>
            </tr>

            <tr>
                <td valign="top">
                    <span class="star">*</span>Upload New GiftCard:
                </td>
                <td>
                    <asp:FileUpload ID="fluGiftCard" runat="server" onkeypress="return false" />
                    <asp:Button ID="btnGift" runat="server" Text="Upload New GiftCard" CssClass="servbtnBg"
                        OnClick="btnGift_Click" />
                    <br />
                    <br />
                    You can upload .JPEG, .GIF, .BMP, .PNG files with maximum size of 234 X 138.
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFooter" runat="server">
</asp:Content>
