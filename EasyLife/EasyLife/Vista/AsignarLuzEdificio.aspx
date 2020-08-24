<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="AsignarLuzEdificio.aspx.cs" Inherits="EasyLife.Vista.AsignarLuzEdificio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Asignar Luz Edificio</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <section class="form-control mb-4" style="width: 40%; height: auto; margin-left: 30%; margin-top: 6%; background-color: #BB8FCE;">
        <form class="text-center border border-light p-5" action="#!">
            <div class="h4 mb-4 text-center">
                <asp:Label ID="lbOpcion" runat="server" Text="Asignar Luz Edificio" CssClass="h4 mb-4 text-center" ForeColor="Black"></asp:Label>
            </div>
            <%-- Campo de ingreso de Opcion --%>
            <asp:Label ID="Label2" runat="server" Text="Opcion" ForeColor="Black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:DropDownList ID="dplOption" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dplOption_SelectedIndexChanged">
                    <asp:ListItem>Seleccione una Opción</asp:ListItem>
                    <asp:ListItem Value="1">Asignar</asp:ListItem>
                    <asp:ListItem Value="2">Modificar</asp:ListItem>
                </asp:DropDownList>
            </div>

            <%-- Validacion de Opcion --%>
            <div style="display: inline-block;">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplOption"
                    Display="Dynamic" InitialValue="Seleccione una Opción" ValidationGroup="luz"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplOption"
                    Display="Dynamic" ValidationGroup="luz"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <%-- Campo de ingreso de Condominio --%>
            <asp:Label ID="Label10" runat="server" Text="Condominio" ForeColor="Black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:DropDownList ID="dplCondominio" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dplCondominio_SelectedIndexChanged"
                    Enabled="false">
                </asp:DropDownList>
            </div>
            <%-- Validacion de Condominio --%>
            <div style="display: inline-block;">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplCondominio"
                    Display="Dynamic" InitialValue="Seleccione un Condominio" ValidationGroup="luz"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplCondominio"
                    Display="Dynamic" ValidationGroup="luz"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <%-- Campo de ingreso de Edificio --%>
            <asp:Label ID="Label8" runat="server" Text="Edificio" ForeColor="Black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:DropDownList ID="dplEdificio" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dplEdificio_SelectedIndexChanged"
                    Enabled="false">
                </asp:DropDownList>
            </div>
            <%-- Validacion de Edificio --%>
            <div style="display: inline-block;">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplEdificio"
                    Display="Dynamic" InitialValue="Seleccione un Edificio" ValidationGroup="luz"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplEdificio"
                    Display="Dynamic" ValidationGroup="luz"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <%-- Campo de ingreso de Luz --%>
            <asp:Label ID="Label1" runat="server" Text="Luz" ForeColor="Black"></asp:Label><br />
            <asp:Label ID="lbLuz" runat="server" Text="" ForeColor="Black" Visible="false"></asp:Label>
            <div style="display: inline-block; width: 90%">
                <asp:DropDownList ID="dplLuz" runat="server" CssClass="form-control" AutoPostBack="true" Enabled="false">
                </asp:DropDownList>
            </div>
            <%-- Validacion de Luz --%>
            <div style="display: inline-block;">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplLuz"
                    Display="Dynamic" InitialValue="Seleccione una Luz" ValidationGroup="luz"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplLuz"
                    Display="Dynamic" ValidationGroup="luz"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <asp:Label ID="lbError" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label><br />
            <asp:Button runat="server" ID="btnAgregarLuz" class="btn btn-light btn-block my-4" Text="Asignar" OnClick="btnAgregarLuz_Click" Visible="false"
                ValidationGroup="luz" />
            <asp:Button runat="server" ID="btnModificarLuz" class="btn btn-light btn-block my-4" Text="Asignar" OnClick="btnModificarLuz_Click" Visible="false"
                ValidationGroup="luz" />

            <!-- Lista de Luces Cargadas -->
            <asp:GridView ID="grLuces" runat="server" CssClass="table table-striped w-auto" AutoGenerateColumns="False" DataKeyNames="_ID_LUZ_E"
                Font-Size="10pt" AllowPaging="True" OnSelectedIndexChanged="grLuces_SelectedIndexChanged" OnPageIndexChanging="grLuces_PageIndexChanging" PageSize="6">
                <Columns>
                    <asp:BoundField DataField="_CODIGO_LUZ_E" HeaderText="Luz" SortExpression="_CODIGO_LUZ_E" />
                    <asp:BoundField DataField="_NOMBRE_CONDOMINIO" HeaderText="Condominio" SortExpression="_NOMBRE_CONDOMINIO" />
                    <asp:BoundField DataField="_NOMBRE_EDIFICIO" HeaderText="Edificio" SortExpression="_NOMBRE_EDIFICIO" />
                    <asp:CommandField ShowSelectButton="True" HeaderText="Eliminar" />
                </Columns>
            </asp:GridView>

            <!-- Sign in button -->
            <asp:UpdatePanel ID="barraProgreso" runat="server">
                <ContentTemplate>
                    <asp:Button runat="server" ID="btnRegistroLuz" class="btn btn-light btn-block my-4" Text="Asignar Luz" OnClick="btnRegistroLuz_Click" Visible="false" />
                    <asp:Button runat="server" ID="btnUpdateLuz" class="btn btn-light btn-block my-4" Text="Modificar Luz" OnClick="btnUpdateLuz_Click" Visible="false" />
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