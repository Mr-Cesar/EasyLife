<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="RegistroGasto.aspx.cs" Inherits="EasyLife.Vista.RegistroGasto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Registro Gasto</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <section class="form-control mb-4" style="margin: 30px; width: 40%; height: auto; margin-left: 30%; margin-top: 5%; background-color: #BB8FCE">
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

                <%-- Campo de Opcion de Agregar el Mismo Gasto a todos los Edificios --%>
                <div style="display: inline-block; width: 90%">
                    <asp:RadioButton ID="radioOpcionGasto" runat="server" Text="Agregar Gasto a Todos los Edificios" ForeColor="Black"
                        OnCheckedChanged="radioOpcionGasto_CheckedChanged" AutoPostBack="true" Checked="false" />
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
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtGConserje"></asp:RequiredFieldValidator>
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
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtGGuardia"></asp:RequiredFieldValidator>
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
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtGMantAreas"></asp:RequiredFieldValidator>
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
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtGCamaras"></asp:RequiredFieldValidator>
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
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtGArtAseo"></asp:RequiredFieldValidator>
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
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtGAseo"></asp:RequiredFieldValidator>
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
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtGAscensor"></asp:RequiredFieldValidator>
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
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtGAgua"></asp:RequiredFieldValidator>
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
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtGOtro"></asp:RequiredFieldValidator>
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