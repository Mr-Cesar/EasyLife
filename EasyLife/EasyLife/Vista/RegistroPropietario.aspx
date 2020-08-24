<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="RegistroPropietario.aspx.cs" Inherits="EasyLife.Vista.RegistroPropietario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Registro Propietario</title>
    <script type="text/javascript">
        function formatCliente(cliente) {
            cliente.value = cliente.value.replace(/[.-]/g, '')
                .replace(/^(\d{1,2})(\d{3})(\d{3})(\w{1})$/, '$1.$2.$3-$4')
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <section class="form-control mb-4" style="width: 40%; height: auto; margin-left: 30%; margin-top: 6%; background-color: #BB8FCE;">
        <form class="text-center border border-light p-5" action="#!">
            <div class="h4 mb-4 text-center">
                <asp:Label ID="lbOpcion" runat="server" Text="Registro Propietario" CssClass="h4 mb-4 text-center" ForeColor="Black"></asp:Label>
            </div>
            <asp:Panel ID="panelProp" runat="server">
                <%-- Campo de ingreso de Condominio --%>
                <asp:Label ID="Label10" runat="server" Text="Condominio" ForeColor="Black"></asp:Label><br />
                <div style="display: inline-block; width: 90%">
                    <asp:DropDownList ID="dplCondominio" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dplCondominio_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <%-- Validacion de Condominio --%>
                <div style="display: inline-block;">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplCondominio"
                        Display="Dynamic" InitialValue="Seleccione un Condominio" ValidationGroup="dep"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplCondominio"
                        Display="Dynamic" ValidationGroup="dep"></asp:RequiredFieldValidator>
                </div>
                <br />
                <br />

                <%-- Campo de ingreso de Edificio --%>
                <asp:Label ID="Label8" runat="server" Text="Edificio" ForeColor="Black"></asp:Label><br />
                <div style="display: inline-block; width: 90%">
                    <asp:DropDownList ID="dplEdificio" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dplEdificio_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <%-- Validacion de Edificio --%>
                <div style="display: inline-block;">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplEdificio"
                        Display="Dynamic" InitialValue="Seleccione un Edificio" ValidationGroup="dep"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplEdificio"
                        Display="Dynamic" ValidationGroup="dep"></asp:RequiredFieldValidator>
                </div>
                <br />
                <br />

                <%-- Campo de ingreso de Departamento --%>
                <asp:Label ID="Label9" runat="server" Text="Departamento" ForeColor="Black"></asp:Label><br />
                <div style="display: inline-block; width: 90%">
                    <asp:DropDownList ID="dplDepartamento" runat="server" CssClass="form-control" AutoPostBack="true">
                    </asp:DropDownList>
                </div>
                <%-- Validacion de Departamento --%>
                <div style="display: inline-block;">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplDepartamento"
                        Display="Dynamic" InitialValue="Seleccione un Departamento" ValidationGroup="dep"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplDepartamento"
                        Display="Dynamic" ValidationGroup="dep"></asp:RequiredFieldValidator>
                </div>
                <br />
                <br />

                <asp:Label ID="lbError" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                <asp:Button runat="server" ID="btnAgregarDepartamento" class="btn btn-light btn-block my-4" Text="Agregar Departamento" OnClick="btnAgregarDepartamento_Click"
                    Width="40%" ValidationGroup="dep" />
            </asp:Panel>

            <asp:GridView ID="grDepartamento" runat="server" CssClass="table table-striped w-auto" AutoGenerateColumns="False" DataKeyNames="_ID_DEPARTAMENTO"
                Font-Size="10pt" OnSelectedIndexChanged="grDepartamento_SelectedIndexChanged" AllowPaging="true" PageSize="6"
                OnPageIndexChanging="grDepartamento_PageIndexChanging">
                <Columns>
                    <asp:BoundField DataField="_NOMBRE_CONDOMINIO" HeaderText="Condominio" SortExpression="_NOMBRE_CONDOMINIO" />
                    <asp:BoundField DataField="_NOMBRE_EDIFICIO" HeaderText="Edificio" SortExpression="_NOMBRE_EDIFICIO" />
                    <asp:BoundField DataField="_NUMERO_DEP" HeaderText="Numero Dep" SortExpression="_NUMERO_DEP" />
                    <asp:CommandField ShowSelectButton="True" HeaderText="Eliminar" />
                </Columns>
            </asp:GridView>

            <%-- Campo de ingreso de Rut --%>
            <asp:Label ID="Label3" runat="server" Text="Rut" ForeColor="Black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:TextBox ID="txtRut" runat="server" placeholder="Rut" CssClass="form-control" MaxLength="12" onkeyup="formatCliente(this)"></asp:TextBox>
            </div>
            <%-- Validacion de rut --%>
            <div style="display: inline-block;">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtRut"
                    Display="Dynamic" ValidationGroup="prop"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Formato no Valido" ForeColor="Red"
                    Display="Dynamic" ControlToValidate="txtRut" ValidationExpression="^(\d{1,3}(?:\.\d{1,3}){2}-[\dkK])$" ValidationGroup="prop"></asp:RegularExpressionValidator>
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
                    ControlToValidate="txtNombre" ValidationExpression="^[a-zA-Z]*$" Display="Dynamic" ValidationGroup="prop"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red"
                    ControlToValidate="txtNombre" ValidationGroup="prop"></asp:RequiredFieldValidator>
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
                    ControlToValidate="txtApellido" ValidationExpression="^[a-zA-Z]*$" Display="Dynamic" ValidationGroup="prop"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red"
                    ControlToValidate="txtApellido" ValidationGroup="prop"></asp:RequiredFieldValidator>
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
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ForeColor="Red"
                    ControlToValidate="txtTelefono" ValidationGroup="prop"></asp:RequiredFieldValidator>
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
                    Display="Dynamic" ValidationGroup="prop"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Formato de correo no Valido" ForeColor="Red" Display="Dynamic"
                    ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="prop"></asp:RegularExpressionValidator>
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
                    Display="Dynamic" ValidationGroup="prop"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <%-- Campo de ingreso de Opcion de Luz --%>
            <asp:Label ID="Label6" runat="server" Text="Automatizacion de Luz" ForeColor="Black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:DropDownList ID="dplLuz" runat="server" CssClass="form-control">
                    <asp:ListItem>Seleccione una Opcion</asp:ListItem>
                    <asp:ListItem>Si</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList>
            </div>
            <%-- Validacion de Opcion de Luz --%>
            <div style="display: inline-block;">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplLuz"
                    Display="Dynamic" InitialValue="Seleccione una Opcion" ValidationGroup="prop"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplLuz"
                    Display="Dynamic" ValidationGroup="prop"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <!-- Sign in button -->
            <asp:UpdatePanel ID="barraProgreso" runat="server">
                <ContentTemplate>
                    <asp:Button runat="server" ID="btnRegistroPropietario" class="btn btn-light btn-block my-4" Text="Registrar" OnClick="btnRegistroPropietario_Click"
                        ValidationGroup="prop" />
                    <asp:Button runat="server" ID="btnModificarPropietario" class="btn btn-light btn-block my-4" Text="Modificar" OnClick="btnModificarPropietario_Click"
                        Visible="false" ValidationGroup="prop" />
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