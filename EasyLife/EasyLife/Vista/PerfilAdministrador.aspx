<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="PerfilAdministrador.aspx.cs" Inherits="EasyLife.Vista.PerfilAdministrador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Perfil</title>
    <script type="text/javascript">
        function formatCliente(cliente) {
            cliente.value = cliente.value.replace(/[.-]/g, '')
                .replace(/^(\d{1,2})(\d{3})(\d{3})(\w{1})$/, '$1.$2.$3-$4')
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <!-- Bienvenido Usuario -->
            <div class="jumbotron card card-image" style="background-image: url(https://i.postimg.cc/7hH0y8Lk/Section.png); width: 102%; height: 400px">
                <div class="text-white text-center py-5 px-4">
                    <br />
                    <div class="container">
                        <h2 class="display-4"><strong>Bienvenido
                            <asp:Label ID="lbUser" runat="server" Text=""></asp:Label></strong>
                        </h2>
                    </div>
                </div>
            </div>

            <div class="row" style="margin-left: 10%; margin-top: 5%; margin-bottom: 4%;">
                <div class="col-4">
                    <div class="list-group" role="tablist">
                        <asp:Button ID="btnDatosUsuario" runat="server" Text="Mis Datos" CssClass="list-group-item list-group-item-action"
                            OnClick="btnDatosUsuario_Click" BackColor="LightBlue" />
                        <asp:Button ID="btnCondominio" runat="server" Text="Condominios" CssClass="list-group-item list-group-item-action" OnClick="btnCondominio_Click" />
                        <asp:Button ID="btnPersonal" runat="server" Text="Personal" CssClass="list-group-item list-group-item-action" OnClick="btnPersonal_Click" />
                        <asp:Button ID="btnPropietarios" runat="server" Text="Propietarios" CssClass="list-group-item list-group-item-action" OnClick="btnPropietarios_Click" />
                        <asp:Button ID="btnGastos" runat="server" Text="Gastos Comúnes" CssClass="list-group-item list-group-item-action" OnClick="btnGastos_Click" />
                        <asp:Button ID="btnCentros" runat="server" Text="Centros" CssClass="list-group-item list-group-item-action" OnClick="btnCentros_Click" />
                        <asp:Button ID="btnMensajes" runat="server" Text="Mensajes" CssClass="list-group-item list-group-item-action" OnClick="btnMensajes_Click" />
                        <asp:Button ID="btnAvisos" runat="server" Text="Avisos" CssClass="list-group-item list-group-item-action" OnClick="btnAvisos_Click" />
                    </div>
                </div>

                <div class="col-8">
                    <div class="tab-content">
                        <asp:Panel ID="panelDatos" runat="server" Visible="true">
                            <section>
                                <div class="form-group row">
                                    <label for="inputEmail3MD" class="col-sm-2 col-form-label">Rut</label>
                                    <div class="col-sm-10">
                                        <div class="md-form mt-0" style="width: 50%">
                                            <asp:Label ID="lbRut" CssClass="form-control" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group row">
                                    <label for="inputEmail3MD" class="col-sm-2 col-form-label">Nombre</label>
                                    <div class="col-sm-10">
                                        <div class="md-form mt-0" style="width: 50%">
                                            <asp:Label ID="lbNombre" CssClass="form-control" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group row">
                                    <label for="inputEmail3MD" class="col-sm-2 col-form-label">Apellido</label>
                                    <div class="col-sm-10">
                                        <div class="md-form mt-0" style="width: 50%">
                                            <asp:Label ID="lbApellido" CssClass="form-control" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group row">
                                    <label for="inputEmail3MD" class="col-sm-2 col-form-label">Telefono</label>
                                    <div class="col-sm-10">
                                        <div class="md-form mt-0" style="width: 50%">
                                            <asp:Label ID="lbTelefono" CssClass="form-control" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group row">
                                    <label for="inputEmail3MD" class="col-sm-2 col-form-label">Correo</label>
                                    <div class="col-sm-10">
                                        <div class="md-form mt-0" style="width: 50%">
                                            <asp:Label ID="lbCorreo" CssClass="form-control" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                </div>

                                <asp:LinkButton ID="lnkModificarDatos" runat="server" class="btn btn-outline-primary btn-rounded waves-effect"
                                    CausesValidation="false" OnClick="lnkModificarDatos_Click">Modificar Datos</asp:LinkButton>
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:LinkButton ID="lnkModificarPassword" runat="server" class="btn btn-outline-primary btn-rounded waves-effect"
                                    CausesValidation="false" OnClick="lnkModificarPassword_Click">Cambiar Password</asp:LinkButton>
                            </section>
                        </asp:Panel>

                        <asp:Panel ID="panelCondominios" runat="server" Visible="false">
                            <div class="form-inline my-3 my-lg-0">
                                <div class="md-form form-sm my-0" style="margin-right: 2%">
                                    <div style="display: inline-block;">
                                        <asp:TextBox ID="txtSearchCondominio" runat="server" CssClass="form-control" placeholder="Search"
                                            onkeyup="formatCliente(this)"></asp:TextBox>
                                    </div>
                                    <div style="display: inline-block;">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red"
                                            ControlToValidate="txtSearchCondominio" Display="Dynamic" ValidationGroup="searchCondominio"></asp:RequiredFieldValidator>
                                    </div>
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnSearchCondominio" runat="server" Text="Search" CssClass="btn btn-outline-primary btn-rounded waves-effect"
                                        ValidationGroup="searchCondominio" OnClick="btnSearchCondominio_Click" />
                                </div>
                            </div>
                            <br />
                            <asp:Button ID="btnCrearCondominio" runat="server" Text="Crear Condominio" class="btn btn-outline-primary btn-rounded waves-effect"
                                CausesValidation="false" OnClick="btnCrearCondominio_Click" />
                            <br />
                            <br />

                            <asp:Label ID="Label4" runat="server" Text="Lista de Condominios" ForeColor="Black"></asp:Label><br />
                            <asp:Label ID="lbErrorSearchCondominio" runat="server" Text="No se Encontraron Resultados" Visible="false"></asp:Label>
                            <br />
                            <asp:GridView ID="grCondominio" runat="server" CssClass="table table-striped w-auto" AutoGenerateColumns="False" DataKeyNames="_ID_CONDOMINIO"
                                Font-Size="10pt" OnSelectedIndexChanged="grCondominio_SelectedIndexChanged" AllowPaging="true"
                                OnPageIndexChanging="grCondominio_PageIndexChanging" PageSize="6">
                                <Columns>
                                    <asp:BoundField DataField="_ID_CONDOMINIO" HeaderText="Id" SortExpression="_ID_CONDOMINIO" />
                                    <asp:BoundField DataField="_NOMBRE_CONDOMINIO" HeaderText="Nombre" SortExpression="_NOMBRE_CONDOMINIO" />
                                    <asp:BoundField DataField="_PRECIO_EST" HeaderText="Precio Est" SortExpression="_PRECIO_EST" />
                                    <asp:BoundField DataField="_FK_RUT" HeaderText="Administrador" SortExpression="_FK_RUT" />
                                    <asp:BoundField DataField="_CALLE" HeaderText="Calle" SortExpression="_CALLE" />
                                    <asp:BoundField DataField="_NUMERO" HeaderText="Numero" SortExpression="_NUMERO" />
                                    <asp:BoundField DataField="_NOMBRE_COMUNA" HeaderText="Comuna" SortExpression="_NOMBRE_COMUNA" />
                                    <asp:BoundField DataField="_NOMBRE_CIUDAD" HeaderText="Ciudad" SortExpression="_NOMBRE_CIUDAD" />
                                    <asp:BoundField DataField="_NOMBRE_REGION" HeaderText="Region" SortExpression="_NOMBRE_REGION" />
                                    <asp:CommandField ShowSelectButton="true" HeaderText="Ver Mas" />
                                </Columns>
                            </asp:GridView>

                            <asp:Panel ID="panelEdificio" runat="server" Visible="false">
                                <asp:Label ID="Label1" runat="server" Text="Lista de Edificios" ForeColor="Black"></asp:Label><br />
                                <asp:GridView ID="grEdificio" runat="server" CssClass="table table-striped w-auto" AutoGenerateColumns="False" DataKeyNames="_ID_EDIFICIO"
                                    Font-Size="10pt" AllowPaging="True" OnSelectedIndexChanged="grEdificio_SelectedIndexChanged" ShowHeaderWhenEmpty="true"
                                    OnPageIndexChanging="grEdificio_PageIndexChanging" PageSize="6">
                                    <Columns>
                                        <asp:BoundField DataField="_ID_EDIFICIO" HeaderText="Id" SortExpression="_ID_EDIFICIO" />
                                        <asp:BoundField DataField="_NOMBRE_EDIFICIO" HeaderText="Nombre" SortExpression="_NOMBRE_EDIFICIO" />
                                        <asp:BoundField DataField="_CANTIDAD_PISO" HeaderText="Pisos" SortExpression="_CANTIDAD_PISO" />
                                        <asp:BoundField DataField="_CANTIDAD_DEPARTAMENTO" HeaderText="Cant Dep" SortExpression="_CANTIDAD_DEPARTAMENTO" />
                                        <asp:BoundField DataField="_TOTAL_GASTO" HeaderText="Gasto Común" SortExpression="_TOTAL_GASTO" NullDisplayText="No Asignado" />
                                        <asp:CommandField ShowSelectButton="True" HeaderText="Ver Mas" />
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>

                            <asp:Panel ID="panelDep" runat="server" Visible="false">
                                <asp:Label ID="Label2" runat="server" Text="Lista de Departamentos" ForeColor="Black"></asp:Label><br />
                                <asp:GridView ID="grDepartamento" runat="server" CssClass="table table-striped w-auto" AutoGenerateColumns="False" DataKeyNames="ID_DEPARTAMENTO"
                                    Font-Size="10pt" AllowPaging="True" OnSelectedIndexChanged="grDepartamento_SelectedIndexChanged"
                                    OnPageIndexChanging="grDepartamento_PageIndexChanging" PageSize="6">
                                    <Columns>
                                        <asp:BoundField DataField="ID_DEPARTAMENTO" HeaderText="Id" SortExpression="ID_DEPARTAMENTO" />
                                        <asp:BoundField DataField="NUMERO_DEP" HeaderText="Numero" SortExpression="NUMERO_DEP" />
                                        <asp:CommandField ShowSelectButton="True" HeaderText="Ver Mas" />
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>

                            <asp:Label ID="lbError" runat="server" Text="" Visible="false"></asp:Label>

                            <asp:Panel ID="panelDetalleDep" runat="server" Visible="false">
                                <asp:Label ID="Label9" runat="server" Text="Detalle Propietario Departamento" ForeColor="Black"></asp:Label><br />
                                <div class="col">
                                    <div class="form-group row">
                                        <asp:Label ID="Label13" runat="server" Text="Rut: " CssClass="col-sm-4 col-form-label"></asp:Label>
                                        <asp:Label ID="lbDepRut" runat="server" Text="" CssClass="col-sm-4 col-form-label"></asp:Label>
                                    </div>
                                </div>
                                <div class="col">
                                    <div class="form-group row">
                                        <asp:Label ID="Label17" runat="server" Text="Nombre: " CssClass="col-sm-4 col-form-label"></asp:Label>
                                        <asp:Label ID="lbDepNombre" runat="server" Text="" CssClass="col-sm-4 col-form-label"></asp:Label>
                                    </div>
                                </div>
                                <div class="col">
                                    <div class="form-group row">
                                        <asp:Label ID="Label21" runat="server" Text="Telefono: " CssClass="col-sm-4 col-form-label"></asp:Label>
                                        <asp:Label ID="lbDepTelefono" runat="server" Text="" CssClass="col-sm-4 col-form-label"></asp:Label>
                                    </div>
                                </div>
                                <div class="col">
                                    <div class="form-group row">
                                        <asp:Label ID="Label25" runat="server" Text="Correo: " CssClass="col-sm-4 col-form-label"></asp:Label>
                                        <asp:Label ID="lbDepCorreo" runat="server" Text="" CssClass="col-sm-4 col-form-label"></asp:Label>
                                    </div>
                                </div>
                                <div class="col">
                                    <div class="form-group row">
                                        <asp:Label ID="Label10" runat="server" Text="Luz: " CssClass="col-sm-4 col-form-label"></asp:Label>
                                        <asp:Label ID="lbDepLuz" runat="server" Text="" CssClass="col-sm-4 col-form-label"></asp:Label>
                                    </div>
                                </div>

                                <asp:Label ID="Label30" runat="server" Text="Lista de Multas"></asp:Label><br />
                                <asp:Label ID="lbErrorMulta" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:GridView ID="grMulta" runat="server" CssClass="table table-striped w-auto" AutoGenerateColumns="False" DataKeyNames="ID_MULTA"
                                    Font-Size="10pt" AllowPaging="True" OnPageIndexChanging="grMulta_PageIndexChanging" PageSize="6">
                                    <Columns>
                                        <asp:BoundField DataField="ID_MULTA" HeaderText="Id" SortExpression="ID_MULTA" />
                                        <asp:BoundField DataField="MOTIVO" HeaderText="Motivo" SortExpression="MOTIVO" />
                                        <asp:BoundField DataField="COSTO_MULTA" HeaderText="Costo" SortExpression="COSTO_MULTA" />
                                        <asp:CheckBoxField DataField="ESTADO_MULTA" HeaderText="Estado" SortExpression="ESTADO_MULTA" />
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                        </asp:Panel>

                        <asp:Panel ID="panelPersonal" runat="server" Visible="false">
                            <div class="form-inline my-4 my-lg-0">
                                <div class="md-form form-sm my-0" style="margin-right: 2%">
                                    <div style="display: inline-block;">
                                        <asp:TextBox ID="txtSearchPersonal" runat="server" CssClass="form-control" placeholder="Search"
                                            onkeyup="formatCliente(this)"></asp:TextBox>
                                    </div>
                                    <div style="display: inline-block;">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red"
                                            ControlToValidate="txtSearchPersonal" Display="Dynamic" ValidationGroup="searchPersonal"></asp:RequiredFieldValidator>
                                    </div>
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnSearchPersonal" runat="server" Text="Search" CssClass="btn btn-outline-primary btn-rounded waves-effect"
                                        ValidationGroup="searchPersonal" OnClick="btnSearchPersonal_Click" />
                                </div>

                                <asp:Button ID="btnRegistroPersonal" runat="server" Text="Registrar Personal" class="btn btn-outline-primary btn-rounded waves-effect"
                                    CausesValidation="false" OnClick="btnRegistroPersonal_Click" />
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnModificarPersonal" runat="server" Text="Modificar Personal" class="btn btn-outline-primary btn-rounded waves-effect"
                                    CausesValidation="false" OnClick="btnModificarPersonal_Click" Enabled="false" />
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnEliminarPersonal" runat="server" Text="Eliminar Personal" class="btn btn-outline-primary btn-rounded waves-effect"
                                    CausesValidation="false" OnClick="btnEliminarPersonal_Click" Enabled="false" />
                            </div>
                            <br />

                            <asp:DropDownList ID="dplPersonal" runat="server" CssClass="form-control" Width="40%" AutoPostBack="true"
                                OnSelectedIndexChanged="dplPersonal_SelectedIndexChanged">
                            </asp:DropDownList>
                            <br />

                            <asp:Label ID="Label3" runat="server" Text="Listado de Personal" ForeColor="Black"></asp:Label><br />
                            <asp:Label ID="lbErrorSearchPersonal" runat="server" Text="No se Encontraron Datos" Visible="false"></asp:Label>
                            <asp:GridView ID="grPersonal" runat="server" CssClass="table table-striped w-auto" AutoGenerateColumns="False" DataKeyNames="_ID_PERSONA"
                                Font-Size="10pt" AllowPaging="True" OnSelectedIndexChanged="grPersonal_SelectedIndexChanged" PageSize="6"
                                OnPageIndexChanging="grPersonal_PageIndexChanging">
                                <Columns>
                                    <asp:BoundField DataField="_ID_PERSONA" HeaderText="Id" SortExpression="_ID_PERSONA" />
                                    <asp:BoundField DataField="_DESCRIPCION_ROL" HeaderText="Rol" SortExpression="_DESCRIPCION_ROL" />
                                    <asp:BoundField DataField="_FK_RUT" HeaderText="Rut" SortExpression="_FK_RUT" />
                                    <asp:BoundField DataField="_NOMBRE_PERSONA" HeaderText="Nombre" SortExpression="_NOMBRE_PERSONA" />
                                    <asp:BoundField DataField="_APELLIDO_PERSONA" HeaderText="Apellido" SortExpression="_APELLIDO_PERSONA" />
                                    <asp:BoundField DataField="_TELEFONO_PERSONA" HeaderText="Telefono" SortExpression="_TELEFONO_PERSONA" />
                                    <asp:BoundField DataField="_CORREO_PERSONA" HeaderText="Coreo" SortExpression="_CORREO_PERSONA" />
                                    <asp:CheckBoxField DataField="_ESTADO_PERSONA" HeaderText="Estado" SortExpression="_ESTADO_PERSONA" />
                                    <asp:CommandField ShowSelectButton="True" HeaderText="Ver Mas" />
                                </Columns>
                            </asp:GridView>

                            <asp:Panel ID="panelDetallePersonal" runat="server" Visible="false">
                                <asp:Label ID="Label19" runat="server" Text="Detalle Personal" ForeColor="Black"></asp:Label><br />
                                <div class="col">
                                    <div class="form-group row">
                                        <asp:Label ID="Label23" runat="server" Text="Id: " CssClass="col-sm-4 col-form-label"></asp:Label>
                                        <asp:Label ID="lbPId" runat="server" Text="" CssClass="col-sm-4 col-form-label"></asp:Label>
                                    </div>
                                </div>
                                <div class="col">
                                    <div class="form-group row">
                                        <asp:Label ID="Label26" runat="server" Text="Rol: " CssClass="col-sm-4 col-form-label"></asp:Label>
                                        <asp:Label ID="lbPRol" runat="server" Text="" CssClass="col-sm-4 col-form-label"></asp:Label>
                                    </div>
                                </div>
                                <div class="col">
                                    <div class="form-group row">
                                        <asp:Label ID="Label27" runat="server" Text="Rut: " CssClass="col-sm-4 col-form-label"></asp:Label>
                                        <asp:Label ID="lbPRut" runat="server" Text="" CssClass="col-sm-4 col-form-label"></asp:Label>
                                    </div>
                                </div>
                                <div class="col">
                                    <div class="form-group row">
                                        <asp:Label ID="Label29" runat="server" Text="Nombre: " CssClass="col-sm-4 col-form-label"></asp:Label>
                                        <asp:Label ID="lbPNombre" runat="server" Text="" CssClass="col-sm-4 col-form-label"></asp:Label>
                                    </div>
                                </div>
                                <div class="col">
                                    <div class="form-group row">
                                        <asp:Label ID="Label31" runat="server" Text="Telefono: " CssClass="col-sm-4 col-form-label"></asp:Label>
                                        <asp:Label ID="lbPTelefono" runat="server" Text="" CssClass="col-sm-4 col-form-label"></asp:Label>
                                    </div>
                                </div>
                                <div class="col">
                                    <div class="form-group row">
                                        <asp:Label ID="Label33" runat="server" Text="Correo: " CssClass="col-sm-4 col-form-label"></asp:Label>
                                        <asp:Label ID="lbPCorreo" runat="server" Text="" CssClass="col-sm-4 col-form-label"></asp:Label>
                                    </div>
                                </div>
                                <div class="col">
                                    <div class="form-group row">
                                        <asp:Label ID="Label35" runat="server" Text="Estado: " CssClass="col-sm-4 col-form-label"></asp:Label>
                                        <asp:Label ID="lbPEstado" runat="server" Text="" CssClass="col-sm-4 col-form-label"></asp:Label>
                                    </div>
                                </div>
                                <asp:Button ID="btnHabilitarPersonal" runat="server" Text="Habilitar" class="btn btn-outline-primary btn-rounded waves-effect"
                                    CausesValidation="false" OnClick="btnHabilitarPersonal_Click" />
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnDeshabilitarPersonal" runat="server" Text="Deshabilitar" class="btn btn-outline-primary btn-rounded waves-effect"
                                    CausesValidation="false" OnClick="btnDeshabilitarPersonal_Click" />
                                <br />
                                <br />
                                <asp:Panel ID="panelConserje" runat="server" Visible="false">
                                    <asp:Label ID="lbConserje" runat="server" Text="Turno Conserje: " CssClass="col-sm-4 col-form-label" Visible="false"></asp:Label>
                                    <asp:GridView ID="grTurno" runat="server" CssClass="table table-striped w-auto" AutoGenerateColumns="False" DataKeyNames="ID_TURNO"
                                        Font-Size="10pt" AllowPaging="true" PageSize="6" OnPageIndexChanging="grTurno_PageIndexChanging">
                                        <Columns>
                                            <asp:BoundField DataField="DESCRIPCION_TURNO" HeaderText="Turno" SortExpression="DESCRIPCION_TURNO" />
                                            <asp:BoundField DataField="FECHA_INICIO" HeaderText="Fecha Inicio" SortExpression="FECHA_INICIO" />
                                            <asp:BoundField DataField="FECHA_TERMINO" HeaderText="Fecha Termino" SortExpression="FECHA_TERMINO" />
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                            </asp:Panel>
                        </asp:Panel>

                        <asp:Panel ID="panelPropietario" runat="server" Visible="false">
                            <div class="form-inline my-4 my-lg-0">
                                <div class="md-form form-sm my-0" style="margin-right: 2%">
                                    <div style="display: inline-block;">
                                        <asp:TextBox ID="txtSearchPropietario" runat="server" CssClass="form-control" placeholder="Search"
                                            onkeyup="formatCliente(this)"></asp:TextBox>
                                    </div>
                                    <div style="display: inline-block;">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red"
                                            ControlToValidate="txtSearchPropietario" Display="Dynamic" ValidationGroup="searchPropietario"></asp:RequiredFieldValidator>
                                    </div>
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnSearchPropietario" runat="server" Text="Search" CssClass="btn btn-outline-primary btn-rounded waves-effect"
                                        ValidationGroup="searchPropietario" OnClick="btnSearchPropietario_Click" />
                                </div>
                                <asp:Button ID="btnRegistroPropietario" runat="server" Text="Registrar Propietario" class="btn btn-outline-primary btn-rounded waves-effect"
                                    CausesValidation="false" OnClick="btnRegistroPropietario_Click" />
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnModificarPropietario" runat="server" Text="Modificar Propietario" class="btn btn-outline-primary btn-rounded waves-effect"
                                    CausesValidation="false" OnClick="btnModificarPropietario_Click" Enabled="false" />
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnEliminarPropietario" runat="server" Text="Eliminar Propietario" class="btn btn-outline-primary btn-rounded waves-effect"
                                    CausesValidation="false" OnClick="btnEliminarPropietario_Click" Enabled="false" />
                            </div>
                            <br />
                            <asp:Button ID="btnAsignarMulta" runat="server" Text="Asignar Multa" class="btn btn-outline-primary btn-rounded waves-effect"
                                CausesValidation="false" OnClick="btnAsignarMulta_Click" Enabled="false" />
                            <br />
                            <br />

                            <asp:Label ID="Label5" runat="server" Text="Listado de Propietarios" ForeColor="Black"></asp:Label><br />
                            <asp:Label ID="lbErrorSearchPropietario" runat="server" Text="No se Encontraron Datos" Visible="false"></asp:Label>
                            <asp:GridView ID="grPropietarios" runat="server" CssClass="table table-striped w-auto" AutoGenerateColumns="False" DataKeyNames="_ID_PERSONA"
                                Font-Size="10pt" AllowPaging="True" OnSelectedIndexChanged="grPropietarios_SelectedIndexChanged" PageSize="6"
                                OnPageIndexChanging="grPropietarios_PageIndexChanging">
                                <Columns>
                                    <asp:BoundField DataField="_ID_PERSONA" HeaderText="Id" SortExpression="ID_PERSONA" />
                                    <asp:BoundField DataField="_FK_RUT" HeaderText="Rut" SortExpression="_FK_RUT" />
                                    <asp:BoundField DataField="_NOMBRE_PERSONA" HeaderText="Nombre" SortExpression="_NOMBRE_PERSONA" />
                                    <asp:BoundField DataField="_APELLIDO_PERSONA" HeaderText="Apellido" SortExpression="_APELLIDO_PERSONA" />
                                    <asp:BoundField DataField="_NOMBRE_CONDOMINIO" HeaderText="Condominio" SortExpression="_NOMBRE_CONDOMINIO" />
                                    <asp:BoundField DataField="_NOMBRE_EDIFICIO" HeaderText="Edificio" SortExpression="_NOMBRE_EDIFICIO" />
                                    <asp:BoundField DataField="_NUMERO_DEP" HeaderText="Dep" SortExpression="_NUMERO_DEP" />
                                    <asp:CheckBoxField DataField="_ESTADO_PERSONA" HeaderText="Estado" SortExpression="_ESTADO_PERSONA" />
                                    <asp:CommandField ShowSelectButton="True" HeaderText="Ver Mas" />
                                </Columns>
                            </asp:GridView>

                            <asp:Panel ID="panelDetalle" runat="server" Visible="false">
                                <asp:Label ID="Label6" runat="server" Text="Detalle Propietario" ForeColor="Black"></asp:Label><br />
                                <div class="col">
                                    <div class="form-group row">
                                        <asp:Label ID="Label24" runat="server" Text="Id: " CssClass="col-sm-4 col-form-label"></asp:Label>
                                        <asp:Label ID="lbDId" runat="server" Text="" CssClass="col-sm-4 col-form-label"></asp:Label>
                                    </div>
                                </div>
                                <div class="col">
                                    <div class="form-group row">
                                        <asp:Label ID="Label7" runat="server" Text="Rut: " CssClass="col-sm-4 col-form-label"></asp:Label>
                                        <asp:Label ID="lbDRut" runat="server" Text="" CssClass="col-sm-4 col-form-label"></asp:Label>
                                    </div>
                                </div>
                                <div class="col">
                                    <div class="form-group row">
                                        <asp:Label ID="Label8" runat="server" Text="Nombre: " CssClass="col-sm-4 col-form-label"></asp:Label>
                                        <asp:Label ID="lbDNombre" runat="server" Text="" CssClass="col-sm-4 col-form-label"></asp:Label>
                                    </div>
                                </div>
                                <div class="col">
                                    <div class="form-group row">
                                        <asp:Label ID="Label12" runat="server" Text="Telefono: " CssClass="col-sm-4 col-form-label"></asp:Label>
                                        <asp:Label ID="lbDTelefono" runat="server" Text="" CssClass="col-sm-4 col-form-label"></asp:Label>
                                    </div>
                                </div>
                                <div class="col">
                                    <div class="form-group row">
                                        <asp:Label ID="Label14" runat="server" Text="Correo: " CssClass="col-sm-4 col-form-label"></asp:Label>
                                        <asp:Label ID="lbDCorreo" runat="server" Text="" CssClass="col-sm-4 col-form-label"></asp:Label>
                                    </div>
                                </div>
                                <div class="col">
                                    <div class="form-group row">
                                        <asp:Label ID="Label22" runat="server" Text="Estado: " CssClass="col-sm-4 col-form-label"></asp:Label>
                                        <asp:Label ID="lbDEstado" runat="server" Text="" CssClass="col-sm-4 col-form-label"></asp:Label>
                                    </div>
                                </div>
                                <div class="col">
                                    <div class="form-group row">
                                        <asp:Label ID="Label20" runat="server" Text="Condominio: " CssClass="col-sm-4 col-form-label"></asp:Label>
                                        <asp:Label ID="lbDCondominio" runat="server" Text="" CssClass="col-sm-4 col-form-label"></asp:Label>
                                    </div>
                                </div>
                                <div class="col">
                                    <div class="form-group row">
                                        <asp:Label ID="Label18" runat="server" Text="Edificio: " CssClass="col-sm-4 col-form-label"></asp:Label>
                                        <asp:Label ID="lbDEdificio" runat="server" Text="" CssClass="col-sm-4 col-form-label"></asp:Label>
                                    </div>
                                </div>
                                <div class="col">
                                    <div class="form-group row">
                                        <asp:Label ID="Label16" runat="server" Text="Departamento: " CssClass="col-sm-4 col-form-label"></asp:Label>
                                        <asp:Label ID="lbDep" runat="server" Text="" CssClass="col-sm-4 col-form-label"></asp:Label>
                                    </div>
                                </div>
                                <div class="col">
                                    <div class="form-group row">
                                        <asp:Label ID="Label11" runat="server" Text="Luz: " CssClass="col-sm-4 col-form-label"></asp:Label>
                                        <asp:Label ID="lbDLuz" runat="server" Text="" CssClass="col-sm-4 col-form-label"></asp:Label>
                                    </div>
                                </div>
                            </asp:Panel>
                        </asp:Panel>

                        <asp:Panel ID="panelGastos" runat="server" Visible="false">
                            <div class="form-inline my-4 my-lg-0">
                                <div class="md-form form-sm my-0" style="margin-right: 2%">
                                    <div style="display: inline-block;">
                                        <asp:TextBox ID="txtSearchGasto" runat="server" CssClass="form-control" placeholder="Search"></asp:TextBox>
                                    </div>
                                    <div style="display: inline-block;">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red"
                                            ControlToValidate="txtSearchGasto" Display="Dynamic" ValidationGroup="searchGasto"></asp:RequiredFieldValidator>
                                    </div>
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnSearchGasto" runat="server" Text="Search" CssClass="btn btn-outline-primary btn-rounded waves-effect"
                                        ValidationGroup="searchGasto" OnClick="btnSearchGasto_Click" />
                                </div>
                            </div>
                            <br />

                            <div class="form-inline my-4 my-lg-0">
                                <div class="md-form form-sm my-0" style="width: 50%">
                                    <asp:DropDownList ID="dplCondominioGasto" runat="server" CssClass="form-control" AutoPostBack="true"
                                        OnSelectedIndexChanged="dplCondominioGasto_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <br />
                            <br />

                            <asp:Label ID="Label15" runat="server" Text="Lista de Gastos Comunes" ForeColor="Black"></asp:Label><br />
                            <asp:Label ID="lbErrorSearchGasto" runat="server" Text="No se Encontraron Datos" Visible="false"></asp:Label>
                            <asp:GridView ID="grGastos" runat="server" CssClass="table table-striped w-auto" AutoGenerateColumns="False" DataKeyNames="_ID_GASTOS"
                                Font-Size="10pt" AllowPaging="True" OnSelectedIndexChanged="grGastos_SelectedIndexChanged" PageSize="6"
                                OnPageIndexChanging="grGastos_PageIndexChanging">
                                <Columns>
                                    <asp:BoundField DataField="_NOMBRE_EDIFICIO" HeaderText="Edificio" SortExpression="_NOMBRE_EDIFICIO" />
                                    <asp:BoundField DataField="_GASTO_CONSERJE" HeaderText="Conserje" SortExpression="_GASTO_CONSERJE" />
                                    <asp:BoundField DataField="_GASTO_GUARDIA" HeaderText="Guardia" SortExpression="_GASTO_GUARDIA" />
                                    <asp:BoundField DataField="_GASTO_MANTENCION_AREAS" HeaderText="Mantención Areas" SortExpression="_GASTO_MANTENCION_AREAS" />
                                    <asp:BoundField DataField="_GASTO_CAMARAS" HeaderText="Camaras" SortExpression="_GASTO_CAMARAS" />
                                    <asp:BoundField DataField="_GASTO_ARTICULOS_ASEO" HeaderText="Art. Aseo" SortExpression="_GASTO_ARTICULOS_ASEO" />
                                    <asp:BoundField DataField="_GASTOS_ASEO" HeaderText="Aseo" SortExpression="_GASTOS_ASEO" />
                                    <asp:BoundField DataField="_GASTO_ASCENSOR" HeaderText="Ascensor" SortExpression="_GASTO_ASCENSOR" />
                                    <asp:BoundField DataField="_GASTO_AGUA_CALIENTE" HeaderText="Agua Caliente" SortExpression="_GASTO_AGUA_CALIENTE" />
                                    <asp:BoundField DataField="_GASTO_OTRO" HeaderText="Otros" SortExpression="_GASTO_OTRO" />
                                    <asp:BoundField DataField="_TOTAL_GASTO" HeaderText="Total" SortExpression="_TOTAL_GASTO" />
                                    <asp:CommandField ShowSelectButton="True" HeaderText="Modificar" />
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>

                        <asp:Panel ID="panelCentro" runat="server" Visible="false">
                            <div class="form-inline my-4 my-lg-0">
                                <div class="md-form form-sm my-0" style="margin-right: 2%">
                                    <div style="display: inline-block;">
                                        <asp:TextBox ID="txtSearchCentro" runat="server" CssClass="form-control" placeholder="Search"></asp:TextBox>
                                    </div>
                                    <div style="display: inline-block;">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red"
                                            ControlToValidate="txtSearchCentro" Display="Dynamic" ValidationGroup="searchCentro"></asp:RequiredFieldValidator>
                                    </div>
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnSearchCentro" runat="server" Text="Search" CssClass="btn btn-outline-primary btn-rounded waves-effect"
                                        ValidationGroup="searchCentro" OnClick="btnSearchCentro_Click" />
                                </div>
                                <asp:Button ID="btnCrearCentro" runat="server" Text="Registro Centro" class="btn btn-outline-primary btn-rounded waves-effect"
                                    CausesValidation="false" OnClick="btnCrearCentro_Click" />
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnModificarCentro" runat="server" Text="Modificar Centro" class="btn btn-outline-primary btn-rounded waves-effect"
                                    CausesValidation="false" OnClick="btnModificarCentro_Click" Enabled="false" />
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnModificarHorario" runat="server" Text="Modificar Horario" class="btn btn-outline-primary btn-rounded waves-effect"
                                    CausesValidation="false" OnClick="btnModificarHorario_Click" Enabled="false" />
                            </div>
                            <br />

                            <div class="form-inline my-4 my-lg-0">
                                <div class="md-form form-sm my-0" style="width: 50%">
                                    <asp:DropDownList ID="dplCondominioCentro" runat="server" CssClass="form-control" AutoPostBack="true"
                                        OnSelectedIndexChanged="dplCondominioCentro_SelectedIndexChanged1">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <br />
                            <br />

                            <asp:Label ID="Label28" runat="server" Text="Lista de Centros" ForeColor="Black"></asp:Label><br />
                            <asp:Label ID="lbErrorSearchCentro" runat="server" Text="No se Encontraron Datos" Visible="false"></asp:Label>
                            <asp:Label ID="lbErrorCentro" runat="server" Text="Condominio No Posee Centros" ForeColor="Red" Visible="false"></asp:Label><br />
                            <asp:GridView ID="grCentros" runat="server" CssClass="table table-striped w-auto" AutoGenerateColumns="False" DataKeyNames="_ID_CENTRO"
                                Font-Size="10pt" AllowPaging="True" OnSelectedIndexChanged="grCentros_SelectedIndexChanged1" PageSize="6"
                                OnPageIndexChanging="grCentros_PageIndexChanging1">
                                <Columns>
                                    <asp:BoundField DataField="_ID_CENTRO" HeaderText="Id" SortExpression="_ID_CENTRO" />
                                    <asp:BoundField DataField="_NOMBRE_CENTRO" HeaderText="Centro" SortExpression="_NOMBRE_CENTRO" />
                                    <asp:BoundField DataField="_NOMBRE_TIPO_CENTRO" HeaderText="Tipo" SortExpression="_NOMBRE_TIPO_CENTRO" />
                                    <asp:BoundField DataField="_NOMBRE_CONDOMINIO" HeaderText="Condominio" SortExpression="_NOMBRE_CONDOMINIO" />
                                    <asp:BoundField DataField="_NOMBRE_EDIFICIO" HeaderText="Edificio" SortExpression="_NOMBRE_EDIFICIO" />
                                    <asp:BoundField DataField="_COSTO" HeaderText="Coto" SortExpression="_COSTO" />
                                    <asp:CommandField ShowSelectButton="True" HeaderText="Horario" />
                                </Columns>
                            </asp:GridView>

                            <asp:Panel ID="panelHorario" runat="server" Visible="false">
                                <asp:Label ID="lbHorario" runat="server" Text="Horario Centro" ForeColor="Black"></asp:Label><br />
                                <asp:Label ID="lbErrorHorario" runat="server" Text="Centro no Posee Horario" ForeColor="Red" Visible="false"></asp:Label><br />
                                <asp:GridView ID="grHorario" runat="server" CssClass="table table-striped w-auto" AutoGenerateColumns="False"
                                    DataKeyNames="ID_HORARIO_CENTRO" Font-Size="10pt" AllowPaging="True" PageSize="6" OnPageIndexChanging="grHorario_PageIndexChanging">
                                    <Columns>
                                        <asp:BoundField DataField="DIA_HORARIO" HeaderText="Dia" SortExpression="DIA_HORARIO" />
                                        <asp:BoundField DataField="HORARIO_COMPLETO" HeaderText="Horario" SortExpression="HORARIO_COMPLETO" />
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                        </asp:Panel>

                        <asp:Panel ID="panelMensajes" runat="server" Visible="false">
                            <div class="row">
                                <div class="col-4">
                                    <div class="list-group" id="list-tab" role="tablist">
                                        <a class="list-group-item list-group-item-action active" id="list-home-list" data-toggle="list" href="#list-home"
                                            role="tab" aria-controls="home">
                                            <div class="d-flex w-100 justify-content-between">
                                                <h5 class="mb-2 h5">List group item heading</h5>
                                                <small>3 days ago</small>
                                            </div>
                                            <p class="mb-2">
                                                Donec id elit non mi porta gravida at eget metus. Maecenas sed diam eget risus varius blandit.
                                            </p>
                                            <small>Donec id elit non mi porta.</small>
                                        </a>
                                        <a class="list-group-item list-group-item-action" id="list-profile-list" data-toggle="list" href="#list-profile"
                                            role="tab" aria-controls="profile">Profile</a>
                                        <a class="list-group-item list-group-item-action" id="list-messages-list" data-toggle="list" href="#list-messages"
                                            role="tab" aria-controls="messages">Messages</a>
                                        <a class="list-group-item list-group-item-action" id="list-settings-list" data-toggle="list" href="#list-settings"
                                            role="tab" aria-controls="settings">Settings</a>
                                    </div>
                                </div>
                                <div class="col-8">
                                    <div class="tab-content" id="nav-tabContent">
                                        <div class="tab-pane fade show active" id="list-home" role="tabpanel" aria-labelledby="list-home-list">
                                            Velit aute mollit ipsum ad dolor consectetur nulla officia culpa adipisicing exercitation fugiat
                                            tempor. Voluptate deserunt sit sunt nisi aliqua fugiat proident ea ut. Mollit voluptate reprehenderit
                                            occaecat nisi ad non minim tempor sunt voluptate consectetur exercitation id ut nulla. Ea et fugiat
                                            aliquip nostrud sunt incididunt consectetur culpa aliquip eiusmod dolor. Anim ad Lorem aliqua in
                                            cupidatat nisi enim eu nostrud do aliquip veniam minim.
                                        </div>
                                        <div class="tab-pane fade" id="list-profile" role="tabpanel" aria-labelledby="list-profile-list">
                                            Cupidatat quis ad sint excepteur laborum in esse qui. Et excepteur consectetur ex nisi eu do cillum ad
                                            laborum. Mollit et eu officia dolore sunt Lorem culpa qui commodo velit ex amet id ex. Officia anim
                                            incididunt laboris deserunt anim aute dolor incididunt veniam aute dolore do exercitation. Dolor nisi
                                            culpa ex ad irure in elit eu dolore. Ad laboris ipsum reprehenderit irure non commodo enim culpa
                                            commodo veniam incididunt veniam ad.
                                        </div>
                                        <div class="tab-pane fade" id="list-messages" role="tabpanel" aria-labelledby="list-messages-list">
                                            Ut ut do pariatur aliquip aliqua aliquip exercitation do nostrud commodo reprehenderit aute ipsum
                                            voluptate. Irure Lorem et laboris nostrud amet cupidatat cupidatat anim do ut velit mollit consequat
                                            enim tempor. Consectetur est minim nostrud nostrud consectetur irure labore voluptate irure. Ipsum id
                                            Lorem sit sint voluptate est pariatur eu ad cupidatat et deserunt culpa sit eiusmod deserunt.
                                            Consectetur et fugiat anim do eiusmod aliquip nulla laborum elit adipisicing pariatur cillum.
                                        </div>
                                        <div class="tab-pane fade" id="list-settings" role="tabpanel" aria-labelledby="list-settings-list">
                                            Irure enim occaecat labore sit qui aliquip reprehenderit amet velit. Deserunt ullamco ex elit nostrud
                                            ut dolore nisi officia magna sit occaecat laboris sunt dolor. Nisi eu minim cillum occaecat aute est
                                            cupidatat aliqua labore aute occaecat ea aliquip sunt amet. Aute mollit dolor ut exercitation irure
                                            commodo non amet consectetur quis amet culpa. Quis ullamco nisi amet qui aute irure eu. Magna labore
                                            dolor quis ex labore id nostrud deserunt dolor eiusmod eu pariatur culpa mollit in irure.
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <asp:GridView ID="GridView2" runat="server">
                                <Columns>
                                    <asp:BoundField />
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>

                        <asp:Panel ID="panelAvisos" runat="server" Visible="false">
                            Irure enim occaecat labore sit qui aliquip reprehenderit amet velit. Deserunt ullamco ex elit nostrud
                            ut dolore nisi officia magna sit occaecat laboris sunt dolor. Nisi eu minim cillum occaecat aute est
                            cupidatat aliqua labore aute occaecat ea aliquip sunt amet. Aute mollit dolor ut exercitation irure
                            commodo non amet consectetur quis amet culpa. Quis ullamco nisi amet qui aute irure eu. Magna labore
                            dolor quis ex labore id nostrud deserunt dolor eiusmod eu pariatur culpa mollit in irure.
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>