<%@ Page Title="" Language="C#" MasterPageFile="~/EadTeam.Master" AutoEventWireup="true" CodeBehind="OnlineAppointment.aspx.cs" Inherits="EAD_Project.OnlineAppointment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100px;
        }
        .auto-style2 {
            width: 260px;
        }
        .auto-style4 {
            width: 100%;
        }
        .auto-style5 {
            width: 332px;
        }
        .auto-style6 {
            width: 563px;
        }
        .auto-style8 {
            height: 20px;
            width: 280px;
        }
        .auto-style12 {
            width: 100px;
            height: 162px;
        }
        .auto-style13 {
            width: 260px;
            height: 162px;
        }
        .auto-style14 {
            width: 563px;
            height: 162px;
        }
        .auto-style15 {
            height: 162px;
        }
        .auto-style18 {
            width: 331px;
        }
        .auto-style19 {
            width: 330px;
        }
        .auto-style20 {
            width: 280px;
        }
        .auto-style21 {
            width: 100px;
            height: 36px;
        }
        .auto-style22 {
            width: 260px;
            height: 36px;
        }
        .auto-style23 {
            width: 563px;
            height: 36px;
        }
        .auto-style24 {
            height: 36px;
        }
        .auto-style25 {
            width: 100%;
            height: 247px;
        }
        .auto-style26 {
            margin-top: 0px;
        }
        .auto-style27 {
            width: 100px;
            height: 26px;
        }
        .auto-style28 {
            width: 260px;
            height: 26px;
        }
        .auto-style29 {
            width: 563px;
            height: 26px;
        }
        .auto-style30 {
            height: 26px;
        }
        .auto-style31 {
            width: 277px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Css/OnlineAppointment.css" rel="stylesheet" />
    <div class="Title">
        <asp:Label ID="LabelHead" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="X-Large" Text="Online Appointment System" Font-Underline="True"></asp:Label>
    </div>
    <div>
        <table style="width: 100%;">
            <tr>
                <td class="auto-style21"></td>
                <td class="auto-style22">
    <div class="PickDate"> 
        <asp:Label ID="LabelPickDate" runat="server" Text="Pick a date:" Font-Bold="True" Font-Size="Medium" Font-Underline="True"></asp:Label>
    </div>
                </td>
                <td class="auto-style23"></td>
                <td class="auto-style24"></td>
                <td class="auto-style24"></td>
            </tr>
            <tr>
                <td class="auto-style12"></td>
                <td class="auto-style13">
                    <asp:Calendar ID="CalendarDate" runat="server" Width="253px" AutoPostBack="True" OnSelectionChanged="CalendarDate_SelectionChanged" Height="221px"></asp:Calendar>
                </td>
                <td class="auto-style14">
                    <br />
                    <br />
                    <table class="auto-style4">
                        <tr>
                            <td class="auto-style5">
        <asp:Label ID="LabelDate" runat="server" Text="Book Date: " Font-Size="Small"></asp:Label>
                                &nbsp;<asp:TextBox ID="TextBoxBookDate" runat="server" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style5">
                                <asp:Label ID="LabelPreferredDoc" runat="server" Font-Size="Small" Text="Preferred Doctor:  "></asp:Label>
                    &nbsp;<asp:DropDownList ID="DropDownListDoc" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListDoc_SelectedIndexChanged">
                    <asp:ListItem>---Please Select---</asp:ListItem>
                    <asp:ListItem>Dr Tan Yijun Kenneth</asp:ListItem>
                    <asp:ListItem>Dr Tony Tan</asp:ListItem>
                    </asp:DropDownList>
                                &nbsp;
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    <table class="auto-style4">
                        <tr>
                            <td class="auto-style31">
        <asp:Label ID="LabelTiming" runat="server" Text="Book Timing: " Font-Size="Small"></asp:Label>
                                <asp:DropDownList ID="DropDownListTimings" AutoPostBack="True" runat="server" OnSelectedIndexChanged="DropDownListTimings_SelectedIndexChanged">
                                    <asp:ListItem>---Please Select---</asp:ListItem>
                                    <asp:ListItem>12pm to 12.30pm</asp:ListItem>
                                    <asp:ListItem>12.30pm to 1pm</asp:ListItem>
                                    <asp:ListItem>1pm to 1.30pm</asp:ListItem>
                                    <asp:ListItem>1.30pm to 2pm</asp:ListItem>
                                    <asp:ListItem>2pm to 2.30pm</asp:ListItem>
                                    <asp:ListItem>2.30pm to 3pm</asp:ListItem>
                                    <asp:ListItem></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style31">
                                <asp:Label ID="LabelReason" runat="server" Font-Size="Small" Text="Reason: "></asp:Label>                                
                                <asp:CheckBoxList ID="CheckBoxListOptions" runat="server" Height="99px" AutoPostBack="True" OnSelectedIndexChanged="CheckBoxListOptions_SelectedIndexChanged1">
                                    <asp:ListItem>Asthma</asp:ListItem>
                                    <asp:ListItem>Cancer</asp:ListItem>
                                    <asp:ListItem>Diabetes</asp:ListItem>
                                    <asp:ListItem>HIV/AIDS</asp:ListItem>
                                    <asp:ListItem>Parkinson disease</asp:ListItem>
                                    <asp:ListItem>Other...</asp:ListItem>
                                </asp:CheckBoxList>
                                    
                            </td>
                            <td>
                                <table class="auto-style4">
                                    <tr>
                                        <td>
                                            <asp:Label ID="LabelSpecify" runat="server" Text="Please Specify:"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="TextBoxOthers" runat="server" Height="86px" Width="223px" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <br />
                </td>
                <td class="auto-style15">
                    <asp:Label ID="LabelErrorMsg" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                </td>
                <td class="auto-style15"></td>
            </tr>
            <tr>
                <td class="auto-style27"></td>
                <td class="auto-style28">
                    </td>
                <td class="auto-style29">
                    &nbsp;</td>
                <td class="auto-style30">&nbsp;</td>
                <td class="auto-style30"></td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    &nbsp;</td>
                <td class="auto-style6">
                    <asp:Label ID="LabelSuccessfulMsg" runat="server" Font-Bold="True" ForeColor="#33CC33"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    &nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>
    <table class="auto-style4">
        <tr>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style8">Doctor on shift:</td>
            <td class="auto-style8">Date:</td>
            <td class="auto-style8">Timing:</td>
            <td class="auto-style18">Reason:</td>
        </tr>
        <tr>
            <td class="auto-style20">
                &nbsp;</td>
            <td class="auto-style20">
                <asp:TextBox ID="TextBoxDocShift" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
            <td class="auto-style20">
                <asp:TextBox ID="TextBoxDate" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
            <td class="auto-style20">
                <asp:TextBox ID="TextBoxTiming" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBoxReason" runat="server" ReadOnly="True" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">
                <asp:Button ID="ButtonBookAppointment" runat="server" Text="Book Appointment"  OnClick="ButtonBookAppointment_Click" />
            </td>
            <td class="auto-style8"></td>
            <td class="auto-style8"></td>
            <td class="auto-style8"></td>
            <td class="auto-style19"></td>
        </tr>
        <tr>
            <td class="auto-style20">
                &nbsp;</td>
            <td class="auto-style20">&nbsp;</td>
            <td class="auto-style20">&nbsp;</td>
            <td class="auto-style20">&nbsp;</td>
        </tr>
    </table>

        <div class="auto-style25">
        <asp:GridView ID="GridViewApptDetails" runat="server" AutoGenerateColumns="False" CssClass="auto-style26" Height="240px" Width="1338px">
            <Columns>
                <asp:BoundField HeaderText="Doctor Name" DataField="doctorName" />
                <asp:BoundField HeaderText="Date" DataField="date" />
                <asp:BoundField HeaderText="Timing" DataField="timing" />
                <asp:BoundField DataField="reason" HeaderText="Reason" />
            </Columns>
        </asp:GridView>

        </div>

    
</asp:Content>
