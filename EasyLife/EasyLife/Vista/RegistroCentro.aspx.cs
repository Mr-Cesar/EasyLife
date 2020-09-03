using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EasyLife.Vista
{
    public partial class RegistroCentro : System.Web.UI.Page
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
                    cargarCondominioAdministrador(admCondominio.ID_PERSONA);
                }
                cargarTipo();

                //Recuperar Session de Modificar Centro
                string modificarCentro = (string)Session["ModificarCentro"];

                if (modificarCentro != null)
                {
                    cargarParametros(modificarCentro);
                    lbOpcion.Text = "Modificar Centro";
                }
            }
        }

        private static List<HORARIO_CENTRO> listaHorario = new List<HORARIO_CENTRO>();
        private static List<HORARIO_CENTRO> horarioActual = new List<HORARIO_CENTRO>();
        private static List<Adapter.AdapterCentro> listaCentro = new List<Adapter.AdapterCentro>();
        private static CENTRO updateCentro = new CENTRO();

        public void cargarCondominio()
        {
            List<CONDOMINIO> lista = Controller.ControllerCondominio.listaCondominio();
            dplCondominio.DataSource = lista;
            dplCondominio.DataValueField = "ID_CONDOMINIO";
            dplCondominio.DataTextField = "NOMBRE_CONDOMINIO";
            dplCondominio.DataBind();
            dplCondominio.Items.Insert(0, "Seleccione un Condominio");
            dplCondominio.SelectedIndex = 0;
            listaCentro = new List<Adapter.AdapterCentro>();
            grCentros.DataSource = listaCentro;
            grCentros.DataBind();
            listaHorario = new List<HORARIO_CENTRO>();
            grHorario.DataSource = listaHorario;
            grHorario.DataBind();
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
            listaCentro = new List<Adapter.AdapterCentro>();
            grCentros.DataSource = listaCentro;
            grCentros.DataBind();
            listaHorario = new List<HORARIO_CENTRO>();
            grHorario.DataSource = listaHorario;
            grHorario.DataBind();
        }

        public void cargarTipo()
        {
            List<TIPO_CENTRO> listaTipo = Controller.ControllerTipoCentro.listaTipoCentro();
            dplTipo.DataSource = listaTipo;
            dplTipo.DataValueField = "ID_TIPO_CENTRO";
            dplTipo.DataTextField = "NOMBRE_TIPO_CENTRO";
            dplTipo.DataBind();
            dplTipo.Items.Insert(0, "Seleccione un Tipo de Centro");
            dplTipo.SelectedIndex = 0;
        }

        public void cargarParametros(string centro)
        {
            CENTRO aux = Controller.ControllerCentro.buscarIdCentro(Convert.ToInt64(centro));
            EDIFICIO edificio = Controller.ControllerEdificio.buscarIdEdificio(aux.ID_EDIFICIO);
            cargarCondominio();
            dplCondominio.SelectedValue = edificio.ID_CONDOMINIO.ToString();
            dplCondominio.Enabled = false;
            List<EDIFICIO> listaEdificio = Controller.ControllerEdificio.buscarEdificioCondominio(edificio.ID_CONDOMINIO);
            dplEdificio.DataSource = listaEdificio;
            dplEdificio.DataValueField = "ID_EDIFICIO";
            dplEdificio.DataTextField = "NOMBRE_EDIFICIO";
            dplEdificio.DataBind();
            dplEdificio.Items.Insert(0, "Seleccione un Edificio");
            dplEdificio.SelectedValue = aux.ID_EDIFICIO.ToString();
            dplEdificio.Enabled = false;
            dplTipo.SelectedValue = aux.ID_TIPO_CENTRO.ToString();
            txtNomCentro.Text = aux.NOMBRE_CENTRO;
            txtCosto.Text = aux.COSTO.ToString();
            btnRegistroCentro.Visible = false;
            btnModificarCentro.Visible = true;

            horarioActual = new List<HORARIO_CENTRO>();
            horarioActual = Controller.ControllerHorarioCentro.listadoHorario(Convert.ToInt64(centro));
            lbHorarioActual.Visible = true;
            grHorarioActual.DataSource = horarioActual;
            grHorarioActual.DataBind();
            updateCentro = aux;
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
                dplTipo.SelectedIndex = 0;
                listaCentro = new List<Adapter.AdapterCentro>();
                grCentros.DataSource = listaCentro;
                grCentros.DataBind();
                listaHorario = new List<HORARIO_CENTRO>();
                grHorario.DataSource = listaHorario;
                grHorario.DataBind();
            }
            catch (Exception ex)
            {
                dplEdificio.Items.Insert(0, "Seleccione un Edificio");
                dplEdificio.SelectedIndex = 0;
                dplTipo.SelectedIndex = 0;
                listaCentro = new List<Adapter.AdapterCentro>();
                grCentros.DataSource = listaCentro;
                grCentros.DataBind();
                listaHorario = new List<HORARIO_CENTRO>();
                grHorario.DataSource = listaHorario;
                grHorario.DataBind();
                System.Diagnostics.Debug.WriteLine("Error: " + ex);
            }
        }

        protected void dplEdificio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                long edificio = Convert.ToInt64(dplEdificio.SelectedValue);
                listaCentro = new List<Adapter.AdapterCentro>();
                listaCentro = Controller.ControllerCentro.listaCentrosEdificio(edificio);
                grCentros.DataSource = listaCentro;
                grCentros.DataBind();
            }
            catch (Exception ex)
            {
                dplTipo.SelectedIndex = 0;
                listaCentro = new List<Adapter.AdapterCentro>();
                grCentros.DataSource = listaCentro;
                grCentros.DataBind();
                listaHorario = new List<HORARIO_CENTRO>();
                grHorario.DataSource = listaHorario;
                grHorario.DataBind();
                System.Diagnostics.Debug.WriteLine("Error: " + ex);
            }
        }

        protected void grCentros_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grCentros.PageIndex = e.NewPageIndex;
            grCentros.DataSource = listaCentro;
            grCentros.DataBind();
        }

        protected void dplTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtCosto.Text = "";
                txtDia.Text = "";
                txtHoraI.Text = "";
                txtHoraT.Text = "";
                txtNomCentro.Text = "";
                listaHorario = new List<HORARIO_CENTRO>();
                grHorario.DataSource = listaHorario;
                grHorario.DataBind();
            }
            catch (Exception ex)
            {
                txtCosto.Text = "";
                txtDia.Text = "";
                txtHoraI.Text = "";
                txtHoraT.Text = "";
                txtNomCentro.Text = "";
                listaHorario = new List<HORARIO_CENTRO>();
                grHorario.DataSource = listaHorario;
                grHorario.DataBind();
                System.Diagnostics.Debug.WriteLine("Error:  " + ex);
            }
        }

        protected void grHorarioActual_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grHorarioActual.PageIndex = e.NewPageIndex;
            grHorarioActual.DataSource = horarioActual;
            grHorarioActual.DataBind();
        }

        protected void btnAgregarHorario_Click(object sender, EventArgs e)
        {
            lbError.Visible = false;
            Boolean operation = true;
            DateTime dia = new DateTime();
            dia = Convert.ToDateTime(txtDia.Text);
            HORARIO_CENTRO horario = new HORARIO_CENTRO();
            horario.DIA_HORARIO = dia.ToString("dd/MM/yyy");
            horario.HORA_INICIO_D = txtHoraI.Text + ":00";
            horario.HORA_TERMINO_D = txtHoraT.Text + ":00";
            horario.HORARIO_COMPLETO = txtHoraI.Text + " - " + txtHoraT.Text;

            if (horarioActual.Count > 0)
            {
                foreach (HORARIO_CENTRO item in horarioActual)
                {
                    if (item.DIA_HORARIO.Equals(horario.DIA_HORARIO))
                    {
                        if (item.HORA_INICIO_D.Equals(horario.HORA_INICIO_D))
                        {
                            operation = false;
                        }
                    }
                }
            }

            if (operation == true)
            {
                if (listaHorario.Count > 0)
                {
                    foreach (HORARIO_CENTRO item in listaHorario)
                    {
                        if (item.DIA_HORARIO.Equals(horario.DIA_HORARIO) && item.HORA_INICIO_D.Equals(horario.HORA_INICIO_D))
                        {
                            lbError.Visible = true;
                            operation = false;
                        }
                    }
                }
            }

            if (operation == true)
            {
                lbError.Visible = false;
                lbHorario.Visible = true;
                listaHorario.Add(horario);
                grHorario.DataSource = listaHorario;
                grHorario.DataBind();
                txtDia.Text = "";
                txtHoraI.Text = "";
                txtHoraT.Text = "";
            }
            else
            {
                lbError.Visible = true;
            }
        }

        protected void grHorario_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = grHorario.SelectedIndex;
            listaHorario.RemoveAt(index);
            grHorario.DataSource = listaHorario;
            grHorario.DataBind();
        }

        protected void grHorario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grHorario.PageIndex = e.NewPageIndex;
            grHorario.DataSource = listaHorario;
            grHorario.DataBind();
        }

        protected void btnRegistroCentro_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            string resultCentro = "";
            string resultHorario = "";

            resultCentro = Controller.ControllerCentro.crearCentro(Convert.ToInt64(dplTipo.SelectedValue), Convert.ToInt64(dplEdificio.SelectedValue), txtNomCentro.Text,
                Convert.ToInt32(txtCosto.Text));

            if (resultCentro.Equals("Centro Creado"))
            {
                CENTRO centro = Controller.ControllerCentro.buscarCentroEdificio(Convert.ToInt64(dplEdificio.SelectedValue), txtNomCentro.Text);
                foreach (HORARIO_CENTRO item in listaHorario)
                {
                    resultHorario = Controller.ControllerHorarioCentro.crearHorarioCentro(centro.ID_CENTRO, item.DIA_HORARIO, item.HORA_INICIO_D,
                        item.HORA_TERMINO_D, item.HORARIO_COMPLETO);
                }

                if (resultHorario.Equals("Horario Creado"))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Centro Creado');window.location.href='" + Request.RawUrl + "';", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Error al Crear Centro');window.location.href='" + Request.RawUrl + "';", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Error al Crear Centro');window.location.href='" + Request.RawUrl + "';", true);
            }
        }

        protected void btnModificarCentro_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            long idCentro = updateCentro.ID_CENTRO;
            long edificio = Convert.ToInt64(dplEdificio.SelectedValue);
            long tipo = Convert.ToInt64(dplTipo.SelectedValue);
            string nombre = txtNomCentro.Text;
            int costo = Convert.ToInt32(txtCosto.Text);
            string resultUpdateCentro = Controller.ControllerCentro.modificarCentro(idCentro, tipo, edificio, nombre, costo);
            string resultHorario = "";
            if (resultUpdateCentro.Equals("Centro Modificado"))
            {
                CENTRO centro = Controller.ControllerCentro.buscarCentroEdificio(Convert.ToInt64(dplEdificio.SelectedValue), txtNomCentro.Text);
                foreach (HORARIO_CENTRO item in listaHorario)
                {
                    resultHorario = Controller.ControllerHorarioCentro.crearHorarioCentro(centro.ID_CENTRO, item.DIA_HORARIO, item.HORA_INICIO_D,
                        item.HORA_TERMINO_D, item.HORARIO_COMPLETO);
                }

                if (resultHorario.Equals("Horario Creado"))
                {
                    Session["ModificarCentro"] = null;
                    Session["ModificarHorario"] = null;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Centro Modificado');window.location.href='" + Request.RawUrl + "';", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Error al Modificar Centro');window.location.href='" + Request.RawUrl + "';", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Error al Modificar Centro');window.location.href='" + Request.RawUrl + "';", true);
            }
        }
    }
}