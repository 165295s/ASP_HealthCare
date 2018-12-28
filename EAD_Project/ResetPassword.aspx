<%@ Page Title="" Language="C#" MasterPageFile="~/EadTeam.Master" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="EAD_Project.Registration.ResetPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../Css/Forms.css" rel="stylesheet" />
    <div class="Contents">
        <asp:Label ID="LblTitle" runat="server" Text="Reset your password" Font-Size="XX-Large"></asp:Label>
        <br />
        <asp:Label ID="LblLogin" runat="server" Text="" Visible="false"></asp:Label>
        <br />
        <br />
    </div>
    <div>
        <table>
            <tr>
                <td class="RightAlign">
                    <asp:Label ID="lblPassword" runat="server" Text="Password: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbPassword" runat="server" CssClass="Corners" Width="235px" TextMode="Password"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server" ControlToValidate="tbPassword" ErrorMessage="Please enter new password" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="RightAlign">
                    <asp:Label ID="lblCfmPassword" runat="server" Text="Confirm password: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbCfmPassword" runat="server" CssClass="Corners" Width="235px" TextMode="Password"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorCfmPassword" runat="server" ControlToValidate="tbCfmPassword" ErrorMessage="Please confirm your password" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidatorPassword" runat="server" ErrorMessage="Password and Confirm Password must match" Text="*" ControlToValidate="tbCfmPassword" ControlToCompare="tbPassword" Operator="Equal" Type="String" ForeColor="Red"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="Corners" Height="36px" OnClick="btnReset_Click" Width="235px" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <br />
    </div>
</asp:Content>
