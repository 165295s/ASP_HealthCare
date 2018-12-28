<%@ Page Title="" Language="C#" MasterPageFile="~/EadTeam.Master" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="EAD_Project.MainPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Css/MainPageStyle.css" rel="stylesheet" />
    <asp:Image ID="ImgMainPge" ImageUrl="~/Images/MainIMG.png" runat="server" Width="100%" />
    <div class="Role">
        <p>Who are you?</p>
        
        <main>
            <section>
                <ul>
                    <li>
                        <div>
                            <asp:Label ID="LblNurse" runat="server" Text="Nurse" ></asp:Label>
                            <asp:ImageButton ID="ImgBtnNurseLogin" runat="server" ImageUrl="~/Images/nurse.png" Height="120px" Width="128px" CssClass="ImgBtnAlign" OnClick="ImgBtnNurseLogin_Click"/>
                        </div>
                    </li>
                    <li>
                        <div>
                            <asp:Label ID="LblDoctor" runat="server" Text="Doctor"></asp:Label>
                            <asp:ImageButton ID="ImgBtnDoctorLogin" runat="server" ImageUrl="~/Images/doctor.png" Height="120px" Width="128px" CssClass="ImgBtnAlign" OnClick="ImgBtnDoctorLogin_Click"/>
                        </div>
                    </li>
                    <li>
                        <div>
                            <asp:Label ID="LblPatient" runat="server" Text="Patient" ></asp:Label>
                            <asp:ImageButton ID="ImgBtnPatientLogin" runat="server" ImageUrl="~/Images/patient.png" Height="120px" Width="128px" CssClass="ImgBtnAlign" OnClick="ImgBtnPatientLogin_Click"/>
                        </div>
                    </li>
                    <li>
                        <div>
                            <asp:Label ID="LblAdmin" runat="server" Text="Admin"></asp:Label>
                            <asp:ImageButton ID="ImgBtnAdminLogin" runat="server" CssClass="ImgBtnAlign" ImageUrl="~/Images/Admin.png" Height="120px" Width="128px" OnClick="ImgBtnAdminLogin_Click" />
                        </div>
                    </li>
                    <li>
                        <div>
                            <asp:Label ID="LblVisitor" runat="server" Text="Visitor"></asp:Label>
                            <asp:ImageButton ID="ImgBtnVisitorLogin" runat="server" CssClass="ImgBtnAlign" Height="120px" Width="128px" ImageUrl="~/Images/Visitor.png" OnClick="ImgBtnVisitorLogin_Click" />
                        </div>
                    </li>
                </ul>
            </section>
        </main>
    </div>
</asp:Content>
