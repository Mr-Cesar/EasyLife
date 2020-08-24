<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="RegistroReservaPropietario.aspx.cs" Inherits="EasyLife.Vista.RegistroReservaPropietario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Reserva Centro</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <section class="form-control mb-4" style="margin: 30px; width: 40%; height: auto; margin-left: 30%; margin-top: 5%; background-color: #BB8FCE">
        <!-- Default form login -->
        <form class="text-center border border-light p-5" action="#!">
            <p class="h4 mb-4 text-center" style="color: black">
                <asp:Label ID="lbTitulo" runat="server" Text="Registro de Reserva"></asp:Label>
            </p>
            <%-- Campo de ingreso de Departamento --%>
            <asp:Label ID="Label3" runat="server" Text="Departamento" Style="color: black"></asp:Label>
            <br />
            <div style="display: inline-block; width: 90%">
                <asp:DropDownList ID="dplDepartamento" runat="server" CssClass="form-control" OnSelectedIndexChanged="dplDepartamento_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem>Seleccione un Departamento</asp:ListItem>
                </asp:DropDownList>
            </div>
            <%-- Validacion de Departamento --%>
            <div style="display: inline-block;">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplDepartamento"
                    Display="Dynamic" InitialValue="Seleccione un Departamento"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplDepartamento" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <%-- Campo de ingreso de Centro --%>
            <asp:Label ID="Label1" runat="server" Text="Centro" Style="color: black"></asp:Label>
            <br />
            <div style="display: inline-block; width: 90%">
                <asp:DropDownList ID="dplCentro" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dplCentro_SelectedIndexChanged">
                    <asp:ListItem>Seleccione un Centro</asp:ListItem>
                </asp:DropDownList>
            </div>
            <%-- Validacion de Centro --%>
            <div style="display: inline-block;">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplCentro"
                    Display="Dynamic" InitialValue="Seleccione un Centro"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplCentro" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <%-- Campo de Ingreso de Dia --%>
            <asp:Label ID="Label4" runat="server" Text="Dia Reserva" Style="color: black"></asp:Label>
            <br />
            <div style="display: inline-block; width: 90%">
                <asp:DropDownList ID="dplDia" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dplDia_SelectedIndexChanged">
                    <asp:ListItem>Seleccione un Dia</asp:ListItem>
                </asp:DropDownList>
            </div>
            <%-- Validacion de Dia --%>
            <div style="display: inline-block;">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplDia"
                    Display="Dynamic" InitialValue="Seleccione un Dia"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplDia" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <%-- Campo de Ingreso de Horario --%>
            <asp:Label ID="Label5" runat="server" Text="Horario" Style="color: black"></asp:Label>
            <br />
            <div style="display: inline-block; width: 90%">
                <asp:DropDownList ID="dplHorario" runat="server" CssClass="form-control">
                    <asp:ListItem>Seleccione un Horario</asp:ListItem>
                </asp:DropDownList>
            </div>
            <%-- Validacion de Horario --%>
            <div style="display: inline-block;">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplHorario"
                    Display="Dynamic" InitialValue="Seleccione un Horario"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplHorario" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <%-- Campo de ingreso Total --%>
            <asp:Label ID="Label7" runat="server" Text="Total" ForeColor="Black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:Label ID="lbTotal" runat="server" Text="" placeholder="Total" CssClass="form-control"></asp:Label>
            </div>

            <!-- Sign in button -->
            <asp:UpdatePanel ID="barraProgreso" runat="server">
                <ContentTemplate>
                    <asp:Button runat="server" ID="btnRegistroReserva" class="btn btn-light btn-block my-4" Text="Registrar Reserva" OnClick="btnRegistroReserva_Click" />
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