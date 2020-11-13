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
            //Validación de Session Iniciada
            LOGIN adm = (LOGIN)Session["adm"];
            LOGIN conserje = (LOGIN)Session["conserje"];
            LOGIN vendedor = (LOGIN)Session["vendedor"];
            LOGIN propietario = (LOGIN)Session["login"];
            LOGIN admCondominio = (LOGIN)Session["admCondominio"];
            if (adm == null && conserje == null && vendedor == null && propietario == null && admCondominio == null)
            {
                Response.Redirect("~/Vista/Index.aspx");
            }

            if (!IsPostBack)
            {
                if (adm != null)
                {
                    buscarDatos(adm.FK_RUT);
                }
                else if (conserje != null)
                {
                    buscarDatos(conserje.FK_RUT);
                }
                else if (vendedor != null)
                {
                    buscarDatos(vendedor.FK_RUT);
                }
                else if (propietario != null)
                {
                    buscarDatos(propietario.FK_RUT);
                }
                else
                {
                    buscarDatos(admCondominio.FK_RUT);
                }
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