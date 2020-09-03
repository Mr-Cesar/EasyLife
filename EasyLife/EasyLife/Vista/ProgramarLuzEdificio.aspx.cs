using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EasyLife.Vista
{
    public partial class ProgramarLuzEdificio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validación de Session Iniciada
            LOGIN adm = (LOGIN)Session["adm"];
            LOGIN conserje = (LOGIN)Session["conserje"];
            LOGIN vendedor = (LOGIN)Session["vendedor"];
            LOGIN propietario = (LOGIN)Session["login"];
            LOGIN admCondominio = (LOGIN)Session["admCondominio"];
            if (vendedor != null || propietario != null)
            {
                Response.Redirect("Index.aspx");
            }
            else if (adm == null && conserje == null && vendedor == null && propietario == null && admCondominio == null)
            {
                Response.Redirect("Index.aspx");
            }

            //Recuperar Session de Modificar Control
            string modificar = (string)Session["ModificarControlIluminacionEdifciio"];

            if (!IsPostBack)
            {
                if (adm != null)
                {
                    cargarCondominio();
                }
                else if (admCondominio != null)
                {
                    cargarCondominioAdministrador(admCondominio.ID_PERSONA);
                }
                else
                {
                    cargarEdificioConserje(conserje.ID_PERSONA);
                }

                if (modificar != null)
                {
                    cargarControl(modificar);
                }
            }
        }

        private static CONTROL_ILUMINACION_EDIFICIO controlEdificio = new CONTROL_ILUMINACION_EDIFICIO();

        public void cargarCondominio()
        {
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
            CONSERJE conserje = Controller.ControllerConserje.buscarIdConserje(persona);
            List<EDIFICIO> listaEdificio = Controller.ControllerEdificio.buscarEdificioCondominio(Convert.ToInt64(conserje.ID_CONDOMINIO));
            dplEdificio.DataSource = listaEdificio;
            dplEdificio.DataValueField = "ID_EDIFICIO";
            dplEdificio.DataTextField = "NOMBRE_EDIFICIO";
            dplEdificio.DataBind();
            dplEdificio.Items.Insert(0, "Seleccione un Edificio");
            dplEdificio.SelectedIndex = 0;
        }

        public void cargarControl(string control)
        {
            lbOpcion.Text = "Modifiar Control de Luces";
            panelCondominio.Visible = false;
            panelModificar.Visible = false;
            controlEdificio = new CONTROL_ILUMINACION_EDIFICIO();
            controlEdificio = Controller.ControllerControlIluminacionEdificio.buscarIdControl(Convert.ToInt64(control));
            string año = controlEdificio.HORA_INICIO_E.Substring(6, 4);
            string mes = controlEdificio.HORA_INICIO_E.Substring(3, 2);
            string dia = controlEdificio.HORA_INICIO_E.Substring(0, 2);
            txtDia.Text = año + "-" + mes + "-" + dia;

            string horaI = controlEdificio.HORA_INICIO_E.Substring(11, 5);
            txtHoraInicio.Text = horaI;

            string horaT = controlEdificio.HORA_TERMINO_E.Substring(11, 5);
            txtHoraTermino.Text = horaT;

            if (controlEdificio.ESTADO_LUZ_CE == true)
            {
                rbOpcion.SelectedIndex = 0;
            }
            else
            {
                rbOpcion.SelectedIndex = 1;
            }
            btnProgramarLuz.Visible = false;
            btnModificarPrograma.Visible = true;
        }

        protected void dplCondominio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                long condominio = Convert.ToInt64(dplCondominio.SelectedValue);
                List<EDIFICIO> listaEdificio = Controller.ControllerEdificio.buscarEdificioCondominio(condominio);
                dplEdificio.DataSource = listaEdificio;
                dplEdificio.DataValueField = "ID_EDIFICIO";
                dplEdificio.DataTextField = "NOMBRE_EDIFICIO";
                dplEdificio.DataBind();
                dplEdificio.Items.Insert(0, "Seleccione un Edificio");
                dplEdificio.SelectedIndex = 0;
                dplLuz.Items.Insert(0, "Seleccione una Luz");
                dplLuz.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                dplEdificio.Items.Insert(0, "Seleccione un Edificio");
                dplEdificio.SelectedIndex = 0;
                dplLuz.Items.Insert(0, "Seleccione una Luz");
                dplLuz.SelectedIndex = 0;
                System.Diagnostics.Debug.WriteLine("Error:  " + ex);
            }
        }

        protected void dplEdificio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                long edificio = Convert.ToInt64(dplEdificio.SelectedValue);
                List<LUZ_EDIFICIO> lista = Controller.ControllerLuzEdificio.buscarLuzEdificio(edificio);
                dplLuz.DataSource = lista;
                dplLuz.DataBind();
                dplLuz.DataValueField = "ID_LUZ_E";
                dplLuz.DataTextField = "CODIGO_LUZ_E";
                dplLuz.DataBind();
                dplLuz.Items.Insert(0, "Seleccione una Luz");
                dplLuz.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                dplLuz.Items.Insert(0, "Seleccione una Luz");
                dplLuz.SelectedIndex = 0;
                System.Diagnostics.Debug.WriteLine("Error:  " + ex);
            }
        }

        protected void dplLuz_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                long luz = Convert.ToInt64(dplLuz.SelectedValue);
                LUZ_EDIFICIO luzE = Controller.ControllerLuzEdificio.buscarIdLuzEdificio(luz);
                if (luzE.ESTADO_LUZ_E == true)
                {
                    lbEstado.Text = "Encendida";
                }
                else
                {
                    lbEstado.Text = "Apagada";
                }
            }
            catch (Exception ex)
            {
                lbEstado.Text = "";
                System.Diagnostics.Debug.WriteLine("Error:  " + ex);
            }
        }

        protected void btnEncenderLuz_Click(object sender, EventArgs e)
        {
        }

        protected void btnApagarLuz_Click(object sender, EventArgs e)
        {
        }

        protected void btnEncenderTodo_Click(object sender, EventArgs e)
        {
        }

        protected void btnApagarTodo_Click(object sender, EventArgs e)
        {
        }

        protected void btnProgramarLuz_Click(object sender, EventArgs e)
        {
        }

        protected void btnModificarPrograma_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            DateTime dia = Convert.ToDateTime(txtDia.Text);
            string horaI = txtHoraInicio.Text;
            string horaT = txtHoraTermino.Text;
            int operacion = rbOpcion.SelectedIndex;
            Boolean opcion = new Boolean();
            if (operacion == 0)
            {
                opcion = true;
            }
            else
            {
                opcion = false;
            }
            string horaInicio = dia.ToString("dd/MM/yyy") + " " + horaI;
            string horaTermino = dia.ToString("dd/MM/yyy") + " " + horaT;
            string result = Controller.ControllerControlIluminacionEdificio.modificarControlEdificio(controlEdificio.ID_CILUMINACION_E, controlEdificio.ID_LUZ_E,
                horaInicio, horaTermino, opcion);
            if (result.Equals("Control Modificado"))
            {
                Session["ModificarControlIluminacionEdifciio"] = null;
                panelCondominio.Visible = true;
                panelModificar.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Control Modificado');window.location.href='" + Request.RawUrl + "';", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Error al Modificado Control');window.location.href='" + Request.RawUrl + "';", true);
            }
        }
    }
}