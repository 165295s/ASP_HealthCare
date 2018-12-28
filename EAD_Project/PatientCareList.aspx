<%@ Page Title="" Language="C#" MasterPageFile="~/EadTeam.Master" AutoEventWireup="true" CodeBehind="PatientCareList.aspx.cs" Inherits="EAD_Project.PatientCareList1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Css/PatientCareListStyle.css" rel="stylesheet" />
    <div class="title">
        <asp:Label ID="patientCare" runat="server">Patient Care</asp:Label>
    </div>
    <div>
        <asp:TextBox ID="searchBox" runat="server" OnTextChanged="searchBox_TextChanged"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Search" />
    </div>
    <div class="panel panel-info"">
        <div class="panel-heading">
            <h3 class="panel-title">Patient List:</h3>
        </div>
        <div class="panel-body">
            <div class="form-content">
                <h5>
                    <asp:Label ID="startDate" runat="server" Text="Label"></asp:Label>,
                    <asp:Label ID="startTime" runat="server" Text="Label"></asp:Label>
                </h5>
                <h5>
                    TO
                </h5>
                <h5>
                    <asp:Label ID="endDate" runat="server" Text="Label"></asp:Label>,
                    <asp:Label ID="endTime" runat="server" Text="Label"></asp:Label>
                </h5>
                <asp:GridView ID="gvPatientList" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" >
                    <Columns>
                        <asp:BoundField AccessibleHeaderText="Patient Name" DataField="Name" HeaderText="Patient Name" />
                        <asp:BoundField AccessibleHeaderText="NRIC" DataField="NRIC" HeaderText="NRIC" />
                        <asp:BoundField AccessibleHeaderText="Ward" DataField="WardNo" HeaderText="Ward" />
                        <asp:BoundField AccessibleHeaderText="Medication" DataField="Medication" HeaderText="Medication" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <div>
        <table style="width:100%;">
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>           
    </div>

</asp:Content>
