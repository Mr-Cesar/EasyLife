<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="ProgramarLuzDepartamento.aspx.cs" Inherits="EasyLife.Vista.ProgramarLuzDepartamento" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Programar Luz</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <section class="form-control mb-4" style="width: 40%; height: auto; margin-left: 30%; margin-top: 6%; background-color: #BB8FCE">
        <!-- Default form login -->
        <form class="text-center border border-light p-5" action="#!">
            <p class="h4 mb-4 text-center" style="color: black">
                <asp:Label ID="lbOpcion" runat="server" Text="Control de Luces"></asp:Label>
            </p>
            <section>
                <asp:Panel ID="panelPropDep" runat="server" Visible="true">
                    <%-- Campo de ingreso de Departamento --%>
                    <asp:Label ID="Label6" runat="server" Text="Departamento" Style="color: black"></asp:Label><br />
                    <div style="display: inline-block; width: 90%">
                        <asp:DropDownList ID="dplDepartamento" runat="server" CssClass="form-control" AutoPostBack="true"
                            OnSelectedIndexChanged="dplDepartamento_SelectedIndexChanged">
                            <asp:ListItem>Seleccione un Departamento</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <%-- Validacion de Departamento --%>
                    <div style="display: inline-block;">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplDepartamento"
                            Display="Dynamic" InitialValue="Seleccione un Departamento"></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplDepartamento" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                    <br />
                    <br />
                </asp:Panel>
                <nav>
                    <asp:Panel ID="panelEstado" runat="server" Visible="true">
                        <nav class="col">
                            <div class="form-group row">
                                <label class="col-sm-4 col-form-label" style="color: black;">Estado Actual: </label>
                                <asp:Label ID="lbEstado" CssClass="form-control" runat="server" Text="" Style="width: 30%"></asp:Label>
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
                        </nav>
                    </asp:Panel>
                    <br />

                    <!-- Ingreso de Dia de Ejecucion -->
                    <div class="col">
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
                        <div class="form-group row">
                            <asp:Label ID="Label2" runat="server" Text="Hora de Inicio:" CssClass="col-sm-4 col-form-label" ForeColor="Black"></asp:Label>
                            <asp:TextBox ID="txtHoraInicio" runat="server" CssClass="form-control" Width="20%" TextMode="Time"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtHoraInicio"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <!-- Ingreso de Hora de Termino -->
                    <div class="col">
                        <div class="form-group row">
                            <asp:Label ID="Label3" runat="server" Text="Hora de Termino:" CssClass="col-sm-4 col-form-label" ForeColor="Black"></asp:Label>
                            <asp:TextBox ID="txtHoraTermino" runat="server" CssClass="form-control" Width="20%" TextMode="Time"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtHoraTermino"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <!-- Ingreso de Opcion de Control-->
                    <div class="col">
                        <div class="form-group row">
                            <label class="col-sm-4 col-form-label" style="color: black">Opcion: </label>
                            <asp:RadioButtonList ID="rbOpcion" runat="server" ForeColor="Black">
                                <asp:ListItem Value="Encender">Encender</asp:ListItem>
                                <asp:ListItem Value="Apagar">Apagar</asp:ListItem>
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
                    <asp:Button ID="btnModificarPrograma" runat="server" Text="Modificar" OnClick="btnModificarPrograma_Click" class="btn btn-light btn-block my-4"
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