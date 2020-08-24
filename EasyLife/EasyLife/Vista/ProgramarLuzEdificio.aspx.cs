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
            if (!IsPostBack)
            {
                long persona = 2;
                cargarEdificioConserje(persona);
                cargarCondominio();
            }
        }

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
        }
    }
}