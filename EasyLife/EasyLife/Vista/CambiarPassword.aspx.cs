using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EasyLife.Vista
{
    public partial class CambiarPassword : System.Web.UI.Page
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
                Response.Redirect("Index.aspx");
            }
        }

        protected void btnCambioPassword_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            if (txtAPassword.Text.Equals(txtPassword.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Password Nueva es igual a la Antigua');window.location.href='" + Request.RawUrl + "';", true);
            }
            else
            {
                LOGIN prop = (LOGIN)Session["login"];
                LOGIN adm = (LOGIN)Session["adm"];
                LOGIN conserje = (LOGIN)Session["conserje"];
                LOGIN vendedor = (LOGIN)Session["vendedor"];
                LOGIN admCondominio = (LOGIN)Session["admCondominio"];
                string rut = "";
                if (prop != null)
                {
                    rut = prop.FK_RUT;
                }
                else if (adm != null)
                {
                    rut = adm.FK_RUT;
                }
                else if (conserje != null)
                {
                    rut = conserje.FK_RUT;
                }
                else if (vendedor != null)
                {
                    rut = vendedor.FK_RUT;
                }
                else if (admCondominio != null)
                {
                    rut = admCondominio.FK_RUT;
                }

                cambiarPasword(rut, txtAPassword.Text, txtPassword.Text);
            }
        }

        public void cambiarPasword(string rut, string passActual, string newPass)
        {
            string result = Controller.ControllerLogin.modificarPassword(rut, passActual, newPass);
            if (result.Equals("Password Cambiada"))
            {
                Session["CambioPassword"] = null;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Password Cambiada');window.location.href='" + Request.RawUrl + "';", true);
                Response.Redirect("Index.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Error de Sistema Contactese con Administracion');window.location.href='" + Request.RawUrl + "';", true);
            }
        }
    }
}