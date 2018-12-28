<%@ Page Title="" Language="C#" MasterPageFile="~/EadTeam.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="EAD_Project.Checkout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            margin-top: 0px;
        }
        .auto-style2 {
            width: 199px;
        }
        .auto-style3 {
            width: 509px;
        }
        .auto-style4 {
            width: 199px;
            height: 47px;
        }
        .auto-style5 {
            width: 509px;
            height: 47px;
        }
        .auto-style6 {
            height: 47px;
        }
        .auto-style7 {
            width: 199px;
            height: 228px;
        }
        .auto-style8 {
            width: 509px;
            height: 228px;
        }
        .auto-style9 {
            height: 228px;
        }
        .auto-style10 {
            width: 199px;
            height: 22px;
        }
        .auto-style11 {
            width: 509px;
            height: 22px;
        }
        .auto-style12 {
            height: 22px;
        }
        .auto-style25 {
            width: 199px;
            height: 59px;
        }
        .auto-style26 {
            width: 509px;
            height: 59px;
        }
        .auto-style28 {
            height: 59px;
        }
        .auto-style35 {
            width: 199px;
            height: 27px;
        }
        .auto-style36 {
            width: 509px;
            height: 27px;
        }
        .auto-style38 {
            height: 27px;
        }
        .auto-style39 {
            width: 199px;
            height: 62px;
        }
        .auto-style40 {
            width: 509px;
            height: 62px;
        }
        .auto-style42 {
            height: 62px;
        }
        .auto-style43 {
            width: 199px;
            height: 96px;
        }
        .auto-style44 {
            width: 509px;
            height: 96px;
        }
        .auto-style46 {
            height: 96px;
        }
        .auto-style47 {
            width: 199px;
            height: 25px;
        }
        .auto-style48 {
            width: 509px;
            height: 25px;
        }
        .auto-style50 {
            height: 25px;
        }
        .auto-style51 {
            width: 199px;
            height: 20px;
        }
        .auto-style52 {
            width: 509px;
            height: 20px;
        }
        .auto-style54 {
            height: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <link href="Css/CheckOutStyle.css" rel="stylesheet" />

            <p id="checkout">
                
                &nbsp;<asp:Label ID="Label1" runat="server" Font-Size="XX-Large" Text="Checkout"></asp:Label>
        <br />
    </p>
    <table class="auto-style1">
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">
                <asp:TextBox ID="TextBox5" runat="server" ReadOnly="True" Visible="False"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox6" runat="server" ReadOnly="True" Visible="False" OnTextChanged="TextBox6_TextChanged"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style47"></td>
            <td class="auto-style48">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
            <td class="auto-style50">
                </td>
            <td class="auto-style50"></td>
            <td class="auto-style50"></td>
            <td class="auto-style50"></td>
            <td class="auto-style50"></td>
            <td class="auto-style50"></td>
            <td class="auto-style50"></td>
            <td class="auto-style50"></td>
            <td class="auto-style50"></td>
            <td class="auto-style50"></td>
            <td class="auto-style50"></td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style51"></td>
            <td class="auto-style52">
                </td>
            <td class="auto-style54"></td>
            <td class="auto-style54"></td>
            <td class="auto-style54"></td>
            <td class="auto-style54">
                <asp:Label ID="Label7" runat="server" Text="Recipient "></asp:Label>
            </td>
            <td class="auto-style54"></td>
            <td class="auto-style54"></td>
            <td class="auto-style54"></td>
            <td class="auto-style54"></td>
            <td class="auto-style54"></td>
            <td class="auto-style54"></td>
            <td class="auto-style54"></td>
        </tr>
        <tr>
            <td class="auto-style35"></td>
            <td class="auto-style36">
                <asp:Label ID="Label5" runat="server" Font-Size="XX-Large" ForeColor="#CCCCCC" Text="Your Order Summary"></asp:Label>
            </td>
            <td class="auto-style38">
                <br />
                <br />
                <br />
            </td>
            <td class="auto-style38">
                <br />
                <br />
                <br />
            </td>
            <td class="auto-style38"></td>
            <td class="auto-style38">
                <asp:TextBox ID="TextBox7" runat="server" Height="44px" Width="268px"></asp:TextBox>
            </td>
            <td class="auto-style38"></td>
            <td class="auto-style38"></td>
            <td class="auto-style38"></td>
            <td class="auto-style38"></td>
            <td class="auto-style38"></td>
            <td class="auto-style38"></td>
            <td class="auto-style38"></td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">
                <asp:Panel ID="Panel1" runat="server" Height="238px">
                    <asp:GridView ID="GridView1" runat="server" CssClass="auto-style18" Height="240px" Width="506px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1" AutoGenerateSelectButton="True" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" GridLines="None" ForeColor="Black">
                        <AlternatingRowStyle BackColor="PaleGoldenrod" />
                        <FooterStyle BackColor="Tan" />
                        <HeaderStyle BackColor="Tan" Font-Bold="True" />
                        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                        <SortedAscendingCellStyle BackColor="#FAFAE7" />
                        <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                        <SortedDescendingCellStyle BackColor="#E1DB9C" />
                        <SortedDescendingHeaderStyle BackColor="#C2A47B" />
                    </asp:GridView>
                </asp:Panel>
            </td>
            <td>
                &nbsp;</td>
            <td>
                <br />
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;<asp:Label ID="Label8" runat="server" Text="Address"></asp:Label>
                <br />
                <asp:TextBox ID="TextBox8" runat="server" Height="44px" Width="268px"></asp:TextBox>
                <br />
                <br />
                <br />
                <asp:Label ID="Label10" runat="server" Text="Phone Number:"></asp:Label>
                <br />
                <asp:TextBox ID="TextBox9" runat="server" Height="44px" Width="268px" OnTextChanged="TextBox9_TextChanged"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style43"></td>
            <td class="auto-style44">
                <br />
                <br />
                <asp:Label ID="LabelTime" runat="server"></asp:Label>
                <br />
                <br />
                <br />
                <asp:Label ID="Label6" runat="server" Font-Size="Large" Text="Total Price:"></asp:Label>
&nbsp;<br />
                <asp:TextBox ID="TextBox4" runat="server" Height="22px" OnTextChanged="TextBox4_TextChanged" ReadOnly="True" Width="162px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            <td class="auto-style46">
                &nbsp;</td>
            <td class="auto-style46">
                <br />
            </td>
            <td class="auto-style46"></td>
            <td class="auto-style46">
                <asp:Label ID="Label9" runat="server" Text="BankAccount No."></asp:Label>
                <br />
                <asp:TextBox ID="TextBox10" runat="server" Height="44px" Width="268px"></asp:TextBox>
            </td>
            <td class="auto-style46"></td>
            <td class="auto-style46"></td>
            <td class="auto-style46"></td>
            <td class="auto-style46"></td>
            <td class="auto-style46"></td>
            <td class="auto-style46"></td>
            <td class="auto-style46"></td>
        </tr>
        <tr>
            <td class="auto-style39"></td>
            <td class="auto-style40">&nbsp;</td>
            <td class="auto-style42">
            </td>
            <td class="auto-style42"></td>
            <td class="auto-style42"></td>
            <td class="auto-style42"></td>
            <td class="auto-style42"></td>
            <td class="auto-style42"></td>
            <td class="auto-style42"></td>
            <td class="auto-style42"></td>
            <td class="auto-style42"></td>
            <td class="auto-style42"></td>
            <td class="auto-style42"></td>
        </tr>
        <tr>
            <td class="auto-style2"></td>
            <td class="auto-style3">
                <asp:Button ID="Button1" runat="server" Height="65px" OnClick="Button1_Click" Text="Cancel" Width="194px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button2" runat="server" Height="65px" Text="Confirm" Width="194px" OnClick="Button2_Click" />
            </td>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td></td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td class="auto-style7"></td>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style9">
                &nbsp;</td>
            <td class="auto-style9">&nbsp;</td>
            <td class="auto-style9">&nbsp;</td>
            <td class="auto-style9">&nbsp;</td>
            <td class="auto-style9">&nbsp;</td>
            <td class="auto-style9"></td>
            <td class="auto-style9"></td>
            <td class="auto-style9"></td>
            <td class="auto-style9"></td>
            <td class="auto-style9"></td>
            <td class="auto-style9">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style10"></td>
            <td class="auto-style11"></td>
            <td class="auto-style12">
                &nbsp;</td>
            <td class="auto-style12">&nbsp;</td>
            <td class="auto-style12">&nbsp;</td>
            <td class="auto-style12">&nbsp;</td>
            <td class="auto-style12"></td>
            <td class="auto-style12"></td>
            <td class="auto-style12"></td>
            <td class="auto-style12"></td>
            <td class="auto-style12"></td>
            <td class="auto-style12"></td>
            <td class="auto-style12"></td>
        </tr>
        <tr>
            <td class="auto-style25"></td>
            <td class="auto-style26"></td>
            <td class="auto-style28">
                &nbsp;</td>
            <td class="auto-style28"></td>
            <td class="auto-style28"></td>
            <td class="auto-style28"></td>
            <td class="auto-style28"></td>
            <td class="auto-style28"></td>
            <td class="auto-style28"></td>
            <td class="auto-style28"></td>
            <td class="auto-style28"></td>
            <td class="auto-style28"></td>
            <td class="auto-style28"></td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style6">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style6">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2"></td>
            <td class="auto-style3"></td>
            <td>
                &nbsp;</td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
    </table>
</asp:Content>
