<%@ Page Title="" Language="C#" MasterPageFile="~/EadTeam.Master" AutoEventWireup="true" CodeBehind="Nurses_Shift.aspx.cs" Inherits="EAD_Project.Nurses_Shift" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-info">
        <div class="panel-heading">
            <asp:Label ID="Message" runat="server" Font-Size="Large" ForeColor="Red" Text="Click on respective wards to assign nurses to timeslot" AssociatedControlID="wardList"></asp:Label>
        </div>
    </div>
    <div class="panel-body">
        <div class="form-content">
            <asp:GridView ID="wardList" runat="server" AutoGenerateRows="False" CssClass="table table-striped" AutoGenerateColumns="False" OnSelectedIndexChanged="wardList_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="Ward" HeaderText="Level 1" />
                    <asp:CommandField InsertVisible="False" ShowCancelButton="False" ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
            <asp:GridView ID="wardList2" runat="server" AutoGenerateRows="False" CssClass="table table-striped" AutoGenerateColumns="False" OnSelectedIndexChanged="wardList2_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="Ward" HeaderText="Level 2" />
                    <asp:CommandField InsertVisible="False" ShowCancelButton="False" ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
            <asp:GridView ID="wardList3" runat="server" AutoGenerateRows="False" CssClass="table table-striped" AutoGenerateColumns="False" OnSelectedIndexChanged="wardList3_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="Ward" HeaderText="Level 3" />
                    <asp:CommandField InsertVisible="False" ShowCancelButton="False" ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
