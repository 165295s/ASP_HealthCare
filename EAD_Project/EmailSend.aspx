<%@ Page Title="" Language="C#" MasterPageFile="~/EadTeam.Master" AutoEventWireup="true" CodeBehind="EmailSend.aspx.cs" Inherits="EAD_Project.EmailSend" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Label ID="tb_CfmEmail" runat="server" Text="To confirm your account, please click the link that has been sent to you in your email" Font-Size="15pt"></asp:Label>
    </div>
</asp:Content>
