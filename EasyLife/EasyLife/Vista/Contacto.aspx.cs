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
    public partial class Contacto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarCombo();
            }
        }

        public void cargarCombo()
        {
            List<TIPO_MENSAJE> lista = Controller.ControllerTipoMensaje.listaTipoMensaje();
            dplMotivo.DataSource = lista;
            dplMotivo.DataValueField = "ID_TIPO_MENSAJE";
            dplMotivo.DataTextField = "DESCRIPCION_TP";
            dplMotivo.DataBind();
            dplMotivo.Items.Insert(0, "Seleccionar...");
            dplMotivo.SelectedIndex = 0;
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(5000);
                string message = "";
                message += "";

                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(txtEmail.Text);
                msg.To.Add("easylifeapartaments@gmail.com");
                TIPO_MENSAJE tp = Controller.ControllerTipoMensaje.buscarIdTipoMensaje(Convert.ToInt64(dplMotivo.SelectedValue));
                msg.Subject = tp.DESCRIPCION_TP;
                msg.Body = message;
                msg.BodyEncoding = System.Text.Encoding.UTF8;
                /*Para realizar envio de mensaje con copia*/
                /*MailAddress ms = new MailAddress("easylifeapartaments@gmail.com");
                msg.CC.Add(ms);*/
                SmtpClient sc = new SmtpClient("smtp.gmail.com");
                sc.Port = 25;
                sc.Credentials = new NetworkCredential("easylifeapartaments@gmail.com", "easylife2020");
                sc.EnableSsl = true;
                sc.Send(msg);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Mensaje Enviado');window.location.href='" + Request.RawUrl + "';", true);
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