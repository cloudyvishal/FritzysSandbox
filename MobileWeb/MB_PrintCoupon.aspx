<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MB_PrintCoupon.aspx.cs" Inherits="MobileWeb.MB_PrintCoupon" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="cache-control" content="no-cache;" />
    <title>Print Coupon</title>
    <script type="text/javascript" lang="javascript" defer="defer">
        function PrintCard() {
            document.getElementById('<%=divButton.ClientID %>').style.display = "none";
          window.print();
          window.close();
          return false;
      }
    </script>
    <link href="css/style.css" type="text/css" rel="Stylesheet" />
</head>
<body>
    <div style="width: 320px; margin: 4px auto 0 auto;">
        <form id="form1" runat="server">
            <div class="container">

                <asp:DataList ID="dlCoupon" runat="server" RepeatColumns="1" DataKeyField="BannerId" Width="100%" CellPadding="0"
                    CellSpacing="0" OnItemCommand="dlCoupon_ItemCommand">
                    <ItemTemplate>
                        <div>
                            <div id="dvcoupon" runat="server" style="width: 320px; height: 150px; background: #decfba; margin: 30px auto; text-align: center;">
                                <img alt="Image" src='<%#DataBinder.Eval(Container.DataItem,"BannerPath") %>' runat="server" id="imgThumb" height="142" width="320" />
                                <asp:Label ID="lblBannerId" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"BannerId") %>' Visible="false"></asp:Label>
                                <br />

                                <div class="bottomlink">
                                    <ul>
                                        <li>
                                            <asp:Button ID="btnPrint" runat="server" CssClass="button" CommandName="Print"
                                                CommandArgument='<%# DataBinder.Eval(Container.DataItem,"BannerId") %>' Text="Print"
                                                ToolTip="Print" /></li>
                                        <li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="javascript:history.go(-1)" title="Back">Back</a></li>
                                    </ul>
                                </div>


                            </div>

                        </div>

                    </ItemTemplate>
                </asp:DataList>

                <div id="dvDefaultCoupon" runat="server" style="width: 320px; height: 150px; background: #decfba; margin: 30px auto; text-align: center; padding: 20px;">
                    <asp:Image ID="ImgGift" runat="server" border="0" alt="Print Coupon" />
                    <br />
                    <div id="divButton" runat="server" style="display: block;">
                        <asp:Button ID="btnPrint" runat="server" Text="Print" ToolTip="Print" CssClass="printbtnBg" OnClientClick="return PrintCard();" />
                    </div>
                </div>

                <div id="dvNocoupon" runat="server" style="width: 320px; height: 150px; background: #decfba; margin: 30px auto; text-align: center; padding: 20px;">
                    <div class="errorDiv" id="divError" runat="server" visible="false">
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
                </div>

            </div>
        </form>
    </div>
</body>
</html>
