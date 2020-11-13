using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;

namespace EasyLife.Vista
{
    public partial class RecuperarPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnRecuperarPassword_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Reserva Cancelada');window.location.href='" + Request.RawUrl + "';", true);
            try
            {
                System.Threading.Thread.Sleep(5000);
                string message = "";
                message += "";

                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("easylifeapartaments@gmail.com");
                msg.To.Add(txtEmail.Text);
                msg.Subject = "Recuperacion de Password";
                msg.Body = message + "Su nueva contraseña es EasyLife";
                msg.BodyEncoding = System.Text.Encoding.UTF8;
                /*Para realizar envio de mensaje con copia*/
                /*MailAddress ms = new MailAddress("easylifeapartaments@gmail.com");
                msg.CC.Add(ms);*/
                SmtpClient sc = new SmtpClient("smtp.gmail.com");
                sc.Port = 25;
                sc.Credentials = new NetworkCredential("easylifeapartaments@gmail.com", "easylife2020");
                sc.EnableSsl = true;
                sc.Send(msg);

                string result = Controller.ControllerLogin.recuperarPassword(txtEmail.Text);
                if (result.Equals("Password Cambiada"))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Mensaje Enviado');window.location.href='" + Request.RawUrl + "';", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Error al Enviar Mensaje');window.location.href='" + Request.RawUrl + "';", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Error al Enviar Mensaje');window.location.href='" + Request.RawUrl + "';", true);
                System.Diagnostics.Debug.WriteLine("Error, Contactenos " + ex);
                throw;
            }
        }
    }
}