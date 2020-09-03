using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EasyLife.Vista
{
    public partial class AsignarTurnoConserje : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validación de Session Iniciada
            LOGIN adm = (LOGIN)Session["adm"];
            LOGIN conserje = (LOGIN)Session["conserje"];
            LOGIN vendedor = (LOGIN)Session["vendedor"];
            LOGIN propietario = (LOGIN)Session["login"];
            LOGIN admCondominio = (LOGIN)Session["admCondominio"];
            if (conserje != null || vendedor != null || propietario != null)
            {
                Response.Redirect("Index.aspx");
            }
            else if (adm == null && conserje == null && vendedor == null && propietario == null && admCondominio == null)
            {
                Response.Redirect("Index.aspx");
            }

            if (!IsPostBack)
            {
                if (adm != null)
                {
                    cargarCondominio();
                }
                else
                {
                    cargarCondominioAdm(admCondominio.ID_PERSONA);
                }
            }
        }

        private static List<TURNO> listaTurnoActual = new List<TURNO>();
        private static List<TURNO> listaTurnoAsignar = new List<TURNO>();
        private static List<PERSONA> listaConserje = new List<PERSONA>();
        private static TURNO turno = new TURNO();

        public void cargarCondominio()
        {
            List<CONDOMINIO> listaCondominio = new List<CONDOMINIO>();
            listaCondominio = Controller.ControllerCondominio.listaCondominio();
            dplCondominio.DataSource = listaCondominio;
            dplCondominio.DataValueField = "ID_CONDOMINIO";
            dplCondominio.DataTextField = "NOMBRE_CONDOMINIO";
            dplCondominio.DataBind();
            dplCondominio.Items.Insert(0, "Seleccione un Condominio");
            dplCondominio.SelectedIndex = 0;
        }

        public void cargarCondominioAdm(long administrador)
        {
            List<CONDOMINIO> listaCondominio = new List<CONDOMINIO>();
            listaCondominio = Controller.ControllerCondominio.listaCondominioAdministrador(administrador);
            dplCondominio.DataSource = listaCondominio;
            dplCondominio.DataValueField = "ID_CONDOMINIO";
            dplCondominio.DataTextField = "NOMBRE_CONDOMINIO";
            dplCondominio.DataBind();
            dplCondominio.Items.Insert(0, "Seleccione un Condominio");
            dplCondominio.SelectedIndex = 0;
        }

        protected void dplCondominio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                long condominio = Convert.ToInt64(dplCondominio.SelectedValue);
                listaConserje = new List<PERSONA>();
                listaConserje = Controller.ControllerConserje.listaConserjeCondominio(condominio);
                dplConserje.DataSource = listaConserje;
                dplConserje.DataValueField = "ID_PERSONA";
                dplConserje.DataTextField = "FK_RUT";
                dplConserje.DataBind();
                dplConserje.Items.Insert(0, "Seleccione un Conserje");
                dplConserje.SelectedIndex = 0;
                dplTurno.SelectedIndex = 0;
                listaTurnoAsignar = new List<TURNO>();
                listaTurnoActual = new List<TURNO>();
                grHorario.DataSource = listaTurnoAsignar;
                grHorario.DataBind();
                grHorarioActual.DataSource = listaTurnoActual;
                grHorarioActual.DataBind();
            }
            catch (Exception ex)
            {
                dplConserje.Items.Insert(0, "Seleccione un Conserje");
                dplConserje.SelectedIndex = 0;
                dplTurno.SelectedIndex = 0;
                grHorarioActual.DataSource = null;
                grHorarioActual.DataBind();
                grHorario.DataSource = null;
                grHorario.DataBind();
                listaTurnoAsignar = new List<TURNO>();
                listaTurnoActual = new List<TURNO>();
                grHorario.DataSource = listaTurnoAsignar;
                grHorario.DataBind();
                grHorarioActual.DataSource = listaTurnoActual;
                grHorarioActual.DataBind();
                System.Diagnostics.Debug.WriteLine("Error:  " + ex);
            }
        }

        protected void dplConserje_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                long conserje = Convert.ToInt64(dplConserje.SelectedValue);
                CONSERJE aux = Controller.ControllerConserje.buscarIdConserje(conserje);
                listaTurnoActual = Controller.ControllerTurno.listaTurno(aux.ID_CONSERJE);
                grHorarioActual.DataSource = listaTurnoActual;
                grHorarioActual.DataBind();
                dplTurno.SelectedIndex = 0;
                listaTurnoAsignar = new List<TURNO>();
                grHorario.DataSource = listaTurnoAsignar;
                grHorario.DataBind();
            }
            catch (Exception ex)
            {
                grHorarioActual.DataSource = null;
                grHorarioActual.DataBind();
                grHorario.DataSource = null;
                grHorario.DataBind();
                dplTurno.SelectedIndex = 0;
                System.Diagnostics.Debug.WriteLine("Error:  " + ex);
            }
        }

        protected void grHorarioActual_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grHorarioActual.PageIndex = e.NewPageIndex;
            grHorarioActual.DataSource = listaTurnoActual;
            grHorarioActual.DataBind();
        }

        protected void grHorarioActual_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = grHorarioActual.SelectedIndex;
            turno = new TURNO();
            turno = listaTurnoActual[index];
            if (turno.DESCRIPCION_TURNO.Equals("Mañana"))
            {
                dplTurno.SelectedIndex = 1;
            }
            else if (turno.DESCRIPCION_TURNO.Equals("Tarde"))
            {
                dplTurno.SelectedIndex = 2;
            }
            else
            {
                dplTurno.SelectedIndex = 3;
            }
            string añoI = turno.FECHA_INICIO.Substring(6, 4);
            string mesI = turno.FECHA_INICIO.Substring(3, 2);
            string diaI = turno.FECHA_INICIO.Substring(0, 2);
            txtFechaI.Text = añoI + "-" + mesI + "-" + diaI;

            string añoT = turno.FECHA_TERMINO.Substring(6, 4);
            string mesT = turno.FECHA_TERMINO.Substring(3, 2);
            string diaT = turno.FECHA_TERMINO.Substring(0, 2);
            txtFechaT.Text = añoT + "-" + mesT + "-" + diaT;
            btnAgregarTurno.Visible = false;
            btnRegistroTurno.Visible = false;
            btnModificarTurno.Visible = true;
        }

        protected void btnAgregarTurno_Click(object sender, EventArgs e)
        {
            TURNO turno = new TURNO();
            DateTime fechaI = new DateTime();
            DateTime fechaT = new DateTime();
            string tipoTurno = dplTurno.SelectedValue;
            fechaI = Convert.ToDateTime(txtFechaI.Text);
            fechaT = Convert.ToDateTime(txtFechaT.Text);
            Boolean operation = true;
            foreach (TURNO item in listaTurnoActual)
            {
                if (item.FECHA_INICIO.Equals(fechaI.ToShortDateString()))
                {
                    if (item.DESCRIPCION_TURNO.Equals(tipoTurno))
                    {
                        lbError.Visible = true;
                        dplTurno.SelectedIndex = 0;
                        txtFechaI.Text = "";
                        txtFechaT.Text = "";
                        operation = false;
                    }
                }
            }

            if (operation == true)
            {
                lbError.Visible = false;
                turno.DESCRIPCION_TURNO = tipoTurno;
                turno.FECHA_INICIO = fechaI.ToShortDateString();
                turno.FECHA_TERMINO = fechaT.ToShortDateString();
                listaTurnoAsignar.Add(turno);
                grHorario.DataSource = listaTurnoAsignar;
                grHorario.DataBind();
                dplTurno.SelectedIndex = 0;
                txtFechaI.Text = "";
                txtFechaT.Text = "";
                btnRegistroTurno.Visible = true;
            }
        }

        protected void grHorario_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = grHorario.SelectedIndex;
            listaTurnoAsignar.RemoveAt(index);
            grHorario.DataSource = listaTurnoAsignar;
            grHorario.DataBind();
            if (listaTurnoAsignar.Count <= 0)
            {
                btnRegistroTurno.Visible = false;
            }
        }

        protected void grHorario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grHorario.PageIndex = e.NewPageIndex;
            grHorario.DataSource = listaTurnoAsignar;
            grHorario.DataBind();
        }

        protected void btnRegistroTurno_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            string resultTurno = "";
            string asignarTurno = "";
            long personal = Convert.ToInt64(dplConserje.SelectedValue);
            CONSERJE conserje = Controller.ControllerConserje.buscarIdConserje(personal);
            foreach (TURNO item in listaTurnoAsignar)
            {
                resultTurno = Controller.ControllerTurno.crearTurno(item.DESCRIPCION_TURNO, item.FECHA_INICIO, item.FECHA_TERMINO, conserje.ID_CONSERJE);
                if (resultTurno.Equals("Turno Creado"))
                {
                    asignarTurno = Controller.ControllerTurno.asignarTurno(conserje.ID_CONSERJE);
                }
            }

            if (asignarTurno.Equals("Turno Asignado"))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Turnos Asignados Correctamente');window.location.href='" + Request.RawUrl + "';", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Error al Registrar Turno');window.location.href='" + Request.RawUrl + "';", true);
            }
        }

        protected void btnModificarTurno_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            string resultUpdate = "";
            DateTime fechaI = new DateTime();
            DateTime fechaT = new DateTime();
            string tipoTurno = dplTurno.SelectedValue;
            fechaI = Convert.ToDateTime(txtFechaI.Text);
            fechaT = Convert.ToDateTime(txtFechaT.Text);
            resultUpdate = Controller.ControllerTurno.modificarTurno(turno.ID_TURNO, tipoTurno, fechaI.ToShortDateString(), fechaT.ToShortDateString());

            if (resultUpdate.Equals("Turno Modificado"))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Turno Modificado Correctamente');window.location.href='" + Request.RawUrl + "';", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Error al Modificar Turno');window.location.href='" + Request.RawUrl + "';", true);
            }
        }
    }
}