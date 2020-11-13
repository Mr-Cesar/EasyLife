<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="Servicios.aspx.cs" Inherits="EasyLife.Vista.Servicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Servicios</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <!-- Titulo Seccion -->
            <div class="jumbotron card card-image" style="background-image: url(https://i.postimg.cc/7hH0y8Lk/Section.png);">
                <div class="text-white text-center py-5 px-4">
                    <div class="container">
                        <h2 class="display-4"><strong>Servicios</strong></h2>
                        <p class="mx-5 mb-5"><a href="Index.aspx">Home</a> / Servicios</p>
                    </div>
                </div>
            </div>

            <!-- Tutoriales -->
            <div class="row" style="margin-left: 10%; margin-top: 5%; margin-bottom: 4%; width: 80%">
                <div class="col-4">
                    <div class="list-group" id="list-tab" role="tablist">
                        <!-- Opciones Propietario -->
                        <asp:Button ID="btnOperacionesBasicas" runat="server" Text="Login" CssClass="list-group-item list-group-item-action" BackColor="LightBlue"
                            OnClick="btnOperacionesBasicas_Click" />
                        <asp:Button ID="btnGastos" runat="server" Text="Pago de Gastos Comunes" CssClass="list-group-item list-group-item-action"
                            OnClick="btnGastos_Click" />
                        <asp:Button ID="btnMensajeria" runat="server" Text="Mensajería" CssClass="list-group-item list-group-item-action"
                            OnClick="btnMensajeria_Click" />
                        <asp:Button ID="btnReserva" runat="server" Text="Reserva de Centros" CssClass="list-group-item list-group-item-action"
                            OnClick="btnReserva_Click" />
                        <asp:Button ID="btnLuces" runat="server" Text="Control de Luces" CssClass="list-group-item list-group-item-action"
                            OnClick="btnLuces_Click" />
                        <asp:Button ID="btnPassword" runat="server" Text="Cambiar Password" CssClass="list-group-item list-group-item-action"
                            OnClick="btnPassword_Click" />
                        <asp:Button ID="btnPerfilPropietario" runat="server" Text="Perfil" CssClass="list-group-item list-group-item-action"
                            OnClick="btnPerfilPropietario_Click" />

                        <!-- Opciones Vendedor -->
                        <asp:Button ID="btnRegistroPropietario" runat="server" Text="Registrar Propietario" CssClass="list-group-item list-group-item-action"
                            OnClick="btnRegistroPropietario_Click" />
                        <asp:Button ID="btnPerfilVendedor" runat="server" Text="Perfil" CssClass="list-group-item list-group-item-action"
                            OnClick="btnPerfilVendedor_Click" />

                        <!-- Opciones Conserje -->
                        <asp:Button ID="btnRegistroEst" runat="server" Text="Registro Estacionamiento" CssClass="list-group-item list-group-item-action"
                            OnClick="btnRegistroEst_Click" />
                        <asp:Button ID="btnReservaCentro" runat="server" Text="Reserva Centro" CssClass="list-group-item list-group-item-action"
                            OnClick="btnReservaCentro_Click" />
                        <asp:Button ID="btnPagoGasto" runat="server" Text="Pago de Gasto Común" CssClass="list-group-item list-group-item-action"
                            OnClick="btnPagoGasto_Click" />
                        <asp:Button ID="btnControlLuces" runat="server" Text="Control de Luces" CssClass="list-group-item list-group-item-action"
                            OnClick="btnControlLuces_Click" />
                        <asp:Button ID="btnPerfilConserje" runat="server" Text="Perfil" CssClass="list-group-item list-group-item-action"
                            OnClick="btnPerfilConserje_Click" />

                        <!-- Opciones Administrador de Condominio -->
                        <asp:Button ID="btnMulta" runat="server" Text="Asignar Multa" CssClass="list-group-item list-group-item-action"
                            OnClick="btnMulta_Click" />
                        <asp:Button ID="btnPerfilAdmCondominio" runat="server" Text="Perfil" CssClass="list-group-item list-group-item-action"
                            OnClick="btnPerfilAdmCondominio_Click" />
                        <asp:Button ID="btnRegistroConserje" runat="server" Text="Registro Conserje" CssClass="list-group-item list-group-item-action"
                            OnClick="btnRegistroConserje_Click" />
                        <asp:Button ID="btnRegistroLuces" runat="server" Text="Registro de Luces" CssClass="list-group-item list-group-item-action"
                            OnClick="btnRegistroLuces_Click" />
                        <asp:Button ID="btnAsignarLuz" runat="server" Text="Asignar Luces" CssClass="list-group-item list-group-item-action"
                            OnClick="btnAsignarLuz_Click" />

                        <!-- Opciones Administrados -->
                        <asp:Button ID="btnPerfilAdm" runat="server" Text="Perfil" CssClass="list-group-item list-group-item-action"
                            OnClick="btnPerfilAdm_Click" />
                        <asp:Button ID="btnRegistroPersonal" runat="server" Text="Registro Personal" CssClass="list-group-item list-group-item-action"
                            OnClick="btnRegistroPersonal_Click" />
                        <asp:Button ID="btnRegistroCondominio" runat="server" Text="Registro Condominio" CssClass="list-group-item list-group-item-action"
                            OnClick="btnRegistroCondominio_Click" />
                        <asp:Button ID="btnRegistroCentro" runat="server" Text="Registro de Centro" CssClass="list-group-item list-group-item-action"
                            OnClick="btnRegistroCentro_Click" />
                    </div>
                </div>

                <div class="col-8">
                    <div class="tab-content" id="nav-tabContent">
                        <asp:Panel ID="panelOperaciones" runat="server">
                            <section class="showcase" style="height: 800px; overflow: scroll;">
                                <div class="container-fluid p-0">
                                    <div class="row no-gutters">
                                        <asp:Image ID="Image32" runat="server" CssClass="col-lg-6 order-lg-2 text-white showcase-img"
                                            ImageUrl="https://i.postimg.cc/8c6k5t3v/Login.png" />
                                        <div class="col-lg-6 order-lg-1 my-auto showcase-text">
                                            <h2>Login</h2>
                                            <br>
                                            <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                                            </p>
                                        </div>
                                    </div>
                                    <div class="row no-gutters">
                                        <asp:Image ID="Image33" runat="server" CssClass="col-lg-6 text-white showcase-img"
                                            ImageUrl="https://i.postimg.cc/G2NhdZMr/Recuperar-Password.png" />
                                        <div class="col-lg-6 my-auto showcase-text">
                                            <h2>Recuperación de Password</h2>
                                            <br>
                                            <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                                            </p>
                                        </div>
                                    </div>
                                    <div class="row no-gutters">
                                        <asp:Image ID="Image34" runat="server" CssClass="col-lg-6 order-lg-2 text-white showcase-img"
                                            ImageUrl="https://i.postimg.cc/ZqQC5BR1/Modificar-Datos.png" />
                                        <div class="col-lg-6 order-lg-1 my-auto showcase-text">
                                            <h2>Modificar Datos</h2>
                                            <br>
                                            <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                                                En esta sección se podrá modificar los datos especificados en el perfil los cuales se limitaran al teléfono y correo electrónico.<br />
                                                <br />
                                                1) Ingresar nuevo teléfono para ser establecido en el perfil.<br />
                                                2) Ingresar nuevo correo para ser establecido en el perfil.<br />
                                                3) Presionar para aceptar e ingresar los nuevos datos.<br />
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </section>
                        </asp:Panel>

                        <asp:Panel ID="panelGastos" runat="server" Visible="false">
                            <section class="showcase" style="height: 800px; overflow: scroll;">
                                <div class="container-fluid p-0">
                                    <div class="row no-gutters">
                                        <asp:Image ID="Image1" runat="server" CssClass="col-lg-6 order-lg-2 text-white showcase-img"
                                            ImageUrl="https://i.postimg.cc/QMtqkH2x/Registro-Pago-Gasto-Comun.png" />
                                        <div class="col-lg-6 order-lg-1 my-auto showcase-text">
                                            <h2>Pago de Gasto Común</h2>
                                            <br>
                                            <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                                                Para el pago de gastos comunes de manera presencial el conserje deberá registrar los datos entregados en el siguiente
                                                formulario.<br />
                                                <br />
                                                1) Se debe seleccionar el condómino al que pertenece la persona que desea realizar el pago.<br />
                                                2) Se debe seleccionar la torre especifica de la persona que desea realizar el pago.<br />
                                                3) Se debe seleccionar el departamento de la persona que desea realizar el pago.<br />
                                                4) Se muestra el Rut asociado al gasto común a pagar.<br />
                                                5) Se muestra el detalle del gasto común.<br />
                                                6) Presione para agregar un pago, cabe mencionar que luego de agregado un pago se pueden agregar mas según sea necesario.<br />
                                                7) Se resume los detales del pago junto con el total del/los pagos a registrar.<br />
                                                8) Luego de recibido el pago presione el registro para dejar constancia por sistema del pago realizado.<br />
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </section>
                        </asp:Panel>

                        <asp:Panel ID="panelMensajeria" runat="server" Visible="false">
                            <section class="showcase" style="height: 800px; overflow: scroll;">
                                <div class="container-fluid p-0">
                                    <div class="row no-gutters">
                                        <asp:Image ID="Image2" runat="server" CssClass="col-lg-6 order-lg-2 text-white showcase-img"
                                            ImageUrl="https://i.postimg.cc/KcrgjmW9/Mensajeria-Interna.png" />
                                        <div class="col-lg-6 order-lg-1 my-auto showcase-text">
                                            <h2>Mensajería Interna</h2>
                                            <br>
                                            <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                                                Esta la posibilidad de realizar envió de mensajes entre usuarios para lo cual se tiene el siguiente la siguiente sección.<br />
                                                <br />
                                                1) En esta parte se debe seleccionar un motivo que será establecido previamente para el contacto.<br />
                                                2) Se debe especificar al destinatario del mensaje ente las selecciones disponibles.<br />
                                                3) En esta sección se debe escribir el mensaje que se desea enviar al destinatario previamente especificado.<br />
                                                4) Cuando se este satisfecho con el contenido se debe presionar para enviar el mensaje escrito<br />
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </section>
                        </asp:Panel>

                        <asp:Panel ID="panelReserva" runat="server" Visible="false">
                            <section class="showcase" style="height: 800px; overflow: scroll;">
                                <div class="container-fluid p-0">
                                    <div class="row no-gutters">
                                        <asp:Image ID="Image8" runat="server" CssClass="col-lg-6 order-lg-2 text-white showcase-img"
                                            ImageUrl="https://i.postimg.cc/rsX6mQcv/Reserva-de-Centro.png" />
                                        <div class="col-lg-6 order-lg-1 my-auto showcase-text">
                                            <h2>Reserva de Centros</h2>
                                            <br>
                                            <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                                                Si un usuario requiere realizar una reserva de un centro ubicado en su condominio requiere completar el siguiente formulario.<br />
                                                <br />
                                                1) Seleccione el departamento el cual será asociado a la reserva del centro.<br />
                                                2) Seleccione un centro disponible para la reserva.<br />
                                                3) Seleccione el día en el que quiera efectuar la reserva.<br />
                                                4) Seleccione el uno de los horarios disponibles para la realización de la reserva.<br />
                                                5)Presione luego de que este conforme con los datos ingresados para hacer efectiva la reserva.<br />
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </section>
                        </asp:Panel>

                        <asp:Panel ID="panelLuces" runat="server" Visible="false">
                            <section class="showcase" style="height: 800px; overflow: scroll;">
                                <div class="container-fluid p-0">
                                    <div class="row no-gutters">
                                        <asp:Image ID="Image3" runat="server" CssClass="col-lg-6 order-lg-2 text-white showcase-img"
                                            ImageUrl="https://i.postimg.cc/qMvg7yyR/Control-de-Luz-Departamento.png" />
                                        <div class="col-lg-6 order-lg-1 my-auto showcase-text">
                                            <h2>Programar Luces</h2>
                                            <br>
                                            <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                                                Este es el panel para el control de luces, en donde podrá ver el estado de las luces actuales y controlarlas libremente.<br />
                                                <br />
                                                1) Seleccione el departamento del cual requerirá controlar la luz.<br />
                                                2) Aquí se muestra el estado actual de la luz del departamento seleccionado.<br />
                                                3) Botones para el encendido y apagado.<br />
                                                4) Espacio para programar la luz para que se encienda o apague en un horario determinado.<br />
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </section>
                        </asp:Panel>

                        <asp:Panel ID="panelPassword" runat="server" Visible="false">
                            <section class="showcase" style="height: 800px; overflow: scroll;">
                                <div class="container-fluid p-0">
                                    <div class="row no-gutters">
                                        <asp:Image ID="Image4" runat="server" CssClass="col-lg-6 order-lg-2 text-white showcase-img"
                                            ImageUrl="https://i.postimg.cc/0j25b163/Cambio-de-Password.png" />
                                        <div class="col-lg-6 order-lg-1 my-auto showcase-text">
                                            <h2>Cambio de Password</h2>
                                            <br>
                                            <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                                                Esta ventana es para el cambio de password la cual deberá hacerse la primera vez que se inicie sesión con su cuenta
                                                obligatoriamente y posteriormente se recomienda cambiarla periódicamente con fines de seguridad.<br />
                                                <br />
                                                1) En este espacio escriba la password actual.<br />
                                                2) En este espacio escriba la password que desea establecer.<br />
                                                3) En este espacio vuelva a escribir la password que desea establecer asegurándose que conincidan con la escrita en el
                                                espacio anterior.<br />
                                                4) Presione para establecer su nueva password.<br />
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </section>
                        </asp:Panel>

                        <asp:Panel ID="panelPerfilProp" runat="server" Visible="false">
                            <section class="showcase" style="height: 800px; overflow: scroll;">
                                <div class="container-fluid p-0">
                                    <div>
                                        <div>
                                            <h2>Perfil de Propietarios</h2>
                                            <br>
                                            <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                                                En esta sección se muestra el perfil y los datos del propietario.<br />
                                                <br />
                                                1) Se muestra el Rut ingresado del propietario.<br />
                                                2) Se muestra el nombre del propietario.<br />
                                                3) Se muestra el apellido del propietario.<br />
                                                4) Se muestra el teléfono de contacto del propietario.<br />
                                                5) Se muestra el correo de contacto del propietario.<br />
                                                6) Se muestran los diferentes departamentos de los cuales es dueño el usuario.<br />
                                                7) Se especifican las luces asignadas al departamento seleccionado.<br />
                                                8) Se especifica el condominio al cual pertenece el departamento seleccionado.<br />
                                                9) Se especifica el edificio al cual pertenece el departamento seleccionado.<br />
                                                10) Se muestran los botones que redireccionan a la modificación de datos y al cambio de password respectivamente.<br />
                                                11) Las distintas opciones de navegación disponibles para el propietario<br />
                                            </p>
                                        </div>
                                    </div>
                                    <asp:Image ID="Image5" runat="server" CssClass="img-fluid" ImageUrl="https://i.postimg.cc/mDZWSNb1/Perfil-Propietario.png" />
                                </div>
                                <div class="container-fluid p-0">
                                    <div>
                                        <div>
                                            <h2>Gastos Comunes</h2>
                                            <br>
                                            <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                                                En esta sección se muestra las opciones que tiene el propietario con sesión iniciada con respecto a los gastos comunes<br />
                                                1) Selecciona el año que se requiere para ver los gastos comunes correspondientes.<br />
                                                2) Descarga la boleta del gasto común seleccionado.<br />
                                                3) Lista de los gastos comunes con relación al propietario.<br />
                                            </p>
                                        </div>
                                    </div>
                                    <asp:Image ID="Image35" runat="server" CssClass="img-fluid" ImageUrl="https://i.postimg.cc/jjMbXbWs/Perfil-Propietario-Gastos.png" />
                                    <div>
                                        <div>
                                            <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                                                En la siguiente imagen se muestran los detalles que se muestran en un detalle de la boleta.<br />
                                            </p>
                                        </div>
                                    </div>
                                    <asp:Image ID="Image36" runat="server" CssClass="img-fluid" ImageUrl="https://i.postimg.cc/YSr7Y9Cn/Perfil-Propietario-Gastos2.png" />
                                </div>
                                <div class="container-fluid p-0">
                                    <div>
                                        <div>
                                            <h2>Luces</h2>
                                            <br>
                                            <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                                                En este módulo se muestran las opciones correspondientes a las luces para el propietario con la sesión iniciada<br />
                                                1) Barra de búsqueda para aplicar filtro de la lista mostrada posteriormente.<br />
                                                2) Registrar control es una opción para aplicar un horario para establecer a una luz en especifica.<br />
                                                3) Opciones de encendido y apagado de una luz seleccionada.<br />
                                                4) Se establece una lista de departamentos para mostrar en específicos las luces instaladas en estos.<br />
                                                5) Listas de horarios registrados con opción para modificarlos.
                                            </p>
                                        </div>
                                    </div>
                                    <asp:Image ID="Image37" runat="server" CssClass="img-fluid" ImageUrl="https://i.postimg.cc/50vMMF7t/Perfil-Propietario-Luz.png" />
                                </div>
                                <div class="container-fluid p-0">
                                    <div>
                                        <div>
                                            <h2>Multas</h2>
                                            <br>
                                            <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                                                En esta sección se muestran las multas asociadas al propietario con la sesión iniciada.<br />
                                                1) Es una lista que ayuda para seleccionar el departamento y así mostrar las multas asociadas.<br />
                                                2) Lista de multas registradas.
                                            </p>
                                        </div>
                                    </div>
                                    <asp:Image ID="Image38" runat="server" CssClass="img-fluid" ImageUrl="https://i.postimg.cc/QNQr41K4/Perfil-Propietario-Multas.png" />
                                </div>
                                <div class="container-fluid p-0">
                                    <div>
                                        <div>
                                            <h2>Reserva</h2>
                                            <br>
                                            <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                                                En esta sección se muestran las opciones pertinentes a las reservas de centros para los propietarios de departamentos.<br />
                                                1) Barra de búsqueda para aplicar un filtro a la lista mostrada posteriormente.<br />
                                                2) Botón que redirecciona a el registro de una reserva de centro.<br />
                                                3) Aplica la selección para seleccionar un centro especifico.<br />
                                                4) Muestra las reservas activas correspondientes al usuario con la sesión iniciada.<br />
                                            </p>
                                        </div>
                                    </div>
                                    <asp:Image ID="Image39" runat="server" CssClass="img-fluid" ImageUrl="https://i.postimg.cc/65WFMSXq/Perfil-Propietario-Reserva.png" />
                                </div>
                            </section>
                        </asp:Panel>

                        <asp:Panel ID="panelRegistroPropietario" runat="server" Visible="false">
                            <section class="showcase" style="height: 800px; overflow: scroll;">
                                <div class="container-fluid p-0">
                                    <div class="row no-gutters">
                                        <asp:Image ID="Image6" runat="server" CssClass="col-lg-6 order-lg-2 text-white showcase-img"
                                            ImageUrl="https://i.postimg.cc/pX4zjs2r/Registro-Propietario-Parte-1.png" />
                                        <div class="col-lg-6 order-lg-1 my-auto showcase-text">
                                            <h2>Registro de Propietarios</h2>
                                            <br>
                                            <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                                                Cuando se realice la venta de un departamento se deberá realizar el registro del propietario llenando el siguiente
                                                formulario.<br />
                                                <br />
                                                1) Seleccione el condominio en donde fue adquirido el departamento.<br />
                                                2) Seleccione el edificio en donde fue adquirido el departamento.<br />
                                                3) Seleccione el departamento que fue adquirido por el propietario.<br />
                                                4) Presione para agregar el departamento al propietario, cabe destacar que si se adquiere más de un departamento se
                                                pueden registrar estos a su vez luego de completar el llenado de uno.<br />
                                                5) Se especifica el detalle de el/los departamento/s adquirido/s.<br />
                                                6) Especificar el Rut del propietario.<br />
                                                7) Especificar el nombre del propietario.<br />
                                                8) Especificar el apellido del propietario.<br />
                                            </p>
                                        </div>
                                    </div>
                                    <div class="row no-gutters">
                                        <asp:Image ID="Image7" runat="server" CssClass="col-lg-6 text-white showcase-img" ImageUrl="https://i.postimg.cc/J4GjtfCS/Registro-Propietario-Parte-2.png" />
                                        <div class="col-lg-6 my-auto showcase-text">
                                            <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                                                9) Especificar el telefono de contacto del propietario.<br />
                                                10) Especificar el correo de contacto del propietario.<br />
                                                11) Seleccione el genero del propietario.<br />
                                                12) Seleccione la opción se desea o no agregar la automatización de luces a sus departamentos.<br />
                                                13) Presionar para terminar y realizar el registro del propietario.<br />
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </section>
                        </asp:Panel>

                        <asp:Panel ID="panelPerfilVendedor" runat="server" Visible="false">
                            <section class="showcase" style="height: 800px; overflow: scroll;">
                                <div class="container-fluid p-0">
                                    <div>
                                        <div>
                                            <h2>Perfil Vendedor</h2>
                                            <br>
                                            <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                                                En esta seccion se muestra el perfil del vendedor junto con los datos y opciones de mismo.<br />
                                                <br />
                                                1) Se muestra el Rut del vendedor.<br />
                                                2) Se muestra el nombre del vendedor.<br />
                                                3) Se muestra el apellido del vendedor.<br />
                                                4) Se muestra el teléfono de contacto del vendedor.<br />
                                                5) Se muestra el correo de contacto del vendedor.<br />
                                                6) Botones para acceder a la modificación de datos y cambio de passowrd del vendedor respectivamente.<br />
                                                7) Opciones de navegación disponibles para el vendedor.
                                            </p>
                                        </div>
                                    </div>
                                    <asp:Image ID="Image9" runat="server" CssClass="img-fluid" ImageUrl="https://i.postimg.cc/QMQ1wMC1/Perfil-Vendedor.png" />
                                </div>
                                <div class="container-fluid p-0">
                                    <div>
                                        <div>
                                            <h2>Propietarios</h2>
                                            <br>
                                            <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                                                En este módulo el vendedor puede acceder a las opciones respectivas a los propietarios.<br />
                                                1) Barra de búsqueda para aplicar filtros.<br />
                                                2) Botón que redirecciona al formulario de registro de propietarios.<br />
                                                3) Selección de condominios para la Revisión de propietarios.<br />
                                                4) Lista de propietarios registrados.<br />
                                            </p>
                                        </div>
                                    </div>
                                    <asp:Image ID="Image54" runat="server" CssClass="img-fluid" ImageUrl="https://i.postimg.cc/JhnGLmBF/Perfil-Vendedor-Propietarios.png" />
                                    <div>
                                        <div>
                                            <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                                                En la siguiente imagen se muestra un ejemplo de los detalles de un propietario registrado seleccionado con anterioridad.
                                            </p>
                                        </div>
                                    </div>
                                    <asp:Image ID="Image55" runat="server" CssClass="img-fluid" ImageUrl="https://i.postimg.cc/zGpV633W/Perfil-Vendedor-Propietarios2.png" />
                                </div>
                            </section>
                        </asp:Panel>

                        <asp:Panel ID="panelRegistroEst" runat="server" Visible="false">
                            <section class="showcase" style="height: 800px; overflow: scroll;">
                                <div class="container-fluid p-0">
                                    <div class="row no-gutters">
                                        <asp:Image ID="Image10" runat="server" CssClass="col-lg-6 order-lg-2 text-white showcase-img"
                                            ImageUrl="https://i.postimg.cc/KvhkSbX5/Registro-Estacionamiento-Visita.png" />
                                        <div class="col-lg-6 order-lg-1 my-auto showcase-text">
                                            <h2>Registro Estacionamiento de Visitas</h2>
                                            <br>
                                            <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                                                Al ocupar un estacionamiento de visita los conserjes que estén encargado en ese momento deberá registrar los datos del vehículo
                                                tanto como la hora entrada y salida de este para lo cual se tiene el siguiente formulario que el conserje deberá completar.<br />
                                                <br />
                                                1) Seleccione el edificio especifico al que pertenece el estacionamiento que ser ocupado.<br />
                                                2) Seleccione el departamento al que se dirige el visitante.<br />
                                                3) Anote la patente del vehículo que ocupara el estacionamiento de visitas.<br />
                                                4) Registre la hora a la que se realizo el ingreso del vehículo visitante.<br />
                                                5) Se especifica el valor que tendrá el estacionamiento.<br />
                                                6) Presione para realizar el registro de la entrada de la visita.<br />
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </section>
                        </asp:Panel>

                        <asp:Panel ID="panelReservaCentro" runat="server" Visible="false">
                            <section class="showcase" style="height: 800px; overflow: scroll;">
                                <div class="container-fluid p-0">
                                    <div class="row no-gutters">
                                        <asp:Image ID="Image11" runat="server" CssClass="col-lg-6 order-lg-2 text-white showcase-img"
                                            ImageUrl="https://i.postimg.cc/DzpBfg1n/Registro-Reserva-Conserje.png" />
                                        <div class="col-lg-6 order-lg-1 my-auto showcase-text">
                                            <h2>Reserva de Centros</h2>
                                            <br>
                                            <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                                                Para realizar la reserva de un centro se deberá completar el siguiente formulario y de la siguiente forma.<br />
                                                <br />
                                                1) Seleccione el edificio al que pertenece la persona que realiza la reserva.<br />
                                                2) Seleccione el departamento al que pertenece la persona que realiza la reserva.<br />
                                                3) Se detalla las reservas que van a ser registradas con un resumen de sus datos.<br />
                                                4) Seleccione el centro que será reservado.<br />
                                                5) Seleccione el día de la reserva.<br />
                                                6) Seleccione el horario especifico en que será la reserva.<br />
                                                7) Presione para realizar la reserva cuando se este conforme con los datos ingresados.<br />
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </section>
                        </asp:Panel>

                        <asp:Panel ID="panelPagoGasto" runat="server" Visible="false">
                            <section class="showcase" style="height: 800px; overflow: scroll;">
                                <div class="container-fluid p-0">
                                    <div class="row no-gutters">
                                        <asp:Image ID="Image12" runat="server" CssClass="col-lg-6 order-lg-2 text-white showcase-img"
                                            ImageUrl="https://i.postimg.cc/pLDwdgdx/Registro-Gasto-Comun-Parte-1.png" />
                                        <div class="col-lg-6 order-lg-1 my-auto showcase-text">
                                            <h2>Pago de Gastos Comunes</h2>
                                            <br>
                                            <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                                                Para realizar el registro de un gasto común se deberá completar el siguiente formulario.<br />
                                                <br />
                                                1) Seleccione el condominio al que le será asignado el gasto común.<br />
                                                2) Seleccione el edificio en particular al que se le desea aplicar el gasto común o bien seleccione la opción para agregar
                                                gasto común a todos los edificios del condominio especificado.<br />
                                                3) Especifique el gasto del conserje del condominio especificado.<br />
                                                4) Especifique el gasto del guardia del condominio especificado.<br />
                                                5) Especifique el gasto de mantención de áreas del condominio seleccionado.<br />
                                                6) Especifique el gasto de cámaras del condominio especificado.<br />
                                                7) Especifique el gasto de artículos de aseo del seleccionado.<br />
                                                8) Especifique el gasto de aseo general del condominio seleccionado.<br />
                                            </p>
                                        </div>
                                    </div>
                                    <div class="row no-gutters">
                                        <asp:Image ID="Image13" runat="server" CssClass="col-lg-6 text-white showcase-img"
                                            ImageUrl="https://i.postimg.cc/0yRgP8Pc/Registro-Gasto-Comun-Parte-2.png" />
                                        <div class="col-lg-6 my-auto showcase-text">
                                            <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                                                9) Especifique el gasto de la mantención de los ascensores del condominio seleccionado.<br />
                                                10) Especifique el gasto de agua caliente del condominio seleccionado.<br />
                                                11) Especifique el gasto de otros apartados del condominio seleccionado si es que existen de estos.<br />
                                                12) Se muestra el valor total de los gastos comunes.<br />
                                                13) Presione para terminar el registro del gasto común.<br />
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </section>
                        </asp:Panel>

                        <asp:Panel ID="panelControlLuz" runat="server" Visible="false">
                            <section class="showcase" style="height: 800px; overflow: scroll;">
                                <div class="container-fluid p-0">
                                    <div class="row no-gutters">
                                        <asp:Image ID="Image14" runat="server" CssClass="col-lg-6 order-lg-2 text-white showcase-img"
                                            ImageUrl="https://i.postimg.cc/htfHLfMD/Control-de-Luz-Edificio.png" />
                                        <div class="col-lg-6 order-lg-1 my-auto showcase-text">
                                            <h2>Control de Luces</h2>
                                            <br>
                                            <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                                                Esta sección es para el control de las luces de un edificio en particular permitiendo programar y controlar el estado actual
                                                de las luces automáticas.<br />
                                                <br />
                                                1) En este espacio se debe seleccionar el condominio del que se quiere controlar la o las luces disponibles.<br />
                                                2) Seleccionar el edificio en particular en donde se encuentra la luz que se requiere controlar.<br />
                                                3) Seleccionar una luz para controlar específicamente.<br />
                                                4) En este espacio se muestra el estado actual de la luz seleccionada.<br />
                                                5) Con estas opciones se puede encender o apagar la luz seleccionada anteriormente.<br />
                                                6) Con estos botones se puede encender o apagar todas las luces del edificio seleccionado.<br />
                                                7) En este espacio es posible programar las luces del edificio seleccionado anteriormente.<br />
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </section>
                        </asp:Panel>

                        <asp:Panel ID="panelPerfilConserje" runat="server" Visible="false">
                            <section class="showcase" style="height: 800px; overflow: scroll;">
                                <div class="container-fluid p-0">
                                    <div>
                                        <div>
                                            <h2>Perfil Conserje</h2>
                                            <br>
                                            <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                                                Esta es la sección del perfil del conserje, donde se especifican los datos de este.<br />
                                                <br />
                                                1) Ese muestra el Rut del conserje.<br />
                                                2) Se muestra el nombre del conserje.<br />
                                                3) Se muestra el apellido del conserje.<br />
                                                4) Se especifica el teléfono de contacto del conserje.<br />
                                                5) Se muestra el correo de contacto del conserje.<br />
                                                6) Se especifica el condominio al cual esta asignado el conserje.<br />
                                                7) Botones para acceder a la modificación de datos y al cambio de password respectivamente.<br />
                                                8) Opciones de navegación disponibles para el conserje.<br />
                                            </p>
                                        </div>
                                    </div>
                                    <asp:Image ID="Image15" runat="server" CssClass="img-fluid" ImageUrl="https://i.postimg.cc/BnK9dVh0/Perfil-Conserje-Datos.png" />
                                </div>
                                <div class="container-fluid p-0">
                                    <div>
                                        <div>
                                            <h2>Gastos Comunes</h2>
                                            <br>
                                            <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                                                En este módulo el conserje puede acceder a las opciones relacionadas a los gastos comunes.<br />
                                                1) Barra de búsqueda para aplicar un filtro a la lista mostrada posteriormente.<br />
                                                2) Botón que redirecciona al registro de un pago.
                                                <br />
                                                3) Lista que muestra los gastos comunes emitidos en relación con el propietario correspondiente.<br />
                                            </p>
                                        </div>
                                    </div>
                                    <asp:Image ID="Image49" runat="server" CssClass="img-fluid" ImageUrl="https://i.postimg.cc/zvVPTy6r/Perfil-Conserje-Gastos.png" />
                                    <div>
                                        <div>
                                            <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                                                En esta sección se muestran los detalles de un gasto común seleccionado y la opción de descargar
                                                la boleta por parte del conserje.<br />
                                                1) Detalle de la boleta.<br />
                                                2) Botón para descargar la boleta.<br />
                                            </p>
                                        </div>
                                    </div>
                                    <asp:Image ID="Image53" runat="server" CssClass="img-fluid" ImageUrl="https://i.postimg.cc/cHDbKRDh/Perfil-Conserje-Gastos2.png" />
                                </div>
                                <div class="container-fluid p-0">
                                    <div>
                                        <div>
                                            <h2>Luces</h2>
                                            <br>
                                            <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                                                En este módulo se muestran las opciones que tiene disponible el usuario tipo conserje con respecto a las luces
                                                de un condominio al que este asignado.<br />
                                                1) Barra de búsqueda que aplica un filtro a la lista posteriormente mostrada.<br />
                                                2) Botones que redireccionan las opciones para encender, apagar, y crear un control de luz a una luz.<br />
                                                3) Lista que muestra los edificios disponibles para el conserje para filtrar lista de control de luces
                                                posteriormente mostrada.<br />
                                                4) Lista de controles de las luces.<br />
                                            </p>
                                        </div>
                                    </div>
                                    <asp:Image ID="Image50" runat="server" CssClass="img-fluid" ImageUrl="https://i.postimg.cc/sxkKSw5Y/Perfil-Conserje-Luz.png" />
                                </div>
                                <div class="container-fluid p-0">
                                    <div>
                                        <div>
                                            <h2>Estacionamiento</h2>
                                            <br>
                                            <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                                                En este módulo el conserje tiene la opción de registrar la entrada de salida en estacionamientos de visita
                                                todo dentro de su turno.
                                                <br />
                                                1) Barra de búsqueda para aplicar a la lista de los registros de usos de estacionamiento mostrada posteriormente.<br />
                                                2) Botón que redirecciona al formulario para el registro de un uso de estacionamiento.<br />
                                                3) Lista que muestra los detalles de los ingresos a los estacionamientos registrados.<br />
                                            </p>
                                        </div>
                                    </div>
                                    <asp:Image ID="Image51" runat="server" CssClass="img-fluid" ImageUrl="https://i.postimg.cc/7Pzxvbbc/Perfil-Conserje-Est.png" />
                                </div>
                                <div class="container-fluid p-0">
                                    <div>
                                        <div>
                                            <h2>Reservas</h2>
                                            <br>
                                            <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                                                En esta sección se muestras las opciones pertinentes al registro de reservas de centros por parte del conserje.
                                                1) Barra de búsqueda para aplicar un filtro a la lista posteriormente mostrada.
                                                2) Botón que redirecciona al formulario de registro de reserva.
                                                3) Opciones para seleccionar el filtro del centro para mostrar.
                                                4) Listas de las reservas de los centros registradas.
                                            </p>
                                        </div>
                                    </div>
                                    <asp:Image ID="Image52" runat="server" CssClass="img-fluid" ImageUrl="https://i.postimg.cc/C13QsNPS/Perfil-Conserje.png" />
                                </div>
                            </section>
                        </asp:Panel>

                        <asp:Panel ID="panelMulta" runat="server" Visible="false">
                            <section class="showcase" style="height: 800px; overflow: scroll;">
                                <div class="container-fluid p-0">
                                    <div class="row no-gutters">
                                        <asp:Image ID="Image16" runat="server" CssClass="col-lg-6 order-lg-2 text-white showcase-img"
                                            ImageUrl="https://i.postimg.cc/MKdghyXb/Asignar-Multa.png" />
                                        <div class="col-lg-6 order-lg-1 my-auto showcase-text">
                                            <h2>Asignar Multa a Departamento</h2>
                                            <br>
                                            <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                                                En determinadas situaciones se requerirá la asignación de una multa la cual se asignara directamente al departamento de
                                                la persona implicada, para esto se requiere el llenado de lo siguiente.<br />
                                                <br />
                                                1) Seleccionar el condominio al que pertenezca el objetivo de la multa.<br />
                                                2) Seleccione el edificio especifico al que pertenece el objetivo de la multa.<br />
                                                3) Seleccione al departamento específico al que se le asignara la multa.<br />
                                                4) Especifique el monto correspondiente a la multa que se asignara.<br />
                                                5) Presione para asignar definitivamente la multa especificada al objetivo especificado.<br />
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </section>
                        </asp:Panel>

                        <asp:Panel ID="panelPerfilAdmCondominio" runat="server" Visible="false">
                            <section class="showcase" style="height: 800px; overflow: scroll;">
                                <div class="container-fluid p-0">
                                    <div>
                                        <div>
                                            <h2>Perfil Administrador de Condominio</h2>
                                            <br>
                                            <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                                                Esta es la sección del perfil del administrador de condominio en donde se contiene los siguiente, además de dar la
                                                posibilidad de dar acceso a los formularios de modificar datos y cambio de password.<br />
                                                <br />
                                                1) Se especificara el Rut especifico del administrador de condominio.<br />
                                                2) Se detalla el nombre del administrador de condominio.<br />
                                                3) Se detalla el apellido del administrador de condominio.<br />
                                                4) Se muestra el teléfono de contacto del administrador de condominio.<br />
                                                5) Se muestra el correo de contacto del administrador de condominio.<br />
                                                6) Se especifica los condominios del administrador de condóminos.<br />
                                                7) Acceso para los formularios de modificar datos y cambiar la password del administrador de condominio.<br />
                                                8) Puntos de navegación para las distintas secciones a los que tiene acceso el administrador de condominios.<br />
                                            </p>
                                        </div>
                                    </div>
                                    <asp:Image ID="Image17" runat="server" CssClass="img-fluid" ImageUrl="https://i.postimg.cc/GpkSbwwk/Perfil-Adm-Condominio-Datos.png" />
                                </div>
                                <div class="container-fluid p-0">
                                    <div>
                                        <div>
                                            <h2>Condominios</h2>
                                            <br>
                                            <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                                                En este módulo se puede ver los condominios asignados a el administrador de condominios.<br />
                                                1) Barra de búsqueda apara aplicar filtro a los condominios mostrados en la lista mostrada posteriormente.<br />
                                                2) Lista que muestra la lista asignada al administrador de condominios especifico, además permitiendo acceder
                                                a más detalles haciendo click en la parte "Seleccionar".<br />
                                            </p>
                                        </div>
                                    </div>
                                    <asp:Image ID="Image56" runat="server" CssClass="img-fluid" ImageUrl="https://i.postimg.cc/tTqDyszj/Perfil-Adm-Condominio-Condominios.png" />
                                </div>
                                <div class="container-fluid p-0">
                                    <div>
                                        <div>
                                            <h2>Conserjes</h2>
                                            <br>
                                            <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                                                En este módulo se muestran las opciones correspondientes a la administración de conserjes accesibles
                                                para el administrador.<br />
                                                1) Barra de búsqueda para aplicar filtros a la lista de los conserjes mostrada posteriormente.<br />
                                                2) Botones para acceder al registro de conserjes y a la modificación de los datos de conserjes respectivamente.<br />
                                                3) Botón para acceder a la asignación de turno a un conserje previamente seleccionado.<br />
                                                4) Selecciona un condominio para mostrar los conserjes registrados a este en la lista mostrada posteriormente.<br />
                                                5) Lista que muestra el o los conserjes que coincidan con los filtros previamente aplicados.<br />
                                            </p>
                                        </div>
                                    </div>
                                    <asp:Image ID="Image57" runat="server" CssClass="img-fluid" ImageUrl="https://i.postimg.cc/9XSPg8sV/Perfil-Adm-Condominio-Conserje.png" />
                                </div>
                                <div class="container-fluid p-0">
                                    <div>
                                        <div>
                                            <h2>Propietarios</h2>
                                            <br>
                                            <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                                                En este módulo se muestran las opciones que a las cuales puede acceder el administrador de condominio.<br />
                                                1) Barra de búsqueda para aplicar filtros a la búsqueda de propietario de la lista mostrada posteriormente.<br />
                                                2) Botón para acceder al formulario de registro de propietario.<br />
                                                3) Botón para acceder al formulario para la modificación de los datos de un propietario seleccionado.<br />
                                                4) Botón para acceder al módulo para asignar una multa a un propietario en especifico.<br />
                                                5) Lista para seleccionar un condominio que mostrara sus respectivos propietarios en le lista posteriormente mostrada.<br />
                                                6) Lista que muestra los propietarios a cargo del administrador de condominios con la sesión iniciada dando la
                                                opción de acceder a los detalles de los datos del propietario.<br />
                                            </p>
                                        </div>
                                    </div>
                                    <asp:Image ID="Image58" runat="server" CssClass="img-fluid" ImageUrl="https://i.postimg.cc/nr84rM4r/Perfil-Adm-Condominio-Propietario.png" />
                                    <div>
                                        <div>
                                            <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                                                La imagen numero 2 muestra específicamente lo que se muestra al seleccionar un propietario
                                                dando a su vez la opción de asignar una luz al propietario seleccionado.<br />
                                            </p>
                                        </div>
                                    </div>
                                    <asp:Image ID="Image60" runat="server" CssClass="img-fluid" ImageUrl="https://i.postimg.cc/Tw5jTnWB/Perfil-Adm-Condominio-Propietario2.png" />
                                </div>
                                <div class="container-fluid p-0">
                                    <div>
                                        <div>
                                            <h2>Centros</h2>
                                            <br>
                                            <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                                                En este módulo se puede apreciar los centros que tiene disponible el administrador para su gestión.<br />
                                                Lo cual le permite ver los distintos centros de los condominios registrados, además de poder acceder a la
                                                modificación de los datos de estos centros.<br />
                                                1) Cuadro de búsqueda en donde puede ingresar un filtro para buscar un centro en especifico.<br />
                                                2) Lista de los condominios disponibles para desplegar los centros correspondientes al condominio seleccionado.<br />
                                                3) Lista de los centros registrado del condominio seleccionado previamente con sus respectivos detalles,
                                                además permitiendo acceder a la modificación de estos.<br />
                                                4) Números que muestran las páginas de la lista de la totalidad de los centros registrados.<br />
                                            </p>
                                        </div>
                                    </div>
                                    <asp:Image ID="Image59" runat="server" CssClass="img-fluid" ImageUrl="https://i.postimg.cc/15sFjkMk/Perfil-Adm-Condominio-Centros.png" />
                                </div>
                            </section>
                        </asp:Panel>

                        <asp:Panel ID="panelRegistroConserje" runat="server" Visible="false">
                            <section class="showcase" style="height: 800px; overflow: scroll;">
                                <div class="container-fluid p-0">
                                    <div class="row no-gutters">
                                        <asp:Image ID="Image18" runat="server" CssClass="col-lg-6 order-lg-2 text-white showcase-img"
                                            ImageUrl="https://i.postimg.cc/43ZtVhbq/Registro-Conserje-Parte-1.png" />
                                        <div class="col-lg-6 order-lg-1 my-auto showcase-text">
                                            <h2>Registro de Conserje</h2>
                                            <br>
                                            <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                                                Para el registro de conserjes se necesitara completar el siguiente formulario, de la siguiente forma.<br />
                                                <br />
                                                1) Seleccione el condominio especifico al cual será asignado el conserje que se va a registrar.<br />
                                                2) Especifique el rut del conserje a registrar.<br />
                                                3) Especifique el nombre del conserje a registrar.<br />
                                                4) Especifique el apellido del conserje a registrar.<br />
                                                5) Especifique el teléfono de contacto del conserje a registrar.<br />
                                                6) Especifique el e-mail de contacto del conserje a registrar.<br />
                                                7) Seleccione el genero del conserje a registrar.<br />
                                            </p>
                                        </div>
                                    </div>
                                    <div class="row no-gutters">
                                        <asp:Image ID="Image19" runat="server" CssClass="col-lg-6 text-white showcase-img"
                                            ImageUrl="https://i.postimg.cc/YCQYvxgQ/Registro-Conserje-Parte-2.png" />
                                        <div class="col-lg-6 my-auto showcase-text">
                                            <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                                                8) Seleccione el turno que se le quiere asignar al conserje a registrar.<br />
                                                9) Indique las fechas en donde iniciara y terminara respectivamente el turno del conserje.<br />
                                                10) Presione para registrar un turno que se haya especificado previamente, cabe mencionar que luego de agregado un turno
                                                se puede especificar otro y agregar este para realizar más de un registro de turno para el conserje.<br />
                                                11) Se especifica los detalles de los turnos del conserje con la posibilidad de eliminar según se estime conveniente.<br />
                                                12) Presione para realizar el registro del conserje.<br />
                                            </p>
                                        </div>
                                    </div>
                                    <div class="row no-gutters">
                                        <asp:Image ID="Image31" runat="server" CssClass="col-lg-6 order-lg-2 text-white showcase-img"
                                            ImageUrl="https://i.postimg.cc/QtjccWsV/Asignar-Turno-Conserje.png" />
                                        <div class="col-lg-6 order-lg-1 my-auto showcase-text">
                                            <h2>Asignar Turno Conserje</h2>
                                            <br>
                                            <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                                                Para la asignación de un turno a un conserje se deberá completar lo siguiente.<br />
                                                <br />
                                                1) Seleccione el condominio en el cual el conserje deberá completar el turno.<br />
                                                2) Seleccione el conserje al que se le asignara el turno.<br />
                                                3) Seleccione el turno al cual será asignado el conserje seleccionado.<br />
                                                4) Establezca la fecha de inicio del turno con formato dd-mm-aaaa.<br />
                                                5) Establezca la fecha de término del turno con formato dd-mm-aaaa.<br />
                                                6) Presione para agregar un horario al conserje seleccionado.<br />
                                                7) Presione para terminar el registro del turno correspondiente.<br />
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </section>
                        </asp:Panel>

                        <asp:Panel ID="panelRegistroLuz" runat="server" Visible="false">
                            <section class="showcase" style="height: 800px; overflow: scroll;">
                                <div class="container-fluid p-0">
                                    <div class="row no-gutters">
                                        <asp:Image ID="Image20" runat="server" CssClass="col-lg-6 order-lg-2 text-white showcase-img"
                                            ImageUrl="https://i.postimg.cc/3rnTTMcv/Registro-de-Luz.png" />
                                        <div class="col-lg-6 order-lg-1 my-auto showcase-text">
                                            <h2>Registro de Luz</h2>
                                            <br>
                                            <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                                                Para el registro de una luz en el sistema se debe realizar lo siguiente.<br />
                                                <br />
                                                1) Seleccione la opción especifica que se requiera para la luz a registrar.<br />
                                                2) Especifique el código de la luz a registrar.<br />
                                                3) Presione para terminar el registro de la luz.<br />
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </section>
                        </asp:Panel>

                        <asp:Panel ID="panelAsignarLuz" runat="server" Visible="false">
                            <section class="showcase" style="height: 800px; overflow: scroll;">
                                <div class="container-fluid p-0">
                                    <div class="row no-gutters">
                                        <asp:Image ID="Image21" runat="server" CssClass="col-lg-6 order-lg-2 text-white showcase-img"
                                            ImageUrl="https://i.postimg.cc/PxztrRNc/Asignar-Luz-a-Edificio.png" />
                                        <div class="col-lg-6 order-lg-1 my-auto showcase-text">
                                            <h2>Asignar Luz a Edificio</h2>
                                            <br>
                                            <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                                                Si requiere de asignar una luz a un edificio, asegúrese de rellenar cada uno de los campos.<br />
                                                <br />
                                                1) Selecciona la opción correspondiente a la luz y edificio que se requiera.<br />
                                                2) Seleccione el condominio al que será asignado la luz correspondiente.<br />
                                                3) Seleccione el edificio al que corresponderá la asignación de la luz, si es que este condominio seleccionado tenga mas
                                                de un edificio.<br />
                                                4) Dentro de las luces registradas selecciona la que corresponde al edificio y condominio al que quiere asignar.<br />
                                                5) Presione asignar luz para terminar el proceso de asignación de la luz correspondiente.<br />
                                            </p>
                                        </div>
                                    </div>
                                    <div class="row no-gutters">
                                        <asp:Image ID="Image22" runat="server" CssClass="col-lg-6 text-white showcase-img"
                                            ImageUrl="https://i.postimg.cc/B622KcRr/Asignar-Luz-Departamento.png" />
                                        <div class="col-lg-6 my-auto showcase-text">
                                            <h2>Asignar Luz a Departamento</h2>
                                            <br>
                                            <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                                                si se requiere asignar una luz específicamente a un departamento es necesario completar el siguiente formulario.<br />
                                                <br />
                                                1)seleccionar la opción especifica que se requiera para la asignación en particular.<br />
                                                2)seleccionar el condominio en donde se ubica el departamento al que se le asignara la luz.<br />
                                                3)seleccione el edificio en el que se encuentra el departamento al que se le asignara la luz.<br />
                                                4)seleccione el departamento en especifico al cual se le asignara la luz.<br />
                                                5) seleccione la luz correspondiente que se asignara al departamento seleccionado previamente.<br />
                                                6)presionando se termina la asignación completando todo correctamente.<br />
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </section>
                        </asp:Panel>

                        <asp:Panel ID="panelPerfilAdm" runat="server" Visible="false">
                            <section class="showcase" style="height: 800px; overflow: scroll;">
                                <div class="container-fluid p-0">
                                    <div>
                                        <div>
                                            <h2>Perfil Administrador</h2>
                                            <br>
                                            <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                                                En esta sección se muestra el perfil del administrador, el cual a su vez da el acceso a los formularios para la modificación
                                                de datos y cambio de password.<br />
                                                <br />
                                                1) Se muestra el Rut del administrador.<br />
                                                2) Se muestra el nombre del administrador.<br />
                                                3) Se muestra el apellido del administrador.<br />
                                                4) Se muestra el teléfono de contacto del administrador.<br />
                                                5) Se muestra el correo de contacto del administrador.<br />
                                                6) Son los botones que redireccionan para la modificación de datos específicos del perfil y al cambio de password respectivamente.<br />
                                                7) Puntos de navegación para las distintas opciones del administrador.<br />
                                            </p>
                                        </div>
                                    </div>
                                    <asp:Image ID="Image23" runat="server" CssClass="img-fluid" ImageUrl="https://i.postimg.cc/sDHG1NvB/Perfil-Administrador.png" />
                                </div>
                                <div class="container-fluid p-0">
                                    <div>
                                        <div>
                                            <h2>Condominios</h2>
                                            <br>
                                            <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                                                En esta sección se muestran los condominios asignados al administrador de condominios.<br />
                                                1) Barra de búsqueda para aplicar filtros a la lista mostrada más adelante.<br />
                                                2) Botón que redirecciona al formulario de registro de condominios.<br />
                                                3) Lista que muestra los condominios los cuales están asignados al usuario con la sesión iniciada.<br />
                                            </p>
                                        </div>
                                    </div>
                                    <asp:Image ID="Image40" runat="server" CssClass="img-fluid" ImageUrl="https://i.postimg.cc/rpxhVCk7/Perfil-Adm-Condominios.png" />
                                    <div>
                                        <div>
                                            <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                                                Esta sección muestra los edificios de un condominio seleccionado anteriormente para ver detalles.<br />
                                                1) Redirecciona al formulario para acceder una luz a un edificio del condominio seleccionado.<br />
                                                2) Redirecciona al formulario para modificar los parámetros de una luz asignada a un edificio.<br />
                                                3) Lista que muestra los edificios del condominio seleccionado anteriormente dando la opción de acceder a los detalles de
                                                cada edificio en particular.<br />
                                            </p>
                                        </div>
                                    </div>
                                    <asp:Image ID="Image42" runat="server" CssClass="img-fluid" ImageUrl="https://i.postimg.cc/K8KqVhsG/Perfil-Adm-Condominios2.png" />
                                    <div>
                                        <div>
                                            <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                                                En este módulo el administrador de condominios puede acceder a los detalles de un propietario de departamentos en especifico.<br />
                                                Según los accesos permitidos para este tipo de administrador.<br />
                                                1) Se muestran los departamentos que posee el propietario anteriormente seleccionado con la posibilidad de acceder a más
                                                detalles de un departamento en especifico.<br />
                                                2) Se muestra el detalle de los datos del propietario del departamento.<br />
                                                3) Se muestra las multas que posee el propietario seleccionado junto con una confirmación del estado de estas.<br />
                                            </p>
                                        </div>
                                    </div>
                                    <asp:Image ID="Image43" runat="server" CssClass="img-fluid" ImageUrl="https://i.postimg.cc/Jz96CY9b/Perfil-Adm-Condominios3.png" />
                                </div>
                                <div class="container-fluid p-0">
                                    <div>
                                        <div>
                                            <h2>Personal</h2>
                                            <br>
                                            <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                                                En este módulo se muestran las opciones respectivas al personal para el administrador.<br />
                                                1) Barra de búsqueda para aplicar filtros a la lista mostrada posteriormente.<br />
                                                2) Botones que redireccionan a los formularios de registro de personal, modificación de datos de personal y eliminación
                                                de personal respectivamente.<br />
                                                3) Lista de roles disponibles para seleccionar y aplicar como filtro a la lista mostrada posteriormente.<br />
                                                4) Botón que redirecciona a la asignación de un turno par aun conserje, siempre y cuando sea seleccionado uno anteriormente.<br />
                                                5) Lista que muestra el personal registrado, dando la opción de ver más detalles de estos.<br />
                                            </p>
                                        </div>
                                    </div>
                                    <asp:Image ID="Image41" runat="server" CssClass="img-fluid" ImageUrl="https://i.postimg.cc/VkBrzdhD/Perfil-Adm-Personal.png" />
                                    <div>
                                        <div>
                                            <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                                                En esta parte se muestra la información cuando se selecciona un personal en especifico.<br />
                                                1) Lista del personal.<br />
                                                2) Detalles del personal previamente seleccionado.<br />
                                            </p>
                                        </div>
                                    </div>
                                    <asp:Image ID="Image47" runat="server" CssClass="img-fluid" ImageUrl="https://i.postimg.cc/bwjSXQmZ/Perfil-Adm-Personal2.png" />
                                </div>
                                <div class="container-fluid p-0">
                                    <div>
                                        <div>
                                            <h2>Propietarios</h2>
                                            <br>
                                            <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                                                En este módulo se muestran las opciones a las cuales puede acceder el administrador con respecto a la gestión de los
                                                usuarios propietarios registrados.<br />
                                                1) Barra de búsqueda para aplicar filtro a la lista mostrada posteriormente.<br />
                                                2) Botones que redireccionan a los formularios de registro de propietario, modificación de datos de un propietario y
                                                eliminación de propietario respectivamente.<br />
                                                3) Es te botón permite asignar una multa a un propietario.<br />
                                                4) Lista que muestra los propietarios registrados con la opción de acceder a ver más detalles de estos.<br />
                                            </p>
                                        </div>
                                    </div>
                                    <asp:Image ID="Image44" runat="server" CssClass="img-fluid" ImageUrl="https://i.postimg.cc/90CQMjnZ/Perfil-Adm-Propietarios.png" />
                                    <div>
                                        <div>
                                            <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                                                En la imagen se muestra el detalle de un propietario seleccionado por el administrador.<br />
                                                1) Muestra los datos correspondientes al propietario seleccionado y sus distintos departamentos.<br />
                                                2) Botones que redireccionen al registro de una luz y a la codificación de los registros de una.<br />
                                            </p>
                                        </div>
                                    </div>
                                    <asp:Image ID="Image48" runat="server" CssClass="img-fluid" ImageUrl="https://i.postimg.cc/k4x5q5f7/Perfil-Adm-Propietarios2.png" />
                                </div>
                                <div class="container-fluid p-0">
                                    <div>
                                        <div>
                                            <h2>Gastos Comunes</h2>
                                            <br>
                                            <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                                                En este módulo el administrador con sesión iniciada puede ver los gastos comunes asignados a los edificios específicos
                                                con una breve muestra de la especificación.<br />
                                                1) Barra de búsqueda para aplicar a la lista de gastos comunes mostrada posteriormente.<br />
                                                2) Lista de condominios para aplicar como filtro a la lista mostrada posteriormente.<br />
                                                3) Lista de las torres con los respectivos gastos que se le asignan como gasto común con la opción de modificarlos.<br />
                                            </p>
                                        </div>
                                    </div>
                                    <asp:Image ID="Image45" runat="server" CssClass="img-fluid" ImageUrl="https://i.postimg.cc/gcH07nxD/Perfil-Adm-Gastos-Comunes.png" />
                                </div>
                                <div class="container-fluid p-0">
                                    <div>
                                        <div>
                                            <h2>Centros</h2>
                                            <br>
                                            <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                                                En este módulo se puede apreciar los centros que tiene disponible el administrador para su gestión.<br />
                                                Lo cual le permite ver los distintos centros de los condominios registrados, además de poder acceder a la modificación
                                                de los datos de estos centros.<br />
                                                1) Cuadro de búsqueda en donde puede ingresar un filtro para buscar un centro en especifico.<br />
                                                2) Lista de los condominios disponibles para desplegar los centros correspondientes al condominio seleccionado.<br />
                                                3) Lista de los centros registrado del condominio seleccionado previamente con sus respectivos detalles, además
                                                permitiendo acceder a la modificación de estos.<br />
                                                4) Números que muestran las páginas de la lista de la totalidad de los centros registrados.<br />
                                            </p>
                                        </div>
                                    </div>
                                    <asp:Image ID="Image46" runat="server" CssClass="img-fluid" ImageUrl="https://i.postimg.cc/RF9B1LLz/Perfil-Adm-Centros.png" />
                                </div>
                            </section>
                        </asp:Panel>

                        <asp:Panel ID="panelRegistroPersonal" runat="server" Visible="false">
                            <section class="showcase" style="height: 800px; overflow: scroll;">
                                <div class="container-fluid p-0">
                                    <div class="row no-gutters">
                                        <asp:Image ID="Image24" runat="server" CssClass="col-lg-6 order-lg-2 text-white showcase-img"
                                            ImageUrl="https://i.postimg.cc/PqyjrB59/Registro-Personal-Basico.png" />
                                        <div class="col-lg-6 order-lg-1 my-auto showcase-text">
                                            <h2>Registro Personal</h2>
                                            <br>
                                            <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                                                Para el registro del personal a un condominio se debe completar el siguiente formulario.<br />
                                                <br />
                                                1) Seleccione el rol que tomara el personal a registrar.<br />
                                                2) Especifique el Rut del personal a registrar.<br />
                                                3) Especifique el nombre del personal a registrar.<br />
                                                4) Especifique el apellido del personal a registrar.<br />
                                                5) Especifique el teléfono de contacto del personal a registrar.<br />
                                                6) Especifique el correo de contacto del personal a registrar.<br />
                                                7) Seleccione el genero del personal a registrar.<br />
                                                8) Luego de ingresado los datos correspondientes presione para realizar el registro de personal.<br />
                                            </p>
                                        </div>
                                    </div>

                                    <div class="row no-gutters">
                                        <asp:Image ID="Image26" runat="server" CssClass="col-lg-6 text-white showcase-img"
                                            ImageUrl="https://i.postimg.cc/L6PFZqsz/Registro-Personal-Administrador-Condominio.png" />
                                        <div class="col-lg-6 my-auto showcase-text">
                                            <h2>Registro Administrador de Condominio</h2>
                                            <br>
                                            <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                                                Para asignar un personal a un condominio en específico, este se debe registrar por medio del siguiente formulario y de la
                                                siguiente forma.<br />
                                                <br />
                                                1) Seleccione el rol que tomara el personal en el condominio.<br />
                                                2) Seleccione el condominio al que era asignado el personal a registrar.<br />
                                                3) Especifique el Rut del personal a registrar.<br />
                                                4) Especifique el nombre de personal a registrar.<br />
                                                5) Especifique le apellido del personal a registrar.<br />
                                                6) Especifique el teléfono de contacto del personal registrar.<br />
                                                7) Especifique el correo de contacto del personal a registrar.<br />
                                                8) Seleccione el género del personal a registrar.<br />
                                                9) Luego de que todos los datos sean registrados correctamente, presione para terminar el registro.<br />
                                            </p>
                                        </div>
                                    </div>
                                    <div class="row no-gutters">
                                        <asp:Image ID="Image25" runat="server" CssClass="col-lg-6 order-lg-2 text-white showcase-img"
                                            ImageUrl="https://i.postimg.cc/s2Vk8w4c/Registro-Personal-Conserje.png" />
                                        <div class="col-lg-6 order-lg-1 my-auto showcase-text">
                                            <h2>Registro Conserje</h2>
                                            <br>
                                            <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </section>
                        </asp:Panel>

                        <asp:Panel ID="panelRegistroCondominio" runat="server" Visible="false">
                            <section class="showcase" style="height: 800px; overflow: scroll;">
                                <div class="container-fluid p-0">
                                    <div class="row no-gutters">
                                        <asp:Image ID="Image27" runat="server" CssClass="col-lg-6 order-lg-2 text-white showcase-img"
                                            ImageUrl="https://i.postimg.cc/wjVq7tWw/Registro-Condominio-Parte-1.png" />
                                        <div class="col-lg-6 order-lg-1 my-auto showcase-text">
                                            <h2>Registro de Condominio</h2>
                                            <br>
                                            <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                                                Para el registro de condominio se tendrá el siguiente formulario que deberá ser llenado para realizar el registro
                                                correctamente.<br />
                                                <br />
                                                1) Seleccione la región disponible en donde está ubicado el condominio a registrar.<br />
                                                2) Seleccione la ciudad disponible en donde está ubicado el condominio a registrar.<br />
                                                3) Seleccione la comuna disponible en donde está ubicado el condominio a registrar.<br />
                                                4) Especifique la calle en donde está ubicado el condominio a registrar.<br />
                                                5) Indique el numero especifico donde está ubicado el condominio a registrar.<br />
                                                6) Seleccione un administrador de condominio que será registrado al condominio a registrar.<br />
                                                7) Especifique el nombre del condominio a registrar.<br />
                                                8) Indique el prefijo que se le será asignado al condominio.<br />
                                            </p>
                                        </div>
                                    </div>
                                    <div class="row no-gutters">
                                        <asp:Image ID="Image28" runat="server" CssClass="col-lg-6 text-white showcase-img"
                                            ImageUrl="https://i.postimg.cc/sgyfjPJB/Registro-Condominio-Parte-2.png" />
                                        <div class="col-lg-6 my-auto showcase-text">
                                            <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                                                9) Seleccione el tipo de numero o letra verificadora que le será asignado al condominio a registrar en correlación.<br />
                                                con el nombre como por ejemplo "Torre-A".<br />
                                                10) Indique la cantidad de edificios que contiene el condominio a registrar.<br />
                                                11) Especifique la cantidad de pisos por edificio.<br />
                                                12) Especifique la cantidad de departamentos por edificio.<br />
                                                13) Indique el precio que se le asignara a los estacionamientos de visita.<br />
                                                14) Presione para completar el registro del condominio.<br />
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </section>
                        </asp:Panel>

                        <asp:Panel ID="panelRegistroCentro" runat="server" Visible="false">
                            <section class="showcase" style="height: 800px; overflow: scroll;">
                                <div class="container-fluid p-0">
                                    <div class="row no-gutters">
                                        <asp:Image ID="Image29" runat="server" CssClass="col-lg-6 order-lg-2 text-white showcase-img"
                                            ImageUrl="https://i.postimg.cc/YCyPnMjp/Registro-Centro-Parte-1.png" />
                                        <div class="col-lg-6 order-lg-1 my-auto showcase-text">
                                            <h2>Registro de Centro</h2>
                                            <br>
                                            <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                                                En esta sección se puede ver el formulario para hacer registro de centros dentro de los condominios y/o edificios los
                                                cuáles pueden ser de distinta índole, desde lavandería, hasta gimnasio, para lo cual se necesita completar los siguiente.<br />
                                                1) Seleccionar el condómino especifico al cual se le asociara el centro en particular.<br />
                                                2) Seleccionar el edificio en donde se ubicara específicamente el centro.<br />
                                                3) Seleccionar el tipo de centro que será registrado dentro del sistema.<br />
                                                4) Aplique un nombre al centro seleccionado, se recomienda que tenga relación con el tipo de centro y su ubicación.<br />
                                                5) Especificar el precio que se cobrara por la utilización del centro que se quiere registrar.<br />
                                                6) Se especifica el día que el centro realizara sus funciones además de especificar la hora de inicio y termino de estas.<br />
                                            </p>
                                        </div>
                                    </div>
                                    <div class="row no-gutters">
                                        <asp:Image ID="Image30" runat="server" CssClass="col-lg-6 text-white showcase-img"
                                            ImageUrl="https://i.postimg.cc/k56pLztW/Registro-Centro-Parte-2.png" />
                                        <div class="col-lg-6 my-auto showcase-text">
                                            <p class="lead mb-0" style="text-align: justify; color: black; width: 90%">
                                                7) Presione para agregar el horario especificado.<br />
                                                8) Se detallan los horarios especificados anteriormente con la posibilidad de eliminar un día de funciones según se requiera.<br />
                                                9) Presione para finalizar con la creación del centro.<br />
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </section>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>