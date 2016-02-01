<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ManageAppointmentType.aspx.cs" Inherits="FritzysPetCareProsSandbox.Admin.ManageAppointmentType" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div class="innerContent">
        <div class="pageTitle">
            <h2>Manage Appointment Type</h2>
        </div>
        <table>
            <tr>
                <td>
                    <div class="errorDivlarge" id="divError" runat="server" visible="false">
                        <table width="100%">
                            <tbody>
                                <tr>
                                    <td align="left" rowspan="2">
                                        <asp:Label ID="lblError" runat="server" Visible="False"></asp:Label>&nbsp;
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <br style="clear: both;" />
                </td>
            </tr>
            <tr>
                <td>
                    <div id="divsearch" runat="server" class="searchtopDiv">
                        <table border="0" class="searchTable">
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                        <br style="clear: both;" />
                    </div>
                </td>
            </tr>
        </table>
        <asp:GridView ID="gdvApptType" runat="server" AutoGenerateColumns="False" CellPadding="0"
            AllowSorting="true" OnRowDataBound="gdvApptType_OnRowDataBound" AllowPaging="True"
            DataKeyNames="ApptTypeId" GridLines="Vertical" Width="100%" OnPageIndexChanging="gdvApptType_PageIndexChanging"
            HeaderStyle-CssClass="headerStyle" CssClass="gridStyle" AlternatingRowStyle-CssClass="altGridStyle"
            OnRowCancelingEdit="gdvApptType_RowCancelingEdit" OnRowEditing="gdvApptType_RowEditing"
            OnRowUpdating="gdvApptType_RowUpdating" OnSorting="gdvApptType_Sorting" OnDataBound="gdvApptType_DataBound" OnRowCreated="gdvApptType_RowCreated">
            <PagerTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Page" CommandArgument="First">First</asp:LinkButton>
                <asp:Label ID="pmore" runat="server" Text="..."></asp:Label>
                <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Page" CommandArgument="Prev">Prev</asp:LinkButton>
                <asp:LinkButton ID="p0" runat="server">LinkButton</asp:LinkButton>
                <asp:LinkButton ID="p1" runat="server">LinkButton</asp:LinkButton>
                <asp:LinkButton ID="p2" runat="server">LinkButton</asp:LinkButton>
                <asp:Label ID="CurrentPage" runat="server" Text="Label"></asp:Label>
                <asp:LinkButton ID="p4" runat="server">LinkButton</asp:LinkButton>
                <asp:LinkButton ID="p5" runat="server">LinkButton</asp:LinkButton>
                <asp:LinkButton ID="p6" runat="server">LinkButton</asp:LinkButton>
                <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Page" CommandArgument="Next">Next</asp:LinkButton>
                <asp:Label ID="nmore" runat="server" Text="..."></asp:Label>
                <asp:LinkButton ID="LinkButton4" runat="server" CommandName="Page" CommandArgument="Last">Last</asp:LinkButton>
            </PagerTemplate>
            <AlternatingRowStyle CssClass="altGridStyle" />
            <PagerStyle CssClass="gridPager" />
            <Columns>
                <asp:TemplateField HeaderText="Sr. No.">
                    <ItemStyle CssClass="itemstyle" Width="5%" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="srno" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Appointment Type">
                    <ItemStyle CssClass="itemstyle" />
                    <HeaderStyle CssClass="headerStyle" />
                    <EditItemTemplate>
                        <asp:TextBox ID="txtAppointmentType" runat="server" Text='<%# Bind("ApptType") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblApptType" runat="server" Text='<%# Bind("ApptType") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField HeaderText="Edit" ShowEditButton="True" CausesValidation="False">
                    <ItemStyle CssClass="itemstyle" Width="15%" />
                    <HeaderStyle CssClass="headerStyle" />
                </asp:CommandField>
            </Columns>
        </asp:GridView>
        <div id="DivlnkShowBreed" runat="server" style="display: block">
            <asp:Button ID="btnNew" runat="server" Text="Add" ToolTip="Add" CssClass="btnBg" OnClientClick="return showAddBreed();" OnClick="btnNew_Click" />
        </div>
        <div id="divAddBreed" runat="server" style="display: none" class="itemstyle">
            Add Appointment Type<span class="star" style="color: #f00;">*</span>
            <asp:TextBox ID="txtAppointmentType" ValidationGroup="valBreed" runat="server" CssClass="textBox"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAppointmentType" ValidationGroup="valBreed"
                Display="None" SetFocusOnError="true" ErrorMessage="<b>Required Field Missing</b><br />Appointment Type is required.">  
            </asp:RequiredFieldValidator>
            <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender4"
                TargetControlID="RequiredFieldValidator3" HighlightCssClass="validatorCalloutHighlight"
                Enabled="true" />
            <asp:Button ID="ImgSubmitService" runat="server" ValidationGroup="valBreed" CssClass="btnBg" Text="Add" ToolTip="Add"
                CausesValidation="true" OnClick="ImgSubmitService_Click" />&nbsp;&nbsp;            
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="false" ToolTip="Cancel" OnClientClick="return HideAddBreed();" CssClass="btnBg" />
        </div>
        <asp:Button ID="lnkNorec" runat="server" CssClass="gobackbtnBg" Text="Go Back" Visible="false" OnClick="lnkNorec_Click" />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFooter" runat="server">
    <script type="text/javascript" lang="javascript">
        function showAddBreed() {
            document.getElementById('<%=divAddBreed.ClientID %>').style.display = "block";
             document.getElementById('<%=DivlnkShowBreed.ClientID %>').style.display = "none";
             return false;
         }
         function HideAddBreed() {
             document.getElementById('<%=divAddBreed.ClientID %>').style.display = "none";
            document.getElementById('<%=DivlnkShowBreed.ClientID %>').style.display = "block";
            document.getElementById('<%=txtAppointmentType.ClientID %>').value = "";

            return false;
        }
    </script>
</asp:Content>
