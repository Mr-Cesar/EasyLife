using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EasyLife.Vista
{
    public partial class RegistroReservaPropietario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                long propietario = 4;
                persona = propietario;
                cargarDepartamento(propietario);
            }
        }

        private static long persona;

        public void cargarDepartamento(long propietario)
        {
            List<DEPARTAMENTO> listaDepartamento = Controller.ControllerDepartamento.listaDepartamentoPersona(propietario);
            dplDepartamento.DataSource = listaDepartamento;
            dplDepartamento.DataValueField = "ID_DEPARTAMENTO";
            dplDepartamento.DataTextField = "NUMERO_DEP";
            dplDepartamento.DataBind();
            dplDepartamento.Items.Insert(0, "Seleccione un Departamento");
            dplDepartamento.SelectedIndex = 0;
        }

        protected void dplDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                long departamento = Convert.ToInt64(dplDepartamento.SelectedValue);
                DEPARTAMENTO aux = Controller.ControllerDepartamento.buscarIdDepartamento(departamento);
                List<CENTRO> listaCI = Controller.ControllerCentro.listaCentroEdificio(aux.ID_EDIFICIO);
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
                dplCentro.SelectedIndex = 0;
                dplDia.SelectedIndex = 0;
                dplHorario.SelectedIndex = 0;
                lbTotal.Text = "";
                System.Diagnostics.Debug.WriteLine("Error:  " + ex);
            }
        }

        protected void dplCentro_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                long centro = Convert.ToInt64(dplCentro.SelectedValue);
                CENTRO aux = Controller.ControllerCentro.buscarIdCentro(centro);
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
                lbTotal.Text = aux.COSTO.ToString();
            }
            catch (Exception ex)
            {
                dplDia.SelectedIndex = 0;
                dplHorario.SelectedIndex = 0;
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
                System.Diagnostics.Debug.WriteLine("Error:  " + ex);
            }
        }

        protected void btnRegistroReserva_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            string resultBoleta = Controller.ControllerBoleta.crearBoletaReserva(persona, Convert.ToInt32(lbTotal.Text), Convert.ToInt64(dplDepartamento.SelectedValue));
            if (resultBoleta.Equals("Boleta Creada"))
            {
                BOLETA boleta = Controller.ControllerBoleta.buscarBoletaReserva(persona, Convert.ToInt64(dplDepartamento.SelectedValue), Convert.ToInt32(lbTotal.Text));
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
            }
        }
    }
}