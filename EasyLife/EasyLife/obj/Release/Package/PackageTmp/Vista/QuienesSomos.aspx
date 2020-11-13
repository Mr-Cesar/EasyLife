<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="QuienesSomos.aspx.cs" Inherits="EasyLife.Vista.QuienesSomos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Quienes Somos</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Titulo Seccion -->
    <div class="jumbotron card card-image" style="background-image: url(https://i.postimg.cc/7hH0y8Lk/Section.png);">
        <div class="text-white text-center py-5 px-4">
            <br />
            <div class="container">
                <h2 class="display-4"><strong>Quienes Somos</strong></h2>
                <p class="mx-5 mb-5"><a href="Index.aspx">Home</a> / Quienes Somos</p>
            </div>
        </div>
    </div>

    <!-- Informacion sistema -->
    <section class="showcase" style="margin-top: 4%; margin-bottom: 4%; margin-right: 4%; margin-left: 4%">
        <div class="container-fluid p-0">
            <div class="row no-gutters">
                <asp:Image ID="Image1" runat="server" CssClass="col-lg-6 order-lg-2 text-white showcase-img" ImageUrl="https://i.postimg.cc/fb9mBmF6/Que-es.jpg" />
                <div class="col-lg-6 order-lg-1 my-auto showcase-text">
                    <h2>¿Qué es EasyLife?</h2>
                    <br>
                    <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                        EasyLife Apartments es una organización que tiene como objetivo automatizar procesos de administración y control de iluminación de edificios.
                        En su página web, los usuarios podrán controlar la iluminación de edificios y departamentos, realizar el pago de gastos comunes, reservar áreas
                        comunes de los edificios, recibir avisos y comunicarse entre conserjería y arrendatario.
                    </p>
                </div>
            </div>
            <div class="row no-gutters">
                <asp:Image ID="Image2" runat="server" CssClass="col-lg-6 text-white showcase-img" ImageUrl="https://i.postimg.cc/nhMv961V/Mision.jpg" />
                <div class="col-lg-6 my-auto showcase-text">
                    <h2 style="margin-left: 10px">Misión</h2>
                    <br>
                    <p class="lead mb-0" style="text-align: justify; color: black; margin-left: 10px">
                        <li style="margin-left: 10px">Ofrecer un sistema que lleve la administración de un edificio a la punta de un dedo.</li>
                        <li style="margin-left: 10px">Hacer condominios conectados con la tecnología y la tecnología conectada con personas.</li>
                        <li style="margin-left: 10px">Tu edificio en tus manos.</li>
                        <li style="margin-left: 10px">Llevar la administración de un edificio a cualquier navegador, facilitar el acceso y automatizar procesos.</li>
                        <li style="margin-left: 10px">Ofrecer un sistema de administración e automatización de edificios para mantener la comunidad conectada e informada desde cualquier dispositivo
                            con internet</li>
                    </p>
                </div>
            </div>
            <div class="row no-gutters">
                <asp:Image ID="Image3" runat="server" CssClass="col-lg-6 order-lg-2 text-white showcase-img" ImageUrl="https://i.postimg.cc/HkKbwBSw/Vision.jpg" />
                <div class="col-lg-6 order-lg-1 my-auto showcase-text">
                    <h2>Visión</h2>
                    <br>
                    <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                        “Acelerar la automatización, centralizar la información, facilitar los procesos de condominios y edificios con un toque.”
                    </p>
                </div>
            </div>
            <div class="row no-gutters">
                <asp:Image ID="Image4" runat="server" CssClass="col-lg-6 text-white showcase-img" ImageUrl="https://i.postimg.cc/nLD3fYgM/Pilares.png" />
                <div class="col-lg-6 my-auto showcase-text" style="align-content: center">
                    <h2 style="margin-left: 10px">Pilares</h2>
                    <br>
                    <p class="lead mb-0" style="text-align: justify; color: black; margin-left: 10px">
                        Nuestra identidad se enmarca en:<br>
                        <br>
                        <li style="margin-left: 10px">Conocimiento informático.</li>
                        <li style="margin-left: 10px">Experiencia en situaciones de contingencia.</li>
                        <li style="margin-left: 10px">Facilitar el trabajo de conserjería.</li>
                        <li style="margin-left: 10px">Facilitar el cobro de gastos comunes para ambos lados.</li>
                        <li style="margin-left: 10px">Disminuir los gastos de luces con la automatización.</li>
                        <li style="margin-left: 10px">Centralizar la información.</li>
                        <li style="margin-left: 10px">Administrar áreas comunes con mayor facilidad.</li>
                    </p>
                </div>
            </div>
        </div>
    </section>
</asp:Content>