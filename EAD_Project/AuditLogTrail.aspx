<%@ Page Title="" Language="C#" MasterPageFile="~/EadTeam.Master" AutoEventWireup="true" CodeBehind="AuditLogTrail.aspx.cs" Inherits="EAD_Project.AuditLogTrail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Audit Trail Log" Font-Size="X-Large" Font-Underline="True"></asp:Label>
        <asp:GridView runat="server" ShowHeaderWhenEmpty="true" AutoGenerateColumns="false" ID="AuditTable" Width="709px" Height="174px">
       <Columns>
        <asp:BoundField DataField="userName" HeaderText="Username" />
        <asp:BoundField DataField="action" HeaderText="Action" />
        <asp:BoundField DataField="timeOfAction" HeaderText="Time"/>

        </Columns>

    </asp:GridView>
        <asp:LinkButton ID="LinkButton1" runat="server" Font-Size="Medium" Font-Underline="True" ForeColor="#0000CC" OnClick="LinkButton1_Click">Click here to return to main menu</asp:LinkButton>
        </div>
</asp:Content>
