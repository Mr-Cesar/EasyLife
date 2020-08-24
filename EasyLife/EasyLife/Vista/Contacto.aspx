<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="EasyLife.Vista.Contacto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Contáctenos</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <!-- Titulo Seccion -->
    <div class="jumbotron card card-image" style="background-image: url(https://i.postimg.cc/7hH0y8Lk/Section.png);">
        <div class="text-white text-center py-5 px-4">
            <div class="container">
                <h2 class="display-4"><strong>Contáctenos </strong></h2>
                <p class="mx-5 mb-5"><a href="Index.aspx">Home</a> / Contáctenos </p>
            </div>
        </div>
    </div>

    <div style="width: 40%; margin: auto; margin-bottom: 4%;">
        <div>
            <div class="card mx-xl-5" style="background-color: #BB8FCE">
                <div class="card-body">
                    <form>
                        <%--Motivo--%>
                        <div class="form-group" style="display: inline-block; width: 90%">
                            <label for="list1">Motivo de Contacto:</label>
                            <asp:DropDownList ID="dplMotivo" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                        </div>
                        <!-- Validacion Motivo -->
                        <div style="display: inline-block">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dplMotivo"
                                Display="Dynamic" InitialValue="Seleccionar..."></asp:RequiredFieldValidator>
                        </div>

                        <%--Nombre--%>
                        <div class="form-group" style="display: inline-block; width: 90%">
                            <label for="txtInput1">Nombre:</label>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Nombre"></asp:TextBox>
                        </div>
                        <!-- Validacion de Nombre -->
                        <div style="display: inline-block">
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Debe ingresar solo letras." ForeColor="Red"
                                ControlToValidate="txtNombre" ValidationExpression="^[a-zA-Z]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtNombre"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>

                        <%--Apellido--%>
                        <div class="form-group" style="display: inline-block; width: 90%">
                            <label for="txtInput2">Apellidos:</label>
                            <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" placeholder="Apellidos"></asp:TextBox>
                        </div>
                        <!-- Validacion de Apellidos -->
                        <div style="display: inline-block">
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Debe ingresar solo letras." ForeColor="Red"
                                ControlToValidate="txtApellido" ValidationExpression="^[a-zA-Z]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtApellido"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>

                        <%--Mail--%>
                        <div class="form-group" style="display: inline-block; width: 90%">
                            <label for="txtInput3">Email:</label>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Email"></asp:TextBox>
                        </div>
                        <!-- Validacion de Email -->
                        <div style="display: inline-block">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtEmail"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Formato de correo no Valido" ForeColor="Red" Display="Dynamic"
                                ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </div>

                        <%--Area de Texto--%>
                        <div class="form-group" style="display: inline-block; width: 90%">
                            <label>Mensaje:</label>
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
                </div>
            </div>
        </div>
    </div>
</asp:Content>