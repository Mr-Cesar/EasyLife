<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="AsignarPersonal.aspx.cs" Inherits="EasyLife.Vista.AsignarPersonal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Asignar Personal</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <section class="form-control mb-4" style="width: 40%; height: auto; margin-left: 30%; margin-top: 6%; background-color: #BB8FCE;">
        <form class="text-center border border-light p-5" action="#!">
            <div class="h4 mb-4 text-center">
                <asp:Label ID="lbOpcion" runat="server" Text="Asignar Personal" CssClass="h4 mb-4 text-center" ForeColor="Black"></asp:Label>
            </div>
            <%-- Campo de ingreso de Opcion --%>
            <asp:Label ID="Label2" runat="server" Text="Opcion" ForeColor="Black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:DropDownList ID="dplOption" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dplOption_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <%-- Validacion de Opcion --%>
            <div style="display: inline-block;">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplOption"
                    Display="Dynamic" InitialValue="Seleccione una Opción" ValidationGroup="asignar"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplOption"
                    Display="Dynamic" ValidationGroup="asignar"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <%-- Campo de ingreso de Condominio --%>
            <asp:Label ID="Label10" runat="server" Text="Condominio" ForeColor="Black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:DropDownList ID="dplCondominio" runat="server" CssClass="form-control" AutoPostBack="true"
                    OnSelectedIndexChanged="dplCondominio_SelectedIndexChanged" Enabled="false">
                </asp:DropDownList>
            </div>
            <%-- Validacion de Condominio --%>
            <div style="display: inline-block;">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplCondominio"
                    Display="Dynamic" InitialValue="Seleccione un Condominio" ValidationGroup="asignar"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplCondominio"
                    Display="Dynamic" ValidationGroup="asignar"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <!-- Personal Asignado -->
            <asp:Label ID="lbPersonal" runat="server" Text="No Puede Eliminar a Esta Persona" ForeColor="Red" Visible="false"></asp:Label>
            <asp:Label ID="lbOk" runat="server" Text="Personal Asignados" ForeColor="Black" Visible="false"></asp:Label>
            <asp:GridView ID="grPersonal" runat="server" CssClass="table table-striped w-auto" AutoGenerateColumns="False" DataKeyNames="_ID_PERSONA"
                Font-Size="10pt" OnSelectedIndexChanged="grPersonal_SelectedIndexChanged" AllowPaging="true" OnPageIndexChanging="grPersonal_PageIndexChanging"
                PageSize="6">
                <Columns>
                    <asp:BoundField DataField="_DESCRIPCION_ROL" HeaderText="Rol" SortExpression="_DESCRIPCION_ROL" />
                    <asp:BoundField DataField="_FK_RUT" HeaderText="Rut" SortExpression="_FK_RUT" />
                    <asp:BoundField DataField="_NOMBRE_PERSONA" HeaderText="Nombre" SortExpression="_NOMBRE_PERSONA" />
                    <asp:BoundField DataField="_APELLIDO_PERSONA" HeaderText="Apellido" SortExpression="_APELLIDO_PERSONA" />
                    <asp:CommandField ShowSelectButton="True" HeaderText="Eliminar" />
                </Columns>
            </asp:GridView>

            <%-- Campo de ingreso de Personal --%>
            <asp:Label ID="Label8" runat="server" Text="Personal" ForeColor="Black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:DropDownList ID="dplPersonal" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dplPersonal_SelectedIndexChanged"
                    Enabled="false">
                </asp:DropDownList>
            </div>
            <%-- Validacion de Personal --%>
            <div style="display: inline-block;">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplPersonal"
                    Display="Dynamic" InitialValue="Seleccione Personal" ValidationGroup="asignar"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplPersonal"
                    Display="Dynamic" ValidationGroup="asignar"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <asp:Label ID="lbError" runat="server" Text="Personal ya Asignado" Visible="false" ForeColor="Red"></asp:Label>
            <asp:Button runat="server" ID="btnAgregar" class="btn btn-light btn-block my-4" Text="Asignar" OnClick="btnAgregar_Click" Visible="false"
                ValidationGroup="asignar" />

            <!-- Lista de Personal a Asignar -->
            <asp:GridView ID="grAsignados" runat="server" CssClass="table table-striped w-auto" AutoGenerateColumns="False" DataKeyNames="_ID_PERSONA"
                Font-Size="10pt" OnSelectedIndexChanged="grAsignados_SelectedIndexChanged" AllowPaging="true" OnPageIndexChanging="grAsignados_PageIndexChanging"
                PageSize="6">
                <Columns>
                    <asp:BoundField DataField="_DESCRIPCION_ROL" HeaderText="Rol" SortExpression="_DESCRIPCION_ROL" />
                    <asp:BoundField DataField="_FK_RUT" HeaderText="Rut" SortExpression="_FK_RUT" />
                    <asp:BoundField DataField="_NOMBRE_PERSONA" HeaderText="Nombre" SortExpression="_NOMBRE_PERSONA" />
                    <asp:BoundField DataField="_APELLIDO_PERSONA" HeaderText="Apellido" SortExpression="_APELLIDO_PERSONA" />
                    <asp:CommandField ShowSelectButton="True" HeaderText="Eliminar" />
                </Columns>
            </asp:GridView>

            <!-- Sign in button -->
            <asp:UpdatePanel ID="barraProgreso" runat="server">
                <ContentTemplate>
                    <asp:Button runat="server" ID="btnRegistro" class="btn btn-light btn-block my-4" Text="Asignar Personal" OnClick="btnRegistro_Click" Visible="false" />
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