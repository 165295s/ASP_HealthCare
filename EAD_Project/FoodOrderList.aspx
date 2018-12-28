<%@ Page Title="" Language="C#" MasterPageFile="~/EadTeam.Master" AutoEventWireup="true" CodeBehind="FoodOrderList.aspx.cs" Inherits="EAD_Project.FoodOrderList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            margin-left: 0px;
        }
        .auto-style3 {
            width: 554px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Css/FoodOrderList.css" rel="stylesheet" />
    <div id ="title">

        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" Text="Food Orders"></asp:Label>

    </div>
    <div>

        <table class="auto-style1">
            <tr>
                <td id ="FoodOrderTable">
                    <asp:GridView ID="FoodOrderView" runat="server" ondatabound="gv_DataBound" AutoGenerateColumns="False" Width="1133px" >
                        <Columns>
                            <asp:BoundField AccessibleHeaderText="NRIC" DataField="NRIC" HeaderText="NRIC" />
                            <asp:BoundField AccessibleHeaderText="Patient Name" DataField="Name" HeaderText="Patient Name" />
                            <asp:BoundField AccessibleHeaderText="Ward Number" DataField="WardNo" HeaderText="Ward Number" />
                            <asp:BoundField AccessibleHeaderText="Meal" DataField="Meal" HeaderText="Meal" />
                            <asp:BoundField AccessibleHeaderText="Date" DataField="Date" HeaderText="Date" />
                            <asp:BoundField AccessibleHeaderText="Main Dish" DataField="Main" HeaderText="Main Dish" />
                            <asp:BoundField AccessibleHeaderText="Meat Dish" DataField="Meat" HeaderText="Meat Dish" />
                            <asp:BoundField AccessibleHeaderText="Fruit" DataField="Fruit" HeaderText="Fruit" />
                            <asp:BoundField AccessibleHeaderText="Vegetable" DataField="Vegetable" HeaderText="Vegetable" />
                            <asp:BoundField AccessibleHeaderText="Side Dish" DataField="Side" HeaderText="Side Dish" />
                            <asp:BoundField AccessibleHeaderText="Drink" DataField="Drink" HeaderText="Drink" />
                            <asp:BoundField AccessibleHeaderText="Request" DataField="Request" HeaderText="Request" />
                            <asp:templatefield HeaderText="Done">
                              <itemtemplate>
                                <asp:checkbox ID="checkboxSelect"
                                         runat="server"></asp:checkbox>
                               </itemtemplate>
                              </asp:templatefield>
                        </Columns>
                    </asp:GridView>
                    <table class="auto-style1">
                        <tr>
                            <td class="auto-style3">&nbsp;</td>
                            <td>
                                <asp:Button ID="ClearButton" runat="server" CssClass="auto-style2" OnClick="ClearButton_Click" Text="Clear Food Order List" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>

    </div>
</asp:Content>
