using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EasyLife.Vista
{
    public partial class RegistroPropietario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarCondominio();

                string updatePropietario = (string)Session["ModificarPropietario"];
                if (updatePropietario != null)
                {
                    cargarParametros(updatePropietario);
                }
            }
        }

        private static List<Adapter.AdapterDepartamento> listaDepartamento = new List<Adapter.AdapterDepartamento>();
        private static PERSONA persona = new PERSONA();

        public void cargarCondominio()
        {
            List<CONDOMINIO> lista = Controller.ControllerCondominio.listaCondominio();
            dplCondominio.DataSource = lista;
            dplCondominio.DataValueField = "ID_CONDOMINIO";
            dplCondominio.DataTextField = "NOMBRE_CONDOMINIO";
            dplCondominio.DataBind();
            dplCondominio.Items.Insert(0, "Seleccione un Condominio");
            dplCondominio.SelectedIndex = 0;
            dplEdificio.Items.Insert(0, "Seleccione un Edificio");
            dplEdificio.SelectedIndex = 0;
            dplDepartamento.Items.Insert(0, "Seleccione un Departamento");
            dplDepartamento.SelectedIndex = 0;
            listaDepartamento = new List<Adapter.AdapterDepartamento>();
        }

        public void cargarParametros(string propietario)
        {
            lbOpcion.Text = "Modificar Propietario";
            panelProp.Visible = false;
            btnAgregarDepartamento.Visible = false;
            btnRegistroPropietario.Visible = false;
            btnModificarPropietario.Visible = true;
            listaDepartamento = Controller.ControllerDepartamento.listaAdapterDepartamentoPersona(Convert.ToInt64(propietario));
            grDepartamento.Columns[3].Visible = false;
            grDepartamento.DataSource = listaDepartamento;
            grDepartamento.DataBind();
            persona = Controller.ControllerPersona.buscarIdPersona(Convert.ToInt64(propietario));
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

            if (persona.LUZ == true)
            {
                dplLuz.SelectedIndex = 1;
            }
            else
            {
                dplLuz.SelectedIndex = 2;
            }
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
                dplEdificio.Items.Insert(0, "Seleccione un Edificio");
                dplEdificio.SelectedIndex = 0;
                dplDepartamento.Items.Insert(0, "Seleccione un Departamento");
                dplDepartamento.SelectedIndex = 0;
                System.Diagnostics.Debug.WriteLine("Error: " + ex);
            }
        }

        protected void dplEdificio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                long edificio = Convert.ToInt64(dplEdificio.SelectedValue);
                List<DEPARTAMENTO> listaDep = Controller.ControllerDepartamento.listaDepartamentoLibre(edificio);
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

        protected void btnAgregarDepartamento_Click(object sender, EventArgs e)
        {
            Adapter.AdapterDepartamento adapter = new Adapter.AdapterDepartamento();
            lbError.Visible = false;
            Boolean operation = true;
            if (listaDepartamento.Count > 0)
            {
                foreach (Adapter.AdapterDepartamento item in listaDepartamento)
                {
                    if (item._ID_DEPARTAMENTO == Convert.ToInt64(dplDepartamento.SelectedValue))
                    {
                        lbError.Visible = true;
                        lbError.Text = "Departamento ya Asignado";
                        operation = false;
                    }
                }
            }

            if (operation == true)
            {
                lbError.Visible = false;
                CONDOMINIO condominio = Controller.ControllerCondominio.buscarIdCondominio(Convert.ToInt64(dplCondominio.SelectedValue));
                EDIFICIO edificio = Controller.ControllerEdificio.buscarIdEdificio(Convert.ToInt64(dplEdificio.SelectedValue));
                DEPARTAMENTO departamento = Controller.ControllerDepartamento.buscarIdDepartamento(Convert.ToInt64(dplDepartamento.SelectedValue));
                adapter._ID_CONDOMINIO = condominio.ID_CONDOMINIO;
                adapter._NOMBRE_CONDOMINIO = condominio.NOMBRE_CONDOMINIO;
                adapter._ID_EDIFICIO = edificio.ID_EDIFICIO;
                adapter._NOMBRE_EDIFICIO = edificio.NOMBRE_EDIFICIO;
                adapter._ID_DEPARTAMENTO = departamento.ID_DEPARTAMENTO;
                adapter._NUMERO_DEP = departamento.NUMERO_DEP;
                listaDepartamento.Add(adapter);
                grDepartamento.DataSource = listaDepartamento;
                grDepartamento.DataBind();
                dplCondominio.SelectedIndex = 0;
                dplEdificio.SelectedIndex = 0;
                dplDepartamento.SelectedIndex = 0;
            }
        }

        protected void grDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = grDepartamento.SelectedIndex;
            listaDepartamento.RemoveAt(index);
            grDepartamento.DataSource = listaDepartamento;
            grDepartamento.DataBind();
        }

        protected void grDepartamento_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grDepartamento.PageIndex = e.NewPageIndex;
            grDepartamento.DataSource = listaDepartamento;
            grDepartamento.DataBind();
        }

        protected void btnRegistroPropietario_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            persona = new PERSONA();
            string resultPropietario = "";
            string resultDepartamento = "";
            long rol = 4;
            Boolean luz = false;
            string opcion = dplLuz.SelectedValue;
            if (opcion.Equals("Si"))
            {
                luz = true;
            }

            if (listaDepartamento.Count > 0)
            {
                resultPropietario = Controller.ControllerPersona.crearPersona(rol, txtNombre.Text, txtApellido.Text, txtRut.Text, txtTelefono.Text, txtEmail.Text, luz,
                radioSexo.SelectedValue);

                if (resultPropietario.Equals("Persona Creada"))
                {
                    persona = Controller.ControllerPersona.buscarPersonaRut(txtRut.Text);
                    foreach (Adapter.AdapterDepartamento item in listaDepartamento)
                    {
                        resultDepartamento = Controller.ControllerDepartamento.asignarDepartamentoPropietario(persona.ID_PERSONA, item._ID_DEPARTAMENTO);
                    }
                    if (resultDepartamento.Equals("Departamento Asignado"))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Propietario Registrado');window.location.href='" + Request.RawUrl + "';", true);
                        persona = new PERSONA();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Error al Asignar Departamento');window.location.href='" + Request.RawUrl + "';", true);
                    }
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('No ha Registrado Ningun Departamento');window.location.href='" + Request.RawUrl + "';", true);
            }
        }

        protected void btnModificarPropietario_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            long idpersona = persona.ID_PERSONA;
            string rut = txtRut.Text;
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string telefono = txtTelefono.Text;
            string correo = txtEmail.Text;
            string sexo = radioSexo.SelectedValue;
            Boolean luz = true;

            if (dplLuz.SelectedValue.Equals("Si"))
            {
                luz = true;
            }
            else
            {
                luz = false;
            }

            string resultPersona = Controller.ControllerPersona.modificarPersona(idpersona, nombre, apellido, rut, telefono, correo, sexo, luz);
            if (resultPersona.Equals("Propietario Modificada"))
            {
                Session["ModificarPropietario"] = null; ;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Usuario Modificado Correctamente');window.location.href='" + Request.RawUrl + "';", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Usuario no Existe');window.location.href='" + Request.RawUrl + "';", true);
            }
        }
    }
}