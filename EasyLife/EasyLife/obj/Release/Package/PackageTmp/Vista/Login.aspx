<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EasyLife.Vista.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Login</title>
    <script type="text/javascript">
        function formatCliente(cliente) {
            cliente.value = cliente.value.replace(/[.-]/g, '')
                .replace(/^(\d{1,2})(\d{3})(\d{3})(\w{1})$/, '$1.$2.$3-$4')
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <section class="form-control mb-4" style="margin: 30px; width: 40%; height: auto; margin-left: 30%; margin-top: 10%; background-color: #BB8FCE">
        <form class="text-center border border-light p-5" action="#!">
            <p class="h4 mb-4 text-center" style="color: black">Sign on</p>
            <%-- Campo de ingreso de Rut --%>
            <asp:Label ID="Label3" runat="server" Text="Rut" ForeColor="Black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:TextBox ID="txtRut" runat="server" placeholder="Rut" CssClass="form-control" onkeyup="formatCliente(this)"></asp:TextBox>
            </div>
            <%-- Validacion de rut --%>
            <div style="display: inline-block;">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtRut" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Formato no Valido" ForeColor="Red" Display="Dynamic" ControlToValidate="txtRut" ValidationExpression="^(\d{1,3}(?:\.\d{1,3}){2}-[\dkK])$"></asp:RegularExpressionValidator>
            </div>
            <br />
            <br />

            <!-- Password -->
            <asp:Label ID="Label1" runat="server" Text="Password" ForeColor="Black"></asp:Label><br />
            <div style="display: inline-block; width: 90%">
                <asp:TextBox runat="server" ID="txtPassword" class="form-control" aria-describedby="emailHelp" placeholder="Enter Password" MaxLength="20"
                    TextMode="Password"></asp:TextBox>
            </div>
            <!-- Validacion de Password-->
            <div style="display: inline-block">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />

            <div class="d-flex justify-content-around">
                <div>
                    <!-- Remember me -->
                    <div class="custom-control custom-checkbox">
                        <input type="checkbox" class="custom-control-input" id="defaultLoginFormRemember">
                        <label class="custom-control-label" for="defaultLoginFormRemember" style="color: black">Remember me</label>
                    </div>
                </div>
                <div>
                    <!-- Forgot password -->
                    <asp:LinkButton ID="lnkRecuperar" runat="server" CausesValidation="false" OnClick="lnkRecuperar_Click">Forgot password?</asp:LinkButton>
                </div>
            </div>

            <asp:UpdatePanel ID="barraProgreso" runat="server">
                <ContentTemplate>
                    <asp:Button runat="server" ID="btnLogin" class="btn btn-light btn-block my-4" Text="Login" OnClick="btnLogin_Click" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </form>
        <%-- Panel que muestra Pop up de carga --%>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="barraProgreso">
            <ProgressTemplate>
                <div class="fImg"></div>
                <div class="fLoad">
                    <p class="h4 mb-4 text-center">Espere Un Momento</p>
                    <br />
                    <br />
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </section>
</asp:Content>