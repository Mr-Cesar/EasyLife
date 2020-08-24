using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EasyLife.Vista
{
    public partial class RegistroConserje : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarCondominio();

                string updateConserje = (string)Session["ModificarConserje"];
                if (updateConserje != null)
                {
                    operation = true;
                }
            }
        }

        private static List<PERSONA> listaConserje = new List<PERSONA>();
        private static List<TURNO> listaTurno = new List<TURNO>();
        private static Boolean operation = false;
        private static List<TURNO> listaTurnoUpdate = new List<TURNO>();

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

        protected void dplCondominio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                listaConserje = new List<PERSONA>();
                long condominio = Convert.ToInt64(dplCondominio.SelectedValue);
                listaConserje = Controller.ControllerConserje.listaConserjeCondominio(condominio);
                grConserje.DataSource = listaConserje;
                grConserje.DataBind();
            }
            catch (Exception ex)
            {
                listaConserje = new List<PERSONA>();
                grConserje.DataSource = listaConserje;
                grConserje.DataBind();
                System.Diagnostics.Debug.WriteLine("Error: " + ex);
            }
        }

        protected void grConserje_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grConserje.PageIndex = e.NewPageIndex;
            grConserje.DataSource = listaConserje;
            grConserje.DataBind();
        }

        protected void btnAgregarTurno_Click(object sender, EventArgs e)
        {
            TURNO turno = new TURNO();
            DateTime fechaI = new DateTime();
            DateTime fechaT = new DateTime();
            string tipoTurno = dplTurno.SelectedValue;
            fechaI = Convert.ToDateTime(txtFechaI.Text);
            fechaT = Convert.ToDateTime(txtFechaT.Text);
            Boolean option = true;
            if (operation == true)
            {
                if (listaTurnoUpdate.Count > 0)
                {
                    foreach (TURNO item in listaTurnoUpdate)
                    {
                        if (item.FECHA_INICIO.Equals(fechaI.ToShortDateString()))
                        {
                            if (item.DESCRIPCION_TURNO.Equals(tipoTurno))
                            {
                                lbError.Visible = true;
                                dplTurno.SelectedIndex = 0;
                                txtFechaI.Text = "";
                                txtFechaT.Text = "";
                                option = false;
                            }
                        }
                    }
                }

                if (option == true)
                {
                    lbError.Visible = false;
                    turno.DESCRIPCION_TURNO = tipoTurno;
                    turno.FECHA_INICIO = fechaI.ToShortDateString();
                    turno.FECHA_TERMINO = fechaT.ToShortDateString();
                    listaTurnoUpdate.Add(turno);
                    grHorario.DataSource = listaTurnoUpdate;
                    grHorario.DataBind();
                    dplTurno.SelectedIndex = 0;
                    txtFechaI.Text = "";
                    txtFechaT.Text = "";
                    btnRegistroConserje.Visible = true;
                }
            }
            else
            {
                if (listaTurno.Count > 0)
                {
                    foreach (TURNO item in listaTurno)
                    {
                        if (item.FECHA_INICIO.Equals(fechaI.ToShortDateString()))
                        {
                            if (item.DESCRIPCION_TURNO.Equals(tipoTurno))
                            {
                                lbError.Visible = true;
                                dplTurno.SelectedIndex = 0;
                                txtFechaI.Text = "";
                                txtFechaT.Text = "";
                                option = false;
                            }
                        }
                    }
                }

                if (option == true)
                {
                    lbError.Visible = false;
                    turno.DESCRIPCION_TURNO = tipoTurno;
                    turno.FECHA_INICIO = fechaI.ToShortDateString();
                    turno.FECHA_TERMINO = fechaT.ToShortDateString();
                    listaTurno.Add(turno);
                    grHorario.DataSource = listaTurno;
                    grHorario.DataBind();
                    dplTurno.SelectedIndex = 0;
                    txtFechaI.Text = "";
                    txtFechaT.Text = "";
                    btnRegistroConserje.Visible = true;
                }
            }
        }

        protected void grHorario_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = grHorario.SelectedIndex;
            listaTurno.RemoveAt(index);
            grHorario.DataSource = listaTurno;
            grHorario.DataBind();
        }

        protected void grHorario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (operation == true)
            {
                grHorario.PageIndex = e.NewPageIndex;
                grHorario.DataSource = listaTurnoUpdate;
                grHorario.DataBind();
            }
            else
            {
                grHorario.PageIndex = e.NewPageIndex;
                grHorario.DataSource = listaTurno;
                grHorario.DataBind();
            }
        }

        protected void btnRegistroConserje_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            string resultPersona = Controller.ControllerPersona.crearPersona(2, txtNombre.Text, txtApellido.Text, txtRut.Text, txtTelefono.Text, txtEmail.Text,
                false, radioSexo.SelectedValue);
            if (resultPersona.Equals("Persona Creada"))
            {
                PERSONA persona = Controller.ControllerPersona.buscarPersonaRut(txtRut.Text);
                string resultConserje = Controller.ControllerConserje.crearConserje(persona.ID_PERSONA, Convert.ToInt64(dplCondominio.SelectedValue));
                if (resultConserje.Equals("Conserje Creado"))
                {
                    string resultTurno = "";
                    CONSERJE conserje = Controller.ControllerConserje.buscarIdConserje(persona.ID_PERSONA);
                    foreach (TURNO item in listaTurno)
                    {
                        resultTurno = Controller.ControllerTurno.crearTurno(item.DESCRIPCION_TURNO, item.FECHA_INICIO, item.FECHA_TERMINO, conserje.ID_CONSERJE);
                    }

                    if (resultTurno.Equals("Turno Creado"))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Conserje Creado');window.location.href='" + Request.RawUrl + "';", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Error al Crear Turno');window.location.href='" + Request.RawUrl + "';", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Error al Crear Conserje');window.location.href='" + Request.RawUrl + "';", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Error al Crear Conserje');window.location.href='" + Request.RawUrl + "';", true);
            }
        }

        protected void btnModificarConserje_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
        }
    }
}