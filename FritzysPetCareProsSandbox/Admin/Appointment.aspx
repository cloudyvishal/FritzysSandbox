<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Appointment.aspx.cs" Inherits="FritzysPetCareProsSandbox.Admin.Appointments" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <script lang="javascript" type="text/javascript">
        function ShowDiv() {
            document.getElementById('<%=divShow.ClientID %>').style.display = "Block";
            document.getElementById('<%=divBtn.ClientID %>').style.display = "none";
            return false;
        }

        function HideDiv() {
            document.getElementById('<%=divShow.ClientID %>').style.display = "none";
    document.getElementById('<%=divBtn.ClientID %>').style.display = "block";
    return false;
}

function ValidateExport() {
    if (document.getElementById('<%=txtStartDate.ClientID %>').value == "") {
        document.getElementById('<%=txtStartDate.ClientID %>').focus();
        alert("Please select start date");
        return false;
    }
    if (document.getElementById('<%=txtEndDate.ClientID %>').value == "") {
        document.getElementById('<%=txtEndDate.ClientID %>').focus();
        alert("Please select end date");
        return false;
    }
}
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div class="innerContent">
        <div class="pageTitle">
            <h2>Manage Appointment</h2>
        </div>
        <%--Region Error/Success message start--%>
        <div class="errorDiv" id="divError" runat="server" visible="false">
            <table width="100%">
                <tbody>
                    <tr>
                        <td align="left" rowspan="2">
                            <asp:Label ID="lblError" runat="server" Visible="False"></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <%--Region Appointment Grid start --%>
        <asp:Label ID="lblError1" runat="server"></asp:Label>
        <asp:GridView ID="grdAppointment" runat="server" DataKeyNames="AppointmentID" AllowPaging="true"
            AllowSorting="true" PageSize="10" CellPadding="0" GridLines="Vertical" Width="100%"
            HeaderStyle-CssClass="headerStyle" AutoGenerateColumns="false" CssClass="gridStyle itemstyle"
            AlternatingRowStyle-CssClass="altGridStyle" OnPageIndexChanging="grdAppointment_PageIndexChanging"
            OnDataBound="grdAppointment_DataBound" OnSorting="grdAppointment_Sorting" OnRowCreated="grdAppointment_RowCreated">

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
                <asp:TemplateField>
                    <ItemStyle CssClass="itemstyle" Width="5%" />
                    <HeaderStyle CssClass="headerStyle" />
                    <HeaderTemplate>
                        <asp:CheckBox ID="chkall" runat="server" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelect" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Name" SortExpression="FullName">
                    <ItemStyle CssClass="itemstyle" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="lblFullTime" runat="server" Text='<%# Bind("FullName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Date/Time" SortExpression="Date">
                    <ItemStyle CssClass="itemstyle" Width="12%" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:HyperLink ID="hyp" runat="server" Text='<%# Bind("Date", "{0:MMM-dd-yyyy hh:mm tt}")  %>'
                            NavigateUrl='<%# "ViewAppointment.aspx?ID=" + Eval("AppointmentID") + "&p=1" %>'></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Time" Visible="false">
                    <ItemStyle CssClass="itemstyle" Width="8%" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="lblTime" runat="server" Text='<%# Bind("T") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Flexible">
                    <ItemStyle CssClass="itemstyle" Width="14%" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="lblFlex" runat="server" Text='<%# Bind("Flex") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Address">
                    <ItemStyle CssClass="itemstyle" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="lblAddress" runat="server" Text='<%# Bind("Address") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ConfirmBy" SortExpression="ConfirmBy" Visible="false">
                    <ItemStyle CssClass="itemstyle" Width="10%" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="lblConfirmBy" runat="server" Text='<%# Bind("ConfirmBy") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Note">
                    <ItemStyle CssClass="itemstyle" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="lblNote" runat="server" Text='<%# Bind("Note") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <%--Region Appointment Grid end --%>
        <%-- Region  Button start --%>
        <div id="divBtn" runat="server" style="display: block;">
            <asp:Button ID="btnDelete" runat="server" Text="Delete" ToolTip="Delete" CssClass="btnBg"
                OnClick="btnDelete_Click1" />&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnExp" runat="server" Text="EXPORT" ToolTip="Export" CssClass="btnBg"
                OnClientClick="return ShowDiv();" />
        </div>
        <%-- Region  Button end --%>
        <%-- Region  Search start --%>
        <div class="itemstyle" style="margin: 10px 0pt 0pt; display: none;" id="divShow"
            runat="server">
            <table border="0" style="margin: 10px 0pt 0pt;">
                <tr>
                    <td>Start Date :
                    </td>
                    <td>
                        <asp:TextBox ID="txtStartDate" runat="server"></asp:TextBox>
                        <asp:ImageButton ID="imgCalPop" runat="server" ImageUrl="~/Images/calImage.jpg" />
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/d/yyyy" PopupButtonID="imgCalPop"
                            TargetControlID="txtStartDate">
                        </cc1:CalendarExtender>
                    </td>
                    <td>End Date :
                    </td>
                    <td>
                        <asp:TextBox ID="txtEndDate" runat="server"></asp:TextBox>
                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/calImage.jpg" />
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="MM/d/yyyy" PopupButtonID="ImageButton1"
                            TargetControlID="txtEndDate">
                        </cc1:CalendarExtender>
                    </td>
                    <td>
                        <asp:Button ID="btnExport" runat="server" Text="Export" ToolTip="Export" CssClass="servbtnBg"
                            OnClientClick="return ValidateExport();" OnClick="btnExport_Click" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" ToolTip="Cancel" CssClass="servbtnBg"
                            OnClientClick="return HideDiv();" />
                    </td>
                </tr>
            </table>
        </div>
        <%-- Region  Search end --%>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFooter" runat="server">
</asp:Content>
