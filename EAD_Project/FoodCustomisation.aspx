<%@ Page Title="" Language="C#" MasterPageFile="~/EadTeam.Master" AutoEventWireup="true" CodeBehind="FoodCustomisation.aspx.cs" Inherits="EAD_Project.FoodCustomisation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        

    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style10 {
            width: 129px;
        }
        .auto-style11 {
            width: 131px;
        }
        .auto-style12 {
            height: 40px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Css/FoodCustomisation.css" rel="stylesheet" />

    <div id="title" >
        
        <asp:Label ID="Label20" runat="server" class="label20" Text="Food Customisation System" Font-Bold="True" Font-Size="Large"></asp:Label>
        
    </div>
    <div>

        <asp:Panel ID="Panel1" runat="server">
            <asp:Label ID="Label2" runat="server" Text="Patient Details" Font-Bold="True" Font-Size="Medium"></asp:Label>
            <br />
            <table class="auto-style1">
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="*NRIC:"></asp:Label>
                        <asp:TextBox ID="NRICBox" runat="server"></asp:TextBox>
                        <asp:Button ID="EnterButton" runat="server" OnClick="EnterButton_Click" Text="Enter" />
                        <asp:Label ID="ErrorLabelNRIC" runat="server" Font-Size="X-Small" ForeColor="Red"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="Condition:"></asp:Label>
                        <asp:TextBox ID="ConditionBox" runat="server" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style12">
                        <asp:Label ID="Label4" runat="server" Text="Patient Name:"></asp:Label>
                        <asp:TextBox ID="NameBox" runat="server" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td class="auto-style12">
                        <asp:Label ID="Label26" runat="server" Text="*Meal:"></asp:Label>
                        <asp:RadioButtonList ID="FoodMealList" runat="server">
                            <asp:ListItem>Breakfast</asp:ListItem>
                            <asp:ListItem>Lunch</asp:ListItem>
                            <asp:ListItem>Dinner</asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:Label ID="ErrorLabelMeal" runat="server" Font-Size="X-Small" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Ward Number:"></asp:Label>
                        <asp:TextBox ID="WardNoBox" runat="server" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label7" runat="server" Text="Special Diet:"></asp:Label>
                        <asp:TextBox ID="DietBox" runat="server" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </asp:Panel>

    </div>
    <br />
    <div>

        <asp:Label ID="Label14" runat="server" Font-Bold="True" Font-Size="Medium" Text="Food Menu"></asp:Label>
        <asp:Label ID="ErrorLabelFood" runat="server" Font-Size="X-Small" ForeColor="Red"></asp:Label>
        <table class="auto-style1">
            <tr>
                <td class="auto-style11">
                    <asp:Label ID="Label15" runat="server" Text="*Main:"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="MainDropDownList" runat="server" Width="162px" >
                        <asp:ListItem Selected="True" Value="0">Select Main</asp:ListItem>
                        <asp:ListItem Value="Rice">Rice</asp:ListItem>
                        <asp:ListItem Value="Noodle">Noodle</asp:ListItem>
                        <asp:ListItem Value="Porridge">Porridge </asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style11">
                    <asp:Label ID="Label16" runat="server" Text="*Meat:"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="MeatDropDownList" runat="server" Width="162px">
                        <asp:ListItem Selected="True" Value="0">Select Meat</asp:ListItem>
                        <asp:ListItem Value="Chicken">Chicken</asp:ListItem>
                        <asp:ListItem Value="Fish">Fish</asp:ListItem>
                        <asp:ListItem Value="Beef">Beef</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style11">
                    <asp:Label ID="Label17" runat="server" Text="*Fruit/Vegetable:"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="FruitDropDownList" runat="server" Width="162px">
                        <asp:ListItem Selected="True" Value="0">Select Fruit</asp:ListItem>
                        <asp:ListItem Value="Apple">Apple</asp:ListItem>
                        <asp:ListItem Value="Banana">Banana</asp:ListItem>
                        <asp:ListItem Value="Grape">Grape</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <asp:DropDownList ID="VegetableDropDownList" runat="server" Width="162px">
                        <asp:ListItem Selected="True" Value="0">Select Vegetable</asp:ListItem>
                        <asp:ListItem Value="Spinach">Spinach</asp:ListItem>
                        <asp:ListItem Value="Brocoli">Brocoli</asp:ListItem>
                        <asp:ListItem Value="Cabbage">Cabbage</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style11">
                    <asp:Label ID="Label18" runat="server" Text="*Side:"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="SideDropDownList" runat="server" Width="162px">
                        <asp:ListItem Selected="True" Value="0">Select Side</asp:ListItem>
                        <asp:ListItem Value="Soup">Soup</asp:ListItem>
                        <asp:ListItem Value="Ice Cream">Ice Cream</asp:ListItem>
                        <asp:ListItem Value="Cookie">Cookie</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style11">
                    <asp:Label ID="Label19" runat="server" Text="*Drink:"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DrinkDropDownList" runat="server" Width="162px">
                        <asp:ListItem Selected="True" Value="0">Select Drink</asp:ListItem>
                        <asp:ListItem Value="Plain Water">Plain Water</asp:ListItem>
                        <asp:ListItem Value="Hot Tea">Hot Tea</asp:ListItem>
                        <asp:ListItem Value="Coke">Coke</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>

    </div>
    <div>

        <table class="auto-style1">
            <tr>
                <td class="auto-style10">
                    <asp:Label ID="Label13" runat="server" Text="Special Request:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="RequestBox" runat="server" Height="113px" Width="621px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style10">&nbsp;</td>
                <td id="RequiredLabel">
                    <asp:Label ID="Label27" runat="server" Font-Size="Small" Text="*Required to fill in"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style10">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="ResetButton" runat="server" Text="Reset Food Order" OnClick="ResetButton_Click" />
                    <asp:Button ID="SubmitButton" runat="server" Text="Submit Food Order" OnClick="SubmitButton_Click" />
                    <asp:Label ID="ErrorLabelRepeatedMeal" runat="server" Font-Size="X-Small" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>

    </div>
</asp:Content>

