<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ViewGroomerAppointment.aspx.cs" Inherits="FritzysPetCareProsSandbox.Admin.ViewGroomerAppointment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <style type="text/css">
        .itemstyleEdit a {
            float: left;
            clear: both;
        }

        .itemstyleSeq input {
            width: 15px !important;
        }

        .ViewAptGrid {
            margin: 15px 0 0 0;
        }

        .EditAptGrid {
            margin: 15px 0 0 -36px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div class="innerContent">
        <div class="pageTitle">
            <h2>View Grooming Appointments</h2>
        </div>
        <table>
            <tr>
                <td>
                    <div class="errorDivlarge" id="divError" runat="server" visible="false">
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
                    <br style="clear: both;" />
                </td>
            </tr>
            <tr>
                <td class="keepcenter">
                    <asp:Calendar ID="calDate" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66"
                        BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
                        ForeColor="#663399" ShowGridLines="True" Width="50%" OnDayRender="calDate_DayRender"
                        OnSelectionChanged="calDate_SelectionChanged">
                        <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                        <SelectorStyle BackColor="#FFCC66" />
                        <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                        <OtherMonthDayStyle ForeColor="#CC9966" />
                        <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                        <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                        <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                    </asp:Calendar>
                </td>
            </tr>
        </table>
        <div id="div1" runat="server" style="display: block;">
            <asp:Label ID="lblSelectDate" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnAdd" runat="server" Text="Add Appointment" ToolTip="Add Groomers Appointment"
                CssClass="btnBg" OnClick="btnAdd_Click" />&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnDeleteAppointment" runat="server" Text="Delete Old Appointment"
                OnClientClick="return ShowDiv();" CssClass="btnBg" ToolTip="Delete Old Appointment"
                OnClick="btnDeleteAppointment_Click" />&nbsp;&nbsp;&nbsp;
            <input id="buttonDeleteSelectedAppt" class="btnBg" type="submit" value="Delete Selected Appointments" disabled onclick="return delconfirm();" />
        </div>
        <div class="ViewAptGrid" id="DvAptGrid" runat="server">
            <asp:GridView ID="GrdUsers" runat="server" DataKeyNames="AppointmentID" AutoGenerateColumns="False"
                AllowSorting="true" AllowPaging="true" OnPageIndexChanging="GrdUsers_PageIndexChanging"
                OnRowCancelingEdit="GrdUsers_RowCancelingEdit" OnRowEditing="GrdUsers_RowEditing"
                OnRowUpdating="GrdUsers_RowUpdating" OnSorting="GrdUsers_Sorting" OnRowDataBound="GrdUsers_RowDataBound"
                OnDataBound="GrdUsers_DataBound" OnRowCreated="GrdUsers_RowCreated" PageSize="100"
                CellPadding="0" GridLines="Vertical" Width="100%" HeaderStyle-CssClass="headerStyle"
                CssClass="viewgridStyle" AlternatingRowStyle-CssClass="altGridStyle" OnRowDeleting="GrdUsers_RowDeleting">
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
                    <asp:TemplateField HeaderText="Seq" SortExpression="SequenceNo">
                        <ItemStyle CssClass="itemstyle itemstyleSeq" Width="5%" />
                        <HeaderStyle CssClass="headerStyle" />
                        <ItemTemplate>
                            <asp:Label ID="lblSequenceNo" runat="server" Text='<%# Bind("SequenceNo")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtSequenceNo" Width="25px" runat="server" Text='<%# Bind("SequenceNo")%>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorSeq" runat="server" ValidationGroup="valContactus"
                                SetFocusOnError="true" ControlToValidate="txtSequenceNo" Display="None" ErrorMessage="Date/Time field should not be blank">  
                            </asp:RequiredFieldValidator>
                            <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtenderSeq"
                                Enabled="true" TargetControlID="RequiredFieldValidatorSeq" HighlightCssClass="validatorCalloutHighlight" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="false">
                        <ItemStyle CssClass="itemstyle" Width="3%" />
                        <HeaderStyle CssClass="headerStyle" />
                        <HeaderTemplate>
                            <asp:CheckBox ID="chkall" runat="server" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Groomer" SortExpression="Name">
                        <ItemStyle CssClass="itemstyle" />
                        <HeaderStyle CssClass="headerStyle" />
                        <ItemTemplate>
                            <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlName" runat="server" Width="77px">
                                <asp:ListItem Value="Select" Selected="True"></asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Date / Time">
                        <ItemStyle CssClass="itemstyle" Width="10%" />
                        <HeaderStyle CssClass="headerStyle" />
                        <ItemTemplate>
                            <asp:Label ID="lblAppointmentDate" runat="server" Text='<%# Bind("DateTimeFormat")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtAppointmentDate" Width="100px" runat="server" Text='<%# Bind("DateTimeFormat")%>'
                                TextMode="MultiLine" Rows="1" onkeypress="return valDate(event);"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="reqDate" runat="server" ValidationGroup="valContactus"
                                SetFocusOnError="true" ControlToValidate="txtAppointmentDate" Display="None"
                                ErrorMessage="Date/Time field should not be blank">  </asp:RequiredFieldValidator>
                            <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1"
                                Enabled="true" TargetControlID="reqDate" HighlightCssClass="validatorCalloutHighlight" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="String">
                        <ItemStyle CssClass="itemstyle" Width="35%" />
                        <HeaderStyle CssClass="headerStyle" />
                        <ItemTemplate>
                            <asp:Label ID="lblString" runat="server" Text='<%# Bind("Others")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtOthers" runat="server" TextMode="MultiLine" Width="200px" MaxLength="500" Height="140px" Font-Size="11px"
                                Text='<%# Bind("Others")%>' onkeypress="return valOther(event);"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="reqOther" runat="server" ValidationGroup="valContactus"
                                SetFocusOnError="true" ControlToValidate="txtOthers" Display="None" ErrorMessage="String should not be blank">  </asp:RequiredFieldValidator>
                            <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="valOther" Enabled="true"
                                TargetControlID="reqOther" HighlightCssClass="validatorCalloutHighlight" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Rev">
                        <ItemStyle CssClass="itemstyle" Width="7%" HorizontalAlign="left" />
                        <HeaderStyle CssClass="headerStyle1" />
                        <ItemTemplate>
                            <asp:Label ID="lblExpectedTotalRevenue" runat="server" Text='<%# Bind("ExpectedTotalRevenue")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtExpectedTotalRevenue" Width="50px" runat="server" Text='<%# Bind("ExpectedTotalRevenue")%>'
                                onkeypress="return valRev(event);" MaxLength="8"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="valContactus"
                                EnableClientScript="true" SetFocusOnError="true" ControlToValidate="txtExpectedTotalRevenue"
                                Display="None" ErrorMessage="Expected revenue field should not be blank">  
                            </asp:RequiredFieldValidator>
                            <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender2"
                                Enabled="true" TargetControlID="RequiredFieldValidator2" HighlightCssClass="validatorCalloutHighlight" />
                            <asp:RegularExpressionValidator ID="repExpectedRevenue" EnableClientScript="true"
                                runat="server" Display="None" ErrorMessage="<b>Expected Revenue should be Dollars ($xxx.xx)"
                                ValidationGroup="valContactus" SetFocusOnError="true" ControlToValidate="txtExpectedTotalRevenue"
                                ValidationExpression="^\d*(\.\d{1,4})?$"></asp:RegularExpressionValidator>
                            <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender3"
                                Enabled="true" TargetControlID="repExpectedRevenue" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Time">
                        <ItemStyle CssClass="itemstyle" Width="7%" HorizontalAlign="left" />
                        <HeaderStyle CssClass="headerStyle1" />
                        <ItemTemplate>
                            <asp:Label ID="lbltxtExpectedPetTime" runat="server" Text='<%# Bind("ExpPetTime")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtExpectedPetTime" Width="35px" runat="server" Text='<%# Bind("ExpPetTime")%>'
                                onkeypress="return valPetTime(event);" MaxLength="4"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorPetTime" runat="server" ValidationGroup="valContactus"
                                EnableClientScript="true" SetFocusOnError="true" ControlToValidate="txtExpectedPetTime"
                                Display="None" ErrorMessage="Expected pet time should not be blank">  
                            </asp:RequiredFieldValidator>
                            <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtenderPetTime"
                                Enabled="true" TargetControlID="RequiredFieldValidatorPetTime" HighlightCssClass="validatorCalloutHighlight" />
                            <asp:RegularExpressionValidator ID="repPetTime" EnableClientScript="true" runat="server"
                                Display="None" ErrorMessage="<b>Expected pet time allow only numbers" ValidationGroup="valContactus"
                                SetFocusOnError="true" ControlToValidate="txtExpectedPetTime" ValidationExpression="^\d*(\.\d{1,4})?$"></asp:RegularExpressionValidator>
                            <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtenderPetTime1"
                                Enabled="true" TargetControlID="repPetTime" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Presented">
                        <ItemStyle CssClass="itemstyle" Width="8%" />
                        <HeaderStyle CssClass="headerStyle" />
                        <ItemTemplate>
                            <asp:Label ID="lblStatusPresented" runat="server" Text='<%# Bind("StatusPresentedDt")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlStatusPresented" Width="55" runat="server">
                            </asp:DropDownList>
                            <asp:Label ID="lblStatusP" runat="server" Text='<%# Bind("StatusPresentedDt")%>'
                                Visible="false"></asp:Label>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Start Time">
                        <ItemStyle CssClass="itemstyle" Width="8%" />
                        <HeaderStyle CssClass="headerStyle" />
                        <ItemTemplate>
                            <asp:Label ID="lblAptSTime" runat="server" Text='<%# Bind("ApptStartTime","{0:hh:mm:ss tt}")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="End Time">
                        <ItemStyle CssClass="itemstyle" Width="8%" />
                        <HeaderStyle CssClass="headerStyle" />
                        <ItemTemplate>
                            <asp:Label ID="lblAptETime" runat="server" Text='<%# Bind("ApptEndTime","{0:hh:mm:ss tt}")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Completed">
                        <ItemStyle CssClass="itemstyle" Width="8%" />
                        <HeaderStyle CssClass="headerStyle" />
                        <ItemTemplate>
                            <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField HeaderText="Edit" ShowEditButton="True" CausesValidation="True"
                        ValidationGroup="valContactus">
                        <ItemStyle CssClass="itemstyle itemstyleEdit" Width="7%" />
                        <HeaderStyle CssClass="headerStyle" />
                    </asp:CommandField>
                    <asp:TemplateField HeaderText="">
                        <ItemStyle CssClass="itemstyle" Width="5%" HorizontalAlign="left" />
                        <ItemTemplate>
                            <input type="image" src="/images/deleteicon.gif" onclick="return singleDelete('chkDelete<%# Eval("AppointmentID") %>    ')" /><input type="checkbox" name="chkDelete<%# Eval("AppointmentID") %>" id="chkDelete<%# Eval("AppointmentID") %>" onclick="    showDeleteAllButton();" />
                        </ItemTemplate>
                        <HeaderStyle CssClass="headerStyle1" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Seq" SortExpression="SequenceNo" Visible="false">
                        <ItemStyle CssClass="itemstyle" Width="1%" />
                        <HeaderStyle CssClass="headerStyle" />
                        <ItemTemplate>
                            <asp:Label ID="lblAppointmentID" runat="server" Text='<%# Bind("AppointmentID")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="GID" Visible="false">
                        <ItemStyle CssClass="itemstyle" Width="1%" />
                        <ItemTemplate>
                            <asp:Label ID="lblGId" runat="server" Text='<%# Bind("GID")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Astatus" Visible="false">
                        <ItemStyle CssClass="itemstyle" Width="1%" />
                        <ItemTemplate>
                            <asp:Label ID="lblAStatusId" runat="server" Text='<%# Bind("AStatus")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Astatus" Visible="false">
                        <ItemStyle CssClass="itemstyle" Width="1%" />
                        <ItemTemplate>
                            <asp:Label ID="lblSPresented" runat="server" Text='<%# Bind("StatusPresented")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div id="divShow" runat="server" style="display: none; margin: 10px 0 0 0;" class="itemstyle">
            <table border="0" style="margin: 10px 0pt 0pt;">
                <tr>
                    <td>
                        <span class="star" style="color: #f00;">*</span>Select Date:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlMonth" runat="server">
                            <asp:ListItem Text="January" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Febuary" Value="2"></asp:ListItem>
                            <asp:ListItem Text="March" Value="3"></asp:ListItem>
                            <asp:ListItem Text="April" Value="4"></asp:ListItem>
                            <asp:ListItem Text="May" Value="5"></asp:ListItem>
                            <asp:ListItem Text="June" Value="6"></asp:ListItem>
                            <asp:ListItem Text="July" Value="7"></asp:ListItem>
                            <asp:ListItem Text="August" Value="8"></asp:ListItem>
                            <asp:ListItem Text="September" Value="9"></asp:ListItem>
                            <asp:ListItem Text="October" Value="10"></asp:ListItem>
                            <asp:ListItem Text="November" Value="11"></asp:ListItem>
                            <asp:ListItem Text="December" Value="12"></asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;&nbsp;<asp:DropDownList ID="ddlYear" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td valign="top">
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" ToolTip="Delete" CssClass="btnBgsmall"
                            OnClick="btnDelete_Click" />
                        <asp:Button ID="btnHide" Text="Cancel" runat="server" CssClass="servbtnBg" border="0"
                            OnClientClick="return HideDiv();" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFooter" runat="server">
    <script language="javascript" type="text/javascript">

        function singleDelete(chkId) {
            document.getElementById(chkId).checked = true;
            if (delconfirm()) {
                return true;
            }
            else {
                document.getElementById(chkId).checked = false;
                return false;

            }
        }

        function showDeleteAllButton() {

            var countChecked = 0;
            var inputs = document.getElementsByTagName("input");

            for (i in inputs) {
                if (inputs[i].id != null && inputs[i].id.startsWith("chkDelete")) {
                    if (inputs[i].checked) {
                        countChecked++;
                    }
                }
            }

            document.getElementById("buttonDeleteSelectedAppt").disabled = (countChecked == 0);
        }

        function delconfirm(flag) {
            //alert(flag);
            if (flag != "13") {

                return confirm("Do You Want To Delete Selected Groomer(s) Appointment?");
            }

        }

        function valOther(event) {
            var kcode = event.keyCode;
            //alert(kcode);
            var other = document.getElementById("ctl00_ContentPlaceHolder1_GrdUsers_ctl02_txtOthers").value;
            if (kcode == 8 || kcode == 46 || kcode == 37 || kcode == 38 || kcode == 39 || kcode == 40) { return true; }
            else
                if (other.length > 500) { return false }
            return true;

        }

        function valDate(event) {
            var kcode = event.keyCode;
            //alert(kcode);
            var other = document.getElementById("ctl00_ContentPlaceHolder1_GrdUsers_ctl02_txtAppointmentDate").value;
            if (kcode == 8 || kcode == 46 || kcode == 37 || kcode == 38 || kcode == 39 || kcode == 40) { return true; }
            else
                if (other.length > 20) { return false }
            return true;

        }

        function valRev(event) {
            var kcode = event.keyCode;
            //alert(kcode);
            var Rev = document.getElementById("ctl00_ContentPlaceHolder1_GrdUsers_ctl02_txtExpectedTotalRevenue").value;
            if (kcode == 8 || kcode == 46 || kcode == 37 || kcode == 38 || kcode == 39 || kcode == 40) { return true; }
            else
                if (Rev.length > 8) { return false }
            return true;

        }

        function valPetTime(event) {
            var kcode = event.keyCode;
            //alert(kcode);
            var PetTime = document.getElementById("ctl00_ContentPlaceHolder1_GrdUsers_ctl02_txtExpectedPetTime").value;
            if (kcode == 8 || kcode == 46 || kcode == 37 || kcode == 38 || kcode == 13 || kcode == 39 || kcode == 40) { return true; }
            else
                if (PetTime.length > 4) { return false }
            return true;

        }
        function ShowDiv() {
            document.getElementById('<%=divShow.ClientID %>').style.display = "Block";
            return false;
        }
        function HideDiv() {
            document.getElementById('<%=divShow.ClientID %>').style.display = "none";
            return false;
        }
    </script>
</asp:Content>
