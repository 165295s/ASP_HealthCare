<%@ Page Title="" Language="C#" MasterPageFile="~/EadTeam.Master" AutoEventWireup="true" CodeBehind="SendEmailLink.aspx.cs" Inherits="EAD_Project.Registration.PasswordChange"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../Css/Forms.css" rel="stylesheet" />
    <div class="Contents">
        <asp:Label ID="LblTitle" runat="server" Text="Enter your email" Font-Size="XX-Large"></asp:Label><br/>
        <asp:Label ID="Lblconfirmation" runat="server" Text="Please check your email" Visible="false" Font-Size="Medium"></asp:Label>
    </div>
        <div>
        
        <table>
            <tr>
                <td class="RightAlign"><asp:Label ID="LblNRIC" runat="server" Text="Email:"></asp:Label></td>
                <td><asp:TextBox ID="TbEmail" runat="server" CssClass="Corners" Width="235px"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server" ControlToValidate="TbEmail" ErrorMessage="Please enter your email" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1"></td>
                <td class="auto-style1">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
                </td>
                <td></td>
            </tr>
            <tr>
                <td class="RightAlign"></td>
                <br/>
                <td><asp:Button ID="BtnEmail" runat="server" Text="Send link to email" CssClass="Corners" Height="43px" OnClick="BtnOTPSubmit_Click" Width="177px"/></td>
                <td></td>
            </tr>

            </table>
            <br />
            <br />
        </div>
</asp:Content>
