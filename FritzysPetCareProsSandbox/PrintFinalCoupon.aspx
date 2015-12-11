<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintFinalCoupon.aspx.cs" Inherits="FritzysPetCareProsSandbox.PrintFinalCoupon" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Print Final Coupon</title>
    <script lang="javascript" type="text/javascript">
        function PrintIt() {
            window.print();
            window.close();
            return false;
        }
    </script>


    <link href="Styles.css" type="text/css" rel="Stylesheet" />
</head>
<body onload="PrintIt();">
    <form id="form1" runat="server">
        <div>
            <div style="width: 700px; height: 300px; background: #decfba; margin: 30px auto; text-align: center; padding: 20px;">
                <asp:Image ID="ImgGift" runat="server" border="0" alt="Print Coupon" />
                <br />

            </div>
        </div>
    </form>
</body>
</html>
