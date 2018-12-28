<%@ Page Title="" Language="C#" MasterPageFile="~/EadTeam.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EAD_Project.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style1 {
        height: 50px;
    }
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Css/LoginPage.css" rel="stylesheet" />
    <div class="Contents">
        <asp:Label ID="LblLogin" runat="server" Font-Size="XX-Large" Font-Bold="True" Font-Underline="True"></asp:Label>
        <br />
        <br />
        <script type="text/javascript">
            function redirect(webpage) {
                window.location = webpage;
            }
        </script>
        <br />
        <div>
            <table class="style" style="margin-bottom: 0px">
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="LblUserName" runat="server" Text="Username: "></asp:Label>
                        <asp:TextBox ID="tbUsername" runat="server" Height="30px" CssClass="Corners"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorUsername" runat="server" ControlToValidate="tbUsername" ErrorMessage="Please enter your username" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LblPassword" runat="server" Text="Password: "></asp:Label>
                        &nbsp;<asp:TextBox ID="tbPassword" runat="server" Height="30px" CssClass="Corners" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server" ControlToValidate="tbPassword" ErrorMessage="Please enter your password" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LblResetPassword" runat="server" Text="" Visible="False"></asp:Label>
                        <br />
                    <asp:Label ID="LblErr" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                    </td>
                </tr>
                </table>
            
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
            
            <br />
            
        </div>
            <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="Corners" Height="48px" Width="85px" OnClick="btnLogin_Click"/>
        &nbsp;&nbsp;
        
        <input id="btnCancel" class="Cancel Corners" type="button" value="Cancel" OnClick="redirect('MainPage.aspx')"/>
        
        <br />
        <br />
        
    </div>
</asp:Content>
