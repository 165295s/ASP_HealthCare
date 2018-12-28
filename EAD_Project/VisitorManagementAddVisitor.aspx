<%@ Page Title="" Language="C#" MasterPageFile="~/EadTeam.Master" AutoEventWireup="true" CodeBehind="VisitorManagementAddVisitor.aspx.cs" Inherits="EAD_Project.VisitorManagement_AddVisitor_" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Css/VisitorAdmin.css" rel="stylesheet" />
    <div class="title">
        <asp:Label ID="lblTitle" runat="server" Text="Patient Visit Check In" Font-Bold="true" Font-Size="XX-Large" Font-Underline="true"></asp:Label>
        <br />
        <asp:Label ID="lblEnterDetails" runat="server" Text="Enter Patient Details" Font-Size="X-Large" Font-Underline="true"></asp:Label>
    </div>
    <table class="PatientDetails">
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblPatientNRIC" runat="server" Text="Patient's NRIC: " Font-Size="Large" CssClass="Patientlbl"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbPatientNRIC" runat="server" Font-Size="Large" CssClass="Corners"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="PatientNRICRequiredFieldValidator" runat="server" ControlToValidate="tbPatientNRIC" ErrorMessage="Please enter patient's NRIC" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblPatientName" runat="server" Text="Patient's Name: " Font-Size="Large" CssClass="Patientlbl"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbPatientName" runat="server" Font-Size="Large" CssClass="Corners"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="PatientNameRequiredFieldValidator" runat="server" ErrorMessage="Please enter patient's name" ForeColor="Red" ControlToValidate="tbPatientName">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
                    <asp:Label ID="lblError" runat="server" ForeColor="Red" Text="*Patient NRIC and Name does not match" Visible="false"></asp:Label>
                    <br />
                    <br />
                    <asp:Button ID="btnCfmPatient" runat="server" Text="Confirm Patient" CssClass="btn btn-primary" OnClick="btnCfmPatient_Click"/>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    <div class="labelMsg">
         <asp:Label ID="lblMaxReached" runat="server" Text="There are currently more than 4 visitors visiting the patient" Font-Size="Large" Visible="false"></asp:Label>
    </div>
</asp:Content>
