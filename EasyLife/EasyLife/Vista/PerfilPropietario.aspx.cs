using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace EasyLife.Vista
{
    public partial class PerfilPropietario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validación de Session Iniciada
            /*LOGIN adm = (LOGIN)Session["adm"];
            LOGIN conserje = (LOGIN)Session["conserje"];
            LOGIN vendedor = (LOGIN)Session["vendedor"];
            LOGIN propietario = (LOGIN)Session["login"];
            LOGIN admCondominio = (LOGIN)Session["admCondominio"];
            if (adm != null || vendedor != null || conserje != null || admCondominio != null)
            {
                Response.Redirect("Index.aspx");
            }
            else if (adm == null && conserje == null && vendedor == null && propietario == null && admCondominio == null)
            {
                Response.Redirect("Index.aspx");
            }

            if (!IsPostBack)
            {
                cargarDatos(propietario.ID_PERSONA);
                cargarGastos(propietario.ID_PERSONA);
                cargarControl(propietario.ID_PERSONA);
                cargarMulta(propietario.ID_PERSONA);
                cargarCentro(propietario.ID_PERSONA);
            }*/

            if (!IsPostBack)
            {
                long propietario = 4;
                cargarDatos(propietario);
                cargarGastos(propietario);
                cargarControl(propietario);
                cargarMulta(propietario);
                cargarCentro(propietario);
            }
        }

        private static PERSONA propietario = new PERSONA();
        private static List<DEPARTAMENTO> listaDepartamentos = new List<DEPARTAMENTO>();
        private static List<string> listaAños = new List<string>();
        private static List<Adapter.AdapterBoletaGasto> listagastos = new List<Adapter.AdapterBoletaGasto>();
        private static List<Adapter.AdapterBoletaGasto> listaSearchGasto = new List<Adapter.AdapterBoletaGasto>();
        private static Boolean searchGasto = false;
        private static Adapter.AdapterBoletaGasto adapterGasto = new Adapter.AdapterBoletaGasto();
        private static List<Adapter.AdapterControlLuzDepartamento> listaControlLuz = new List<Adapter.AdapterControlLuzDepartamento>();
        private static List<Adapter.AdapterControlLuzDepartamento> listaSearchControlLuz = new List<Adapter.AdapterControlLuzDepartamento>();
        private static Boolean searchControlLuz = false;
        private static List<Adapter.AdapterMulta> listaMulta = new List<Adapter.AdapterMulta>();
        private static List<Adapter.AdapterMulta> listaSearchMulta = new List<Adapter.AdapterMulta>();
        private static Boolean searchMulta = false;
        private static List<Adapter.AdapterReserva> listaReserva = new List<Adapter.AdapterReserva>();
        private static List<Adapter.AdapterReserva> listaSearchReserva = new List<Adapter.AdapterReserva>();
        private static Boolean searchReserva = false;

        public void cargarDatos(long persona)
        {
            PERSONA aux = Controller.ControllerPersona.buscarIdPersona(persona);
            lbUser.Text = aux.NOMBRE_PERSONA;
            lbRut.Text = aux.FK_RUT;
            lbNombre.Text = aux.NOMBRE_PERSONA;
            lbApellido.Text = aux.APELLIDO_PERSONA;
            lbTelefono.Text = aux.TELEFONO_PERSONA;
            lbCorreo.Text = aux.CORREO_PERSONA;
            propietario = aux;

            listaDepartamentos = Controller.ControllerDepartamento.listaDepartamentoPersona(persona);
            dplDepartamento.DataSource = listaDepartamentos;
            dplDepartamento.DataValueField = "ID_DEPARTAMENTO";
            dplDepartamento.DataTextField = "NUMERO_DEP";
            dplDepartamento.DataBind();
            dplDepartamento.Items.Insert(0, "Seleccione un Departamento");
            dplDepartamento.SelectedIndex = 0;

            dplDepartamentoLuz.DataSource = listaDepartamentos;
            dplDepartamentoLuz.DataValueField = "ID_DEPARTAMENTO";
            dplDepartamentoLuz.DataTextField = "NUMERO_DEP";
            dplDepartamentoLuz.DataBind();
            dplDepartamentoLuz.Items.Insert(0, "Seleccione un Departamento");
            dplDepartamentoLuz.SelectedIndex = 0;

            dplMulta.DataSource = listaDepartamentos;
            dplMulta.DataValueField = "ID_DEPARTAMENTO";
            dplMulta.DataTextField = "NUMERO_DEP";
            dplMulta.DataBind();
            dplMulta.Items.Insert(0, "Seleccione un Departamento");
            dplMulta.SelectedIndex = 0;

            lbLuz.Text = "";
            lbCondominio.Text = "";
            lbEdificio.Text = "";
        }

        public void cargarGastos(long propietario)
        {
            listagastos = new List<Adapter.AdapterBoletaGasto>();
            long total = 0;
            listagastos = Controller.ControllerGastoComun.listaGastosBoleta(propietario);
            foreach (Adapter.AdapterBoletaGasto item in listagastos)
            {
                if (item._COSTO_BOLETA != item._TOTAL_GASTO)
                {
                    total = item._COSTO_BOLETA - item._TOTAL_GASTO;
                    item._MULTA = total;
                }
            }
            grGastos.DataSource = listagastos;
            grGastos.DataBind();

            //Carga de Años
            listaAños = new List<string>();
        }

        public void cargarControl(long propietario)
        {
            listaControlLuz = new List<Adapter.AdapterControlLuzDepartamento>();
            listaControlLuz = Controller.ControllerControlIlimunacionDep.listaControlDep(propietario);
            grLuces.DataSource = listaControlLuz;
            grLuces.DataBind();
        }

        public void cargarMulta(long persona)
        {
            listaMulta = new List<Adapter.AdapterMulta>();
            listaMulta = Controller.ControllerMulta.listaAdapterMulta(propietario.ID_PERSONA);
            grMulta.DataSource = listaMulta;
            grMulta.DataBind();
        }

        public void cargarCentro(long persona)
        {
            //Carga de Tipo de Centro
            List<TIPO_CENTRO> listaTipos = Controller.ControllerTipoCentro.listaTipoCentro();
            dplCentro.DataSource = listaTipos;
            dplCentro.DataValueField = "ID_TIPO_CENTRO";
            dplCentro.DataTextField = "NOMBRE_TIPO_CENTRO";
            dplCentro.DataBind();
            dplCentro.Items.Insert(0, "Seleccione un Centro");
            dplCentro.SelectedIndex = 0;

            //Carga de Reservas de Centro
            listaReserva = new List<Adapter.AdapterReserva>();
            listaReserva = Controller.ControllerReservaCentro.listaReservaDepartamento(persona);
            grReserva.DataSource = listaReserva;
            grReserva.DataBind();
        }

        protected void btnDatosUsuario_Click(object sender, EventArgs e)
        {
            panelDatos.Visible = true;
            panelGastos.Visible = false;
            panelLuces.Visible = false;
            panelMulta.Visible = false;
            panelReserva.Visible = false;
            panelMensajes.Visible = false;
            panelAvisos.Visible = false;

            btnDatosUsuario.BackColor = Color.LightBlue;
            btnGastos.BackColor = Color.White;
            btnLuces.BackColor = Color.White;
            btnMultas.BackColor = Color.White;
            btnReserva.BackColor = Color.White;
            btnMensajes.BackColor = Color.White;
            btnAvisos.BackColor = Color.White;
        }

        protected void btnGastos_Click(object sender, EventArgs e)
        {
            panelDatos.Visible = false;
            panelGastos.Visible = true;
            panelLuces.Visible = false;
            panelMulta.Visible = false;
            panelReserva.Visible = false;
            panelMensajes.Visible = false;
            panelAvisos.Visible = false;

            btnDatosUsuario.BackColor = Color.White;
            btnGastos.BackColor = Color.LightBlue;
            btnLuces.BackColor = Color.White;
            btnMultas.BackColor = Color.White;
            btnReserva.BackColor = Color.White;
            btnMensajes.BackColor = Color.White;
            btnAvisos.BackColor = Color.White;
        }

        protected void btnLuces_Click(object sender, EventArgs e)
        {
            panelDatos.Visible = false;
            panelGastos.Visible = false;
            panelLuces.Visible = true;
            panelMulta.Visible = false;
            panelReserva.Visible = false;
            panelMensajes.Visible = false;
            panelAvisos.Visible = false;

            btnDatosUsuario.BackColor = Color.White;
            btnGastos.BackColor = Color.White;
            btnLuces.BackColor = Color.LightBlue;
            btnMultas.BackColor = Color.White;
            btnReserva.BackColor = Color.White;
            btnMensajes.BackColor = Color.White;
            btnAvisos.BackColor = Color.White;
        }

        protected void btnMultas_Click(object sender, EventArgs e)
        {
            panelDatos.Visible = false;
            panelGastos.Visible = false;
            panelLuces.Visible = false;
            panelMulta.Visible = true;
            panelReserva.Visible = false;
            panelMensajes.Visible = false;
            panelAvisos.Visible = false;

            btnDatosUsuario.BackColor = Color.White;
            btnGastos.BackColor = Color.White;
            btnLuces.BackColor = Color.White;
            btnMultas.BackColor = Color.LightBlue;
            btnReserva.BackColor = Color.White;
            btnMensajes.BackColor = Color.White;
            btnAvisos.BackColor = Color.White;
        }

        protected void btnReserva_Click(object sender, EventArgs e)
        {
            panelDatos.Visible = false;
            panelGastos.Visible = false;
            panelLuces.Visible = false;
            panelMulta.Visible = false;
            panelReserva.Visible = true;
            panelMensajes.Visible = false;
            panelAvisos.Visible = false;

            btnDatosUsuario.BackColor = Color.White;
            btnGastos.BackColor = Color.White;
            btnLuces.BackColor = Color.White;
            btnMultas.BackColor = Color.White;
            btnReserva.BackColor = Color.LightBlue;
            btnMensajes.BackColor = Color.White;
            btnAvisos.BackColor = Color.White;
        }

        protected void btnMensajes_Click(object sender, EventArgs e)
        {
            panelDatos.Visible = false;
            panelGastos.Visible = false;
            panelLuces.Visible = false;
            panelMulta.Visible = false;
            panelReserva.Visible = false;
            panelMensajes.Visible = true;
            panelAvisos.Visible = false;

            btnDatosUsuario.BackColor = Color.White;
            btnGastos.BackColor = Color.White;
            btnLuces.BackColor = Color.White;
            btnMultas.BackColor = Color.White;
            btnReserva.BackColor = Color.White;
            btnMensajes.BackColor = Color.LightBlue;
            btnAvisos.BackColor = Color.White;
        }

        protected void btnAvisos_Click(object sender, EventArgs e)
        {
            panelDatos.Visible = false;
            panelGastos.Visible = false;
            panelLuces.Visible = false;
            panelMulta.Visible = false;
            panelReserva.Visible = false;
            panelMensajes.Visible = false;
            panelAvisos.Visible = true;

            btnDatosUsuario.BackColor = Color.White;
            btnGastos.BackColor = Color.White;
            btnLuces.BackColor = Color.White;
            btnMultas.BackColor = Color.White;
            btnReserva.BackColor = Color.White;
            btnMensajes.BackColor = Color.White;
            btnAvisos.BackColor = Color.LightBlue;
        }

        public void limpiarVariables()
        {
            //Variables Datos Usuario
            dplDepartamento.SelectedIndex = 0;
            lbLuz.Text = "";
            lbCondominio.Text = "";
            lbEdificio.Text = "";

            //Variables Gastos
            listaSearchGasto = new List<Adapter.AdapterBoletaGasto>();
            grGastos.DataSource = listagastos;
            grGastos.DataBind();
            searchGasto = false;
            adapterGasto = new Adapter.AdapterBoletaGasto();
            dplGastos.SelectedIndex = 0;
            btnDescargarBoleta.Enabled = false;
            panelDetalleBoleta.Visible = false;
            lbErrorGasto.Visible = false;

            //Variables Control Luz
            listaSearchControlLuz = new List<Adapter.AdapterControlLuzDepartamento>();
            grLuces.DataSource = listaControlLuz;
            grLuces.DataBind();
            searchControlLuz = false;
            dplDepartamentoLuz.SelectedIndex = 0;
            lbErrorLuz.Visible = false;
            lbErrorSearchLuz.Visible = false;
            Session["ModificarControlIluminacionDep"] = null;

            //Variables Multas
            listaSearchMulta = new List<Adapter.AdapterMulta>();
            searchMulta = false;
            grMulta.DataSource = listaMulta;
            grMulta.DataBind();
            dplMulta.SelectedIndex = 0;
            lbErrorMulta.Visible = false;

            //Variables Reservas
            listaSearchReserva = new List<Adapter.AdapterReserva>();
            searchReserva = false;
            grReserva.DataSource = listaReserva;
            grReserva.DataBind();
            lbErrorReserva.Visible = false;
            lbErrorSearchReserva.Visible = false;
            dplCentro.SelectedIndex = 0;
        }

        protected void dplDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                long departamento = Convert.ToInt64(dplDepartamento.SelectedValue);
                DEPARTAMENTO aux = Controller.ControllerDepartamento.buscarIdDepartamento(departamento);
                if (aux.ID_LUZ_D != null)
                {
                    LUZ_DEPARTAMENTO luz = Controller.ControllerLuzDepartamento.buscarIdLuzDepartamento(Convert.ToInt64(aux.ID_LUZ_D));
                    lbLuz.Text = luz.CODIGO_LUZ_D;
                }
                else
                {
                    lbLuz.Text = "No Posee";
                }
                EDIFICIO edificio = Controller.ControllerEdificio.buscarIdEdificio(aux.ID_EDIFICIO);
                CONDOMINIO condominio = Controller.ControllerCondominio.buscarIdCondominio(edificio.ID_CONDOMINIO);
                lbEdificio.Text = edificio.NOMBRE_EDIFICIO;
                lbCondominio.Text = condominio.NOMBRE_CONDOMINIO;
            }
            catch (Exception ex)
            {
                lbLuz.Text = "";
                lbCondominio.Text = "";
                lbEdificio.Text = "";
                System.Diagnostics.Debug.WriteLine("Error:  " + ex);
            }
        }

        protected void lnkModificarDatos_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModificarDatos.aspx");
        }

        protected void lnkModificarPassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("CambiarPassword.aspx");
        }

        protected void dplGastos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error:  " + ex);
            }
        }

        protected void btnDescargarBoleta_Click(object sender, EventArgs e)
        {
        }

        protected void grGastos_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelDetalleBoleta.Visible = false;
            GridViewRow gvr = grGastos.SelectedRow;
            long boletasGasto = (long)grGastos.DataKeys[gvr.RowIndex].Value;
        }

        protected void grGastos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (searchGasto == true)
            {
                grGastos.PageIndex = e.NewPageIndex;
                grGastos.DataSource = listaSearchGasto;
                grGastos.DataBind();
            }
            else
            {
                grGastos.PageIndex = e.NewPageIndex;
                grGastos.DataSource = listagastos;
                grGastos.DataBind();
            }
        }

        protected void btnSearchLuz_Click(object sender, EventArgs e)
        {
            lbErrorLuz.Visible = false;
            lbErrorSearchLuz.Visible = false;
            dplDepartamentoLuz.SelectedIndex = 0;
            listaSearchControlLuz = new List<Adapter.AdapterControlLuzDepartamento>();
            listaSearchControlLuz = Controller.ControllerControlIlimunacionDep.listaSearchControlDep(propietario.ID_PERSONA, txtSearchLuz.Text);
            if (listaSearchControlLuz.Count > 0)
            {
                lbErrorLuz.Visible = false;
                lbErrorSearchLuz.Visible = false;
                grLuces.DataSource = listaSearchControlLuz;
                grLuces.DataBind();
            }
            else
            {
                lbErrorLuz.Visible = false;
                lbErrorSearchLuz.Visible = true;
                listaSearchControlLuz = new List<Adapter.AdapterControlLuzDepartamento>();
                grLuces.DataSource = listaSearchControlLuz;
                grLuces.DataBind();
            }
        }

        protected void btnCrearControl_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProgramarLuzDepartamento.aspx");
        }

        protected void btnApagar_Click(object sender, EventArgs e)
        {
        }

        protected void btnEncender_Click(object sender, EventArgs e)
        {
        }

        protected void dplDepartamentoLuz_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lbErrorLuz.Visible = false;
                lbErrorSearchLuz.Visible = false;
                long departamento = Convert.ToInt64(dplDepartamentoLuz.SelectedValue);
                listaSearchControlLuz = new List<Adapter.AdapterControlLuzDepartamento>();
                listaSearchControlLuz = Controller.ControllerControlIlimunacionDep.listaControlDepartamento(propietario.ID_PERSONA, departamento);
                if (listaSearchControlLuz.Count > 0)
                {
                    lbErrorLuz.Visible = false;
                    lbErrorSearchLuz.Visible = false;
                    grLuces.DataSource = listaSearchControlLuz;
                    grLuces.DataBind();
                }
                else
                {
                    lbErrorLuz.Visible = true;
                    lbErrorSearchLuz.Visible = false;
                    listaSearchControlLuz = new List<Adapter.AdapterControlLuzDepartamento>();
                    grLuces.DataSource = listaSearchControlLuz;
                    grLuces.DataBind();
                }
            }
            catch (Exception ex)
            {
                lbErrorLuz.Visible = false;
                lbErrorSearchLuz.Visible = false;
                grLuces.DataSource = listaControlLuz;
                grLuces.DataBind();
                System.Diagnostics.Debug.WriteLine("Error:  " + ex);
            }
        }

        protected void grLuces_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void grLuces_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (searchControlLuz == true)
            {
                grLuces.PageIndex = e.NewPageIndex;
                grLuces.DataSource = listaSearchControlLuz;
                grLuces.DataBind();
            }
            else
            {
                grLuces.PageIndex = e.NewPageIndex;
                grLuces.DataSource = listaControlLuz;
                grLuces.DataBind();
            }
        }

        protected void dplMulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lbErrorMulta.Visible = false;
                long departamento = Convert.ToInt64(dplMulta.SelectedValue);
                listaSearchMulta = new List<Adapter.AdapterMulta>();
                listaSearchMulta = Controller.ControllerMulta.listaAdapterMultaDepartamento(departamento);
                if (listaSearchMulta.Count > 0)
                {
                    lbErrorMulta.Visible = false;
                    searchMulta = true;
                    grMulta.DataSource = listaSearchMulta;
                    grMulta.DataBind();
                }
                else
                {
                    lbErrorMulta.Visible = true;
                    searchMulta = false;
                    listaSearchMulta = new List<Adapter.AdapterMulta>();
                    grMulta.DataSource = listaSearchMulta;
                    grMulta.DataBind();
                }
            }
            catch (Exception ex)
            {
                lbErrorMulta.Visible = false;
                searchMulta = false;
                grMulta.DataSource = listaMulta;
                grMulta.DataBind();
                System.Diagnostics.Debug.WriteLine("Error:  " + ex);
            }
        }

        protected void btnPagarMulta_Click(object sender, EventArgs e)
        {
            Response.Redirect(".aspx");
        }

        protected void grMulta_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void grMulta_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (searchMulta == true)
            {
                grMulta.PageIndex = e.NewPageIndex;
                grMulta.DataSource = listaSearchMulta;
                grMulta.DataBind();
            }
            else
            {
                grMulta.PageIndex = e.NewPageIndex;
                grMulta.DataSource = listaMulta;
                grMulta.DataBind();
            }
        }

        protected void btnSearchReserva_Click(object sender, EventArgs e)
        {
            lbErrorReserva.Visible = false;
            lbErrorSearchReserva.Visible = false;
            dplCentro.SelectedIndex = 0;
            listaSearchReserva = new List<Adapter.AdapterReserva>();
            listaSearchReserva = Controller.ControllerReservaCentro.searchReservaDepartamento(propietario.ID_PERSONA, txtSearchReserva.Text);
            if (listaSearchReserva.Count > 0)
            {
                lbErrorReserva.Visible = false;
                lbErrorSearchReserva.Visible = false;
                grReserva.DataSource = listaSearchReserva;
                grReserva.DataBind();
            }
            else
            {
                lbErrorReserva.Visible = false;
                lbErrorSearchReserva.Visible = true;
                listaSearchReserva = new List<Adapter.AdapterReserva>();
                grReserva.DataSource = listaSearchReserva;
                grReserva.DataBind();
            }
        }

        protected void btnCrearReserva_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistroReservaPropietario.aspx");
        }

        protected void dplCentro_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lbErrorReserva.Visible = false;
                lbErrorSearchReserva.Visible = false;
                txtSearchReserva.Text = "";
                long tipo = Convert.ToInt64(dplCentro.SelectedValue);
                listaSearchReserva = new List<Adapter.AdapterReserva>();
                listaSearchReserva = Controller.ControllerReservaCentro.listaReservaTipoCentro(propietario.ID_PERSONA, tipo);
                if (listaSearchReserva.Count > 0)
                {
                    lbErrorReserva.Visible = false;
                    lbErrorSearchReserva.Visible = false;
                    searchReserva = true;
                    grReserva.DataSource = listaSearchReserva;
                    grReserva.DataBind();
                }
                else
                {
                    lbErrorReserva.Visible = true;
                    lbErrorSearchReserva.Visible = false;
                    searchReserva = false;
                    listaSearchReserva = new List<Adapter.AdapterReserva>();
                    grReserva.DataSource = listaSearchReserva;
                    grReserva.DataBind();
                }
            }
            catch (Exception ex)
            {
                lbErrorReserva.Visible = false;
                lbErrorSearchReserva.Visible = false;
                searchReserva = false;
                grReserva.DataSource = listaReserva;
                grReserva.DataBind();
                System.Diagnostics.Debug.WriteLine("Error:  " + ex);
            }
        }

        protected void grReserva_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void grReserva_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (searchReserva == true)
            {
                grReserva.PageIndex = e.NewPageIndex;
                grReserva.DataSource = listaSearchReserva;
                grReserva.DataBind();
            }
            else
            {
                grReserva.PageIndex = e.NewPageIndex;
                grReserva.DataSource = listaReserva;
                grReserva.DataBind();
            }
        }
    }
}