<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ZipCode.ascx.cs" Inherits="FritzysPetCarePros.Controls.ZipCode" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<script type="text/javascript" lang="javascript">
    function Hide() {
        document.getElementById('<%=PanelFiveImg.ClientID %>').style.display = "none";

    return false;
}
function set1() {

    document.getElementById('<%=PanelFiveImg.ClientID %>').style.display = "block";

}
function HideLocation() {
    document.getElementById('<%=PanelFiveImg.ClientID %>').style.display = "none";
}
</script>
<style type="text/css">
 </style>

<asp:UpdatePanel ID="pop" runat="server">
    <ContentTemplate>
        <asp:Label ID="lblWelcome" runat="server" Text=""></asp:Label>
        <div class="locationServiced">

            <div class="zipcode">
                <asp:TextBox ID="txtZip" runat="server" class="textfield1" Width="60px" Height="15px"
                    MaxLength="6"></asp:TextBox>
                <cc1:TextBoxWatermarkExtender ID="TBWE2" runat="server" TargetControlID="txtZip"
                    WatermarkText="Zip code" WatermarkCssClass="watermarked" />
            </div>
            <div style="z-index: 10; position: absolute;">
                <asp:ImageButton ID="imgZipcode" runat="server" ImageUrl="http://naturesfreshpet.com/Images/btn_go.gif" AlternateText="Go"
                    OnClick="ImageButton2_Click" OnClientClick="return set1();" />
            </div>
        </div>
        <div id="PanelFiveImg" style="display: none;" runat="server">
            <div id="divInner" runat="server">
            </div>
            <div id="jquery-overlay"></div>
            <div id="jquery-lightbox">
                <div id="lightbox-container-image-box">
                    <div id="lightbox-container-image">
                        <table width="100%" border="0">
                            <tbody>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblResult" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnOk" runat="server" Text="Ok" ToolTip="Ok" CssClass="btnBg" OnClick="btnOk_Click" OnClientClick="return HideLocation();" />
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" ToolTip="Cancel" CssClass="btnBg" OnClientClick="return Hide();" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <img src="http://naturesfreshpet.com/Images/lightbox-ico-loading.gif" alt="">
                    </div>
                </div>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
