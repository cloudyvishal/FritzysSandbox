﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Inner_Page_MB_MasterPage.Master" AutoEventWireup="true" CodeBehind="MB_Registration.aspx.cs" Inherits="MobileWeb.MB_Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div class="contentinnersection">
        <div class="innerpageheading">
            <h1>Registration</h1>
        </div>
        <div class="innercontent">
            <div class="reg-top-txt">
                Join Fritzy's Club today, and enjoy member discounts, online appointment requests
                and more. Please complete the information below so you can login as a member the
                next time you visit our site.
            </div>
            <asp:Label ID="lblCaptchaError" runat="server" Visible="false" ForeColor="red"></asp:Label>
            <h2>
                <span class="heading">Your Information</span></h2>
            <div class="forform">
                <form action="#">
                    <asp:Label runat="server" ID="firstname" CssClass="label">First Name<span class="mand">*</span></asp:Label><br />
                    <asp:TextBox CssClass="txtbox" ID="txtFirstName" MaxLength="30" runat="server"></asp:TextBox><br />
                    <asp:Label runat="server" ID="lastname" CssClass="label">Last Name<span class="mand">*</span></asp:Label><br />
                    <asp:TextBox runat="server" ID="txtLastName" MaxLength="30" CssClass="txtbox"></asp:TextBox><br />
                    <asp:Label runat="server" ID="streetaddresslabel" CssClass="label">Street Address<span class="mand">*</span></asp:Label><br />
                    <asp:TextBox runat="server" ID="txtStreet" MaxLength="60" CssClass="txtbox"></asp:TextBox><br />
                    <asp:Label runat="server" ID="citylable" CssClass="label">City<span class="mand">*</span></asp:Label><br />
                    <asp:TextBox runat="server" ID="txtCity" MaxLength="30" CssClass="txtbox"></asp:TextBox><br />
                    <div class="divforstate-zip">
                        <div class="divstate">
                            <asp:Label ID="statelabel" CssClass="shortlabel" runat="server">State<span class="mand">*</span></asp:Label><br />
                            <asp:DropDownList ID="ddlState" CssClass="shortselectbox" runat="server">
                            </asp:DropDownList>
                        </div>
                        <div class="divstate">
                            <asp:Label runat="server" CssClass="shortlabel" ID="ziplabel">Zip<span class="mand">*</span></asp:Label><br />
                            <asp:TextBox runat="server" CssClass="shorttxtbox" MaxLength="5" ID="txtZip"></asp:TextBox>
                        </div>
                    </div>
                    <asp:Label runat="server" CssClass="label" ID="phonelabel">Phone<span class="mand">*</span></asp:Label><br />
                    <asp:TextBox runat="server" CssClass="txtbox" MaxLength="16" ID="txtPhone" onkeydown="javascript:backspacerDOWN(this,event);"
                        onkeyup="javascript:backspacerUP(this,event);"></asp:TextBox><br />
                    <asp:Label runat="server" CssClass="label" ID="referrellabel">Referral Source<span class="mand">*</span></asp:Label><br />
                    <asp:DropDownList runat="server" CssClass="selectbox" ID="ddlReferralSource">
                    </asp:DropDownList>
                    <br />
                    <h2>
                        <span class="heading">Your Pet Information</span></h2>
                    <asp:UpdatePanel ID="up12" runat="server">
                        <ContentTemplate>
                            <%--    For Pet 1--%>
                            <div class="divfirstpetinfo" id="dvPet1" runat="server">
                                <div class="petlabeldiv">
                                    <asp:Label ID="petlabel" CssClass="shortlabel" runat="server">Pet</asp:Label><br />
                                    <asp:DropDownList ID="ddlPetType1" CssClass="shortselectbox" runat="server" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlPetType1_OnSelectedIndexChanged">
                                        <asp:ListItem Text="Cat" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Dog" Value="1"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="breedlabel" CssClass="shortlabel" runat="server">Breed</asp:Label><br />
                                    <asp:DropDownList ID="ddlBreed1" CssClass="shortselectbox" runat="server">
                                    </asp:DropDownList>
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="petnamelabel" CssClass="shortlabel" runat="server">Pet&nbsp;Name</asp:Label><br />
                                    <asp:TextBox ID="txtPetName1" CssClass="shorttxtbox" MaxLength="20" runat="server"></asp:TextBox>
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="birthlabel" runat="server" CssClass="shortlabel">Birth Year</asp:Label>
                                    <asp:TextBox ID="txtPetDOB1" runat="server" MaxLength="4" CssClass="shorttxtbox"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator13" ControlToValidate="txtPetDOB1"
                                        Text="(Invalid Birth Year)" runat="server" ValidationGroup="RegValidation" ValidationExpression="^[0-9]+$"
                                        Display="Dynamic" />
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="weightlabel" runat="server" CssClass="shortlabel">Weight</asp:Label><br />
                                    <asp:TextBox ID="txtPetWeight1" runat="server" MaxLength="6" CssClass="smalltxtbox"></asp:TextBox>&nbsp;&nbsp;lbs
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" ControlToValidate="txtPetWeight1"
                                    Text="(Invalid Weight)" runat="server" ValidationGroup="RegValidation" ValidationExpression="^[0-9]+$" />
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="furlenghtlabel" runat="server" CssClass="shortlabel">Fur Length</asp:Label><br />
                                    <asp:TextBox ID="txtPetLength1" runat="server" MaxLength="6" CssClass="smalltxtbox"></asp:TextBox>&nbsp;&nbsp;inches
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" ControlToValidate="txtPetLength1"
                                    Text="(Invalid Fur Length)" runat="server" ValidationGroup="RegValidation" ValidationExpression="^[0-9]+$" />
                                </div>
                            </div>
                            <%--    For Pet 2--%>
                            <div class="divfirstpetinfo" id="dvPet2" runat="server">
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label1" CssClass="shortlabel" runat="server">Pet</asp:Label><br />
                                    <asp:DropDownList ID="ddlPetType2" CssClass="shortselectbox" runat="server" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlPetType2_OnSelectedIndexChanged">
                                        <asp:ListItem Text="Cat" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Dog" Value="1"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label3" CssClass="shortlabel" runat="server">Breed</asp:Label><br />
                                    <asp:DropDownList ID="ddlBreed2" CssClass="shortselectbox" runat="server">
                                    </asp:DropDownList>
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label2" CssClass="shortlabel" runat="server">Pet&nbsp;Name</asp:Label><br />
                                    <asp:TextBox ID="txtPetName2" CssClass="shorttxtbox" MaxLength="30" runat="server"></asp:TextBox>
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label4" runat="server" CssClass="shortlabel">Birth Year</asp:Label>
                                    <asp:TextBox ID="txtDOB2" runat="server" MaxLength="4" CssClass="shorttxtbox"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator14" ControlToValidate="txtDOB2"
                                        Text="(Invalid Birth Year)" runat="server" ValidationGroup="RegValidation" ValidationExpression="^[0-9]+$" />
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label5" runat="server" CssClass="shortlabel">Weight</asp:Label><br />
                                    <asp:TextBox ID="txtPetWeight2" runat="server" MaxLength="6" CssClass="smalltxtbox"></asp:TextBox>&nbsp;&nbsp;lbs
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ControlToValidate="txtPetWeight2"
                                    Text="(Invalid Weight)" runat="server" ValidationGroup="RegValidation" ValidationExpression="^[0-9]+$" />
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label6" runat="server" CssClass="shortlabel">Fur Length</asp:Label><br />
                                    <asp:TextBox ID="txtPetLength2" runat="server" MaxLength="6" CssClass="smalltxtbox"></asp:TextBox>&nbsp;&nbsp;inches
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" ControlToValidate="txtPetLength2"
                                    Text="(Invalid Fur Length)" runat="server" ValidationGroup="RegValidation" ValidationExpression="^[0-9]+$" />
                                </div>
                            </div>
                            <%--    For Pet 3--%>
                            <div class="divfirstpetinfo" id="dvPet3" runat="server">
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label7" CssClass="shortlabel" runat="server">Pet</asp:Label><br />
                                    <asp:DropDownList ID="ddlPetType3" CssClass="shortselectbox" runat="server" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlPetType3_OnSelectedIndexChanged">
                                        <asp:ListItem Text="Cat" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Dog" Value="1"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label9" CssClass="shortlabel" runat="server">Breed</asp:Label><br />
                                    <asp:DropDownList ID="ddlBreed3" CssClass="shortselectbox" runat="server">
                                    </asp:DropDownList>
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label8" CssClass="shortlabel" runat="server">Pet&nbsp;Name</asp:Label><br />
                                    <asp:TextBox ID="txtPetName3" CssClass="shorttxtbox" MaxLength="30" runat="server"></asp:TextBox>
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label10" runat="server" CssClass="shortlabel">Birth Year</asp:Label>
                                    <asp:TextBox ID="txtDOB3" runat="server" MaxLength="4" CssClass="shorttxtbox"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator15" ControlToValidate="txtDOB3"
                                        Text="(Invalid Birth Year)" runat="server" ValidationGroup="RegValidation" ValidationExpression="^[0-9]+$" />
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label11" runat="server" CssClass="shortlabel">Weight</asp:Label><br />
                                    <asp:TextBox ID="txtPetWeight3" runat="server" MaxLength="6" CssClass="smalltxtbox"></asp:TextBox>&nbsp;&nbsp;lbs
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="txtPetWeight3"
                                    Text="(Invalid Weight)" runat="server" ValidationGroup="RegValidation" ValidationExpression="^[0-9]+$" />
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label12" runat="server" CssClass="shortlabel">Fur Length</asp:Label><br />
                                    <asp:TextBox ID="txtPetLength3" runat="server" MaxLength="6" CssClass="smalltxtbox"></asp:TextBox>&nbsp;&nbsp;inches
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator9" ControlToValidate="txtPetLength3"
                                    Text="(Invalid Fur Length)" runat="server" ValidationGroup="RegValidation" ValidationExpression="^[0-9]+$" />
                                </div>
                            </div>
                            <%--    For Pet 4--%>
                            <div class="divfirstpetinfo" id="dvPet4" runat="server">
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label13" CssClass="shortlabel" runat="server">Pet</asp:Label><br />
                                    <asp:DropDownList ID="ddlPetType4" CssClass="shortselectbox" runat="server" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlPetType4_OnSelectedIndexChanged">
                                        <asp:ListItem Text="Cat" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Dog" Value="1"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label15" CssClass="shortlabel" runat="server">Breed</asp:Label><br />
                                    <asp:DropDownList ID="ddlBreed4" CssClass="shortselectbox" runat="server">
                                    </asp:DropDownList>
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label14" CssClass="shortlabel" runat="server">Pet&nbsp;Name</asp:Label><br />
                                    <asp:TextBox ID="txtPetName4" CssClass="shorttxtbox" MaxLength="30" runat="server"></asp:TextBox>
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label16" runat="server" CssClass="shortlabel">Birth Year</asp:Label>
                                    <asp:TextBox ID="txtDOB4" runat="server" MaxLength="4" CssClass="shorttxtbox"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator16" ControlToValidate="txtDOB4"
                                        Text="(Invalid Birth Year)" runat="server" ValidationGroup="RegValidation" ValidationExpression="^[0-9]+$" />
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label17" runat="server" CssClass="shortlabel">Weight</asp:Label><br />
                                    <asp:TextBox ID="txtPetWeight4" runat="server" MaxLength="6" CssClass="smalltxtbox"></asp:TextBox>&nbsp;&nbsp;lbs
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txtPetWeight4"
                                    Text="(Invalid Weight)" runat="server" ValidationGroup="RegValidation" ValidationExpression="^[0-9]+$" />
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label18" runat="server" CssClass="shortlabel">Fur Length</asp:Label><br />
                                    <asp:TextBox ID="txtPetLength4" runat="server" MaxLength="6" CssClass="smalltxtbox"></asp:TextBox>&nbsp;&nbsp;inches
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator10" ControlToValidate="txtPetLength4"
                                    Text="(Invalid Fur Length)" runat="server" ValidationGroup="RegValidation" ValidationExpression="^[0-9]+$" />
                                </div>
                            </div>
                            <%--    For Pet 5--%>
                            <div class="divfirstpetinfo" id="dvPet5" runat="server">
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label19" CssClass="shortlabel" runat="server">Pet</asp:Label><br />
                                    <asp:DropDownList ID="ddlPetType5" CssClass="shortselectbox" runat="server" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlPetType5_OnSelectedIndexChanged">
                                        <asp:ListItem Text="Cat" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Dog" Value="1"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label21" CssClass="shortlabel" runat="server">Breed</asp:Label><br />
                                    <asp:DropDownList ID="ddlBreed5" CssClass="shortselectbox" runat="server">
                                    </asp:DropDownList>
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label20" CssClass="shortlabel" runat="server">Pet&nbsp;Name</asp:Label><br />
                                    <asp:TextBox ID="txtPetName5" CssClass="shorttxtbox" MaxLength="30" runat="server"></asp:TextBox>
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label22" runat="server" CssClass="shortlabel">Birth Year</asp:Label>
                                    <asp:TextBox ID="txtDOB5" runat="server" MaxLength="4" CssClass="shorttxtbox"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator17" ControlToValidate="txtDOB5"
                                        Text="(Invalid Birth Year)" runat="server" ValidationGroup="RegValidation" ValidationExpression="^[0-9]+$" />
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label23" runat="server" CssClass="shortlabel">Weight</asp:Label><br />
                                    <asp:TextBox ID="txtPetWeight5" MaxLength="6" runat="server" CssClass="smalltxtbox"></asp:TextBox>&nbsp;&nbsp;lbs
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtPetWeight5"
                                    Text="(Invalid Weight)" runat="server" ValidationGroup="RegValidation" ValidationExpression="^[0-9]+$" />
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label24" runat="server" CssClass="shortlabel">Fur Length</asp:Label><br />
                                    <asp:TextBox ID="txtPetLength5" MaxLength="6" runat="server" CssClass="smalltxtbox"></asp:TextBox>&nbsp;&nbsp;inches
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator11" ControlToValidate="txtPetLength5"
                                    Text="(Invalid Fur Length)" runat="server" ValidationGroup="RegValidation" ValidationExpression="^[0-9]+$" />
                                </div>
                            </div>
                            <%--    For Pet 6--%>
                            <div class="divfirstpetinfo" id="dvPet6" runat="server">
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label25" CssClass="shortlabel" runat="server">Pet</asp:Label><br />
                                    <asp:DropDownList ID="ddlPetType6" CssClass="shortselectbox" runat="server" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlPetType5_OnSelectedIndexChanged">
                                        <asp:ListItem Text="Cat" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Dog" Value="1"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label26" CssClass="shortlabel" runat="server">Pet&nbsp;Name</asp:Label><br />
                                    <asp:TextBox ID="txtPetName6" CssClass="shorttxtbox" MaxLength="30" runat="server"></asp:TextBox>
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label27" CssClass="shortlabel" runat="server">Breed</asp:Label><br />
                                    <asp:DropDownList ID="ddlBreed6" CssClass="shortselectbox" runat="server">
                                    </asp:DropDownList>
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label28" runat="server" CssClass="shortlabel">Birth Year</asp:Label><br />
                                    <asp:TextBox ID="txtDOB6" runat="server" MaxLength="4" CssClass="shorttxtbox"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator18" ControlToValidate="txtDOB6"
                                        Text="(Invalid Birth Year)" runat="server" ValidationGroup="RegValidation" ValidationExpression="^[0-9]+$" />
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label29" runat="server" CssClass="shortlabel">Weight</asp:Label><br />
                                    <asp:TextBox ID="txtPetWeight6" runat="server" MaxLength="6" CssClass="smalltxtbox"></asp:TextBox>&nbsp;&nbsp;lbs
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtPetWeight6"
                                    Text="(Invalid Weight)" runat="server" ValidationGroup="RegValidation" ValidationExpression="^[0-9]+$" />
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label30" runat="server" CssClass="shortlabel">Fur Length</asp:Label><br />
                                    <asp:TextBox ID="txtPetLength6" runat="server" MaxLength="6" CssClass="smalltxtbox"></asp:TextBox>&nbsp;&nbsp;inches
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator12" ControlToValidate="txtPetLength6"
                                    Text="(Invalid Fur Length)" runat="server" ValidationGroup="RegValidation" ValidationExpression="^[0-9]+$" />
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:Label ID="lblMessageSix" runat="server" Visible="false"></asp:Label>
                    <asp:Button ID="imgAddmore" CssClass="button" runat="server" Text="Add More Pets"
                        CausesValidation="true" OnClick="imgAddmore_Click" /><br />
                    <br />
                    <h2>
                        <span class="heading">Create Username &amp; Password</span></h2>
                    <asp:Label runat="server" ID="username" CssClass="label">Email<span class="mand">*</span></asp:Label><br />
                    <asp:TextBox CssClass="txtbox" ID="txtEmailReg" MaxLength="30" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="regEmail" ControlToValidate="txtEmailReg" Text="(Invalid email)"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" runat="server"
                        ValidationGroup="RegValidation" />
                    <br />
                    <asp:Label runat="server" ID="passwordlabel" CssClass="label">Password<span class="mand">*</span></asp:Label><br />
                    <asp:TextBox runat="server" ID="txtPasswordReg" MaxLength="30" CssClass="txtbox"
                        TextMode="Password"></asp:TextBox><br />
                    <asp:Label runat="server" ID="cnfpassword" CssClass="label">Confirm Password<span class="mand">*</span></asp:Label><br />
                    <asp:TextBox runat="server" ID="txtcnfpassword" MaxLength="30" CssClass="txtbox"
                        TextMode="Password"></asp:TextBox><br />
                    <asp:Button runat="server" ID="IdSubmit" CssClass="button" Text="Submit" OnClientClick="return validate();"
                        OnClick="IdSubmit_Click" />&nbsp;&nbsp;
                <asp:Button runat="server" ID="Reset" CssClass="button" Text="Reset" Visible="false"
                    ValidationGroup="RegValidation" />
                </form>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBodyEnd" runat="server">
    <script type="text/javascript" src="../Scripts/phone_validation.js" defer="defer"></script>

    <script type="text/javascript" src="../Scripts/Validation.js" defer="defer"></script>

    <script language="javascript" type="text/javascript" defer="defer">
        function validate() {

            if (document.getElementById('<%=txtFirstName.ClientID %>').value == "") {

                alert("Please Enter First Name.");
                document.getElementById('<%=txtFirstName.ClientID %>').focus();
                return false;
            }
            if (document.getElementById('<%=txtLastName.ClientID %>').value == "") {

                alert("Please Enter Last Name.");
                document.getElementById('<%=txtLastName.ClientID %>').focus();
                return false;
            }

            if (document.getElementById('<%=txtStreet.ClientID %>').value == "") {

                alert("Please Enter Address.");
                document.getElementById('<%=txtStreet.ClientID %>').focus();
                return false;
            }

            if (document.getElementById('<%=txtCity.ClientID %>').value == "") {

                alert("Please Enter City.");
                document.getElementById('<%=txtCity.ClientID %>').focus();
                return false;
            }

            var StateValue = document.getElementById('<%= ddlState.ClientID %>').options[document.getElementById('<%= ddlState.ClientID %>').selectedIndex].value;

            if (StateValue == "0") {
                alert("Please Select State.");
                document.getElementById('<%=ddlState.ClientID %>').focus();
                return false;
            }
            if (document.getElementById('<%=txtZip.ClientID %>').value == "") {

                alert("Please Enter Zip Code.");
                document.getElementById('<%=txtZip.ClientID %>').focus();
                return false;
            }

            if (IsNumeric(document.getElementById('<%=txtZip.ClientID %>').value) == false) {
                alert("Not a valid Zip Code.");
                document.getElementById('<%=txtZip.ClientID %>').focus();
                return false;
            }
            if ((document.getElementById('<%=txtPhone.ClientID %>').value) == false) {
                alert("Not a valid Phone No.");
                document.getElementById('<%=txtPhone.ClientID %>').focus();
                return false;
            }

            var ReferralSource = document.getElementById('<%= ddlReferralSource.ClientID %>').options[document.getElementById('<%= ddlReferralSource.ClientID %>').selectedIndex].value;
            if (ReferralSource == "0") {
                alert("Please Select Referral Source.");
                document.getElementById('<%=ddlReferralSource.ClientID %>').focus();
                return false;
            }

            if (document.getElementById('<%=txtEmailReg.ClientID %>').value == "") {

                alert("Please Enter Email.");
                document.getElementById('<%=txtEmailReg.ClientID %>').focus();
                return false;
            }
            if (document.getElementById('<%=txtPasswordReg.ClientID %>').value == "") {

                alert("Please Enter Password.");
                document.getElementById('<%=txtPasswordReg.ClientID %>').focus();
                return false;
            }
            var pass = document.getElementById('<%=txtPasswordReg.ClientID %>').value;
            var Confpass = document.getElementById('<%=txtcnfpassword.ClientID %>').value;
            if (pass != Confpass) {
                alert("Confirm Password Not Match With Password.");
                document.getElementById('<%=txtcnfpassword.ClientID %>').focus();
                return false;

            }

        }

        function IsNumeric(sText) {
            var ValidChars = "0123456789";
            var IsNumber = true;
            var Char;


            for (i = 0; i < sText.length && IsNumber == true; i++) {
                Char = sText.charAt(i);
                if (ValidChars.indexOf(Char) == -1) {
                    IsNumber = false;
                }
            }
            return IsNumber;

        }
    </script>
</asp:Content>
