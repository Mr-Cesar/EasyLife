<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="RegistroEstacionamiento.aspx.cs" Inherits="EasyLife.Vista.RegistroEstacionamiento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Registro Estacionamiento</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <section class="form-control mb-4" style="margin: 30px; width: 40%; height: auto; margin-left: 30%; margin-top: 5%; background-color: #BB8FCE">
        <!-- Default form login -->
        <form class="text-center border border-light p-5" action="#!">
            <p class="h4 mb-4 text-center" style="color: black">
                <asp:Label ID="lbTitulo" runat="server" Text="Estacionamiento Visita"></asp:Label>
            </p>
            <section>
                <asp:Panel ID="panelRegistro" runat="server">
                    <%-- Campo de ingreso de Edificio --%>
                    <asp:Label ID="Label8" runat="server" Text="Edificio" Style="color: black"></asp:Label><br />
                    <div style="display: inline-block; width: 90%">
                        <asp:DropDownList ID="dplEdificio" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dplEdificio_SelectedIndexChanged">
                            <asp:ListItem>Seleccione un Edificio</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <%-- Validacion de Edificio --%>
                    <div style="display: inline-block;">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplEdificio"
                            Display="Dynamic" InitialValue="Seleccione un Edificio"></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplEdificio" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                    <br />
                    <br />

                    <%-- Campo de ingreso de Departamento --%>
                    <asp:Label ID="Label1" runat="server" Text="Departamento" Style="color: black"></asp:Label><br />
                    <div style="display: inline-block; width: 90%">
                        <asp:DropDownList ID="dplDepartamento" runat="server" CssClass="form-control" AutoPostBack="true">
                            <asp:ListItem>Seleccione un Departamento</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <%-- Validacion de Departamento --%>
                    <div style="display: inline-block;">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplDepartamento"
                            Display="Dynamic" InitialValue="Seleccione un Departamento"></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplDepartamento" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                    <br />
                    <br />
                </asp:Panel>

                <!-- Campo de Patente -->
                <asp:Label ID="Label7" runat="server" Text="Patente" Style="color: black"></asp:Label><br />
                <div style="display: inline-block; width: 90%">
                    <asp:TextBox runat="server" ID="txtPatente" class="form-control" aria-describedby="emailHelp" placeholder="Patente" MaxLength="6"></asp:TextBox>
                </div>
                <!-- Campo de Patente -->
                <div style="display: inline-block">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtPatente"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Formato no Valido" ForeColor="Red"
                        Display="Dynamic" ControlToValidate="txtPatente" ValidationExpression="^[a-z]{4}[0-9]{2}$"></asp:RegularExpressionValidator>
                </div>
                <br />
                <br />

                <!-- Campo de Hora Entrada -->
                <asp:Label ID="Label2" runat="server" Text="Hora Entrada" Style="color: black"></asp:Label><br />
                <div style="display: inline-block; width: 90%">
                    <asp:TextBox runat="server" ID="txtHoraEntrada" class="form-control" aria-describedby="emailHelp" placeholder="Hora Entrada" TextMode="Time"></asp:TextBox>
                </div>
                <!-- Campo de Hora Entrada -->
                <div style="display: inline-block">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtHoraEntrada"></asp:RequiredFieldValidator>
                </div>
                <br />
                <br />

                <!-- Campo de Hora Salida -->
                <asp:Label ID="Label4" runat="server" Text="Hora Salida" Style="color: black"></asp:Label><br />
                <div style="display: inline-block; width: 90%">
                    <asp:TextBox runat="server" ID="txtHoraSalida" class="form-control" aria-describedby="emailHelp" placeholder="Hora Salida"
                        TextMode="Time" OnTextChanged="txtHoraSalida_TextChanged" AutoPostBack="true" Enabled="false"></asp:TextBox>
                </div>
                <!-- Campo de Hora Salida -->
                <div style="display: inline-block">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtHoraSalida"
                        Enabled="false" Visible="false"></asp:RequiredFieldValidator>
                </div>
                <br />
                <br />

                <!-- Campo de Total -->
                <asp:Label ID="Label11" runat="server" Text="Total" Style="color: black"></asp:Label><br />
                <div style="display: inline-block; width: 90%">
                    <asp:Label ID="lbTotal" runat="server" Text="" class="form-control" aria-describedby="emailHelp"></asp:Label>
                </div>
                <br />
                <br />

                <!-- Sign in button -->
                <asp:UpdatePanel ID="barraProgreso" runat="server">
                    <ContentTemplate>
                        <asp:Button runat="server" ID="btnRegistroEst" class="btn btn-light btn-block my-4" Text="Registrar Entrada Visita"
                            OnClick="btnRegistroEst_Click" UseSubmitBehavior="false" />
                        <asp:Button runat="server" ID="btnRegistroSalida" class="btn btn-light btn-block my-4" Text="Registrar Salida Visita" Visible="false"
                            OnClick="btnRegistroSalida_Click" UseSubmitBehavior="false" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </section>
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