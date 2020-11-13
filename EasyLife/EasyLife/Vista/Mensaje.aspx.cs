using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;

namespace EasyLife.Vista
{
    public partial class Mensaje : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validación de Session Iniciada
            /*LOGIN adm = (LOGIN)Session["adm"];
            LOGIN conserje = (LOGIN)Session["conserje"];
            LOGIN vendedor = (LOGIN)Session["vendedor"];
            LOGIN propietario = (LOGIN)Session["login"];
            LOGIN admCondominio = (LOGIN)Session["admCondominio"];
            if (vendedor != null || propietario != null)
            {
                Response.Redirect("~/Vista/Index.aspx");
            }
            else if (adm == null && conserje == null && vendedor == null && propietario == null && admCondominio == null)
            {
                Response.Redirect("~/Vista/Index.aspx");
            }

            if (!IsPostBack)
            {
                if (adm != null)
                {
                    cargarCondominio();
                    emisor = adm.ID_PERSONA;
                }
                else if (admCondominio != null)
                {
                    cargarCondominioAdministrador(admCondominio.ID_PERSONA);
                    emisor = admCondominio.ID_PERSONA;
                }
                else
                {
                    cargarEdificioConserje(conserje.ID_PERSONA);
                    emisor = conserje.ID_PERSONA;
                }
                cargarMotivo();
            }*/

            if (!IsPostBack)
            {
                cargarCondominio();
                cargarMotivo();
                emisor = 1;
            }
        }

        private static string correo = "";
        private static string asunto = "";
        private static long emisor = 0;
        private static Boolean operation = false;
        private static List<EDIFICIO> listaEdificio = new List<EDIFICIO>();
        private static List<PERSONA> listapersonal = new List<PERSONA>();
        private static List<DEPARTAMENTO> listaDepartamento = new List<DEPARTAMENTO>();

        public void cargarMotivo()
        {
            List<TIPO_MENSAJE> lista = Controller.ControllerTipoMensaje.listaTipoMensaje();
            dplMotivo.DataSource = lista;
            dplMotivo.DataValueField = "ID_TIPO_MENSAJE";
            dplMotivo.DataTextField = "DESCRIPCION_TP";
            dplMotivo.DataBind();
            dplMotivo.Items.Insert(0, "Seleccione un Motivo");
            dplMotivo.SelectedIndex = 0;
        }

        public void cargarCondominio()
        {
            panelCondominio.Visible = true;
            List<CONDOMINIO> lista = Controller.ControllerCondominio.listaCondominio();
            dplCondominio.DataSource = lista;
            dplCondominio.DataValueField = "ID_CONDOMINIO";
            dplCondominio.DataTextField = "NOMBRE_CONDOMINIO";
            dplCondominio.DataBind();
            dplCondominio.Items.Insert(0, "Seleccione un Condominio");
            dplCondominio.SelectedIndex = 0;
        }

        public void cargarCondominioAdministrador(long administrador)
        {
            panelCondominio.Visible = true;
            List<CONDOMINIO> lista = Controller.ControllerCondominio.listaCondominioAdministrador(administrador);
            dplCondominio.DataSource = lista;
            dplCondominio.DataValueField = "ID_CONDOMINIO";
            dplCondominio.DataTextField = "NOMBRE_CONDOMINIO";
            dplCondominio.DataBind();
            dplCondominio.Items.Insert(0, "Seleccione un Condominio");
            dplCondominio.SelectedIndex = 0;
        }

        public void cargarEdificioConserje(long persona)
        {
            panelCondominio.Visible = false;
            CONSERJE conserje = Controller.ControllerConserje.buscarIdConserje(persona);
            listaEdificio = Controller.ControllerEdificio.buscarEdificioCondominio(Convert.ToInt64(conserje.ID_CONDOMINIO));
            dplEdificio.DataSource = listaEdificio;
            dplEdificio.DataValueField = "ID_EDIFICIO";
            dplEdificio.DataTextField = "NOMBRE_EDIFICIO";
            dplEdificio.DataBind();
            dplEdificio.Items.Insert(0, "Seleccione un Edificio");
            dplEdificio.Items.Insert(1, "Enviar a Todos los Edificios");
            dplEdificio.SelectedIndex = 0;
        }

        public void cargarAdministrador(long condominio)
        {
            listapersonal = Controller.ControllerPersona.admCondominio(condominio);
            dplPersonal.DataSource = listapersonal;
            dplPersonal.DataValueField = "ID_PERSONA";
            dplPersonal.DataTextField = "FK_RUT";
            dplPersonal.DataBind();
            dplPersonal.Items.Insert(0, "Seleccione un Personal");
            dplPersonal.Items.Insert(1, "Enviar a Todos los Administradores de Condominio");
            dplPersonal.SelectedIndex = 0;
        }

        public void cargarConserje(long condominio)
        {
            listapersonal = Controller.ControllerPersona.conserjeCondominio(condominio);
            dplPersonal.DataSource = listapersonal;
            dplPersonal.DataValueField = "ID_PERSONA";
            dplPersonal.DataTextField = "FK_RUT";
            dplPersonal.DataBind();
            dplPersonal.Items.Insert(0, "Seleccione un Personal");
            dplPersonal.Items.Insert(1, "Enviar a Todos los Conserjes");
            dplPersonal.SelectedIndex = 0;
        }

        protected void dplMotivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                long motivo = Convert.ToInt64(dplMotivo.SelectedValue);
                TIPO_MENSAJE tipo = Controller.ControllerTipoMensaje.buscarIdTipoMensaje(motivo);
                asunto = tipo.DESCRIPCION_TP;
                if (motivo == 3)
                {
                    panelEdificio.Visible = false;
                    panelDepartamento.Visible = false;
                    panelPersonal.Visible = true;
                }
                else if (motivo == 5)
                {
                    panelEdificio.Visible = false;
                    panelDepartamento.Visible = false;
                    panelPersonal.Visible = true;
                }
                else
                {
                    panelEdificio.Visible = true;
                    panelDepartamento.Visible = true;
                    panelPersonal.Visible = false;
                }
            }
            catch (Exception ex)
            {
                dplCondominio.Items.Insert(0, "Seleccione un Condominio");
                dplCondominio.SelectedIndex = 0;
                dplEdificio.Items.Insert(0, "Seleccione un Edificio");
                dplEdificio.SelectedIndex = 0;
                dplDepartamento.Items.Insert(0, "Seleccione un Departamento");
                dplDepartamento.SelectedIndex = 0;
                System.Diagnostics.Debug.WriteLine("Error: " + ex);
            }
        }

        protected void dplCondominio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                long condominio = Convert.ToInt64(dplCondominio.SelectedValue);
                long motivo = Convert.ToInt64(dplMotivo.SelectedValue);
                if (motivo == 3)
                {
                    cargarAdministrador(condominio);
                }
                else if (motivo == 5)
                {
                    cargarConserje(condominio);
                }
                else
                {
                    listaEdificio = Controller.ControllerEdificio.buscarEdificioCondominio(condominio);
                    dplEdificio.DataSource = listaEdificio;
                    dplEdificio.DataValueField = "ID_EDIFICIO";
                    dplEdificio.DataTextField = "NOMBRE_EDIFICIO";
                    dplEdificio.DataBind();
                    dplEdificio.Items.Insert(0, "Seleccione un Edificio");
                    dplEdificio.Items.Insert(1, "Enviar a Todos los Edificios");
                    dplEdificio.SelectedIndex = 0;
                    dplDepartamento.Items.Insert(0, "Seleccione un Departamento");
                    dplDepartamento.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                dplEdificio.Items.Insert(0, "Seleccione un Edificio");
                dplEdificio.SelectedIndex = 0;
                dplDepartamento.Items.Insert(0, "Seleccione un Departamento");
                dplDepartamento.SelectedIndex = 0;
                System.Diagnostics.Debug.WriteLine("Error: " + ex);
            }
        }

        protected void dplEdificio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (dplEdificio.SelectedIndex == 1)
                {
                    operation = true;
                    panelDepartamento.Visible = false;
                    panelPersonal.Visible = false;
                }
                else
                {
                    long edificio = Convert.ToInt64(dplEdificio.SelectedValue);
                    listaDepartamento = Controller.ControllerDepartamento.listaDepartamentoOcupado(edificio);
                    dplDepartamento.DataSource = listaDepartamento;
                    dplDepartamento.DataValueField = "ID_DEPARTAMENTO";
                    dplDepartamento.DataTextField = "NUMERO_DEP";
                    dplDepartamento.DataBind();
                    dplDepartamento.Items.Insert(0, "Seleccione un Departamento");
                    dplDepartamento.Items.Insert(1, "Enviar a Todos los Edificios");
                    dplDepartamento.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                dplDepartamento.Items.Insert(0, "Seleccione un Departamento");
                dplDepartamento.SelectedIndex = 0;
                System.Diagnostics.Debug.WriteLine("Error: " + ex);
            }
        }

        protected void dplDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (dplDepartamento.SelectedIndex == 1)
                {
                    operation = true;
                    panelPersonal.Visible = false;
                }
                else
                {
                    operation = false;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error: " + ex);
            }
        }

        protected void dplPersonal_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (dplPersonal.SelectedIndex == 1)
                {
                    operation = true;
                }
                else
                {
                    long persona = Convert.ToInt64(dplPersonal.SelectedValue);
                    PERSONA aux = Controller.ControllerPersona.buscarIdPersona(persona);
                    correo = aux.CORREO_PERSONA;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error: " + ex);
            }
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Reserva Cancelada');window.location.href='" + Request.RawUrl + "';", true);
            try
            {
                System.Threading.Thread.Sleep(5000);
                string result = "";
                string message = txtArea.Text;
                message += "";
                MailMessage msg = new MailMessage();
                SmtpClient sc = new SmtpClient("smtp.gmail.com");
                PERSONA persona = Controller.ControllerPersona.buscarIdPersona(emisor);

                if (operation == true)
                {
                    if (dplEdificio.SelectedIndex == 1)
                    {
                        foreach (EDIFICIO item in listaEdificio)
                        {
                            List<DEPARTAMENTO> lista = Controller.ControllerDepartamento.listaDepartamento(item.ID_EDIFICIO);
                            foreach (DEPARTAMENTO dep in lista)
                            {
                                PERSONA aux = Controller.ControllerPersona.buscarIdPersona(Convert.ToInt64(dep.ID_PERSONA));
                                msg.From = new MailAddress("easylifeapartaments@gmail.com");
                                msg.To.Add(correo);
                                msg.Subject = asunto;
                                msg.Body = message;
                                msg.BodyEncoding = System.Text.Encoding.UTF8;
                                /*Para realizar envio de mensaje con copia*/
                                /*MailAddress ms = new MailAddress("easylifeapartaments@gmail.com");
                                msg.CC.Add(ms);*/
                                sc.Port = 25;
                                sc.Credentials = new NetworkCredential("easylifeapartaments@gmail.com", "easylife2020");
                                sc.EnableSsl = true;
                                sc.Send(msg);
                                result = Controller.ControllerMensaje.crearMensaje(Convert.ToInt64(dplMotivo.SelectedValue), emisor, txtArea.Text,
                                    persona.FK_RUT, aux.FK_RUT, true);
                            }
                        }
                    }
                    else if (dplDepartamento.SelectedIndex == 1)
                    {
                        foreach (DEPARTAMENTO item in listaDepartamento)
                        {
                            PERSONA aux = Controller.ControllerPersona.buscarIdPersona(Convert.ToInt64(item.ID_PERSONA));
                            msg.From = new MailAddress("easylifeapartaments@gmail.com");
                            msg.To.Add(correo);
                            msg.Subject = asunto;
                            msg.Body = message;
                            msg.BodyEncoding = System.Text.Encoding.UTF8;
                            /*Para realizar envio de mensaje con copia*/
                            /*MailAddress ms = new MailAddress("easylifeapartaments@gmail.com");
                            msg.CC.Add(ms);*/
                            sc.Port = 25;
                            sc.Credentials = new NetworkCredential("easylifeapartaments@gmail.com", "easylife2020");
                            sc.EnableSsl = true;
                            sc.Send(msg);
                            result = Controller.ControllerMensaje.crearMensaje(Convert.ToInt64(dplMotivo.SelectedValue), emisor, txtArea.Text,
                                persona.FK_RUT, aux.FK_RUT, true);
                        }
                    }
                    else if (dplPersonal.SelectedIndex == 1)
                    {
                        foreach (PERSONA item in listapersonal)
                        {
                            msg.From = new MailAddress("easylifeapartaments@gmail.com");
                            msg.To.Add(correo);
                            msg.Subject = asunto;
                            msg.Body = message;
                            msg.BodyEncoding = System.Text.Encoding.UTF8;
                            /*Para realizar envio de mensaje con copia*/
                            /*MailAddress ms = new MailAddress("easylifeapartaments@gmail.com");
                            msg.CC.Add(ms);*/
                            sc.Port = 25;
                            sc.Credentials = new NetworkCredential("easylifeapartaments@gmail.com", "easylife2020");
                            sc.EnableSsl = true;
                            sc.Send(msg);
                            result = Controller.ControllerMensaje.crearMensaje(Convert.ToInt64(dplMotivo.SelectedValue), emisor, txtArea.Text,
                                persona.FK_RUT, item.FK_RUT, true);
                        }
                    }
                }
                else
                {
                    if (Convert.ToInt64(dplMotivo.SelectedValue) == 3 || Convert.ToInt64(dplMotivo.SelectedValue) == 5)
                    {
                        PERSONA destinatario = Controller.ControllerPersona.buscarIdPersona(Convert.ToInt64(dplPersonal.SelectedValue));
                        msg.From = new MailAddress("easylifeapartaments@gmail.com");
                        msg.To.Add(correo);
                        msg.Subject = asunto;
                        msg.Body = message;
                        msg.BodyEncoding = System.Text.Encoding.UTF8;
                        /*Para realizar envio de mensaje con copia*/
                        /*MailAddress ms = new MailAddress("easylifeapartaments@gmail.com");
                        msg.CC.Add(ms);*/
                        sc.Port = 25;
                        sc.Credentials = new NetworkCredential("easylifeapartaments@gmail.com", "easylife2020");
                        sc.EnableSsl = true;
                        sc.Send(msg);
                        result = Controller.ControllerMensaje.crearMensaje(Convert.ToInt64(dplMotivo.SelectedValue), emisor, txtArea.Text,
                            persona.FK_RUT, destinatario.FK_RUT, true);
                    }
                    else
                    {
                        DEPARTAMENTO dep = Controller.ControllerDepartamento.buscarIdDepartamento(Convert.ToInt64(dplDepartamento.SelectedValue));
                        PERSONA destinatario = Controller.ControllerPersona.buscarIdPersona(Convert.ToInt64(dep.ID_PERSONA));
                        msg.From = new MailAddress("easylifeapartaments@gmail.com");
                        msg.To.Add(correo);
                        msg.Subject = asunto;
                        msg.Body = message;
                        msg.BodyEncoding = System.Text.Encoding.UTF8;
                        /*Para realizar envio de mensaje con copia*/
                        /*MailAddress ms = new MailAddress("easylifeapartaments@gmail.com");
                        msg.CC.Add(ms);*/
                        sc.Port = 25;
                        sc.Credentials = new NetworkCredential("easylifeapartaments@gmail.com", "easylife2020");
                        sc.EnableSsl = true;
                        sc.Send(msg);
                        result = Controller.ControllerMensaje.crearMensaje(Convert.ToInt64(dplMotivo.SelectedValue), emisor, txtArea.Text,
                            persona.FK_RUT, destinatario.FK_RUT, true);
                    }
                }

                if (result.Equals("Mensaje Creado"))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Mensaje Enviado');window.location.href='" + Request.RawUrl + "';", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Error al Enviar Mensaje');window.location.href='" + Request.RawUrl + "';", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Error al Enviar Mensaje');window.location.href='" + Request.RawUrl + "';", true);
                System.Diagnostics.Debug.WriteLine("Error, Contactenos " + ex);
                throw;
            }
        }
    }
}