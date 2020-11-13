<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="RegistroGasto.aspx.cs" Inherits="EasyLife.Vista.RegistroGasto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Registro Gasto</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <section class="form-control mb-4" style="margin: 30px; width: 45%; height: auto; margin-left: 30%; margin-top: 5%; background-color: #BB8FCE">
        <!-- Default form login -->
        <form class="text-center border border-light p-5" action="#!">
            <p class="h4 mb-4 text-center" style="color: black">
                <asp:Label ID="lbTitulo" runat="server" Text="Registro de Gasto Común"></asp:Label>
            </p>
            <asp:Panel ID="panelGasto" runat="server">
                <%-- Campo de ingreso de Condominio --%>
                <asp:Label ID="Label8" runat="server" Text="Condominio" Style="color: black"></asp:Label><br />
                <div style="display: inline-block; width: 90%">
                    <asp:DropDownList ID="dplCondominio" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dplCondominio_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <%-- Validacion de Condominio --%>
                <div style="display: inline-block;">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplCondominio"
                        Display="Dynamic" InitialValue="Seleccione un Condominio" ValidationGroup="gasto"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplCondominio"
                        Display="Dynamic" ValidationGroup="gasto"></asp:RequiredFieldValidator>
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
                        Display="Dynamic" InitialValue="Seleccione un Edificio" ValidationGroup="gasto"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplEdificio"
                        Display="Dynamic" ValidationGroup="gasto"></asp:RequiredFieldValidator>
                </div>
                <br />
                <br />
            </asp:Panel>
            <!-- Gasto Conserje -->
            <asp:Label ID="Label7" runat="server" Text="Gasto Conserje" Style="color: black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:TextBox runat="server" ID="txtGConserje" class="form-control" aria-describedby="emailHelp" placeholder="Gasto Conserje" MaxLength="20"
                    TextMode="Number" OnTextChanged="txtGOtro_TextChanged"></asp:TextBox>
            </div>
            <!-- Validacion de Gasto Conserje-->
            <div style="display: inline-block">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtGConserje"
                    ValidationGroup="gasto"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <!-- Gasto Guardia -->
            <asp:Label ID="Label1" runat="server" Text="Gasto Guardia" Style="color: black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:TextBox runat="server" ID="txtGGuardia" class="form-control" aria-describedby="emailHelp" placeholder="Gasto Guardia" MaxLength="20"
                    TextMode="Number" OnTextChanged="txtGOtro_TextChanged"></asp:TextBox>
            </div>
            <!-- Validacion de Gasto Guardia-->
            <div style="display: inline-block">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtGGuardia"
                    ValidationGroup="gasto"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <!-- Gasto Mantencion Areas -->
            <asp:Label ID="Label2" runat="server" Text="Gasto Mantencion Areas" Style="color: black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:TextBox runat="server" ID="txtGMantAreas" class="form-control" aria-describedby="emailHelp" placeholder="Gasto Mantencion Areas" MaxLength="20"
                    TextMode="Number" OnTextChanged="txtGOtro_TextChanged"></asp:TextBox>
            </div>
            <!-- Validacion de Mantencion Areas-->
            <div style="display: inline-block">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtGMantAreas"
                    ValidationGroup="gasto"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <!-- Gasto Camaras -->
            <asp:Label ID="Label3" runat="server" Text="Gasto Camaras" Style="color: black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:TextBox runat="server" ID="txtGCamaras" class="form-control" aria-describedby="emailHelp" placeholder="Gasto Camaras" MaxLength="20"
                    TextMode="Number" OnTextChanged="txtGOtro_TextChanged"></asp:TextBox>
            </div>
            <!-- Validacion de Gasto Camaras-->
            <div style="display: inline-block">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtGCamaras"
                    ValidationGroup="gasto"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <!-- Gasto Articulos de Aseo -->
            <asp:Label ID="Label4" runat="server" Text="Gasto Articulos de Aseo" Style="color: black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:TextBox runat="server" ID="txtGArtAseo" class="form-control" aria-describedby="emailHelp" placeholder="Gasto Articulos de Aseo" MaxLength="20"
                    TextMode="Number" OnTextChanged="txtGOtro_TextChanged"></asp:TextBox>
            </div>
            <!-- Validacion de Gasto Articulos de Aseo-->
            <div style="display: inline-block">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtGArtAseo"
                    ValidationGroup="gasto"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <!-- Gasto Aseo -->
            <asp:Label ID="Label5" runat="server" Text="Gasto Aseo" Style="color: black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:TextBox runat="server" ID="txtGAseo" class="form-control" aria-describedby="emailHelp" placeholder="Gasto Aseo" MaxLength="20"
                    TextMode="Number" OnTextChanged="txtGOtro_TextChanged"></asp:TextBox>
            </div>
            <!-- Validacion de Gasto Aseo-->
            <div style="display: inline-block">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtGAseo"
                    ValidationGroup="gasto"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <!-- Gasto Ascensor -->
            <asp:Label ID="Label6" runat="server" Text="Gasto Ascensor" Style="color: black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:TextBox runat="server" ID="txtGAscensor" class="form-control" aria-describedby="emailHelp" placeholder="Gasto Ascensor" MaxLength="20"
                    TextMode="Number" OnTextChanged="txtGOtro_TextChanged"></asp:TextBox>
            </div>
            <!-- Validacion de Gasto Ascensor-->
            <div style="display: inline-block">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtGAscensor"
                    ValidationGroup="gasto"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <!-- Gasto Agua Caliente -->
            <asp:Label ID="Label9" runat="server" Text="Gasto Agua Caliente" Style="color: black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:TextBox runat="server" ID="txtGAgua" class="form-control" aria-describedby="emailHelp" placeholder="Gasto Agua Caliente" MaxLength="20"
                    TextMode="Number" OnTextChanged="txtGOtro_TextChanged"></asp:TextBox>
            </div>
            <!-- Validacion de Gasto Agua Caliente-->
            <div style="display: inline-block">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtGAgua"
                    ValidationGroup="gasto"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <!-- Gasto Otro -->
            <asp:Label ID="Label10" runat="server" Text="Gasto Otro" Style="color: black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:TextBox runat="server" ID="txtGOtro" class="form-control" aria-describedby="emailHelp" placeholder="Gasto Otro" MaxLength="20"
                    TextMode="Number" OnTextChanged="txtGOtro_TextChanged" AutoPostBack="true"></asp:TextBox>
            </div>
            <!-- Validacion de Gasto Otro-->
            <div style="display: inline-block">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtGOtro"
                    ValidationGroup="gasto"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <!-- Gasto Total -->
            <asp:Label ID="Label11" runat="server" Text="Total" Style="color: black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:Label ID="lbTotal" runat="server" Text="" class="form-control" aria-describedby="emailHelp"></asp:Label>
            </div>
            <br />
            <br />

            <asp:Button runat="server" ID="btnAgregarGasto" class="btn btn-light btn-block my-4" Text="Agregar Gasto" OnClick="btnAgregarGasto_Click"
                ValidationGroup="gasto" />
            <!-- Lista Elementos -->
            <asp:Label ID="lbGastos" runat="server" Text="Lista Gastos" ForeColor="Black" Visible="false"></asp:Label><br />
            <asp:Label ID="lbError" runat="server" Text="Edificio ya Posee Gasto Asociado" ForeColor="Red" Visible="false"></asp:Label><br />
            <asp:GridView ID="grGastos" runat="server" CssClass="table table-striped w-auto" AutoGenerateColumns="False" DataKeyNames="_ID_EDIFICIO"
                Font-Size="10pt" AllowPaging="true" PageSize="6" OnSelectedIndexChanged="grGastos_SelectedIndexChanged"
                OnPageIndexChanging="grGastos_PageIndexChanging" Visible="false">
                <Columns>
                    <asp:BoundField DataField="_NOMBRE_EDIFICIO" HeaderText="Edificio" SortExpression="_NOMBRE_EDIFICIO" />
                    <asp:BoundField DataField="_GASTO_CONSERJE" HeaderText="Conserje" SortExpression="_GASTO_CONSERJE" />
                    <asp:BoundField DataField="_GASTO_GUARDIA" HeaderText="Guardia" SortExpression="_GASTO_GUARDIA" />
                    <asp:BoundField DataField="_GASTO_MANTENCION_AREAS" HeaderText="Mant. Areas" SortExpression="_GASTO_MANTENCION_AREAS" />
                    <asp:BoundField DataField="_GASTO_CAMARAS" HeaderText="Camaras" SortExpression="_GASTO_CAMARAS" />
                    <asp:BoundField DataField="_GASTO_ARTICULOS_ASEO" HeaderText="Art. Aseo" SortExpression="_GASTO_ARTICULOS_ASEO" />
                    <asp:BoundField DataField="_GASTOS_ASEO" HeaderText="Aseo" SortExpression="_GASTOS_ASEO" />
                    <asp:BoundField DataField="_GASTO_ASCENSOR" HeaderText="Ascensor" SortExpression="_GASTO_ASCENSOR" />
                    <asp:BoundField DataField="_GASTO_AGUA_CALIENTE" HeaderText="Agua" SortExpression="_GASTO_AGUA_CALIENTE" />
                    <asp:BoundField DataField="_GASTO_OTRO" HeaderText="Otro" SortExpression="_GASTO_OTRO" />
                    <asp:BoundField DataField="_TOTAL_GASTO" HeaderText="Total" SortExpression="_TOTAL_GASTO" />
                    <asp:CommandField ShowSelectButton="True" HeaderText="Eliminar" />
                </Columns>
            </asp:GridView>

            <!-- Sign in button -->
            <asp:UpdatePanel ID="barraProgreso" runat="server">
                <ContentTemplate>
                    <asp:Button runat="server" ID="btnRegistroGasto" class="btn btn-light btn-block my-4" Text="Registrar Gasto" OnClick="btnRegistroGasto_Click" />
                    <asp:Button runat="server" ID="btnModificarGasto" class="btn btn-light btn-block my-4" Text="Modificar Gasto"
                        OnClick="btnModificarGasto_Click" Visible="false" />
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