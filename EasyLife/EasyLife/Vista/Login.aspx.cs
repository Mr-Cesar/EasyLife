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
        }

        protected void lnkRecuperar_Click(object sender, EventArgs e)
        {
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
                            Response.Redirect("CambiarPassword.aspx");
                        }
                        else
                        {
                            Response.Redirect("Index.aspx");
                        }
                    }
                    else if (per.ID_ROL == 2)
                    {
                        Session["conserje"] = aux;
                        string passM = Controller.ControllerEncryption.stDecrypt(aux.PASSWORD_LOGIN, key);
                        if (passM.Equals(defaultPass))
                        {
                            Session["CambioPassword"] = cambio;
                            Response.Redirect("CambiarPassword.aspx");
                        }
                        else
                        {
                            Response.Redirect("Index.aspx");
                        }
                    }
                    else if (per.ID_ROL == 3)
                    {
                        Session["vendedor"] = aux;
                        string passM = Controller.ControllerEncryption.stDecrypt(aux.PASSWORD_LOGIN, key);
                        if (passM.Equals(defaultPass))
                        {
                            Session["CambioPassword"] = cambio;
                            Response.Redirect("CambiarPassword.aspx");
                        }
                        else
                        {
                            Response.Redirect("Index.aspx");
                        }
                    }
                    else if (per.ID_ROL == 4)
                    {
                        Session["login"] = aux;
                        string passM = Controller.ControllerEncryption.stDecrypt(aux.PASSWORD_LOGIN, key);
                        if (passM.Equals(defaultPass))
                        {
                            Session["CambioPassword"] = cambio;
                            Response.Redirect("CambiarPassword.aspx");
                        }
                        else
                        {
                            Response.Redirect("Index.aspx");
                        }
                    }
                    else if (per.ID_ROL == 5)
                    {
                        Session["admCondominio"] = aux;
                        string passM = Controller.ControllerEncryption.stDecrypt(aux.PASSWORD_LOGIN, key);
                        if (passM.Equals(defaultPass))
                        {
                            Session["CambioPassword"] = cambio;
                            Response.Redirect("CambiarPassword.aspx");
                        }
                        else
                        {
                            Response.Redirect("Index.aspx");
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