<%@ Page language="c#" Codebehind="GetCreditCardInfo.aspx.cs" AutoEventWireup="false" Inherits="CyberSourceStore.GetCreditCardInfo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>GetCreditCardInfo</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<h1>Enter Credit Card Information</h1>
		<form id="GetCreditCardInfo" method="post" runat="server">
			<asp:label id="ErrorMessage" style="Z-INDEX: 138; LEFT: 37px; POSITION: absolute; TOP: 61px" runat="server" Width="656px" ForeColor="Red"></asp:label><asp:textbox id="CV" style="Z-INDEX: 109; LEFT: 218px; POSITION: absolute; TOP: 199px" runat="server" Width="36px"></asp:textbox><asp:textbox id="ExpYear" style="Z-INDEX: 108; LEFT: 218px; POSITION: absolute; TOP: 164px" runat="server" Width="35px"></asp:textbox><asp:textbox id="ExpMonth" style="Z-INDEX: 107; LEFT: 218px; POSITION: absolute; TOP: 129px" runat="server" Width="36px"></asp:textbox><asp:label id="Label5" style="Z-INDEX: 106; LEFT: 34px; POSITION: absolute; TOP: 201px" runat="server" Width="164px">Card Verification Number</asp:label><asp:label id="Label4" style="Z-INDEX: 105; LEFT: 34px; POSITION: absolute; TOP: 168px" runat="server" Width="132px">Expiration Year</asp:label><asp:label id="Label3" style="Z-INDEX: 104; LEFT: 35px; POSITION: absolute; TOP: 133px" runat="server" Width="132px">Expiration Month</asp:label><asp:label id="Label2" style="Z-INDEX: 102; LEFT: 35px; POSITION: absolute; TOP: 98px" runat="server" Width="132px">Credit Card Number</asp:label><asp:textbox id="CCNumber" style="Z-INDEX: 103; LEFT: 218px; POSITION: absolute; TOP: 96px" runat="server"></asp:textbox><asp:button id="Button1" style="Z-INDEX: 110; LEFT: 35px; POSITION: absolute; TOP: 241px" runat="server" Width="96px" Text="Submit"></asp:button></form>
	</body>
</HTML>
