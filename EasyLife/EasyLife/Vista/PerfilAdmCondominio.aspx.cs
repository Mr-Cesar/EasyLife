using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace EasyLife.Vista
{
    public partial class PerfilAdmCondominio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                long persona = 5;
                cargarDatos(persona);
                cargarCondominio(persona);
                cargarConserje();
                cargarPropietarios();
                cargarGastoComun();
                cargarCentro();
            }
        }

        private static long administradorCondominio;
        private static List<Adapter.AdapterCondominio> listaCondominio = new List<Adapter.AdapterCondominio>();
        private static List<Adapter.AdapterCondominio> listaSearchCondominio = new List<Adapter.AdapterCondominio>();
        private static Boolean searchCondominio = false;
        private static List<Adapter.AdapterEdificio> listaEdificio = new List<Adapter.AdapterEdificio>();
        private static List<DEPARTAMENTO> listaDepartamento = new List<DEPARTAMENTO>();
        private static List<MULTA> listaMulta = new List<MULTA>();
        private static List<Adapter.AdapterConserje> listaConserje = new List<Adapter.AdapterConserje>();
        private static List<Adapter.AdapterConserje> listaSearchConserje = new List<Adapter.AdapterConserje>();
        private static List<TURNO> listaTurno = new List<TURNO>();
        private static Boolean searchConserje = false;
        private static List<Adapter.AdapterPropietario> listaPropietario = new List<Adapter.AdapterPropietario>();
        private static List<Adapter.AdapterPropietario> listaSearchPropietario = new List<Adapter.AdapterPropietario>();
        private static Boolean searchPropietario = false;
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
            List<string> lista = new List<string>();
            List<CONDOMINIO> listaCondominioAdm = new List<CONDOMINIO>();
            listaCondominioAdm = Controller.ControllerCondominio.listaCondominioAdministrador(aux.ID_PERSONA);
            foreach (CONDOMINIO item in listaCondominioAdm)
            {
                lista.Add(item.NOMBRE_CONDOMINIO);
            }

            listCondominio.DataSource = lista;
            listCondominio.DataBind();
            administradorCondominio = aux.ID_PERSONA;
        }

        public void cargarCondominio(long administrador)
        {
            listaCondominio = new List<Adapter.AdapterCondominio>();
            listaCondominio = Controller.ControllerCondominio.listaAdapterCondominioAdm(administrador);
            grCondominio.DataSource = listaCondominio;
            grCondominio.DataBind();

            List<CONDOMINIO> lista = Controller.ControllerCondominio.listaCondominioAdministrador(administrador);
            dplCondominioConserje.DataSource = lista;
            dplCondominioConserje.DataValueField = "ID_CONDOMINIO";
            dplCondominioConserje.DataTextField = "NOMBRE_CONDOMINIO";
            dplCondominioConserje.DataBind();
            dplCondominioConserje.Items.Insert(0, "Seleccione un Condominio");
            dplCondominioConserje.SelectedIndex = 0;

            dplCondominioPropietario.DataSource = lista;
            dplCondominioPropietario.DataValueField = "ID_CONDOMINIO";
            dplCondominioPropietario.DataTextField = "NOMBRE_CONDOMINIO";
            dplCondominioPropietario.DataBind();
            dplCondominioPropietario.Items.Insert(0, "Seleccione un Condominio");
            dplCondominioPropietario.SelectedIndex = 0;

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

        public void cargarConserje()
        {
            listaConserje = new List<Adapter.AdapterConserje>();
            List<Adapter.AdapterConserje> listaAux = new List<Adapter.AdapterConserje>();
            foreach (Adapter.AdapterCondominio item in listaCondominio)
            {
                listaAux = Controller.ControllerConserje.listaAdapterConserjeCondominio(item._ID_CONDOMINIO);
                foreach (Adapter.AdapterConserje adapter in listaAux)
                {
                    listaConserje.Add(adapter);
                }
            }
            grConserje.DataSource = listaConserje;
            grConserje.DataBind();
        }

        public void cargarPropietarios()
        {
            listaPropietario = new List<Adapter.AdapterPropietario>();
            List<Adapter.AdapterPropietario> listaAux = new List<Adapter.AdapterPropietario>();
            foreach (Adapter.AdapterCondominio item in listaCondominio)
            {
                listaAux = Controller.ControllerPersona.listaPropietariosCondominio(item._ID_CONDOMINIO);
                foreach (Adapter.AdapterPropietario adapter in listaAux)
                {
                    listaPropietario.Add(adapter);
                }
            }
            grPropietarios.DataSource = listaPropietario;
            grPropietarios.DataBind();
        }

        public void cargarGastoComun()
        {
            listaGasto = new List<Adapter.AdapterGastoComun>();
            List<Adapter.AdapterGastoComun> listaAux = new List<Adapter.AdapterGastoComun>();
            foreach (Adapter.AdapterCondominio item in listaCondominio)
            {
                listaAux = Controller.ControllerGastoComun.listaGastoCondominio(item._ID_CONDOMINIO);
                foreach (Adapter.AdapterGastoComun adapter in listaAux)
                {
                    listaGasto.Add(adapter);
                }
            }
            grGastos.DataSource = listaGasto;
            grGastos.DataBind();
        }

        public void cargarCentro()
        {
            listaCentro = new List<Adapter.AdapterCentro>();
            List<Adapter.AdapterCentro> listaAux = new List<Adapter.AdapterCentro>();
            foreach (Adapter.AdapterCondominio item in listaCondominio)
            {
                listaAux = Controller.ControllerCentro.searchCentroCondominio(item._ID_CONDOMINIO);
                foreach (Adapter.AdapterCentro adapter in listaAux)
                {
                    listaCentro.Add(adapter);
                }
            }
            grCentros.DataSource = listaCentro;
            grCentros.DataBind();
        }

        protected void btnDatosUsuario_Click(object sender, EventArgs e)
        {
            panelDatos.Visible = true;
            panelCondominio.Visible = false;
            panelConserje.Visible = false;
            panelPropietario.Visible = false;
            panelGastos.Visible = false;
            panelCentro.Visible = false;
            panelMensajes.Visible = false;
            panelAvisos.Visible = false;

            btnDatosUsuario.BackColor = Color.LightBlue;
            btnCondominio.BackColor = Color.White;
            btnConserjes.BackColor = Color.White;
            btnPropietarios.BackColor = Color.White;
            btnGastos.BackColor = Color.White;
            btnCentro.BackColor = Color.White;
            btnMensajes.BackColor = Color.White;
            btnAvisos.BackColor = Color.White;

            limpiarVariable();
        }

        protected void btnCondominio_Click(object sender, EventArgs e)
        {
            panelDatos.Visible = false;
            panelCondominio.Visible = true;
            panelConserje.Visible = false;
            panelPropietario.Visible = false;
            panelGastos.Visible = false;
            panelCentro.Visible = false;
            panelMensajes.Visible = false;
            panelAvisos.Visible = false;

            btnDatosUsuario.BackColor = Color.White;
            btnCondominio.BackColor = Color.LightBlue;
            btnConserjes.BackColor = Color.White;
            btnPropietarios.BackColor = Color.White;
            btnGastos.BackColor = Color.White;
            btnCentro.BackColor = Color.White;
            btnMensajes.BackColor = Color.White;
            btnAvisos.BackColor = Color.White;

            limpiarVariable();
        }

        protected void btnConserjes_Click(object sender, EventArgs e)
        {
            panelDatos.Visible = false;
            panelCondominio.Visible = false;
            panelConserje.Visible = true;
            panelPropietario.Visible = false;
            panelGastos.Visible = false;
            panelCentro.Visible = false;
            panelMensajes.Visible = false;
            panelAvisos.Visible = false;

            btnDatosUsuario.BackColor = Color.White;
            btnCondominio.BackColor = Color.White;
            btnConserjes.BackColor = Color.LightBlue;
            btnPropietarios.BackColor = Color.White;
            btnGastos.BackColor = Color.White;
            btnCentro.BackColor = Color.White;
            btnMensajes.BackColor = Color.White;
            btnAvisos.BackColor = Color.White;

            limpiarVariable();
        }

        protected void btnPropietarios_Click(object sender, EventArgs e)
        {
            panelDatos.Visible = false;
            panelCondominio.Visible = false;
            panelConserje.Visible = false;
            panelPropietario.Visible = true;
            panelGastos.Visible = false;
            panelCentro.Visible = false;
            panelMensajes.Visible = false;
            panelAvisos.Visible = false;

            btnDatosUsuario.BackColor = Color.White;
            btnCondominio.BackColor = Color.White;
            btnConserjes.BackColor = Color.White;
            btnPropietarios.BackColor = Color.LightBlue;
            btnGastos.BackColor = Color.White;
            btnCentro.BackColor = Color.White;
            btnMensajes.BackColor = Color.White;
            btnAvisos.BackColor = Color.White;

            limpiarVariable();
        }

        protected void btnGastos_Click(object sender, EventArgs e)
        {
            panelDatos.Visible = false;
            panelCondominio.Visible = false;
            panelConserje.Visible = false;
            panelPropietario.Visible = false;
            panelGastos.Visible = true;
            panelCentro.Visible = false;
            panelMensajes.Visible = false;
            panelAvisos.Visible = false;

            btnDatosUsuario.BackColor = Color.White;
            btnCondominio.BackColor = Color.White;
            btnConserjes.BackColor = Color.White;
            btnPropietarios.BackColor = Color.White;
            btnGastos.BackColor = Color.LightBlue;
            btnCentro.BackColor = Color.White;
            btnMensajes.BackColor = Color.White;
            btnAvisos.BackColor = Color.White;

            limpiarVariable();
        }

        protected void btnCentro_Click(object sender, EventArgs e)
        {
            panelDatos.Visible = false;
            panelCondominio.Visible = false;
            panelConserje.Visible = false;
            panelPropietario.Visible = false;
            panelGastos.Visible = false;
            panelCentro.Visible = true;
            panelMensajes.Visible = false;
            panelAvisos.Visible = false;

            btnDatosUsuario.BackColor = Color.White;
            btnCondominio.BackColor = Color.White;
            btnConserjes.BackColor = Color.White;
            btnPropietarios.BackColor = Color.White;
            btnGastos.BackColor = Color.White;
            btnCentro.BackColor = Color.LightBlue;
            btnMensajes.BackColor = Color.White;
            btnAvisos.BackColor = Color.White;

            limpiarVariable();
        }

        protected void btnMensajes_Click(object sender, EventArgs e)
        {
            panelDatos.Visible = false;
            panelCondominio.Visible = false;
            panelConserje.Visible = false;
            panelPropietario.Visible = false;
            panelGastos.Visible = false;
            panelCentro.Visible = false;
            panelMensajes.Visible = true;
            panelAvisos.Visible = false;

            btnDatosUsuario.BackColor = Color.White;
            btnCondominio.BackColor = Color.White;
            btnConserjes.BackColor = Color.White;
            btnPropietarios.BackColor = Color.White;
            btnGastos.BackColor = Color.White;
            btnCentro.BackColor = Color.White;
            btnMensajes.BackColor = Color.LightBlue;
            btnAvisos.BackColor = Color.White;

            limpiarVariable();
        }

        protected void btnAvisos_Click(object sender, EventArgs e)
        {
            panelDatos.Visible = false;
            panelCondominio.Visible = false;
            panelConserje.Visible = false;
            panelPropietario.Visible = false;
            panelGastos.Visible = false;
            panelCentro.Visible = false;
            panelMensajes.Visible = false;
            panelAvisos.Visible = true;

            btnDatosUsuario.BackColor = Color.White;
            btnCondominio.BackColor = Color.White;
            btnConserjes.BackColor = Color.White;
            btnPropietarios.BackColor = Color.White;
            btnGastos.BackColor = Color.White;
            btnCentro.BackColor = Color.White;
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
            grDep.DataSource = listaDepartamento;
            grDep.DataBind();
            grMulta.DataSource = listaMulta;
            grMulta.DataBind();
            panelEdificio.Visible = false;
            panelDep.Visible = false;
            panelDetalleDep.Visible = false;
            lbErrorSearchCondominio.Visible = false;
            lbError.Visible = false;
            lbErrorMulta.Visible = false;
            txtSearchCondominio.Text = "";

            //Variables Conserje
            listaSearchConserje = new List<Adapter.AdapterConserje>();
            listaTurno = new List<TURNO>();
            searchConserje = false;
            grConserje.Visible = true;
            grConserje.DataSource = listaConserje;
            grConserje.DataBind();
            grTurno.DataSource = listaTurno;
            grTurno.DataBind();
            lbErrorConserje.Visible = false;
            lbErrorSearchConserje.Visible = false;
            lbConserje.Visible = false;
            btnModificarConserje.Enabled = false;
            btnEliminarConserje.Enabled = false;
            btnAsignarTurno.Enabled = false;
            panelTurnoConserje.Visible = false;
            dplCondominioConserje.SelectedIndex = 0;
            txtSearchConserje.Text = "";
            Session["ModificarConserje"] = null;
            Session["ModificarTurno"] = null;

            //Variables Propietario
            listaSearchPropietario = new List<Adapter.AdapterPropietario>();
            searchPropietario = false;
            grPropietarios.DataSource = listaPropietario;
            grPropietarios.DataBind();
            btnModificarPropietario.Enabled = false;
            btnEliminarPropietario.Enabled = false;
            btnAsignarMulta.Enabled = false;
            btnAsignarLuz.Enabled = false;
            dplCondominioPropietario.SelectedIndex = 0;
            txtSearchPropietario.Text = "";
            panelDetalle.Visible = false;
            lbErrorPropietario.Visible = false;
            lbErrorSearchPropietario.Visible = false;
            Session["ModificarPropietario"] = null;
            Session["AsignarLuzDepartamento"] = null;
            Session["AsignarMultaDepartamento"] = null;

            //Variables Gasto
            listaSearchGasto = new List<Adapter.AdapterGastoComun>();
            grGastos.DataSource = listaGasto;
            grGastos.DataBind();
            searchGasto = false;
            txtSearchGasto.Text = "";
            lbErrorSearchGasto.Visible = false;
            dplCondominioGasto.SelectedIndex = 0;
            Session["ModificarGasto"] = null;

            //Variables Centro
            listaSearchCentro = new List<Adapter.AdapterCentro>();
            listaHorario = new List<HORARIO_CENTRO>();
            searchCentro = false;
            grCentros.DataSource = listaCentro;
            grCentros.DataBind();
            grHorario.DataSource = listaHorario;
            grHorario.DataBind();
            panelHorario.Visible = false;
            lbErrorSearchCentro.Visible = false;
            lbErrorCentro.Visible = false;
            dplCondominioCentro.SelectedIndex = 0;
            txtSearchCentro.Text = "";
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
            listaSearchCondominio = Controller.ControllerCondominio.searchAdaprterCondominioAdministrador(txtSearchCondominio.Text, administradorCondominio);
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
            grDep.DataSource = listaDepartamento;
            grDep.DataBind();
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

        protected void grDep_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                listaMulta = new List<MULTA>();
                GridViewRow gvr = grDep.SelectedRow;
                long departamento = (long)grDep.DataKeys[gvr.RowIndex].Value;

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

        protected void grDep_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            panelDetalleDep.Visible = false;
            lbErrorSearchCondominio.Visible = false;
            lbError.Visible = false;
            lbErrorMulta.Visible = false;
            grDep.PageIndex = e.NewPageIndex;
            grDep.DataSource = listaDepartamento;
            grDep.DataBind();
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

        protected void btnSearchConserje_Click(object sender, EventArgs e)
        {
            listaSearchConserje = new List<Adapter.AdapterConserje>();
            dplCondominioConserje.SelectedIndex = 0;
            string parametro = txtSearchConserje.Text;
            foreach (Adapter.AdapterConserje item in listaConserje)
            {
                if (item._NOMBRE_PERSONA.Contains(parametro) || item._APELLIDO_PERSONA.Contains(parametro) || item._FK_RUT.Contains(parametro) ||
                    item._TELEFONO_PERSONA.Contains(parametro) || item._CORREO_PERSONA.Contains(parametro) || item._NOMBRE_CONDOMINIO.Contains(parametro))
                {
                    listaSearchConserje.Add(item);
                }
            }

            if (listaSearchConserje.Count > 0)
            {
                lbErrorSearchConserje.Visible = false;
                dplCondominioConserje.SelectedIndex = 0;
                grConserje.DataSource = listaSearchConserje;
                grConserje.DataBind();
                searchConserje = true;
            }
            else
            {
                lbErrorSearchConserje.Visible = true;
                dplCondominioConserje.SelectedIndex = 0;
                listaSearchConserje = new List<Adapter.AdapterConserje>();
                grConserje.DataSource = listaSearchConserje;
                grConserje.DataBind();
                searchConserje = false;
            }
        }

        protected void btnRegistroConserje_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistroConserje.aspx");
        }

        protected void btnModificarConserje_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistroConserje.aspx");
        }

        protected void btnEliminarConserje_Click(object sender, EventArgs e)
        {
        }

        protected void btnAsignarTurno_Click(object sender, EventArgs e)
        {
            Response.Redirect("AsignarTurnoConserje.aspx");
        }

        protected void dplCondominioConserje_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtSearchConserje.Text = "";
                long condominio = Convert.ToInt64(dplCondominioConserje.SelectedValue);
                panelTurnoConserje.Visible = false;
                lbConserje.Visible = false;
                lbErrorConserje.Visible = false;
                lbErrorSearchConserje.Visible = false;
                btnModificarConserje.Enabled = false;
                btnEliminarConserje.Enabled = false;
                btnAsignarTurno.Enabled = false;
                listaTurno = new List<TURNO>();
                grTurno.DataSource = listaTurno;
                grTurno.DataBind();
                listaSearchConserje = new List<Adapter.AdapterConserje>();
                listaSearchConserje = Controller.ControllerConserje.listaAdapterConserjeCondominio(condominio);
                if (listaSearchConserje.Count > 0)
                {
                    lbErrorConserje.Visible = false;
                    grConserje.DataSource = listaSearchConserje;
                    grConserje.DataBind();
                    searchConserje = true;
                }
                else
                {
                    lbErrorConserje.Visible = true;
                    listaSearchConserje = new List<Adapter.AdapterConserje>();
                    grConserje.DataSource = listaSearchConserje;
                    grConserje.DataBind();
                    searchConserje = false;
                }
            }
            catch (Exception ex)
            {
                txtSearchConserje.Text = "";
                lbErrorConserje.Visible = false;
                lbErrorSearchConserje.Visible = false;
                btnModificarConserje.Enabled = false;
                btnEliminarConserje.Enabled = false;
                btnAsignarTurno.Enabled = false;
                grConserje.DataSource = listaConserje;
                grConserje.DataBind();
                searchConserje = false;
                panelTurnoConserje.Visible = false;
                lbConserje.Visible = false;
                listaTurno = new List<TURNO>();
                grTurno.DataSource = listaTurno;
                grTurno.DataBind();
                System.Diagnostics.Debug.WriteLine("Error: " + ex);
            }
        }

        protected void grConserje_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelTurnoConserje.Visible = true;
            GridViewRow gvr = grConserje.SelectedRow;
            long conserje = (long)grConserje.DataKeys[gvr.RowIndex].Value;
            Session["ModificarConserje"] = conserje.ToString();
            Session["ModificarTurno"] = conserje.ToString();
            btnModificarConserje.Enabled = true;
            btnEliminarConserje.Enabled = true;
            btnAsignarTurno.Enabled = true;

            listaTurno = new List<TURNO>();
            listaTurno = Controller.ControllerTurno.listaTurno(conserje);
            if (listaTurno.Count > 0)
            {
                lbConserje.Visible = false;
                grTurno.DataSource = listaTurno;
                grTurno.DataBind();
            }
            else
            {
                lbConserje.Visible = true;
                listaTurno = new List<TURNO>();
                grTurno.DataSource = listaTurno;
                grTurno.DataBind();
            }
        }

        protected void grConserje_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (searchConserje == true)
            {
                panelTurnoConserje.Visible = false;
                lbConserje.Visible = false;
                listaTurno = new List<TURNO>();
                grTurno.DataSource = listaTurno;
                grTurno.DataBind();
                grConserje.PageIndex = e.NewPageIndex;
                grConserje.DataSource = listaSearchConserje;
                grConserje.DataBind();
            }
            else
            {
                panelTurnoConserje.Visible = false;
                lbConserje.Visible = false;
                listaTurno = new List<TURNO>();
                grTurno.DataSource = listaTurno;
                grTurno.DataBind();
                grConserje.PageIndex = e.NewPageIndex;
                grConserje.DataSource = listaConserje;
                grConserje.DataBind();
            }
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
            dplCondominioPropietario.SelectedIndex = 0;
            string parametro = txtSearchPropietario.Text;
            foreach (Adapter.AdapterPropietario item in listaPropietario)
            {
                if (item._NOMBRE_PERSONA.Contains(parametro) || item._APELLIDO_PERSONA.Contains(parametro) || item._FK_RUT.Contains(parametro) ||
                    item._TELEFONO_PERSONA.Contains(parametro) || item._CORREO_PERSONA.Contains(parametro) || item._NOMBRE_CONDOMINIO.Contains(parametro) ||
                    item._NOMBRE_EDIFICIO.Contains(parametro) || item._NUMERO_DEP.Contains(parametro))
                {
                    listaSearchPropietario.Add(item);
                }
            }

            if (listaSearchPropietario.Count > 0)
            {
                lbErrorSearchPropietario.Visible = false;
                dplCondominioPropietario.SelectedIndex = 0;
                grPropietarios.DataSource = listaSearchPropietario;
                grPropietarios.DataBind();
                searchPropietario = true;
            }
            else
            {
                lbErrorSearchPropietario.Visible = true;
                dplCondominioPropietario.SelectedIndex = 0;
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

        protected void dplCondominioPropietario_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtSearchPropietario.Text = "";
                long condominio = Convert.ToInt64(dplCondominioPropietario.SelectedValue);
                btnModificarPropietario.Enabled = false;
                btnEliminarPropietario.Enabled = false;
                btnAsignarMulta.Enabled = false;
                lbErrorPropietario.Visible = false;
                lbErrorSearchPropietario.Visible = false;
                listaSearchPropietario = new List<Adapter.AdapterPropietario>();
                listaSearchPropietario = Controller.ControllerPersona.listaPropietariosCondominio(condominio);
                if (listaSearchPropietario.Count > 0)
                {
                    lbErrorPropietario.Visible = false;
                    lbErrorSearchPropietario.Visible = false;
                    grPropietarios.DataSource = listaSearchPropietario;
                    grPropietarios.DataBind();
                    searchPropietario = true;
                    panelDetalle.Visible = false;
                }
                else
                {
                    lbErrorPropietario.Visible = true;
                    lbErrorSearchPropietario.Visible = false;
                    listaSearchPropietario = new List<Adapter.AdapterPropietario>();
                    grPropietarios.DataSource = listaSearchPropietario;
                    grPropietarios.DataBind();
                    searchPropietario = false;
                    panelDetalle.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lbErrorPropietario.Visible = false;
                lbErrorSearchPropietario.Visible = false;
                grPropietarios.DataSource = listaPropietario;
                grPropietarios.DataBind();
                searchPropietario = false;
                panelDetalle.Visible = false;
                listaSearchPropietario = new List<Adapter.AdapterPropietario>();
                txtSearchPropietario.Text = "";
                System.Diagnostics.Debug.WriteLine("Error: " + ex);
            }
        }

        protected void grPropietarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            Adapter.AdapterPropietario prop = new Adapter.AdapterPropietario();
            if (searchPropietario == true)
            {
                panelDetalle.Visible = true;
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
                PERSONA aux = Controller.ControllerPersona.buscarIdPersona(propietario);
                if (aux.LUZ == true)
                {
                    btnAsignarLuz.Enabled = true;
                }
                else
                {
                    btnAsignarLuz.Enabled = false;
                }
                Session["ModificarPropietario"] = propietario.ToString();
                Session["AsignarLuzDepartamento"] = propietario.ToString();
                Session["AsignarMultaDepartamento"] = propietario.ToString();
            }
            else
            {
                panelDetalle.Visible = true;
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
                PERSONA aux = Controller.ControllerPersona.buscarIdPersona(propietario);
                if (aux.LUZ == true)
                {
                    btnAsignarLuz.Enabled = true;
                }
                else
                {
                    btnAsignarLuz.Enabled = false;
                }
                Session["ModificarPropietario"] = propietario.ToString();
                Session["AsignarLuzDepartamento"] = propietario.ToString();
                Session["AsignarMultaDepartamento"] = propietario.ToString();
            }

            btnModificarPropietario.Enabled = true;
            btnEliminarPropietario.Enabled = true;
            btnAsignarMulta.Enabled = true;
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

        protected void btnAsignarLuz_Click(object sender, EventArgs e)
        {
            Response.Redirect("AsignarLuzDepartamento.aspx");
        }

        protected void btnSearchGasto_Click(object sender, EventArgs e)
        {
            listaSearchGasto = new List<Adapter.AdapterGastoComun>();
            dplCondominioGasto.SelectedIndex = 0;
            string parametro = txtSearchGasto.Text;
            foreach (Adapter.AdapterGastoComun item in listaGasto)
            {
                if (item._NOMBRE_EDIFICIO.Contains(parametro))
                {
                    listaSearchGasto.Add(item);
                }
            }

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
                dplCondominioGasto.SelectedIndex = 0;
                listaSearchGasto = new List<Adapter.AdapterGastoComun>();
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
                lbErrorSearchGasto.Visible = false;
                listaSearchGasto = new List<Adapter.AdapterGastoComun>();
                listaSearchGasto = Controller.ControllerGastoComun.listaGastoCondominio(condominio);
                if (listaSearchGasto.Count > 0)
                {
                    lbErrorSearchGasto.Visible = false;
                    grGastos.DataSource = listaSearchGasto;
                    grGastos.DataBind();
                    searchGasto = true;
                }
                else
                {
                    lbErrorSearchGasto.Visible = true;
                    listaSearchGasto = new List<Adapter.AdapterGastoComun>();
                    grGastos.DataSource = listaSearchGasto;
                    grGastos.DataBind();
                    searchGasto = false;
                }
            }
            catch (Exception ex)
            {
                txtSearchGasto.Text = "";
                lbErrorSearchGasto.Visible = false;
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
            string parametro = txtSearchCentro.Text;
            int costo = Convert.ToInt32(parametro);
            foreach (Adapter.AdapterCentro item in listaCentro)
            {
                if (item._NOMBRE_CONDOMINIO.Contains(parametro) || item._NOMBRE_EDIFICIO.Contains(parametro) || item._NOMBRE_CENTRO.Contains(parametro) ||
                    item._NOMBRE_TIPO_CENTRO.Contains(parametro) || item._COSTO == costo)
                {
                    listaSearchCentro.Add(item);
                }
            }

            if (listaSearchCentro.Count > 0)
            {
                lbErrorSearchCentro.Visible = false;
                lbErrorCentro.Visible = false;
                dplCondominioCentro.SelectedIndex = 0;
                grCentros.DataSource = listaSearchCentro;
                grCentros.DataBind();
                searchCentro = true;
            }
            else
            {
                lbErrorSearchCentro.Visible = false;
                lbErrorCentro.Visible = false;
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

        protected void dplCondominioCentro_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtSearchCentro.Text = "";
                long condominio = Convert.ToInt64(dplCondominioCentro.SelectedValue);
                listaSearchCentro = new List<Adapter.AdapterCentro>();
                lbErrorCentro.Visible = false;
                lbErrorSearchCentro.Visible = false;
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

        protected void grCentros_SelectedIndexChanged(object sender, EventArgs e)
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

        protected void grCentros_PageIndexChanging(object sender, GridViewPageEventArgs e)
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