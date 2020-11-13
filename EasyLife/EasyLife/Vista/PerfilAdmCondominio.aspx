<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="PerfilAdmCondominio.aspx.cs" Inherits="EasyLife.Vista.PerfilAdmCondominio" %>

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
                    <div class="list-group" id="list-tab" role="tablist">
                        <asp:Button ID="btnDatosUsuario" runat="server" Text="Mis Datos" CssClass="list-group-item list-group-item-action" OnClick="btnDatosUsuario_Click"
                            BackColor="LightBlue" />
                        <asp:Button ID="btnCondominio" runat="server" Text="Condominio" CssClass="list-group-item list-group-item-action" OnClick="btnCondominio_Click" />
                        <asp:Button ID="btnConserjes" runat="server" Text="Conserjes" CssClass="list-group-item list-group-item-action" OnClick="btnConserjes_Click" />
                        <asp:Button ID="btnPropietarios" runat="server" Text="Propietarios" CssClass="list-group-item list-group-item-action" OnClick="btnPropietarios_Click" />
                        <asp:Button ID="btnGastos" runat="server" Text="Gastos Comúnes" CssClass="list-group-item list-group-item-action" OnClick="btnGastos_Click" />
                        <asp:Button ID="btnCentro" runat="server" Text="Centros" CssClass="list-group-item list-group-item-action" OnClick="btnCentro_Click" />
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

                                <div class="form-group row">
                                    <label for="inputEmail3MD" class="col-sm-2 col-form-label">Condominios a Cargo</label>
                                    <div class="col-sm-10">
                                        <div class="md-form mt-0" style="width: 50%">
                                            <asp:ListBox ID="listCondominio" runat="server"></asp:ListBox>
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

                        <asp:Panel ID="panelCondominio" runat="server" Visible="false">
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

                            <asp:Label ID="lbCondominio" runat="server" Text="" CssClass="form-control" Visible="false" Width="20%"></asp:Label>
                            <br />
                            <br />

                            <asp:Label ID="Label3" runat="server" Text="Lista de Condominios" ForeColor="Black"></asp:Label><br />
                            <asp:Label ID="lbErrorSearchCondominio" runat="server" Text="No se Encontraron Datos" Visible="false"></asp:Label>
                            <asp:GridView ID="grCondominio" runat="server" CssClass="table table-striped w-auto" AutoGenerateColumns="False" DataKeyNames="_ID_CONDOMINIO"
                                Font-Size="10pt" OnSelectedIndexChanged="grCondominio_SelectedIndexChanged" AllowPaging="true" PageSize="6"
                                OnPageIndexChanging="grCondominio_PageIndexChanging">
                                <Columns>
                                    <asp:BoundField DataField="_ID_CONDOMINIO" HeaderText="Id" SortExpression="_ID_CONDOMINIO" />
                                    <asp:BoundField DataField="_NOMBRE_CONDOMINIO" HeaderText="Nombre" SortExpression="_NOMBRE_CONDOMINIO" />
                                    <asp:BoundField DataField="_PRECIO_EST" HeaderText="Precio Est" SortExpression="_PRECIO_EST" />
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
                                    Font-Size="10pt" OnSelectedIndexChanged="grEdificio_SelectedIndexChanged" AllowPaging="true" PageSize="6"
                                    OnPageIndexChanging="grEdificio_PageIndexChanging">
                                    <Columns>
                                        <asp:BoundField DataField="_ID_EDIFICIO" HeaderText="Id" SortExpression="_ID_EDIFICIO" />
                                        <asp:BoundField DataField="_NOMBRE_EDIFICIO" HeaderText="Nombre" SortExpression="_NOMBRE_EDIFICIO" />
                                        <asp:BoundField DataField="_CANTIDAD_PISO" HeaderText="Pisos" SortExpression="_CANTIDAD_PISO" />
                                        <asp:BoundField DataField="_CANTIDAD_DEPARTAMENTO" HeaderText="Cant Dep" SortExpression="_CANTIDAD_DEPARTAMENTO" />
                                        <asp:BoundField DataField="_CODIGO_LUZ_E" HeaderText="Luz" SortExpression="_CODIGO_LUZ_E" />
                                        <asp:BoundField DataField="_TOTAL_GASTO" HeaderText="Gasto Común" SortExpression="_TOTAL_GASTO" />
                                        <asp:CommandField ShowSelectButton="True" HeaderText="Ver Mas" />
                                    </Columns>
                                </asp:GridView>
                                <br />
                            </asp:Panel>

                            <asp:Panel ID="panelDep" runat="server" Visible="false">
                                <asp:Label ID="Label2" runat="server" Text="Lista de Departamentos" ForeColor="Black"></asp:Label><br />
                                <asp:GridView ID="grDep" runat="server" CssClass="table table-striped w-auto" AutoGenerateColumns="False" DataKeyNames="ID_DEPARTAMENTO"
                                    Font-Size="10pt" OnSelectedIndexChanged="grDep_SelectedIndexChanged" AllowPaging="true" PageSize="6"
                                    OnPageIndexChanging="grDep_PageIndexChanging">
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

                                <asp:Label ID="Label4" runat="server" Text="Lista de Multas" ForeColor="Black"></asp:Label><br />
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

                        <asp:Panel ID="panelConserje" runat="server" Visible="false">
                            <div class="form-inline my-3 my-lg-0">
                                <div class="md-form form-sm my-0" style="margin-right: 2%">
                                    <div style="display: inline-block;">
                                        <asp:TextBox ID="txtSearchConserje" runat="server" CssClass="form-control" placeholder="Search"
                                            onkeyup="formatCliente(this)"></asp:TextBox>
                                    </div>
                                    <div style="display: inline-block;">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red"
                                            ControlToValidate="txtSearchConserje" Display="Dynamic" ValidationGroup="searchConserje"></asp:RequiredFieldValidator>
                                    </div>
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnSearchConserje" runat="server" Text="Search" CssClass="btn btn-outline-primary btn-rounded waves-effect"
                                        ValidationGroup="searchConserje" OnClick="btnSearchConserje_Click" />
                                </div>
                            </div>
                            <br />
                            <asp:Button ID="btnRegistroConserje" runat="server" Text="Registrar Conserje" CssClass="btn btn-outline-primary btn-rounded waves-effect"
                                OnClick="btnRegistroConserje_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnModificarConserje" runat="server" Text="Modificar Conserje" CssClass="btn btn-outline-primary btn-rounded waves-effect"
                                OnClick="btnModificarConserje_Click" Enabled="false" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnEliminarConserje" runat="server" Text="Eliminar Conserje" CssClass="btn btn-outline-primary btn-rounded waves-effect"
                                OnClick="btnEliminarConserje_Click" Enabled="false" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnAsignarTurno" runat="server" Text="Asignar Turno Conserje" class="btn btn-outline-primary btn-rounded waves-effect"
                                CausesValidation="false" OnClick="btnAsignarTurno_Click" Enabled="false" />
                            <br />
                            <br />

                            <div class="form-inline my-4 my-lg-0">
                                <div class="md-form form-sm my-0" style="width: 50%">
                                    <asp:DropDownList ID="dplCondominioConserje" runat="server" CssClass="form-control" AutoPostBack="true"
                                        OnSelectedIndexChanged="dplCondominioConserje_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <br />
                            <br />

                            <asp:Label ID="Label5" runat="server" Text="Lista de Conserjes" ForeColor="Black"></asp:Label><br />
                            <asp:Label ID="lbErrorConserje" runat="server" Text="Condominio no Posee Conserje Asignado" Visible="false"></asp:Label>
                            <asp:Label ID="lbErrorSearchConserje" runat="server" Text="No se Encontraron Datos" Visible="false"></asp:Label>
                            <asp:GridView ID="grConserje" runat="server" CssClass="table table-striped w-auto" AutoGenerateColumns="False" DataKeyNames="_ID_PERSONA"
                                Font-Size="10pt" OnSelectedIndexChanged="grConserje_SelectedIndexChanged" AllowPaging="true" PageSize="6"
                                OnPageIndexChanging="grConserje_PageIndexChanging">
                                <Columns>
                                    <asp:BoundField DataField="_ID_PERSONA" HeaderText="Id" SortExpression="_ID_PERSONA" />
                                    <asp:BoundField DataField="_NOMBRE_CONDOMINIO" HeaderText="Condominio" SortExpression="_NOMBRE_CONDOMINIO" />
                                    <asp:BoundField DataField="_FK_RUT" HeaderText="Rut" SortExpression="_FK_RUT" />
                                    <asp:BoundField DataField="_NOMBRE_PERSONA" HeaderText="Nombre" SortExpression="_NOMBRE_PERSONA" />
                                    <asp:BoundField DataField="_APELLIDO_PERSONA" HeaderText="Apellido" SortExpression="_APELLIDO_PERSONA" />
                                    <asp:BoundField DataField="_TELEFONO_PERSONA" HeaderText="Telefono" SortExpression="_TELEFONO_PERSONA" />
                                    <asp:BoundField DataField="_CORREO_PERSONA" HeaderText="Coreo" SortExpression="_CORREO_PERSONA" />
                                    <asp:CheckBoxField DataField="_ESTADO_PERSONA" HeaderText="Estado" SortExpression="_ESTADO_PERSONA" />
                                    <asp:CommandField ShowSelectButton="True" HeaderText="Turnos" />
                                </Columns>
                            </asp:GridView>

                            <asp:Panel ID="panelTurnoConserje" runat="server">
                                <asp:Label ID="Label23" runat="server" Text="Turno " CssClass="col-sm-4 col-form-label"></asp:Label><br />
                                <asp:Label ID="lbConserje" runat="server" Text="Conserje no Posee Turnos Asignados" CssClass="col-sm-4 col-form-label" Visible="false"></asp:Label>
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

                        <asp:Panel ID="panelPropietario" runat="server" Visible="false">
                            <div class="form-inline my-3 my-lg-0">
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
                            </div>
                            <br />
                            <asp:Button ID="btnRegistroPropietario" runat="server" Text="Registrar Propietario"
                                CssClass="btn btn-outline-primary btn-rounded waves-effect" OnClick="btnRegistroPropietario_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnModificarPropietario" runat="server" Text="Modificar Propietario"
                                CssClass="btn btn-outline-primary btn-rounded waves-effect" OnClick="btnModificarPropietario_Click" Enabled="false" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnEliminarPropietario" runat="server" Text="Eliminar Propietario" class="btn btn-outline-primary btn-rounded waves-effect"
                                CausesValidation="false" OnClick="btnEliminarPropietario_Click" Enabled="false" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                           <asp:Button ID="btnAsignarMulta" runat="server" Text="Asignar Multa" class="btn btn-outline-primary btn-rounded waves-effect"
                               CausesValidation="false" OnClick="btnAsignarMulta_Click" Enabled="false" Visible="false" />
                            <br />
                            <br />

                            <div class="form-inline my-4 my-lg-0">
                                <div class="md-form form-sm my-0" style="width: 50%">
                                    <asp:DropDownList ID="dplCondominioPropietario" runat="server" CssClass="form-control" AutoPostBack="true"
                                        OnSelectedIndexChanged="dplCondominioPropietario_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <br />
                            <br />

                            <asp:Label ID="Label19" runat="server" Text="Lista de Propietarios" ForeColor="Black"></asp:Label><br />
                            <asp:Label ID="lbErrorPropietario" runat="server" Text="Condominio no Posee Propietarios" Visible="false"></asp:Label>
                            <asp:Label ID="lbErrorSearchPropietario" runat="server" Text="No se Encontraron Datos" Visible="false"></asp:Label>
                            <asp:GridView ID="grPropietarios" runat="server" CssClass="table table-striped w-auto" AutoGenerateColumns="False" DataKeyNames="_ID_PERSONA"
                                Font-Size="10pt" OnSelectedIndexChanged="grPropietarios_SelectedIndexChanged" AllowPaging="true" PageSize="6"
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

                                <%-- Lista de Elementos--%>
                                <asp:Label ID="lbElementos" runat="server" Text="Lista Elementos" ForeColor="Black" Visible="false"></asp:Label><br />
                                <asp:Label ID="lbErrorElemento" runat="server" Text="No Posee Elementos Asignados" ForeColor="Red" Visible="false"></asp:Label><br />
                                <asp:GridView ID="grElementos" runat="server" CssClass="table table-striped w-auto" AutoGenerateColumns="False" DataKeyNames="_ID_EDIFICIO"
                                    Font-Size="10pt" AllowPaging="true" PageSize="6" OnPageIndexChanging="grElementos_PageIndexChanging" Visible="false">
                                    <Columns>
                                        <asp:BoundField DataField="_NOMBRE_EDIFICIO" HeaderText="Nombre" SortExpression="_NOMBRE_EDIFICIO" />
                                        <asp:BoundField DataField="_DEP" HeaderText="Departamento" SortExpression="_DEP" />
                                        <asp:BoundField DataField="_TIPO" HeaderText="Tipo" SortExpression="_TIPO" />
                                        <asp:BoundField DataField="_NUMERO_ELEMENTO" HeaderText="Numero" SortExpression="_NUMERO_ELEMENTO" />
                                        <asp:BoundField DataField="_DIMENSION" HeaderText="Dimensión" SortExpression="_DIMENSION" />
                                        <asp:BoundField DataField="_PRECIO" HeaderText="Precio" SortExpression="_PRECIO" />
                                    </Columns>
                                </asp:GridView>

                                <asp:Button ID="btnAsignarLuz" runat="server" Text="Asignar Luz" class="btn btn-outline-primary btn-rounded waves-effect"
                                    CausesValidation="false" OnClick="btnAsignarLuz_Click" Enabled="false" />
                            </asp:Panel>
                        </asp:Panel>

                        <asp:Panel ID="panelGastos" runat="server" Visible="false">
                            <div class="form-inline my-4 my-lg-0">
                                <div class="md-form form-sm my-0" style="margin-right: 2%">
                                    <div style="display: inline-block;">
                                        <asp:TextBox ID="txtSearchGasto" runat="server" CssClass="form-control" placeholder="Search"></asp:TextBox>
                                    </div>
                                    <div style="display: inline-block;">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red"
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
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red"
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
                                        OnSelectedIndexChanged="dplCondominioCentro_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <br />
                            <br />

                            <asp:Label ID="Label28" runat="server" Text="Lista de Centros" ForeColor="Black"></asp:Label><br />
                            <asp:Label ID="lbErrorSearchCentro" runat="server" Text="No se Encontraron Datos" Visible="false"></asp:Label>
                            <asp:Label ID="lbErrorCentro" runat="server" Text="Condominio No Posee Centros" ForeColor="Red" Visible="false"></asp:Label><br />
                            <asp:GridView ID="grCentros" runat="server" CssClass="table table-striped w-auto" AutoGenerateColumns="False" DataKeyNames="_ID_CENTRO"
                                Font-Size="10pt" AllowPaging="True" OnSelectedIndexChanged="grCentros_SelectedIndexChanged" PageSize="6"
                                OnPageIndexChanging="grCentros_PageIndexChanging">
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

                        <asp:Panel ID="panelAvisos" runat="server" Visible="false">
                            <div class="form-inline my-4 my-lg-0">
                                <div class="md-form form-sm my-0" style="margin-right: 2%">
                                    <div style="display: inline-block;">
                                        <asp:TextBox ID="txtSearchAviso" runat="server" CssClass="form-control" placeholder="Search"></asp:TextBox>
                                    </div>
                                    <div style="display: inline-block;">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ForeColor="Red"
                                            ControlToValidate="txtSearchAviso" Display="Dynamic" ValidationGroup="searchAviso"></asp:RequiredFieldValidator>
                                    </div>
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnSearchAviso" runat="server" Text="Search" CssClass="btn btn-outline-primary btn-rounded waves-effect"
                                        ValidationGroup="searchAviso" OnClick="btnSearchAviso_Click" />
                                </div>
                            </div>
                            <br />

                            <asp:Label ID="lbAviso" runat="server" Text="Lista de Avisos" ForeColor="Black"></asp:Label><br />
                            <asp:Label ID="lbErrorSearchAviso" runat="server" Text="No se Encontraron Datos" Visible="false"></asp:Label><br />
                            <asp:GridView ID="grAvisos" runat="server" CssClass="table table-striped w-auto" AutoGenerateColumns="False" DataKeyNames="_ID_MENSAJE"
                                Font-Size="10pt" AllowPaging="True" PageSize="6" OnPageIndexChanging="grAvisos_PageIndexChanging">
                                <Columns>
                                    <asp:BoundField DataField="_DESCRIPCION_TP" HeaderText="Tipo Mensaje" SortExpression="_DESCRIPCION_TP" />
                                    <asp:BoundField DataField="_EMISOR_MENSAJE" HeaderText="Emisor" SortExpression="_EMISOR_MENSAJE" />
                                    <asp:BoundField DataField="_DESTINATARIO_MENSAJE" HeaderText="Destinatario" SortExpression="_DESTINATARIO_MENSAJE" />
                                    <asp:BoundField DataField="_DESCRIPCION_MENSAJE" HeaderText="Descripcion" SortExpression="_DESCRIPCION_MENSAJE" />
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>