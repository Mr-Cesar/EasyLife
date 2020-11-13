<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="RegistroLuz.aspx.cs" Inherits="EasyLife.Vista.RegistroLuz" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Registro Codigo Luz</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <section class="form-control mb-4" style="width: 40%; height: auto; margin-left: 30%; margin-top: 6%; background-color: #BB8FCE;">
        <form class="text-center border border-light p-5" action="#!">
            <div class="h4 mb-4 text-center">
                <asp:Label ID="lbOpcion" runat="server" Text="Registro Luz" CssClass="h4 mb-4 text-center" ForeColor="Black"></asp:Label>
            </div>
            <%-- Campo de ingreso de Option --%>
            <asp:Label ID="Label1" runat="server" Text="Opción" ForeColor="Black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:DropDownList ID="dplOption" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dplOption_SelectedIndexChanged">
                    <asp:ListItem>Seleccione una Opcion</asp:ListItem>
                    <asp:ListItem Value="1">Edificio</asp:ListItem>
                    <asp:ListItem Value="2">Departamento</asp:ListItem>
                </asp:DropDownList>
            </div>
            <%-- Validacion de Option --%>
            <div style="display: inline-block;">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplOption"
                    Display="Dynamic" InitialValue="Seleccione una Opcion" ValidationGroup="Luz"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplOption"
                    Display="Dynamic" ValidationGroup="Luz"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <%-- Campo de ingreso de Codigo --%>
            <asp:Label ID="Label3" runat="server" Text="Codigo" ForeColor="Black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:TextBox runat="server" ID="txtCod" class="form-control" placeholder="Codigo" MaxLength="20"></asp:TextBox>
            </div>
            <%-- Validacion de Codigo --%>
            <div style="display: inline-block;">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtCod"
                    Display="Dynamic" ValidationGroup="Luz"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Debe ingresar solo letras." ForeColor="Red"
                    ControlToValidate="txtCod" ValidationExpression="^[a-zA-Z0-9]+$" Display="Dynamic" ValidationGroup="Luz"></asp:RegularExpressionValidator>
            </div>
            <br />
            <br />

            <asp:Label ID="lbError" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
            <asp:Button runat="server" ID="btnAgregarLuzEdificio" class="btn btn-light btn-block my-4" Text="Agregar" OnClick="btnAgregarLuzEdificio_Click"
                ValidationGroup="Luz" Visible="false" />
            <asp:Button runat="server" ID="btnAgregarLuzDep" class="btn btn-light btn-block my-4" Text="Agregar" OnClick="btnAgregarLuzDep_Click"
                ValidationGroup="Luz" Visible="false" />

            <!-- Lista de Codigos Luz Edificio -->
            <asp:GridView ID="grCodLuzEdificio" runat="server" CssClass="table table-striped w-auto" AutoGenerateColumns="False" DataKeyNames="ID_LUZ_E"
                Font-Size="10pt" OnSelectedIndexChanged="grCodLuzEdificio_SelectedIndexChanged" AllowPaging="true" PageSize="6"
                OnPageIndexChanging="grCodLuzEdificio_PageIndexChanging">
                <Columns>
                    <asp:BoundField DataField="CODIGO_LUZ_E" HeaderText="Codigo Luz" SortExpression="CODIGO_LUZ_E" />
                    <asp:CommandField ShowSelectButton="True" HeaderText="Eliminar" />
                </Columns>
            </asp:GridView>

            <!-- Lista de Codigos Luz Departamento -->
            <asp:GridView ID="grCodLuzDep" runat="server" CssClass="table table-striped w-auto" AutoGenerateColumns="False" DataKeyNames="ID_LUZ_D"
                Font-Size="10pt" OnSelectedIndexChanged="grCodLuzDep_SelectedIndexChanged" AllowPaging="true" PageSize="6"
                OnPageIndexChanging="grCodLuzDep_PageIndexChanging"
                Visible="false">
                <Columns>
                    <asp:BoundField DataField="CODIGO_LUZ_D" HeaderText="Codigo Luz" SortExpression="CODIGO_LUZ_D" />
                    <asp:CommandField ShowSelectButton="True" HeaderText="Eliminar" />
                </Columns>
            </asp:GridView>

            <!-- Sign in button -->
            <asp:UpdatePanel ID="barraProgreso" runat="server">
                <ContentTemplate>
                    <asp:Button runat="server" ID="btnRegistroLuzEdificio" class="btn btn-light btn-block my-4" Text="Registrar Luz" OnClick="btnRegistroLuzEdificio_Click"
                        Visible="false" />
                    <asp:Button runat="server" ID="btnRegistroLuzDep" class="btn btn-light btn-block my-4" Text="Registrar Luz" OnClick="btnRegistroLuzDep_Click"
                        Visible="false" />
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