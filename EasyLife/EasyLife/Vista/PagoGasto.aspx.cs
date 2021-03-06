﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EasyLife.Vista
{
    public partial class PagoGasto : System.Web.UI.Page
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

            if (!IsPostBack)
            {
                cargarCondominio();
            }
        }

        private static List<Adapter.AdapterBoletaGasto> listaGastos = new List<Adapter.AdapterBoletaGasto>();
        private static long total;

        public void cargarCondominio()
        {
            panelCondominio.Visible = true;
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
            panelCondominio.Visible = true;
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
            panelCondominio.Visible = false;
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
                listaGastos = new List<Adapter.AdapterBoletaGasto>();
            }
            catch (Exception ex)
            {
                dplEdificio.Items.Insert(0, "Seleccione un Edificio");
                dplEdificio.SelectedIndex = 0;
                dplDepartamento.Items.Insert(0, "Seleccione un Departamento");
                dplDepartamento.SelectedIndex = 0;
                listaGastos = new List<Adapter.AdapterBoletaGasto>();
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
            }
            catch (Exception ex)
            {
                dplDepartamento.Items.Insert(0, "Seleccione un Departamento");
                dplDepartamento.SelectedIndex = 0;
                System.Diagnostics.Debug.WriteLine("Error: " + ex);
            }
        }

        protected void dplDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                listGastos.DataSource = null;
                listGastos.DataBind();
                long edificio = Convert.ToInt64(dplEdificio.SelectedIndex);
                string mes = DateTime.Now.ToString("MMMM");
                string año = DateTime.Now.Year.ToString();
                int costoEst = 0;
                double prorroteo = 0;
                GASTOS_COMUNES gasto = Controller.ControllerGastoComun.buscarGastoMes(edificio, mes.Substring(0, 3), año);
                DEPARTAMENTO departamento = Controller.ControllerDepartamento.buscarIdDepartamento(Convert.ToInt64(dplDepartamento.SelectedValue));
                List<MULTA> listaMultas = Controller.ControllerMulta.listaMultaNoPagadaDepartamento(Convert.ToInt64(dplDepartamento.SelectedValue));
                long multa = 0;
                foreach (MULTA item in listaMultas)
                {
                    multa = multa + item.COSTO_MULTA;
                }

                List<ESTACIONAMIENTO> listaEst = Controller.ControllerEstacionamiento.buscarEstacionamientoDepartamento(departamento.ID_DEPARTAMENTO);
                foreach (ESTACIONAMIENTO item in listaEst)
                {
                    costoEst = item.PRECIO_EST + costoEst;
                }
                prorroteo = Convert.ToDouble(departamento.PRORROTEO);
                GASTOS_COMUNES aux = new GASTOS_COMUNES();
                aux.GASTO_CONSERJE = Convert.ToInt32((gasto.GASTO_CONSERJE * prorroteo) / 100);
                aux.GASTO_GUARDIA = Convert.ToInt32((gasto.GASTO_GUARDIA * prorroteo) / 100);
                aux.GASTO_MANTENCION_AREAS = Convert.ToInt32((gasto.GASTO_MANTENCION_AREAS * prorroteo) / 100);
                aux.GASTO_CAMARAS = Convert.ToInt32((gasto.GASTO_CAMARAS * prorroteo) / 100);
                aux.GASTO_ARTICULOS_ASEO = Convert.ToInt32((gasto.GASTO_ARTICULOS_ASEO * prorroteo) / 100);
                aux.GASTOS_ASEO = Convert.ToInt32((gasto.GASTOS_ASEO * prorroteo) / 100);
                aux.GASTO_ASCENSOR = Convert.ToInt32((gasto.GASTO_ASCENSOR * prorroteo) / 100);
                aux.GASTO_AGUA_CALIENTE = Convert.ToInt32((gasto.GASTO_AGUA_CALIENTE * prorroteo) / 100);
                aux.GASTO_OTRO = Convert.ToInt32((gasto.GASTO_OTRO * prorroteo) / 100);

                List<string> listaG = new List<string>()
                {
                    "Gasto Conserje " + aux.GASTO_CONSERJE,
                    "Gasto Guardia " + aux.GASTO_GUARDIA,
                    "Gasto Mantencion Areas " + aux.GASTO_MANTENCION_AREAS,
                    "Gasto Camaras " + aux.GASTO_CAMARAS,
                    "Gastos Articulos de Aseo " + aux.GASTO_ARTICULOS_ASEO,
                    "Gasto Aseo " + aux.GASTOS_ASEO,
                    "Gasto Ascensor " + aux.GASTO_ASCENSOR,
                    "Gasto Agua Caliente " + aux.GASTO_AGUA_CALIENTE,
                    "Otros Gastos " + aux.GASTO_OTRO,
                    "Estacionamiento " + costoEst,
                    "Multa " + multa.ToString()
                };
                long total = Convert.ToInt64(gasto.TOTAL_GASTO) + multa;
                listGastos.DataSource = listaG;
                listGastos.DataBind();
            }
            catch (Exception ex)
            {
                listGastos.DataSource = null;
                listGastos.DataBind();
                System.Diagnostics.Debug.WriteLine("Error:  " + ex);
            }
        }

        protected void btnAgregarPago_Click(object sender, EventArgs e)
        {
            lbErrorRegistro.Visible = false;
            btnPagarGasto.Visible = true;
            EDIFICIO edificio = new EDIFICIO();
            GASTOS_COMUNES gasto = new GASTOS_COMUNES();
            DEPARTAMENTO departamento = new DEPARTAMENTO();
            PERSONA persona = new PERSONA();
            List<MULTA> listaMulta = Controller.ControllerMulta.listaMultaNoPagadaDepartamento(Convert.ToInt64(dplDepartamento.SelectedValue));
            long multa = 0;
            foreach (MULTA item in listaMulta)
            {
                multa = multa + item.COSTO_MULTA;
            }
            edificio = Controller.ControllerEdificio.buscarIdEdificio(Convert.ToInt64(dplEdificio.SelectedValue));
            gasto = Controller.ControllerGastoComun.buscarGastoComunEdificio(Convert.ToInt64(dplEdificio.SelectedValue));
            departamento = Controller.ControllerDepartamento.buscarIdDepartamento(Convert.ToInt64(dplDepartamento.SelectedValue));
            persona = Controller.ControllerPersona.buscarPersonaRut(txtPersona.Text);
            if (persona == null)
            {
                lbError.Visible = true;
                lbPagados.Visible = false;
            }
            else
            {
                lbError.Visible = false;
                lbPagados.Visible = true;
                Adapter.AdapterBoletaGasto pago = new Adapter.AdapterBoletaGasto();
                long totalBoleta = Convert.ToInt64(gasto.TOTAL_GASTO) + multa;

                pago._ID_GASTOS = gasto.ID_GASTOS;
                pago._ID_EDIFICIO = edificio.ID_EDIFICIO;
                pago._ID_DEPARTAMENTO = departamento.ID_DEPARTAMENTO;
                pago._FK_RUT = persona.FK_RUT;
                pago._NOMBRE_EDIFICIO = edificio.NOMBRE_EDIFICIO;
                pago._NUMERO_DEP = departamento.NUMERO_DEP;
                pago._TOTAL_GASTO = gasto.TOTAL_GASTO;
                pago._MULTA = multa;
                pago._COSTO_BOLETA = totalBoleta;

                listaGastos.Add(pago);
                grGastos.DataSource = listaGastos;
                grGastos.DataBind();
                total = total + pago._COSTO_BOLETA;
                lbTotal.Text = total.ToString();
                dplDepartamento.SelectedIndex = 0;
                listGastos.DataSource = null;
                listGastos.DataBind();
            }
        }

        protected void grGastos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = grGastos.SelectedIndex;
            Adapter.AdapterBoletaGasto aux = listaGastos[index];
            total = total - aux._COSTO_BOLETA;
            lbTotal.Text = total.ToString();
            listaGastos.RemoveAt(index);
            grGastos.DataSource = listaGastos;
            grGastos.DataBind();
            lbTotal.Text = total.ToString();
        }

        protected void grGastos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grGastos.PageIndex = e.NewPageIndex;
            grGastos.DataSource = listaGastos;
            grGastos.DataBind();
        }

        protected void btnPagarGasto_Click(object sender, EventArgs e)
        {
        }
    }
}