<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MB_PrintFinalCoupon.aspx.cs" Inherits="MobileWeb.MB_PrintFinalCoupon" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="initial-scale=1.0,maximum-scale=1.0,minimum-scale=1.0,user-scalable=no, width=320;" />
    <meta name="cache-control" content="no-cache;" />
    <title>Print Coupon</title>

    <script lang="javascript" type="text/javascript" defer="defer">
        function PrintIt() {
            window.print();
            window.close();
            return false;
        }
    </script>

    <link href="Style/Style.css" type="text/css" rel="Stylesheet" />
</head>
<body onload="PrintIt();">
    <div style="width: 320px; margin: 4px auto 0 auto;">
        <form id="form1" runat="server">
            <div class="container">
                <div style="width: 320px; height: 150px; background: #decfba; margin: 30px auto; text-align: center;">
                    <asp:Image ID="ImgGift" runat="server" border="0" alt="Print Coupon" Height="124"
                        Width="320" />
                    <br />
                    <a href="javascript:history.go(-1)" title="Back">
                        <img src="Images/back_button.jpg" alt="Back" /></a><br />
                    <asp:Label ID="Label1" runat="server" Text="Print the coupon for earning the offers from Fritzy"></asp:Label>
                </div>
            </div>
        </form>
    </div>
</body>
</html>
