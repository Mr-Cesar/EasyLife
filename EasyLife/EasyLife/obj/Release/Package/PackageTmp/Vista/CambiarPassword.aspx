<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="CambiarPassword.aspx.cs" Inherits="EasyLife.Vista.CambiarPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Cambiar Password</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <section class="form-control mb-4" style="width: 40%; height: auto; margin-left: 30%; margin-top: 6%; background-color: #BB8FCE; margin-bottom: 180px">
        <!-- Default form login -->
        <form class="text-center border border-light p-5" action="#!">
            <p class="h4 mb-4 text-center" style="color: black">Cambio de Password</p>
            <!-- Password -->
            <asp:Label ID="Label1" runat="server" Text="Ingrese Password Anterior" ForeColor="Black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:TextBox runat="server" ID="txtAPassword" class="form-control" aria-describedby="emailHelp" placeholder="Enter Password" MaxLength="20"
                    TextMode="Password"></asp:TextBox>
            </div>
            <!-- Validacion de Password-->
            <div style="display: inline-block">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtAPassword"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <!-- Password Nueva -->
            <asp:Label ID="Label7" runat="server" Text="Nueva Password" Style="color: black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:TextBox runat="server" ID="txtPassword" class="form-control" aria-describedby="emailHelp" placeholder="Enter New Password" MaxLength="20"
                    TextMode="Password"></asp:TextBox>
            </div>
            <!-- Validacion de Password-->
            <div style="display: inline-block">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <%-- Campo de ingreso Password2 --%>
            <asp:Label ID="Label6" runat="server" Text="Repetir Password" Style="color: black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:TextBox ID="txtPassword2" runat="server" placeholder="Repetir Password" CssClass="form-control" TextMode="Password" MaxLength="20"></asp:TextBox>
            </div>
            <%-- Validacion de password2 --%>
            <div style="display: inline-block;">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtPassword2"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Contraseñas no Coinciden" ControlToValidate="txtPassword"
                    ControlToCompare="txtPassword2" Display="Dynamic" ForeColor="Red"></asp:CompareValidator>
            </div>
            <br />
            <br />

            <!-- Sign in button -->
            <asp:UpdatePanel ID="barraProgreso" runat="server">
                <ContentTemplate>
                    <asp:Button runat="server" ID="btnCambioPassword" class="btn btn-light btn-block my-4" Text="Cambiar Password" OnClick="btnCambioPassword_Click" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </form>
        <%-- Panel que muestra Pop up de carga --%>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="barraProgreso">
            <ProgressTemplate>
                <div class="fImg"></div>
                <div class="fLoad">
                    <p class="h4 mb-4 text-center">Espere Un Momento</p>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </section>
</asp:Content>