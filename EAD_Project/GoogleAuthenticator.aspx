<%@ Page Title="" Language="C#" MasterPageFile="~/EadTeam.Master" AutoEventWireup="true" CodeBehind="GoogleAuthenticator.aspx.cs" Inherits="EAD_Project.GoogleAuthenticator" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!DOCTYPE html>

<html>
    <title></title>
</head>
<body>
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <meta charset="utf-8" />
    <title>Login Page - Ace Admin</title>

    <meta name="description" content="User login page" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0" />

    <!-- bootstrap & fontawesome -->
    <link rel="stylesheet" href="assets/css/bootstrap.min.css" />
    <link rel="stylesheet" href="assets/font-awesome/4.5.0/css/font-awesome.min.css" />

    <!-- text fonts -->
    <link rel="stylesheet" href="assets/css/fonts.googleapis.com.css" />

    <!-- ace styles -->
    <link rel="stylesheet" href="assets/css/ace.min.css" />

    <!--[if lte IE 9]><a href="GoogleAuthenticator.aspx">GoogleAuthenticator.aspx</a>
			<link rel="stylesheet" href="assets/css/ace-part2.min.css" />
		<![endif]-->
    <link rel="stylesheet" href="assets/css/ace-rtl.min.css" />

    <!--[if lte IE 9]>
		  <link rel="stylesheet" href="assets/css/ace-ie.min.css" />
		<![endif]-->

    <!-- HTML5shiv and Respond.js for IE8 to support HTML5 elements and media queries -->

    <!--[if lte IE 8]>
		<script src="assets/js/html5shiv.min.js"></script>
		<script src="assets/js/respond.min.js"></script>
		<![endif]-->

</head>
  
<body>
           <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
        <%-- <Scripts>
            <asp:ScriptReference Path="assets/js/Validation.js" />
        </Scripts>--%>
    </asp:ScriptManager>
        <div>
            <div class="main-container">
                <div class="main-content">
                    <div class="row">
                        <div class="col-sm-10 col-sm-offset-1">
                            <div class="login-container">
                                <div class="center">
                                    <h1>
                                        <i class="ace-icon fa fa-leaf green"></i>
                                        <span class="red">BayHealth</span>
                                        <span class="white" id="id-text2">Payment</span>
                                    </h1>
                                   <%-- <h4 class="blue" id="id-company-text">&copy; Company Name</h4>--%>
                                </div>

                                <div class="space-6"></div>

                                <div class="position-relative">
                                    <div id="login-box" class="login-box visible widget-box no-border">
                                        <div class="widget-body">
                                            <div class="widget-main">
                                                <h4 class="header blue lighter bigger">
                                                    <i class="fa fa-google" style="font-size:20px"></i>
                                                    Please use your google authenticator here
                                                </h4>

                                                <div class="space-6"></div>

                                                <form>
                                                    <fieldset>
                                                        <asp:Image ID="imgQrCode" runat="server" /><br />
                                                        <label class="block clearfix">
                                                            <span class="block input-icon input-icon-right">
                                                                <asp:TextBox ID="TextBoxGooglePin" runat="server" class="form-control" placeholder="Enter Pin Here" style="margin-top:5%;" autocomplete="off"></asp:TextBox>
                                                                <i class="ace-icon fa fa-lock"></i>
                                                            </span>
                                                        </label>
                                                                      <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" display="dynamic" ErrorMessage="Please enter a valid pin *" ControlToValidate="TextBoxGooglePin" ValidationExpression= "^[0-9]{6}$" validationgroup="GoogleAuthenticate" ForeColor="Red"/>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" validationgroup="GoogleAuthenticate" ForeColor="Red" runat="server" ErrorMessage="Required *" ControlToValidate="TextBoxGooglePin"></asp:RequiredFieldValidator>
                                                        <br /><asp:Label runat="server" Font-Bold="true" ID="lblValidationResult"></asp:Label>
                                             <%--           <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
<ContentTemplate>--%>
                                                        <div class="clearfix">
                                                            <%--<button type="button" class="width-35 pull-right btn btn-sm btn-primary">
															<i class="ace-icon fa fa-key"></i>
															<span class="bigger-110">Login</span>
														</button>--%>
                                                        </div>
<%--    </ContentTemplate>
</asp:UpdatePanel>--%>
                                                        <div class="space-4">
                                                            <asp:LinkButton ID="ButtonValidate" runat="server" class="width-35 pull-right btn btn-sm btn-primary" validationgroup="GoogleAuthenticate" OnClick="ButtonValidate_Click">
                                                          <i class="ace-icon fa fa-key"></i>
															<span class="bigger-110">Validate</span>
                                                            </asp:LinkButton>
                                                            </div>
                                                    </fieldset>
                                                </form>

                                            </div>
                                          
                                            </div>
                                        </div>
                                        <!-- /.widget-body -->
                                    </div>
                                    <!-- /.login-box -->
                                <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>
    </form>
</body>
</html>
    </div>

    </div>


</asp:Content>
