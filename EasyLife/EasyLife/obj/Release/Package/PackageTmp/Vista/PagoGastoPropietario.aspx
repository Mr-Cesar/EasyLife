<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="PagoGastoPropietario.aspx.cs" Inherits="EasyLife.Vista.PagoGastoPropietario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Pago de Gastos Comunes</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <section class="form-control mb-4" style="width: 40%; height: auto; margin-left: 30%; margin-top: 6%; background-color: #BB8FCE">
        <!-- Default form login -->
        <form class="text-center border border-light p-5" action="#!">
            <p class="h4 mb-4 text-center" style="color: black">
                <asp:Label ID="lbTitulo" runat="server" Text="Pago de Gasto Común"></asp:Label>
            </p>

            <%-- Campo de ingreso de Departamento --%>
            <asp:Label ID="Label8" runat="server" Text="Departamento" Style="color: black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:DropDownList ID="dplDepartamento" runat="server" CssClass="form-control" AutoPostBack="true"
                    OnSelectedIndexChanged="dplDepartamento_SelectedIndexChanged">
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

            <!-- Detalle Gastos -->
            <asp:Label ID="Label1" runat="server" Text="Detalle Gastos" Style="color: black"></asp:Label><br />
            <asp:ListBox ID="listGastos" runat="server"></asp:ListBox>
            <br />
            <br />

            <asp:Button runat="server" ID="btnAgregarGasto" class="btn btn-light btn-block my-4" Text="Agregar Pago" OnClick="btnAgregarGasto_Click" ValidationGroup="gasto" />

            <!-- Gastos Pagados -->
            <asp:GridView ID="grGastos" runat="server" CssClass="table table-striped w-auto" AutoGenerateColumns="False" DataKeyNames="_ID_BOLETA"
                Font-Size="10pt" OnSelectedIndexChanged="grGastos_SelectedIndexChanged" AllowPaging="true" PageSize="6"
                OnPageIndexChanging="grGastos_PageIndexChanging">
                <Columns>
                    <asp:BoundField DataField="_NUMERO_DEP" HeaderText="Departamento" SortExpression="_NUMERO_DEP" />
                    <asp:BoundField DataField="_MULTA" HeaderText="Multa" SortExpression="_MULTA" />
                    <asp:BoundField DataField="_TOTAL_GASTO" HeaderText="Total gastos" SortExpression="_TOTAL_GASTO" />
                    <asp:BoundField DataField="_COSTO_BOLETA" HeaderText="Total Boleta" SortExpression="_COSTO_BOLETA" />
                    <asp:CommandField ShowSelectButton="true" HeaderText="Eliminar" />
                </Columns>
            </asp:GridView>
            <br />

            <!-- Gasto Total -->
            <div class="col">
                <div class="form-group row">
                    <asp:Label ID="Label11" runat="server" Text="Total: " Style="color: black; margin-right: 2%"></asp:Label>
                    <div style="width: 30%">
                        <asp:Label ID="lbTotal" runat="server" Text="Label" class="form-control"></asp:Label>
                    </div>
                </div>
            </div>

            <!-- Sign in button -->
            <asp:UpdatePanel ID="barraProgreso" runat="server">
                <ContentTemplate>
                    <asp:Button runat="server" ID="btnPagarGasto" class="btn btn-light btn-block my-4" Text="Registrar Pago Gasto" OnClick="btnPagarGasto_Click" />
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