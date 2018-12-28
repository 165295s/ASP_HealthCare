<%@ Page Title="" Language="C#" MasterPageFile="~/EadTeam.Master" AutoEventWireup="true" CodeBehind="QueueAdministration.aspx.cs" Inherits="EAD_Project.QueueAdministration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Css/QueueAdminStyle.css" rel="stylesheet" />
    <script src="Scripts/jquery-2.2.4.js"></script>
    <script type="text/javascript">
        $(document).ready(
            
            window.setInterval(function () {
                if ($("#<%=tbInputNRIC.ClientID%>").html() != "") {
                    BindGridViewHoldList();
                }
            }, 1000),
            

            window.setInterval(function () {
                BindGridViewQList();
            }, 1000),

            window.setInterval(function () {
                BindGridViewHoldSearch();
            }, 1000)
        );

        function BindGridViewQList() {
            $.ajax({
                type: "POST",
                url: "QueueService.asmx/getAllUserInQ",
                contentType: "application/json;charset=utf-8",
                data: {},
                dataType: "json",
                async: true,
                success: function (data) {
                    var GridView1 = $("#<%=QListGridView.ClientID%>");
                    GridView1.empty();

                    var body = '';

                    if (data.d.length > 0) {
                        GridView1.append("<tr> <th>NRIC</th> <th>Name</th> <th>Queue Number</th> <th>TimeStamp</th></tr>");
                        for (var i = 0; i < data.d.length; i++) {

                            var date = new Date(parseInt(data.d[i].TimeStamp.substr(6)));

                            GridView1.append("<tr><td>" + data.d[i].VisitorNRIC
                                + "</td><td>" + data.d[i].VisitorName
                                + "</td><td>" + data.d[i].QueueNum
                                + "</td><td>" + date.toLocaleString() + "</td></tr>");

                        }
                    }

                },
                error: function () {
                    return false;
                }
            });
        }

        function BindGridViewHoldSearch() {
            $.ajax({
                type: "POST",
                url: "QueueService.asmx/getQHoldSearch",
                contentType: "application/json;charset=utf-8",
                data: JSON.stringify({ visitorNRIC: $("#<%=tbInputNRIC.ClientID%>").val() }),
                dataType: "json",
                async: true,
                success: function (data) {
                    var GridView2 = $("#<%=OnHoldGridView.ClientID%>");
                    GridView2.empty();
                    if (data.d.length > 0) {
                        GridView2.append("<tr> <th>NRIC</th> <th>Name</th> <th>Queue Number</th> <th>TimeStamp</th></tr>");
                        for (var i = 0; i < data.d.length; i++) {

                            var date = new Date(parseInt(data.d[i].TimeStamp.substr(6)));

                            GridView2.append("<tr><td>" + data.d[i].VisitorNRIC
                                + "</td><td>" + data.d[i].VisitorName
                                + "</td><td>" + data.d[i].QueueNum
                                + "</td><td>" + date.toLocaleString() + "</td></tr>");
                        }
                    }

                },
                error: function () {
                    return false;
                }
            });
        }

        function BindGridViewHoldList() {
            $.ajax({
                type: "POST",
                url: "QueueService.asmx/getQHold",
                contentType: "application/json;charset=utf-8",
                data: {},
                dataType: "json",
                async: true,
                success: function (data) {
                    var GridView2 = $("#<%=OnHoldGridView.ClientID%>");
                    GridView2.empty();
                    if (data.d.length > 0) {
                        GridView2.append("<tr> <th>NRIC</th> <th>Name</th> <th>Queue Number</th> <th>TimeStamp</th></tr>");
                        for (var i = 0; i < data.d.length; i++) {

                            var date = new Date(parseInt(data.d[i].TimeStamp.substr(6)));

                            GridView2.append("<tr><td>" + data.d[i].VisitorNRIC
                                + "</td><td>" + data.d[i].VisitorName
                                + "</td><td>" + data.d[i].QueueNum
                                + "</td><td>" + date.toLocaleString() + "</td></tr>");
                        }
                    }

                },
                error: function () {
                    return false;
                }
            });
        }

    </script>
    <div class="Contents">
        <asp:Label ID="lblTitle" runat="server" Text="Queue Administration" Font-Bold="true" Font-Underline="true" Font-Size="XX-Large"></asp:Label>
        <br />
        <br />
        <div class="container">
            <div class="panel panel-info">
                <div class="panel-heading"><asp:Label ID="lblCounter" runat="server" Font-Bold="true" Font-Underline="true" Font-Size="X-Large"></asp:Label></div>
                <div class="panel-body">
                    <asp:Label ID="lblCurrentlyServed" runat="server" Text="Currently Served" Font-Size="X-Large" Font-Bold="true"></asp:Label>
                    <br />
                    <br />
                    <asp:GridView ID="CurrentlyServedGridView" AutoGenerateColumns="false" runat="server" CssClass="table table-striped">
                        <Columns>
                            <asp:BoundField DataField="VisitorNRIC" HeaderText="NRIC" />
                            <asp:BoundField DataField="VisitorName" HeaderText="Name" />
                            <asp:BoundField DataField="QueueNum" HeaderText="Queue Number" />
                            <asp:BoundField DataField="TimeStamp" HeaderText="TimeStamp" />
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="panel-footer">
                    <asp:Button ID="btnNext" CssClass="btn btn-primary btn-lg" runat="server" Text="Next" Width="176px" OnClick="btnNext_Click"/>
                    <br />
                    <br />
                    <asp:Button ID="btnHold" CssClass="btn btn-warning btn-lg" runat="server" Text="Put On Hold" Width="176px" OnClick="btnHold_Click"/>
                </div>
            </div>
            <asp:Label ID="lblQueueDetails" runat="server" Text="Queue Details" Font-Underline="true" Font-Size="X-Large"></asp:Label>
            <main>
                <section>
                    <ul>
                        <li>
                            <div>
                                <asp:Label ID="lblOnHold" runat="server" Text="On Hold" Font-Bold="true" Font-Underline="true" Font-Size="Large"></asp:Label>
                                <br />
                                <asp:Label ID="lblNRIC" runat="server" Text="NRIC: " Font-Size="Large"></asp:Label>
                                <asp:TextBox ID="tbInputNRIC" placeholder="Input NRIC" runat="server" Font-Size="Large"></asp:TextBox>
                                <asp:Button ID="btnServeOnHold" runat="server" Text="Serve" Font-Size="Large" OnClick="btnServeOnHold_Click"/>
                                <br />
                                <asp:Label ID="lblOnHoldExists" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                                <br />
                                <br />
                                <asp:GridView ID="OnHoldGridView" AutoGenerateColumns="False" runat="server" CssClass="table table-striped" OnSelectedIndexChanged="OnHoldGridView_SelectedIndexChanged" ClientIDMode="Static">
                                <Columns>
                                    <asp:BoundField DataField="VisitorNRIC" HeaderText="NRIC" />
                                    <asp:BoundField DataField="VisitorName" HeaderText="Name" />
                                    <asp:BoundField DataField="QueueNum" HeaderText="Queue Number" />
                                    <asp:BoundField DataField="TimeStamp" HeaderText="TimeStamp" />
                                    <asp:CommandField ShowSelectButton="True" />
                                    
                                </Columns>
                            </asp:GridView>
                            </div>
                        </li>
                        <li>
                            <div>
                                <asp:Label ID="lblQList" runat="server" Text="Queue List" Font-Bold="true" Font-Underline="true" Font-Size="Large"></asp:Label>
                                 <asp:GridView ID="QListGridView" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
                                    <Columns>
                                        <asp:BoundField DataField="VisitorNRIC" HeaderText="NRIC" />
                                        <asp:BoundField DataField="VisitorName" HeaderText="Name" />
                                        <asp:BoundField DataField="QueueNum" HeaderText="Queue Number" />
                                        <asp:BoundField DataField="TimeStamp" HeaderText="TimeStamp" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                            
                        </li>
                    </ul>
                </section>
            </main>
        </div>
    </div>
</asp:Content>
