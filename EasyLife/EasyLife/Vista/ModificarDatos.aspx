<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="ModificarDatos.aspx.cs" Inherits="EasyLife.Vista.ModificarDatos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Modificar Datos</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <section class="form-control mb-4" style="width: 40%; height: auto; margin-left: 30%; margin-top: 6%; background-color: #BB8FCE">
        <!-- Default form login -->
        <form class="text-center border border-light p-5" action="#!">
            <p class="h4 mb-4 text-center" style="color: black">Modificar Datos</p>
            <%-- Campo de ingreso telefono --%>
            <asp:Label ID="Label4" runat="server" Text="Telefono" ForeColor="Black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:TextBox ID="txtTelefono" runat="server" placeholder="Telefono" CssClass="form-control" TextMode="Number" MaxLength="9"></asp:TextBox>
            </div>
            <%-- Validacion de Telefono --%>
            <div style="display: inline-block;">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtTelefono"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <!-- Campo Ingreso Email -->
            <asp:Label ID="Label5" runat="server" Text="Email" ForeColor="Black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:TextBox runat="server" ID="txtEmail" class="form-control" aria-describedby="emailHelp" placeholder="Enter email" MaxLength="50"></asp:TextBox>
            </div>
            <!-- Validacion de Email -->
            <div style="display: inline-block">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtEmail"
                    Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Formato de correo no Valido" ForeColor="Red" Display="Dynamic"
                    ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </div>
            <br />
            <br />

            <!-- Sign in button -->
            <asp:UpdatePanel ID="barraProgreso" runat="server">
                <ContentTemplate>
                    <asp:Button runat="server" ID="btnModificarDatos" class="btn btn-light btn-block my-4" Text="Modificar Datos" OnClick="btnModificarDatos_Click" />
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