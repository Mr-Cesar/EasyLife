<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="Mensaje.aspx.cs" Inherits="EasyLife.Vista.Mensaje" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Mensajeria</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <section class="form-control mb-4" style="width: 40%; height: auto; margin-left: 30%; margin-top: 6%; background-color: #BB8FCE">
        <!-- Default form login -->
        <form class="text-center border border-light p-5" action="#!">
            <p class="h4 mb-4 text-center" style="color: black">Envio de Avisos</p>
            <div class="card-body">
                <%-- Motivo --%>
                <div class="form-group" style="display: inline-block; width: 90%">
                    <label for="list1" style="color: black">Motivo de Contacto:</label>
                    <asp:DropDownList ID="dplMotivo" runat="server" CssClass="form-control" OnSelectedIndexChanged="dplMotivo_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem>Seleccione un Motivo</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <!-- Validacion Motivo -->
                <div style="display: inline-block">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplMotivo"
                        Display="Dynamic" InitialValue="Seleccione un Motivo"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplMotivo"
                        Display="Dynamic"></asp:RequiredFieldValidator>
                </div>

                <asp:Panel ID="panelCondominio" runat="server" Visible="false">
                    <%-- Condominio --%>
                    <div class="form-group" style="display: inline-block; width: 90%">
                        <label for="list1" style="color: black">Condominio:</label>
                        <asp:DropDownList ID="dplCondominio" runat="server" CssClass="form-control" OnSelectedIndexChanged="dplCondominio_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem>Seleccione un Condominio</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <!-- Validacion Condominio -->
                    <div style="display: inline-block">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplCondominio"
                            Display="Dynamic" InitialValue="Seleccione un Condominio"></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplCondominio"
                            Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </asp:Panel>

                <asp:Panel ID="panelEdificio" runat="server" Visible="false">
                    <%-- Edificio --%>
                    <div class="form-group" style="display: inline-block; width: 90%">
                        <label for="list1" style="color: black">Edifcio:</label>
                        <asp:DropDownList ID="dplEdificio" runat="server" CssClass="form-control" OnSelectedIndexChanged="dplEdificio_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem>Seleccione un Edificio</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <!-- Validacion Edificio -->
                    <div style="display: inline-block">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplEdificio"
                            Display="Dynamic" InitialValue="Seleccione un Edificio"></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplEdificio"
                            Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </asp:Panel>

                <asp:Panel ID="panelDepartamento" runat="server" Visible="false">
                    <%-- Departamento --%>
                    <div class="form-group" style="display: inline-block; width: 90%">
                        <label for="list1" style="color: black">Departamento:</label>
                        <asp:DropDownList ID="dplDepartamento" runat="server" CssClass="form-control" OnSelectedIndexChanged="dplDepartamento_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem>Seleccione un Departamento</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <!-- Validacion Departamento -->
                    <div style="display: inline-block">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplDepartamento"
                            Display="Dynamic" InitialValue="Seleccione un Departamento"></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplDepartamento"
                            Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </asp:Panel>

                <asp:Panel ID="panelPersonal" runat="server" Visible="false">
                    <%-- Personal --%>
                    <div class="form-group" style="display: inline-block; width: 90%">
                        <label for="list1" style="color: black">Edifcio:</label>
                        <asp:DropDownList ID="dplPersonal" runat="server" CssClass="form-control" OnSelectedIndexChanged="dplPersonal_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem>Seleccione un Personal</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <!-- Validacion Personal -->
                    <div style="display: inline-block">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplPersonal"
                            Display="Dynamic" InitialValue="Seleccione un Edificio"></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplPersonal"
                            Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </asp:Panel>

                <%--Area de Texto--%>
                <div class="form-group" style="display: inline-block; width: 90%">
                    <label style="color: black">Mensaje:</label>
                    <asp:TextBox ID="txtArea" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="5" placeholder="Mensaje" MaxLength="50"></asp:TextBox>
                </div>
                <!-- Validacion de Mensaje -->
                <div style="display: inline-block">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtArea"
                        Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <br />
                <asp:UpdatePanel ID="barraProgreso" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnEnviar" runat="server" Text="Enviar" CssClass="btn btn-light btn-block my-4" OnClick="btnEnviar_Click" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
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