<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="RegistroCentro.aspx.cs" Inherits="EasyLife.Vista.RegistroCentro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Registro de Centro</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <section class="form-control mb-4" style="margin: 30px; width: 40%; height: auto; margin-left: 30%; margin-top: 6%; background-color: #BB8FCE">
        <!-- Default form login -->
        <form class="text-center border border-light p-5" action="#!">
            <p class="h4 mb-4 text-center" style="color: black">
                <asp:Label ID="lbOpcion" runat="server" Text="Registro de Centro"></asp:Label>
            </p>

            <%-- Campo de ingreso de Condominio --%>
            <asp:Label ID="Label8" runat="server" Text="Condominio" Style="color: black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:DropDownList ID="dplCondominio" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dplCondominio_SelectedIndexChanged">
                    <asp:ListItem>Seleccione un Condominio</asp:ListItem>
                </asp:DropDownList>
            </div>
            <%-- Validacion de Condominio --%>
            <div style="display: inline-block;">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplCondominio"
                    Display="Dynamic" InitialValue="Seleccione un Condominio"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplCondominio" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

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
                    Display="Dynamic" InitialValue="Seleccione un Edificio"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplEdificio" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <!-- Lista de Centros -->
            <asp:Label ID="Label5" runat="server" Text="Lista Horarios" Visible="false" ForeColor="Black"></asp:Label>
            <asp:GridView ID="grCentros" runat="server" CssClass="table table-striped w-auto" AutoGenerateColumns="False" DataKeyNames="_ID_CENTRO"
                Font-Size="10pt" AllowPaging="true" PageSize="6" OnPageIndexChanging="grCentros_PageIndexChanging">
                <Columns>
                    <asp:BoundField DataField="_NOMBRE_CENTRO" HeaderText="Nombre" SortExpression="_NOMBRE_CENTRO" />
                    <asp:BoundField DataField="_NOMBRE_TIPO_CENTRO" HeaderText="Tipo" SortExpression="_NOMBRE_TIPO_CENTRO" />
                    <asp:BoundField DataField="_COSTO" HeaderText="Precio" SortExpression="_COSTO" />
                </Columns>
            </asp:GridView>

            <%-- Campo de ingreso de Tipo de Centro --%>
            <asp:Label ID="Label13" runat="server" Text="Tipo de Centro " Style="color: black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:DropDownList ID="dplTipo" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dplTipo_SelectedIndexChanged">
                    <asp:ListItem>Seleccione un Tipo de Centro </asp:ListItem>
                </asp:DropDownList>
            </div>
            <%-- Validacion de Tipo de Centro  --%>
            <div style="display: inline-block;">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplTipo"
                    Display="Dynamic" InitialValue="Seleccione un Tipo de Centro"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplTipo" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <!-- Ingreso Nombre de Centro -->
            <asp:Label ID="Label7" runat="server" Text="Nombre Centro" Style="color: black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:TextBox runat="server" ID="txtNomCentro" class="form-control" aria-describedby="emailHelp" placeholder="Nombre Centro" MaxLength="40"></asp:TextBox>
            </div>
            <!-- Validacion de Ingreso Nombre de Centro -->
            <div style="display: inline-block">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtNomCentro"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <!-- Ingreso Costo de Centro -->
            <asp:Label ID="Label1" runat="server" Text="Precio Centro" Style="color: black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:TextBox runat="server" ID="txtCosto" class="form-control" aria-describedby="emailHelp" placeholder="Precio Centro" TextMode="Number"></asp:TextBox>
            </div>
            <!-- Validacion de Ingreso Costo de Centro -->
            <div style="display: inline-block">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtCosto"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <!-- Ingreso Dia Horario -->
            <asp:Label ID="Label2" runat="server" Text="Dia Horario" Style="color: black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:TextBox runat="server" ID="txtDia" class="form-control" aria-describedby="emailHelp" TextMode="Date"></asp:TextBox>
            </div>
            <!-- Validacion de Ingreso Dia Horario -->
            <div style="display: inline-block">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtDia"
                    ValidationGroup="horario"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <!-- Ingreso Hora Inicio -->
            <asp:Label ID="Label3" runat="server" Text="Hora Inicio" Style="color: black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:TextBox runat="server" ID="txtHoraI" class="form-control" aria-describedby="emailHelp" TextMode="Time"></asp:TextBox>
            </div>
            <!-- Validacion de Ingreso Hora Inicio -->
            <div style="display: inline-block">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red"
                    ControlToValidate="txtHoraI" ValidationGroup="horario"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <!-- Ingreso Hora Termino -->
            <asp:Label ID="Label4" runat="server" Text="Hora Termino" Style="color: black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:TextBox runat="server" ID="txtHoraT" class="form-control" aria-describedby="emailHelp" TextMode="Time"></asp:TextBox>
            </div>
            <!-- Validacion de Ingreso Hora Termino -->
            <div style="display: inline-block">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red"
                    ControlToValidate="txtHoraT" ValidationGroup="horario"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />
            <asp:Label ID="lbError" runat="server" Text="Horario ya Existete" ForeColor="Red" Visible="false"></asp:Label>
            <asp:Button runat="server" ID="btnAgregarHorario" class="btn btn-light btn-block my-4" Text="Agregar Horario" OnClick="btnAgregarHorario_Click"
                ValidationGroup="horario" />

            <!-- Lista de Horarios -->
            <asp:Label ID="lbHorario" runat="server" Text="Lista Horarios" Visible="false" ForeColor="Black"></asp:Label>
            <asp:GridView ID="grHorario" runat="server" CssClass="table table-striped w-auto" AutoGenerateColumns="False" DataKeyNames="ID_HORARIO_CENTRO"
                Font-Size="10pt" OnSelectedIndexChanged="grHorario_SelectedIndexChanged" AllowPaging="true" PageSize="6" OnPageIndexChanging="grHorario_PageIndexChanging">
                <Columns>
                    <asp:BoundField DataField="DIA_HORARIO" HeaderText="Dia" SortExpression="DIA_HORARIO" />
                    <asp:BoundField DataField="HORA_INICIO_D" HeaderText="Hora Inicio" SortExpression="HORA_INICIO_D" />
                    <asp:BoundField DataField="HORA_TERMINO_D" HeaderText="Hora Termino" SortExpression="HORA_TERMINO_D" />
                    <asp:CommandField ShowSelectButton="true" HeaderText="Eliminar" />
                </Columns>
            </asp:GridView>

            <!-- Sign in button -->
            <asp:UpdatePanel ID="barraProgreso" runat="server">
                <ContentTemplate>
                    <asp:Button runat="server" ID="btnRegistroCentro" class="btn btn-light btn-block my-4" Text="Crear Centro" Visible="true"
                        OnClick="btnRegistroCentro_Click1" />
                    <asp:Button runat="server" ID="btnModificarCentro" class="btn btn-light btn-block my-4" Text="Modificar Centro" Visible="false"
                        OnClick="btnModificarCentro_Click1" CausesValidation="false" />
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