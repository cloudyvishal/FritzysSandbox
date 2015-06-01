<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Inner_Page_MB_MasterPage.Master" AutoEventWireup="true" CodeBehind="MB_Login.aspx.cs" Inherits="MobileWeb.MB_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div class="contentinnersection">
        <div class="innerpageheading">
            <h1>Login</h1>
        </div>
        <div class="innercontent">
            <div class="forform">
                <form action="#">
                    <asp:Label runat="server" ID="lblLoginerror" CssClass="lblerror" Style="color: Red;" Text="Please Check Username or Password" Visible="false" runat="server"></asp:Label><br />
                    <asp:Label runat="server" ID="username" CssClass="label">User Name</asp:Label><br />
                    <asp:TextBox CssClass="txtbox" ID="txtUserName" runat="server"></asp:TextBox><br />

                    <asp:Label runat="server" ID="passwordlbl" CssClass="label">Password</asp:Label><br />
                    <asp:TextBox runat="server" ID="txtpassword" CssClass="txtbox" TextMode="password"></asp:TextBox><br />
                    <asp:Button runat="server" CssClass="button" OnClientClick="return validate();" ID="btnLogin" Text="Login" OnClick="btnLogin_Click" CausesValidation="False" />
                </form>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBodyEnd" runat="server">
    <script lang="javascript" type="text/javascript" defer="defer">
        function validate() {

            if (document.getElementById('<%=txtUserName.ClientID %>').value == "") {

                alert("Please Enter User Name.");
                document.getElementById('<%=txtUserName.ClientID %>').focus();
            return false;
        }
        if (document.getElementById('<%=txtpassword.ClientID %>').value == "") {

                alert("Please Enter Password.");
                document.getElementById('<%=txtpassword.ClientID %>').focus();
            return false;
        }
    }
    </script>
</asp:Content>
