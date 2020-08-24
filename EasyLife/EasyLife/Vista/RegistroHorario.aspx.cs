using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EasyLife.Vista
{
    public partial class RegistroHorario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarCondominio();

                string updateCentro = (string)Session["ModificarHorario"];
                if (updateCentro != null)
                {
                    cargarParametros(updateCentro);
                    lbOpcion.Text = "Modificar Horario Centro";
                }
            }
        }

        private static List<HORARIO_CENTRO> listaHorario = new List<HORARIO_CENTRO>();
        private static List<Adapter.AdapterCentro> listaCentro = new List<Adapter.AdapterCentro>();
        private static CENTRO centroUpdate = new CENTRO();

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
            lbNombreCentro.Text = aux.NOMBRE_CENTRO;
            btnRegistroHorario.Visible = false;
            btnModificarHorario.Visible = true;
            centroUpdate = aux;
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
                listaCentro = new List<Adapter.AdapterCentro>();
                grCentros.DataSource = listaCentro;
                grCentros.DataBind();
                listaHorario = new List<HORARIO_CENTRO>();
                grHorario.DataSource = listaHorario;
                grHorario.DataBind();
                System.Diagnostics.Debug.WriteLine("Error: " + ex);
            }
        }

        protected void grCentros_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gvr = grCentros.SelectedRow;
            long centro = (long)grCentros.DataKeys[gvr.RowIndex].Value;
            CENTRO aux = Controller.ControllerCentro.buscarIdCentro(centro);
            lbNombreCentro.Text = aux.NOMBRE_CENTRO;
            centroUpdate = aux;
        }

        protected void grCentros_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grCentros.PageIndex = e.NewPageIndex;
            grCentros.DataSource = listaCentro;
            grCentros.DataBind();
        }

        protected void btnAgregarHorario_Click(object sender, EventArgs e)
        {
            lbError.Visible = false;
            Boolean operation = true;
            Boolean insert = true;
            DateTime dia = new DateTime();
            dia = Convert.ToDateTime(txtDia.Text);
            HORARIO_CENTRO horario = new HORARIO_CENTRO();
            horario.DIA_HORARIO = dia.ToString("dd/MM/yyy");
            horario.HORA_INICIO_D = txtHoraI.Text;
            horario.HORA_TERMINO_D = txtHoraT.Text;
            horario.HORARIO_COMPLETO = txtHoraI.Text + " - " + txtHoraT.Text;
            List<HORARIO_CENTRO> listaHorarioActual = new List<HORARIO_CENTRO>();
            listaHorarioActual = Controller.ControllerHorarioCentro.listadoHorario(centroUpdate.ID_CENTRO);
            foreach (HORARIO_CENTRO item in listaHorarioActual)
            {
                if (item.DIA_HORARIO.Equals(horario.DIA_HORARIO))
                {
                    if (item.HORA_INICIO_D.Equals(horario.HORA_INICIO_D))
                    {
                        operation = false;
                        insert = false;
                    }
                }
            }

            if (insert == true)
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

        protected void btnRegistroHorario_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            string resultHorario = "";

            CENTRO centro = Controller.ControllerCentro.buscarCentroEdificio(Convert.ToInt64(dplEdificio.SelectedValue), lbNombreCentro.Text);
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

        protected void btnModificarHorario_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            string resultHorario = "";
        }
    }
}