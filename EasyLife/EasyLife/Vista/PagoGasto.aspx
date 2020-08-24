<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="PagoGasto.aspx.cs" Inherits="EasyLife.Vista.PagoGasto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Pago de Gastos</title>
    <script type="text/javascript">
        function formatCliente(cliente) {
            cliente.value = cliente.value.replace(/[.-]/g, '')
                .replace(/^(\d{1,2})(\d{3})(\d{3})(\w{1})$/, '$1.$2.$3-$4')
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <section class="form-control mb-4" style="width: 40%; height: auto; margin-left: 30%; margin-top: 6%; background-color: #BB8FCE">
        <!-- Default form login -->
        <form class="text-center border border-light p-5" action="#!">
            <p class="h4 mb-4 text-center" style="color: black">
                <asp:Label ID="lbTitulo" runat="server" Text="Registro Pago de Gasto Común"></asp:Label>
            </p>
            <asp:Panel ID="panelCondominio" runat="server" Visible="true">
                <%-- Campo de ingreso de Condominio --%>
                <asp:Label ID="Label2" runat="server" Text="Condominio" Style="color: black"></asp:Label><br />
                <div style="display: inline-block; width: 90%">
                    <asp:DropDownList ID="dplCondominio" runat="server" CssClass="form-control" AutoPostBack="true"
                        OnSelectedIndexChanged="dplCondominio_SelectedIndexChanged">
                        <asp:ListItem>Seleccione un Condominio</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <%-- Validacion de Condominio --%>
                <div style="display: inline-block;">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplCondominio"
                        Display="Dynamic" InitialValue="Seleccione un Condominio" ValidationGroup="gasto"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplCondominio"
                        Display="Dynamic" ValidationGroup="gasto"></asp:RequiredFieldValidator>
                </div>
                <br />
                <br />
            </asp:Panel>

            <%-- Campo de ingreso de Edificio --%>
            <asp:Label ID="Label12" runat="server" Text="Edificio" Style="color: black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:DropDownList ID="dplEdificio" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dplEdificio_SelectedIndexChanged">
                    <asp:ListItem>Seleccione un Edificio</asp:ListItem>
                </asp:DropDownList>
            </div>
            <%-- Validacion de Edificio --%>
            <div style="display: inline-block;">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplEdificio"
                    Display="Dynamic" InitialValue="Seleccione un Edificio" ValidationGroup="gasto"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplEdificio"
                    Display="Dynamic" ValidationGroup="gasto"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <%-- Campo de ingreso de Departamento --%>
            <asp:Label ID="Label8" runat="server" Text="Departamento" Style="color: black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:DropDownList ID="dplDepartamento" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dplDepartamento_SelectedIndexChanged">
                    <asp:ListItem>Seleccione un Departamento</asp:ListItem>
                </asp:DropDownList>
            </div>
            <%-- Validacion de Departamento --%>
            <div style="display: inline-block;">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplDepartamento"
                    Display="Dynamic" InitialValue="Seleccione un Departamento" ValidationGroup="gasto"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplDepartamento"
                    Display="Dynamic" ValidationGroup="gasto"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <%-- Campo de ingreso de Persona --%>
            <asp:Label ID="Label3" runat="server" Text="Rut " ForeColor="Black"></asp:Label><br />
            <asp:Label ID="lbError" runat="server" Text="Persona no Registratada" Style="color: black" Visible="false"></asp:Label>
            <div style="display: inline-block; width: 90%">
                <asp:TextBox ID="txtPersona" runat="server" placeholder="Rut" CssClass="form-control" MaxLength="12" onkeyup="formatCliente(this)"></asp:TextBox>
            </div>
            <%-- Validacion de Persona --%>
            <div style="display: inline-block;">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtPersona"
                    Display="Dynamic" ValidationGroup="gasto"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Formato no Valido" ForeColor="Red" Display="Dynamic"
                    ControlToValidate="txtPersona" ValidationExpression="^(\d{1,3}(?:\.\d{1,3}){2}-[\dkK])$" ValidationGroup="gasto"></asp:RegularExpressionValidator>
            </div>
            <br />
            <br />

            <!-- Detalle Gastos -->
            <asp:Label ID="Label1" runat="server" Text="Detalle Gastos" Style="color: black"></asp:Label><br />
            <asp:ListBox ID="listGastos" runat="server"></asp:ListBox>
            <br />

            <asp:Button runat="server" ID="btnAgregarPago" class="btn btn-light btn-block my-4" Text="Agregar Pago" OnClick="btnAgregarPago_Click" ValidationGroup="gasto" />

            <!-- Gastos Pagados -->
            <asp:Label ID="lbErrorRegistro" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label><br />
            <asp:Label ID="lbPagados" runat="server" Text="Gastos Pagados" Style="color: black" Visible="false"></asp:Label><br />
            <asp:GridView ID="grGastos" runat="server" CssClass="table table-striped w-auto" AutoGenerateColumns="False" DataKeyNames="_ID_BOLETA"
                Font-Size="10pt" OnSelectedIndexChanged="grGastos_SelectedIndexChanged" AllowPaging="true" PageSize="6"
                OnPageIndexChanging="grGastos_PageIndexChanging">
                <Columns>
                    <asp:BoundField DataField="_FK_RUT" HeaderText="Rut" SortExpression="_FK_RUT" />
                    <asp:BoundField DataField="_NOMBRE_EDIFICIO" HeaderText="Edificio" SortExpression="_NOMBRE_EDIFICIO" />
                    <asp:BoundField DataField="_NUMERO_DEP" HeaderText="Departamento" SortExpression="_NUMERO_DEP" />
                    <asp:BoundField DataField="_MULTA" HeaderText="Multa" SortExpression="_MULTA" />
                    <asp:BoundField DataField="_TOTAL_GASTO" HeaderText="Total gastos" SortExpression="_TOTAL_GASTO" />
                    <asp:BoundField DataField="_COSTO_BOLETA" HeaderText="Total Boleta" SortExpression="_COSTO_BOLETA" />
                    <asp:CommandField ShowSelectButton="true" HeaderText="Eliminar" />
                </Columns>
            </asp:GridView>

            <!-- Gasto Total -->
            <div class="col">
                <div class="form-group row">
                    <asp:Label ID="Label11" runat="server" Text="Total: " Style="color: black; margin-right: 2%"></asp:Label>
                    <div style="width: 30%">
                        <asp:Label ID="lbTotal" runat="server" Text="" class="form-control"></asp:Label>
                    </div>
                </div>
            </div>

            <!-- Sign in button -->
            <asp:UpdatePanel ID="barraProgreso" runat="server">
                <ContentTemplate>
                    <asp:Button runat="server" ID="btnPagarGasto" class="btn btn-light btn-block my-4" Text="Registrar Pago Gasto" OnClick="btnPagarGasto_Click" Visible="true" />
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