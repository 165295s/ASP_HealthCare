<%@ Page Title="" Language="C#" MasterPageFile="~/EadTeam.Master" AutoEventWireup="true" CodeBehind="Take_Daily_Survey.aspx.cs" Inherits="EAD_Project.Take_Daily_Survey" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Css/Take_Daily_Survey.css" rel="stylesheet" />

    <asp:Label ID="Label2" runat="server" Text="Daily Updates" Font-Bold="True" Font-Size="X-Large" Font-Underline="True"></asp:Label>
    
    <div class="title">
        <asp:Label ID="Label1" runat="server" Text="Take Daily Survey" Font-Bold="True" Font-Size="Large" Font-Underline="True"></asp:Label>
        <br />
    </div>

    <div class="content">
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
                        
                        <asp:Label ID="Label23" runat="server" Text="Notes: " CssClass="NotesLabel"></asp:Label>
                        
                        <br />
                    </td>
                    <td>
                        <textarea id="TextArea1" name="S1" class="auto-style1" cols="20" rows="1"></textarea><br />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="Button3" runat="server" Text="Clear" />
                        <asp:Button ID="Button4" runat="server" Text="Submit" />
                    </td>
                </tr>
            </table>
        </div>



</asp:Content>
