using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace EasyLife.Vista
{
    public partial class PerfilAdministrador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validación de Session Iniciada
            /*LOGIN adm = (LOGIN)Session["adm"];
            LOGIN conserje = (LOGIN)Session["conserje"];
            LOGIN vendedor = (LOGIN)Session["vendedor"];
            LOGIN propietario = (LOGIN)Session["login"];
            LOGIN admCondominio = (LOGIN)Session["admCondominio"];
            if (conserje != null || vendedor != null || propietario != null || admCondominio != null)
            {
                Response.Redirect("Index.aspx");
            }
            else if (adm == null && conserje == null && vendedor == null && propietario == null && admCondominio == null)
            {
                Response.Redirect("Index.aspx");
            }

            if (!IsPostBack)
            {
                cargarDatos(adm.ID_PERSONA);
                cargarCondominio();
                cargarRol();
                cargarPersonal();
                cargarPropietarios();
                cargarGastoComun();
                cargarCentro();
            }*/

            long adm = 1;
            if (!IsPostBack)
            {
                cargarDatos(adm);
                cargarCondominio();
                cargarRol();
                cargarPersonal();
                cargarPropietarios();
                cargarGastoComun();
                cargarCentro();
            }
        }

        private static List<Adapter.AdapterCondominio> listaCondominio = new List<Adapter.AdapterCondominio>();
        private static List<Adapter.AdapterCondominio> listaSearchCondominio = new List<Adapter.AdapterCondominio>();
        private static Boolean searchCondominio = false;
        private static List<Adapter.AdapterEdificio> listaEdificio = new List<Adapter.AdapterEdificio>();
        private static List<DEPARTAMENTO> listaDepartamento = new List<DEPARTAMENTO>();
        private static List<MULTA> listaMulta = new List<MULTA>();
        private static List<Adapter.AdapterPersonal> listaPersonal = new List<Adapter.AdapterPersonal>();
        private static List<Adapter.AdapterPersonal> listaSearchPersonal = new List<Adapter.AdapterPersonal>();
        private static Boolean searchPersonal = false;
        private static Adapter.AdapterPersonal adapterPersonal = new Adapter.AdapterPersonal();
        private static List<TURNO> listaTurno = new List<TURNO>();
        private static List<Adapter.AdapterPropietario> listaPropietario = new List<Adapter.AdapterPropietario>();
        private static List<Adapter.AdapterPropietario> listaSearchPropietario = new List<Adapter.AdapterPropietario>();
        private static Boolean searchPropietario = false;
        private static Adapter.AdapterPropietario adapterPropietario = new Adapter.AdapterPropietario();
        private static List<Adapter.AdapterGastoComun> listaGasto = new List<Adapter.AdapterGastoComun>();
        private static List<Adapter.AdapterGastoComun> listaSearchGasto = new List<Adapter.AdapterGastoComun>();
        private static Boolean searchGasto = false;
        private static List<Adapter.AdapterCentro> listaCentro = new List<Adapter.AdapterCentro>();
        private static List<Adapter.AdapterCentro> listaSearchCentro = new List<Adapter.AdapterCentro>();
        private static List<HORARIO_CENTRO> listaHorario = new List<HORARIO_CENTRO>();
        private static Boolean searchCentro = false;

        public void cargarDatos(long persona)
        {
            PERSONA aux = Controller.ControllerPersona.buscarIdPersona(persona);
            lbUser.Text = aux.NOMBRE_PERSONA;
            lbRut.Text = aux.FK_RUT;
            lbNombre.Text = aux.NOMBRE_PERSONA;
            lbApellido.Text = aux.APELLIDO_PERSONA;
            lbTelefono.Text = aux.TELEFONO_PERSONA;
            lbCorreo.Text = aux.CORREO_PERSONA;
        }

        public void cargarCondominio()
        {
            listaCondominio = new List<Adapter.AdapterCondominio>();
            listaCondominio = Controller.ControllerCondominio.listaAdapterCondominio();
            grCondominio.DataSource = listaCondominio;
            grCondominio.DataBind();

            List<CONDOMINIO> lista = Controller.ControllerCondominio.listaCondominio();
            dplCondominioGasto.DataSource = lista;
            dplCondominioGasto.DataValueField = "ID_CONDOMINIO";
            dplCondominioGasto.DataTextField = "NOMBRE_CONDOMINIO";
            dplCondominioGasto.DataBind();
            dplCondominioGasto.Items.Insert(0, "Seleccione un Condominio");
            dplCondominioGasto.SelectedIndex = 0;

            dplCondominioCentro.DataSource = lista;
            dplCondominioCentro.DataValueField = "ID_CONDOMINIO";
            dplCondominioCentro.DataTextField = "NOMBRE_CONDOMINIO";
            dplCondominioCentro.DataBind();
            dplCondominioCentro.Items.Insert(0, "Seleccione un Condominio");
            dplCondominioCentro.SelectedIndex = 0;
        }

        public void cargarPersonal()
        {
            listaPersonal = new List<Adapter.AdapterPersonal>();
            listaPersonal = Controller.ControllerPersona.listaPersonal();
            grPersonal.DataSource = listaPersonal;
            grPersonal.DataBind();
        }

        public void cargarRol()
        {
            List<ROL> listaRoles = Controller.ControllerRol.listaRol();
            dplPersonal.DataSource = listaRoles;
            dplPersonal.DataValueField = "ID_ROL";
            dplPersonal.DataTextField = "DESCRIPCION_ROL";
            dplPersonal.DataBind();
            dplPersonal.Items.Insert(0, "Seleccione un Rol");
            dplPersonal.SelectedIndex = 0;
            dplPersonal.Items.RemoveAt(4);
        }

        public void cargarPropietarios()
        {
            listaPropietario = new List<Adapter.AdapterPropietario>();
            listaPropietario = Controller.ControllerPersona.listaPropietarios();
            grPropietarios.DataSource = listaPropietario;
            grPropietarios.DataBind();
        }

        public void cargarGastoComun()
        {
            listaGasto = new List<Adapter.AdapterGastoComun>();
            listaGasto = Controller.ControllerGastoComun.listaGastos();
            grGastos.DataSource = listaGasto;
            grGastos.DataBind();
        }

        public void cargarCentro()
        {
            listaCentro = new List<Adapter.AdapterCentro>();
            listaCentro = Controller.ControllerCentro.listaAdapterCentro();
            grCentros.DataSource = listaCentro;
            grCentros.DataBind();
        }

        protected void btnDatosUsuario_Click(object sender, EventArgs e)
        {
            panelDatos.Visible = true;
            panelCondominios.Visible = false;
            panelPersonal.Visible = false;
            panelPropietario.Visible = false;
            panelGastos.Visible = false;
            panelCentro.Visible = false;
            panelMensajes.Visible = false;
            panelAvisos.Visible = false;

            btnDatosUsuario.BackColor = Color.LightBlue;
            btnCondominio.BackColor = Color.White;
            btnPersonal.BackColor = Color.White;
            btnPropietarios.BackColor = Color.White;
            btnGastos.BackColor = Color.White;
            btnCentros.BackColor = Color.White;
            btnMensajes.BackColor = Color.White;
            btnAvisos.BackColor = Color.White;

            limpiarVariable();
        }

        protected void btnCondominio_Click(object sender, EventArgs e)
        {
            panelDatos.Visible = false;
            panelCondominios.Visible = true;
            panelPersonal.Visible = false;
            panelPropietario.Visible = false;
            panelGastos.Visible = false;
            panelCentro.Visible = false;
            panelMensajes.Visible = false;
            panelAvisos.Visible = false;

            btnDatosUsuario.BackColor = Color.White;
            btnCondominio.BackColor = Color.LightBlue;
            btnPersonal.BackColor = Color.White;
            btnPropietarios.BackColor = Color.White;
            btnGastos.BackColor = Color.White;
            btnCentros.BackColor = Color.White;
            btnMensajes.BackColor = Color.White;
            btnAvisos.BackColor = Color.White;

            limpiarVariable();
        }

        protected void btnPersonal_Click(object sender, EventArgs e)
        {
            panelDatos.Visible = false;
            panelCondominios.Visible = false;
            panelPersonal.Visible = true;
            panelPropietario.Visible = false;
            panelGastos.Visible = false;
            panelCentro.Visible = false;
            panelMensajes.Visible = false;
            panelAvisos.Visible = false;

            btnDatosUsuario.BackColor = Color.White;
            btnCondominio.BackColor = Color.White;
            btnPersonal.BackColor = Color.LightBlue;
            btnPropietarios.BackColor = Color.White;
            btnGastos.BackColor = Color.White;
            btnCentros.BackColor = Color.White;
            btnMensajes.BackColor = Color.White;
            btnAvisos.BackColor = Color.White;

            limpiarVariable();
        }

        protected void btnPropietarios_Click(object sender, EventArgs e)
        {
            panelDatos.Visible = false;
            panelCondominios.Visible = false;
            panelPersonal.Visible = false;
            panelPropietario.Visible = true;
            panelGastos.Visible = false;
            panelCentro.Visible = false;
            panelMensajes.Visible = false;
            panelAvisos.Visible = false;

            btnDatosUsuario.BackColor = Color.White;
            btnCondominio.BackColor = Color.White;
            btnPersonal.BackColor = Color.White;
            btnPropietarios.BackColor = Color.LightBlue;
            btnGastos.BackColor = Color.White;
            btnCentros.BackColor = Color.White;
            btnMensajes.BackColor = Color.White;
            btnAvisos.BackColor = Color.White;

            limpiarVariable();
        }

        protected void btnGastos_Click(object sender, EventArgs e)
        {
            panelDatos.Visible = false;
            panelCondominios.Visible = false;
            panelPersonal.Visible = false;
            panelPropietario.Visible = false;
            panelGastos.Visible = true;
            panelCentro.Visible = false;
            panelMensajes.Visible = false;
            panelAvisos.Visible = false;

            btnDatosUsuario.BackColor = Color.White;
            btnCondominio.BackColor = Color.White;
            btnPersonal.BackColor = Color.White;
            btnPropietarios.BackColor = Color.White;
            btnGastos.BackColor = Color.LightBlue;
            btnCentros.BackColor = Color.White;
            btnMensajes.BackColor = Color.White;
            btnAvisos.BackColor = Color.White;

            limpiarVariable();
        }

        protected void btnCentros_Click(object sender, EventArgs e)
        {
            panelDatos.Visible = false;
            panelCondominios.Visible = false;
            panelPersonal.Visible = false;
            panelPropietario.Visible = false;
            panelGastos.Visible = false;
            panelCentro.Visible = true;
            panelMensajes.Visible = false;
            panelAvisos.Visible = false;

            btnDatosUsuario.BackColor = Color.White;
            btnCondominio.BackColor = Color.White;
            btnPersonal.BackColor = Color.White;
            btnPropietarios.BackColor = Color.White;
            btnGastos.BackColor = Color.White;
            btnCentros.BackColor = Color.LightBlue;
            btnMensajes.BackColor = Color.White;
            btnAvisos.BackColor = Color.White;

            limpiarVariable();
        }

        protected void btnMensajes_Click(object sender, EventArgs e)
        {
            panelDatos.Visible = false;
            panelCondominios.Visible = false;
            panelPersonal.Visible = false;
            panelPropietario.Visible = false;
            panelGastos.Visible = false;
            panelCentro.Visible = false;
            panelMensajes.Visible = true;
            panelAvisos.Visible = false;

            btnDatosUsuario.BackColor = Color.White;
            btnCondominio.BackColor = Color.White;
            btnPersonal.BackColor = Color.White;
            btnPropietarios.BackColor = Color.White;
            btnGastos.BackColor = Color.White;
            btnCentros.BackColor = Color.White;
            btnMensajes.BackColor = Color.LightBlue;
            btnAvisos.BackColor = Color.White;

            limpiarVariable();
        }

        protected void btnAvisos_Click(object sender, EventArgs e)
        {
            panelDatos.Visible = false;
            panelCondominios.Visible = false;
            panelPersonal.Visible = false;
            panelPropietario.Visible = false;
            panelGastos.Visible = false;
            panelCentro.Visible = false;
            panelMensajes.Visible = false;
            panelAvisos.Visible = true;

            btnDatosUsuario.BackColor = Color.White;
            btnCondominio.BackColor = Color.White;
            btnPersonal.BackColor = Color.White;
            btnPropietarios.BackColor = Color.White;
            btnGastos.BackColor = Color.White;
            btnCentros.BackColor = Color.White;
            btnMensajes.BackColor = Color.White;
            btnAvisos.BackColor = Color.LightBlue;

            limpiarVariable();
        }

        public void limpiarVariable()
        {
            //Variables Condominio
            listaSearchCondominio = new List<Adapter.AdapterCondominio>();
            listaEdificio = new List<Adapter.AdapterEdificio>();
            listaDepartamento = new List<DEPARTAMENTO>();
            listaMulta = new List<MULTA>();
            grCondominio.Visible = true;
            grCondominio.DataSource = listaCondominio;
            grCondominio.DataBind();
            searchCondominio = false;
            grEdificio.DataSource = listaEdificio;
            grEdificio.DataBind();
            grDepartamento.DataSource = listaDepartamento;
            grDepartamento.DataBind();
            grMulta.DataSource = listaMulta;
            grMulta.DataBind();
            panelEdificio.Visible = false;
            panelDep.Visible = false;
            panelDetalleDep.Visible = false;
            lbErrorSearchCondominio.Visible = false;
            lbError.Visible = false;
            lbErrorMulta.Visible = false;
            txtSearchCondominio.Text = "";

            //Variables Personal
            listaSearchPersonal = new List<Adapter.AdapterPersonal>();
            listaTurno = new List<TURNO>();
            adapterPersonal = new Adapter.AdapterPersonal();
            searchPersonal = false;
            grPersonal.Visible = true;
            grPersonal.DataSource = listaPersonal;
            grPersonal.DataBind();
            grTurno.DataSource = listaTurno;
            grTurno.DataBind();
            lbErrorSearchPersonal.Visible = false;
            panelDetallePersonal.Visible = false;
            panelConserje.Visible = false;
            lbConserje.Visible = false;
            grTurno.Visible = false;
            dplPersonal.SelectedIndex = 0;
            btnModificarPersonal.Enabled = false;
            btnEliminarPersonal.Enabled = false;
            txtSearchPersonal.Text = "";
            Session["ModificarPersonal"] = null;
            Session["ModificarTurno"] = null;

            //Variables Propietario
            listaSearchPropietario = new List<Adapter.AdapterPropietario>();
            adapterPropietario = new Adapter.AdapterPropietario();
            grPropietarios.Visible = true;
            grPropietarios.DataSource = listaPropietario;
            grPropietarios.DataBind();
            searchPropietario = false;
            lbErrorSearchPropietario.Visible = false;
            panelDetalle.Visible = false;
            btnModificarPropietario.Enabled = false;
            btnEliminarPropietario.Enabled = false;
            btnAsignarMulta.Enabled = false;
            txtSearchPropietario.Text = "";
            lbDEdificio.Text = "";
            lbDCondominio.Text = "";
            lbDLuz.Text = "";
            Session["ModificarPropietario"] = null;
            Session["AsignarLuzDepartamento"] = null;
            Session["AsignarMultaDepartamento"] = null;

            //Variables Gasto Comun
            listaSearchGasto = new List<Adapter.AdapterGastoComun>();
            grGastos.DataSource = listaGasto;
            grGastos.DataBind();
            searchGasto = false;
            lbErrorSearchGasto.Visible = false;
            dplCondominioGasto.SelectedIndex = 0;
            txtSearchGasto.Text = "";
            Session["ModificarGasto"] = null;

            //Variables Centro
            listaSearchCentro = new List<Adapter.AdapterCentro>();
            listaHorario = new List<HORARIO_CENTRO>();
            grCentros.DataSource = listaCentro;
            grCentros.DataBind();
            grHorario.DataSource = listaHorario;
            grHorario.DataBind();
            searchCentro = false;
            txtSearchCentro.Text = "";
            lbErrorCentro.Visible = false;
            lbErrorSearchCentro.Visible = false;
            lbErrorHorario.Visible = false;
            dplCondominioCentro.SelectedIndex = 0;
            panelHorario.Visible = false;
            btnModificarCentro.Enabled = false;
            btnModificarHorario.Enabled = false;
            Session["ModificarCentro"] = null;
            Session["ModificarHorario"] = null;
        }

        protected void lnkModificarDatos_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModificarDatos.aspx");
        }

        protected void lnkModificarPassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("CambiarPassword.aspx");
        }

        protected void btnSearchCondominio_Click(object sender, EventArgs e)
        {
            listaSearchCondominio = new List<Adapter.AdapterCondominio>();
            listaSearchCondominio = Controller.ControllerCondominio.searchAdaprterCondominio(txtSearchCondominio.Text);
            if (listaSearchCondominio.Count > 0)
            {
                lbErrorSearchCondominio.Visible = false;
                grCondominio.DataSource = listaSearchCondominio;
                grCondominio.DataBind();
                searchCondominio = true;
            }
            else
            {
                listaSearchCondominio = new List<Adapter.AdapterCondominio>();
                lbErrorSearchCondominio.Visible = true;
                grCondominio.DataSource = listaSearchCondominio;
                grCondominio.DataBind();
                searchCondominio = false;
            }
        }

        protected void btnCrearCondominio_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistroCondominio.aspx");
        }

        protected void grCondominio_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelDep.Visible = false;
            panelDetalleDep.Visible = false;
            lbError.Visible = false;
            lbErrorMulta.Visible = false;
            lbErrorSearchCondominio.Visible = false;
            GridViewRow gvr = grCondominio.SelectedRow;
            long condominio = (long)grCondominio.DataKeys[gvr.RowIndex].Value;
            panelEdificio.Visible = true;

            listaEdificio = new List<Adapter.AdapterEdificio>();
            listaEdificio = Controller.ControllerEdificio.listaAdapterEdificio(condominio);
            grEdificio.DataSource = listaEdificio;
            grEdificio.DataBind();
        }

        protected void grCondominio_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (searchCondominio == true)
            {
                panelEdificio.Visible = false;
                panelDep.Visible = false;
                panelDetalleDep.Visible = false;
                lbErrorSearchCondominio.Visible = false;
                lbError.Visible = false;
                lbErrorMulta.Visible = false;
                grCondominio.PageIndex = e.NewPageIndex;
                grCondominio.DataSource = listaSearchCondominio;
                grCondominio.DataBind();
            }
            else
            {
                panelEdificio.Visible = false;
                panelDep.Visible = false;
                panelDetalleDep.Visible = false;
                lbErrorSearchCondominio.Visible = false;
                lbError.Visible = false;
                lbErrorMulta.Visible = false;
                grCondominio.PageIndex = e.NewPageIndex;
                grCondominio.DataSource = listaCondominio;
                grCondominio.DataBind();
            }
        }

        protected void grEdificio_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelDetalleDep.Visible = false;
            lbError.Visible = false;
            GridViewRow gvr = grEdificio.SelectedRow;
            long edificio = (long)grEdificio.DataKeys[gvr.RowIndex].Value;
            panelDep.Visible = true;
            listaDepartamento = new List<DEPARTAMENTO>();
            listaDepartamento = Controller.ControllerDepartamento.listaDepartamento(edificio);
            grDepartamento.DataSource = listaDepartamento;
            grDepartamento.DataBind();
        }

        protected void grEdificio_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            panelDep.Visible = false;
            panelDetalleDep.Visible = false;
            lbErrorSearchCondominio.Visible = false;
            lbError.Visible = false;
            lbErrorMulta.Visible = false;
            grEdificio.PageIndex = e.NewPageIndex;
            grEdificio.DataSource = listaEdificio;
            grEdificio.DataBind();
        }

        protected void grDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                listaMulta = new List<MULTA>();
                GridViewRow gvr = grDepartamento.SelectedRow;
                long departamento = (long)grDepartamento.DataKeys[gvr.RowIndex].Value;

                lbError.Visible = false;
                lbErrorMulta.Visible = false;
                DEPARTAMENTO dep = Controller.ControllerDepartamento.buscarIdDepartamento(departamento);
                PERSONA persona = Controller.ControllerPersona.buscarIdPersona(Convert.ToInt64(dep.ID_PERSONA));
                listaMulta = Controller.ControllerMulta.listaMultaDepartamento(dep.ID_DEPARTAMENTO);
                if (listaMulta.Count > 0)
                {
                    lbErrorMulta.Visible = false;
                    grMulta.DataSource = listaMulta;
                    grMulta.DataBind();
                }
                else
                {
                    lbErrorMulta.Visible = true;
                    lbErrorMulta.Text = "Departamento no Posee Multas";
                    listaMulta = new List<MULTA>();
                    grMulta.DataSource = listaMulta;
                    grMulta.DataBind();
                }

                if (dep.ID_LUZ_D != null)
                {
                    LUZ_DEPARTAMENTO luz = Controller.ControllerLuzDepartamento.buscarIdLuzDepartamento(Convert.ToInt64(dep.ID_LUZ_D));
                    panelDetalleDep.Visible = true;
                    lbDepRut.Text = persona.FK_RUT;
                    lbDepNombre.Text = persona.NOMBRE_PERSONA + " " + persona.APELLIDO_PERSONA;
                    lbDepTelefono.Text = persona.TELEFONO_PERSONA;
                    lbDepCorreo.Text = persona.CORREO_PERSONA;
                    lbDepLuz.Text = luz.CODIGO_LUZ_D;
                }
                else
                {
                    panelDetalleDep.Visible = true;
                    lbDepRut.Text = persona.FK_RUT;
                    lbDepNombre.Text = persona.NOMBRE_PERSONA + " " + persona.APELLIDO_PERSONA;
                    lbDepTelefono.Text = persona.TELEFONO_PERSONA;
                    lbDepCorreo.Text = persona.CORREO_PERSONA;
                    lbDepLuz.Text = "No Asignada";
                }
            }
            catch (Exception ex)
            {
                lbError.Visible = true;
                panelDetalleDep.Visible = false;
                lbError.Text = "Departamento Sin Propietario";
                System.Diagnostics.Debug.WriteLine("Error " + ex);
            }
        }

        protected void grDepartamento_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            panelDetalleDep.Visible = false;
            lbErrorSearchCondominio.Visible = false;
            lbError.Visible = false;
            lbErrorMulta.Visible = false;
            grDepartamento.PageIndex = e.NewPageIndex;
            grDepartamento.DataSource = listaDepartamento;
            grDepartamento.DataBind();
        }

        protected void grMulta_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            lbErrorSearchCondominio.Visible = false;
            lbError.Visible = false;
            lbErrorMulta.Visible = false;
            grMulta.PageIndex = e.NewPageIndex;
            grMulta.DataSource = listaMulta;
            grMulta.DataBind();
        }

        protected void btnSearchPersonal_Click(object sender, EventArgs e)
        {
            listaSearchPersonal = new List<Adapter.AdapterPersonal>();
            dplPersonal.SelectedIndex = 0;
            listaSearchPersonal = Controller.ControllerPersona.searchPersonal(txtSearchPersonal.Text);
            if (listaSearchPersonal.Count > 0)
            {
                lbErrorSearchPersonal.Visible = false;
                dplPersonal.SelectedIndex = 0;
                grPersonal.DataSource = listaSearchPersonal;
                grPersonal.DataBind();
                searchPersonal = true;
            }
            else
            {
                lbErrorSearchPersonal.Visible = true;
                dplPersonal.SelectedIndex = 0;
                listaSearchPersonal = new List<Adapter.AdapterPersonal>();
                grPersonal.DataSource = listaSearchPersonal;
                grPersonal.DataBind();
                searchPersonal = false;
            }
        }

        protected void btnRegistroPersonal_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistroPersonal.aspx");
        }

        protected void btnModificarPersonal_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistroPersonal.aspx");
        }

        protected void btnEliminarPersonal_Click(object sender, EventArgs e)
        {
        }

        protected void dplPersonal_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                long rol = Convert.ToInt64(dplPersonal.SelectedValue);
                lbErrorSearchPersonal.Visible = false;
                listaSearchPersonal = new List<Adapter.AdapterPersonal>();
                listaSearchPersonal = Controller.ControllerPersona.listaAdapterPersonalRol(rol);
                grPersonal.DataSource = listaSearchPersonal;
                grPersonal.DataBind();
            }
            catch (Exception ex)
            {
                lbErrorSearchPersonal.Visible = false;
                grPersonal.DataSource = listaPersonal;
                grPersonal.DataBind();
                searchPersonal = false;
                System.Diagnostics.Debug.WriteLine("Error: " + ex);
            }
        }

        protected void grPersonal_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelDetallePersonal.Visible = true;
            panelConserje.Visible = false;
            lbConserje.Visible = false;
            grTurno.Visible = false;
            adapterPersonal = new Adapter.AdapterPersonal();
            btnModificarPersonal.Enabled = true;
            btnEliminarPersonal.Enabled = true;
            GridViewRow gvr = grPersonal.SelectedRow;
            long personal = (long)grPersonal.DataKeys[gvr.RowIndex].Value;
            string modificar = personal.ToString();
            Session["ModificarPersonal"] = modificar;
            Session["ModificarTurno"] = modificar;
            btnEliminarPersonal.Enabled = true;
            btnModificarPersonal.Enabled = true;

            Adapter.AdapterPersonal aux = new Adapter.AdapterPersonal();
            aux = Controller.ControllerPersona.buscarPersonalId(personal);
            lbPId.Text = aux._ID_PERSONA.ToString();
            lbPRol.Text = aux._DESCRIPCION_ROL;
            lbPRut.Text = aux._FK_RUT;
            lbPNombre.Text = aux._NOMBRE_PERSONA + " " + aux._APELLIDO_PERSONA;
            lbPTelefono.Text = aux._TELEFONO_PERSONA;
            lbPCorreo.Text = aux._CORREO_PERSONA;
            if (aux._ESTADO_PERSONA == true)
            {
                lbPEstado.Text = "Activo";
            }
            else
            {
                lbPEstado.Text = "Inactivo";
            }

            if (aux._DESCRIPCION_ROL.Equals("Conserje"))
            {
                panelConserje.Visible = true;
                lbConserje.Visible = true;
                grTurno.Visible = true;
                CONSERJE conserje = Controller.ControllerConserje.buscarIdConserje(personal);
                listaTurno = new List<TURNO>();
                listaTurno = Controller.ControllerTurno.listaTurno(conserje.ID_CONSERJE);
                grTurno.DataSource = listaTurno;
                grTurno.DataBind();
            }
            adapterPersonal = aux;
        }

        protected void grPersonal_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (searchPersonal == true)
            {
                panelConserje.Visible = false;
                lbConserje.Visible = false;
                grTurno.Visible = false;
                grPersonal.PageIndex = e.NewPageIndex;
                grPersonal.DataSource = listaSearchPersonal;
                grPersonal.DataBind();
            }
            else
            {
                panelConserje.Visible = false;
                lbConserje.Visible = false;
                grTurno.Visible = false;
                grPersonal.PageIndex = e.NewPageIndex;
                grPersonal.DataSource = listaPersonal;
                grPersonal.DataBind();
            }
        }

        protected void btnHabilitarPersonal_Click(object sender, EventArgs e)
        {
        }

        protected void btnDeshabilitarPersonal_Click(object sender, EventArgs e)
        {
        }

        protected void grTurno_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grTurno.PageIndex = e.NewPageIndex;
            grTurno.DataSource = listaTurno;
            grTurno.DataBind();
        }

        protected void btnSearchPropietario_Click(object sender, EventArgs e)
        {
            listaSearchPropietario = new List<Adapter.AdapterPropietario>();
            listaSearchPropietario = Controller.ControllerPersona.searchListaPropietario(txtSearchPropietario.Text);
            if (listaSearchPropietario.Count > 0)
            {
                lbErrorSearchPropietario.Visible = false;
                grPropietarios.DataSource = listaSearchPropietario;
                grPropietarios.DataBind();
                searchPropietario = true;
            }
            else
            {
                lbErrorSearchPropietario.Visible = true;
                listaSearchPropietario = new List<Adapter.AdapterPropietario>();
                grPropietarios.DataSource = listaSearchPropietario;
                grPropietarios.DataBind();
                searchPropietario = false;
            }
        }

        protected void btnRegistroPropietario_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistroPropietario.aspx");
        }

        protected void btnModificarPropietario_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistroPropietario.aspx");
        }

        protected void btnEliminarPropietario_Click(object sender, EventArgs e)
        {
        }

        protected void btnAsignarMulta_Click(object sender, EventArgs e)
        {
            Response.Redirect("AsignarMulta.aspx");
        }

        protected void grPropietarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            Adapter.AdapterPropietario prop = new Adapter.AdapterPropietario();
            if (searchPropietario == true)
            {
                panelDetalle.Visible = true;
                adapterPropietario = new Adapter.AdapterPropietario();
                GridViewRow gvr = grPropietarios.SelectedRow;
                long propietario = (long)grPropietarios.DataKeys[gvr.RowIndex].Value;
                long position = grPropietarios.SelectedIndex;
                prop = listaSearchPropietario[Convert.ToInt32(position)];
                lbDId.Text = prop._ID_EDIFICIO.ToString();
                lbDRut.Text = prop._FK_RUT;
                lbDNombre.Text = prop._NOMBRE_PERSONA + " " + prop._APELLIDO_PERSONA;
                lbDTelefono.Text = prop._TELEFONO_PERSONA;
                lbDCorreo.Text = prop._CORREO_PERSONA;
                lbDCondominio.Text = prop._NOMBRE_CONDOMINIO;
                lbDEdificio.Text = prop._NOMBRE_EDIFICIO;
                lbDep.Text = prop._NUMERO_DEP;

                if (prop._ESTADO_PERSONA == true)
                {
                    lbDEstado.Text = "Activo";
                }
                else
                {
                    lbDEstado.Text = "Inactivo";
                }
                DEPARTAMENTO departamento = Controller.ControllerDepartamento.buscarIdDepartamento(prop._ID_DEPARTAMENTO);
                if (departamento.ID_LUZ_D != null)
                {
                    LUZ_DEPARTAMENTO luz = Controller.ControllerLuzDepartamento.buscarLuzDepartamento(prop._ID_DEPARTAMENTO);
                    lbDLuz.Text = luz.CODIGO_LUZ_D;
                }
                else
                {
                    lbDLuz.Text = "No Asignada";
                }
                Session["ModificarPropietario"] = propietario.ToString();
            }
            else
            {
                panelDetalle.Visible = true;
                adapterPropietario = new Adapter.AdapterPropietario();
                GridViewRow gvr = grPropietarios.SelectedRow;
                long propietario = (long)grPropietarios.DataKeys[gvr.RowIndex].Value;
                long position = grPropietarios.SelectedIndex;
                prop = listaPropietario[Convert.ToInt32(position)];
                lbDId.Text = prop._ID_EDIFICIO.ToString();
                lbDRut.Text = prop._FK_RUT;
                lbDNombre.Text = prop._NOMBRE_PERSONA + " " + prop._APELLIDO_PERSONA;
                lbDTelefono.Text = prop._TELEFONO_PERSONA;
                lbDCorreo.Text = prop._CORREO_PERSONA;
                lbDCondominio.Text = prop._NOMBRE_CONDOMINIO;
                lbDEdificio.Text = prop._NOMBRE_EDIFICIO;
                lbDep.Text = prop._NUMERO_DEP;

                if (prop._ESTADO_PERSONA == true)
                {
                    lbDEstado.Text = "Activo";
                }
                else
                {
                    lbDEstado.Text = "Inactivo";
                }
                DEPARTAMENTO departamento = Controller.ControllerDepartamento.buscarIdDepartamento(prop._ID_DEPARTAMENTO);
                if (departamento.ID_LUZ_D != null)
                {
                    LUZ_DEPARTAMENTO luz = Controller.ControllerLuzDepartamento.buscarLuzDepartamento(prop._ID_DEPARTAMENTO);
                    lbDLuz.Text = luz.CODIGO_LUZ_D;
                }
                else
                {
                    lbDLuz.Text = "No Asignada";
                }
                Session["ModificarPropietario"] = propietario.ToString();
            }

            btnModificarPropietario.Enabled = true;
            btnEliminarPropietario.Enabled = true;
            btnAsignarMulta.Enabled = true;
            adapterPropietario = prop;
            Session["ModificarPropietario"] = prop._ID_PERSONA.ToString();
            Session["AsignarLuzDepartamento"] = prop._ID_PERSONA.ToString();
            Session["AsignarMultaDepartamento"] = prop._ID_PERSONA.ToString();
        }

        protected void grPropietarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (searchPropietario == true)
            {
                grPropietarios.PageIndex = e.NewPageIndex;
                grPropietarios.DataSource = listaSearchPropietario;
                grPropietarios.DataBind();
            }
            else
            {
                grPropietarios.PageIndex = e.NewPageIndex;
                grPropietarios.DataSource = listaPropietario;
                grPropietarios.DataBind();
            }
        }

        protected void btnSearchGasto_Click(object sender, EventArgs e)
        {
            listaSearchGasto = new List<Adapter.AdapterGastoComun>();
            dplCondominioGasto.SelectedIndex = 0;
            listaSearchGasto = Controller.ControllerGastoComun.searchGastoComun(txtSearchGasto.Text);
            if (listaSearchGasto.Count > 0)
            {
                lbErrorSearchGasto.Visible = false;
                dplCondominioGasto.SelectedIndex = 0;
                grGastos.DataSource = listaSearchGasto;
                grGastos.DataBind();
                searchGasto = true;
            }
            else
            {
                lbErrorSearchGasto.Visible = true;
                listaSearchGasto = new List<Adapter.AdapterGastoComun>();
                dplCondominioGasto.SelectedIndex = 0;
                grGastos.DataSource = listaSearchGasto;
                grGastos.DataBind();
                searchGasto = false;
            }
        }

        protected void dplCondominioGasto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtSearchGasto.Text = "";
                long condominio = Convert.ToInt64(dplCondominioGasto.SelectedValue);
                listaSearchGasto = new List<Adapter.AdapterGastoComun>();
                listaSearchGasto = Controller.ControllerGastoComun.listaGastoCondominio(condominio);
                grGastos.DataSource = listaSearchGasto;
                grGastos.DataBind();
                searchGasto = true;
            }
            catch (Exception ex)
            {
                txtSearchGasto.Text = "";
                grGastos.DataSource = listaGasto;
                grGastos.DataBind();
                searchGasto = false;
                listaSearchGasto = new List<Adapter.AdapterGastoComun>();
                System.Diagnostics.Debug.WriteLine("Error: " + ex);
            }
        }

        protected void grGastos_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gvr = grGastos.SelectedRow;
            long gasto = (long)grGastos.DataKeys[gvr.RowIndex].Value;
            string modificar = gasto.ToString();
            Session["ModificarGasto"] = modificar;
            Response.Redirect("RegistroGasto.aspx");
        }

        protected void grGastos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (searchGasto == true)
            {
                lbErrorSearchGasto.Visible = false;
                grGastos.PageIndex = e.NewPageIndex;
                grGastos.DataSource = listaSearchGasto;
                grGastos.DataBind();
            }
            else
            {
                lbErrorSearchGasto.Visible = false;
                grGastos.PageIndex = e.NewPageIndex;
                grGastos.DataSource = listaGasto;
                grGastos.DataBind();
            }
        }

        protected void btnSearchCentro_Click(object sender, EventArgs e)
        {
            listaSearchCentro = new List<Adapter.AdapterCentro>();
            dplCondominioCentro.SelectedIndex = 0;
            listaSearchCentro = Controller.ControllerCentro.searchCentro(txtSearchCentro.Text);
            if (listaSearchCentro.Count > 0)
            {
                lbErrorSearchCentro.Visible = false;
                dplCondominioCentro.SelectedIndex = 0;
                grCentros.DataSource = listaSearchCentro;
                grCentros.DataBind();
                searchCentro = true;
            }
            else
            {
                lbErrorSearchCentro.Visible = true;
                dplCondominioCentro.SelectedIndex = 0;
                listaSearchCentro = new List<Adapter.AdapterCentro>();
                grCentros.DataSource = listaSearchCentro;
                grCentros.DataBind();
                searchCentro = false;
            }
        }

        protected void btnCrearCentro_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistroCentro.aspx");
        }

        protected void btnModificarCentro_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistroCentro.aspx");
        }

        protected void btnModificarHorario_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistroHorario.aspx");
        }

        protected void dplCondominioCentro_SelectedIndexChanged1(object sender, EventArgs e)
        {
            try
            {
                txtSearchCentro.Text = "";
                long condominio = Convert.ToInt64(dplCondominioCentro.SelectedValue);
                listaSearchCentro = new List<Adapter.AdapterCentro>();
                lbErrorCentro.Visible = false;
                listaSearchCentro = Controller.ControllerCentro.searchCentroCondominio(condominio);
                if (listaSearchCentro.Count > 0)
                {
                    lbErrorCentro.Visible = false;
                    grCentros.DataSource = listaSearchCentro;
                    grCentros.DataBind();
                    searchCentro = true;
                }
                else
                {
                    lbErrorCentro.Visible = true;
                    listaSearchCentro = new List<Adapter.AdapterCentro>();
                    grCentros.DataSource = listaSearchCentro;
                    grCentros.DataBind();
                    searchCentro = false;
                }
            }
            catch (Exception ex)
            {
                txtSearchCentro.Text = "";
                lbErrorCentro.Visible = false;
                lbErrorSearchCentro.Visible = false;
                listaSearchCentro = new List<Adapter.AdapterCentro>();
                grCentros.DataSource = listaCentro;
                grCentros.DataBind();
                searchCentro = false;
                System.Diagnostics.Debug.WriteLine("Error: " + ex);
            }
        }

        protected void grCentros_SelectedIndexChanged1(object sender, EventArgs e)
        {
            GridViewRow gvr = grCentros.SelectedRow;
            btnModificarCentro.Enabled = true;
            btnModificarHorario.Enabled = true;
            long centro = (long)grCentros.DataKeys[gvr.RowIndex].Value;
            Session["ModificarCentro"] = centro.ToString();
            Session["ModificarHorario"] = centro.ToString();
            listaHorario = new List<HORARIO_CENTRO>();
            listaHorario = Controller.ControllerHorarioCentro.listadoHorario(centro);
            if (listaHorario.Count > 0)
            {
                panelHorario.Visible = true;
                lbErrorHorario.Visible = false;
                grHorario.DataSource = listaHorario;
                grHorario.DataBind();
            }
            else
            {
                panelHorario.Visible = true;
                lbErrorHorario.Visible = true;
                listaHorario = new List<HORARIO_CENTRO>();
                grHorario.DataSource = listaHorario;
                grHorario.DataBind();
            }
        }

        protected void grCentros_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            if (searchCentro == true)
            {
                grCentros.PageIndex = e.NewPageIndex;
                grCentros.DataSource = listaSearchCentro;
                grCentros.DataBind();
            }
            else
            {
                grCentros.PageIndex = e.NewPageIndex;
                grCentros.DataSource = listaCentro;
                grCentros.DataBind();
            }
        }

        protected void grHorario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grHorario.PageIndex = e.NewPageIndex;
            grHorario.DataSource = listaHorario;
            grHorario.DataBind();
        }
    }
}