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
        }

        protected void lnkServicios_Click(object sender, EventArgs e)
        {
        }

        protected void lnkContacto_Click(object sender, EventArgs e)
        {
        }

        protected void lnkLogin_Click(object sender, EventArgs e)
        {
        }

        protected void lnkPerfil_Click(object sender, EventArgs e)
        {
        }

        protected void lnkLuces_Click(object sender, EventArgs e)
        {
        }

        protected void btnPagarGasto_Click(object sender, EventArgs e)
        {
        }

        protected void btnReserva_Click(object sender, EventArgs e)
        {
        }

        protected void lnkMensaje_Click(object sender, EventArgs e)
        {
        }

        protected void lnkCerrar_Click(object sender, EventArgs e)
        {
        }

        protected void lnkPerfilAdm_Click(object sender, EventArgs e)
        {
        }

        protected void lnkRegistroProp_Click(object sender, EventArgs e)
        {
        }

        protected void lnkRegistroPersonal_Click(object sender, EventArgs e)
        {
        }

        protected void lnkRegistroCondominio_Click(object sender, EventArgs e)
        {
        }

        protected void lnkRegistroLuz_Click(object sender, EventArgs e)
        {
        }

        protected void lnkCentro_Click(object sender, EventArgs e)
        {
        }

        protected void lnkMulta_Click(object sender, EventArgs e)
        {
        }

        protected void lnkAsignarTurno_Click(object sender, EventArgs e)
        {
        }

        protected void lnkAsignarLuzEdificio_Click(object sender, EventArgs e)
        {
        }

        protected void lnkAsignarLuzDep_Click(object sender, EventArgs e)
        {
        }

        protected void btnAsignarPersonal_Click(object sender, EventArgs e)
        {
        }

        protected void lnkEnviarMensaje_Click(object sender, EventArgs e)
        {
        }

        protected void lnkPerfilVendedor_Click(object sender, EventArgs e)
        {
        }

        protected void lnkRegistroPropV_Click(object sender, EventArgs e)
        {
        }

        protected void lnkPerfilConserje_Click(object sender, EventArgs e)
        {
        }

        protected void lnkRegistroEstacionamiento_Click(object sender, EventArgs e)
        {
        }

        protected void lnkPagoGastos_Click(object sender, EventArgs e)
        {
        }

        protected void LnkControlLuces_Click(object sender, EventArgs e)
        {
        }

        protected void lnkReservaConserje_Click(object sender, EventArgs e)
        {
        }

        protected void lnkPerfilAdmCondominio_Click(object sender, EventArgs e)
        {
        }

        protected void lnkRegistroConserje_Click(object sender, EventArgs e)
        {
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
        }

        protected void lnkPreguntas_Click(object sender, EventArgs e)
        {
        }

        protected void lnkTerminos_Click(object sender, EventArgs e)
        {
        }

        protected void lnkLogo_Click(object sender, EventArgs e)
        {
        }
    }
}