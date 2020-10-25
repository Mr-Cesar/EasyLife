<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="DetalleGastoComun.aspx.cs" Inherits="EasyLife.Vista.DetalleGastoComun" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Detalle Gasto Común</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="jumbotron card card-image" style="background-image: url(https://i.postimg.cc/7hH0y8Lk/Section.png);">
                <div class="text-white text-center py-5 px-4">
                    <div class="container">
                        <h2 class="display-4"><strong>Detalle de Gasto Común</strong></h2>
                        <p class="mx-5 mb-5"><a href="Index.aspx">Home</a> / Preguntas Frecuentes</p>
                    </div>
                </div>
            </div>

            <div style="text-align: center; width: 80%; margin: auto; margin-bottom: 4%;">
                <div class="form-inline my-3 my-lg-0">
                    <asp:DropDownList ID="dplCondominio" runat="server" CssClass="form-control"
                        AutoPostBack="true" OnSelectedIndexChanged="dplCondominio_SelectedIndexChanged">
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="dplEdificio" runat="server" CssClass="form-control"
                        AutoPostBack="true" OnSelectedIndexChanged="dplEdificio_SelectedIndexChanged">
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="dplAño" runat="server" CssClass="form-control"
                        AutoPostBack="true" OnSelectedIndexChanged="dplAño_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <br />

                <asp:Label ID="Label6" runat="server" Text="Detalle de Gastos Comunes" ForeColor="Black"></asp:Label>
                <asp:Label ID="lbErrorAño" runat="server" Text="No se Encontraron Datos" Visible="false"></asp:Label>
                <br />

                <asp:GridView ID="grDetalle" runat="server" CssClass="table table-striped w-auto" AutoGenerateColumns="False" DataKeyNames="_ID_GASTOS"
                    Font-Size="10pt" AllowPaging="true" PageSize="6" OnPageIndexChanging="grDetalle_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="_NOMBRE_EDIFICIO" HeaderText="Edificio" SortExpression="_NOMBRE_EDIFICIO" />
                        <asp:BoundField DataField="_MES" HeaderText="Mes" SortExpression="_MES" />
                        <asp:BoundField DataField="_ANO" HeaderText="Año" SortExpression="_ANO" />
                        <asp:BoundField DataField="_GASTO_CONSERJE" HeaderText="Conserje" SortExpression="_GASTO_CONSERJE" />
                        <asp:BoundField DataField="_GASTO_GUARDIA" HeaderText="Guardia" SortExpression="_GASTO_GUARDIA" />
                        <asp:BoundField DataField="_GASTO_MANTENCION_AREAS" HeaderText="Mantención Areas" SortExpression="_GASTO_MANTENCION_AREAS" />
                        <asp:BoundField DataField="_GASTO_CAMARAS" HeaderText="Camaras" SortExpression="_GASTO_CAMARAS" />
                        <asp:BoundField DataField="_GASTO_ARTICULOS_ASEO" HeaderText="Art. Aseo" SortExpression="_GASTO_ARTICULOS_ASEO" />
                        <asp:BoundField DataField="_GASTOS_ASEO" HeaderText="Aseo" SortExpression="_GASTOS_ASEO" />
                        <asp:BoundField DataField="_GASTO_ASCENSOR" HeaderText="Ascensor" SortExpression="_GASTO_ASCENSOR" />
                        <asp:BoundField DataField="_GASTO_AGUA_CALIENTE" HeaderText="Agua Caliente" SortExpression="_GASTO_AGUA_CALIENTE" />
                        <asp:BoundField DataField="_GASTO_OTRO" HeaderText="Otros" SortExpression="_GASTO_OTRO" />
                        <asp:BoundField DataField="_TOTAL_GASTO" HeaderText="Total" SortExpression="_TOTAL_GASTO" />
                    </Columns>
                </asp:GridView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>