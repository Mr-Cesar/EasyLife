using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EasyLife.Vista
{
    public partial class RegistroCondominio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validación de Session Iniciada
            LOGIN adm = (LOGIN)Session["adm"];
            LOGIN conserje = (LOGIN)Session["conserje"];
            LOGIN vendedor = (LOGIN)Session["vendedor"];
            LOGIN propietario = (LOGIN)Session["login"];
            LOGIN admCondominio = (LOGIN)Session["admCondominio"];
            if (conserje != null || vendedor != null || propietario != null || admCondominio != null)
            {
                Response.Redirect("Index.aspx");
            }
            else if (adm == null && conserje == null && vendedor == null && propietario == null && admCondominio == null)
            {
                Response.Redirect("Index.aspx");
            }

            if (!IsPostBack)
            {
                cargarRegion();
                cargarAdministrador();
                string pagoCondominio = (string)Session["CondominioSinPago"];
                if (pagoCondominio != null)
                {
                    Response.Redirect("RegistroGasto.aspx");
                }
            }
        }

        private static List<string> listaLetras = new List<string>() {"", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "Ñ", "O", "P",
                        "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};

        public void cargarRegion()
        {
            List<REGION> lista = Controller.ControllerRegion.listaRegion();
            dplRegion.DataSource = lista;
            dplRegion.DataValueField = "ID_REGION";
            dplRegion.DataTextField = "NOMBRE_REGION";
            dplRegion.DataBind();
            dplRegion.Items.Insert(0, "Seleccione una Region");
            dplRegion.SelectedIndex = 0;
        }

        public void cargarAdministrador()
        {
            long rol = 5;
            List<PERSONA> lista = Controller.ControllerPersona.listaPersonalRol(rol);
            dplAdministrador.DataSource = lista;
            dplAdministrador.DataValueField = "ID_PERSONA";
            dplAdministrador.DataTextField = "FK_RUT";
            dplAdministrador.DataBind();
            dplAdministrador.Items.Insert(0, "Seleccione un Administrador");
            dplAdministrador.SelectedIndex = 0;
        }

        protected void dplRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                long region = Convert.ToInt64(dplRegion.SelectedValue);
                List<CIUDAD> lista = Controller.ControllerCiudad.listaCiudad(region);
                dplCiudad.DataSource = lista;
                dplCiudad.DataValueField = "ID_CIUDAD";
                dplCiudad.DataTextField = "NOMBRE_CIUDAD";
                dplCiudad.DataBind();
                dplCiudad.Items.Insert(0, "Seleccione una Ciudad");
                dplCiudad.SelectedIndex = 0;

                dplComuna.Items.Insert(0, "Seleccione una Comuna");
                dplComuna.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                dplCiudad.Items.Insert(0, "Seleccione una Ciudad");
                dplCiudad.SelectedIndex = 0;
                dplComuna.Items.Insert(0, "Seleccione una Comuna");
                dplComuna.SelectedIndex = 0;
                System.Diagnostics.Debug.WriteLine("Error " + ex);
            }
        }

        protected void dplCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                long ciudad = Convert.ToInt64(dplCiudad.SelectedValue);
                List<COMUNA> lista = Controller.ControllerComuna.listaCiudad(ciudad);
                dplComuna.DataSource = lista;
                dplComuna.DataValueField = "ID_COMUNA";
                dplComuna.DataTextField = "NOMBRE_COMUNA";
                dplComuna.DataBind();
                dplComuna.Items.Insert(0, "Seleccione una Comuna");
                dplComuna.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                dplComuna.Items.Insert(0, "Seleccione una Comuna");
                dplComuna.SelectedIndex = 0;
                System.Diagnostics.Debug.WriteLine("Error " + ex);
            }
        }

        protected void btnRegistroCondominio_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            string resultDireccion = Controller.ControllerDireccion.crearDireccion(Convert.ToInt64(dplComuna.SelectedValue), txtCalle.Text,
                Convert.ToInt32(txtNumero.Text));
            if (resultDireccion.Equals("Direccion Creada"))
            {
                DIRECCION direccion = Controller.ControllerDireccion.buscarDireccion(Convert.ToInt64(dplComuna.SelectedValue), txtCalle.Text,
                    Convert.ToInt32(txtNumero.Text));
                string resulCondominio = Controller.ControllerCondominio.crearCondominio(direccion.ID_DIRECCION, Convert.ToInt64(dplAdministrador.SelectedValue),
                    txtNombre.Text, Convert.ToInt32(txtEst.Text));
                if (resulCondominio.Equals("Condominio Creado"))
                {
                    string nomEdificio = txtPrefijo.Text;
                    int cantEdificio = Convert.ToInt32(txtCantidadE.Text);
                    int piso = Convert.ToInt32(txtPiso.Text);
                    int dep = Convert.ToInt32(txtDepartamento.Text);
                    string nombreE = "";
                    string numeroDep = "";
                    string resultEdificio = "";
                    string resultDep = "";
                    string letra = "";
                    CONDOMINIO condominio = Controller.ControllerCondominio.buscarCondominio(direccion.ID_DIRECCION);
                    if (radioEdificios.SelectedIndex == 0)
                    {
                        for (int i = 1; i <= cantEdificio; i++)
                        {
                            nombreE = nomEdificio + " " + listaLetras[i];
                            resultEdificio = Controller.ControllerEdificio.crearEdificio(condominio.ID_CONDOMINIO, nombreE, piso, dep);
                        }

                        if (resultEdificio.Equals("Edificio Creado"))
                        {
                            int index = 1;
                            List<EDIFICIO> listaEdificio = Controller.ControllerEdificio.buscarEdificioCondominio(condominio.ID_CONDOMINIO);
                            foreach (EDIFICIO item in listaEdificio)
                            {
                                letra = listaLetras[index];
                                for (int i = 1; i <= dep; i++)
                                {
                                    numeroDep = letra + " " + i;
                                    resultDep = Controller.ControllerDepartamento.crearDepartamento(item.ID_EDIFICIO, numeroDep);
                                }
                                index++;
                            }

                            if (resultDep.Equals("Departamento Creado"))
                            {
                                string condominioPago = condominio.ID_CONDOMINIO.ToString();
                                Session["CondominioSinPago"] = condominioPago;
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Condominio Registrado');window.location.href='" + Request.RawUrl + "';", true);
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Error al Registrar Edificio');window.location.href='" + Request.RawUrl + "';", true);
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Error al Registrar Edificio');window.location.href='" + Request.RawUrl + "';", true);
                        }
                    }
                    else
                    {
                        for (int i = 1; i <= cantEdificio; i++)
                        {
                            nombreE = nomEdificio + " " + i;
                            resultEdificio = Controller.ControllerEdificio.crearEdificio(condominio.ID_CONDOMINIO, nombreE, piso, dep);
                        }

                        if (resultEdificio.Equals("Edificio Creado"))
                        {
                            List<EDIFICIO> listaEdificio = Controller.ControllerEdificio.buscarEdificioCondominio(condominio.ID_CONDOMINIO);
                            foreach (EDIFICIO item in listaEdificio)
                            {
                                for (int i = 1; i <= dep; i++)
                                {
                                    resultDep = Controller.ControllerDepartamento.crearDepartamento(item.ID_EDIFICIO, i.ToString());
                                }
                            }

                            if (resultDep.Equals("Departamento Creado"))
                            {
                                string condominioPago = condominio.ID_CONDOMINIO.ToString();
                                Session["CondominioSinPago"] = condominioPago;
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Condominio Registrado');window.location.href='" + Request.RawUrl + "';", true);
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Error al Registrar Edificio');window.location.href='" + Request.RawUrl + "';", true);
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Error al Registrar Edificio');window.location.href='" + Request.RawUrl + "';", true);
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Error al Registrar Condominio');window.location.href='" + Request.RawUrl + "';", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Error al Crear la Dirección');window.location.href='" + Request.RawUrl + "';", true);
            }
        }

        protected void btnModificarCondominio_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
        }
    }
}