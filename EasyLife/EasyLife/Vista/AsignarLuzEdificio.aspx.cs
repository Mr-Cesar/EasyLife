using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EasyLife.Vista
{
    public partial class AsignarLuzEdificio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarCondominio();
                cargarLuzEdificio();
            }
        }

        private static List<Adapter.AdapterLuzEdificio> listaLuzEdificio = new List<Adapter.AdapterLuzEdificio>();
        private static List<Adapter.AdapterLuzEdificio> listaLuzEdificioUpdate = new List<Adapter.AdapterLuzEdificio>();

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

        public void cargarCondominioAdm(long administrador)
        {
            List<CONDOMINIO> lista = Controller.ControllerCondominio.listaCondominioAdministrador(administrador);
            dplCondominio.DataSource = lista;
            dplCondominio.DataValueField = "ID_CONDOMINIO";
            dplCondominio.DataTextField = "NOMBRE_CONDOMINIO";
            dplCondominio.DataBind();
            dplCondominio.Items.Insert(0, "Seleccione un Condominio");
            dplCondominio.SelectedIndex = 0;
        }

        public void cargarLuzEdificio()
        {
            List<LUZ_EDIFICIO> lista = Controller.ControllerLuzEdificio.listaLuzDisponibles();
            dplLuz.DataSource = lista;
            dplLuz.DataValueField = "ID_LUZ_E";
            dplLuz.DataTextField = "CODIGO_LUZ_E";
            dplLuz.DataBind();
            dplLuz.Items.Insert(0, "Seleccione una Luz");
            dplLuz.SelectedIndex = 0;
        }

        protected void dplOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dplCondominio.Enabled = true;
                dplEdificio.Enabled = true;
                dplLuz.Enabled = true;
                lbError.Visible = false;
                listaLuzEdificio = new List<Adapter.AdapterLuzEdificio>();
                listaLuzEdificioUpdate = new List<Adapter.AdapterLuzEdificio>();
                grLuces.DataSource = listaLuzEdificio;
                grLuces.DataBind();
                int option = dplOption.SelectedIndex;
                if (option == 0)
                {
                    dplCondominio.Enabled = false;
                    dplEdificio.Enabled = false;
                    dplLuz.Enabled = false;
                    btnAgregarLuz.Visible = false;
                    btnRegistroLuz.Visible = false;
                    btnModificarLuz.Visible = false;
                    btnUpdateLuz.Visible = false;
                }
                else if (option == 1)
                {
                    btnAgregarLuz.Visible = true;
                    btnRegistroLuz.Visible = true;
                    btnAgregarLuz.Enabled = true;
                    btnModificarLuz.Visible = false;
                    btnUpdateLuz.Visible = false;
                }
                else if (option == 2)
                {
                    btnModificarLuz.Visible = true;
                    btnUpdateLuz.Visible = true;
                    btnModificarLuz.Enabled = true;
                    btnAgregarLuz.Visible = false;
                    btnRegistroLuz.Visible = false;
                }
            }
            catch (Exception ex)
            {
                listaLuzEdificio = new List<Adapter.AdapterLuzEdificio>();
                listaLuzEdificioUpdate = new List<Adapter.AdapterLuzEdificio>();
                grLuces.DataSource = listaLuzEdificio;
                grLuces.DataBind();
                dplCondominio.Enabled = false;
                dplEdificio.Enabled = false;
                dplLuz.Enabled = false;
                btnAgregarLuz.Visible = false;
                btnModificarLuz.Visible = false;
                btnRegistroLuz.Visible = false;
                btnUpdateLuz.Visible = false;
                lbError.Visible = false;
                System.Diagnostics.Debug.WriteLine("Error: " + ex);
            }
        }

        protected void dplCondominio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dplLuz.SelectedIndex = 0;
                btnAgregarLuz.Enabled = true;
                btnModificarLuz.Enabled = true;
                lbError.Visible = false;
                long condominio = Convert.ToInt64(dplCondominio.SelectedValue);
                List<EDIFICIO> listaEdificio = Controller.ControllerEdificio.buscarEdificioCondominio(condominio);
                dplEdificio.DataSource = listaEdificio;
                dplEdificio.DataValueField = "ID_EDIFICIO";
                dplEdificio.DataTextField = "NOMBRE_EDIFICIO";
                dplEdificio.DataBind();
                dplEdificio.Items.Insert(0, "Seleccione un Edificio");
                dplEdificio.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                dplEdificio.Items.Insert(0, "Seleccione un Edificio");
                dplEdificio.SelectedIndex = 0;
                dplLuz.SelectedIndex = 0;
                System.Diagnostics.Debug.WriteLine("Error: " + ex);
            }
        }

        protected void dplEdificio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                btnAgregarLuz.Enabled = true;
                lbError.Visible = false;
                long option = dplOption.SelectedIndex;
                if (option == 1)
                {
                    long edificio = Convert.ToInt64(dplEdificio.SelectedValue);
                    List<LUZ_EDIFICIO> lista = Controller.ControllerLuzEdificio.buscarLuzEdificio(edificio);
                    if (lista.Count > 0)
                    {
                        lbError.Visible = true;
                        lbError.Text = "Edificio ya Posee Luz";
                        btnAgregarLuz.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                dplLuz.SelectedIndex = 0;
                System.Diagnostics.Debug.WriteLine("Error: " + ex);
            }
        }

        protected void btnAgregarLuz_Click(object sender, EventArgs e)
        {
            Adapter.AdapterLuzEdificio adapter = new Adapter.AdapterLuzEdificio();
            CONDOMINIO condominio = Controller.ControllerCondominio.buscarIdCondominio(Convert.ToInt64(dplCondominio.SelectedValue));
            EDIFICIO edificio = Controller.ControllerEdificio.buscarIdEdificio(Convert.ToInt64(dplEdificio.SelectedValue));
            LUZ_EDIFICIO luz = Controller.ControllerLuzEdificio.buscarIdLuzEdificio(Convert.ToInt64(dplLuz.SelectedValue));
            lbError.Visible = false;
            List<Adapter.AdapterLuzEdificio> listaAux = listaLuzEdificio;
            if (listaLuzEdificio.Count > 0)
            {
                foreach (Adapter.AdapterLuzEdificio item in listaAux.ToList())
                {
                    if (item._ID_LUZ_E == Convert.ToInt64(dplLuz.SelectedValue))
                    {
                        lbError.Visible = true;
                        lbError.Text = "Luz ya Asignada";
                    }
                    else if (item._ID_EDIFICIO == Convert.ToInt64(dplEdificio.SelectedValue))
                    {
                        lbError.Visible = true;
                        lbError.Text = "Edificio ya Posee Luz";
                    }
                    else
                    {
                        lbError.Visible = false;
                        adapter._ID_LUZ_E = luz.ID_LUZ_E;
                        adapter._CODIGO_LUZ_E = luz.CODIGO_LUZ_E;
                        adapter._ID_EDIFICIO = edificio.ID_EDIFICIO;
                        adapter._NOMBRE_EDIFICIO = edificio.NOMBRE_EDIFICIO;
                        adapter._ID_CONDOMINIO = condominio.ID_CONDOMINIO;
                        adapter._NOMBRE_CONDOMINIO = condominio.NOMBRE_CONDOMINIO;
                        adapter._ESTADO_LUZ_E = luz.ESTADO_LUZ_E;
                        listaLuzEdificio.Add(adapter);
                        grLuces.DataSource = listaLuzEdificio;
                        grLuces.DataBind();
                    }
                }
            }
            else
            {
                lbError.Visible = false;
                adapter._ID_LUZ_E = luz.ID_LUZ_E;
                adapter._CODIGO_LUZ_E = luz.CODIGO_LUZ_E;
                adapter._ID_EDIFICIO = edificio.ID_EDIFICIO;
                adapter._NOMBRE_EDIFICIO = edificio.NOMBRE_EDIFICIO;
                adapter._ID_CONDOMINIO = condominio.ID_CONDOMINIO;
                adapter._NOMBRE_CONDOMINIO = condominio.NOMBRE_CONDOMINIO;
                adapter._ESTADO_LUZ_E = luz.ESTADO_LUZ_E;
                listaLuzEdificio.Add(adapter);
                grLuces.DataSource = listaLuzEdificio;
                grLuces.DataBind();
            }
        }

        protected void btnModificarLuz_Click(object sender, EventArgs e)
        {
            Adapter.AdapterLuzEdificio adapter = new Adapter.AdapterLuzEdificio();
            CONDOMINIO condominio = Controller.ControllerCondominio.buscarIdCondominio(Convert.ToInt64(dplCondominio.SelectedValue));
            EDIFICIO edificio = Controller.ControllerEdificio.buscarIdEdificio(Convert.ToInt64(dplEdificio.SelectedValue));
            LUZ_EDIFICIO luz = Controller.ControllerLuzEdificio.buscarIdLuzEdificio(Convert.ToInt64(dplLuz.SelectedValue));
            lbError.Visible = false;
            List<Adapter.AdapterLuzEdificio> listaAux = listaLuzEdificioUpdate;
            if (listaLuzEdificioUpdate.Count > 0)
            {
                foreach (Adapter.AdapterLuzEdificio item in listaAux.ToList())
                {
                    if (item._ID_LUZ_E == Convert.ToInt64(dplLuz.SelectedValue))
                    {
                        lbError.Visible = true;
                        lbError.Text = "Luz ya Asignada";
                    }
                    else if (item._ID_EDIFICIO == Convert.ToInt64(dplEdificio.SelectedValue))
                    {
                        lbError.Visible = true;
                        lbError.Text = "Edificio ya Posee Luz";
                    }
                    else
                    {
                        lbError.Visible = false;
                        adapter._ID_LUZ_E = luz.ID_LUZ_E;
                        adapter._CODIGO_LUZ_E = luz.CODIGO_LUZ_E;
                        adapter._ID_EDIFICIO = edificio.ID_EDIFICIO;
                        adapter._NOMBRE_EDIFICIO = edificio.NOMBRE_EDIFICIO;
                        adapter._ID_CONDOMINIO = condominio.ID_CONDOMINIO;
                        adapter._NOMBRE_CONDOMINIO = condominio.NOMBRE_CONDOMINIO;
                        adapter._ESTADO_LUZ_E = luz.ESTADO_LUZ_E;
                        listaLuzEdificioUpdate.Add(adapter);
                        grLuces.DataSource = listaLuzEdificioUpdate;
                        grLuces.DataBind();
                    }
                }
            }
            else
            {
                lbError.Visible = false;
                adapter._ID_LUZ_E = luz.ID_LUZ_E;
                adapter._CODIGO_LUZ_E = luz.CODIGO_LUZ_E;
                adapter._ID_EDIFICIO = edificio.ID_EDIFICIO;
                adapter._NOMBRE_EDIFICIO = edificio.NOMBRE_EDIFICIO;
                adapter._ID_CONDOMINIO = condominio.ID_CONDOMINIO;
                adapter._NOMBRE_CONDOMINIO = condominio.NOMBRE_CONDOMINIO;
                adapter._ESTADO_LUZ_E = luz.ESTADO_LUZ_E;
                listaLuzEdificioUpdate.Add(adapter);
                grLuces.DataSource = listaLuzEdificioUpdate;
                grLuces.DataBind();
            }
        }

        protected void grLuces_SelectedIndexChanged(object sender, EventArgs e)
        {
            long option = Convert.ToInt64(dplOption.SelectedIndex);
            if (option == 1)
            {
                int index = grLuces.SelectedIndex;
                listaLuzEdificio.RemoveAt(index);
                grLuces.DataSource = listaLuzEdificio;
                grLuces.DataBind();
            }
            else if (option == 2)
            {
                int index = grLuces.SelectedIndex;
                listaLuzEdificioUpdate.RemoveAt(index);
                grLuces.DataSource = listaLuzEdificioUpdate;
                grLuces.DataBind();
            }
        }

        protected void btnRegistroLuz_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            string result = "";
            foreach (Adapter.AdapterLuzEdificio item in listaLuzEdificio)
            {
                result = Controller.ControllerLuzEdificio.asignarLuzEdificio(item._ID_EDIFICIO, item._ID_LUZ_E);
            }

            if (result.Equals("Luz Edificio Asignada"))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Luz Asignada');window.location.href='" + Request.RawUrl + "';", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Error al Asignar Luz');window.location.href='" + Request.RawUrl + "';", true);
            }
        }

        protected void btnUpdateLuz_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            string result = "";
            foreach (Adapter.AdapterLuzEdificio item in listaLuzEdificioUpdate)
            {
                result = Controller.ControllerLuzEdificio.asignarLuzEdificio(item._ID_EDIFICIO, item._ID_LUZ_E);
            }

            if (result.Equals("Luz Edificio Asignada"))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Luz Asignada');window.location.href='" + Request.RawUrl + "';", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Error al Asignar Luz');window.location.href='" + Request.RawUrl + "';", true);
            }
        }

        protected void grLuces_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            long option = dplOption.SelectedIndex;
            if (option == 1)
            {
                grLuces.PageIndex = e.NewPageIndex;
                grLuces.DataSource = listaLuzEdificio;
                grLuces.DataBind();
            }
            else if (option == 2)
            {
                grLuces.PageIndex = e.NewPageIndex;
                grLuces.DataSource = listaLuzEdificioUpdate;
                grLuces.DataBind();
            }
        }
    }
}