<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Appointment.ascx.cs" Inherits="FritzysPetCarePros.Controls.Appointment" %>
<%@ Register Src="~/Controls/Login.ascx" TagName="Log" TagPrefix="LG" %>

<div id="logAppointment" runat="server">
    <LG:Log ID="Ap" runat="server" />
</div>
<div id="NormalAppointment" runat="server" class="img">
    <asp:ImageButton ID="ImgAppointment" runat="server" ImageUrl="http://naturesfreshpet.com/Images/make_appointment_now.jpg" OnClick="ImgAppointment_Click" ToolTip="MAKE AN APPOINTMENT NOW" />
</div>
