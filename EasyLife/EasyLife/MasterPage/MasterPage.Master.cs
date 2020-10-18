using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EasyLife.MasterPage
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string imgAdmH = "https://i.postimg.cc/W3CXK1nm/IconAdmH.png";
            string imgAdmM = "https://i.postimg.cc/KzR0JMnv/IconAdmM.png";
            string imgH = "https://i.postimg.cc/vm8qxjTn/Icon-User-H.png";
            string imgM = "https://i.postimg.cc/s2nnYcGN/Icon-User-M.png";

            //Validación de Session Iniciada
            LOGIN adm = (LOGIN)Session["adm"];
            LOGIN conserje = (LOGIN)Session["conserje"];
            LOGIN vendedor = (LOGIN)Session["vendedor"];
            LOGIN propietario = (LOGIN)Session["login"];
            LOGIN admCondominio = (LOGIN)Session["admCondominio"];

            if (adm != null)
            {
                panelBotones.Visible = false;
                panelAdm.Visible = true;
                PERSONA aux = Controller.ControllerPersona.buscarPersonaRut(adm.FK_RUT);
                char[] sexo = aux.SEXO.ToCharArray();
                if (sexo[0] == 'M')
                {
                    imgAdm.ImageUrl = imgAdmH;
                }
                else
                {
                    imgAdm.ImageUrl = imgAdmM;
                }
            }

            if (conserje != null)
            {
                panelBotones.Visible = false;
                panelConserje.Visible = true;
                PERSONA aux = Controller.ControllerPersona.buscarPersonaRut(conserje.FK_RUT);
                char[] sexo = aux.SEXO.ToCharArray();
                if (sexo[0] == 'M')
                {
                    imgConserje.ImageUrl = imgH;
                }
                else
                {
                    imgConserje.ImageUrl = imgM;
                }
            }

            if (vendedor != null)
            {
                panelBotones.Visible = false;
                panelVendedor.Visible = true;
                PERSONA aux = Controller.ControllerPersona.buscarPersonaRut(vendedor.FK_RUT);
                char[] sexo = aux.SEXO.ToCharArray();
                if (sexo[0] == 'M')
                {
                    imgVendedor.ImageUrl = imgH;
                }
                else
                {
                    imgVendedor.ImageUrl = imgM;
                }
            }

            if (propietario != null)
            {
                panelBotones.Visible = false;
                panelPropietario.Visible = true;
                PERSONA aux = Controller.ControllerPersona.buscarPersonaRut(propietario.FK_RUT);
                char[] sexo = aux.SEXO.ToCharArray();
                if (sexo[0] == 'M')
                {
                    imgProp.ImageUrl = imgH;
                }
                else
                {
                    imgProp.ImageUrl = imgM;
                }
            }

            if (admCondominio != null)
            {
                panelBotones.Visible = false;
                panelAdmCondominio.Visible = true;
                PERSONA aux = Controller.ControllerPersona.buscarPersonaRut(admCondominio.FK_RUT);
                char[] sexo = aux.SEXO.ToCharArray();
                if (sexo[0] == 'M')
                {
                    imgAdmCon.ImageUrl = imgAdmH;
                }
                else
                {
                    imgAdmCon.ImageUrl = imgAdmM;
                }
            }
        }

        protected void lnkQuienes_Click(object sender, EventArgs e)
        {
            Response.Redirect("QuienesSomos.aspx");
        }

        protected void lnkServicios_Click(object sender, EventArgs e)
        {
            Response.Redirect("Servicios.aspx");
        }

        protected void lnkContacto_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Vista/Contacto.aspx");
        }

        protected void lnkLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void lnkPerfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("PerfilPropietario.aspx");
        }

        protected void lnkLuces_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProgramarLuzDepartamento.aspx");
        }

        protected void btnPagarGasto_Click(object sender, EventArgs e)
        {
            Response.Redirect("PagoGastoPropietario.aspx");
        }

        protected void btnReserva_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistroReservaPropietario.aspx");
        }

        protected void lnkMensaje_Click(object sender, EventArgs e)
        {
            Response.Redirect("Mensaje.aspx");
        }

        protected void lnkCerrar_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Index.aspx");
        }

        protected void lnkPerfilAdm_Click(object sender, EventArgs e)
        {
            Response.Redirect("PerfilAdministrador.aspx");
        }

        protected void lnkRegistroProp_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistroPropietario.aspx");
        }

        protected void lnkRegistroPersonal_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistroPersonal.aspx");
        }

        protected void lnkRegistroCondominio_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistroCondominio.aspx");
        }

        protected void lnkRegistroLuz_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistroLuz.aspx");
        }

        protected void lnkCentro_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistroCentro.aspx");
        }

        protected void lnkMulta_Click(object sender, EventArgs e)
        {
            Response.Redirect("AsignarMulta.aspx");
        }

        protected void lnkAsignarTurno_Click(object sender, EventArgs e)
        {
            Response.Redirect("AsignarTurnoConserje.aspx");
        }

        protected void lnkAsignarLuzEdificio_Click(object sender, EventArgs e)
        {
            Response.Redirect("AsignarLuzEdificio.aspx");
        }

        protected void lnkAsignarLuzDep_Click(object sender, EventArgs e)
        {
            Response.Redirect("AsignarLuzDepartamento.aspx");
        }

        protected void btnAsignarPersonal_Click(object sender, EventArgs e)
        {
            Response.Redirect("AsignarPersonal.aspx");
        }

        protected void lnkEnviarMensaje_Click(object sender, EventArgs e)
        {
            Response.Redirect("Mensaje.aspx");
        }

        protected void lnkPerfilVendedor_Click(object sender, EventArgs e)
        {
            Response.Redirect("PerfilVendedor.aspx");
        }

        protected void lnkRegistroPropV_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistroPropietario.aspx");
        }

        protected void lnkPerfilConserje_Click(object sender, EventArgs e)
        {
            Response.Redirect("PerfilConserje.aspx");
        }

        protected void lnkRegistroEstacionamiento_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistroEstacionamiento.aspx");
        }

        protected void lnkPagoGastos_Click(object sender, EventArgs e)
        {
            Response.Redirect("PagoGasto.aspx");
        }

        protected void LnkControlLuces_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProgramarLuzEdificio.aspx");
        }

        protected void lnkReservaConserje_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistroReservaConserje.aspx");
        }

        protected void lnkPerfilAdmCondominio_Click(object sender, EventArgs e)
        {
            Response.Redirect("PerfilAdmCondominio.aspx");
        }

        protected void lnkRegistroConserje_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistroConserje.aspx");
        }

        protected void lnkPreguntas_Click(object sender, EventArgs e)
        {
            Response.Redirect("Preguntas.aspx");
        }

        protected void lnkTerminos_Click(object sender, EventArgs e)
        {
            Response.Redirect("Terminos.aspx");
        }

        protected void lnkLogo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }
    }
}