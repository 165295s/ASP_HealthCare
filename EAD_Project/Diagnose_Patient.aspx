<%@ Page Title="" Language="C#" MasterPageFile="~/EadTeam.Master" AutoEventWireup="true" CodeBehind="Diagnose_Patient.aspx.cs" Inherits="EAD_Project.Diagnose_Patient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Css/Diagnose_patient.css" rel="stylesheet" />
    <asp:Label ID="Label2" runat="server" Text="Diagnose Patient" Font-Bold="True" Font-Size="X-Large" Font-Underline="True"></asp:Label>
    
    <div class="title">
        <asp:Label ID="Label1" runat="server" Text="Patient Information" Font-Bold="True" Font-Size="Large" Font-Underline="True"></asp:Label>
        <br />
    </div>
    
    <div class="content">

             <table>
                <tr>
                    <td colspan="3"> 
                        <br />
                        <asp:Label ID="Label3" runat="server" Text="ID: "></asp:Label>
                        <asp:DropDownList ID="ddlID" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLid_SelectedIndexChanged">
                            <asp:ListItem>--Select--</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField DataField="PatientNRIC" HeaderText="NRIC" />
                                <asp:BoundField DataField="Name" HeaderText="Name" />
                                <asp:BoundField DataField="Age" HeaderText="Age" />
                                <asp:BoundField DataField="Gender" HeaderText="Gender" />
                                <asp:BoundField DataField="MobileNo" HeaderText="Mobile" />
                                <asp:BoundField DataField="Email" HeaderText="E-Mail" />
                                <asp:BoundField DataField="HeartPulse" HeaderText="Heart Pulse" />
                                <asp:BoundField DataField="BloodPressure" HeaderText="Blood Pressure" />
                                <asp:BoundField DataField="Tempreture" HeaderText="Tempreture" />
                                <asp:BoundField DataField="Test" HeaderText="Test" />
                                <asp:BoundField DataField="Symtoms" HeaderText="Symptoms" />
                                <asp:BoundField DataField="Chronic" HeaderText="Chronic" />
                                <asp:BoundField DataField="Drugs" HeaderText="Drugs" />
                                <asp:BoundField DataField="Notes" HeaderText="Notes" />
                                <asp:BoundField DataField="Diagnose_date" HeaderText="Diagnose Date" />
                                <asp:CommandField InsertVisible="False" ShowCancelButton="False" ShowSelectButton="True" />
                                
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button ID="btnGridViewDelete" runat="server" Text="Delete" OnClick="btnGridViewDelete_Click" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                            </Columns>
                        </asp:GridView>
                        
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Name: "></asp:Label>
                        <asp:TextBox ID="tbName" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Age: "></asp:Label>
                        <asp:TextBox ID="tbAge" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="Gender: "></asp:Label>
                        <asp:TextBox ID="tbGender" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label7" runat="server" Text="Mobile: "></asp:Label>
                        <asp:TextBox ID="tbMobile" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label8" runat="server" Text="E-Mail: "></asp:Label>
                        <asp:TextBox ID="tbEmail" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label10" runat="server" Text="Heart Pulse: "></asp:Label>
                        <asp:TextBox ID="tbPulse" runat="server"></asp:TextBox>
                        <asp:Label ID="Label11" runat="server" Text="/ Min"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;<asp:Label ID="Label9" runat="server" Text="Blood Pressure: "></asp:Label>
                        <asp:TextBox ID="tbPressure" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label12" runat="server" Text="Tempreture: "></asp:Label>
                        <asp:TextBox ID="tbTempreture" runat="server" Width="56px"></asp:TextBox>
                        <asp:Label ID="Label13" runat="server" Text=" °c"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label14" runat="server" Text="Test: "></asp:Label>
                        <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatColumns="4" Width="343px">
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
                        <asp:Label ID="Label15" runat="server" Text="Symptoms: "></asp:Label>
                        <br />
                        <asp:DropDownList ID="ddlSymptoms" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSymtoms_SelectedIndexChanged">
                            <asp:ListItem>--Select--</asp:ListItem>
                            <asp:ListItem>Cough</asp:ListItem>
                            <asp:ListItem>Runny Nose</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label ID="Label16" runat="server" Text="Chronic: "></asp:Label>
                        <br />
                        <asp:DropDownList ID="ddlChronic" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlChronic_SelectedIndexChanged">
                            <asp:ListItem>--Select--</asp:ListItem>
                            <asp:ListItem>Heart Failure</asp:ListItem>
                            <asp:ListItem>Arthritis</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label ID="Label17" runat="server" Text="Drugs: "></asp:Label>
                        <br />
                        <asp:DropDownList ID="ddlDrugs" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDrugs_SelectedIndexChanged" Height="16px">
                            <asp:ListItem>--Select--</asp:ListItem>
                            <asp:ListItem>Humibid</asp:ListItem>
                            <asp:ListItem>Aspirin</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="tbSymtoms" runat="server" TextMode="MultiLine"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="tbChronic" runat="server" TextMode="MultiLine"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="tbDrugs" runat="server" TextMode="MultiLine"></asp:TextBox></td>
                </tr>

                <tr>
                    <td>
                        
                        <asp:Label ID="Label18" runat="server" Text="Notes: " CssClass="NotesLabel"></asp:Label>
                        
                    </td>
                    <td>
                        <asp:TextBox ID="tbNotes" runat="server" TextMode="MultiLine"></asp:TextBox></td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Button ID="btnInsert" runat="server" Text="Insert" OnClick="BtnInsert" />
                        <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete" />
                    </td>
                </tr>
            </table>
           
        </div>
</asp:Content>
