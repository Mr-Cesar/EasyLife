using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/* Referencia Configuration */

using System.Configuration;

namespace EasyLife.Vista
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validación de Session Iniciada
            LOGIN adm = (LOGIN)Session["adm"];
            LOGIN conserje = (LOGIN)Session["conserje"];
            LOGIN vendedor = (LOGIN)Session["vendedor"];
            LOGIN propietario = (LOGIN)Session["login"];
            LOGIN admCondominio = (LOGIN)Session["admCondominio"];
            if (adm != null || conserje != null || vendedor != null || propietario != null || admCondominio != null)
            {
                Response.Redirect("~/Vista/Index.aspx");
            }
        }

        protected void lnkRecuperar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Vista/RecuperarPassword.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            string cambio = "Cambiar Password";
            string defaultPass = "21-9A-FD-7F-85-14-19-7A-2F-37-EE-B2-FF-F7-B2-15";
            string key = ConfigurationManager.AppSettings["stKey"];
            LOGIN aux = Controller.ControllerLogin.loginPersona(txtRut.Text, txtPassword.Text);
            if (aux != null)
            {
                PERSONA per = Controller.ControllerPersona.buscarPersonaRut(aux.FK_RUT);
                if (per != null)
                {
                    if (per.ID_ROL == 1)
                    {
                        Session["adm"] = aux;
                        string passM = Controller.ControllerEncryption.stDecrypt(aux.PASSWORD_LOGIN, key);
                        if (passM.Equals(defaultPass))
                        {
                            Session["CambioPassword"] = cambio;
                            Response.Redirect("~/Vista/CambiarPassword.aspx");
                        }
                        else
                        {
                            Response.Redirect("~/Vista/Index.aspx");
                        }
                    }
                    else if (per.ID_ROL == 2)
                    {
                        Session["conserje"] = aux;
                        string passM = Controller.ControllerEncryption.stDecrypt(aux.PASSWORD_LOGIN, key);
                        if (passM.Equals(defaultPass))
                        {
                            Session["CambioPassword"] = cambio;
                            Response.Redirect("~/Vista/CambiarPassword.aspx");
                        }
                        else
                        {
                            Response.Redirect("~/Vista/Index.aspx");
                        }
                    }
                    else if (per.ID_ROL == 3)
                    {
                        Session["vendedor"] = aux;
                        string passM = Controller.ControllerEncryption.stDecrypt(aux.PASSWORD_LOGIN, key);
                        if (passM.Equals(defaultPass))
                        {
                            Session["CambioPassword"] = cambio;
                            Response.Redirect("~/Vista/CambiarPassword.aspx");
                        }
                        else
                        {
                            Response.Redirect("~/Vista/Index.aspx");
                        }
                    }
                    else if (per.ID_ROL == 4)
                    {
                        Session["login"] = aux;
                        string passM = Controller.ControllerEncryption.stDecrypt(aux.PASSWORD_LOGIN, key);
                        if (passM.Equals(defaultPass))
                        {
                            Session["CambioPassword"] = cambio;
                            Response.Redirect("~/Vista/CambiarPassword.aspx");
                        }
                        else
                        {
                            Response.Redirect("~/Vista/Index.aspx");
                        }
                    }
                    else if (per.ID_ROL == 5)
                    {
                        Session["admCondominio"] = aux;
                        string passM = Controller.ControllerEncryption.stDecrypt(aux.PASSWORD_LOGIN, key);
                        if (passM.Equals(defaultPass))
                        {
                            Session["CambioPassword"] = cambio;
                            Response.Redirect("~/Vista/CambiarPassword.aspx");
                        }
                        else
                        {
                            Response.Redirect("~/Vista/Index.aspx");
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Credenciales Incorrectas');window.location.href='" + Request.RawUrl + "';", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Credenciales Incorrectas');window.location.href='" + Request.RawUrl + "';", true);
            }
        }
    }
}