<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="PerfilPropietario.aspx.cs" Inherits="EasyLife.Vista.PerfilPropietario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Perfil</title>
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
                        <asp:Button ID="btnGastos" runat="server" Text="Gastos Comunes" CssClass="list-group-item list-group-item-action" OnClick="btnGastos_Click" />
                        <asp:Button ID="btnLuces" runat="server" Text="Luces" CssClass="list-group-item list-group-item-action" OnClick="btnLuces_Click" />
                        <asp:Button ID="btnMultas" runat="server" Text="Multas" CssClass="list-group-item list-group-item-action" OnClick="btnMultas_Click" />
                        <asp:Button ID="btnReserva" runat="server" Text="Reservas" CssClass="list-group-item list-group-item-action" OnClick="btnReserva_Click" />
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

                                <div class="form-group row">
                                    <label for="inputEmail3MD" class="col-sm-2 col-form-label">Departamento</label>
                                    <div class="col-sm-10">
                                        <div class="md-form mt-0" style="width: 60%">
                                            <asp:DropDownList ID="dplDepartamento" runat="server" CssClass="form-control" AutoPostBack="true"
                                                OnSelectedIndexChanged="dplDepartamento_SelectedIndexChanged" Width="50%">
                                                <asp:ListItem>Seleccione un Departamento</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group row">
                                    <label for="inputEmail3MD" class="col-sm-2 col-form-label">Luz</label>
                                    <div class="col-sm-10">
                                        <div class="md-form mt-0" style="width: 50%">
                                            <asp:Label ID="lbLuz" CssClass="form-control" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group row">
                                    <label for="inputEmail3MD" class="col-sm-2 col-form-label">Condominio</label>
                                    <div class="col-sm-10">
                                        <div class="md-form mt-0" style="width: 50%">
                                            <asp:Label ID="lbCondominio" CssClass="form-control" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group row">
                                    <label for="inputEmail3MD" class="col-sm-2 col-form-label">Edificio</label>
                                    <div class="col-sm-10">
                                        <div class="md-form mt-0" style="width: 50%">
                                            <asp:Label ID="lbEdificio" CssClass="form-control" runat="server" Text=""></asp:Label>
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

                        <asp:Panel ID="panelGastos" runat="server" Visible="false">
                            <div class="form-inline my-4 my-lg-0">
                                <asp:DropDownList ID="dplGastos" runat="server" CssClass="form-control" AutoPostBack="true"
                                    OnSelectedIndexChanged="dplGastos_SelectedIndexChanged" Width="40%">
                                </asp:DropDownList>
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnDescargarBoleta" runat="server" Text="Descargar Boleta" CssClass="btn btn-outline-primary btn-rounded waves-effect"
                                    Enabled="false" OnClick="btnDescargarBoleta_Click" target="_blank" />
                            </div>
                            <br />
                            <br />

                            <asp:Label ID="Label3" runat="server" Text="Lista Gastos Comúnes Pagados" ForeColor="Black"></asp:Label>
                            <asp:Label ID="lbErrorGasto" runat="server" Text="No se Registran Gastos Pagados" Visible="false"></asp:Label>
                            <asp:GridView ID="grGastos" runat="server" CssClass="table table-striped w-auto" AutoGenerateColumns="False" DataKeyNames="_ID_BOLETA"
                                Font-Size="10pt" OnSelectedIndexChanged="grGastos_SelectedIndexChanged" AllowPaging="true" PageSize="6"
                                OnPageIndexChanging="grGastos_PageIndexChanging">
                                <Columns>
                                    <asp:BoundField DataField="_FK_RUT" HeaderText="Rut" SortExpression="_FK_RUT" />
                                    <asp:BoundField DataField="_NOMBRE_EDIFICIO" HeaderText="Edificio" SortExpression="_NOMBRE_EDIFICIO" />
                                    <asp:BoundField DataField="_NUMERO_DEP" HeaderText="Departamento" SortExpression="_NUMERO_DEP" />
                                    <asp:BoundField DataField="_MULTA" HeaderText="Multa" SortExpression="_MULTA" />
                                    <asp:BoundField DataField="_TOTAL_GASTO" HeaderText="Total gastos" SortExpression="_TOTAL_GASTO" />
                                    <asp:BoundField DataField="_MES" HeaderText="Mes" SortExpression="_MES" />
                                    <asp:BoundField DataField="_AÑO" HeaderText="Año" SortExpression="_AÑO" />
                                    <asp:BoundField DataField="_COSTO_BOLETA" HeaderText="Total Boleta" SortExpression="_COSTO_BOLETA" />
                                    <asp:CommandField ShowSelectButton="true" HeaderText="Ver Detalle" />
                                </Columns>
                            </asp:GridView>

                            <asp:Panel ID="panelDetalleBoleta" runat="server" Visible="false">
                                <asp:Label ID="Label9" runat="server" Text="Detalle Boleta" ForeColor="Black"></asp:Label><br />
                                <div class="col">
                                    <div class="form-group row">
                                        <asp:Label ID="Label13" runat="server" Text="Codigo: " CssClass="col-sm-4 col-form-label"></asp:Label>
                                        <asp:Label ID="lbDCod" runat="server" Text="" CssClass="col-sm-4 col-form-label"></asp:Label>
                                    </div>
                                </div>
                                <div class="col">
                                    <div class="form-group row">
                                        <asp:Label ID="Label17" runat="server" Text="Persona: " CssClass="col-sm-4 col-form-label"></asp:Label>
                                        <asp:Label ID="lbDPersona" runat="server" Text="" CssClass="col-sm-4 col-form-label"></asp:Label>
                                    </div>
                                </div>
                                <div class="col">
                                    <div class="form-group row">
                                        <asp:Label ID="Label21" runat="server" Text="Edificio: " CssClass="col-sm-4 col-form-label"></asp:Label>
                                        <asp:Label ID="lbDEdificio" runat="server" Text="" CssClass="col-sm-4 col-form-label"></asp:Label>
                                    </div>
                                </div>
                                <div class="col">
                                    <div class="form-group row">
                                        <asp:Label ID="Label25" runat="server" Text="Departamento: " CssClass="col-sm-4 col-form-label"></asp:Label>
                                        <asp:Label ID="lbDDepartamento" runat="server" Text="" CssClass="col-sm-4 col-form-label"></asp:Label>
                                    </div>
                                </div>
                                <div class="col">
                                    <div class="form-group row">
                                        <asp:Label ID="Label10" runat="server" Text="Multa: " CssClass="col-sm-4 col-form-label"></asp:Label>
                                        <asp:Label ID="lbDMulta" runat="server" Text="" CssClass="col-sm-4 col-form-label"></asp:Label>
                                    </div>
                                </div>
                                <div class="col">
                                    <div class="form-group row">
                                        <asp:Label ID="Label2" runat="server" Text="Total Gastos: " CssClass="col-sm-4 col-form-label"></asp:Label>
                                        <asp:Label ID="lbDTotalG" runat="server" Text="" CssClass="col-sm-4 col-form-label"></asp:Label>
                                    </div>
                                </div>
                                <div class="col">
                                    <div class="form-group row">
                                        <asp:Label ID="Label4" runat="server" Text="Total Boleta: " CssClass="col-sm-4 col-form-label"></asp:Label>
                                        <asp:Label ID="lbDTotalB" runat="server" Text="" CssClass="col-sm-4 col-form-label"></asp:Label>
                                    </div>
                                </div>
                            </asp:Panel>
                        </asp:Panel>

                        <asp:Panel ID="panelLuces" runat="server" Visible="false">
                            <div class="form-inline my-4 my-lg-0">
                                <div class="md-form form-sm my-0" style="margin-right: 2%">
                                    <div style="display: inline-block;">
                                        <asp:TextBox ID="txtSearchLuz" runat="server" CssClass="form-control" placeholder="Search"></asp:TextBox>
                                    </div>
                                    <div style="display: inline-block;">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red"
                                            ControlToValidate="txtSearchLuz" Display="Dynamic" ValidationGroup="searchLuz"></asp:RequiredFieldValidator>
                                    </div>
                                    <asp:Button ID="btnSearchLuz" runat="server" Text="Search" CssClass="btn btn-outline-primary btn-rounded waves-effect"
                                        ValidationGroup="searchLuz" OnClick="btnSearchLuz_Click" />
                                </div>
                                <asp:Button ID="btnCrearControl" runat="server" Text="Registrar Control" class="btn btn-outline-primary btn-rounded waves-effect"
                                    CausesValidation="false" OnClick="btnCrearControl_Click" />
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnApagar" runat="server" Text="Apagar" class="btn btn-outline-primary btn-rounded waves-effect"
                                    CausesValidation="false" OnClick="btnApagar_Click" />
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnEncender" runat="server" Text="Encender" class="btn btn-outline-primary btn-rounded waves-effect"
                                    CausesValidation="false" OnClick="btnEncender_Click" />
                            </div>
                            <br />
                            <div class="form-inline my-4 my-lg-0">
                                <asp:DropDownList ID="dplDepartamentoLuz" runat="server" CssClass="form-control" AutoPostBack="true"
                                    OnSelectedIndexChanged="dplDepartamentoLuz_SelectedIndexChanged" Width="30%">
                                </asp:DropDownList>
                            </div>
                            <br />
                            <br />

                            <asp:Label ID="Label1" runat="server" Text="Lista Controles Iluminacion" ForeColor="Black"></asp:Label><br />
                            <asp:Label ID="lbErrorLuz" runat="server" Text="Deaprtamento no Posee Luz" Visible="false"></asp:Label>
                            <asp:Label ID="lbErrorSearchLuz" runat="server" Text="No se Encontraron Datos" Visible="false"></asp:Label>
                            <asp:GridView ID="grLuces" runat="server" CssClass="table table-striped w-auto" AutoGenerateColumns="False" DataKeyNames="_ID_CILUMINACION_D"
                                Font-Size="10pt" OnSelectedIndexChanged="grLuces_SelectedIndexChanged" AllowPaging="true" PageSize="6"
                                OnPageIndexChanging="grLuces_PageIndexChanging">
                                <Columns>
                                    <asp:BoundField DataField="_CODIGO_LUZ_D" HeaderText="Codigo Luz" SortExpression="_CODIGO_LUZ_D" />
                                    <asp:BoundField DataField="_NUMERO_DEP" HeaderText="Dep" SortExpression="_NUMERO_DEP" />
                                    <asp:BoundField DataField="_HORA_INICIO_D" HeaderText="Hora Inicio" SortExpression="_HORA_INICIO_D" />
                                    <asp:BoundField DataField="_HORA_TERMINO_D" HeaderText="Hora Termino" SortExpression="_HORA_TERMINO_D" />
                                    <asp:CheckBoxField DataField="_ESTADO_LUZ_CD" HeaderText="Estado Luz" SortExpression="_ESTADO_LUZ_CD" />
                                    <asp:CheckBoxField DataField="_ESTADO_CONTROL_D" HeaderText="Estado Control" SortExpression="_ESTADO_CONTROL_D" />
                                    <asp:CommandField ShowSelectButton="True" HeaderText="Modificar" />
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>

                        <asp:Panel ID="panelMulta" runat="server" Visible="false">
                            <div class="form-inline my-4 my-lg-0">
                                <asp:DropDownList ID="dplMulta" runat="server" CssClass="form-control" Width="40%" AutoPostBack="true"
                                    OnSelectedIndexChanged="dplMulta_SelectedIndexChanged">
                                </asp:DropDownList>
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnPagarMulta" runat="server" Text="Pagar Multas" class="btn btn-outline-primary btn-rounded waves-effect"
                                    CausesValidation="false" OnClick="btnPagarMulta_Click" />
                            </div>
                            <br />
                            <asp:Label ID="Label5" runat="server" Text="Lista de Multas" ForeColor="Black"></asp:Label><br />
                            <asp:Label ID="lbErrorMulta" runat="server" Text="Departamento no Posee Multas" Visible="false"></asp:Label>
                            <asp:GridView ID="grMulta" runat="server" CssClass="table table-striped w-auto" AutoGenerateColumns="False" DataKeyNames="_ID_MULTA"
                                Font-Size="10pt" AllowPaging="True" OnSelectedIndexChanged="grMulta_SelectedIndexChanged"
                                OnPageIndexChanging="grMulta_PageIndexChanging" PageSize="6">
                                <Columns>
                                    <asp:BoundField DataField="_NUMERO_DEP" HeaderText="Departamento" SortExpression="_NUMERO_DEP" />
                                    <asp:BoundField DataField="_MOTIVO" HeaderText="Motivo" SortExpression="_MOTIVO" />
                                    <asp:BoundField DataField="_COSTO_MULTA" HeaderText="Costo" SortExpression="_COSTO_MULTA" />
                                    <asp:CheckBoxField DataField="_ESTADO_MULTA" HeaderText="Estado" SortExpression="_ESTADO_MULTA" />
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>

                        <asp:Panel ID="panelReserva" runat="server" Visible="false">
                            <div class="form-inline my-4 my-lg-0">
                                <div class="md-form form-sm my-0" style="margin-right: 2%">
                                    <div style="display: inline-block;">
                                        <asp:TextBox ID="txtSearchReserva" runat="server" CssClass="form-control" placeholder="Search"></asp:TextBox>
                                    </div>
                                    <div style="display: inline-block;">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red"
                                            ControlToValidate="txtSearchReserva" Display="Dynamic" ValidationGroup="searchReserva"></asp:RequiredFieldValidator>
                                    </div>
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnSearchReserva" runat="server" Text="Search" CssClass="btn btn-outline-primary btn-rounded waves-effect"
                                        ValidationGroup="searchReserva" OnClick="btnSearchReserva_Click" />
                                </div>
                                <asp:Button ID="btnCrearReserva" runat="server" Text="Registrar Reserva" class="btn btn-outline-primary btn-rounded waves-effect"
                                    CausesValidation="false" OnClick="btnCrearReserva_Click" />
                            </div>
                            <br />
                            <div class="form-inline my-3 my-lg-0">
                                <asp:DropDownList ID="dplCentro" runat="server" CssClass="form-control"
                                    AutoPostBack="true" OnSelectedIndexChanged="dplCentro_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <br />

                            <asp:Label ID="Label6" runat="server" Text="Listado de Reservas" ForeColor="Black"></asp:Label>
                            <asp:Label ID="lbErrorReserva" runat="server" Text="No Posee Reservas de Este Tipo de Centro" Visible="false"></asp:Label>
                            <asp:Label ID="lbErrorSearchReserva" runat="server" Text="No se Encontraron Datos" Visible="false"></asp:Label>
                            <br />

                            <asp:GridView ID="grReserva" runat="server" CssClass="table table-striped w-auto" AutoGenerateColumns="False" DataKeyNames="_ID_RESERVA_CENTRO"
                                Font-Size="10pt" OnSelectedIndexChanged="grReserva_SelectedIndexChanged" AllowPaging="true" PageSize="6"
                                OnPageIndexChanging="grReserva_PageIndexChanging">
                                <Columns>
                                    <asp:BoundField DataField="_NUMERO_DEP" HeaderText="Dep" SortExpression="_NUMERO_DEP" />
                                    <asp:BoundField DataField="_NOMBRE_CENTRO" HeaderText="Centro" SortExpression="_NOMBRE_CENTRO" />
                                    <asp:BoundField DataField="_NOMBRE_TIPO_CENTRO" HeaderText="Tipo" SortExpression="_NOMBRE_TIPO_CENTRO" />
                                    <asp:BoundField DataField="_DIA_HORARIO" HeaderText="Dia" SortExpression="_DIA_HORARIO" />
                                    <asp:BoundField DataField="_HORA_INICIO_D" HeaderText="Hora Inicio" SortExpression="_HORA_INICIO_D" />
                                    <asp:BoundField DataField="_HORA_TERMINO_D" HeaderText="Hora Termino" SortExpression="_HORA_TERMINO_D" />
                                    <asp:BoundField DataField="_COSTO_BOLETA" HeaderText="Total" SortExpression="_COSTO_BOLETA" />
                                    <asp:CommandField ShowSelectButton="True" HeaderText="Descargar" />
                                </Columns>
                            </asp:GridView>
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