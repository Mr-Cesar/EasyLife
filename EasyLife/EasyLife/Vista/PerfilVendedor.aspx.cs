using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace EasyLife.Vista
{
    public partial class PerfilVendedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validación de Session Iniciada
            LOGIN adm = (LOGIN)Session["adm"];
            LOGIN conserje = (LOGIN)Session["conserje"];
            LOGIN vendedor = (LOGIN)Session["vendedor"];
            LOGIN propietario = (LOGIN)Session["login"];
            LOGIN admCondominio = (LOGIN)Session["admCondominio"];
            if (adm != null || conserje != null || propietario != null || admCondominio != null)
            {
                Response.Redirect("Index.aspx");
            }
            else if (adm == null && conserje == null && vendedor == null && propietario == null && admCondominio == null)
            {
                Response.Redirect("Index.aspx");
            }

            if (!IsPostBack)
            {
                cargarDatos(vendedor.ID_PERSONA);
                cargarCondominio();
                cargarPropietario();
            }
        }

        private static List<Adapter.AdapterPropietario> listaPropietarios = new List<Adapter.AdapterPropietario>();
        private static List<Adapter.AdapterPropietario> listaSearchPropietarios = new List<Adapter.AdapterPropietario>();
        private static Boolean search = false;

        public void cargarCondominio()
        {
            List<CONDOMINIO> lista = Controller.ControllerCondominio.listaCondominio();
            dplCondominioVendedor.DataSource = lista;
            dplCondominioVendedor.DataValueField = "ID_CONDOMINIO";
            dplCondominioVendedor.DataTextField = "NOMBRE_CONDOMINIO";
            dplCondominioVendedor.DataBind();
            dplCondominioVendedor.Items.Insert(0, "Seleccione un Condominio");
            dplCondominioVendedor.SelectedIndex = 0;
        }

        public void cargarDatos(long persona)
        {
            PERSONA aux = Controller.ControllerPersona.buscarIdPersona(persona);
            lbUser.Text = aux.NOMBRE_PERSONA;
            lbRut.Text = aux.FK_RUT;
            lbNombre.Text = aux.NOMBRE_PERSONA;
            lbApellido.Text = aux.APELLIDO_PERSONA;
            lbTelefono.Text = aux.TELEFONO_PERSONA;
            lbCorreo.Text = aux.CORREO_PERSONA;
        }

        public void cargarPropietario()
        {
            listaPropietarios = new List<Adapter.AdapterPropietario>();
            listaPropietarios = Controller.ControllerPersona.listaPropietarios();
            grPropietarios.DataSource = listaPropietarios;
            grPropietarios.DataBind();
        }

        protected void btnDatosUsuario_Click(object sender, EventArgs e)
        {
            panelDatos.Visible = true;
            panelPropietario.Visible = false;
            panelMensajes.Visible = false;
            panelAvisos.Visible = false;

            btnDatosUsuario.BackColor = Color.LightBlue;
            btnPropietarios.BackColor = Color.White;
            btnMensajes.BackColor = Color.White;
            btnAvisos.BackColor = Color.White;

            limpiarVariables();
        }

        protected void btnPropietarios_Click(object sender, EventArgs e)
        {
            panelDatos.Visible = false;
            panelPropietario.Visible = true;
            panelMensajes.Visible = false;
            panelAvisos.Visible = false;

            btnDatosUsuario.BackColor = Color.White;
            btnPropietarios.BackColor = Color.LightBlue;
            btnMensajes.BackColor = Color.White;
            btnAvisos.BackColor = Color.White;

            limpiarVariables();
        }

        protected void btnMensajes_Click(object sender, EventArgs e)
        {
            panelDatos.Visible = false;
            panelPropietario.Visible = false;
            panelMensajes.Visible = true;
            panelAvisos.Visible = false;

            btnDatosUsuario.BackColor = Color.White;
            btnPropietarios.BackColor = Color.White;
            btnMensajes.BackColor = Color.LightBlue;
            btnAvisos.BackColor = Color.White;

            limpiarVariables();
        }

        protected void btnAvisos_Click(object sender, EventArgs e)
        {
            panelDatos.Visible = false;
            panelPropietario.Visible = false;
            panelMensajes.Visible = false;
            panelAvisos.Visible = true;

            btnDatosUsuario.BackColor = Color.White;
            btnPropietarios.BackColor = Color.White;
            btnMensajes.BackColor = Color.White;
            btnAvisos.BackColor = Color.LightBlue;

            limpiarVariables();
        }

        public void limpiarVariables()
        {
            //Search
            lbErrorSearchPropietario.Visible = false;
            lbErrorCondominio.Visible = false;
            dplCondominioVendedor.SelectedIndex = 0;
            txtSearchPropietario.Text = "";
            grPropietarios.Visible = true;
            grPropietarios.DataSource = listaPropietarios;
            grPropietarios.DataBind();
            listaSearchPropietarios = new List<Adapter.AdapterPropietario>();
            panelDetalle.Visible = false;
            btnModificarPropietario.Enabled = false;
            search = false;

            //Limpiar Sessiones
            Session["ModificarPropietario"] = null;
        }

        protected void lnkModificarDatos_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModificarDatos.aspx");
        }

        protected void lnkModificarPassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("CambiarPassword.aspx");
        }

        protected void btnSearchPropietario_Click(object sender, EventArgs e)
        {
            panelDetalle.Visible = false;
            btnModificarPropietario.Enabled = false;
            listaSearchPropietarios = new List<Adapter.AdapterPropietario>();
            listaSearchPropietarios = Controller.ControllerPersona.searchListaPropietario(txtSearchPropietario.Text);
            if (listaSearchPropietarios.Count > 0)
            {
                lbErrorSearchPropietario.Visible = false;
                grPropietarios.DataSource = listaSearchPropietarios;
                grPropietarios.DataBind();
                search = true;
            }
            else
            {
                lbErrorSearchPropietario.Visible = true;
                listaSearchPropietarios = new List<Adapter.AdapterPropietario>();
                grPropietarios.DataSource = listaSearchPropietarios;
                grPropietarios.DataBind();
                search = false;
            }
        }

        protected void btnRegistroPropietario_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistroPropietario.aspx");
        }

        protected void btnModificarPropietario_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistroPropietario.aspx");
        }

        protected void dplCondominioVendedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lbErrorCondominio.Visible = false;
                panelDetalle.Visible = false;
                btnModificarPropietario.Enabled = false;
                long condominio = Convert.ToInt64(dplCondominioVendedor.SelectedValue);
                listaSearchPropietarios = new List<Adapter.AdapterPropietario>();
                foreach (Adapter.AdapterPropietario item in listaPropietarios)
                {
                    if (item._ID_CONDOMINIO == condominio)
                    {
                        listaSearchPropietarios.Add(item);
                    }
                }

                if (listaSearchPropietarios.Count > 0)
                {
                    lbCondominioFiltro.Visible = true;
                    btnModificarPropietario.Enabled = false;
                    grPropietarios.Visible = true;
                    grPropietarios.DataSource = listaSearchPropietarios;
                    grPropietarios.DataBind();
                    search = true;
                }
                else
                {
                    lbCondominioFiltro.Visible = false;
                    btnModificarPropietario.Enabled = false;
                    lbErrorCondominio.Visible = true;
                    grPropietarios.Visible = false;
                    panelDetalle.Visible = false;
                    search = false;
                }
            }
            catch (Exception ex)
            {
                lbCondominioFiltro.Visible = true;
                btnModificarPropietario.Enabled = false;
                grPropietarios.Visible = true;
                grPropietarios.DataSource = listaPropietarios;
                grPropietarios.DataBind();
                search = false;
                lbErrorCondominio.Visible = false;
                System.Diagnostics.Debug.WriteLine("Error:  " + ex);
            }
        }

        protected void grPropietarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (search == true)
            {
                panelDetalle.Visible = true;
                btnModificarPropietario.Enabled = true;
                Adapter.AdapterPropietario prop = new Adapter.AdapterPropietario();
                GridViewRow gvr = grPropietarios.SelectedRow;
                long propietario = (long)grPropietarios.DataKeys[gvr.RowIndex].Value;
                long position = grPropietarios.SelectedIndex;
                prop = listaSearchPropietarios[Convert.ToInt32(position)];

                lbDRut.Text = prop._FK_RUT;
                lbDNombre.Text = prop._NOMBRE_PERSONA + " " + prop._APELLIDO_PERSONA;
                lbDTelefono.Text = prop._TELEFONO_PERSONA;
                lbDCorreo.Text = prop._CORREO_PERSONA;
                lbCondominio.Text = prop._NOMBRE_CONDOMINIO;
                lbEdificio.Text = prop._NOMBRE_EDIFICIO;
                lbDep.Text = prop._NUMERO_DEP;

                if (prop._ESTADO_PERSONA == true)
                {
                    lbDEstado.Text = "Activo";
                }
                else
                {
                    lbDEstado.Text = "Inactivo";
                }
                Session["ModificarPropietario"] = propietario.ToString();
            }
            else
            {
                panelDetalle.Visible = true;
                btnModificarPropietario.Enabled = true;
                Adapter.AdapterPropietario prop = new Adapter.AdapterPropietario();
                GridViewRow gvr = grPropietarios.SelectedRow;
                long propietario = (long)grPropietarios.DataKeys[gvr.RowIndex].Value;
                long position = grPropietarios.SelectedIndex;
                prop = listaPropietarios[Convert.ToInt32(position)];

                lbDRut.Text = prop._FK_RUT;
                lbDNombre.Text = prop._NOMBRE_PERSONA + " " + prop._APELLIDO_PERSONA;
                lbDTelefono.Text = prop._TELEFONO_PERSONA;
                lbDCorreo.Text = prop._CORREO_PERSONA;
                lbCondominio.Text = prop._NOMBRE_CONDOMINIO;
                lbEdificio.Text = prop._NOMBRE_EDIFICIO;
                lbDep.Text = prop._NUMERO_DEP;

                if (prop._ESTADO_PERSONA == true)
                {
                    lbDEstado.Text = "Activo";
                }
                else
                {
                    lbDEstado.Text = "Inactivo";
                }
                Session["ModificarPropietario"] = propietario.ToString();
            }
        }

        protected void grPropietarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (search == true)
            {
                grPropietarios.PageIndex = e.NewPageIndex;
                grPropietarios.DataSource = listaSearchPropietarios;
                grPropietarios.DataBind();
            }
            else
            {
                grPropietarios.PageIndex = e.NewPageIndex;
                grPropietarios.DataSource = listaPropietarios;
                grPropietarios.DataBind();
            }
        }
    }
}