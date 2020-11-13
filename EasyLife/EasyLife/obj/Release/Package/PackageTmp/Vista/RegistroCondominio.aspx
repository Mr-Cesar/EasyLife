<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="RegistroCondominio.aspx.cs" Inherits="EasyLife.Vista.RegistroCondominio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Registro Condominio</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <section class="form-control mb-4" style="width: 40%; height: auto; margin-left: 30%; margin-top: 5%; background-color: #BB8FCE">
        <form class="text-center border border-light p-5" action="#!">
            <p class="h4 mb-4 text-center" style="color: black">
                <asp:Label ID="lbOpcion" runat="server" Text="Registro de Condominio"></asp:Label>
            </p>
            <%-- Campo de ingreso de Region --%>
            <asp:Label ID="Label11" runat="server" Text="Region" ForeColor="Black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:DropDownList ID="dplRegion" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dplRegion_SelectedIndexChanged">
                    <asp:ListItem>Seleccione una Region</asp:ListItem>
                </asp:DropDownList>
            </div>
            <%-- Validacion de Region --%>
            <div style="display: inline-block;">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplRegion" Display="Dynamic"
                    InitialValue="Seleccione una Region"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplRegion" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <%-- Campo de ingreso de Ciudad --%>
            <asp:Label ID="Label10" runat="server" Text="Ciudad" ForeColor="Black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:DropDownList ID="dplCiudad" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dplCiudad_SelectedIndexChanged">
                    <asp:ListItem>Seleccione una Ciudad</asp:ListItem>
                </asp:DropDownList>
            </div>
            <%-- Validacion de Ciudad --%>
            <div style="display: inline-block;">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplCiudad"
                    Display="Dynamic" InitialValue="Seleccione una Ciudad"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplCiudad" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <%-- Campo de ingreso de Comuna --%>
            <asp:Label ID="Label8" runat="server" Text="Comuna" ForeColor="Black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:DropDownList ID="dplComuna" runat="server" CssClass="form-control" AutoPostBack="true">
                    <asp:ListItem>Seleccione una Comuna</asp:ListItem>
                </asp:DropDownList>
            </div>
            <%-- Validacion de Comuna --%>
            <div style="display: inline-block;">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplComuna"
                    Display="Dynamic" InitialValue="Seleccione una Comuna"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplComuna" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <%-- Campo de ingreso Calle --%>
            <asp:Label ID="Label1" runat="server" Text="Calle" ForeColor="Black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:TextBox ID="txtCalle" runat="server" placeholder="Calle" CssClass="form-control" MaxLength="60"></asp:TextBox>
            </div>
            <%-- Validacion de Calle --%>
            <div style="display: inline-block">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtCalle"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <%-- Campo de ingreso Numero --%>
            <asp:Label ID="Label2" runat="server" Text="Numero" ForeColor="Black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:TextBox ID="txtNumero" runat="server" placeholder="Numero" CssClass="form-control" MaxLength="20" TextMode="Number"></asp:TextBox>
            </div>
            <%-- Validacion de Numero --%>
            <div style="display: inline-block;">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtNumero"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <%-- Campo de ingreso Administrador --%>
            <asp:Label ID="Label3" runat="server" Text="Administrador" ForeColor="Black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:DropDownList ID="dplAdministrador" runat="server" CssClass="form-control" AutoPostBack="true">
                    <asp:ListItem>Seleccione un Administrador</asp:ListItem>
                </asp:DropDownList>
            </div>
            <%-- Validacion de Administrador --%>
            <div style="display: inline-block;">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplAdministrador"
                    Display="Dynamic" InitialValue="Seleccione un Administrador"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplAdministrador" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <%-- Campo de ingreso Nombre Condominio --%>
            <asp:Label ID="Label4" runat="server" Text="Nombre Condominio" ForeColor="Black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:TextBox ID="txtNombre" runat="server" placeholder="Nombre Condominio" CssClass="form-control" MaxLength="40"></asp:TextBox>
            </div>
            <%-- Validacion de Nombre Condominio --%>
            <div style="display: inline-block">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtNombre"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <%-- Campo de ingreso Precio Estacionamiento --%>
            <asp:Label ID="Label13" runat="server" Text="Precio Estacionamiento Visita" ForeColor="Black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:TextBox ID="txtEst" runat="server" placeholder="Precio Estacionamiento Visita" CssClass="form-control" TextMode="Number"></asp:TextBox>
            </div>
            <%-- Validacion de Precio Estacionamiento  --%>
            <div style="display: inline-block">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtEst"
                    ValidationGroup="dimensionEdificio"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <%-- Campo de ingreso Prefijo Nombre Edificio --%>
            <asp:Label ID="Label5" runat="server" Text="Prefijo Nombre Edificio" ForeColor="Black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:TextBox ID="txtPrefijo" runat="server" placeholder="Prefijo Nombre Edificio" CssClass="form-control" MaxLength="30"></asp:TextBox>
            </div>
            <%-- Validacion de Prefijo Nombre Edificio --%>
            <div style="display: inline-block">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtPrefijo"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <%-- Campo de ingreso Tipo Nombre Edificio --%>
            <asp:Label ID="Label9" runat="server" Text="Correlacion de Nombre de Edificio" ForeColor="Black"></asp:Label><br />
            <div style="display: inline-block; width: 80%">
                <asp:RadioButtonList ID="radioEdificios" runat="server" ForeColor="Black">
                    <asp:ListItem>Letras (a, b, c , etc)</asp:ListItem>
                    <asp:ListItem>Numerico (1, 2 , 3, etc)</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <%-- Validacion de Tipo Nombre Edificio --%>
            <div style="display: inline-block">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="radioEdificios"></asp:RequiredFieldValidator>
            </div>
            <br />

            <%-- Campo de ingreso Dimension Edificios --%>
            <asp:Label ID="Label6" runat="server" Text="Dimensión Edificio" ForeColor="Black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:TextBox ID="txtDimensionEdificio" runat="server" placeholder="Dimensión Edificio" CssClass="form-control"></asp:TextBox>
            </div>
            <%-- Validacion de Dimension Edificios --%>
            <div style="display: inline-block">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtDimensionEdificio"
                    ValidationGroup="dimensionEdificio"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Solo Decimal" ForeColor="Red"
                    ControlToValidate="txtDimensionEdificio" ValidationGroup="dimensionEdificio" ValidationExpression="^[1-9]\d*(\,\d+)?$"></asp:RegularExpressionValidator>
            </div>
            <br />

            <%-- Campo de ingreso Cantidad Pisos por Edificio --%>
            <asp:Label ID="Label12" runat="server" Text="Cantidad Pisos por Edificio" ForeColor="Black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:TextBox ID="txtPiso" runat="server" placeholder="Cantidad Pisos por Edificios" CssClass="form-control" TextMode="Number"></asp:TextBox>
            </div>
            <%-- Validacion de Cantidad Pisos por Edificio --%>
            <div style="display: inline-block">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtPiso"
                    ValidationGroup="dimensionEdificio"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <%-- Campo de ingreso Cantidad Departamentos --%>
            <asp:Label ID="Label7" runat="server" Text="Cantidad Departamentos por Edificio" ForeColor="Black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:TextBox ID="txtDepartamento" runat="server" placeholder="Cantidad Departamentos por Edificio" CssClass="form-control" TextMode="Number"></asp:TextBox>
            </div>
            <%-- Validacion de Cantidad Departamentos --%>
            <div style="display: inline-block">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtDepartamento"
                    ValidationGroup="dimensionEdificio"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <asp:Button runat="server" ID="btnAgregar" class="btn btn-light btn-block my-4" Text="Agregar Edificio" ValidationGroup="dimensionEdificio"
                OnClick="btnAgregar_Click" />

            <!-- Lista Edificios -->
            <asp:Label ID="lbEdificio" runat="server" Text="Lista Edificios" ForeColor="Black" Visible="false"></asp:Label><br />
            <asp:GridView ID="grEdificio" runat="server" CssClass="table table-striped w-auto" AutoGenerateColumns="False" DataKeyNames="_ID_EDIFICIO"
                Font-Size="10pt" AllowPaging="true" PageSize="6" OnPageIndexChanging="grEdificio_PageIndexChanging" Visible="false">
                <Columns>
                    <asp:BoundField DataField="_NOMBRE_EDIFICIO" HeaderText="Nombre" SortExpression="_NOMBRE_EDIFICIO" />
                    <asp:BoundField DataField="_CANTIDAD_PISO" HeaderText="Cant. de Pisos" SortExpression="_CANTIDAD_PISO" />
                    <asp:BoundField DataField="_CANTIDAD_DEPARTAMENTO" HeaderText="Cant. Departamento" SortExpression="_CANTIDAD_DEPARTAMENTO" />
                    <asp:BoundField DataField="_DIMENSION_EDIFICIO" HeaderText="Dimensión" SortExpression="_DIMENSION_EDIFICIO" />
                </Columns>
            </asp:GridView>

            <!-- Boton Registro de Condominio -->
            <asp:UpdatePanel ID="barraProgreso" runat="server">
                <ContentTemplate>
                    <asp:Button runat="server" ID="btnRegistroCondominio" class="btn btn-light btn-block my-4" Text="Registrar Condominio"
                        OnClick="btnRegistroCondominio_Click" />
                    <asp:Button runat="server" ID="btnModificarCondominio" class="btn btn-light btn-block my-4" Text="Modificar Condominio"
                        Visible="false" OnClick="btnModificarCondominio_Click" />
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