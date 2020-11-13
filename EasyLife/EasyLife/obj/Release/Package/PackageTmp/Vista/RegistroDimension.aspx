<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="RegistroDimension.aspx.cs" Inherits="EasyLife.Vista.RegistroDimension" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Registro Dimensión</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <section class="form-control mb-4" style="width: 40%; height: auto; margin-left: 30%; margin-top: 5%; background-color: #BB8FCE">
        <form class="text-center border border-light p-5" action="#!">
            <p class="h4 mb-4 text-center" style="color: black">
                <asp:Label ID="lbOpcion" runat="server" Text="Registro de Dimensión"></asp:Label>
            </p>
            <%-- Campo de Nombre Condominio --%>
            <asp:Label ID="Label1" runat="server" Text="Condominio" ForeColor="Black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:TextBox ID="txtCondominio" runat="server" CssClass="form-control" MaxLength="60" Enabled="false"></asp:TextBox>
            </div>
            <br />
            <br />

            <%-- Campo de ingreso Edificio --%>
            <asp:Label ID="Label3" runat="server" Text="Edificio" ForeColor="Black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:DropDownList ID="dplEdificio" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dplEdificio_SelectedIndexChanged">
                    <asp:ListItem>Seleccione un Edificio</asp:ListItem>
                </asp:DropDownList>
            </div>
            <%-- Validacion de Edificio --%>
            <div style="display: inline-block;">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplEdificio"
                    Display="Dynamic" InitialValue="Seleccione un Edificio"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplEdificio" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <%-- Campo de ingreso Tipo --%>
            <asp:Label ID="Label2" runat="server" Text="Tipo" ForeColor="Black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:DropDownList ID="dplTipo" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dplTipo_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <%-- Validacion de Tipo --%>
            <div style="display: inline-block;">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplTipo"
                    Display="Dynamic" InitialValue="Seleccione un Elemento" ValidationGroup="validationTipo"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplTipo"
                    Display="Dynamic" ValidationGroup="validationTipo"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <%-- Panel de Bodega --%>
            <asp:Panel ID="panelBodega" runat="server" Visible="false">
                <%-- Campo de ingreso Dimension Bodega --%>
                <asp:Label ID="Label6" runat="server" Text="Dimensión Bodega" ForeColor="Black"></asp:Label><br />
                <div style="display: inline-block; width: 90%">
                    <asp:TextBox ID="txtDimBodega" runat="server" placeholder="Dimensión Bodega" CssClass="form-control"></asp:TextBox>
                </div>
                <%-- Validacion de Dimension Edificios --%>
                <div style="display: inline-block">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtDimBodega"
                        ValidationGroup="validationTipo"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Solo Decimal" ForeColor="Red"
                        ControlToValidate="txtDimBodega" ValidationGroup="validationTipo" ValidationExpression="^[1-9]\d*(\,\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator>
                </div>
                <br />
                <br />

                <%-- Campo de ingreso Cantidad Bodegas --%>
                <asp:Label ID="Label12" runat="server" Text="Cantidad de Bodegas" ForeColor="Black"></asp:Label><br />
                <div style="display: inline-block; width: 90%">
                    <asp:TextBox ID="txtCantidadBodega" runat="server" placeholder="Cantidad de Bodegas" CssClass="form-control" TextMode="Number"></asp:TextBox>
                </div>
                <%-- Validacion de Cantidad Bodega --%>
                <div style="display: inline-block">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtCantidadBodega"
                        ValidationGroup="validationTipo"></asp:RequiredFieldValidator>
                </div>
                <br />
                <br />
            </asp:Panel>

            <%-- Panel de Estacionamiento --%>
            <asp:Panel ID="panelEstacionamiento" runat="server" Visible="false">
                <%-- Campo de ingreso Cantidad Estacionamiento --%>
                <asp:Label ID="Label5" runat="server" Text="Cantidad de Estacionamientos" ForeColor="Black"></asp:Label><br />
                <div style="display: inline-block; width: 90%">
                    <asp:TextBox ID="txtEstacionamiento" runat="server" placeholder="Cantidad de Estacionamientos" CssClass="form-control" TextMode="Number"></asp:TextBox>
                </div>
                <%-- Validacion de Cantidad Estacionamiento --%>
                <div style="display: inline-block">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtEstacionamiento"
                        ValidationGroup="validationTipo"></asp:RequiredFieldValidator>
                </div>
                <br />
                <br />

                <%-- Campo de ingreso Precio Estacionamiento --%>
                <asp:Label ID="Label8" runat="server" Text="Precio Estacionamientos" ForeColor="Black"></asp:Label><br />
                <div style="display: inline-block; width: 90%">
                    <asp:TextBox ID="txtPrecio" runat="server" placeholder="Precio Estacionamientos" CssClass="form-control" TextMode="Number"></asp:TextBox>
                </div>
                <%-- Validacion de Precio Estacionamiento --%>
                <div style="display: inline-block">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtPrecio"
                        ValidationGroup="validationTipo"></asp:RequiredFieldValidator>
                </div>
                <br />
                <br />
            </asp:Panel>

            <asp:Button runat="server" ID="btnAgregar" class="btn btn-light btn-block my-4" Text="Agregar Elemento" ValidationGroup="validationTipo"
                OnClick="btnAgregar_Click" Width="40%" />

            <!-- Lista Elementos -->
            <asp:Label ID="lbElementos" runat="server" Text="Lista Elementos" ForeColor="Black" Visible="false"></asp:Label><br />
            <asp:GridView ID="grElementos" runat="server" CssClass="table table-striped w-auto" AutoGenerateColumns="False" DataKeyNames="_ID_EDIFICIO"
                Font-Size="10pt" AllowPaging="true" PageSize="6" OnPageIndexChanging="grElementos_PageIndexChanging" Visible="false">
                <Columns>
                    <asp:BoundField DataField="_NOMBRE_EDIFICIO" HeaderText="Nombre" SortExpression="_NOMBRE_EDIFICIO" />
                    <asp:BoundField DataField="_TIPO" HeaderText="Tipo" SortExpression="_TIPO" />
                    <asp:BoundField DataField="_CANTIDAD" HeaderText="Cantidad" SortExpression="_CANTIDAD" />
                    <asp:BoundField DataField="_DIMENSION" HeaderText="Dimensión" SortExpression="_DIMENSION" />
                    <asp:BoundField DataField="_PRECIO" HeaderText="Precio" SortExpression="_PRECIO" />
                </Columns>
            </asp:GridView>

            <%-- Campo de ingreso Departamento --%>
            <asp:Label ID="Label4" runat="server" Text="Departamento" ForeColor="Black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:DropDownList ID="dplDepartamento" runat="server" CssClass="form-control" AutoPostBack="true">
                    <asp:ListItem>Seleccione un Departamento</asp:ListItem>
                </asp:DropDownList>
            </div>
            <%-- Validacion de Departamento --%>
            <div style="display: inline-block;">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplDepartamento"
                    Display="Dynamic" InitialValue="Seleccione un Departamento" ValidationGroup="validationDep"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplDepartamento"
                    Display="Dynamic" ValidationGroup="validationDep"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <%-- Campo de ingreso Dimension Departamento --%>
            <asp:Label ID="Label7" runat="server" Text="Dimension Departamento" ForeColor="Black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:TextBox ID="txtDimDepartamento" runat="server" placeholder="Dimensión Departamento" CssClass="form-control"></asp:TextBox>
            </div>
            <%-- Validacion de Cantidad Estacionamiento --%>
            <div style="display: inline-block">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtDimDepartamento"
                    ValidationGroup="validationDep"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Solo Decimal" ForeColor="Red"
                    ControlToValidate="txtDimDepartamento" ValidationGroup="validationDep" ValidationExpression="^[1-9]\d*(\,\d+)?$" Display="Dynamic"></asp:RegularExpressionValidator>
            </div>
            <br />
            <br />

            <asp:Button runat="server" ID="btnAgregarDep" class="btn btn-light btn-block my-4" Text="Agregar Departamento" ValidationGroup="validationDep"
                OnClick="btnAgregarDep_Click" Width="40%" />

            <!-- Lista Departamentos -->
            <asp:Label ID="lbDep" runat="server" Text="Lista Departamentos" ForeColor="Black" Visible="false"></asp:Label><br />
            <asp:Label ID="lbError" runat="server" Text="Departamento ya Posee Dimensión" ForeColor="Red" Visible="false"></asp:Label><br />
            <asp:GridView ID="grDepartamento" runat="server" CssClass="table table-striped w-auto" AutoGenerateColumns="False" DataKeyNames="_ID_EDIFICIO"
                Font-Size="10pt" AllowPaging="true" PageSize="6" OnPageIndexChanging="grDepartamento_PageIndexChanging" Visible="false">
                <Columns>
                    <asp:BoundField DataField="_NOMBRE_EDIFICIO" HeaderText="Nombre" SortExpression="_NOMBRE_EDIFICIO" />
                    <asp:BoundField DataField="_NUMERO_DEP" HeaderText="Numero Dep" SortExpression="_NUMERO_DEP" />
                    <asp:BoundField DataField="_DIMENSION_DEP" HeaderText="Dimensión" SortExpression="_DIMENSION_DEP" />
                </Columns>
            </asp:GridView>

            <!-- Boton Registro de Dimension -->
            <asp:UpdatePanel ID="barraProgreso" runat="server">
                <ContentTemplate>
                    <asp:Button runat="server" ID="btnRegistroDimension" class="btn btn-light btn-block my-4" Text="Registrar Parametros"
                        OnClick="btnRegistroDimension_Click" />
                    <asp:Button runat="server" ID="btnModificarDimension" class="btn btn-light btn-block my-4" Text="Modificar Parametros"
                        Visible="false" OnClick="btnModificarDimension_Click" />
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