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
            //Validación de Session Iniciada
            LOGIN adm = (LOGIN)Session["adm"];
            LOGIN conserje = (LOGIN)Session["conserje"];
            LOGIN vendedor = (LOGIN)Session["vendedor"];
            LOGIN propietario = (LOGIN)Session["login"];
            LOGIN admCondominio = (LOGIN)Session["admCondominio"];
            if (vendedor != null || propietario != null)
            {
                Response.Redirect("Index.aspx");
            }
            else if (adm == null && conserje == null && vendedor == null && propietario == null && admCondominio == null)
            {
                Response.Redirect("Index.aspx");
            }

            if (!IsPostBack)
            {
                cargarEdificio(conserje.ID_PERSONA);

                string registroSalida = (string)Session["ModificarEstacionamiento"];
                if (registroSalida != null)
                {
                    txtHoraSalida.Enabled = true;
                    idEstacionamiento = registroSalida;
                    cargarParametros(registroSalida);
                }
            }

            /*if (!IsPostBack)
            {
                long conserje = 2;
                cargarEdificio(conserje);

                string registroSalida = (string)Session["SalidaEst"];
                registroSalida = "8";
                if (registroSalida != null)
                {
                    txtHoraSalida.Enabled = true;
                    idEstacionamiento = registroSalida;
                    cargarParametros(registroSalida);
                }
            }*/
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
            DEPARTAMENTO dep = Controller.ControllerDepartamento.buscarDepartamento(aux.NUM_DEP, aux.EDIFICIO);
            List<DEPARTAMENTO> listaEdificio = Controller.ControllerDepartamento.listaDepartamentoOcupado(aux.EDIFICIO);
            dplDepartamento.DataSource = listaEdificio;
            dplDepartamento.DataValueField = "ID_DEPARTAMENTO";
            dplDepartamento.DataTextField = "NUMERO_DEP";
            dplDepartamento.DataBind();
            dplEdificio.SelectedValue = aux.EDIFICIO.ToString();
            dplDepartamento.SelectedValue = dep.ID_DEPARTAMENTO.ToString();
            txtPatente.Text = aux.PATENTE;

            string horaE = aux.HORA_ENTRADA.Substring(11, 5);
            txtHoraEntrada.Text = horaE;
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
            string date = DateTime.Now.Date.ToString();
            string patente = txtPatente.Text;
            string horaE = date.Substring(0, 10) + " " + txtHoraEntrada.Text;
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
                string date = DateTime.Now.Date.ToString();
                string patente = txtPatente.Text;
                string horaS = date.Substring(0, 10) + " " + txtHoraSalida.Text;
                string resultEst = Controller.ControllerEstacionamientoVisita.salidaEstacionamiento(estacionamiento, boleta.ID_BOLETA, horaS, total, false);
                if (resultEst.Equals("Salida Registrada"))
                {
                    Session["SalidaEst"] = null;
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