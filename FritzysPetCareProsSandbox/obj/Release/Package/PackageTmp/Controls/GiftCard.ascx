<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GiftCard.ascx.cs" Inherits="FritzysPetCarePros.Controls.GiftCard" %>
<script type="text/javascript" lang="javascript" defer="defer">
    function GotoPrint()
    {
        window.open('GiftCard.aspx','windowname1', 'width=500, height=500, scrollbars=1'); 
        return false;
    }
</script>
<div class="img">
    <a href="Contactus.aspx" title="Fritzy's giftcard">
        <img src="http://naturesfreshpet.com/Images/giftcard.jpg" border="0" alt="Fritzy's GiftCard" OnClick="return GotoPrint();"/></a>
</div>