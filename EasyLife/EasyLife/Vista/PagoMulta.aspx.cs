using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EasyLife.Vista
{
    public partial class PagoMulta : System.Web.UI.Page
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
                }
                else if (admCondominio != null)
                {
                    cargarCondominioAdministrador(admCondominio.ID_PERSONA);
                }
                else
                {
                    cargarEdificioConserje(conserje.ID_PERSONA);
                }
            }
        }

        private static List<Adapter.AdapterMulta> listaMulta = new List<Adapter.AdapterMulta>();
        private static long total;

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
                dplDepartamento.Items.Insert(0, "Seleccione un Departamento");
                dplDepartamento.SelectedIndex = 0;
                listaMulta = new List<Adapter.AdapterMulta>();
                grMultas.DataSource = listaMulta;
                grMultas.DataBind();
                lbTotal.Text = "";
                total = 0;
            }
            catch (Exception ex)
            {
                dplEdificio.Items.Insert(0, "Seleccione un Edificio");
                dplEdificio.SelectedIndex = 0;
                dplDepartamento.Items.Insert(0, "Seleccione un Departamento");
                dplDepartamento.SelectedIndex = 0;
                listaMulta = new List<Adapter.AdapterMulta>();
                grMultas.DataSource = listaMulta;
                grMultas.DataBind();
                lbTotal.Text = "";
                total = 0;
                System.Diagnostics.Debug.WriteLine("Error: " + ex);
            }
        }

        protected void dplEdificio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                long edificio = Convert.ToInt64(dplEdificio.SelectedValue);
                List<DEPARTAMENTO> listaDep = Controller.ControllerDepartamento.listaDepartamentoOcupado(edificio);
                dplDepartamento.DataSource = listaDep;
                dplDepartamento.DataValueField = "ID_DEPARTAMENTO";
                dplDepartamento.DataTextField = "NUMERO_DEP";
                dplDepartamento.DataBind();
                dplDepartamento.Items.Insert(0, "Seleccione un Departamento");
                dplDepartamento.SelectedIndex = 0;
                listaMulta = new List<Adapter.AdapterMulta>();
                grMultas.DataSource = listaMulta;
                grMultas.DataBind();
                lbTotal.Text = "";
                total = 0;
            }
            catch (Exception ex)
            {
                dplDepartamento.Items.Insert(0, "Seleccione un Departamento");
                dplDepartamento.SelectedIndex = 0;
                listaMulta = new List<Adapter.AdapterMulta>();
                grMultas.DataSource = listaMulta;
                grMultas.DataBind();
                lbTotal.Text = "";
                total = 0;
                System.Diagnostics.Debug.WriteLine("Error: " + ex);
            }
        }

        protected void dplDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                long departamento = Convert.ToInt64(dplDepartamento.SelectedValue);
                total = 0;
                listaMulta = new List<Adapter.AdapterMulta>();
                listaMulta = Controller.ControllerMulta.listaAdapterMultaDepartamento(departamento);
                if (listaMulta.Count > 0)
                {
                    grMultas.DataSource = listaMulta;
                    grMultas.DataBind();
                    foreach (Adapter.AdapterMulta item in listaMulta)
                    {
                        total = total + item._COSTO_MULTA;
                    }
                    lbTotal.Text = total.ToString();
                }
                else
                {
                    listaMulta = new List<Adapter.AdapterMulta>();
                    grMultas.DataSource = listaMulta;
                    grMultas.DataBind();
                }
            }
            catch (Exception ex)
            {
                listaMulta = new List<Adapter.AdapterMulta>();
                grMultas.DataSource = listaMulta;
                grMultas.DataBind();
                System.Diagnostics.Debug.WriteLine("Error:  " + ex);
            }
        }

        protected void grMultas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grMultas.PageIndex = e.NewPageIndex;
            grMultas.DataSource = listaMulta;
            grMultas.DataBind();
        }

        protected void btnPagarMulta_Click(object sender, EventArgs e)
        {
        }
    }
}