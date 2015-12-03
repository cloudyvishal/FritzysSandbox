<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FritzysPetCareProsSandbox.Admin.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin - Login</title>
    <meta http-equiv="X-UA-Compatible" content="IE=8" />

    <link href="http://naturesfreshpet.com/Style/Admin.css" type="text/css" rel="stylesheet" />
</head>
<body class="loginBg">
    <form id="form1" runat="server">
        <%--Region Error/Success message start--%>
        <div class="loginDiv">
            <div style="width: 95%;" id="divError" runat="server" visible="false">
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
            <div>
                <table style="cellspacing:0; cellpadding:3; width:100%; border:0" class="loginTable">
                    <tbody>
                        <tr>
                            <td>
                                <h3>Username</h3>
                            </td>

                            <td>
                                <asp:TextBox ID="txtUserId" runat="server" CssClass="loginText"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>
                                <h3>Password</h3>
                            </td>

                            <td>
                                <asp:TextBox ID="txtPass" runat="server" TextMode="Password" CssClass="loginText"> </asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>

                            <td>
                                <asp:Label ID="lblip1" runat="server" Text="Label" Visible="false"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <asp:CheckBox ID="chkRemember" runat="server" Text="Remember me on this computer." /></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <asp:Button ID="btnLogin" runat="server" Text="LOGIN" ToolTip="LOGIN" UseSubmitBehavior="true" CssClass="loginbtnBg" OnClick="btnLogin_Click"></asp:Button>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <asp:HyperLink ID="ForgotPassword" CssClass="forgotLink" runat="server" NavigateUrl="~/Admin/forgotPassword.aspx"> I forgot my username or password</asp:HyperLink>
                            </td>
                        </tr>

                    </tbody>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
