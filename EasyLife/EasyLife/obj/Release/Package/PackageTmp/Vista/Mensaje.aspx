<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="Mensaje.aspx.cs" Inherits="EasyLife.Vista.Mensaje" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Mensajeria</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <section class="form-control mb-4" style="width: 40%; height: auto; margin-left: 30%; margin-top: 6%; background-color: #BB8FCE">
        <!-- Default form login -->
        <form class="text-center border border-light p-5" action="#!">
            <p class="h4 mb-4 text-center" style="color: black">Envio de Mensaje</p>
            <div class="card-body">
                <%-- Motivo --%>
                <div class="form-group" style="display: inline-block; width: 90%">
                    <label for="list1" style="color: black">Motivo de Contacto:</label>
                    <asp:DropDownList ID="dplMotivo" runat="server" CssClass="form-control" OnSelectedIndexChanged="dplMotivo_SelectedIndexChanged">
                        <asp:ListItem>Seleccionar un Motivo</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <!-- Validacion Motivo -->
                <div style="display: inline-block">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplMotivo"
                        Display="Dynamic" InitialValue="Seleccionar un Motivo"></asp:RequiredFieldValidator>
                </div>

                <%-- Destinatario --%>
                <div class="form-group" style="display: inline-block; width: 90%">
                    <label for="list1" style="color: black">Destinatario:</label>
                    <asp:DropDownList ID="dplDestino" runat="server" CssClass="form-control">
                        <asp:ListItem>Seleccionar un Destinatario</asp:ListItem>
                        <asp:ListItem Value="Conserjeria">Conserjeria</asp:ListItem>
                        <asp:ListItem Value="Administración">Administración</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <!-- Validacion Motivo -->
                <div style="display: inline-block">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplDestino"
                        Display="Dynamic" InitialValue="Seleccionar un Destinatario"></asp:RequiredFieldValidator>
                </div>

                <%--Area de Texto--%>
                <div class="form-group" style="display: inline-block; width: 90%">
                    <label style="color: black">Mensaje:</label>
                    <asp:TextBox ID="txtArea" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="5" placeholder="Mensaje"></asp:TextBox>
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