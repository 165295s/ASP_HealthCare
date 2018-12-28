<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CaptureBarcodePatientVisitDeparture.aspx.cs" Inherits="EAD_Project.CaptureBarcodePatientVisitDeparture" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Contents/bootstrap.css" rel="stylesheet" />
    <link href="Contents/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-2.2.4.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Css/CaptureBarcodeStyle.css" rel="stylesheet" />
</head>
<body>
    <div class="Contents">
        <asp:Label ID="lblTitle" runat="server" Text="Patient Visit Check Out" Font-Underline="true" Font-Bold="true" Font-Size="XX-Large"></asp:Label>
        <div class="panel panel-success">

            <div class="panel-heading">
                <asp:Label ID="lblScanNRIC" runat="server" Text="Scan your IC card" Font-Size="XX-Large"></asp:Label>
            </div>

            <div class="panel-body">
                <video style="width:100%;height:100%;"></video>
                <canvas id="pcCanvas" width="640" height="480" style="display: none; float: left;"></canvas>
                <div>
                    <div id="dbr"></div>
                </div>
            </div>

            <div class="panel-footer">
                <button id="Depart" style="margin-bottom: 12.5px; height: 50px; width: 259px;" class="btn btn-success">Scan</button>
            </div>

        </div>

        <script type="text/javascript" src="scripts/cust/Dynamsoft.BarcodeReaderDemo.js"></script>
        <script src="scripts/cust/video2.js" type="text/javascript"></script>
    </div>
</body>
</html>
