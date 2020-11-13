<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="AsignarMulta.aspx.cs" Inherits="EasyLife.Vista.AsignarMulta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Asignar Multa</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <section class="form-control mb-4" style="width: 40%; height: auto; margin-left: 30%; margin-top: 6%; background-color: #BB8FCE;">
        <form class="text-center border border-light p-5" action="#!">
            <div class="h4 mb-4 text-center">
                <asp:Label ID="lbOpcion" runat="server" Text="Asignar Multa" CssClass="h4 mb-4 text-center" ForeColor="Black"></asp:Label>
            </div>
            <%-- Campo de ingreso de Condominio --%>
            <asp:Label ID="Label10" runat="server" Text="Condominio" ForeColor="Black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:DropDownList ID="dplCondominio" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dplCondominio_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <%-- Validacion de Condominio --%>
            <div style="display: inline-block;">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplCondominio"
                    Display="Dynamic" InitialValue="Seleccione un Condominio" ValidationGroup="Multa"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplCondominio"
                    Display="Dynamic" ValidationGroup="Multa"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <%-- Campo de ingreso de Edificio --%>
            <asp:Label ID="Label8" runat="server" Text="Edificio" ForeColor="Black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:DropDownList ID="dplEdificio" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dplEdificio_SelectedIndexChanged">
                    <asp:ListItem>Seleccione un Edificio</asp:ListItem>
                </asp:DropDownList>
            </div>
            <%-- Validacion de Edificio --%>
            <div style="display: inline-block;">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplEdificio"
                    Display="Dynamic" InitialValue="Seleccione un Edificio" ValidationGroup="Multa"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplEdificio"
                    Display="Dynamic" ValidationGroup="Multa"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <%-- Campo de ingreso de Departamento --%>
            <asp:Label ID="Label2" runat="server" Text="Departamento" ForeColor="Black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:DropDownList ID="dplDepartamento" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dplDepartamento_SelectedIndexChanged">
                    <asp:ListItem>Seleccione un Departamento</asp:ListItem>
                </asp:DropDownList>
            </div>
            <%-- Validacion de Edificio --%>
            <div style="display: inline-block;">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplDepartamento"
                    Display="Dynamic" InitialValue="Seleccione un Departamento" ValidationGroup="Multa"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplDepartamento"
                    Display="Dynamic" ValidationGroup="Multa"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <%-- Campo de ingreso de Motivo --%>
            <asp:Label ID="Label3" runat="server" Text="Motivo" ForeColor="Black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:TextBox runat="server" ID="txtMotivo" class="form-control" placeholder="Motivo"></asp:TextBox>
            </div>
            <%-- Validacion de Motivo --%>
            <div style="display: inline-block;">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtMotivo"
                    Display="Dynamic" ValidationGroup="Multa"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Debe ingresar solo letras." ForeColor="Red"
                    ControlToValidate="txtMotivo" ValidationExpression="^[a-zA-Z ]*$" Display="Dynamic" ValidationGroup="Multa"></asp:RegularExpressionValidator>
            </div>
            <br />
            <br />

            <%-- Campo de ingreso de Multa --%>
            <asp:Label ID="Label1" runat="server" Text="Multa" ForeColor="Black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:TextBox runat="server" ID="txtMulta" class="form-control" TextMode="Number" placeholder="Multa" MaxLength="8"></asp:TextBox>
            </div>
            <%-- Validacion de Multa --%>
            <div style="display: inline-block;">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtMulta"
                    Display="Dynamic" ValidationGroup="Multa"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />
            <asp:Label ID="lbMultasExistentes" runat="server" Text="Historial Multas" ForeColor="Black" Visible="false"></asp:Label><br />
            <asp:ListBox ID="listadoMultas" runat="server" Visible="false"></asp:ListBox><br />

            <asp:Label ID="lbError" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
            <asp:Button runat="server" ID="btnAgregarMulta" class="btn btn-light btn-block my-4" Text="Asignar" OnClick="btnAgregarMulta_Click" ValidationGroup="Multa" />

            <!-- Lista de Multas Cargadas -->
            <asp:Label ID="lbMultasNuevas" runat="server" Text="Multas Nuevas" ForeColor="Black" Visible="false"></asp:Label>
            <asp:GridView ID="grMulta" runat="server" CssClass="table table-striped w-auto" AutoGenerateColumns="False" DataKeyNames="_ID_DEPARTAMENTO"
                Font-Size="10pt" OnSelectedIndexChanged="grMulta_SelectedIndexChanged" AllowPaging="true" PageSize="6" OnPageIndexChanging="grMulta_PageIndexChanging">
                <Columns>
                    <asp:BoundField DataField="_NOMBRE_CONDOMINIO" HeaderText="Condominio" SortExpression="_NOMBRE_CONDOMINIO" />
                    <asp:BoundField DataField="_NOMBRE_EDIFICIO" HeaderText="Edificio" SortExpression="_NOMBRE_EDIFICIO" />
                    <asp:BoundField DataField="_NUMERO_DEP" HeaderText="Dep" SortExpression="_NUMERO_DEP" />
                    <asp:BoundField DataField="_MOTIVO" HeaderText="Motivo" SortExpression="_MOTIVO" />
                    <asp:BoundField DataField="_MULTA" HeaderText="Multa" SortExpression="_MULTA" />
                    <asp:CommandField ShowSelectButton="True" HeaderText="Eliminar" />
                </Columns>
            </asp:GridView>

            <!-- Sign in button -->
            <asp:UpdatePanel ID="barraProgreso" runat="server">
                <ContentTemplate>
                    <asp:Button runat="server" ID="btnRegistroMulta" class="btn btn-light btn-block my-4" Text="Asignar Multa" OnClick="btnRegistroMulta_Click" Visible="true" />
                    <asp:Button runat="server" ID="btnModificarMulta" class="btn btn-light btn-block my-4" Text="Modificar Multa" OnClick="btnModificarMulta_Click" Visible="false" />
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