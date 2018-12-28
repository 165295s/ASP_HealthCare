<%@ Page Title="" Language="C#" MasterPageFile="~/EadTeam.Master" AutoEventWireup="true" CodeBehind="ReminderPatientSelection.aspx.cs" Inherits="EAD_Project.ReminderPatientSelection" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Css/ReminderNurseSelectionStyle.css" rel="stylesheet" />
    <div class ="title">
        <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="X-Large" Text="Reminder System" Font-Underline="True"></asp:Label>
    </div>
    <br />
    <div class="Contents">
        <div class="panel panel-info">
            <div class="panel panel-heading">
                <asp:Label ID="LabelHead" Font-Bold="true" runat="server" Font-Italic="False" Font-Size="Large" Text="Select a patient"></asp:Label>
            </div>
            <div class =" panel panel-body">
                <asp:TextBox ID="TextBoxSearching" runat="server"></asp:TextBox>
                <asp:Button ID="ButtonSearch" runat="server" Text="Search" OnClick="ButtonSearch_Click" />
                <asp:Button ID="ButtonSelectAll" runat="server" Text="Select All" OnClick="ButtonSelectAll_Click" />

                <br />
                <br />
                <asp:GridView ID="GridViewPatientDetails" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridViewPatientDetails_SelectedIndexChanged" CssClass="table table-striped">
                    <Columns>
                        <asp:BoundField DataField="NRIC" HeaderText="NRIC" />
                        <asp:BoundField DataField="Name" HeaderText="Name" />
                        <asp:BoundField DataField="Gender" HeaderText="Gender" />
                        <asp:BoundField DataField="Email" HeaderText="Email" />
                        <asp:CommandField InsertVisible="False" ShowCancelButton="False" ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        
    </div>
</asp:Content>
