<%@ Page Title="" Language="C#" MasterPageFile="~/EadTeam.Master" AutoEventWireup="true" CodeBehind="View_Daily_Survey.aspx.cs" Inherits="EAD_Project.View_Daily_Survey" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Css/View_Daily_Survey.css" rel="stylesheet" />
    <asp:label id="Label2" runat="server" text="Remote Moitoring System" font-bold="True" font-size="X-Large" font-underline="True"></asp:label>
    
    <div class="title">
        <asp:Label ID="Label1" runat="server" Text="View Daily Survey" Font-Bold="True" Font-Size="Large" Font-Underline="True"></asp:Label>
        <br />
    </div>

    <div id="content">

        <table>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="ID: "></asp:Label>
                        <asp:TextBox ID="tbName" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Name: "></asp:Label>
                        <asp:TextBox ID="tbAge" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label12" runat="server" Text="Blood Pressure: "></asp:Label>
                        <asp:TextBox ID="tbPressure" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label25" runat="server" Text="Heart Pulse: "></asp:Label>
                        <asp:TextBox ID="tbPulse0" runat="server"></asp:TextBox>
                        <asp:Label ID="Label26" runat="server" Text="/ Min"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label13" runat="server" Text="Tempreture: "></asp:Label>
                        <asp:TextBox ID="tbTempreture" runat="server" Width="56px"></asp:TextBox>
                        <asp:Label ID="Label14" runat="server" Text=" °c"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label27" runat="server" Text="Test: "></asp:Label>
                        <asp:CheckBoxList ID="CheckBoxList2" runat="server" AutoPostBack="True" RepeatColumns="4" Width="343px">
                            <asp:ListItem>Blood</asp:ListItem>
                            <asp:ListItem>Urine</asp:ListItem>
                            <asp:ListItem>CT Scan</asp:ListItem>
                            <asp:ListItem>Allergy</asp:ListItem>
                            <asp:ListItem>X-Ray</asp:ListItem>
                            <asp:ListItem>ECG</asp:ListItem>
                            <asp:ListItem>MRI</asp:ListItem>
                            <asp:ListItem>Stool</asp:ListItem>
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label28" runat="server" Text="Symtoms: "></asp:Label>
                        <br />
                        <textarea id="TextArea5" name="S5" cols="20" rows="1"></textarea></td>
                    <td>
                        <asp:Label ID="Label29" runat="server" Text="Chronic: "></asp:Label>
                        <br />
                        <textarea id="TextArea6" name="S6" cols="20" rows="1"></textarea></td>
                    <td>
                        <asp:Label ID="Label30" runat="server" Text="Drugs: "></asp:Label>
                        <br />
                        <textarea id="TextArea7" name="S7" cols="20" rows="1"></textarea></td>
                </tr>
                <tr>
                    <td>
                        
                        <asp:Label ID="Label31" runat="server" Text="Notes: " CssClass="NotesLabel"></asp:Label>
                        
                    </td>
                    <td>
                        <textarea id="TextArea8" name="S8" cols="20" rows="1"></textarea></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label19" runat="server" Text="Condition (1-10): "></asp:Label>
                        <asp:DropDownList ID="DDLid3" runat="server" AutoPostBack="True">
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label ID="Label20" runat="server" Text="Medication Effectiveness (1-10):"></asp:Label>
                        <asp:DropDownList ID="DDLid4" runat="server" AutoPostBack="True">
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label21" runat="server" Text="Appetite (1-10): "></asp:Label>
                        <asp:DropDownList ID="DDLid5" runat="server" AutoPostBack="True">
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label ID="Label22" runat="server" Text="Any new symptoms/ Condition: "></asp:Label>
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem>Yes</asp:ListItem>
                            <asp:ListItem>No</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td>
                        
                        <asp:Label ID="Label23" runat="server" Text="Patient's Notes: " CssClass="NotesLabel"></asp:Label>
                        
                        <br />
                    </td>
                    <td>
                        <textarea id="TextArea1" name="S1" class="auto-style1" cols="20" rows="1"></textarea><br />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="Button4" runat="server" Text="Exit" />
                    </td>
                </tr>
            </table>

        </div>

</asp:Content>
