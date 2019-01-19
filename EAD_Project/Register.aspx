<%@ Page Title="" Language="C#" MasterPageFile="~/EadTeam.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="EAD_Project.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        
        .Content {
            width: 100%;
            height: 100%;
        }
        
        .auto-style1 {
            width: 80%;
            margin: 0 auto;
        }
        
        .auto-style2 {
            height: 22px;
        }
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Content" style="text-align: center">
        <asp:Label ID="lbl_Register" runat="server" Text="Visitor Registration" Font-Size="XX-Large"></asp:Label>
    </div>
    <div class="Content" style="text-align: center">
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lbl_Nric" runat="server" Text="NRIC"></asp:Label></td>
                <td class="auto-style2">
                    <asp:TextBox ID="tb_Nric" runat="server"></asp:TextBox></td>
                <td class="auto-style2">
                    <asp:RequiredFieldValidator ID="rfv_Nric" runat="server" ErrorMessage="NRIC is required!" ForeColor="Red" ControlToValidate="tb_Nric"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_Name" runat="server" Text="Name"></asp:Label></td>
                <td>
                    <asp:TextBox ID="tb_Name" runat="server"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="rfv_Name" runat="server" ErrorMessage="Name is required!" ForeColor="Red" ControlToValidate="tb_Name"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_Password" runat="server" Text="Password"></asp:Label></td>
                <td>
                    <asp:TextBox ID="tb_Password" runat="server" TextMode="Password"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="rfv_Password" runat="server" ErrorMessage="Password is required!" ForeColor="Red" ControlToValidate="tb_Password"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_ConfirmPassword" runat="server" Text="Confirm Password"></asp:Label></td>
                <td>
                    <asp:TextBox ID="tb_ConfirmPassword" runat="server" TextMode="Password"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="rfv_ConfirmPassword" runat="server" ErrorMessage="Please re-enter your password" ForeColor="Red" ControlToValidate="tb_ConfirmPassword"></asp:RequiredFieldValidator>
                    <br />
                    <asp:CompareValidator ID="cv_ConfirmPassword" runat="server" ErrorMessage="Password is not the same!" ForeColor="Red" ControlToCompare="tb_Password" ControlToValidate="tb_ConfirmPassword" ></asp:CompareValidator>
                    </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_Gender" runat="server" Text="Gender"></asp:Label></td>
                <td>
                    <asp:RadioButtonList ID="rb_GenderList" runat="server" RepeatDirection="Horizontal" Width="179px">
                        <asp:ListItem Text="Male" Value="Male" Selected="True" />
                        <asp:ListItem Text="Female" Value="Female" />
                    </asp:RadioButtonList></td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_Number" runat="server" Text="Mobile Number"></asp:Label></td>
                <td>
                    <asp:TextBox ID="tb_Number" runat="server" TextMode="Number"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="rfv_Number" runat="server" ErrorMessage="Mobile number is required!" ForeColor="Red" ControlToValidate="tb_Number"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_Email" runat="server" Text="Email"></asp:Label></td>
                <td>
                    <asp:TextBox ID="tb_Email" runat="server"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="rfv_Email" runat="server" ErrorMessage="Email is required!" ForeColor="Red" ControlToValidate="tb_Email"></asp:RequiredFieldValidator></td>
            </tr>
        </table>
        <asp:Button ID="btn_Submit" runat="server" Text="Submit" OnClick="btn_Submit_Click" />
        <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" />
    </div>
</asp:Content>
