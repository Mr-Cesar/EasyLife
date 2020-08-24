using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EasyLife.Vista
{
    public partial class ModificarDatos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string rut = "19.484.165-5";
                buscarDatos(rut);
            }
        }

        private static PERSONA persona = new PERSONA();

        public void buscarDatos(string rut)
        {
            persona = Controller.ControllerPersona.buscarPersonaRut(rut);
            txtTelefono.Text = persona.TELEFONO_PERSONA;
            txtEmail.Text = persona.CORREO_PERSONA;
        }

        protected void btnModificarDatos_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            string telefono = txtTelefono.Text;
            string correo = txtEmail.Text;
            string result = Controller.ControllerPersona.modificarUsuario(persona.ID_PERSONA, telefono, correo);
            if (result.Equals("Persona Modificada"))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Datos Modificados');window.location.href='" + Request.RawUrl + "';", true);
                persona = new PERSONA();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Error al Modificar Datos');window.location.href='" + Request.RawUrl + "';", true);
            }
        }
    }
}