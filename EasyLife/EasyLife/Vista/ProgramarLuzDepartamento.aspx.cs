using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using System.ComponentModel;

namespace EasyLife.Vista
{
    public partial class ProgramarLuzDepartamento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validación de Session Iniciada
            LOGIN adm = (LOGIN)Session["adm"];
            LOGIN conserje = (LOGIN)Session["conserje"];
            LOGIN vendedor = (LOGIN)Session["vendedor"];
            LOGIN propietario = (LOGIN)Session["login"];
            LOGIN admCondominio = (LOGIN)Session["admCondominio"];
            if (adm != null || conserje != null || vendedor != null || admCondominio != null)
            {
                Response.Redirect("Index.aspx");
            }
            else if (adm == null && conserje == null && vendedor == null && propietario == null && admCondominio == null)
            {
                Response.Redirect("Index.aspx");
            }

            //Recuperar Session de Modificar Control
            string modificar = (string)Session["ModificarControlIluminacionDep"];

            if (!IsPostBack)
            {
                cargarDepartamentoPropietario(propietario.ID_PERSONA);
                if (modificar != null)
                {
                    cargarControl(modificar);
                }
            }

            /*if (!IsPostBack)
            {
                long propietario = 4;
                cargarDepartamentoPropietario(propietario);
            }*/
        }

        private static CONTROL_ILUMINACION_DEPARTAMENTO controlDep = new CONTROL_ILUMINACION_DEPARTAMENTO();

        public void cargarDepartamentoPropietario(long propietario)
        {
            List<DEPARTAMENTO> listaDep = Controller.ControllerDepartamento.listaDepartamentoPersona(propietario);
            dplDepartamento.DataSource = listaDep;
            dplDepartamento.DataValueField = "ID_DEPARTAMENTO";
            dplDepartamento.DataTextField = "NUMERO_DEP";
            dplDepartamento.DataBind();
            dplDepartamento.Items.Insert(0, "Seleccione un Departamento");
            dplDepartamento.SelectedIndex = 0;
        }

        public void cargarControl(string control)
        {
            lbOpcion.Text = "Modifiar Control de Luces";
            panelPropDep.Visible = false;
            panelEstado.Visible = false;
            controlDep = new CONTROL_ILUMINACION_DEPARTAMENTO();
            controlDep = Controller.ControllerControlIlimunacionDep.buscarIdControl(Convert.ToInt64(control));
            string año = controlDep.HORA_INICIO_D.Substring(6, 4);
            string mes = controlDep.HORA_INICIO_D.Substring(3, 2);
            string dia = controlDep.HORA_INICIO_D.Substring(0, 2);
            txtDia.Text = año + "-" + mes + "-" + dia;

            string horaI = controlDep.HORA_INICIO_D.Substring(11, 5);
            txtHoraInicio.Text = horaI;
            string horaT = controlDep.HORA_TERMINO_D.Substring(11, 5);
            txtHoraTermino.Text = horaT;

            if (controlDep.ESTADO_LUZ_CD == true)
            {
                rbOpcion.SelectedIndex = 0;
            }
            else
            {
                rbOpcion.SelectedIndex = 1;
            }
            btnProgramarLuz.Visible = false;
            btnModificarPrograma.Visible = true;
        }

        protected void dplDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                long departamento = Convert.ToInt64(dplDepartamento.SelectedValue);
                LUZ_DEPARTAMENTO luz = Controller.ControllerLuzDepartamento.buscarLuzDepartamento(departamento);
                if (luz.ESTADO_LUZ_D == true)
                {
                    lbEstado.Text = "Encendido";
                }
                else
                {
                    lbEstado.Text = "Apagado";
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error  " + ex);
            }
        }

        protected void btnEncenderLuz_Click(object sender, EventArgs e)
        {
            Controller.ControllerControlIlimunacionDep control = new Controller.ControllerControlIlimunacionDep();
            control.prenderLuz();
        }

        protected void btnApagarLuz_Click(object sender, EventArgs e)
        {
            Controller.ControllerControlIlimunacionDep control = new Controller.ControllerControlIlimunacionDep();
            control.apagarLuz();
        }

        protected void btnProgramarLuz_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            DateTime dia = Convert.ToDateTime(txtDia.Text);
            string horaI = txtHoraInicio.Text;
            string horaT = txtHoraTermino.Text;
            int operacion = rbOpcion.SelectedIndex;
            Boolean opcion = new Boolean();
            DEPARTAMENTO departamento = Controller.ControllerDepartamento.buscarIdDepartamento(Convert.ToInt64(dplDepartamento.SelectedValue));
            if (operacion == 0)
            {
                opcion = true;
            }
            else
            {
                opcion = false;
            }
            string horaInicio = dia.ToString("dd/MM/yyy") + " " + horaI;
            string horaTermino = dia.ToString("dd/MM/yyy") + " " + horaT;
            string result = Controller.ControllerControlIlimunacionDep.crearControlDep(Convert.ToInt64(departamento.ID_LUZ_D), horaInicio, horaTermino, opcion);
            if (result.Equals("Control Creado"))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Control Creado');window.location.href='" + Request.RawUrl + "';", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Error al Crear Control');window.location.href='" + Request.RawUrl + "';", true);
            }
        }

        protected void btnModificarPrograma_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            DateTime dia = Convert.ToDateTime(txtDia.Text);
            string horaI = txtHoraInicio.Text;
            string horaT = txtHoraTermino.Text;
            int operacion = rbOpcion.SelectedIndex;
            Boolean opcion = new Boolean();
            if (operacion == 0)
            {
                opcion = true;
            }
            else
            {
                opcion = false;
            }
            string horaInicio = dia.ToString("dd/MM/yyy") + " " + horaI;
            string horaTermino = dia.ToString("dd/MM/yyy") + " " + horaT;
            string result = Controller.ControllerControlIlimunacionDep.modificarControlDep(controlDep.ID_CILUMINACION_D, controlDep.ID_LUZ_D,
                horaInicio, horaTermino, opcion);
            if (result.Equals("Control Modificado"))
            {
                Session["ModificarControlIluminacionDep"] = null;
                panelPropDep.Visible = true;
                panelEstado.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Control Modificado');window.location.href='" + Request.RawUrl + "';", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Error al Modificado Control');window.location.href='" + Request.RawUrl + "';", true);
            }
        }
    }
}