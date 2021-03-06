﻿using System;
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
                lnkContacto.Visible = true;
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
                lnkContacto.Visible = true;
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
                lnkContacto.Visible = true;
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
                lnkContacto.Visible = true;
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
            limpiarSession();
            Response.Redirect("~/Vista/QuienesSomos.aspx");
        }

        protected void lnkServicios_Click(object sender, EventArgs e)
        {
            limpiarSession();
            Response.Redirect("~/Vista/Servicios.aspx");
        }

        protected void lnkContacto_Click(object sender, EventArgs e)
        {
            limpiarSession();
            Response.Redirect("~/Vista/DetalleGastoComun.aspx");
        }

        protected void lnkLogin_Click(object sender, EventArgs e)
        {
            limpiarSession();
            Response.Redirect("~/Vista/Login.aspx");
        }

        protected void lnkPerfil_Click(object sender, EventArgs e)
        {
            limpiarSession();
            Response.Redirect("~/Vista/PerfilPropietario.aspx");
        }

        protected void lnkLuces_Click(object sender, EventArgs e)
        {
            limpiarSession();
            Response.Redirect("~/Vista/ProgramarLuzDepartamento.aspx");
        }

        protected void btnPagarGasto_Click(object sender, EventArgs e)
        {
            limpiarSession();
            Response.Redirect("~/Vista/PagoGastoPropietario.aspx");
        }

        protected void btnReserva_Click(object sender, EventArgs e)
        {
            limpiarSession();
            Response.Redirect("~/Vista/RegistroReservaPropietario.aspx");
        }

        protected void lnkCerrar_Click(object sender, EventArgs e)
        {
            limpiarSession();
            Session.Clear();
            Response.Redirect("~/Vista/Index.aspx");
        }

        protected void lnkPerfilAdm_Click(object sender, EventArgs e)
        {
            limpiarSession();
            Response.Redirect("~/Vista/PerfilAdministrador.aspx");
        }

        protected void lnkRegistroProp_Click(object sender, EventArgs e)
        {
            limpiarSession();
            Response.Redirect("~/Vista/RegistroPropietario.aspx");
        }

        protected void lnkRegistroPersonal_Click(object sender, EventArgs e)
        {
            limpiarSession();
            Response.Redirect("~/Vista/RegistroPersonal.aspx");
        }

        protected void lnkRegistroCondominio_Click(object sender, EventArgs e)
        {
            limpiarSession();
            Response.Redirect("~/Vista/RegistroCondominio.aspx");
        }

        protected void lnkRegistroLuz_Click(object sender, EventArgs e)
        {
            limpiarSession();
            Response.Redirect("~/Vista/RegistroLuz.aspx");
        }

        protected void lnkCentro_Click(object sender, EventArgs e)
        {
            limpiarSession();
            Response.Redirect("~/Vista/RegistroCentro.aspx");
        }

        protected void lnkMulta_Click(object sender, EventArgs e)
        {
            limpiarSession();
            Response.Redirect("~/Vista/AsignarMulta.aspx");
        }

        protected void lnkAsignarTurno_Click(object sender, EventArgs e)
        {
            limpiarSession();
            Response.Redirect("~/Vista/AsignarTurnoConserje.aspx");
        }

        protected void lnkAsignarLuzEdificio_Click(object sender, EventArgs e)
        {
            limpiarSession();
            Response.Redirect("~/Vista/AsignarLuzEdificio.aspx");
        }

        protected void lnkAsignarLuzDep_Click(object sender, EventArgs e)
        {
            limpiarSession();
            Response.Redirect("~/Vista/AsignarLuzDepartamento.aspx");
        }

        protected void btnAsignarPersonal_Click(object sender, EventArgs e)
        {
            limpiarSession();
            Response.Redirect("~/Vista/AsignarPersonal.aspx");
        }

        protected void lnkEnviarMensaje_Click(object sender, EventArgs e)
        {
            limpiarSession();
            Response.Redirect("~/Vista/Mensaje.aspx");
        }

        protected void lnkPerfilVendedor_Click(object sender, EventArgs e)
        {
            limpiarSession();
            Response.Redirect("~/Vista/PerfilVendedor.aspx");
        }

        protected void lnkRegistroPropV_Click(object sender, EventArgs e)
        {
            limpiarSession();
            Response.Redirect("~/Vista/RegistroPropietario.aspx");
        }

        protected void lnkPerfilConserje_Click(object sender, EventArgs e)
        {
            limpiarSession();
            Response.Redirect("~/Vista/PerfilConserje.aspx");
        }

        protected void lnkRegistroEstacionamiento_Click(object sender, EventArgs e)
        {
            limpiarSession();
            Response.Redirect("~/Vista/RegistroEstacionamiento.aspx");
        }

        protected void lnkPagoGastos_Click(object sender, EventArgs e)
        {
            limpiarSession();
            Response.Redirect("~/Vista/PagoGasto.aspx");
        }

        protected void LnkControlLuces_Click(object sender, EventArgs e)
        {
            limpiarSession();
            Response.Redirect("~/Vista/ProgramarLuzEdificio.aspx");
        }

        protected void lnkReservaConserje_Click(object sender, EventArgs e)
        {
            limpiarSession();
            Response.Redirect("~/Vista/RegistroReservaConserje.aspx");
        }

        protected void lnkPerfilAdmCondominio_Click(object sender, EventArgs e)
        {
            limpiarSession();
            Response.Redirect("~/Vista/PerfilAdmCondominio.aspx");
        }

        protected void lnkRegistroConserje_Click(object sender, EventArgs e)
        {
            limpiarSession();
            Response.Redirect("~/Vista/RegistroConserje.aspx");
        }

        protected void lnkPreguntas_Click(object sender, EventArgs e)
        {
            limpiarSession();
            Response.Redirect("~/Vista/Preguntas.aspx");
        }

        protected void lnkTerminos_Click(object sender, EventArgs e)
        {
            limpiarSession();
            Response.Redirect("~/Vista/Terminos.aspx");
        }

        protected void lnkLogo_Click(object sender, EventArgs e)
        {
            limpiarSession();
            Response.Redirect("~/Vista/Index.aspx");
        }

        protected void lnkGasto_Click(object sender, EventArgs e)
        {
            limpiarSession();
            Response.Redirect("~/Vista/RegistroGasto.aspx");
        }

        public void limpiarSession()
        {
            Session["ModificarConserje"] = null;
            Session["ModificarTurno"] = null;
            Session["ModificarPropietario"] = null;
            Session["AsignarLuzDepartamento"] = null;
            Session["AsignarMultaDepartamento"] = null;
            Session["ModificarGasto"] = null;
            Session["ModificarCentro"] = null;
            Session["ModificarHorario"] = null;
            Session["ModificarPersonal"] = null;
            Session["ModificarTurno"] = null;
            Session["ModificarPropietario"] = null;
            Session["AsignarLuzDepartamento"] = null;
            Session["AsignarMultaDepartamento"] = null;
            Session["ModificarGasto"] = null;
            Session["ModificarCentro"] = null;
            Session["ModificarHorario"] = null;
            Session["ModificarControlIluminacionEdifciio"] = null;
            Session["ModificarEstacionamiento"] = null;
            Session["ModificarControlIluminacionDep"] = null;
            Session["ModificarPropietario"] = null;
        }

        protected void lnkMensajeAdm_Click(object sender, EventArgs e)
        {
            limpiarSession();
            Response.Redirect("~/Vista/Mensaje.aspx");
        }
    }
}