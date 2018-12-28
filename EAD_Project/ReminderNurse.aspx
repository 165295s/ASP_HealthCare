<%@ Page Title="" Language="C#" MasterPageFile="~/EadTeam.Master" AutoEventWireup="true" CodeBehind="ReminderNurse.aspx.cs" Inherits="EAD_Project.ReminderNurse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 98%;
        }
        .auto-style3 {
            width: 441px;
        }
        .auto-style4 {
            width: 40%;
        }
        .auto-style5 {
            width: 457px;   
        }
        .auto-style6 {
            width: 441px;
            height: 20px;
        }
        .auto-style7 {
            width: 457px;
            height: 20px;
        }
        .auto-style8 {
            height: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <link href="Css/Reminder(Nurse).css" rel="stylesheet" />
    <div class="Title">
        <asp:Label ID="LabelHead" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="X-Large" Text="Reminder System" Font-Underline="True"></asp:Label>
    </div>


    <table class="auto-style1">
        <tr>
            <td class="auto-style3">
                &nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">
                <div class="patient">
                <table class="auto-style2">
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Patient NRIC: " Font-Size="Small"></asp:Label>
                            <asp:TextBox ID="TextBoxNRIC" runat="server" ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Patient Name: " Font-Size="Small"></asp:Label>
                            <asp:TextBox ID="TextBoxName" runat="server"  ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblPatientGender" runat="server" Text="Patient Gender: " Font-Size="Small"></asp:Label>
                            <asp:TextBox ID="TextBoxGender" runat="server"  ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblPatientEmail" runat="server" Text="Patient Email: " Font-Size="Small"></asp:Label>
                            <asp:TextBox ID="TextBoxEmail" runat="server"  ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnBack" runat="server" Text="Back" Height="26px" OnClick="btnBack_Click" />
                        </td>
                    </tr>
                </table>
                    </div>
            </td>
            <td class="auto-style5">
                <table class="auto-style4">
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Notes: " Font-Size="Small"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="TextBoxNotes" runat="server" Height="62px" TextMode="MultiLine" Width="325px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </td>
            <td>
                <asp:Label ID="LabelErrorMsg" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style6"></td>
            <td class="auto-style7">
                <asp:Label ID="Label7" runat="server" Font-Size="Small" Text="Please indicate the following: "></asp:Label>
            </td>
            <td class="auto-style8">
                <asp:Label ID="Label8" runat="server" Font-Size="Small" Text="Confirmation List: "></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style5">
                <asp:Label ID="Label4" runat="server" Text="Medicines: " Font-Size="Small"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label9" runat="server" Font-Size="Small" Text="Medicines: "></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style5">
                <table class="auto-style1">
                    <tr>
                        <td>
                <asp:DropDownList ID="DropDownListMedicines" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListMedicines_SelectedIndexChanged">
                    <asp:ListItem>---Please Select---</asp:ListItem>
                </asp:DropDownList>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </td>
            <td>
                <asp:TextBox ID="TextBoxMedicines" runat="server" Height="67px" OnTextChanged="TextBoxMedicines_TextChanged" TextMode="MultiLine" Width="223px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style5">
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
         <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style5">
                <asp:Label ID="Label6" runat="server" Text="Duration of medication: " Font-Size="Small"></asp:Label>
             </td>
            <td>
                <asp:Label ID="Label11" runat="server" Font-Size="Small" Text="Duration of medication: "></asp:Label>
             </td>
        </tr>
         <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style5">
                <asp:DropDownList ID="DropDownListDuration" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListDuration_SelectedIndexChanged">
                    <asp:ListItem>---Please Select---</asp:ListItem>
                    <asp:ListItem>1-2 days</asp:ListItem>
                    <asp:ListItem>3-5 days</asp:ListItem>
                    <asp:ListItem>5-7 days</asp:ListItem>
                </asp:DropDownList>
             </td>
            <td>
                <asp:TextBox ID="TextBoxDuration" runat="server"></asp:TextBox>
             </td>
        </tr>
         <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style5">
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
         <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style5">
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
         <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style5">
                <asp:Button ID="btnSelectMedicine" runat="server" Text="Select Medicine" OnClick="btnSelectMedicine_Click" />
                <br />
                <br />
                <asp:Button ID="ButtonSendPatient" runat="server" Text="Send to Patient&nbsp;" OnClick="ButtonSendPatient_Click" />
             </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>



    </table>

     <div>
        <asp:GridView ID="GridViewDetails" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" OnSelectedIndexChanged="GridViewDetails_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="Medicine" DataField="Medicine" />
                <asp:BoundField DataField="Duration" HeaderText="Duration" />
                <asp:BoundField DataField="Notes" HeaderText="Notes" />
                <asp:CommandField InsertVisible="False" ShowCancelButton="False" ShowSelectButton="True" SelectText="Delete" />
            </Columns>
        </asp:GridView>

        </div>
   
</asp:Content>
