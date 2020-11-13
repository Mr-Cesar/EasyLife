using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EasyLife.Vista
{
    public partial class DetalleGastoComun : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validación de Session Iniciada
            LOGIN adm = (LOGIN)Session["adm"];
            LOGIN conserje = (LOGIN)Session["conserje"];
            LOGIN vendedor = (LOGIN)Session["vendedor"];
            LOGIN propietario = (LOGIN)Session["login"];
            LOGIN admCondominio = (LOGIN)Session["admCondominio"];
            if (vendedor != null)
            {
                Response.Redirect("~/Vista/Index.aspx");
            }
            else if (adm == null && conserje == null && vendedor == null && propietario == null && admCondominio == null)
            {
                Response.Redirect("~/Vista/Index.aspx");
            }

            if (!IsPostBack)
            {
                cargarAño();
                if (adm != null)
                {
                    cargarCondominio();
                    prop = false;
                }
                else if (admCondominio != null)
                {
                    cargarCondominioAdministrador(admCondominio.ID_PERSONA);
                    prop = false;
                }
                else if (conserje != null)
                {
                    cargarEdificioConserje(conserje.ID_PERSONA);
                    prop = false;
                }
                else
                {
                    cargarPropietario(propietario.ID_PERSONA);
                    prop = true;
                }
            }

            /*if (!IsPostBack)
            {
                long propietario = 4;
                cargarPropietario(propietario);
                cargarAño();
                prop = true;
            }*/
        }

        private static Boolean prop = false;
        private static List<EDIFICIO> listaEdificio = new List<EDIFICIO>();
        private static List<CONDOMINIO> listaCondominio = new List<CONDOMINIO>();
        private static List<Adapter.AdapterGastoComun> listaGastos = new List<Adapter.AdapterGastoComun>();

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
            dplCondominio.Visible = false;
            CONSERJE conserje = Controller.ControllerConserje.buscarIdConserje(persona);
            List<EDIFICIO> listaEdificio = Controller.ControllerEdificio.buscarEdificioCondominio(Convert.ToInt64(conserje.ID_CONDOMINIO));
            dplEdificio.DataSource = listaEdificio;
            dplEdificio.DataValueField = "ID_EDIFICIO";
            dplEdificio.DataTextField = "NOMBRE_EDIFICIO";
            dplEdificio.DataBind();
            dplEdificio.Items.Insert(0, "Seleccione un Edificio");
            dplEdificio.SelectedIndex = 0;
        }

        public void cargarPropietario(long propietario)
        {
            List<DEPARTAMENTO> listaDepartamento = Controller.ControllerDepartamento.listaDepartamentoPersona(propietario);
            listaEdificio = new List<EDIFICIO>();
            listaCondominio = new List<CONDOMINIO>();
            if (listaDepartamento.Count > 0)
            {
                foreach (DEPARTAMENTO item in listaDepartamento)
                {
                    EDIFICIO edificio = Controller.ControllerEdificio.buscarIdEdificio(item.ID_EDIFICIO);
                    CONDOMINIO condominio = Controller.ControllerCondominio.buscarIdCondominio(edificio.ID_CONDOMINIO);
                    listaEdificio.Add(edificio);
                    listaCondominio.Add(condominio);
                }
            }

            var listEdificio = listaEdificio.GroupBy(x => x.ID_EDIFICIO).Select(y => y.FirstOrDefault());
            var listCondominio = listaCondominio.GroupBy(x => x.ID_CONDOMINIO).Select(y => y.FirstOrDefault());

            listaEdificio = listEdificio.ToList();
            listaCondominio = listCondominio.ToList();

            dplCondominio.DataSource = listCondominio;
            dplCondominio.DataValueField = "ID_CONDOMINIO";
            dplCondominio.DataTextField = "NOMBRE_CONDOMINIO";
            dplCondominio.DataBind();
            dplCondominio.Items.Insert(0, "Seleccione un Condominio");
            dplCondominio.SelectedIndex = 0;

            dplEdificio.DataSource = listEdificio;
            dplEdificio.DataValueField = "ID_EDIFICIO";
            dplEdificio.DataTextField = "NOMBRE_EDIFICIO";
            dplEdificio.DataBind();
            dplEdificio.Items.Insert(0, "Seleccione un Edificio");
            dplEdificio.SelectedIndex = 0;
        }

        public void cargarAño()
        {
            List<BOLETA_GASTO> listaAños = Controller.ControllerGastoComun.listaAños();
            dplAño.DataSource = listaAños;
            dplAño.DataValueField = "ANO";
            dplAño.DataTextField = "ANO";
            dplAño.DataBind();
            dplAño.Items.Insert(0, "Seleccione un Año");
            dplAño.SelectedIndex = 0;
        }

        protected void dplCondominio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                long condominio = Convert.ToInt64(dplCondominio.SelectedValue);
                dplAño.SelectedIndex = 0;
                List<EDIFICIO> lista = new List<EDIFICIO>();
                if (prop == false)
                {
                    lista = Controller.ControllerEdificio.buscarEdificioCondominio(condominio);
                }
                else
                {
                    foreach (EDIFICIO item in listaEdificio)
                    {
                        if (item.ID_CONDOMINIO == condominio)
                        {
                            lista.Add(item);
                        }
                    }
                }

                dplEdificio.DataSource = lista;
                dplEdificio.DataValueField = "ID_EDIFICIO";
                dplEdificio.DataTextField = "NOMBRE_EDIFICIO";
                dplEdificio.DataBind();
                dplEdificio.Items.Insert(0, "Seleccione un Edificio");
                dplEdificio.SelectedIndex = 0;

                listaGastos = new List<Adapter.AdapterGastoComun>();
                foreach (EDIFICIO item in lista)
                {
                    Adapter.AdapterGastoComun gasto = new Adapter.AdapterGastoComun();
                    gasto = Controller.ControllerGastoComun.buscarAdapterGastoComunEdificio(item.ID_EDIFICIO);
                    listaGastos.Add(gasto);
                }

                grDetalle.DataSource = listaGastos;
                grDetalle.DataBind();
            }
            catch (Exception ex)
            {
                dplEdificio.SelectedIndex = 0;
                dplAño.SelectedIndex = 0;
                System.Diagnostics.Debug.WriteLine("Error: " + ex);
            }
        }

        protected void dplEdificio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                long edificio = Convert.ToInt64(dplEdificio.SelectedValue);
                dplAño.SelectedIndex = 0;
                listaGastos = new List<Adapter.AdapterGastoComun>();
                Adapter.AdapterGastoComun gasto = Controller.ControllerGastoComun.buscarAdapterGastoComunEdificio(edificio);
                listaGastos.Add(gasto);
                grDetalle.DataSource = listaGastos;
                grDetalle.DataBind();
            }
            catch (Exception ex)
            {
                dplAño.SelectedIndex = 0;
                System.Diagnostics.Debug.WriteLine("Error: " + ex);
            }
        }

        protected void dplAño_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string año = dplAño.SelectedValue;
                foreach (Adapter.AdapterGastoComun item in listaGastos)
                {
                    if (item._ANO.Equals(año))
                    {
                        listaGastos.Add(item);
                    }
                }
                grDetalle.DataSource = listaGastos;
                grDetalle.DataBind();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error: " + ex);
            }
        }

        protected void grDetalle_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grDetalle.PageIndex = e.NewPageIndex;
            grDetalle.DataSource = listaGastos;
            grDetalle.DataBind();
        }
    }
}