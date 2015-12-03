<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Inner_Page_MB_MasterPage.Master" AutoEventWireup="true" CodeBehind="MB_Schedule_Appointment.aspx.cs" Inherits="MobileWeb.MB_Schedule_Appointment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div class="contentinnersection">
        <div class="innerpageheading">
            <h1>Schedule An Appointment</h1>
            <h2>
                <span class="heading">Who? &amp; What?</span></h2>
        </div>
        <asp:Label ID="lblSuccess" runat="server" Text=""></asp:Label>
        <asp:Label ID="lblErrorDate" runat="server" ForeColor="red"></asp:Label>
        <asp:UpdatePanel ID="up12" runat="server">
            <ContentTemplate>
                <div class="divfirstpetinfo" id="dvPet1" runat="server">
                    <div class="deletediv">
                        <asp:ImageButton ID="imgDelete1" runat="server" Height="20" Width="20" Visible="false"
                            ImageUrl="images/delete.png" ToolTip="Delete" OnClick="imgDelete6_Click" OnClientClick="return confirmation();" />
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="petlabel" CssClass="shortlabel" runat="server">Pet</asp:Label><br />
                        <asp:DropDownList ID="ddlPetType1" CssClass="shortselectbox" runat="server" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlPetType1_OnSelectedIndexChanged">
                            <asp:ListItem Text="Cat" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Dog" Value="1"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="PetID1" runat="server" Text="0" Visible="false"></asp:Label>
                        <asp:Label ID="petnamelabel" CssClass="shortlabel" runat="server">Pet&nbsp;Name</asp:Label><br />
                        <asp:TextBox ID="txtPetName1" CssClass="shorttxtbox" MaxLength="20" runat="server"></asp:TextBox>
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="breedlabel" CssClass="shortlabel" runat="server">Breed</asp:Label><br />
                        <asp:DropDownList ID="ddlBreed1" CssClass="shortselectbox" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="birthlabel" runat="server" CssClass="shortlabel">Birth Year</asp:Label><br />
                        <asp:TextBox ID="txtPetDOB1" runat="server" MaxLength="4" CssClass="shorttxtbox"></asp:TextBox>
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="weightlabel" runat="server" CssClass="shortlabel">Weight</asp:Label><br />
                        <asp:TextBox ID="txtPetWeight1" runat="server" MaxLength="6" CssClass="smalltxtbox"></asp:TextBox>&nbsp;&nbsp;lbs
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="furlenghtlabel" runat="server" CssClass="shortlabel">Fur Length</asp:Label><br />
                        <asp:TextBox ID="txtPetLength1" runat="server" MaxLength="6" CssClass="smalltxtbox"></asp:TextBox>&nbsp;&nbsp;inches
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="spatreatmentlabel" runat="server" CssClass="shortlabel">Spa Treatment</asp:Label><br />
                        <asp:CheckBox ID="chkSpa1" runat="server" />
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="stylelabel" runat="server" CssClass="shortlabel">Style</asp:Label><br />
                        <asp:DropDownList ID="ddlStyle1" CssClass="shortselectbox" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div style="width: 298px; float: left;">
                        <div class="petlabeldiv" style="width: 280px;">
                            <asp:Label ID="addservlabel" runat="server" CssClass="shortlabel">Additional Services</asp:Label><br />
                            <div>
                                <div style="display: none;">
                                    <asp:TextBox ID="txtAddServicesID1" runat="server"></asp:TextBox>
                                </div>
                                <asp:TextBox ID="txtAddServices1" runat="server" OnClick="return getSelectedCheckboxValue(1);"
                                    Text="Select Service" CssClass="regddlFldAdservice" Style="display: none;"></asp:TextBox>
                                <div class="petlabeldiv" style="width: 280px;">
                                    <asp:CheckBoxList ID="lstAddservices1" runat="Server" DataTextField="Name" DataValueField="ID"
                                        RepeatColumns="2" RepeatLayout="Table" AutoPostBack="True" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged">
                                    </asp:CheckBoxList>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="divfirstpetinfo" id="dvPet2" runat="server">
                    <div class="deletediv">
                        <asp:ImageButton ID="imgDelete2" runat="server" Height="20" Width="20" Visible="false"
                            ImageUrl="images/delete.png" ToolTip="Delete" OnClick="imgDelete6_Click" OnClientClick="return confirmation();" />
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="Label1" CssClass="shortlabel" runat="server">Pet</asp:Label><br />
                        <asp:DropDownList ID="ddlPetType2" CssClass="shortselectbox" runat="server" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlPetType2_OnSelectedIndexChanged">
                            <asp:ListItem Text="Cat" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Dog" Value="1"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="PetID2" runat="server" Text="0" Visible="false"></asp:Label>
                        <asp:Label ID="Label2" CssClass="shortlabel" runat="server">Pet&nbsp;Name</asp:Label><br />
                        <asp:TextBox ID="txtPetName2" CssClass="shorttxtbox" MaxLength="30" runat="server"></asp:TextBox>
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="Label3" CssClass="shortlabel" runat="server">Breed</asp:Label><br />
                        <asp:DropDownList ID="ddlBreed2" CssClass="shortselectbox" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="Label4" runat="server" CssClass="shortlabel">Birth Year</asp:Label><br />
                        <asp:TextBox ID="txtDOB2" runat="server" MaxLength="4" CssClass="shorttxtbox"></asp:TextBox>
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="Label5" runat="server" CssClass="shortlabel">Weight</asp:Label><br />
                        <asp:TextBox ID="txtPetWeight2" runat="server" MaxLength="6" CssClass="smalltxtbox"></asp:TextBox>&nbsp;&nbsp;lbs
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="Label6" runat="server" CssClass="shortlabel">Fur Length</asp:Label><br />
                        <asp:TextBox ID="txtPetLength2" runat="server" MaxLength="6" CssClass="smalltxtbox"></asp:TextBox>&nbsp;&nbsp;inches
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="spatrtlabel2" runat="server" CssClass="shortlabel">Spa Treatment</asp:Label><br />
                        <asp:CheckBox ID="chkSpa2" runat="server" />
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="stylelabel2" runat="server" CssClass="shortlabel">Style</asp:Label><br />
                        <asp:DropDownList ID="ddlStyle2" CssClass="shortselectbox" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div style="width: 298px; float: left;">
                        <div class="petlabeldiv" style="width: 280px;">
                            <asp:Label ID="addserlabel2" runat="server" CssClass="shortlabel">Additional Services</asp:Label><br />
                            <div>
                                <div style="display: none;">
                                    <asp:TextBox ID="txtAddServicesID2" runat="server"></asp:TextBox>
                                </div>
                                <asp:TextBox ID="txtAddServices2" runat="server" Text="Select Service" OnClick="return setList(2);"
                                    CssClass="regddlFldAdservice" Style="display: none;"></asp:TextBox>
                            </div>
                            <div class="petlabeldiv" style="width: 280px;">
                                <asp:CheckBoxList ID="lstAddservices2" runat="Server" DataTextField="Name" DataValueField="ID"
                                    RepeatColumns="2" RepeatLayout="Table" AutoPostBack="True" OnSelectedIndexChanged="CheckBoxList2_SelectedIndexChanged">
                                </asp:CheckBoxList>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="divfirstpetinfo" id="dvPet3" runat="server">
                    <div class="deletediv">
                        <asp:ImageButton ID="imgDelete3" runat="server" Height="20" Width="20" Visible="false"
                            ImageUrl="images/delete.png" ToolTip="Delete" OnClick="imgDelete6_Click" OnClientClick="return confirmation();" />
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="Label7" CssClass="shortlabel" runat="server">Pet</asp:Label><br />
                        <asp:DropDownList ID="ddlPetType3" CssClass="shortselectbox" runat="server" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlPetType3_OnSelectedIndexChanged">
                            <asp:ListItem Text="Cat" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Dog" Value="1"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="PetID3" runat="server" Text="0" Visible="false"></asp:Label>
                        <asp:Label ID="Label8" CssClass="shortlabel" runat="server">Pet&nbsp;Name</asp:Label><br />
                        <asp:TextBox ID="txtPetName3" CssClass="shorttxtbox" MaxLength="30" runat="server"></asp:TextBox>
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="Label9" CssClass="shortlabel" runat="server">Breed</asp:Label><br />
                        <asp:DropDownList ID="ddlBreed3" CssClass="shortselectbox" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="Label10" runat="server" CssClass="shortlabel">Birth Year</asp:Label><br />
                        <asp:TextBox ID="txtDOB3" runat="server" MaxLength="4" CssClass="shorttxtbox"></asp:TextBox>
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="Label11" runat="server" CssClass="shortlabel">Weight</asp:Label><br />
                        <asp:TextBox ID="txtPetWeight3" runat="server" MaxLength="6" CssClass="smalltxtbox"></asp:TextBox>&nbsp;&nbsp;lbs
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="Label12" runat="server" CssClass="shortlabel">Fur Length</asp:Label><br />
                        <asp:TextBox ID="txtPetLength3" runat="server" MaxLength="6" CssClass="smalltxtbox"></asp:TextBox>&nbsp;&nbsp;inches
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="spatrt3" runat="server" CssClass="shortlabel">Spa Treatment</asp:Label><br />
                        <asp:CheckBox ID="chkSpa3" runat="server" />
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="stylelbl3" runat="server" CssClass="shortlabel">Style</asp:Label><br />
                        <asp:DropDownList ID="ddlStyle3" CssClass="shortselectbox" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div style="width: 298px; float: left;">
                        <div class="petlabeldiv" style="width: 280px;">
                            <asp:Label ID="addservicelbl3" runat="server" CssClass="shortlabel">Additional Services</asp:Label><br />
                            <div>
                                <div style="display: none;">
                                    <asp:TextBox ID="txtAddServicesID3" runat="server"></asp:TextBox>
                                </div>
                                <asp:TextBox ID="txtAddServices3" runat="server" Text="Select Service" OnClick="return setList(3);"
                                    CssClass="regddlFldAdservice" Style="display: none;"></asp:TextBox>
                            </div>
                            <div class="petlabeldiv" style="width: 280px;">
                                <asp:CheckBoxList ID="lstAddservices3" runat="Server" DataTextField="Name" DataValueField="ID"
                                    RepeatColumns="2" RepeatLayout="Table" AutoPostBack="True" OnSelectedIndexChanged="CheckBoxList3_SelectedIndexChanged">
                                </asp:CheckBoxList>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="divfirstpetinfo" id="dvPet4" runat="server">
                    <div class="deletediv">
                        <asp:ImageButton ID="imgDelete4" runat="server" Height="20" Width="20" Visible="false"
                            ImageUrl="images/delete.png" ToolTip="Delete" OnClick="imgDelete6_Click" OnClientClick="return confirmation();" />
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="Label13" CssClass="shortlabel" runat="server">Pet</asp:Label><br />
                        <asp:DropDownList ID="ddlPetType4" CssClass="shortselectbox" runat="server" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlPetType4_OnSelectedIndexChanged">
                            <asp:ListItem Text="Cat" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Dog" Value="1"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="PetID4" runat="server" Text="0" Visible="false"></asp:Label>
                        <asp:Label ID="Label14" CssClass="shortlabel" runat="server">Pet&nbsp;Name</asp:Label><br />
                        <asp:TextBox ID="txtPetName4" CssClass="shorttxtbox" MaxLength="30" runat="server"></asp:TextBox>
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="Label15" CssClass="shortlabel" runat="server">Breed</asp:Label><br />
                        <asp:DropDownList ID="ddlBreed4" CssClass="shortselectbox" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="Label16" runat="server" CssClass="shortlabel">Birth Year</asp:Label><br />
                        <asp:TextBox ID="txtDOB4" runat="server" MaxLength="4" CssClass="shorttxtbox"></asp:TextBox>
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="Label17" runat="server" CssClass="shortlabel">Weight</asp:Label><br />
                        <asp:TextBox ID="txtPetWeight4" runat="server" MaxLength="6" CssClass="smalltxtbox"></asp:TextBox>&nbsp;&nbsp;lbs
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="Label18" runat="server" CssClass="shortlabel">Fur Length</asp:Label><br />
                        <asp:TextBox ID="txtPetLength4" runat="server" MaxLength="6" CssClass="smalltxtbox"></asp:TextBox>&nbsp;&nbsp;inches
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="spatrt4" runat="server" CssClass="shortlabel">Spa Treatment</asp:Label><br />
                        <asp:CheckBox ID="chkSpa4" runat="server" />
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="stylelbl4" runat="server" CssClass="shortlabel">Style</asp:Label><br />
                        <asp:DropDownList ID="ddlStyle4" CssClass="shortselectbox" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div style="width: 298px; float: left;">
                        <div class="petlabeldiv" style="width: 280px;">
                            <asp:Label ID="addservlbl4" runat="server" CssClass="shortlabel">Additional Services</asp:Label><br />
                            <div>
                                <div style="display: none;">
                                    <asp:TextBox ID="txtAddServicesID4" runat="server"></asp:TextBox>
                                </div>
                                <asp:TextBox ID="txtAddServices4" runat="server" Text="Select Service" OnClick="return setList(4);"
                                    CssClass="regddlFldAdservice" Style="display: none;"></asp:TextBox>
                            </div>
                            <div class="petlabeldiv" style="width: 280px;">
                                <asp:CheckBoxList ID="lstAddservices4" runat="Server" DataTextField="Name" DataValueField="ID"
                                    RepeatColumns="2" RepeatLayout="Table" AutoPostBack="True" OnSelectedIndexChanged="CheckBoxList4_SelectedIndexChanged">
                                </asp:CheckBoxList>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="divfirstpetinfo" id="dvPet5" runat="server">
                    <div class="deletediv">
                        <asp:ImageButton ID="imgDelete5" runat="server" Height="20" Width="20" Visible="false"
                            ImageUrl="images/delete.png" ToolTip="Delete" OnClick="imgDelete6_Click" OnClientClick="return confirmation();" />
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="Label19" CssClass="shortlabel" runat="server">Pet</asp:Label><br />
                        <asp:DropDownList ID="ddlPetType5" CssClass="shortselectbox" runat="server" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlPetType5_OnSelectedIndexChanged">
                            <asp:ListItem Text="Cat" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Dog" Value="1"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="PetID5" runat="server" Text="0" Visible="false"></asp:Label>
                        <asp:Label ID="Label20" CssClass="shortlabel" runat="server">Pet&nbsp;Name</asp:Label><br />
                        <asp:TextBox ID="txtPetName5" CssClass="shorttxtbox" MaxLength="30" runat="server"></asp:TextBox>
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="Label21" CssClass="shortlabel" runat="server">Breed</asp:Label><br />
                        <asp:DropDownList ID="ddlBreed5" CssClass="shortselectbox" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="Label22" runat="server" CssClass="shortlabel">Birth Year</asp:Label><br />
                        <asp:TextBox ID="txtDOB5" runat="server" MaxLength="4" CssClass="shorttxtbox"></asp:TextBox>
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="Label23" runat="server" CssClass="shortlabel">Weight</asp:Label><br />
                        <asp:TextBox ID="txtPetWeight5" MaxLength="6" runat="server" CssClass="smalltxtbox"></asp:TextBox>&nbsp;&nbsp;lbs
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="Label24" runat="server" CssClass="shortlabel">Fur Length</asp:Label><br />
                        <asp:TextBox ID="txtPetLength5" MaxLength="6" runat="server" CssClass="smalltxtbox"></asp:TextBox>&nbsp;&nbsp;inches
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="spatrt5" runat="server" CssClass="shortlabel">Spa Treatment</asp:Label><br />
                        <asp:CheckBox ID="chkSpa5" runat="server" />
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="stylelbl5" runat="server" CssClass="shortlabel">Style</asp:Label><br />
                        <asp:DropDownList ID="ddlStyle5" CssClass="shortselectbox" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div style="width: 298px; float: left;">
                        <div class="petlabeldiv" style="width: 280px;">
                            <asp:Label ID="addservlabel5" runat="server" CssClass="shortlabel">Additional Services</asp:Label><br />
                            <div>
                                <div style="display: none;">
                                    <asp:TextBox ID="txtAddServicesID5" runat="server"></asp:TextBox>
                                </div>
                                <asp:TextBox ID="txtAddServices5" runat="server" Text="Select Service" OnClick="return setList(5);"
                                    CssClass="regddlFldAdservice" Style="display: none;"></asp:TextBox>
                            </div>
                            <div class="petlabeldiv" style="width: 280px;">
                                <asp:CheckBoxList ID="lstAddservices5" runat="Server" DataTextField="Name" DataValueField="ID"
                                    RepeatColumns="2" RepeatLayout="Table" AutoPostBack="True" OnSelectedIndexChanged="CheckBoxList5_SelectedIndexChanged">
                                </asp:CheckBoxList>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="divfirstpetinfo" id="dvPet6" runat="server">
                    <div class="deletediv">
                        <asp:ImageButton ID="imgDelete6" runat="server" Height="20" Width="20" Visible="false"
                            ImageUrl="images/delete.png" ToolTip="Delete" OnClick="imgDelete6_Click" OnClientClick="return confirmation();" />
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="Label25" CssClass="shortlabel" runat="server">Pet</asp:Label><br />
                        <asp:DropDownList ID="ddlPetType6" CssClass="shortselectbox" runat="server" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlPetType6_OnSelectedIndexChanged">
                            <asp:ListItem Text="Cat" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Dog" Value="1"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="PetID6" runat="server" Text="0" Visible="false"></asp:Label>
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
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="Label29" runat="server" CssClass="shortlabel">Weight</asp:Label><br />
                        <asp:TextBox ID="txtPetWeight6" runat="server" MaxLength="6" CssClass="smalltxtbox"></asp:TextBox>&nbsp;&nbsp;lbs
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="Label30" runat="server" CssClass="shortlabel">Fur Length</asp:Label><br />
                        <asp:TextBox ID="txtPetLength6" runat="server" MaxLength="6" CssClass="smalltxtbox"></asp:TextBox>&nbsp;&nbsp;inches
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="spatrt6" runat="server" CssClass="shortlabel">Spa Treatment</asp:Label><br />
                        <asp:CheckBox ID="chkSpa6" runat="server" />
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="stylelbl6" runat="server" CssClass="shortlabel">Style</asp:Label><br />
                        <asp:DropDownList ID="ddlStyle6" CssClass="shortselectbox" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div style="width: 298px; float: left;">
                        <div class="petlabeldiv" style="width: 280px;">
                            <asp:Label ID="addservlbl6" runat="server" CssClass="shortlabel">Additional Services</asp:Label><br />
                            <div>
                                <div style="display: none;">
                                    <asp:TextBox ID="txtAddServicesID6" runat="server"></asp:TextBox>
                                </div>
                                <asp:TextBox ID="txtAddServices6" runat="server" Text="Select Service" OnClick="return setList(6);"
                                    CssClass="regddlFldAdservice" Style="display: none;"></asp:TextBox>
                            </div>
                            <div class="petlabeldiv" style="width: 280px;">
                                <asp:CheckBoxList ID="lstAddservices6" runat="Server" DataTextField="Name" DataValueField="ID"
                                    RepeatColumns="2" RepeatLayout="Table" AutoPostBack="True" OnSelectedIndexChanged="CheckBoxList6_SelectedIndexChanged">
                                </asp:CheckBoxList>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Label ID="lblMessageSix" runat="server" Visible="false"></asp:Label>
        <asp:Button ID="imgAddmore" CssClass="button" runat="server" Text="Add More Pets"
            CausesValidation="true" OnClick="imgAddmore_Click" />&nbsp;&nbsp;
        <asp:Button runat="server" ID="ImageButton1" CssClass="button" Text="Edit My Account"
            OnClick="ImageButton3_Click" />
        <br />
        <br />
        <asp:Label ID="lblNoPet" runat="server" ForeColor="red"></asp:Label>
        <div class="innerpageheading">
            <h2>
                <span class="heading">When?</span></h2>
            <div class="datediv">
                <br />
                <asp:Label ID="datelabel" CssClass="shortestlabel" runat="server">Date<span class="mand">*</span>:</asp:Label>
            </div>
            <div class="datediv">
                <asp:Label ID="mmlistlabel" CssClass="shortestlabel" runat="server">MM</asp:Label><br />
                <asp:DropDownList ID="ddlMonth" runat="server" CssClass="dddrop">
                    <asp:ListItem Text="Jan" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Feb" Value="2"></asp:ListItem>
                    <asp:ListItem Text="March" Value="3"></asp:ListItem>
                    <asp:ListItem Text="Apr" Value="4"></asp:ListItem>
                    <asp:ListItem Text="May" Value="5"></asp:ListItem>
                    <asp:ListItem Text="June" Value="6"></asp:ListItem>
                    <asp:ListItem Text="July" Value="7"></asp:ListItem>
                    <asp:ListItem Text="Aug" Value="8"></asp:ListItem>
                    <asp:ListItem Text="Sept" Value="9"></asp:ListItem>
                    <asp:ListItem Text="Oct" Value="10"></asp:ListItem>
                    <asp:ListItem Text="Nov" Value="11"></asp:ListItem>
                    <asp:ListItem Text="Dec" Value="12"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="datediv">
                <asp:Label ID="ddlistlabel" CssClass="shortestlabel" runat="server">DD</asp:Label><br />
                <asp:DropDownList ID="dddDay" CssClass="dddrop" runat="server">
                </asp:DropDownList>
            </div>
            <div class="datediv">
                <asp:Label ID="yylistlabel" CssClass="shortestlabel" runat="server">YY</asp:Label><br />
                <asp:DropDownList ID="ddlYear" CssClass="dddrop" runat="server">
                </asp:DropDownList>
            </div>
            <div class="datediv">
                <asp:Label ID="timelabel" CssClass="shortestlabel" runat="server">Time<span class="mand">*</span>:</asp:Label>
            </div>
            <div class="timediv">
                <asp:DropDownList ID="ddlhr" CssClass="timedrop" runat="server">
                </asp:DropDownList>
                <asp:DropDownList ID="ddlmin" CssClass="appTextFldAm" Visible="false" runat="server">
                    <asp:ListItem Value=" " Text=" "></asp:ListItem>
                    <asp:ListItem Value=" " Text=" "></asp:ListItem>
                </asp:DropDownList>
            </div>
            <asp:CheckBox ID="chkalt" runat="server" Text="Flexible" CssClass="shortestlabel"
                onClick="ShowDiv();" />
            <div id="divalt" runat="server" style="display: none">
                <div class="timediv">
                    <asp:DropDownList ID="ddlFlex" runat="server" CssClass="appddlFldday">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlFlexDay" CssClass="appddlFldday" runat="server" Style="display: none;">
                        <asp:ListItem Text="Select One" Value="0"></asp:ListItem>
                        <asp:ListItem Text="1 day" Value="1"></asp:ListItem>
                        <asp:ListItem Text="2 day" Value="2"></asp:ListItem>
                        <asp:ListItem Text="3 day" Value="3"></asp:ListItem>
                        <asp:ListItem Text="4 day" Value="4"></asp:ListItem>
                        <asp:ListItem Text="5 day" Value="5"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlFlexHr" CssClass="appddlFldhour" runat="server" Style="display: none;">
                        <asp:ListItem Text="1 hr" Value="1"></asp:ListItem>
                        <asp:ListItem Text="2 hr" Value="2"></asp:ListItem>
                        <asp:ListItem Text="3 hr" Value="3"></asp:ListItem>
                        <asp:ListItem Text="4 hr" Value="4"></asp:ListItem>
                        <asp:ListItem Text="5 hr" Value="5"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <h2>
                <span class="heading">Where?</span></h2>
            <div class="wherediv">
                <asp:RadioButton ID="red1" runat="server" Text="Primary Address" Checked="true" onClick="return setred1();" /><br />
                <asp:TextBox ID="txtPrimary" runat="server" CssClass="wheretxtbox" TextMode="MultiLine"></asp:TextBox>
            </div>
            <div class="wherediv">
                <asp:RadioButton ID="red2" runat="server" Text="Alternate Address" onClick="return setred2();" /><br />
                <asp:TextBox ID="txtAlternat" runat="server" CssClass="wheretxtbox" TextMode="MultiLine"></asp:TextBox>
            </div>
            <h2>
                <span class="heading">Confirm By</span></h2>
            <div class="wherediv">
                <asp:RadioButtonList ID="redConfirmBy" runat="server" RepeatDirection="Horizontal"
                    Width="200px">
                    <asp:ListItem Text="Email" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Phone" Value="1" Selected="True"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <h2>
                <span class="heading">Notes To The Groomer</span></h2>
            <asp:TextBox runat="server" ID="idtextarea" CssClass="txtarea" TextMode="MultiLine"
                MaxLength="250"></asp:TextBox>
            <asp:Button ID="IdNext" CssClass="button" Text="SCHEDULE" runat="server" OnClick="IdNext_Click" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBodyEnd" runat="server">
    <script type="text/javascript" lang="javascript" defer="defer">
        function setList(i) {
            if (document.getSelectedCheckbox("ctl00_ContentPlaceHolder1_lstAddservices" + i).style.display == "none") {
                document.getSelectedCheckbox("ctl00_ContentPlaceHolder1_lstAddservices" + i).style.display = "block";
                document.getSelectedCheckbox("ctl00_ContentPlaceHolder1_lstAddservices" + i).focus();
            }
            else {
                document.getSelectedCheckbox("ctl00_ContentPlaceHolder1_lstAddservices" + i).style.display = "block";
            }
            return false;
        }
        function HideList(i) {
            document.getSelectedCheckbox("ctl00_ContentPlaceHolder1_lstAddservices" + i).style.display = "block";
            return false;
        }

        function SetText(i) {
            var Source = document.getSelectedCheckbox("ctl00_ContentPlaceHolder1_lstAddservices" + i);
            var str = "";
            var str1 = "";
            //alert(Source.options.selectedIndex);
            for (j = 0; j < document.getSelectedCheckbox("ctl00_ContentPlaceHolder1_lstAddservices" + i).length; j++) {
                if (Source.options[j].selected) {
                    if (str == "") {
                        str = Source.options[j].text;
                        str1 = Source.options[j].value;
                    }
                    else {
                        str = str + "," + Source.options[j].text;
                        str1 = str1 + "," + Source.options[j].value;
                    }
                }
            }

            document.getSelectedCheckbox("ctl00_ContentPlaceHolder1_txtAddServices" + i).value = str;
            document.getSelectedCheckbox("ctl00_ContentPlaceHolder1_txtAddServicesID" + i).value = str1;
        }



    </script>

    <script type="text/javascript" language="javascript">



        function ShowDiv() {
            if (document.getElementById('<%=chkalt.ClientID %>').checked) {
                document.getElementById('<%=divalt.ClientID %>').style.display = "block";
            }
            else {
                document.getElementById('<%=divalt.ClientID %>').style.display = "none";
            }
        }


        function setred1() {
            if (document.getElementById('<%=red1.ClientID %>').checked) {
                document.getElementById('<%=txtAlternat.ClientID %>').disabled = true;
                document.getElementById('<%=txtPrimary.ClientID %>').disabled = false;
                document.getElementById('<%=red2.ClientID %>').checked = false;
            }
        }
        function setred2() {
            if (document.getElementById('<%=red2.ClientID %>').checked) {
                document.getElementById('<%=txtPrimary.ClientID %>').disabled = true;
                document.getElementById('<%=txtAlternat.ClientID %>').disabled = false;
                document.getElementById('<%=red1.ClientID %>').checked = false;
            }
        }

        function confirmation() {
            if (!confirm("Do you want to delete this pet?")) {
                return false;
            }
        }
    </script>
</asp:Content>
