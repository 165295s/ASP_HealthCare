<%@ Page Title="" enableEventValidation="false" Language="C#" MasterPageFile="~/EadTeam.Master" AutoEventWireup="true" CodeBehind="AssignNurses.aspx.cs" Inherits="EAD_Project.AssignNurses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-info">
        <div class="panel-heading">
            <asp:Label ID="assignNurse" runat="server" Font-Size="Large" ForeColor="Black" Text="Assign Nurses"></asp:Label>
        </div>
    </div>
    <div class="panel-body">
        <div class="form-content">
            <asp:GridView ID="NurseList" runat="server" AutoGenerateRows="False" CssClass="table table-striped" AutoGenerateColumns="False" OnSelectedIndexChanged="NurseList_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField HeaderText="Nurses Available" AccessibleHeaderText="Nurses Available" DataField="Name" />  
                    <asp:BoundField  HeaderText="NRIC" AccessibleHeaderText="NRIC" DataField="NRIC" />
                    <asp:CommandField InsertVisible="False" ShowCancelButton="False" ShowSelectButton="True" />
                    
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            
        </div>
    </div>
</asp:Content>
