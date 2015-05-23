<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="UploadGroomerAppointments.aspx.cs" Inherits="FritzysPetCareProsSandbox.Admin.UploadGroomerAppointments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
        <ContentTemplate>
            <div class="innerContent">
                <div class="pageTitle">
                    <h2>Upload Groomer Appointments Excel Files</h2>
                </div>
                <div class="errorDiv" id="divError" runat="server" visible="true">
                    <table width="100%">
                        <tbody>
                            <tr>
                                <td align="left" rowspan="2">
                                    <asp:Label ID="lblError" runat="server" Visible="true" EFont-Bold="True"></asp:Label>&nbsp;
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <table class="adduserTable" cellpadding="6" cellspacing="0">
                    <tr id="trupload" runat="server">
                        <td valign="top">Upload File
                        </td>
                        <td>
                            <asp:FileUpload ID="ApptFile" runat="server" CssClass="selectBox" />
                            <br />
                            <asp:RegularExpressionValidator ID="revImage" runat="server" ControlToValidate="ApptFile"
                                ErrorMessage=" ! file format is not supported." ValidationExpression="^.*\.((x|X)(l|L)(s|S))$"
                                ValidationGroup="Submit" />
                            <br />
                            <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click"
                                CssClass="btnBg" />
                        </td>
                    </tr>
                    <tr id="tr2" runat="server">
                        <td style="width: 150px;">&nbsp;
                        </td>
                        <td valign="top">
                            <asp:Label ID="lblMessage" runat="server" EFont-Bold="True"></asp:Label>
                            <asp:Panel ID="Panel3" runat="server">
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnUpload" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFooter" runat="server">
</asp:Content>
