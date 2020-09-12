using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace EasyLife.Vista
{
    public partial class PerfilConserje : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validación de Session Iniciada
            LOGIN adm = (LOGIN)Session["adm"];
            LOGIN conserje = (LOGIN)Session["conserje"];
            LOGIN vendedor = (LOGIN)Session["vendedor"];
            LOGIN propietario = (LOGIN)Session["login"];
            LOGIN admCondominio = (LOGIN)Session["admCondominio"];
            if (adm != null || vendedor != null || propietario != null || admCondominio != null)
            {
                Response.Redirect("Index.aspx");
            }
            else if (adm == null && conserje == null && vendedor == null && propietario == null && admCondominio == null)
            {
                Response.Redirect("Index.aspx");
            }

            if (!IsPostBack)
            {
                cargarDatos(conserje.ID_PERSONA);
                cargarGastoComun();
                cargarControl();
                cargarEstacionamiento();
                cargarReserva();
            }

            /*if (!IsPostBack)
            {
                long conserje = 2;
                cargarDatos(conserje);
                cargarGastoComun();
                cargarControl();
                cargarEstacionamiento();
                cargarReserva();
            }*/
        }

        private static PERSONA conserje = new PERSONA();
        private static List<CONDOMINIO> listaCondominio = new List<CONDOMINIO>();
        private static List<EDIFICIO> listaEdificio = new List<EDIFICIO>();
        private static List<Adapter.AdapterBoletaGasto> listaGasto = new List<Adapter.AdapterBoletaGasto>();
        private static List<Adapter.AdapterBoletaGasto> listaSearchGasto = new List<Adapter.AdapterBoletaGasto>();
        private static Boolean searchGasto = false;
        private static List<Adapter.AdapterControlLuzEdificio> listaControlEdificio = new List<Adapter.AdapterControlLuzEdificio>();
        private static List<Adapter.AdapterControlLuzEdificio> listaSearchControlEdificio = new List<Adapter.AdapterControlLuzEdificio>();
        private static Boolean searchControl = false;
        private static List<Adapter.AdapterEstacionamiento> listaEstacionamiento = new List<Adapter.AdapterEstacionamiento>();
        private static List<Adapter.AdapterEstacionamiento> listaSearchEstacionamiento = new List<Adapter.AdapterEstacionamiento>();
        private static Boolean searchEstacionamiento = false;
        private static List<Adapter.AdapterReserva> listaReserva = new List<Adapter.AdapterReserva>();
        private static List<Adapter.AdapterReserva> listaSearchReserva = new List<Adapter.AdapterReserva>();
        private static Boolean searchReserva = false;

        public void cargarDatos(long persona)
        {
            conserje = new PERSONA();
            PERSONA aux = Controller.ControllerPersona.buscarIdPersona(persona);
            lbUser.Text = aux.NOMBRE_PERSONA;
            lbRut.Text = aux.FK_RUT;
            lbNombre.Text = aux.NOMBRE_PERSONA;
            lbApellido.Text = aux.APELLIDO_PERSONA;
            lbTelefono.Text = aux.TELEFONO_PERSONA;
            lbCorreo.Text = aux.CORREO_PERSONA;

            CONSERJE conser = Controller.ControllerConserje.buscarIdConserje(aux.ID_PERSONA);
            listaEdificio = Controller.ControllerEdificio.buscarEdificioCondominio(Convert.ToInt64(conser.ID_CONDOMINIO));
            dplEdificioLuces.DataSource = listaEdificio;
            dplEdificioLuces.DataValueField = "ID_EDIFICIO";
            dplEdificioLuces.DataTextField = "NOMBRE_EDIFICIO";
            dplEdificioLuces.DataBind();
            dplEdificioLuces.Items.Insert(0, "Seleccione un Edificio");
            dplEdificioLuces.SelectedIndex = 0;
            conserje = aux;

            List<TIPO_CENTRO> listaTipo = new List<TIPO_CENTRO>();
            listaTipo = Controller.ControllerTipoCentro.listaTipoCentro();
            dplCentro.DataSource = listaTipo;
            dplCentro.DataValueField = "ID_TIPO_CENTRO";
            dplCentro.DataTextField = "NOMBRE_TIPO_CENTRO";
            dplCentro.DataBind();
            dplCentro.Items.Insert(0, "Seleccione un Tipo de Centro");
            dplCentro.SelectedIndex = 0;
        }

        public void cargarGastoComun()
        {
            listaGasto = new List<Adapter.AdapterBoletaGasto>();
            List<Adapter.AdapterBoletaGasto> lista = new List<Adapter.AdapterBoletaGasto>();
            foreach (EDIFICIO item in listaEdificio)
            {
                lista = Controller.ControllerGastoComun.listaGastosBoletaEdificio(item.ID_EDIFICIO);
                foreach (Adapter.AdapterBoletaGasto adapter in lista)
                {
                    if (adapter._COSTO_BOLETA != adapter._TOTAL_GASTO)
                    {
                        adapter._MULTA = adapter._COSTO_BOLETA - adapter._TOTAL_GASTO;
                    }
                    listaGasto.Add(adapter);
                }
            }
            grBoletas.DataSource = listaGasto;
            grBoletas.DataBind();
        }

        public void cargarControl()
        {
            listaControlEdificio = new List<Adapter.AdapterControlLuzEdificio>();
            List<Adapter.AdapterControlLuzEdificio> lista = new List<Adapter.AdapterControlLuzEdificio>();
            foreach (EDIFICIO item in listaEdificio)
            {
                lista = Controller.ControllerControlIluminacionEdificio.listaControlesEdificio(item.ID_EDIFICIO);
                foreach (Adapter.AdapterControlLuzEdificio adapter in lista)
                {
                    listaControlEdificio.Add(adapter);
                }
            }

            grLuces.DataSource = listaControlEdificio;
            grLuces.DataBind();
        }

        public void cargarEstacionamiento()
        {
            listaEstacionamiento = new List<Adapter.AdapterEstacionamiento>();
            List<Adapter.AdapterEstacionamiento> lista = new List<Adapter.AdapterEstacionamiento>();
            foreach (EDIFICIO item in listaEdificio)
            {
                lista = Controller.ControllerEstacionamientoVisita.listaEstacionamiento(item.ID_EDIFICIO);
                foreach (Adapter.AdapterEstacionamiento adapter in lista)
                {
                    if (adapter._HORA_SALIDA == null)
                    {
                        adapter._HORA_SALIDA = "Pendiente";
                    }
                    listaEstacionamiento.Add(adapter);
                }
            }

            grEstacionamiento.DataSource = listaEstacionamiento;
            grEstacionamiento.DataBind();
        }

        public void cargarReserva()
        {
            List<DEPARTAMENTO> listaDepartamento = new List<DEPARTAMENTO>();
            List<DEPARTAMENTO> lista = new List<DEPARTAMENTO>();
            List<Adapter.AdapterReserva> listaAuxReserva = new List<Adapter.AdapterReserva>();
            listaReserva = new List<Adapter.AdapterReserva>();
            foreach (EDIFICIO item in listaEdificio)
            {
                lista = Controller.ControllerDepartamento.listaDepartamento(item.ID_EDIFICIO);
                foreach (DEPARTAMENTO dep in lista)
                {
                    listaDepartamento.Add(dep);
                }
            }

            foreach (DEPARTAMENTO item in listaDepartamento)
            {
                listaAuxReserva = Controller.ControllerReservaCentro.listadoReservaDepartamento(item.ID_DEPARTAMENTO);
                foreach (Adapter.AdapterReserva adapter in listaAuxReserva)
                {
                    listaReserva.Add(adapter);
                }
            }

            grReserva.DataSource = listaReserva;
            grReserva.DataBind();
        }

        protected void btnDatosUsuario_Click(object sender, EventArgs e)
        {
            panelDatos.Visible = true;
            panelGastos.Visible = false;
            panelLuces.Visible = false;
            panelEstacionamiento.Visible = false;
            panelReservas.Visible = false;
            panelMensajes.Visible = false;
            panelAvisos.Visible = false;

            btnDatosUsuario.BackColor = Color.LightBlue;
            btnGastos.BackColor = Color.White;
            btnLuces.BackColor = Color.White;
            btnEstacionamiento.BackColor = Color.White;
            btnReserva.BackColor = Color.White;
            btnMensajes.BackColor = Color.White;
            btnAvisos.BackColor = Color.White;

            limpiarVariables();
        }

        protected void btnGastos_Click(object sender, EventArgs e)
        {
            panelDatos.Visible = false;
            panelGastos.Visible = true;
            panelLuces.Visible = false;
            panelEstacionamiento.Visible = false;
            panelReservas.Visible = false;
            panelMensajes.Visible = false;
            panelAvisos.Visible = false;

            btnDatosUsuario.BackColor = Color.White;
            btnGastos.BackColor = Color.LightBlue;
            btnLuces.BackColor = Color.White;
            btnEstacionamiento.BackColor = Color.White;
            btnReserva.BackColor = Color.White;
            btnMensajes.BackColor = Color.White;
            btnAvisos.BackColor = Color.White;

            limpiarVariables();
        }

        protected void btnLuces_Click(object sender, EventArgs e)
        {
            panelDatos.Visible = false;
            panelGastos.Visible = false;
            panelLuces.Visible = true;
            panelEstacionamiento.Visible = false;
            panelReservas.Visible = false;
            panelMensajes.Visible = false;
            panelAvisos.Visible = false;

            btnDatosUsuario.BackColor = Color.White;
            btnGastos.BackColor = Color.White;
            btnLuces.BackColor = Color.LightBlue;
            btnEstacionamiento.BackColor = Color.White;
            btnReserva.BackColor = Color.White;
            btnMensajes.BackColor = Color.White;
            btnAvisos.BackColor = Color.White;

            limpiarVariables();
        }

        protected void btnEstacionamiento_Click(object sender, EventArgs e)
        {
            panelDatos.Visible = false;
            panelGastos.Visible = false;
            panelLuces.Visible = false;
            panelEstacionamiento.Visible = true;
            panelReservas.Visible = false;
            panelMensajes.Visible = false;
            panelAvisos.Visible = false;

            btnDatosUsuario.BackColor = Color.White;
            btnGastos.BackColor = Color.White;
            btnLuces.BackColor = Color.White;
            btnEstacionamiento.BackColor = Color.LightBlue;
            btnReserva.BackColor = Color.White;
            btnMensajes.BackColor = Color.White;
            btnAvisos.BackColor = Color.White;

            limpiarVariables();
        }

        protected void btnReserva_Click(object sender, EventArgs e)
        {
            panelDatos.Visible = false;
            panelGastos.Visible = false;
            panelLuces.Visible = false;
            panelEstacionamiento.Visible = false;
            panelReservas.Visible = true;
            panelMensajes.Visible = false;
            panelAvisos.Visible = false;

            btnDatosUsuario.BackColor = Color.White;
            btnGastos.BackColor = Color.White;
            btnLuces.BackColor = Color.White;
            btnEstacionamiento.BackColor = Color.White;
            btnReserva.BackColor = Color.LightBlue;
            btnMensajes.BackColor = Color.White;
            btnAvisos.BackColor = Color.White;

            limpiarVariables();
        }

        protected void btnMensajes_Click(object sender, EventArgs e)
        {
            panelDatos.Visible = false;
            panelGastos.Visible = false;
            panelLuces.Visible = false;
            panelEstacionamiento.Visible = false;
            panelReservas.Visible = false;
            panelMensajes.Visible = true;
            panelAvisos.Visible = false;

            btnDatosUsuario.BackColor = Color.White;
            btnGastos.BackColor = Color.White;
            btnLuces.BackColor = Color.White;
            btnEstacionamiento.BackColor = Color.White;
            btnReserva.BackColor = Color.White;
            btnMensajes.BackColor = Color.LightBlue;
            btnAvisos.BackColor = Color.White;

            limpiarVariables();
        }

        protected void btnAvisos_Click(object sender, EventArgs e)
        {
            panelDatos.Visible = false;
            panelGastos.Visible = false;
            panelLuces.Visible = false;
            panelEstacionamiento.Visible = false;
            panelReservas.Visible = false;
            panelMensajes.Visible = false;
            panelAvisos.Visible = true;

            btnDatosUsuario.BackColor = Color.White;
            btnGastos.BackColor = Color.White;
            btnLuces.BackColor = Color.White;
            btnEstacionamiento.BackColor = Color.White;
            btnReserva.BackColor = Color.White;
            btnMensajes.BackColor = Color.White;
            btnAvisos.BackColor = Color.LightBlue;

            limpiarVariables();
        }

        public void limpiarVariables()
        {
            //Variables Gastos Comúnes
            listaSearchGasto = new List<Adapter.AdapterBoletaGasto>();
            searchGasto = false;
            grBoletas.DataSource = listaGasto;
            grBoletas.DataBind();
            lbErrorSearchBoleta.Visible = false;
            txtSearchGasto.Text = "";
            panelDetalleBoleta.Visible = false;

            //Variables Luz
            listaSearchControlEdificio = new List<Adapter.AdapterControlLuzEdificio>();
            searchControl = false;
            grLuces.DataSource = listaControlEdificio;
            grLuces.DataBind();
            txtSearchLuces.Text = "";
            lbErrorLuz.Visible = false;
            lbErrorSearchLuz.Visible = false;
            dplEdificioLuces.SelectedIndex = 0;
            Session["ModificarControlIluminacionEdifciio"] = null;

            //Variables Estacionamiento
            listaSearchEstacionamiento = new List<Adapter.AdapterEstacionamiento>();
            searchEstacionamiento = false;
            grEstacionamiento.DataSource = listaEstacionamiento;
            grEstacionamiento.DataBind();
            txtSearchEst.Text = "";
            lbErrorSearchEst.Visible = false;
            Session["ModificarEstacionamiento"] = null;

            //Variables Reserva
            listaSearchReserva = new List<Adapter.AdapterReserva>();
            searchReserva = false;
            grReserva.DataSource = listaReserva;
            grReserva.DataBind();
            txtSearchReserva.Text = "";
            lbErrorReserva.Visible = false;
            lbErrorSearchReserva.Visible = false;
        }

        protected void lnkModificarDatos_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModificarDatos.aspx");
        }

        protected void lnkModificarPassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("CambiarPassword.aspx");
        }

        protected void btnSearchGasto_Click(object sender, EventArgs e)
        {
            lbErrorSearchBoleta.Visible = false;
            listaSearchGasto = new List<Adapter.AdapterBoletaGasto>();
            string parametro = txtSearchGasto.Text;
            List<Adapter.AdapterBoletaGasto> lista = new List<Adapter.AdapterBoletaGasto>();
            foreach (EDIFICIO item in listaEdificio)
            {
                lista = Controller.ControllerGastoComun.listaSearchGastosBoletaEdificio(item.ID_EDIFICIO, parametro);
                foreach (Adapter.AdapterBoletaGasto adapter in lista)
                {
                    if (adapter._COSTO_BOLETA != adapter._TOTAL_GASTO)
                    {
                        adapter._MULTA = adapter._COSTO_BOLETA - adapter._TOTAL_GASTO;
                    }
                    listaSearchGasto.Add(adapter);
                }
            }

            if (listaSearchGasto.Count > 0)
            {
                lbErrorSearchBoleta.Visible = false;
                searchGasto = true;
                grBoletas.DataSource = listaSearchGasto;
                grBoletas.DataBind();
            }
            else
            {
                lbErrorSearchBoleta.Visible = true;
                searchGasto = false;
                listaSearchGasto = new List<Adapter.AdapterBoletaGasto>();
                grBoletas.DataSource = listaSearchGasto;
                grBoletas.DataBind();
            }
        }

        protected void btnPagarGastos_Click(object sender, EventArgs e)
        {
            Response.Redirect("PagoGasto.aspx");
        }

        protected void grBoletas_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelDetalleBoleta.Visible = false;
            GridViewRow gvr = grBoletas.SelectedRow;
            long boleta = (long)grBoletas.DataKeys[gvr.RowIndex].Value;
            Adapter.AdapterBoletaGasto adapter = new Adapter.AdapterBoletaGasto();
            if (searchGasto == true)
            {
                foreach (Adapter.AdapterBoletaGasto item in listaSearchGasto)
                {
                    if (item._ID_BOLETA == boleta)
                    {
                        adapter = item;
                    }
                }
            }
            else
            {
                foreach (Adapter.AdapterBoletaGasto item in listaGasto)
                {
                    if (item._ID_BOLETA == boleta)
                    {
                        adapter = item;
                    }
                }
            }
        }

        protected void grBoletas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (searchGasto == true)
            {
                grBoletas.PageIndex = e.NewPageIndex;
                grBoletas.DataSource = listaSearchGasto;
                grBoletas.DataBind();
            }
            else
            {
                grBoletas.PageIndex = e.NewPageIndex;
                grBoletas.DataSource = listaGasto;
                grBoletas.DataBind();
            }
        }

        protected void btnSearchLuces_Click(object sender, EventArgs e)
        {
            lbErrorSearchLuz.Visible = false;
            lbErrorLuz.Visible = false;
            string parametro = txtSearchLuces.Text;
            listaSearchControlEdificio = new List<Adapter.AdapterControlLuzEdificio>();
            List<Adapter.AdapterControlLuzEdificio> lista = new List<Adapter.AdapterControlLuzEdificio>();
            foreach (EDIFICIO item in listaEdificio)
            {
                lista = Controller.ControllerControlIluminacionEdificio.listaSearchControlesEdificio(item.ID_EDIFICIO, parametro);
                foreach (Adapter.AdapterControlLuzEdificio adapter in lista)
                {
                    listaSearchControlEdificio.Add(adapter);
                }
            }

            if (listaSearchControlEdificio.Count > 0)
            {
                lbErrorLuz.Visible = false;
                lbErrorSearchLuz.Visible = false;
                searchControl = true;
                grLuces.DataSource = listaSearchControlEdificio;
                grLuces.DataBind();
            }
            else
            {
                lbErrorLuz.Visible = false;
                lbErrorSearchLuz.Visible = true;
                searchControl = false;
                listaSearchControlEdificio = new List<Adapter.AdapterControlLuzEdificio>();
                grLuces.DataSource = listaSearchControlEdificio;
                grLuces.DataBind();
            }
        }

        protected void btnEncender_Click(object sender, EventArgs e)
        {
        }

        protected void btnApagar_Click(object sender, EventArgs e)
        {
        }

        protected void btnRegistroLuz_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProgramarLuzEdificio.aspx");
        }

        protected void dplEdificioLuces_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lbErrorLuz.Visible = false;
                lbErrorSearchLuz.Visible = false;
                long edificio = Convert.ToInt64(dplEdificioLuces.SelectedValue);
                listaSearchControlEdificio = new List<Adapter.AdapterControlLuzEdificio>();
                listaSearchControlEdificio = Controller.ControllerControlIluminacionEdificio.listaControlesEdificio(edificio);
                if (listaSearchControlEdificio.Count > 0)
                {
                    lbErrorLuz.Visible = false;
                    lbErrorSearchLuz.Visible = false;
                    grLuces.DataSource = listaSearchControlEdificio;
                    grLuces.DataBind();
                }
                else
                {
                    lbErrorLuz.Visible = true;
                    lbErrorSearchLuz.Visible = false;
                    listaSearchControlEdificio = new List<Adapter.AdapterControlLuzEdificio>();
                    grLuces.DataSource = listaSearchControlEdificio;
                    grLuces.DataBind();
                }
            }
            catch (Exception ex)
            {
                lbErrorLuz.Visible = true;
                lbErrorSearchLuz.Visible = false;
                listaSearchControlEdificio = new List<Adapter.AdapterControlLuzEdificio>();
                grLuces.DataSource = listaControlEdificio;
                grLuces.DataBind();
                System.Diagnostics.Debug.WriteLine("Error:  " + ex);
            }
        }

        protected void grLuces_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gvr = grLuces.SelectedRow;
            long luz = (long)grLuces.DataKeys[gvr.RowIndex].Value;
            Adapter.AdapterControlLuzEdificio adapter = new Adapter.AdapterControlLuzEdificio();
            if (searchControl == true)
            {
                foreach (Adapter.AdapterControlLuzEdificio item in listaSearchControlEdificio)
                {
                    if (item._ID_CILUMINACION_E == luz)
                    {
                        adapter = item;
                    }
                }
            }
            else
            {
                foreach (Adapter.AdapterControlLuzEdificio item in listaControlEdificio)
                {
                    if (item._ID_CILUMINACION_E == luz)
                    {
                        adapter = item;
                    }
                }
            }
            Session["ModificarControlIluminacionEdifciio"] = adapter._ID_CILUMINACION_E;
        }

        protected void grLuces_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (searchControl == true)
            {
                grLuces.PageIndex = e.NewPageIndex;
                grLuces.DataSource = listaSearchControlEdificio;
                grLuces.DataBind();
            }
            else
            {
                grLuces.PageIndex = e.NewPageIndex;
                grLuces.DataSource = listaControlEdificio;
                grLuces.DataBind();
            }
        }

        protected void btnSearchEst_Click(object sender, EventArgs e)
        {
            lbErrorSearchEst.Visible = false;
            string parametro = txtSearchEst.Text;
            listaSearchEstacionamiento = new List<Adapter.AdapterEstacionamiento>();
            List<Adapter.AdapterEstacionamiento> lista = new List<Adapter.AdapterEstacionamiento>();
            foreach (EDIFICIO item in listaEdificio)
            {
                lista = Controller.ControllerEstacionamientoVisita.listaSearchEstacionamiento(item.ID_EDIFICIO, parametro);
                foreach (Adapter.AdapterEstacionamiento adapter in lista)
                {
                    if (adapter._HORA_SALIDA == null)
                    {
                        adapter._HORA_SALIDA = "Pendiente";
                    }
                    listaSearchEstacionamiento.Add(adapter);
                }
            }

            if (listaSearchEstacionamiento.Count > 0)
            {
                lbErrorSearchEst.Visible = false;
                grEstacionamiento.DataSource = listaSearchEstacionamiento;
                grEstacionamiento.DataBind();
            }
            else
            {
                lbErrorSearchEst.Visible = false;
                listaSearchEstacionamiento = new List<Adapter.AdapterEstacionamiento>();
                grEstacionamiento.DataSource = listaSearchEstacionamiento;
                grEstacionamiento.DataBind();
            }
        }

        protected void btnRegistroEst_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistroEstacionamiento.aspx");
        }

        protected void grEstacionamiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gvr = grEstacionamiento.SelectedRow;
            long estacionamiento = (long)grEstacionamiento.DataKeys[gvr.RowIndex].Value;
            string modificar = estacionamiento.ToString();
            Session["ModificarEstacionamiento"] = modificar;
            Response.Redirect("RegistroEstacionamiento.aspx");
        }

        protected void grEstacionamiento_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (searchEstacionamiento == true)
            {
                grEstacionamiento.PageIndex = e.NewPageIndex;
                grEstacionamiento.DataSource = listaSearchEstacionamiento;
                grEstacionamiento.DataBind();
            }
            else
            {
                grEstacionamiento.PageIndex = e.NewPageIndex;
                grEstacionamiento.DataSource = listaEstacionamiento;
                grEstacionamiento.DataBind();
            }
        }

        protected void btnSearchReserva_Click(object sender, EventArgs e)
        {
            string parametro = txtSearchReserva.Text;
            dplCentro.SelectedIndex = 0;
            lbErrorReserva.Visible = false;
            lbErrorSearchReserva.Visible = false;
            List<DEPARTAMENTO> listaDepartamento = new List<DEPARTAMENTO>();
            List<DEPARTAMENTO> lista = new List<DEPARTAMENTO>();
            List<Adapter.AdapterReserva> listaAuxReserva = new List<Adapter.AdapterReserva>();
            listaSearchReserva = new List<Adapter.AdapterReserva>();
            foreach (EDIFICIO item in listaEdificio)
            {
                lista = Controller.ControllerDepartamento.listaDepartamento(item.ID_EDIFICIO);
                foreach (DEPARTAMENTO dep in lista)
                {
                    listaDepartamento.Add(dep);
                }
            }

            foreach (DEPARTAMENTO item in listaDepartamento)
            {
                listaAuxReserva = Controller.ControllerReservaCentro.listadoSearchReservaDepartamento(item.ID_DEPARTAMENTO, parametro);
                foreach (Adapter.AdapterReserva adapter in listaAuxReserva)
                {
                    listaSearchReserva.Add(adapter);
                }
            }

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
                lbErrorReserva.Visible = false;
                lbErrorSearchReserva.Visible = true;
                searchReserva = false;
                listaSearchReserva = new List<Adapter.AdapterReserva>();
                grReserva.DataSource = listaSearchReserva;
                grReserva.DataBind();
            }
        }

        protected void btnRegistroReserva_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistroReservaConserje");
        }

        protected void dplCentro_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                long tipo = Convert.ToInt64(dplCentro.SelectedValue);
                txtSearchReserva.Text = "";
                listaSearchReserva = new List<Adapter.AdapterReserva>();
                lbErrorReserva.Visible = false;
                lbErrorSearchReserva.Visible = false;
                List<DEPARTAMENTO> listaDepartamento = new List<DEPARTAMENTO>();
                List<DEPARTAMENTO> lista = new List<DEPARTAMENTO>();
                List<Adapter.AdapterReserva> listaAuxReserva = new List<Adapter.AdapterReserva>();
                listaSearchReserva = new List<Adapter.AdapterReserva>();
                foreach (EDIFICIO item in listaEdificio)
                {
                    lista = Controller.ControllerDepartamento.listaDepartamento(item.ID_EDIFICIO);
                    foreach (DEPARTAMENTO dep in lista)
                    {
                        listaDepartamento.Add(dep);
                    }
                }

                foreach (DEPARTAMENTO item in listaDepartamento)
                {
                    listaAuxReserva = Controller.ControllerReservaCentro.listadoSearchReservaTipoCentro(item.ID_DEPARTAMENTO, tipo);
                    foreach (Adapter.AdapterReserva adapter in listaAuxReserva)
                    {
                        listaSearchReserva.Add(adapter);
                    }
                }

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
                    lbErrorReserva.Visible = false;
                    lbErrorSearchReserva.Visible = true;
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
        }
    }
}