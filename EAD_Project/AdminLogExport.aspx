<%@ Page Title="" Language="C#" MasterPageFile="~/EadTeam.Master" AutoEventWireup="true" CodeBehind="AdminLogExport.aspx.cs" Inherits="EAD_Project.AdminLogExport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Audit Trail Log" Font-Size="X-Large" Font-Underline="True"></asp:Label>
        </div>
    <div>
        <button type="button" ID="btnExport" runat="server" Font-Size="Medium" Font-Underline="True" ForeColor="#0000CC" onserverclick="ExportExcel">Export</button>

    </div>
        <asp:GridView ID="AuditLogTable" ShowHeaderWhenEmpty="true" AutoGenerateColumns="false" Width="709px" Height="174px" runat="server">
       <Columns>
        <asp:BoundField DataField="userName" HeaderText="Username" />
        <asp:BoundField DataField="action" HeaderText="Action" />
        <asp:BoundField DataField="timeOfAction" HeaderText="Time"/>

        </Columns>

    </asp:GridView>
        
</asp:Content>
