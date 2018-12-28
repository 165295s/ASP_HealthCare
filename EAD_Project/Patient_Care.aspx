<%@ Page Title="" Language="C#" MasterPageFile="~/EadTeam.Master" AutoEventWireup="true" CodeBehind="Patient_Care.aspx.cs" Inherits="EAD_Project.Patient_Care" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style15 {
            margin-bottom: 2;
        }
        </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Css/PatientCareStyle.css" rel="stylesheet" />
    <div class="title">
        <asp:Label ID="patientCare" runat="server">Patient Care</asp:Label>
    </div>
        <div>
            <h4 ID="Label1" runat="server" Text="Label">Select Shift</h4>
        </div>
        <div class="panel panel-info">
            <div class="panel-heading">
                <h3 class="panel-title">Shift Date:<asp:Label ID="dateStar" runat="server" ForeColor="Red" Text="*" Font-Size ="Large" Visible="False"></asp:Label></h3>
            </div>  
            <div class="panel-body">
                <asp:TextBox Name="shiftDateStart" ID="shiftDateStart" runat="server" Width="213px" ForeColor="Black" placeholder="dd/mm/yyyy" TextMode="Date"></asp:TextBox>
                To <asp:TextBox Name="shiftDateEnd" ID="shiftDateEnd" runat="server" Width="213px" ForeColor="Black" placeholder="dd/mm/yyyy" TextMode="Date"></asp:TextBox>
            </div>
        </div>
        <div class="panel panel-info">
            <div class="panel-heading">
                <h3 class="panel-title">Shift Time:<asp:Label ID="timeStar" runat="server" ForeColor="Red" Text="*" Font-Size ="Large" Visible="False"></asp:Label></h3>
            </div>
            <div class="panel-body">
                 <div class="form-content">
                    <asp:TextBox ID="shiftTimeStart" runat="server" TextMode="Time"></asp:TextBox>
                    To <asp:TextBox ID="shiftTimeEnd" runat="server" TextMode="Time"></asp:TextBox>
                 </div>
            </div>
        </div>
        <div class="panel panel-info">
            <div class="panel-heading">
                <h3 class="panel-title">Ward in charge of:<asp:Label ID="wardStar" runat="server" ForeColor="Red" Text="*" Font-Size ="Large" Visible="False"></asp:Label></h3>
            </div>
            <div class="panel-body">
                <div class="form-content">
                    <asp:DropDownList ID="wardList" runat="server">
                        <asp:ListItem Selected="True">--Select--</asp:ListItem>
                        <asp:ListItem>L200</asp:ListItem>
                        <asp:ListItem>L300</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="buttons">
            <div>
                <table style="width: 100%;">
                    <tr>
                        <td><asp:Button ID="cancelBut" runat="server" OnClick="cancelBut_Click" Text="Cancel" OnClientClick = "return confirm('Cancel?');"/><asp:Button ID="resetBut" runat="server" OnClick="resetBut_Click" Text="Reset" OnClientClick = "return confirm('Are you sure you want to reset?');"/></td>
                        <td><asp:Button ID="confirmBut" runat="server" OnClick="confirmBut_Click" Text="Confirm" EnableViewState="False" /></td>
                    </tr>
                </table>
            </div>
        </div>
        <div>
            <asp:Panel ID="errorPanel" runat="server">
                <asp:Label ID="errorLabel" runat="server" Text="Label" ForeColor="Red" Visible="False"></asp:Label>
            </asp:Panel>
        </div>
        <div>

        </div>
</asp:Content>
