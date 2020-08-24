using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace EasyLife.Vista
{
    public partial class Servicios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Verificacion de Opciones Disponibles por usuario
            LOGIN prop = (LOGIN)Session["login"];
            LOGIN adm = (LOGIN)Session["adm"];
            LOGIN conserje = (LOGIN)Session["conserje"];
            LOGIN vendedor = (LOGIN)Session["vendedor"];
            LOGIN admCondominio = (LOGIN)Session["admCondominio"];

            if (!IsPostBack)
            {
                if (prop != null)
                {
                    opcionesPropietario();
                }
                else if (adm != null)
                {
                    opcionesAdm();
                }
                else if (conserje != null)
                {
                    opcionesConserje();
                }
                else if (vendedor != null)
                {
                    opcionesVendedor();
                }
                else if (admCondominio != null)
                {
                    opcionesAdmCondominio();
                }
                else
                {
                    opcionesDefault();
                }
            }
        }

        public void opcionesPropietario()
        {
            btnGastos.Visible = true;
            btnMensajeria.Visible = true;
            btnReserva.Visible = true;
            btnLuces.Visible = true;
            btnPassword.Visible = true;
            btnPerfilPropietario.Visible = true;
            btnRegistroPropietario.Visible = false;
            btnPerfilVendedor.Visible = false;
            btnRegistroEst.Visible = false;
            btnReservaCentro.Visible = false;
            btnPagoGasto.Visible = false;
            btnControlLuces.Visible = false;
            btnPerfilConserje.Visible = false;
            btnMulta.Visible = false;
            btnPerfilAdmCondominio.Visible = false;
            btnRegistroConserje.Visible = false;
            btnRegistroLuces.Visible = false;
            btnAsignarLuz.Visible = false;
            btnPerfilAdm.Visible = false;
            btnRegistroPersonal.Visible = false;
            btnRegistroCondominio.Visible = false;
            btnRegistroCentro.Visible = false;
            btnOperacionesBasicas.Visible = true;
        }

        public void opcionesVendedor()
        {
            btnGastos.Visible = false;
            btnMensajeria.Visible = true;
            btnReserva.Visible = false;
            btnLuces.Visible = false;
            btnPassword.Visible = true;
            btnPerfilPropietario.Visible = false;
            btnRegistroPropietario.Visible = true;
            btnPerfilVendedor.Visible = true;
            btnRegistroEst.Visible = false;
            btnReservaCentro.Visible = false;
            btnPagoGasto.Visible = false;
            btnControlLuces.Visible = false;
            btnPerfilConserje.Visible = false;
            btnMulta.Visible = false;
            btnPerfilAdmCondominio.Visible = false;
            btnRegistroConserje.Visible = false;
            btnRegistroLuces.Visible = false;
            btnAsignarLuz.Visible = false;
            btnPerfilAdm.Visible = false;
            btnRegistroPersonal.Visible = false;
            btnRegistroCondominio.Visible = false;
            btnRegistroCentro.Visible = false;
            btnOperacionesBasicas.Visible = true;
        }

        public void opcionesConserje()
        {
            btnGastos.Visible = false;
            btnMensajeria.Visible = true;
            btnReserva.Visible = false;
            btnLuces.Visible = false;
            btnPassword.Visible = true;
            btnPerfilPropietario.Visible = false;
            btnRegistroPropietario.Visible = false;
            btnPerfilVendedor.Visible = false;
            btnRegistroEst.Visible = true;
            btnReservaCentro.Visible = true;
            btnPagoGasto.Visible = true;
            btnControlLuces.Visible = true;
            btnPerfilConserje.Visible = true;
            btnMulta.Visible = false;
            btnPerfilAdmCondominio.Visible = false;
            btnRegistroConserje.Visible = false;
            btnRegistroLuces.Visible = false;
            btnAsignarLuz.Visible = false;
            btnPerfilAdm.Visible = false;
            btnRegistroPersonal.Visible = false;
            btnRegistroCondominio.Visible = false;
            btnRegistroCentro.Visible = false;
            btnOperacionesBasicas.Visible = true;
        }

        public void opcionesAdmCondominio()
        {
            btnGastos.Visible = false;
            btnMensajeria.Visible = false;
            btnReserva.Visible = false;
            btnLuces.Visible = false;
            btnPassword.Visible = true;
            btnPerfilPropietario.Visible = false;
            btnRegistroPropietario.Visible = true;
            btnPerfilVendedor.Visible = false;
            btnRegistroEst.Visible = true;
            btnReservaCentro.Visible = true;
            btnPagoGasto.Visible = true;
            btnControlLuces.Visible = true;
            btnPerfilConserje.Visible = false;
            btnMulta.Visible = true;
            btnPerfilAdmCondominio.Visible = true;
            btnRegistroConserje.Visible = true;
            btnRegistroLuces.Visible = true;
            btnAsignarLuz.Visible = true;
            btnPerfilAdm.Visible = false;
            btnRegistroPersonal.Visible = false;
            btnRegistroCondominio.Visible = false;
            btnRegistroCentro.Visible = false;
            btnOperacionesBasicas.Visible = true;
        }

        public void opcionesAdm()
        {
            btnGastos.Visible = false;
            btnMensajeria.Visible = false;
            btnReserva.Visible = false;
            btnLuces.Visible = false;
            btnPassword.Visible = true;
            btnPerfilPropietario.Visible = false;
            btnRegistroPropietario.Visible = true;
            btnPerfilVendedor.Visible = false;
            btnRegistroEst.Visible = true;
            btnReservaCentro.Visible = true;
            btnPagoGasto.Visible = true;
            btnControlLuces.Visible = true;
            btnPerfilConserje.Visible = false;
            btnMulta.Visible = true;
            btnPerfilAdmCondominio.Visible = false;
            btnRegistroConserje.Visible = true;
            btnRegistroLuces.Visible = true;
            btnAsignarLuz.Visible = true;
            btnPerfilAdm.Visible = true;
            btnRegistroPersonal.Visible = true;
            btnRegistroCondominio.Visible = true;
            btnRegistroCentro.Visible = true;
            btnOperacionesBasicas.Visible = true;
        }

        public void opcionesDefault()
        {
            btnGastos.Visible = true;
            btnMensajeria.Visible = true;
            btnReserva.Visible = true;
            btnLuces.Visible = true;
            btnPassword.Visible = true;
            btnPerfilPropietario.Visible = true;
            btnRegistroPropietario.Visible = false;
            btnPerfilVendedor.Visible = false;
            btnRegistroEst.Visible = false;
            btnReservaCentro.Visible = false;
            btnPagoGasto.Visible = false;
            btnControlLuces.Visible = false;
            btnPerfilConserje.Visible = false;
            btnMulta.Visible = false;
            btnPerfilAdmCondominio.Visible = false;
            btnRegistroConserje.Visible = false;
            btnRegistroLuces.Visible = false;
            btnAsignarLuz.Visible = false;
            btnPerfilAdm.Visible = false;
            btnRegistroPersonal.Visible = false;
            btnRegistroCondominio.Visible = false;
            btnRegistroCentro.Visible = false;
            btnOperacionesBasicas.Visible = true;
        }

        protected void btnOperacionesBasicas_Click(object sender, EventArgs e)
        {
            btnGastos.BackColor = Color.White;
            btnMensajeria.BackColor = Color.White;
            btnReserva.BackColor = Color.White;
            btnLuces.BackColor = Color.White;
            btnPassword.BackColor = Color.White;
            btnPerfilPropietario.BackColor = Color.White;
            btnRegistroPropietario.BackColor = Color.White;
            btnPerfilVendedor.BackColor = Color.White;
            btnRegistroEst.BackColor = Color.White;
            btnReservaCentro.BackColor = Color.White;
            btnPagoGasto.BackColor = Color.White;
            btnControlLuces.BackColor = Color.White;
            btnPerfilConserje.BackColor = Color.White;
            btnMulta.BackColor = Color.White;
            btnPerfilAdmCondominio.BackColor = Color.White;
            btnRegistroConserje.BackColor = Color.White;
            btnRegistroLuces.BackColor = Color.White;
            btnAsignarLuz.BackColor = Color.White;
            btnPerfilAdm.BackColor = Color.White;
            btnRegistroPersonal.BackColor = Color.White;
            btnRegistroCondominio.BackColor = Color.White;
            btnRegistroCentro.BackColor = Color.White;
            btnOperacionesBasicas.BackColor = Color.LightBlue;

            panelGastos.Visible = false;
            panelMensajeria.Visible = false;
            panelReserva.Visible = false;
            panelLuces.Visible = false;
            panelPassword.Visible = false;
            panelPerfilProp.Visible = false;
            panelRegistroPropietario.Visible = false;
            panelPerfilVendedor.Visible = false;
            panelRegistroEst.Visible = false;
            panelReservaCentro.Visible = false;
            panelPagoGasto.Visible = false;
            panelControlLuz.Visible = false;
            panelPerfilConserje.Visible = false;
            panelRegistroLuz.Visible = false;
            panelAsignarLuz.Visible = false;
            panelPerfilAdm.Visible = false;
            panelRegistroPersonal.Visible = false;
            panelRegistroCondominio.Visible = false;
            panelRegistroCentro.Visible = false;
            panelPerfilAdmCondominio.Visible = false;
            panelMulta.Visible = false;
            panelRegistroConserje.Visible = false;
            panelOperaciones.Visible = true;
        }

        protected void btnGastos_Click(object sender, EventArgs e)
        {
            btnGastos.BackColor = Color.LightBlue;
            btnMensajeria.BackColor = Color.White;
            btnReserva.BackColor = Color.White;
            btnLuces.BackColor = Color.White;
            btnPassword.BackColor = Color.White;
            btnPerfilPropietario.BackColor = Color.White;
            btnRegistroPropietario.BackColor = Color.White;
            btnPerfilVendedor.BackColor = Color.White;
            btnRegistroEst.BackColor = Color.White;
            btnReservaCentro.BackColor = Color.White;
            btnPagoGasto.BackColor = Color.White;
            btnControlLuces.BackColor = Color.White;
            btnPerfilConserje.BackColor = Color.White;
            btnMulta.BackColor = Color.White;
            btnPerfilAdmCondominio.BackColor = Color.White;
            btnRegistroConserje.BackColor = Color.White;
            btnRegistroLuces.BackColor = Color.White;
            btnAsignarLuz.BackColor = Color.White;
            btnPerfilAdm.BackColor = Color.White;
            btnRegistroPersonal.BackColor = Color.White;
            btnRegistroCondominio.BackColor = Color.White;
            btnRegistroCentro.BackColor = Color.White;
            btnOperacionesBasicas.BackColor = Color.White;

            panelGastos.Visible = true;
            panelMensajeria.Visible = false;
            panelReserva.Visible = false;
            panelLuces.Visible = false;
            panelPassword.Visible = false;
            panelPerfilProp.Visible = false;
            panelRegistroPropietario.Visible = false;
            panelPerfilVendedor.Visible = false;
            panelRegistroEst.Visible = false;
            panelReservaCentro.Visible = false;
            panelPagoGasto.Visible = false;
            panelControlLuz.Visible = false;
            panelPerfilConserje.Visible = false;
            panelRegistroLuz.Visible = false;
            panelAsignarLuz.Visible = false;
            panelPerfilAdm.Visible = false;
            panelRegistroPersonal.Visible = false;
            panelRegistroCondominio.Visible = false;
            panelRegistroCentro.Visible = false;
            panelPerfilAdmCondominio.Visible = false;
            panelMulta.Visible = false;
            panelRegistroConserje.Visible = false;
            panelOperaciones.Visible = false;
        }

        protected void btnMensajeria_Click(object sender, EventArgs e)
        {
            btnGastos.BackColor = Color.White;
            btnMensajeria.BackColor = Color.LightBlue;
            btnReserva.BackColor = Color.White;
            btnLuces.BackColor = Color.White;
            btnPassword.BackColor = Color.White;
            btnPerfilPropietario.BackColor = Color.White;
            btnRegistroPropietario.BackColor = Color.White;
            btnPerfilVendedor.BackColor = Color.White;
            btnRegistroEst.BackColor = Color.White;
            btnReservaCentro.BackColor = Color.White;
            btnPagoGasto.BackColor = Color.White;
            btnControlLuces.BackColor = Color.White;
            btnPerfilConserje.BackColor = Color.White;
            btnMulta.BackColor = Color.White;
            btnPerfilAdmCondominio.BackColor = Color.White;
            btnRegistroConserje.BackColor = Color.White;
            btnRegistroLuces.BackColor = Color.White;
            btnAsignarLuz.BackColor = Color.White;
            btnPerfilAdm.BackColor = Color.White;
            btnRegistroPersonal.BackColor = Color.White;
            btnRegistroCondominio.BackColor = Color.White;
            btnRegistroCentro.BackColor = Color.White;
            btnOperacionesBasicas.BackColor = Color.White;

            panelGastos.Visible = false;
            panelMensajeria.Visible = true;
            panelReserva.Visible = false;
            panelLuces.Visible = false;
            panelPassword.Visible = false;
            panelPerfilProp.Visible = false;
            panelRegistroPropietario.Visible = false;
            panelPerfilVendedor.Visible = false;
            panelRegistroEst.Visible = false;
            panelReservaCentro.Visible = false;
            panelPagoGasto.Visible = false;
            panelControlLuz.Visible = false;
            panelPerfilConserje.Visible = false;
            panelRegistroLuz.Visible = false;
            panelAsignarLuz.Visible = false;
            panelPerfilAdm.Visible = false;
            panelRegistroPersonal.Visible = false;
            panelRegistroCondominio.Visible = false;
            panelRegistroCentro.Visible = false;
            panelPerfilAdmCondominio.Visible = false;
            panelMulta.Visible = false;
            panelRegistroConserje.Visible = false;
            panelOperaciones.Visible = false;
        }

        protected void btnReserva_Click(object sender, EventArgs e)
        {
            btnGastos.BackColor = Color.White;
            btnMensajeria.BackColor = Color.White;
            btnReserva.BackColor = Color.LightBlue;
            btnLuces.BackColor = Color.White;
            btnPassword.BackColor = Color.White;
            btnPerfilPropietario.BackColor = Color.White;
            btnRegistroPropietario.BackColor = Color.White;
            btnPerfilVendedor.BackColor = Color.White;
            btnRegistroEst.BackColor = Color.White;
            btnReservaCentro.BackColor = Color.White;
            btnPagoGasto.BackColor = Color.White;
            btnControlLuces.BackColor = Color.White;
            btnPerfilConserje.BackColor = Color.White;
            btnMulta.BackColor = Color.White;
            btnPerfilAdmCondominio.BackColor = Color.White;
            btnRegistroConserje.BackColor = Color.White;
            btnRegistroLuces.BackColor = Color.White;
            btnAsignarLuz.BackColor = Color.White;
            btnPerfilAdm.BackColor = Color.White;
            btnRegistroPersonal.BackColor = Color.White;
            btnRegistroCondominio.BackColor = Color.White;
            btnRegistroCentro.BackColor = Color.White;
            btnOperacionesBasicas.BackColor = Color.White;

            panelGastos.Visible = false;
            panelMensajeria.Visible = false;
            panelReserva.Visible = true;
            panelLuces.Visible = false;
            panelPassword.Visible = false;
            panelPerfilProp.Visible = false;
            panelRegistroPropietario.Visible = false;
            panelPerfilVendedor.Visible = false;
            panelRegistroEst.Visible = false;
            panelReservaCentro.Visible = false;
            panelPagoGasto.Visible = false;
            panelControlLuz.Visible = false;
            panelPerfilConserje.Visible = false;
            panelRegistroLuz.Visible = false;
            panelAsignarLuz.Visible = false;
            panelPerfilAdm.Visible = false;
            panelRegistroPersonal.Visible = false;
            panelRegistroCondominio.Visible = false;
            panelRegistroCentro.Visible = false;
            panelPerfilAdmCondominio.Visible = false;
            panelMulta.Visible = false;
            panelRegistroConserje.Visible = false;
            panelOperaciones.Visible = false;
        }

        protected void btnLuces_Click(object sender, EventArgs e)
        {
            btnGastos.BackColor = Color.White;
            btnMensajeria.BackColor = Color.White;
            btnReserva.BackColor = Color.White;
            btnLuces.BackColor = Color.LightBlue;
            btnPassword.BackColor = Color.White;
            btnPerfilPropietario.BackColor = Color.White;
            btnRegistroPropietario.BackColor = Color.White;
            btnPerfilVendedor.BackColor = Color.White;
            btnRegistroEst.BackColor = Color.White;
            btnReservaCentro.BackColor = Color.White;
            btnPagoGasto.BackColor = Color.White;
            btnControlLuces.BackColor = Color.White;
            btnPerfilConserje.BackColor = Color.White;
            btnMulta.BackColor = Color.White;
            btnPerfilAdmCondominio.BackColor = Color.White;
            btnRegistroConserje.BackColor = Color.White;
            btnRegistroLuces.BackColor = Color.White;
            btnAsignarLuz.BackColor = Color.White;
            btnPerfilAdm.BackColor = Color.White;
            btnRegistroPersonal.BackColor = Color.White;
            btnRegistroCondominio.BackColor = Color.White;
            btnRegistroCentro.BackColor = Color.White;
            btnOperacionesBasicas.BackColor = Color.White;

            panelGastos.Visible = false;
            panelMensajeria.Visible = false;
            panelReserva.Visible = false;
            panelLuces.Visible = true;
            panelPassword.Visible = false;
            panelPerfilProp.Visible = false;
            panelRegistroPropietario.Visible = false;
            panelPerfilVendedor.Visible = false;
            panelRegistroEst.Visible = false;
            panelReservaCentro.Visible = false;
            panelPagoGasto.Visible = false;
            panelControlLuz.Visible = false;
            panelPerfilConserje.Visible = false;
            panelRegistroLuz.Visible = false;
            panelAsignarLuz.Visible = false;
            panelPerfilAdm.Visible = false;
            panelRegistroPersonal.Visible = false;
            panelRegistroCondominio.Visible = false;
            panelRegistroCentro.Visible = false;
            panelPerfilAdmCondominio.Visible = false;
            panelMulta.Visible = false;
            panelRegistroConserje.Visible = false;
            panelOperaciones.Visible = false;
        }

        protected void btnPassword_Click(object sender, EventArgs e)
        {
            btnGastos.BackColor = Color.White;
            btnMensajeria.BackColor = Color.White;
            btnReserva.BackColor = Color.White;
            btnLuces.BackColor = Color.White;
            btnPassword.BackColor = Color.LightBlue;
            btnPerfilPropietario.BackColor = Color.White;
            btnRegistroPropietario.BackColor = Color.White;
            btnPerfilVendedor.BackColor = Color.White;
            btnRegistroEst.BackColor = Color.White;
            btnReservaCentro.BackColor = Color.White;
            btnPagoGasto.BackColor = Color.White;
            btnControlLuces.BackColor = Color.White;
            btnPerfilConserje.BackColor = Color.White;
            btnMulta.BackColor = Color.White;
            btnPerfilAdmCondominio.BackColor = Color.White;
            btnRegistroConserje.BackColor = Color.White;
            btnRegistroLuces.BackColor = Color.White;
            btnAsignarLuz.BackColor = Color.White;
            btnPerfilAdm.BackColor = Color.White;
            btnRegistroPersonal.BackColor = Color.White;
            btnRegistroCondominio.BackColor = Color.White;
            btnRegistroCentro.BackColor = Color.White;
            btnOperacionesBasicas.BackColor = Color.White;

            panelGastos.Visible = false;
            panelMensajeria.Visible = false;
            panelReserva.Visible = false;
            panelLuces.Visible = false;
            panelPassword.Visible = true;
            panelPerfilProp.Visible = false;
            panelRegistroPropietario.Visible = false;
            panelPerfilVendedor.Visible = false;
            panelRegistroEst.Visible = false;
            panelReservaCentro.Visible = false;
            panelPagoGasto.Visible = false;
            panelControlLuz.Visible = false;
            panelPerfilConserje.Visible = false;
            panelRegistroLuz.Visible = false;
            panelAsignarLuz.Visible = false;
            panelPerfilAdm.Visible = false;
            panelRegistroPersonal.Visible = false;
            panelRegistroCondominio.Visible = false;
            panelRegistroCentro.Visible = false;
            panelPerfilAdmCondominio.Visible = false;
            panelMulta.Visible = false;
            panelRegistroConserje.Visible = false;
            panelOperaciones.Visible = false;
        }

        protected void btnPerfilPropietario_Click(object sender, EventArgs e)
        {
            btnGastos.BackColor = Color.White;
            btnMensajeria.BackColor = Color.White;
            btnReserva.BackColor = Color.White;
            btnLuces.BackColor = Color.White;
            btnPassword.BackColor = Color.White;
            btnPerfilPropietario.BackColor = Color.LightBlue;
            btnRegistroPropietario.BackColor = Color.White;
            btnPerfilVendedor.BackColor = Color.White;
            btnRegistroEst.BackColor = Color.White;
            btnReservaCentro.BackColor = Color.White;
            btnPagoGasto.BackColor = Color.White;
            btnControlLuces.BackColor = Color.White;
            btnPerfilConserje.BackColor = Color.White;
            btnMulta.BackColor = Color.White;
            btnPerfilAdmCondominio.BackColor = Color.White;
            btnRegistroConserje.BackColor = Color.White;
            btnRegistroLuces.BackColor = Color.White;
            btnAsignarLuz.BackColor = Color.White;
            btnPerfilAdm.BackColor = Color.White;
            btnRegistroPersonal.BackColor = Color.White;
            btnRegistroCondominio.BackColor = Color.White;
            btnRegistroCentro.BackColor = Color.White;
            btnOperacionesBasicas.BackColor = Color.White;

            panelGastos.Visible = false;
            panelMensajeria.Visible = false;
            panelReserva.Visible = false;
            panelLuces.Visible = false;
            panelPassword.Visible = false;
            panelPerfilProp.Visible = true;
            panelRegistroPropietario.Visible = false;
            panelPerfilVendedor.Visible = false;
            panelRegistroEst.Visible = false;
            panelReservaCentro.Visible = false;
            panelPagoGasto.Visible = false;
            panelControlLuz.Visible = false;
            panelPerfilConserje.Visible = false;
            panelRegistroLuz.Visible = false;
            panelAsignarLuz.Visible = false;
            panelPerfilAdm.Visible = false;
            panelRegistroPersonal.Visible = false;
            panelRegistroCondominio.Visible = false;
            panelRegistroCentro.Visible = false;
            panelPerfilAdmCondominio.Visible = false;
            panelMulta.Visible = false;
            panelRegistroConserje.Visible = false;
            panelOperaciones.Visible = false;
        }

        protected void btnRegistroPropietario_Click(object sender, EventArgs e)
        {
            btnGastos.BackColor = Color.White;
            btnMensajeria.BackColor = Color.White;
            btnReserva.BackColor = Color.White;
            btnLuces.BackColor = Color.White;
            btnPassword.BackColor = Color.White;
            btnPerfilPropietario.BackColor = Color.White;
            btnRegistroPropietario.BackColor = Color.LightBlue;
            btnPerfilVendedor.BackColor = Color.White;
            btnRegistroEst.BackColor = Color.White;
            btnReservaCentro.BackColor = Color.White;
            btnPagoGasto.BackColor = Color.White;
            btnControlLuces.BackColor = Color.White;
            btnPerfilConserje.BackColor = Color.White;
            btnMulta.BackColor = Color.White;
            btnPerfilAdmCondominio.BackColor = Color.White;
            btnRegistroConserje.BackColor = Color.White;
            btnRegistroLuces.BackColor = Color.White;
            btnAsignarLuz.BackColor = Color.White;
            btnPerfilAdm.BackColor = Color.White;
            btnRegistroPersonal.BackColor = Color.White;
            btnRegistroCondominio.BackColor = Color.White;
            btnRegistroCentro.BackColor = Color.White;
            btnOperacionesBasicas.BackColor = Color.White;

            panelGastos.Visible = false;
            panelMensajeria.Visible = false;
            panelReserva.Visible = false;
            panelLuces.Visible = false;
            panelPassword.Visible = false;
            panelPerfilProp.Visible = false;
            panelRegistroPropietario.Visible = true;
            panelPerfilVendedor.Visible = false;
            panelRegistroEst.Visible = false;
            panelReservaCentro.Visible = false;
            panelPagoGasto.Visible = false;
            panelControlLuz.Visible = false;
            panelPerfilConserje.Visible = false;
            panelRegistroLuz.Visible = false;
            panelAsignarLuz.Visible = false;
            panelPerfilAdm.Visible = false;
            panelRegistroPersonal.Visible = false;
            panelRegistroCondominio.Visible = false;
            panelRegistroCentro.Visible = false;
            panelPerfilAdmCondominio.Visible = false;
            panelMulta.Visible = false;
            panelRegistroConserje.Visible = false;
            panelOperaciones.Visible = false;
        }

        protected void btnPerfilVendedor_Click(object sender, EventArgs e)
        {
            btnGastos.BackColor = Color.White;
            btnMensajeria.BackColor = Color.White;
            btnReserva.BackColor = Color.White;
            btnLuces.BackColor = Color.White;
            btnPassword.BackColor = Color.White;
            btnPerfilPropietario.BackColor = Color.White;
            btnRegistroPropietario.BackColor = Color.White;
            btnPerfilVendedor.BackColor = Color.LightBlue;
            btnRegistroEst.BackColor = Color.White;
            btnReservaCentro.BackColor = Color.White;
            btnPagoGasto.BackColor = Color.White;
            btnControlLuces.BackColor = Color.White;
            btnPerfilConserje.BackColor = Color.White;
            btnMulta.BackColor = Color.White;
            btnPerfilAdmCondominio.BackColor = Color.White;
            btnRegistroConserje.BackColor = Color.White;
            btnRegistroLuces.BackColor = Color.White;
            btnAsignarLuz.BackColor = Color.White;
            btnPerfilAdm.BackColor = Color.White;
            btnRegistroPersonal.BackColor = Color.White;
            btnRegistroCondominio.BackColor = Color.White;
            btnRegistroCentro.BackColor = Color.White;
            btnOperacionesBasicas.BackColor = Color.White;

            panelGastos.Visible = false;
            panelMensajeria.Visible = false;
            panelReserva.Visible = false;
            panelLuces.Visible = false;
            panelPassword.Visible = false;
            panelPerfilProp.Visible = false;
            panelRegistroPropietario.Visible = false;
            panelPerfilVendedor.Visible = true;
            panelRegistroEst.Visible = false;
            panelReservaCentro.Visible = false;
            panelPagoGasto.Visible = false;
            panelControlLuz.Visible = false;
            panelPerfilConserje.Visible = false;
            panelRegistroLuz.Visible = false;
            panelAsignarLuz.Visible = false;
            panelPerfilAdm.Visible = false;
            panelRegistroPersonal.Visible = false;
            panelRegistroCondominio.Visible = false;
            panelRegistroCentro.Visible = false;
            panelPerfilAdmCondominio.Visible = false;
            panelMulta.Visible = false;
            panelRegistroConserje.Visible = false;
            panelOperaciones.Visible = false;
        }

        protected void btnRegistroEst_Click(object sender, EventArgs e)
        {
            btnGastos.BackColor = Color.White;
            btnMensajeria.BackColor = Color.White;
            btnReserva.BackColor = Color.White;
            btnLuces.BackColor = Color.White;
            btnPassword.BackColor = Color.White;
            btnPerfilPropietario.BackColor = Color.White;
            btnRegistroPropietario.BackColor = Color.White;
            btnPerfilVendedor.BackColor = Color.White;
            btnRegistroEst.BackColor = Color.LightBlue;
            btnReservaCentro.BackColor = Color.White;
            btnPagoGasto.BackColor = Color.White;
            btnControlLuces.BackColor = Color.White;
            btnPerfilConserje.BackColor = Color.White;
            btnMulta.BackColor = Color.White;
            btnPerfilAdmCondominio.BackColor = Color.White;
            btnRegistroConserje.BackColor = Color.White;
            btnRegistroLuces.BackColor = Color.White;
            btnAsignarLuz.BackColor = Color.White;
            btnPerfilAdm.BackColor = Color.White;
            btnRegistroPersonal.BackColor = Color.White;
            btnRegistroCondominio.BackColor = Color.White;
            btnRegistroCentro.BackColor = Color.White;
            btnOperacionesBasicas.BackColor = Color.White;

            panelGastos.Visible = false;
            panelMensajeria.Visible = false;
            panelReserva.Visible = false;
            panelLuces.Visible = false;
            panelPassword.Visible = false;
            panelPerfilProp.Visible = false;
            panelRegistroPropietario.Visible = false;
            panelPerfilVendedor.Visible = false;
            panelRegistroEst.Visible = true;
            panelReservaCentro.Visible = false;
            panelPagoGasto.Visible = false;
            panelControlLuz.Visible = false;
            panelPerfilConserje.Visible = false;
            panelRegistroLuz.Visible = false;
            panelAsignarLuz.Visible = false;
            panelPerfilAdm.Visible = false;
            panelRegistroPersonal.Visible = false;
            panelRegistroCondominio.Visible = false;
            panelRegistroCentro.Visible = false;
            panelMulta.Visible = false;
            panelRegistroConserje.Visible = false;
            panelOperaciones.Visible = false;
        }

        protected void btnReservaCentro_Click(object sender, EventArgs e)
        {
            btnGastos.BackColor = Color.White;
            btnMensajeria.BackColor = Color.White;
            btnReserva.BackColor = Color.White;
            btnLuces.BackColor = Color.White;
            btnPassword.BackColor = Color.White;
            btnPerfilPropietario.BackColor = Color.White;
            btnRegistroPropietario.BackColor = Color.White;
            btnPerfilVendedor.BackColor = Color.White;
            btnRegistroEst.BackColor = Color.White;
            btnReservaCentro.BackColor = Color.LightBlue;
            btnPagoGasto.BackColor = Color.White;
            btnControlLuces.BackColor = Color.White;
            btnPerfilConserje.BackColor = Color.White;
            btnMulta.BackColor = Color.White;
            btnPerfilAdmCondominio.BackColor = Color.White;
            btnRegistroConserje.BackColor = Color.White;
            btnRegistroLuces.BackColor = Color.White;
            btnAsignarLuz.BackColor = Color.White;
            btnPerfilAdm.BackColor = Color.White;
            btnRegistroPersonal.BackColor = Color.White;
            btnRegistroCondominio.BackColor = Color.White;
            btnRegistroCentro.BackColor = Color.White;
            btnOperacionesBasicas.BackColor = Color.White;

            panelGastos.Visible = false;
            panelMensajeria.Visible = false;
            panelReserva.Visible = false;
            panelLuces.Visible = false;
            panelPassword.Visible = false;
            panelPerfilProp.Visible = false;
            panelRegistroPropietario.Visible = false;
            panelPerfilVendedor.Visible = false;
            panelRegistroEst.Visible = false;
            panelReservaCentro.Visible = true;
            panelPagoGasto.Visible = false;
            panelControlLuz.Visible = false;
            panelPerfilConserje.Visible = false;
            panelRegistroLuz.Visible = false;
            panelAsignarLuz.Visible = false;
            panelPerfilAdm.Visible = false;
            panelRegistroPersonal.Visible = false;
            panelRegistroCondominio.Visible = false;
            panelRegistroCentro.Visible = false;
            panelMulta.Visible = false;
            panelRegistroConserje.Visible = false;
            panelOperaciones.Visible = false;
        }

        protected void btnPagoGasto_Click(object sender, EventArgs e)
        {
            btnGastos.BackColor = Color.White;
            btnMensajeria.BackColor = Color.White;
            btnReserva.BackColor = Color.White;
            btnLuces.BackColor = Color.White;
            btnPassword.BackColor = Color.White;
            btnPerfilPropietario.BackColor = Color.White;
            btnRegistroPropietario.BackColor = Color.White;
            btnPerfilVendedor.BackColor = Color.White;
            btnRegistroEst.BackColor = Color.White;
            btnReservaCentro.BackColor = Color.White;
            btnPagoGasto.BackColor = Color.LightBlue;
            btnControlLuces.BackColor = Color.White;
            btnPerfilConserje.BackColor = Color.White;
            btnMulta.BackColor = Color.White;
            btnPerfilAdmCondominio.BackColor = Color.White;
            btnRegistroConserje.BackColor = Color.White;
            btnRegistroLuces.BackColor = Color.White;
            btnAsignarLuz.BackColor = Color.White;
            btnPerfilAdm.BackColor = Color.White;
            btnRegistroPersonal.BackColor = Color.White;
            btnRegistroCondominio.BackColor = Color.White;
            btnRegistroCentro.BackColor = Color.White;
            btnOperacionesBasicas.BackColor = Color.White;

            panelGastos.Visible = false;
            panelMensajeria.Visible = false;
            panelReserva.Visible = false;
            panelLuces.Visible = false;
            panelPassword.Visible = false;
            panelPerfilProp.Visible = false;
            panelRegistroPropietario.Visible = false;
            panelPerfilVendedor.Visible = false;
            panelRegistroEst.Visible = false;
            panelReservaCentro.Visible = false;
            panelPagoGasto.Visible = true;
            panelControlLuz.Visible = false;
            panelPerfilConserje.Visible = false;
            panelRegistroLuz.Visible = false;
            panelAsignarLuz.Visible = false;
            panelPerfilAdm.Visible = false;
            panelRegistroPersonal.Visible = false;
            panelRegistroCondominio.Visible = false;
            panelRegistroCentro.Visible = false;
            panelMulta.Visible = false;
            panelRegistroConserje.Visible = false;
            panelOperaciones.Visible = false;
        }

        protected void btnControlLuces_Click(object sender, EventArgs e)
        {
            btnGastos.BackColor = Color.White;
            btnMensajeria.BackColor = Color.White;
            btnReserva.BackColor = Color.White;
            btnLuces.BackColor = Color.White;
            btnPassword.BackColor = Color.White;
            btnPerfilPropietario.BackColor = Color.White;
            btnRegistroPropietario.BackColor = Color.White;
            btnPerfilVendedor.BackColor = Color.White;
            btnRegistroEst.BackColor = Color.White;
            btnReservaCentro.BackColor = Color.White;
            btnPagoGasto.BackColor = Color.White;
            btnControlLuces.BackColor = Color.LightBlue;
            btnPerfilConserje.BackColor = Color.White;
            btnMulta.BackColor = Color.White;
            btnPerfilAdmCondominio.BackColor = Color.White;
            btnRegistroConserje.BackColor = Color.White;
            btnRegistroLuces.BackColor = Color.White;
            btnAsignarLuz.BackColor = Color.White;
            btnPerfilAdm.BackColor = Color.White;
            btnRegistroPersonal.BackColor = Color.White;
            btnRegistroCondominio.BackColor = Color.White;
            btnRegistroCentro.BackColor = Color.White;
            btnOperacionesBasicas.BackColor = Color.White;

            panelGastos.Visible = false;
            panelMensajeria.Visible = false;
            panelReserva.Visible = false;
            panelLuces.Visible = false;
            panelPassword.Visible = false;
            panelPerfilProp.Visible = false;
            panelRegistroPropietario.Visible = false;
            panelPerfilVendedor.Visible = false;
            panelRegistroEst.Visible = false;
            panelReservaCentro.Visible = false;
            panelPagoGasto.Visible = false;
            panelControlLuz.Visible = true;
            panelPerfilConserje.Visible = false;
            panelRegistroLuz.Visible = false;
            panelAsignarLuz.Visible = false;
            panelPerfilAdm.Visible = false;
            panelRegistroPersonal.Visible = false;
            panelRegistroCondominio.Visible = false;
            panelRegistroCentro.Visible = false;
            panelMulta.Visible = false;
            panelRegistroConserje.Visible = false;
            panelOperaciones.Visible = false;
        }

        protected void btnPerfilConserje_Click(object sender, EventArgs e)
        {
            btnGastos.BackColor = Color.White;
            btnMensajeria.BackColor = Color.White;
            btnReserva.BackColor = Color.White;
            btnLuces.BackColor = Color.White;
            btnPassword.BackColor = Color.White;
            btnPerfilPropietario.BackColor = Color.White;
            btnRegistroPropietario.BackColor = Color.White;
            btnPerfilVendedor.BackColor = Color.White;
            btnRegistroEst.BackColor = Color.White;
            btnReservaCentro.BackColor = Color.White;
            btnPagoGasto.BackColor = Color.White;
            btnControlLuces.BackColor = Color.White;
            btnPerfilConserje.BackColor = Color.LightBlue;
            btnMulta.BackColor = Color.White;
            btnPerfilAdmCondominio.BackColor = Color.White;
            btnRegistroConserje.BackColor = Color.White;
            btnRegistroLuces.BackColor = Color.White;
            btnAsignarLuz.BackColor = Color.White;
            btnPerfilAdm.BackColor = Color.White;
            btnRegistroPersonal.BackColor = Color.White;
            btnRegistroCondominio.BackColor = Color.White;
            btnRegistroCentro.BackColor = Color.White;
            btnOperacionesBasicas.BackColor = Color.White;

            panelGastos.Visible = false;
            panelMensajeria.Visible = false;
            panelReserva.Visible = false;
            panelLuces.Visible = false;
            panelPassword.Visible = false;
            panelPerfilProp.Visible = false;
            panelRegistroPropietario.Visible = false;
            panelPerfilVendedor.Visible = false;
            panelRegistroEst.Visible = false;
            panelReservaCentro.Visible = false;
            panelPagoGasto.Visible = false;
            panelControlLuz.Visible = false;
            panelPerfilConserje.Visible = true;
            panelRegistroLuz.Visible = false;
            panelAsignarLuz.Visible = false;
            panelPerfilAdm.Visible = false;
            panelRegistroPersonal.Visible = false;
            panelRegistroCondominio.Visible = false;
            panelRegistroCentro.Visible = false;
            panelMulta.Visible = false;
            panelRegistroConserje.Visible = false;
            panelOperaciones.Visible = false;
        }

        protected void btnMulta_Click(object sender, EventArgs e)
        {
            btnGastos.BackColor = Color.White;
            btnMensajeria.BackColor = Color.White;
            btnReserva.BackColor = Color.White;
            btnLuces.BackColor = Color.White;
            btnPassword.BackColor = Color.White;
            btnPerfilPropietario.BackColor = Color.White;
            btnRegistroPropietario.BackColor = Color.White;
            btnPerfilVendedor.BackColor = Color.White;
            btnRegistroEst.BackColor = Color.White;
            btnReservaCentro.BackColor = Color.White;
            btnPagoGasto.BackColor = Color.White;
            btnControlLuces.BackColor = Color.White;
            btnPerfilConserje.BackColor = Color.White;
            btnMulta.BackColor = Color.LightBlue;
            btnPerfilAdmCondominio.BackColor = Color.White;
            btnRegistroConserje.BackColor = Color.White;
            btnRegistroLuces.BackColor = Color.White;
            btnAsignarLuz.BackColor = Color.White;
            btnPerfilAdm.BackColor = Color.White;
            btnRegistroPersonal.BackColor = Color.White;
            btnRegistroCondominio.BackColor = Color.White;
            btnRegistroCentro.BackColor = Color.White;
            btnOperacionesBasicas.BackColor = Color.White;

            panelGastos.Visible = false;
            panelMensajeria.Visible = false;
            panelReserva.Visible = false;
            panelLuces.Visible = false;
            panelPassword.Visible = false;
            panelPerfilProp.Visible = false;
            panelRegistroPropietario.Visible = false;
            panelPerfilVendedor.Visible = false;
            panelRegistroEst.Visible = false;
            panelReservaCentro.Visible = false;
            panelPagoGasto.Visible = false;
            panelControlLuz.Visible = false;
            panelMulta.Visible = true;
            panelPerfilConserje.Visible = false;
            panelRegistroLuz.Visible = false;
            panelAsignarLuz.Visible = false;
            panelPerfilAdm.Visible = false;
            panelRegistroPersonal.Visible = false;
            panelRegistroCondominio.Visible = false;
            panelRegistroCentro.Visible = false;
            panelRegistroConserje.Visible = false;
            panelOperaciones.Visible = false;
        }

        protected void btnPerfilAdmCondominio_Click(object sender, EventArgs e)
        {
            btnGastos.BackColor = Color.White;
            btnMensajeria.BackColor = Color.White;
            btnReserva.BackColor = Color.White;
            btnLuces.BackColor = Color.White;
            btnPassword.BackColor = Color.White;
            btnPerfilPropietario.BackColor = Color.White;
            btnRegistroPropietario.BackColor = Color.White;
            btnPerfilVendedor.BackColor = Color.White;
            btnRegistroEst.BackColor = Color.White;
            btnReservaCentro.BackColor = Color.White;
            btnPagoGasto.BackColor = Color.White;
            btnControlLuces.BackColor = Color.White;
            btnPerfilConserje.BackColor = Color.White;
            btnMulta.BackColor = Color.White;
            btnPerfilAdmCondominio.BackColor = Color.LightBlue;
            btnRegistroConserje.BackColor = Color.White;
            btnRegistroLuces.BackColor = Color.White;
            btnAsignarLuz.BackColor = Color.White;
            btnPerfilAdm.BackColor = Color.White;
            btnRegistroPersonal.BackColor = Color.White;
            btnRegistroCondominio.BackColor = Color.White;
            btnRegistroCentro.BackColor = Color.White;
            btnOperacionesBasicas.BackColor = Color.White;

            panelGastos.Visible = false;
            panelMensajeria.Visible = false;
            panelReserva.Visible = false;
            panelLuces.Visible = false;
            panelPassword.Visible = false;
            panelPerfilProp.Visible = false;
            panelRegistroPropietario.Visible = false;
            panelPerfilVendedor.Visible = false;
            panelRegistroEst.Visible = false;
            panelReservaCentro.Visible = false;
            panelPagoGasto.Visible = false;
            panelControlLuz.Visible = false;
            panelPerfilAdmCondominio.Visible = true;
            panelPerfilConserje.Visible = false;
            panelRegistroLuz.Visible = false;
            panelAsignarLuz.Visible = false;
            panelPerfilAdm.Visible = false;
            panelRegistroPersonal.Visible = false;
            panelRegistroCondominio.Visible = false;
            panelRegistroCentro.Visible = false;
            panelMulta.Visible = false;
            panelRegistroConserje.Visible = false;
            panelOperaciones.Visible = false;
        }

        protected void btnRegistroConserje_Click(object sender, EventArgs e)
        {
            btnGastos.BackColor = Color.White;
            btnMensajeria.BackColor = Color.White;
            btnReserva.BackColor = Color.White;
            btnLuces.BackColor = Color.White;
            btnPassword.BackColor = Color.White;
            btnPerfilPropietario.BackColor = Color.White;
            btnRegistroPropietario.BackColor = Color.White;
            btnPerfilVendedor.BackColor = Color.White;
            btnRegistroEst.BackColor = Color.White;
            btnReservaCentro.BackColor = Color.White;
            btnPagoGasto.BackColor = Color.White;
            btnControlLuces.BackColor = Color.White;
            btnPerfilConserje.BackColor = Color.White;
            btnMulta.BackColor = Color.White;
            btnPerfilAdmCondominio.BackColor = Color.White;
            btnRegistroConserje.BackColor = Color.LightBlue;
            btnRegistroLuces.BackColor = Color.White;
            btnAsignarLuz.BackColor = Color.White;
            btnPerfilAdm.BackColor = Color.White;
            btnRegistroPersonal.BackColor = Color.White;
            btnRegistroCondominio.BackColor = Color.White;
            btnRegistroCentro.BackColor = Color.White;
            btnOperacionesBasicas.BackColor = Color.White;

            panelGastos.Visible = false;
            panelMensajeria.Visible = false;
            panelReserva.Visible = false;
            panelLuces.Visible = false;
            panelPassword.Visible = false;
            panelPerfilProp.Visible = false;
            panelRegistroPropietario.Visible = false;
            panelPerfilVendedor.Visible = false;
            panelRegistroEst.Visible = false;
            panelReservaCentro.Visible = false;
            panelPagoGasto.Visible = false;
            panelControlLuz.Visible = false;
            panelPerfilConserje.Visible = false;
            panelRegistroLuz.Visible = false;
            panelAsignarLuz.Visible = false;
            panelPerfilAdm.Visible = false;
            panelRegistroPersonal.Visible = false;
            panelRegistroCondominio.Visible = false;
            panelRegistroCentro.Visible = false;
            panelPerfilAdmCondominio.Visible = false;
            panelMulta.Visible = false;
            panelRegistroConserje.Visible = true;
            panelOperaciones.Visible = false;
        }

        protected void btnRegistroLuces_Click(object sender, EventArgs e)
        {
            btnGastos.BackColor = Color.White;
            btnMensajeria.BackColor = Color.White;
            btnReserva.BackColor = Color.White;
            btnLuces.BackColor = Color.White;
            btnPassword.BackColor = Color.White;
            btnPerfilPropietario.BackColor = Color.White;
            btnRegistroPropietario.BackColor = Color.White;
            btnPerfilVendedor.BackColor = Color.White;
            btnRegistroEst.BackColor = Color.White;
            btnReservaCentro.BackColor = Color.White;
            btnPagoGasto.BackColor = Color.White;
            btnControlLuces.BackColor = Color.White;
            btnPerfilConserje.BackColor = Color.White;
            btnMulta.BackColor = Color.White;
            btnPerfilAdmCondominio.BackColor = Color.White;
            btnRegistroConserje.BackColor = Color.White;
            btnRegistroLuces.BackColor = Color.LightBlue;
            btnAsignarLuz.BackColor = Color.White;
            btnPerfilAdm.BackColor = Color.White;
            btnRegistroPersonal.BackColor = Color.White;
            btnRegistroCondominio.BackColor = Color.White;
            btnRegistroCentro.BackColor = Color.White;
            btnOperacionesBasicas.BackColor = Color.White;

            panelGastos.Visible = false;
            panelMensajeria.Visible = false;
            panelReserva.Visible = false;
            panelLuces.Visible = false;
            panelPassword.Visible = false;
            panelPerfilProp.Visible = false;
            panelRegistroPropietario.Visible = false;
            panelPerfilVendedor.Visible = false;
            panelRegistroEst.Visible = false;
            panelReservaCentro.Visible = false;
            panelPagoGasto.Visible = false;
            panelControlLuz.Visible = false;
            panelPerfilConserje.Visible = false;
            panelRegistroLuz.Visible = true;
            panelAsignarLuz.Visible = false;
            panelPerfilAdm.Visible = false;
            panelRegistroPersonal.Visible = false;
            panelRegistroCondominio.Visible = false;
            panelRegistroCentro.Visible = false;
            panelPerfilAdmCondominio.Visible = false;
            panelMulta.Visible = false;
            panelRegistroConserje.Visible = false;
            panelOperaciones.Visible = false;
        }

        protected void btnAsignarLuz_Click(object sender, EventArgs e)
        {
            btnGastos.BackColor = Color.White;
            btnMensajeria.BackColor = Color.White;
            btnReserva.BackColor = Color.White;
            btnLuces.BackColor = Color.White;
            btnPassword.BackColor = Color.White;
            btnPerfilPropietario.BackColor = Color.White;
            btnRegistroPropietario.BackColor = Color.White;
            btnPerfilVendedor.BackColor = Color.White;
            btnRegistroEst.BackColor = Color.White;
            btnReservaCentro.BackColor = Color.White;
            btnPagoGasto.BackColor = Color.White;
            btnControlLuces.BackColor = Color.White;
            btnPerfilConserje.BackColor = Color.White;
            btnMulta.BackColor = Color.White;
            btnPerfilAdmCondominio.BackColor = Color.White;
            btnRegistroConserje.BackColor = Color.White;
            btnRegistroLuces.BackColor = Color.White;
            btnAsignarLuz.BackColor = Color.LightBlue;
            btnPerfilAdm.BackColor = Color.White;
            btnRegistroPersonal.BackColor = Color.White;
            btnRegistroCondominio.BackColor = Color.White;
            btnRegistroCentro.BackColor = Color.White;
            btnOperacionesBasicas.BackColor = Color.White;

            panelGastos.Visible = false;
            panelMensajeria.Visible = false;
            panelReserva.Visible = false;
            panelLuces.Visible = false;
            panelPassword.Visible = false;
            panelPerfilProp.Visible = false;
            panelRegistroPropietario.Visible = false;
            panelPerfilVendedor.Visible = false;
            panelRegistroEst.Visible = false;
            panelReservaCentro.Visible = false;
            panelPagoGasto.Visible = false;
            panelControlLuz.Visible = false;
            panelPerfilConserje.Visible = false;
            panelRegistroLuz.Visible = false;
            panelAsignarLuz.Visible = true;
            panelPerfilAdm.Visible = false;
            panelRegistroPersonal.Visible = false;
            panelRegistroCondominio.Visible = false;
            panelRegistroCentro.Visible = false;
            panelPerfilAdmCondominio.Visible = false;
            panelMulta.Visible = false;
            panelRegistroConserje.Visible = false;
            panelOperaciones.Visible = false;
        }

        protected void btnPerfilAdm_Click(object sender, EventArgs e)
        {
            btnGastos.BackColor = Color.White;
            btnMensajeria.BackColor = Color.White;
            btnReserva.BackColor = Color.White;
            btnLuces.BackColor = Color.White;
            btnPassword.BackColor = Color.White;
            btnPerfilPropietario.BackColor = Color.White;
            btnRegistroPropietario.BackColor = Color.White;
            btnPerfilVendedor.BackColor = Color.White;
            btnRegistroEst.BackColor = Color.White;
            btnReservaCentro.BackColor = Color.White;
            btnPagoGasto.BackColor = Color.White;
            btnControlLuces.BackColor = Color.White;
            btnPerfilConserje.BackColor = Color.White;
            btnMulta.BackColor = Color.White;
            btnPerfilAdmCondominio.BackColor = Color.White;
            btnRegistroConserje.BackColor = Color.White;
            btnRegistroLuces.BackColor = Color.White;
            btnAsignarLuz.BackColor = Color.White;
            btnPerfilAdm.BackColor = Color.LightBlue;
            btnRegistroPersonal.BackColor = Color.White;
            btnRegistroCondominio.BackColor = Color.White;
            btnRegistroCentro.BackColor = Color.White;
            btnOperacionesBasicas.BackColor = Color.White;

            panelGastos.Visible = false;
            panelMensajeria.Visible = false;
            panelReserva.Visible = false;
            panelLuces.Visible = false;
            panelPassword.Visible = false;
            panelPerfilProp.Visible = false;
            panelRegistroPropietario.Visible = false;
            panelPerfilVendedor.Visible = false;
            panelRegistroEst.Visible = false;
            panelReservaCentro.Visible = false;
            panelPagoGasto.Visible = false;
            panelControlLuz.Visible = false;
            panelPerfilConserje.Visible = false;
            panelRegistroLuz.Visible = false;
            panelAsignarLuz.Visible = false;
            panelPerfilAdm.Visible = true;
            panelRegistroPersonal.Visible = false;
            panelRegistroCondominio.Visible = false;
            panelRegistroCentro.Visible = false;
            panelMulta.Visible = false;
            panelRegistroConserje.Visible = false;
            panelOperaciones.Visible = false;
        }

        protected void btnRegistroPersonal_Click(object sender, EventArgs e)
        {
            btnGastos.BackColor = Color.White;
            btnMensajeria.BackColor = Color.White;
            btnReserva.BackColor = Color.White;
            btnLuces.BackColor = Color.White;
            btnPassword.BackColor = Color.White;
            btnPerfilPropietario.BackColor = Color.White;
            btnRegistroPropietario.BackColor = Color.White;
            btnPerfilVendedor.BackColor = Color.White;
            btnRegistroEst.BackColor = Color.White;
            btnReservaCentro.BackColor = Color.White;
            btnPagoGasto.BackColor = Color.White;
            btnControlLuces.BackColor = Color.White;
            btnPerfilConserje.BackColor = Color.White;
            btnMulta.BackColor = Color.White;
            btnPerfilAdmCondominio.BackColor = Color.White;
            btnRegistroConserje.BackColor = Color.White;
            btnRegistroLuces.BackColor = Color.White;
            btnAsignarLuz.BackColor = Color.White;
            btnPerfilAdm.BackColor = Color.White;
            btnRegistroPersonal.BackColor = Color.LightBlue;
            btnRegistroCondominio.BackColor = Color.White;
            btnRegistroCentro.BackColor = Color.White;
            btnOperacionesBasicas.BackColor = Color.White;

            panelGastos.Visible = false;
            panelMensajeria.Visible = false;
            panelReserva.Visible = false;
            panelLuces.Visible = false;
            panelPassword.Visible = false;
            panelPerfilProp.Visible = false;
            panelRegistroPropietario.Visible = false;
            panelPerfilVendedor.Visible = false;
            panelRegistroEst.Visible = false;
            panelReservaCentro.Visible = false;
            panelPagoGasto.Visible = false;
            panelControlLuz.Visible = false;
            panelPerfilConserje.Visible = false;
            panelRegistroLuz.Visible = false;
            panelAsignarLuz.Visible = false;
            panelPerfilAdm.Visible = false;
            panelRegistroPersonal.Visible = true;
            panelRegistroCondominio.Visible = false;
            panelRegistroCentro.Visible = false;
            panelMulta.Visible = false;
            panelRegistroConserje.Visible = false;
            panelOperaciones.Visible = false;
        }

        protected void btnRegistroCondominio_Click(object sender, EventArgs e)
        {
            btnGastos.BackColor = Color.White;
            btnMensajeria.BackColor = Color.White;
            btnReserva.BackColor = Color.White;
            btnLuces.BackColor = Color.White;
            btnPassword.BackColor = Color.White;
            btnPerfilPropietario.BackColor = Color.White;
            btnRegistroPropietario.BackColor = Color.White;
            btnPerfilVendedor.BackColor = Color.White;
            btnRegistroEst.BackColor = Color.White;
            btnReservaCentro.BackColor = Color.White;
            btnPagoGasto.BackColor = Color.White;
            btnControlLuces.BackColor = Color.White;
            btnPerfilConserje.BackColor = Color.White;
            btnMulta.BackColor = Color.White;
            btnPerfilAdmCondominio.BackColor = Color.White;
            btnRegistroConserje.BackColor = Color.White;
            btnRegistroLuces.BackColor = Color.White;
            btnAsignarLuz.BackColor = Color.White;
            btnPerfilAdm.BackColor = Color.White;
            btnRegistroPersonal.BackColor = Color.White;
            btnRegistroCondominio.BackColor = Color.LightBlue;
            btnRegistroCentro.BackColor = Color.White;
            btnOperacionesBasicas.BackColor = Color.White;

            panelGastos.Visible = false;
            panelMensajeria.Visible = false;
            panelReserva.Visible = false;
            panelLuces.Visible = false;
            panelPassword.Visible = false;
            panelPerfilProp.Visible = false;
            panelRegistroPropietario.Visible = false;
            panelPerfilVendedor.Visible = false;
            panelRegistroEst.Visible = false;
            panelReservaCentro.Visible = false;
            panelPagoGasto.Visible = false;
            panelControlLuz.Visible = false;
            panelPerfilConserje.Visible = false;
            panelRegistroLuz.Visible = false;
            panelAsignarLuz.Visible = false;
            panelPerfilAdm.Visible = false;
            panelRegistroPersonal.Visible = false;
            panelRegistroCondominio.Visible = true;
            panelRegistroCentro.Visible = false;
            panelMulta.Visible = false;
            panelRegistroConserje.Visible = false;
            panelOperaciones.Visible = false;
        }

        protected void btnRegistroCentro_Click(object sender, EventArgs e)
        {
            btnGastos.BackColor = Color.White;
            btnMensajeria.BackColor = Color.White;
            btnReserva.BackColor = Color.White;
            btnLuces.BackColor = Color.White;
            btnPassword.BackColor = Color.White;
            btnPerfilPropietario.BackColor = Color.White;
            btnRegistroPropietario.BackColor = Color.White;
            btnPerfilVendedor.BackColor = Color.White;
            btnRegistroEst.BackColor = Color.White;
            btnReservaCentro.BackColor = Color.White;
            btnPagoGasto.BackColor = Color.White;
            btnControlLuces.BackColor = Color.White;
            btnPerfilConserje.BackColor = Color.White;
            btnMulta.BackColor = Color.White;
            btnPerfilAdmCondominio.BackColor = Color.White;
            btnRegistroConserje.BackColor = Color.White;
            btnRegistroLuces.BackColor = Color.White;
            btnAsignarLuz.BackColor = Color.White;
            btnPerfilAdm.BackColor = Color.White;
            btnRegistroPersonal.BackColor = Color.White;
            btnRegistroCondominio.BackColor = Color.White;
            btnRegistroCentro.BackColor = Color.LightBlue;
            btnOperacionesBasicas.BackColor = Color.White;

            panelGastos.Visible = false;
            panelMensajeria.Visible = false;
            panelReserva.Visible = false;
            panelLuces.Visible = false;
            panelPassword.Visible = false;
            panelPerfilProp.Visible = false;
            panelRegistroPropietario.Visible = false;
            panelPerfilVendedor.Visible = false;
            panelRegistroEst.Visible = false;
            panelReservaCentro.Visible = false;
            panelPagoGasto.Visible = false;
            panelControlLuz.Visible = false;
            panelPerfilConserje.Visible = false;
            panelRegistroLuz.Visible = false;
            panelAsignarLuz.Visible = false;
            panelPerfilAdm.Visible = false;
            panelRegistroPersonal.Visible = false;
            panelRegistroCondominio.Visible = false;
            panelRegistroCentro.Visible = true;
            panelMulta.Visible = false;
            panelRegistroConserje.Visible = false;
            panelOperaciones.Visible = false;
        }
    }
}