<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="RegistroConserje.aspx.cs" Inherits="EasyLife.Vista.RegistroConserje" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Registro Conserje</title>
    <script type="text/javascript">
        function formatCliente(cliente) {
            cliente.value = cliente.value.replace(/[.-]/g, '')
                .replace(/^(\d{1,2})(\d{3})(\d{3})(\w{1})$/, '$1.$2.$3-$4')
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <section class="form-control mb-4" style="width: 40%; height: auto; margin-left: 30%; margin-top: 5%; background-color: #BB8FCE">
        <form class="text-center border border-light p-5" action="#!">
            <p class="h4 mb-4 text-center" style="color: black">
                <asp:Label ID="lbTitulo" runat="server" Text="Registro de Conserje"></asp:Label>
            </p>
            <%-- Campo de ingreso de Condominio --%>
            <asp:Label ID="Label8" runat="server" Text="Condominio" ForeColor="Black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:DropDownList ID="dplCondominio" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dplCondominio_SelectedIndexChanged">
                    <asp:ListItem>Seleccione un Condominio</asp:ListItem>
                </asp:DropDownList>
            </div>
            <%-- Validacion de Condominio --%>
            <div style="display: inline-block;">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplCondominio"
                    Display="Dynamic" InitialValue="Seleccione un Condominio"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplCondominio" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <!-- Lista de Conserjes -->
            <asp:Label ID="Label11" runat="server" Text="Lista Horarios" Visible="false" ForeColor="Black"></asp:Label>
            <asp:GridView ID="grConserje" runat="server" CssClass="table table-striped w-auto" AutoGenerateColumns="False" DataKeyNames="ID_PERSONA"
                Font-Size="10pt" AllowPaging="true" PageSize="6" OnPageIndexChanging="grConserje_PageIndexChanging">
                <Columns>
                    <asp:BoundField DataField="NOMBRE_PERSONA" HeaderText="Nombre" SortExpression="NOMBRE_PERSONA" />
                    <asp:BoundField DataField="APELLIDO_PERSONA" HeaderText="Apellido" SortExpression="APELLIDO_PERSONA" />
                    <asp:BoundField DataField="FK_RUT" HeaderText="Rut" SortExpression="FK_RUT" />
                </Columns>
            </asp:GridView>

            <%-- Campo de ingreso de Rut --%>
            <asp:Label ID="Label3" runat="server" Text="Rut" ForeColor="Black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:TextBox ID="txtRut" runat="server" placeholder="Rut" CssClass="form-control" MaxLength="12" onkeyup="formatCliente(this)"></asp:TextBox>
            </div>
            <%-- Validacion de rut --%>
            <div style="display: inline-block;">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtRut" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Formato no Valido" ForeColor="Red" Display="Dynamic" ControlToValidate="txtRut" ValidationExpression="^(\d{1,3}(?:\.\d{1,3}){2}-[\dkK])$"></asp:RegularExpressionValidator>
            </div>
            <br />
            <br />

            <%-- Campo de ingreso nombre --%>
            <asp:Label ID="Label1" runat="server" Text="Nombre" ForeColor="Black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:TextBox ID="txtNombre" runat="server" placeholder="Nombre" CssClass="form-control" MaxLength="20"></asp:TextBox>
            </div>
            <%-- Validacion de Nombre --%>
            <div style="display: inline-block">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Debe ingresar solo letras." ForeColor="Red"
                    ControlToValidate="txtNombre" ValidationExpression="^[a-zA-Z]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtNombre"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <%-- Campo de ingreso apellido --%>
            <asp:Label ID="Label2" runat="server" Text="Apellido" ForeColor="Black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:TextBox ID="txtApellido" runat="server" placeholder="Apellido" CssClass="form-control" MaxLength="20"></asp:TextBox>
            </div>
            <%-- Validacion de Apellido --%>
            <div style="display: inline-block;">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Debe ingresar solo letras." ForeColor="Red"
                    ControlToValidate="txtApellido" ValidationExpression="^[a-zA-Z]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtApellido"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

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

            <!-- Email -->
            <asp:Label ID="Label5" runat="server" Text="Email" ForeColor="Black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:TextBox runat="server" ID="txtEmail" class="form-control" aria-describedby="emailHelp" placeholder="Enter email" MaxLength="50"></asp:TextBox>
            </div>
            <!-- Validacion de Email -->
            <div style="display: inline-block">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtEmail"
                    Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Formato de correo no Valido" ForeColor="Red" Display="Dynamic"
                    ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </div>
            <br />
            <br />

            <!-- Campo Seleccion sexo -->
            <asp:Label ID="Label7" runat="server" Text="Sexo" ForeColor="Black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:RadioButtonList ID="radioSexo" runat="server" ForeColor="Black">
                    <asp:ListItem Value="M">Masculino</asp:ListItem>
                    <asp:ListItem Value="F">Femenino</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <!-- Validacion de sexo -->
            <div style="display: inline-block">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="radioSexo"
                    Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <asp:Panel ID="panelTurno" runat="server">
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
                <asp:Label ID="Label10" runat="server" Text="Fecha Termino" Style="color: black"></asp:Label><br />
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
                <asp:Button runat="server" ID="btnAgregarTurno" class="btn btn-light btn-block my-4" Text="Agregar Horario" OnClick="btnAgregarTurno_Click"
                    ValidationGroup="horario" />

                <!-- Lista de Horarios -->
                <asp:Label ID="lbHorario" runat="server" Text="Lista Turno" ForeColor="Black" Visible="false"></asp:Label>
                <asp:GridView ID="grHorario" runat="server" CssClass="table table-striped w-auto" AutoGenerateColumns="False" DataKeyNames="ID_TURNO"
                    Font-Size="10pt" OnSelectedIndexChanged="grHorario_SelectedIndexChanged" AllowPaging="true" PageIndex="6"
                    OnPageIndexChanging="grHorario_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="DESCRIPCION_TURNO" HeaderText="Turno" SortExpression="DESCRIPCION_TURNO" />
                        <asp:BoundField DataField="FECHA_INICIO" HeaderText="Fecha Inicio" SortExpression="FECHA_INICIO" />
                        <asp:BoundField DataField="FECHA_TERMINO" HeaderText="Fecha Termino" SortExpression="FECHA_TERMINO" />
                        <asp:CommandField ShowSelectButton="true" HeaderText="Eliminar" />
                    </Columns>
                </asp:GridView>
            </asp:Panel>

            <!-- Sign in button -->
            <asp:UpdatePanel ID="barraProgreso" runat="server">
                <ContentTemplate>
                    <asp:Button runat="server" ID="btnRegistroConserje" class="btn btn-light btn-block my-4" Text="Registrar Conserje"
                        OnClick="btnRegistroConserje_Click" />
                    <asp:Button runat="server" ID="btnModificarConserje" class="btn btn-light btn-block my-4" Text="Modificar Conserje" Visible="false"
                        OnClick="btnModificarConserje_Click" CausesValidation="false" />
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