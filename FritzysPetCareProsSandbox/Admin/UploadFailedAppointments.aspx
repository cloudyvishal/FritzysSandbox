<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="UploadFailedAppointments.aspx.cs" Inherits="FritzysPetCareProsSandbox.Admin.UploadFailedAppointments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <style type="text/css">
        .normalRow {
            background-color: #FCFCFC;
        }

        .alternateRow {
            background-color: #ECECEC;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div class="innerContent">
        <div class="pageTitle">
            <h2>View Upload Failed Appointments</h2>
        </div>
        <div class="ViewAptGrid" id="DvAptGrid" runat="server">
            <div class="PopupHeader" id="PopupHeader"></div>
            <div class="PopupBody">
                <table class="adduserTable" cellpadding="6" cellspacing="0"  width="100%">
                    <thead>
                        <tr>
                            <td>Appointment Date</td>
                            <td>Appointment Time</td>
                            <td>Duration</td>
                            <td>Customer Name</td>
                            <td>Customer Email</td>
                            <td>Appointment String</td>
                            <td>Schedule By</td>
                            <td>Schedule For</td>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptFailedAppt" runat="server" OnItemDataBound="rptFailedAppt_ItemDataBound">
                            <ItemTemplate>
                                <tr>
                                    <td class="normalRow"><%#Eval("AppointmentDate") %></td>
                                    <td class="alternateRow"><%# Eval("AppointmentTime") %></td>
                                    <td class="normalRow"><%#Eval("Duration") %></td>
                                    <td class="alternateRow"><%#Eval("CustomerName") %></td>
                                    <td class="normalRow"><%#Eval("CustomerEmail") %></td>
                                    <td class="alternateRow"><%#Eval("AppointmentString") %></td>
                                    <td class="normalRow"><%#Eval("ScheduleBy") %></td>
                                    <td class="alternateRow"><%#Eval("ScheduleFor") %></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>

            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFooter" runat="server">
</asp:Content>
