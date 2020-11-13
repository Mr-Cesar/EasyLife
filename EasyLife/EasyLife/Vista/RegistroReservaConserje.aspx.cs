using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EasyLife.Vista
{
    public partial class RegistroReservaConserje : System.Web.UI.Page
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
                    personal = adm.ID_PERSONA;
                }
                else if (conserje != null)
                {
                    cargarEdificioConserje(conserje.ID_PERSONA);
                    personal = conserje.ID_PERSONA;
                }
                else
                {
                    cargarCondominioAdministrador(admCondominio.ID_PERSONA);
                    personal = admCondominio.ID_PERSONA;
                }
            }

            /*if (!IsPostBack)
            {
                cargarCondominio();
                personal = 1;
            }*/
        }

        private static List<Adapter.AdapterReserva> listaReserva = new List<Adapter.AdapterReserva>();
        private static Adapter.AdapterReserva reservaUpdate = new Adapter.AdapterReserva();
        private static long personal;

        public void cargarCondominio()
        {
            panelAdm.Visible = true;
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
            panelAdm.Visible = true;
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
            panelAdm.Visible = false;
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
            }
            catch (Exception ex)
            {
                dplEdificio.SelectedIndex = 0;
                dplDepartamento.SelectedIndex = 0;
                dplCentro.SelectedIndex = 0;
                dplDia.SelectedIndex = 0;
                dplHorario.SelectedIndex = 0;
                System.Diagnostics.Debug.WriteLine("Error: " + ex);
            }
        }

        protected void dplEdificio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                long edificio = Convert.ToInt64(dplEdificio.SelectedValue);
                System.Diagnostics.Debug.WriteLine("edificio: " + edificio);
                List<DEPARTAMENTO> listaDep = Controller.ControllerDepartamento.listaDepartamentoOcupado(edificio);
                dplDepartamento.DataSource = listaDep;
                dplDepartamento.DataValueField = "ID_DEPARTAMENTO";
                dplDepartamento.DataTextField = "NUMERO_DEP";
                dplDepartamento.DataBind();
                dplDepartamento.Items.Insert(0, "Seleccione un Departamento");
                dplDepartamento.SelectedIndex = 0;
                System.Diagnostics.Debug.WriteLine("dep: " + listaDep.Count);

                List<CENTRO> listaCI = Controller.ControllerCentro.listaCentroEdificio(edificio);
                dplCentro.DataSource = listaCI;
                dplCentro.DataValueField = "ID_CENTRO";
                dplCentro.DataTextField = "NOMBRE_CENTRO";
                dplCentro.DataBind();
                dplCentro.Items.Insert(0, "Seleccione un Centro");
                dplCentro.SelectedIndex = 0;

                lbTotal.Text = "";
            }
            catch (Exception ex)
            {
                dplDepartamento.SelectedIndex = 0;
                dplCentro.SelectedIndex = 0;
                dplDia.SelectedIndex = 0;
                dplHorario.SelectedIndex = 0;
                lbTotal.Text = "";
                System.Diagnostics.Debug.WriteLine("Error: " + ex);
            }
        }

        protected void dplDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                listaReserva = new List<Adapter.AdapterReserva>();
                long departamento = Convert.ToInt64(dplDepartamento.SelectedValue);
                listaReserva = Controller.ControllerReservaCentro.listadoReservaDepartamento(departamento);
                lbReserva.Visible = true;
                grReserva.DataSource = listaReserva;
                grReserva.DataBind();
                lbTotal.Text = "";
            }
            catch (Exception ex)
            {
                listaReserva = new List<Adapter.AdapterReserva>();
                lbReserva.Visible = false;
                grReserva.DataSource = listaReserva;
                grReserva.DataBind();
                lbTotal.Text = "";
                System.Diagnostics.Debug.WriteLine("Error " + ex);
            }
        }

        protected void grReserva_SelectedIndexChanged(object sender, EventArgs e)
        {
            reservaUpdate = new Adapter.AdapterReserva();
            GridViewRow gvr = grReserva.SelectedRow;
            long reserva = (long)grReserva.DataKeys[gvr.RowIndex].Value;
            foreach (Adapter.AdapterReserva item in listaReserva)
            {
                if (item._ID_RESERVA_CENTRO == reserva)
                {
                    reservaUpdate = item;
                    break;
                }
            }
            btnRegistroReserva.Visible = false;
            btnModificarReserva.Visible = true;

            DEPARTAMENTO departamento = Controller.ControllerDepartamento.buscarIdDepartamento(reservaUpdate._ID_DEPARTAMENTO);

            List<CENTRO> listaCI = Controller.ControllerCentro.listaCentroEdificio(departamento.ID_EDIFICIO);
            dplCentro.DataSource = listaCI;
            dplCentro.DataValueField = "ID_CENTRO";
            dplCentro.DataTextField = "NOMBRE_CENTRO";
            dplCentro.DataBind();
            dplCentro.Items.Insert(0, "Seleccione un Centro");
            dplCentro.SelectedIndex = 0;

            List<HORARIO_CENTRO> listaC = Controller.ControllerHorarioCentro.listadoHorario(reservaUpdate._ID_CENTRO);
            foreach (HORARIO_CENTRO item in listaC)
            {
                DateTime dia = Convert.ToDateTime(item.DIA_HORARIO);
                item.DIA_HORARIO = dia.ToString("dd/MM/yyy");
            }
            dplDia.DataSource = listaC;
            dplDia.DataValueField = "ID_HORARIO_CENTRO";
            dplDia.DataTextField = "DIA_HORARIO";
            dplDia.DataBind();
            dplDia.Items.Insert(0, "Seleccione un Dia");
            dplDia.SelectedIndex = 0;

            HORARIO_CENTRO aux = Controller.ControllerHorarioCentro.buscarIdHorarioCentro(reservaUpdate._ID_HORARIO_CENTRO);
            List<HORARIO_CENTRO> listaHorario = Controller.ControllerHorarioCentro.listadoHorarioDia(reservaUpdate._ID_CENTRO, aux.DIA_HORARIO);
            dplHorario.DataSource = listaHorario;
            dplHorario.DataValueField = "ID_HORARIO_CENTRO";
            dplHorario.DataTextField = "HORARIO_COMPLETO";
            dplHorario.DataBind();
            dplHorario.Items.Insert(0, "Seleccione un Horario");
            dplHorario.SelectedIndex = 0;

            dplCentro.SelectedValue = reservaUpdate._ID_CENTRO.ToString();
            dplDia.SelectedValue = reservaUpdate._ID_HORARIO_CENTRO.ToString();
            dplHorario.SelectedValue = reservaUpdate._ID_HORARIO_CENTRO.ToString();
            lbTotal.Text = reservaUpdate._COSTO_BOLETA.ToString();
        }

        protected void grReserva_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grReserva.PageIndex = e.NewPageIndex;
            grReserva.DataSource = listaReserva;
            grReserva.DataBind();
        }

        protected void dplCentro_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                long centro = Convert.ToInt64(dplCentro.SelectedValue);
                List<HORARIO_CENTRO> listaC = Controller.ControllerHorarioCentro.listadoHorario(centro);
                foreach (HORARIO_CENTRO item in listaC)
                {
                    DateTime dia = Convert.ToDateTime(item.DIA_HORARIO);
                    item.DIA_HORARIO = dia.ToString("dd/MM/yyy");
                }
                dplDia.DataSource = listaC;
                dplDia.DataValueField = "ID_HORARIO_CENTRO";
                dplDia.DataTextField = "DIA_HORARIO";
                dplDia.DataBind();
                dplDia.Items.Insert(0, "Seleccione un Dia");
                dplDia.SelectedIndex = 0;

                CENTRO aux = Controller.ControllerCentro.buscarIdCentro(centro);
                lbTotal.Text = aux.COSTO.ToString();
            }
            catch (Exception ex)
            {
                dplDia.SelectedIndex = 0;
                lbTotal.Text = "";
                System.Diagnostics.Debug.WriteLine("Error:  " + ex);
            }
        }

        protected void dplDia_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                long horario = Convert.ToInt64(dplDia.SelectedValue);
                long centro = Convert.ToInt64(dplCentro.SelectedValue);
                HORARIO_CENTRO aux = Controller.ControllerHorarioCentro.buscarIdHorarioCentro(horario);
                List<HORARIO_CENTRO> listaHorario = Controller.ControllerHorarioCentro.listadoHorarioDia(centro, aux.DIA_HORARIO);
                dplHorario.DataSource = listaHorario;
                dplHorario.DataValueField = "ID_HORARIO_CENTRO";
                dplHorario.DataTextField = "HORARIO_COMPLETO";
                dplHorario.DataBind();
                dplHorario.Items.Insert(0, "Seleccione un Horario");
                dplHorario.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                dplHorario.SelectedIndex = 0;
                System.Diagnostics.Debug.WriteLine("Error:  " + ex);
            }
        }

        protected void btnRegistroReserva_Click(object sender, EventArgs e)
        {
            /*System.Threading.Thread.Sleep(5000);
            string resultBoleta = Controller.ControllerBoleta.crearBoletaReserva(personal, Convert.ToInt32(lbTotal.Text), Convert.ToInt64(dplDepartamento.SelectedValue));
            if (resultBoleta.Equals("Boleta Creada"))
            {
                BOLETA boleta = Controller.ControllerBoleta.buscarBoletaReserva(personal, Convert.ToInt64(dplDepartamento.SelectedValue), Convert.ToInt32(lbTotal.Text));
                string resultReserva = Controller.ControllerReservaCentro.crearReserva(Convert.ToInt64(dplDepartamento.SelectedValue),
                    Convert.ToInt64(dplCentro.SelectedValue), Convert.ToInt64(dplHorario.SelectedValue), boleta.ID_BOLETA);
                if (resultReserva.Equals("Reserva Creada"))
                {
                    string resultEstado = Controller.ControllerHorarioCentro.modificarEstadoHorario(Convert.ToInt64(dplHorario.SelectedValue), false);
                    if (resultEstado.Equals("Estado Horario Modificado"))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Reserva Registrada');window.location.href='" + Request.RawUrl + "';", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Error al Cambiar Estado Horario');window.location.href='" + Request.RawUrl + "';", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Error al Ingresar Reserva');window.location.href='" + Request.RawUrl + "';", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Error al Ingresar Boleta');window.location.href='" + Request.RawUrl + "';", true);
            }*/
        }

        protected void btnModificarReserva_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            long centro = reservaUpdate._ID_CENTRO;
            long horario = reservaUpdate._ID_HORARIO_CENTRO;
            Boolean cambio = false;
            string resultCambio = "";
            if (centro == Convert.ToInt64(dplCentro.SelectedValue))
            {
                centro = Convert.ToInt64(dplCentro.SelectedValue);
            }

            if (horario == Convert.ToInt64(dplHorario.SelectedValue))
            {
                horario = Convert.ToInt64(dplHorario.SelectedValue);
            }

            string resultReserva = Controller.ControllerReservaCentro.modificarReserva(reservaUpdate._ID_RESERVA_CENTRO, reservaUpdate._ID_DEPARTAMENTO, centro, horario);
            if (resultReserva.Equals("Reserva Modificada"))
            {
                if (cambio == true)
                {
                    resultCambio = Controller.ControllerHorarioCentro.modificarEstadoHorario(reservaUpdate._ID_HORARIO_CENTRO, true);
                    resultCambio = Controller.ControllerHorarioCentro.modificarEstadoHorario(horario, false);
                    if (resultCambio.Equals("Estado Horario Modificado"))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Reserva Modificada');window.location.href='" + Request.RawUrl + "';", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Error al Modificar Estado Horario');window.location.href='" + Request.RawUrl + "';", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Reserva Modificada');window.location.href='" + Request.RawUrl + "';", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Error al Modificar Reserva');window.location.href='" + Request.RawUrl + "';", true);
            }
        }
    }
}