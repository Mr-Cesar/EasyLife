<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="ProgramarLuzEdificio.aspx.cs" Inherits="EasyLife.Vista.ProgramarLuzEdificio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Programar Luz</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <section class="form-control mb-4" style="margin: 30px; width: 40%; height: auto; margin-left: 30%; margin-top: 5%; background-color: #BB8FCE">
        <!-- Default form login -->
        <form class="text-center border border-light p-5" action="#!">
            <p class="h4 mb-4 text-center" style="color: black">
                <asp:Label ID="lbOpcion" runat="server" Text="Control de Luces"></asp:Label>
            </p>
            <section>
                <nav class="col">
                    <asp:Panel ID="panelCondominio" runat="server" Visible="true">
                        <%-- Campo de ingreso de Condominio --%>
                        <asp:Label ID="Label4" runat="server" Text="Condominio" Style="color: black"></asp:Label><br />
                        <asp:Label ID="lbCondominio" runat="server" Text="asd" ForeColor="Black" Visible="false"></asp:Label>
                        <div style="display: inline-block; width: 90%">
                            <asp:DropDownList ID="dplCondominio" runat="server" CssClass="form-control" AutoPostBack="true"
                                OnSelectedIndexChanged="dplCondominio_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <%-- Validacion de Condominio --%>
                        <div style="display: inline-block;">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplCondominio"
                                Display="Dynamic" InitialValue="Seleccione un Condominio"></asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplCondominio"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <br />
                        <br />
                    </asp:Panel>

                    <%-- Campo de ingreso de Edificio --%>
                    <asp:Label ID="Label12" runat="server" Text="Edificio" Style="color: black"></asp:Label><br />
                    <asp:Label ID="lbEdificio" runat="server" Text="" ForeColor="Black" Visible="false"></asp:Label>
                    <div style="display: inline-block; width: 90%">
                        <asp:DropDownList ID="dplEdificio" runat="server" CssClass="form-control" AutoPostBack="true"
                            OnSelectedIndexChanged="dplEdificio_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <%-- Validacion de Edificio --%>
                    <div style="display: inline-block;">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplEdificio"
                            Display="Dynamic" InitialValue="Seleccione un Edificio"></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplEdificio"
                            Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                    <br />
                    <br />

                    <%-- Campo de ingreso de Luz --%>
                    <asp:Label ID="Label5" runat="server" Text="Luz" Style="color: black"></asp:Label><br />
                    <asp:Label ID="lbLuz" runat="server" Text="asd" ForeColor="Black" Visible="false"></asp:Label>
                    <div style="display: inline-block; width: 90%">
                        <asp:DropDownList ID="dplLuz" runat="server" CssClass="form-control" AutoPostBack="true"
                            OnSelectedIndexChanged="dplLuz_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <%-- Validacion de Luz --%>
                    <div style="display: inline-block;">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplLuz"
                            Display="Dynamic" InitialValue="Seleccione una Luz"></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplLuz" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                    <br />
                    <br />

                    <div class="form-group row">
                        <label class="col-sm-4 col-form-label" style="color: black;">Estado Actual: </label>
                        <asp:Label ID="lbEstado" CssClass="form-control" runat="server" Text="Label" Style="width: 30%"></asp:Label>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-3 col-form">
                            <asp:Button ID="btnEncenderLuz" runat="server" CssClass="btn btn-light btn-block waves-effect" CausesValidation="false" Text="Encender"
                                OnClick="btnEncenderLuz_Click" />
                        </div>
                        <div class="col-sm-3 col-form">
                            <asp:Button ID="btnApagarLuz" runat="server" CssClass="btn btn-light btn-block waves-effect" CausesValidation="false" Text="Apagar"
                                OnClick="btnApagarLuz_Click" />
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-4 col-form">
                            <asp:Button ID="btnEncenderTodo" runat="server" CssClass="btn btn-light btn-block waves-effect" CausesValidation="false" Text="Encender Todo"
                                OnClick="btnEncenderTodo_Click" />
                        </div>
                        <div class="col-sm-4 col-form">
                            <asp:Button ID="btnApagarTodo" runat="server" CssClass="btn btn-light btn-block waves-effect" CausesValidation="false" Text="Apagar Todo"
                                OnClick="btnApagarTodo_Click" />
                        </div>
                    </div>
                </nav>

                <nav>
                    <h4>
                        <asp:Label ID="Label8" runat="server" Text="Programar Luz" CssClass="col-sm-4 col-form-label" Style="color: black"></asp:Label>
                    </h4>
                    <!-- Ingreso de Dia de Ejecucion -->
                    <div class="col">
                        <asp:Label ID="lbDia" runat="server" Text="asd" ForeColor="Black" Visible="false"></asp:Label>
                        <div class="form-group row">
                            <asp:Label ID="Label1" runat="server" Text="Día Ejecución: " CssClass="col-sm-4 col-form-label" ForeColor="Black"></asp:Label>
                            <asp:TextBox ID="txtDia" runat="server" CssClass="form-control" Width="30%" TextMode="Date"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtDia"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Año Incorrecto" ForeColor="Red" ControlToValidate="txtDia"
                                MinimumValue="01-01-2020" MaximumValue="31-12-2020"></asp:RangeValidator>
                        </div>
                    </div>

                    <!-- Ingreso de Hora de Inicio -->
                    <div class="col">
                        <asp:Label ID="lbHoraI" runat="server" Text="asd" ForeColor="Black" Visible="false"></asp:Label>
                        <div class="form-group row">
                            <asp:Label ID="Label2" runat="server" Text="Hora de Inicio:" CssClass="col-sm-4 col-form-label" ForeColor="Black"></asp:Label>
                            <asp:TextBox ID="txtHoraInicio" runat="server" CssClass="form-control" Width="20%" TextMode="Time"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtHoraInicio"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <!-- Ingreso de Hora de Termino -->
                    <div class="col">
                        <asp:Label ID="lbHoraT" runat="server" Text="asd" ForeColor="Black" Visible="false"></asp:Label>
                        <div class="form-group row">
                            <asp:Label ID="Label3" runat="server" Text="Hora de Termino:" CssClass="col-sm-4 col-form-label" ForeColor="Black"></asp:Label>
                            <asp:TextBox ID="txtHoraTermino" runat="server" CssClass="form-control" Width="20%" TextMode="Time"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtHoraTermino"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col">
                        <asp:Label ID="lbOption" runat="server" Text="asd" ForeColor="Black" Visible="false"></asp:Label>
                        <div class="form-group row">
                            <label class="col-sm-4 col-form-label" style="color: black">Opcion: </label>
                            <asp:RadioButtonList ID="rbOpcion" runat="server" ForeColor="Black">
                                <asp:ListItem>Encender</asp:ListItem>
                                <asp:ListItem>Apagar</asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="rbOpcion"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </nav>
            </section>

            <!-- Sign in button -->
            <asp:UpdatePanel ID="barraProgreso" runat="server">
                <ContentTemplate>
                    <asp:Button runat="server" ID="btnProgramarLuz" class="btn btn-light btn-block my-4" Text="Programar" OnClick="btnProgramarLuz_Click" />
                    <asp:Button ID="btnModificarPrograma" runat="server" Text="Modificar" class="btn btn-light btn-block my-4" OnClick="btnModificarPrograma_Click"
                        Visible="false" CausesValidation="false" />
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