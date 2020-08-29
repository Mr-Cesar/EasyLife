using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EasyLife.Vista
{
    public partial class RegistroEstacionamiento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                long persona = 2;
                cargarEdificio(persona);

                string registroSalida = (string)Session["SalidaEst"];
                if (registroSalida != null)
                {
                    txtHoraSalida.Enabled = true;
                    idEstacionamiento = registroSalida;
                    cargarParametros(registroSalida);
                }
            }
        }

        private static string idEstacionamiento = "";
        private static int total;

        public void cargarEdificio(long persona)
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

        public void cargarParametros(string estacionamiento)
        {
            ESTACIONAMIENTO_VISITA aux = Controller.ControllerEstacionamientoVisita.buscarIdEstacionamiento(Convert.ToInt64(estacionamiento));
            dplEdificio.SelectedValue = aux.EDIFICIO.ToString();
            txtPatente.Text = aux.PATENTE;
            txtHoraEntrada.Text = aux.HORA_ENTRADA;
            btnRegistroEst.Visible = false;
            btnRegistroSalida.Visible = true;
        }

        protected void dplEdificio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                long edificio = Convert.ToInt64(dplEdificio.SelectedValue);
                List<DEPARTAMENTO> listaEdificio = Controller.ControllerDepartamento.listaDepartamentoOcupado(edificio);
                dplDepartamento.DataSource = listaEdificio;
                dplDepartamento.DataValueField = "ID_DEPARTAMENTO";
                dplDepartamento.DataTextField = "NUMERO_DEP";
                dplDepartamento.DataBind();
                dplDepartamento.Items.Insert(0, "Seleccione un Departamento");
                dplDepartamento.SelectedIndex = 0;
                txtPatente.Text = "";
                txtHoraEntrada.Text = "";
                txtHoraSalida.Text = "";
            }
            catch (Exception ex)
            {
                dplDepartamento.Items.Insert(0, "Seleccione un Departamento");
                dplDepartamento.SelectedIndex = 0;
                txtPatente.Text = "";
                txtHoraEntrada.Text = "";
                txtHoraSalida.Text = "";
                System.Diagnostics.Debug.WriteLine("Error  " + ex);
            }
        }

        protected void txtHoraSalida_TextChanged(object sender, EventArgs e)
        {
            EDIFICIO edificio = Controller.ControllerEdificio.buscarIdEdificio(Convert.ToInt64(idEstacionamiento));
            CONDOMINIO condominio = Controller.ControllerCondominio.buscarIdCondominio(edificio.ID_CONDOMINIO);
            int precio = condominio.PRECIO_EST;

            DateTime horaE = Convert.ToDateTime(txtHoraEntrada.Text);
            DateTime horaS = Convert.ToDateTime(txtHoraSalida.Text);
            TimeSpan diferencia = horaS.Subtract(horaE);
            total = precio * diferencia.Hours;
            if (total < 0)
            {
                total = 0;
            }
            lbTotal.Text = total.ToString();
        }

        protected void btnRegistroEst_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            DEPARTAMENTO departamento = Controller.ControllerDepartamento.buscarIdDepartamento(Convert.ToInt64(dplDepartamento.SelectedValue));
            DateTime day = DateTime.Now;
            string patente = txtPatente.Text;
            string horaE = day.ToString("dd/MMM/yyy") + " " + txtHoraEntrada.Text;
            total = 0;
            string result = Controller.ControllerEstacionamientoVisita.crearEstacionamiento(departamento.NUMERO_DEP, Convert.ToInt64(dplEdificio.SelectedValue),
                patente, horaE, total);
            if (result.Equals("Estacionamiento Creado"))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Estacionamiento Registrado');window.location.href='" + Request.RawUrl + "';", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Error al Registrar Estacionamiento');window.location.href='" + Request.RawUrl + "';", true);
            }
        }

        protected void btnRegistroSalida_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            long estacionamiento = Convert.ToInt64(idEstacionamiento);
            LOGIN conserje = (LOGIN)Session["conserje"];
            string resultBoleta = Controller.ControllerBoleta.crearBoletaEst(estacionamiento, conserje.ID_PERSONA, total);
            if (resultBoleta.Equals("Boleta Creada"))
            {
                BOLETA boleta = Controller.ControllerBoleta.buscarBoletaEst(estacionamiento);
                DateTime day = DateTime.Now;
                string patente = txtPatente.Text;
                string horaS = day.ToString("dd/MMM/yyy") + " " + txtHoraSalida.Text;
                string resultEst = Controller.ControllerEstacionamientoVisita.salidaEstacionamiento(estacionamiento, boleta.ID_BOLETA, horaS, total, false);
                if (resultEst.Equals("Salida Registrada"))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Salida Estacionamiento Registrado');window.location.href='" + Request.RawUrl + "';", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Error al Registrar Estacionamiento');window.location.href='" + Request.RawUrl + "';", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Error al Registrar Salida Estacionamiento');window.location.href='" + Request.RawUrl + "';", true);
            }
        }
    }
}