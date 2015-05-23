<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GiftCard.aspx.cs" Inherits="FritzysPetCareProsSandbox.GiftCard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Fritzy's pet care pros - Gift Card</title>


    <script type="text/javascript" language="javascript">
        function selfClose() {
            self.close();
            return false;
        }

    </script>
    <style type="text/css">
        .btnBg {
            border: 1px solid #bc9964;
            background: url(images/btnBg.jpg) repeat-x;
            font-family: "Times New Roman";
            font-size: 13px;
            font-weight: bold;
            padding: 0;
        }
    </style>
</head>
<body style="background: #decfba; color: #604422; font-family: Verdana; font-size: 11px;">
    <form id="form2" runat="server">
        <div id="divGift" runat="server" style="padding-right: 20px; padding-left: 20px; background: #f3ece4; padding-bottom: 20px; line-height: 25px; padding-top: 20px">

            <asp:Literal ID="litContent" runat="server"></asp:Literal>

        </div>
        <br />
        <br />
        <center>
    <asp:Button ID="btnClose" CssClass="btnBg" runat="server" Text="Close" OnClientClick="return selfClose()"  /></center>
    </form>
</body>
</html>
