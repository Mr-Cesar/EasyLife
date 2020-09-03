using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EasyLife.Vista
{
    public partial class RegistroPersonal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validación de Session Iniciada
            LOGIN adm = (LOGIN)Session["adm"];
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
                cargarRol();
                cargarCondominio();

                string updatePersonal = (string)Session["ModificarPersonal"];
                if (updatePersonal != null)
                {
                    cargarParametros(updatePersonal);
                }
            }
        }

        private static PERSONA updatePersonal = new PERSONA();

        public void cargarRol()
        {
            List<ROL> lista = Controller.ControllerRol.listaRol();
            dplRol.DataSource = lista;
            dplRol.DataValueField = "ID_ROL";
            dplRol.DataTextField = "DESCRIPCION_ROL";
            dplRol.DataBind();
            dplRol.Items.Insert(0, "Seleccione un Rol");
            dplRol.Items.RemoveAt(4);
            dplRol.SelectedIndex = 0;
        }

        public void cargarCondominio()
        {
            List<CONDOMINIO> listaC = Controller.ControllerCondominio.listaCondominiosLibres();
            dplCondominio.DataSource = listaC;
            dplCondominio.DataValueField = "ID_CONDOMINIO";
            dplCondominio.DataTextField = "NOMBRE_CONDOMINIO";
            dplCondominio.DataBind();
            dplCondominio.Items.Insert(0, "Seleccione un Condominio");
            dplCondominio.SelectedIndex = 0;
        }

        public void cargarCondominioTotal()
        {
            List<CONDOMINIO> listaC = Controller.ControllerCondominio.listaCondominio();
            dplCondominio.DataSource = listaC;
            dplCondominio.DataValueField = "ID_CONDOMINIO";
            dplCondominio.DataTextField = "NOMBRE_CONDOMINIO";
            dplCondominio.DataBind();
            dplCondominio.Items.Insert(0, "Seleccione un Condominio");
            dplCondominio.SelectedIndex = 0;
        }

        public void cargarParametros(string personal)
        {
            lbOpcion.Text = "Modificar Personal";
            PERSONA persona = Controller.ControllerPersona.buscarIdPersona(Convert.ToInt64(personal));
            dplRol.SelectedValue = persona.ID_ROL.ToString();
            txtRut.Text = persona.FK_RUT;
            txtNombre.Text = persona.NOMBRE_PERSONA;
            txtApellido.Text = persona.APELLIDO_PERSONA;
            txtTelefono.Text = persona.TELEFONO_PERSONA;
            txtEmail.Text = persona.CORREO_PERSONA;
            if (persona.SEXO.Equals("M"))
            {
                radioSexo.SelectedIndex = 0;
            }
            else
            {
                radioSexo.SelectedIndex = 1;
            }
            btnRegistroPersonal.Visible = false;
            btnModificarPersonal.Visible = true;
            panelCondominio.Visible = false;
            updatePersonal = persona;
        }

        protected void dplRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                long rol = Convert.ToInt64(dplRol.SelectedValue);
                if (rol == 5)
                {
                    RequiredFieldValidator10.Enabled = false;
                    RequiredFieldValidator10.Visible = false;
                    panelCondominio.Visible = true;
                    cargarCondominio();
                }
                else if (rol == 2)
                {
                    panelCondominio.Visible = true;
                    cargarCondominioTotal();
                }
                else
                {
                    panelCondominio.Visible = false;
                }
            }
            catch (Exception ex)
            {
                RequiredFieldValidator10.Enabled = true;
                RequiredFieldValidator10.Visible = true;
                panelCondominio.Visible = false;
                System.Diagnostics.Debug.WriteLine("Error " + ex);
            }
        }

        protected void btnRegistroPersonal_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            long rol = Convert.ToInt64(dplRol.SelectedValue);
            string sexo = radioSexo.SelectedValue;
            long condominio = 0;
            string resultAsignar = "";
            PERSONA aux = new PERSONA();
            if (rol == 2 || rol == 5)
            {
                condominio = Convert.ToInt64(dplCondominio.SelectedValue);
            }
            string resultPersona = Controller.ControllerPersona.crearPersona(rol, txtNombre.Text, txtApellido.Text, txtRut.Text, txtTelefono.Text,
                txtEmail.Text, false, sexo);
            if (resultPersona.Equals("Persona Creada"))
            {
                if (rol == 2)
                {
                    aux = Controller.ControllerPersona.buscarPersonaRut(txtRut.Text);
                    resultAsignar = Controller.ControllerConserje.crearConserje(aux.ID_PERSONA, condominio);
                }
                else if (rol == 5)
                {
                    aux = Controller.ControllerPersona.buscarPersonaRut(txtRut.Text);
                    resultAsignar = Controller.ControllerCondominio.asignarAdministradorCondominio(aux.ID_PERSONA, condominio);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Usuario Registrado Correctamente');window.location.href='" + Request.RawUrl + "';", true);
                }

                if (resultAsignar.Equals("Personal Asignado") || resultAsignar.Equals("Conserje Creado"))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Usuario Registrado Correctamente');window.location.href='" + Request.RawUrl + "';", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Usuario ya Existe');window.location.href='" + Request.RawUrl + "';", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Usuario ya Existe');window.location.href='" + Request.RawUrl + "';", true);
            }
        }

        protected void btnModificarPersonal_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            long rol = Convert.ToInt64(dplRol.SelectedValue);
            string rut = txtRut.Text;
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string telefono = txtTelefono.Text;
            string correo = txtEmail.Text;
            string sexo = radioSexo.SelectedValue;

            string resultUpdate = Controller.ControllerPersona.modificarPersonal(updatePersonal.ID_PERSONA, rol, nombre, apellido, rut, telefono, correo, sexo);
            if (resultUpdate.Equals("Persona Modificada"))
            {
                updatePersonal = new PERSONA();
                Session["ModificarPersonal"] = null;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Personal Modificado');window.location.href='" + Request.RawUrl + "';", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Error al Modificar Personal');window.location.href='" + Request.RawUrl + "';", true);
            }
        }
    }
}