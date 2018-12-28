<%@ Page Title="" Language="C#" MasterPageFile="~/EadTeam.Master" AutoEventWireup="true" CodeBehind="QueueCheck.aspx.cs" Inherits="EAD_Project.QueueCheck" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Css/QueueCheckStyle.css" rel="stylesheet" />
    <script src="Scripts/jquery-2.2.4.js"></script>
    <script type = "text/javascript">
       $(document).ready(
               window.setInterval(function () {
                   BindGridViewQList();
               }, 1000)
           );

        function BindGridViewQList() {
            $.ajax({
                type: "POST",
                url: "QueueService.asmx/retriveQDetailsByUserName",
                contentType: "application/json;charset=utf-8",
                data: JSON.stringify({ UserName: $("#<%=lblHiddenUser.ClientID%>").text() }),
                dataType: "json",
                async: true,
                success: function (data) {
                    var TextBoxQueueNo = $("#<%=tbQueueNo.ClientID%>");
                    var TextBoxNumBefore = $("#<%=tbNumBefore.ClientID%>");
                    var LabelDirection = $("#<%=lblDirection.ClientID%>");
                    var LabelCounter = $("#<%=lblCounter.ClientID%>");
                    var ButtonQueueNum = $("<%=btnTakeQueue.ClientID%>");

                    TextBoxQueueNo.val(data.d.QueueNum);
                    TextBoxNumBefore.val(data.d.pplInQueue);

                    if (TextBoxQueueNo.val() == 0 && data.d.CounterNum == 0) {
                        document.getElementById("<%=btnTakeQueue.ClientID%>").disabled = false;
                        document.getElementById("<%=btnLeaveQueue.ClientID%>").disabled = true;
                    }

                    if (data.d.WaitingTime > 0) {
                        var hours = (data.d.WaitingTime / 60);
                        var rhours = Math.floor(hours);
                        var minutes = (hours - rhours) * 60;
                        var rminutes = Math.round(minutes);
                        LabelDirection.html("You have to wait for " + rhours + "hours " + rminutes + "mins");
                    } else if (data.d.WaitingTime <= 0 && data.d.QueueNum > 0){
                        LabelDirection.html("Please make your way down to BayHealth Hospital");
                    } else {
                        LabelDirection.html("");
                    }

                    if (data.d.CounterNum != 0) {
                        LabelCounter.html("It is your turn, please go to counter " + data.d.CounterNum);
                    } else {
                        LabelCounter.html("");
                    }

                },
                error: function () {
                    return false;
                }
            });
        }
    </script>
    <div class="main">
        <asp:Label ID="LblTitle" runat="server" Text="Queue Check" Font-Size="XX-Large" Font-Bold="true" Font-Underline="true"></asp:Label><br/>
        <asp:Button ID="btnTakeQueue" Class="BtnQueueNumber Corners" runat="server" Text="Take Q Number" Font-Size="X-Large" OnClick="btnTakeQueue_Click" /><br /><br />
        <asp:Button ID="btnLeaveQueue" Class="BtnQueueNumber Corners" runat="server" Text="&nbsp;&nbsp;Leave Queue&nbsp;&nbsp;" Font-Size="X-Large" OnClick="btnLeaveQueue_Click"/>
        <br />
        <br />
        <asp:Label ID="lblDirection" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Blue"></asp:Label>
        <br />
        <asp:Label ID="lblCounter" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="DarkBlue"></asp:Label>
        <div class="QueueStatus">
            <table  style="width: 100%;">
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblNumBefore" runat="server" Text="People before you: " Font-Bold="true" Font-Size="Large"></asp:Label></td>
                    <td><asp:TextBox ID="tbNumBefore" CssClass="Corners tb" runat="server" Font-Size="Large" Enabled="false"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr class="QueueNumber">
                     <td><br/><asp:Label ID="lblQueueNo" runat="server" Text="Queue Number: " Font-Bold="true" Font-Size="Large"></asp:Label>
                         <br />
                         <br/></td>
                     <td><asp:TextBox ID="tbQueueNo" CssClass="Corners tb" runat="server" Font-Size="Large" Enabled="false"></asp:TextBox></td>
                </tr>
            </table>
        </div>
        <br />
        <br />
        &nbsp;<asp:Label ID="lblHiddenUser" runat="server"></asp:Label>
    </div>
</asp:Content>
