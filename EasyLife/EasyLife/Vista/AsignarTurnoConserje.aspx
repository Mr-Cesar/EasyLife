<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="AsignarTurnoConserje.aspx.cs" Inherits="EasyLife.Vista.AsignarTurnoConserje" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Asignar Turno</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <section class="form-control mb-4" style="width: 40%; height: auto; margin-left: 30%; margin-top: 6%; background-color: #BB8FCE;">
        <form class="text-center border border-light p-5" action="#!">
            <div class="h4 mb-4 text-center">
                <asp:Label ID="lbOpcion" runat="server" Text="Asignar Turno Conserje" CssClass="h4 mb-4 text-center" ForeColor="Black"></asp:Label>
            </div>
            <%-- Campo de ingreso de Condominio --%>
            <asp:Label ID="Label10" runat="server" Text="Condominio" ForeColor="Black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:DropDownList ID="dplCondominio" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dplCondominio_SelectedIndexChanged">
                    <asp:ListItem>Seleccione un Condominio</asp:ListItem>
                </asp:DropDownList>
            </div>
            <%-- Validacion de Condominio --%>
            <div style="display: inline-block;">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplCondominio"
                    Display="Dynamic" InitialValue="Seleccione un Condominio"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplCondominio" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <%-- Campo de ingreso de Conserje --%>
            <asp:Label ID="Label2" runat="server" Text="Conserje" ForeColor="Black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:DropDownList ID="dplConserje" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dplConserje_SelectedIndexChanged">
                    <asp:ListItem>Seleccione un Conserje</asp:ListItem>
                </asp:DropDownList>
            </div>
            <%-- Validacion de Conserje --%>
            <div style="display: inline-block;">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplConserje"
                    Display="Dynamic" InitialValue="Seleccione un Conserje"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplConserje" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <!-- Lista de Horarios Actuales -->
            <asp:GridView ID="grHorarioActual" runat="server" CssClass="table table-striped w-auto" AutoGenerateColumns="False" DataKeyNames="ID_TURNO"
                Font-Size="10pt" OnPageIndexChanging="grHorarioActual_PageIndexChanging" PageIndex="7" OnSelectedIndexChanged="grHorarioActual_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="DESCRIPCION_TURNO" HeaderText="Turno" SortExpression="DESCRIPCION_TURNO" />
                    <asp:BoundField DataField="FECHA_INICIO" HeaderText="Fecha Inicio" SortExpression="FECHA_INICIO" />
                    <asp:BoundField DataField="FECHA_TERMINO" HeaderText="Fecha Termino" SortExpression="FECHA_TERMINO" />
                    <asp:CommandField ShowSelectButton="true" HeaderText="Modificar" />
                </Columns>
            </asp:GridView>

            <%-- Campo de ingreso de Turno --%>
            <asp:Label ID="Label9" runat="server" Text="Turno" ForeColor="Black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:DropDownList ID="dplTurno" runat="server" CssClass="form-control" AutoPostBack="true">
                    <asp:ListItem>Seleccione un Turno</asp:ListItem>
                    <asp:ListItem Value="Mañana">Mañana</asp:ListItem>
                    <asp:ListItem Value="Tarde">Tarde</asp:ListItem>
                    <asp:ListItem Value="Noche">Noche</asp:ListItem>
                </asp:DropDownList>
            </div>
            <%-- Validacion de Turno --%>
            <div style="display: inline-block;">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplTurno"
                    Display="Dynamic" InitialValue="Seleccione un Turno" ValidationGroup="horario"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplTurno"
                    Display="Dynamic" ValidationGroup="horario"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <!-- Ingreso Dia Horario -->
            <asp:Label ID="Label6" runat="server" Text="Fecha Inicio" Style="color: black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:TextBox runat="server" ID="txtFechaI" class="form-control" aria-describedby="emailHelp" TextMode="Date"></asp:TextBox>
            </div>
            <!-- Validacion de Ingreso Dia Horario -->
            <div style="display: inline-block">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtFechaI"
                    ValidationGroup="horario"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <!-- Ingreso Dia Horario -->
            <asp:Label ID="Label1" runat="server" Text="Fecha Termino" Style="color: black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:TextBox runat="server" ID="txtFechaT" class="form-control" aria-describedby="emailHelp" TextMode="Date"></asp:TextBox>
            </div>
            <!-- Validacion de Ingreso Dia Horario -->
            <div style="display: inline-block">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtFechaT"
                    ValidationGroup="horario"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <asp:Label ID="lbError" runat="server" Text="Turno ya Asignado" ForeColor="Red" Visible="false"></asp:Label>
            <asp:Button runat="server" ID="btnAgregarTurno" class="btn btn-light btn-block my-4" Text="Agregar Horario" OnClick="btnAgregarTurno_Click" ValidationGroup="horario" />

            <!-- Lista de Horarios -->
            <asp:GridView ID="grHorario" runat="server" CssClass="table table-striped w-auto" AutoGenerateColumns="False" DataKeyNames="ID_TURNO"
                Font-Size="10pt" OnSelectedIndexChanged="grHorario_SelectedIndexChanged" PageIndex="6" OnPageIndexChanging="grHorario_PageIndexChanging">
                <Columns>
                    <asp:BoundField DataField="DESCRIPCION_TURNO" HeaderText="Turno" SortExpression="DESCRIPCION_TURNO" />
                    <asp:BoundField DataField="FECHA_INICIO" HeaderText="Fecha Inicio" SortExpression="FECHA_INICIO" />
                    <asp:BoundField DataField="FECHA_TERMINO" HeaderText="Fecha Termino" SortExpression="FECHA_TERMINO" />
                    <asp:CommandField ShowSelectButton="true" HeaderText="Eliminar" />
                </Columns>
            </asp:GridView>

            <!-- Sign in button -->
            <asp:UpdatePanel ID="barraProgreso" runat="server">
                <ContentTemplate>
                    <asp:Button runat="server" ID="btnRegistroTurno" class="btn btn-light btn-block my-4" Text="Registrar Turnos" OnClick="btnRegistroTurno_Click"
                        Visible="false" />
                    <asp:Button runat="server" ID="btnModificarTurno" class="btn btn-light btn-block my-4" Text="Modificar Turnos" Visible="false"
                        OnClick="btnModificarTurno_Click" CausesValidation="false" />
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