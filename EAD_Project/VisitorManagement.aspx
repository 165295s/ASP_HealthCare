<%@ Page Title="" Language="C#" MasterPageFile="~/EadTeam.Master" AutoEventWireup="true" CodeBehind="VisitorManagement.aspx.cs" Inherits="EAD_Project.VisitorManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type ="text/javascript">
        $(document).ready(
            window.setInterval(function () {
                BindGridView();
            }, 1000)
        );

        function BindGridView() {
            $.ajax({
                type: "POST",
                url: "VisitorManagementService.asmx/getAllVisitors",
                contentType: "application/json;charset=utf-8",
                data: JSON.stringify({ PatientNRIC: $("#<%=lblPatientNRICDetails.ClientID%>").text() }),
                dataType: "json",
                async: true,
                success: function (data) {
                    var GridView1 = $("#<%=PatientVisitGridView.ClientID%>");
                    GridView1.empty();
                    if ($("#<%=lblPatientNRICDetails.ClientID%>").text() != ""){
                        $("#<%=lblNoVisitors.ClientID%>").html("There are no visitors visiting currently");
                    }
                    

                    if (data.d.length > 0) {
                        GridView1.append("<tr> <th>Name</th> <th>Arrival Time</th> <th>Stay Duration</th>");
                        $("#<%=lblNoVisitors.ClientID%>").html("");
                        for (var i = 0; i < data.d.length; i++) {

                            var date = new Date(parseInt(data.d[i].ArrivalTime.substr(6)));

                            GridView1.append("<tr><td>" + data.d[i].VisitorName
                                + "</td><td>" + date.toLocaleString()
                                + "</td><td>" + data.d[i].StayDuration + "</td></tr>");
                        }

                            

                    } 
                    
                },
                error: function () {
                    return false;
                }
            });
        }
    </script>
    <link href="Css/VisitorManagementStyle.css" rel="stylesheet" />
    <div class="Title">
        <asp:Label ID="lblTitle" runat="server" Text="Visitor Mangement System" Font-Bold="true" Font-Size="XX-Large" Font-Underline="true"></asp:Label>
        <br />
        <asp:Label ID="lblEnterDetails" runat="server" Text="Enter Patient Details" Font-Size="X-Large" Font-Underline="true"></asp:Label>
    </div>
    <div class="Contents">
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
        </table>
        <br />
        <br />
        <div class="VisitorDetails">
        <asp:Panel ID="PanelVisitorDetails" runat="server" CssClass="panel panel-info">
            <div class="panel-heading"><asp:Label ID="lblVisitorsVisiting" runat="server" Text="Visitor Details" Font-Size="X-Large" Font-Underline="true"></asp:Label></div>
            <div class="panel-body">
                <table>
                    <tr>
                        <td><asp:Label ID="lblPatientNRIC1" runat="server" Text="Patient NRIC: " Font-Size="Small" CssClass="Patientlbl" Visible ="false"></asp:Label></td>
                        <td><asp:Label ID="lblPatientNRICDetails" runat="server" Font-Size="Small" Visible="false"></asp:Label></td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lblPatientName1" runat="server" Text="Patient Name: " Font-Size="Small" CssClass="Patientlbl" Visible ="false"></asp:Label></td>
                        <td><asp:Label ID="lblPatientNameDetails" runat="server" Font-Size="Small" Visible ="false"></asp:Label></td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
                <asp:Label ID="lblNoVisitors" runat="server" Font-Size="Large"></asp:Label>
                <asp:GridView ID="PatientVisitGridView" runat="server" AutoGenerateColumns="False" CssClass=" table table-striped">
                    <Columns>
                        <asp:BoundField DataField="VisitorName" HeaderText="Name" />
                        <asp:BoundField DataField="ArrivalTime" HeaderText="Arrival Time" />
                        <asp:BoundField DataField="StayDuration" HeaderText="Stay Duration" SortExpression="StayDuration" />
                    </Columns>
                </asp:GridView>
            </div>
            <div class="panel-footer">
                <asp:Label ID="lblMaxVisitors" runat="server" Text="Maximum number of visitors allowed: 4" Font-Size="X-Large"></asp:Label>
            </div>
        </asp:Panel>
        </div>
    </div>
</asp:Content>
