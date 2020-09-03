using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EasyLife.Vista
{
    public partial class RegistroGasto : System.Web.UI.Page
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
                cargarCondominio();
                txtGOtro_TextChanged(sender, e);
                string pagoCondominio = (string)Session["CondominioSinPago"];
                if (pagoCondominio != null)
                {
                    dplCondominio.SelectedValue = pagoCondominio;
                    dplCondominio_SelectedIndexChanged(sender, e);
                }

                string update = (string)Session["ModificarGasto"];
                if (update != null)
                {
                    panelGasto.Visible = false;
                    cargarParametros(update);
                    modificarGasto = Convert.ToInt64(update);
                }
            }
        }

        private static long total;
        private static long modificarGasto;
        private static GASTOS_COMUNES gastoUpdate = new GASTOS_COMUNES();

        public void cargarCondominio()
        {
            List<CONDOMINIO> lista = Controller.ControllerCondominio.listaCondominio();
            dplCondominio.DataSource = lista;
            dplCondominio.DataValueField = "ID_CONDOMINIO";
            dplCondominio.DataTextField = "NOMBRE_CONDOMINIO";
            dplCondominio.DataBind();
            dplCondominio.Items.Insert(0, "Seleccione un Condominio");
            dplCondominio.SelectedIndex = 0;
        }

        public void cargarCondominioAdministrador(long administrador)
        {
            List<CONDOMINIO> lista = Controller.ControllerCondominio.listaCondominioAdministrador(administrador);
            dplCondominio.DataSource = lista;
            dplCondominio.DataValueField = "ID_CONDOMINIO";
            dplCondominio.DataTextField = "NOMBRE_CONDOMINIO";
            dplCondominio.DataBind();
            dplCondominio.Items.Insert(0, "Seleccione un Condominio");
            dplCondominio.SelectedIndex = 0;
        }

        public void cargarParametros(string gasto)
        {
            lbTitulo.Text = "Modificar Gasto";
            btnRegistroGasto.Visible = false;
            btnModificarGasto.Visible = true;
            gastoUpdate = new GASTOS_COMUNES();
            GASTOS_COMUNES aux = Controller.ControllerGastoComun.buscarIdGastoComun(Convert.ToInt64(gasto));
            txtGConserje.Text = aux.GASTO_CONSERJE.ToString();
            txtGGuardia.Text = aux.GASTO_GUARDIA.ToString();
            txtGMantAreas.Text = aux.GASTO_MANTENCION_AREAS.ToString();
            txtGCamaras.Text = aux.GASTO_CAMARAS.ToString();
            txtGArtAseo.Text = aux.GASTO_ARTICULOS_ASEO.ToString();
            txtGAseo.Text = aux.GASTOS_ASEO.ToString();
            txtGAscensor.Text = aux.GASTO_ASCENSOR.ToString();
            txtGAgua.Text = aux.GASTO_AGUA_CALIENTE.ToString();
            txtGOtro.Text = aux.GASTO_OTRO.ToString();
            lbTotal.Text = aux.TOTAL_GASTO.ToString();
            gastoUpdate = aux;
        }

        protected void dplCondominio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                long condominio = Convert.ToInt64(dplCondominio.SelectedValue);
                List<EDIFICIO> listaEdificio = Controller.ControllerEdificio.buscarEdificioCondominio(condominio);
                dplEdificio.DataSource = listaEdificio;
                dplEdificio.DataValueField = "ID_EDIFICIO";
                dplEdificio.DataTextField = "NOMBRE_EDIFICIO";
                dplEdificio.DataBind();
                dplEdificio.Items.Insert(0, "Seleccione un Edificio");
                dplEdificio.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                dplEdificio.Items.Insert(0, "Seleccione un Edificio");
                dplEdificio.SelectedIndex = 0;
                System.Diagnostics.Debug.WriteLine("Error: " + ex);
            }
        }

        public void cargarEdificio(long condominio)
        {
            List<EDIFICIO> listaEdificio = Controller.ControllerEdificio.buscarEdificioCondominio(condominio);
            dplEdificio.DataSource = listaEdificio;
            dplEdificio.DataValueField = "ID_EDIFICIO";
            dplEdificio.DataTextField = "NOMBRE_EDIFICIO";
            dplEdificio.DataBind();
            dplEdificio.Items.Insert(0, "Seleccione un Edificio");
            dplEdificio.SelectedIndex = 0;
        }

        protected void dplEdificio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                long edificio = Convert.ToInt64(dplEdificio.SelectedValue);
                GASTOS_COMUNES gasto = Controller.ControllerGastoComun.buscarGastoComunEdificio(edificio);
                txtGConserje.Text = gasto.GASTO_CONSERJE.ToString();
                txtGGuardia.Text = gasto.GASTO_GUARDIA.ToString();
                txtGMantAreas.Text = gasto.GASTO_MANTENCION_AREAS.ToString();
                txtGCamaras.Text = gasto.GASTO_CAMARAS.ToString();
                txtGArtAseo.Text = gasto.GASTO_ARTICULOS_ASEO.ToString();
                txtGAseo.Text = gasto.GASTOS_ASEO.ToString();
                txtGAscensor.Text = gasto.GASTO_ASCENSOR.ToString();
                txtGAgua.Text = gasto.GASTO_AGUA_CALIENTE.ToString();
                txtGOtro.Text = gasto.GASTO_OTRO.ToString();
                lbTotal.Text = gasto.TOTAL_GASTO.ToString();
            }
            catch (Exception ex)
            {
                txtGConserje.Text = "";
                txtGGuardia.Text = "";
                txtGMantAreas.Text = "";
                txtGCamaras.Text = "";
                txtGArtAseo.Text = "";
                txtGAseo.Text = "";
                txtGAscensor.Text = "";
                txtGAgua.Text = "";
                txtGOtro.Text = "";
                lbTotal.Text = "";
                System.Diagnostics.Debug.WriteLine("Error: " + ex);
            }
        }

        protected void radioOpcionGasto_CheckedChanged(object sender, EventArgs e)
        {
            RequiredFieldValidator12.IsValid = false;
            RequiredFieldValidator13.IsValid = false;
            RequiredFieldValidator12.Enabled = false;
            RequiredFieldValidator13.Enabled = false;
            dplEdificio.SelectedIndex = 0;
        }

        protected void txtGOtro_TextChanged(object sender, EventArgs e)
        {
            int conserje = 0;
            int guardia = 0;
            int mantencion = 0;
            int camaras = 0;
            int articulos = 0;
            int aseo = 0;
            int ascensor = 0;
            int agua = 0;
            int otro = 0;
            total = 0;

            if (!string.IsNullOrEmpty(txtGConserje.Text))
            {
                conserje = Convert.ToInt32(txtGConserje.Text);
                total = conserje + guardia + mantencion + camaras + articulos + aseo + ascensor + agua + otro;
                lbTotal.Text = total.ToString();
            }

            if (!string.IsNullOrEmpty(txtGGuardia.Text))
            {
                guardia = Convert.ToInt32(txtGGuardia.Text);
                total = conserje + guardia + mantencion + camaras + articulos + aseo + ascensor + agua + otro;
                lbTotal.Text = total.ToString();
            }

            if (!string.IsNullOrEmpty(txtGMantAreas.Text))
            {
                mantencion = Convert.ToInt32(txtGMantAreas.Text);
                total = conserje + guardia + mantencion + camaras + articulos + aseo + ascensor + agua + otro;
                lbTotal.Text = total.ToString();
            }

            if (!string.IsNullOrEmpty(txtGCamaras.Text))
            {
                camaras = Convert.ToInt32(txtGCamaras.Text);
                total = conserje + guardia + mantencion + camaras + articulos + aseo + ascensor + agua + otro;
                lbTotal.Text = total.ToString();
            }

            if (!string.IsNullOrEmpty(txtGArtAseo.Text))
            {
                articulos = Convert.ToInt32(txtGArtAseo.Text);
                total = conserje + guardia + mantencion + camaras + articulos + aseo + ascensor + agua + otro;
                lbTotal.Text = total.ToString();
            }

            if (!string.IsNullOrEmpty(txtGAseo.Text))
            {
                aseo = Convert.ToInt32(txtGAseo.Text);
                total = conserje + guardia + mantencion + camaras + articulos + aseo + ascensor + agua + otro;
                lbTotal.Text = total.ToString();
            }

            if (!string.IsNullOrEmpty(txtGAscensor.Text))
            {
                ascensor = Convert.ToInt32(txtGAscensor.Text);
                total = conserje + guardia + mantencion + camaras + articulos + aseo + ascensor + agua + otro;
                lbTotal.Text = total.ToString();
            }

            if (!string.IsNullOrEmpty(txtGAgua.Text))
            {
                agua = Convert.ToInt32(txtGAgua.Text);
                total = conserje + guardia + mantencion + camaras + articulos + aseo + ascensor + agua + otro;
                lbTotal.Text = total.ToString();
            }

            if (!string.IsNullOrEmpty(txtGOtro.Text))
            {
                otro = Convert.ToInt32(txtGOtro.Text);
                total = conserje + guardia + mantencion + camaras + articulos + aseo + ascensor + agua + otro;
                lbTotal.Text = total.ToString();
            }
        }

        protected void btnRegistroGasto_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            int conserje = Convert.ToInt32(txtGConserje.Text);
            int guardia = Convert.ToInt32(txtGGuardia.Text);
            int mantencion = Convert.ToInt32(txtGMantAreas.Text);
            int camaras = Convert.ToInt32(txtGCamaras.Text);
            int articulos = Convert.ToInt32(txtGArtAseo.Text);
            int aseo = Convert.ToInt32(txtGAseo.Text);
            int ascensor = Convert.ToInt32(txtGAscensor.Text);
            int agua = Convert.ToInt32(txtGAgua.Text);
            int otro = Convert.ToInt32(txtGOtro.Text);
            int totaL = Convert.ToInt32(lbTotal.Text);
            string resultGasto = "";
            string resultAsignar = "";
            if (radioOpcionGasto.Checked == true)
            {
                List<EDIFICIO> listaEdificio = Controller.ControllerEdificio.buscarEdificioCondominio(Convert.ToInt64(dplCondominio.SelectedValue));
                foreach (EDIFICIO item in listaEdificio)
                {
                    resultGasto = Controller.ControllerGastoComun.crearGastoComun(item.ID_EDIFICIO, conserje, guardia, mantencion, camaras, articulos, aseo,
                        ascensor, agua, otro, totaL);
                    if (resultGasto.Equals("Gasto Comun Creado"))
                    {
                        GASTOS_COMUNES gasto = Controller.ControllerGastoComun.buscarGastoComunEdificio(item.ID_EDIFICIO);
                        resultAsignar = Controller.ControllerEdificio.asignarGastoEdificio(item.ID_EDIFICIO, gasto.ID_GASTOS);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Error al Ingresar Gasto');window.location.href='" + Request.RawUrl + "';", true);
                    }
                }

                if (resultAsignar.Equals("Gasto Asignado"))
                {
                    Session["CondominioSinPago"] = null;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Gasto Ingresado');window.location.href='" + Request.RawUrl + "';", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Error al Ingresar Gasto');window.location.href='" + Request.RawUrl + "';", true);
                }
            }
            else
            {
                long edificio = Convert.ToInt64(dplEdificio.SelectedValue);
                resultGasto = Controller.ControllerGastoComun.crearGastoComun(edificio, conserje, guardia, mantencion, camaras, articulos, aseo, ascensor, agua,
                    otro, totaL);
                if (resultGasto.Equals("Gasto Comun Creado"))
                {
                    GASTOS_COMUNES gasto = Controller.ControllerGastoComun.buscarGastoComunEdificio(edificio);
                    resultGasto = Controller.ControllerEdificio.asignarGastoEdificio(edificio, gasto.ID_GASTOS);
                    if (resultGasto.Equals("Gasto Asignado"))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Gasto Ingresado');window.location.href='" + Request.RawUrl + "';", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Error al Ingresar Gasto');window.location.href='" + Request.RawUrl + "';", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Error al Ingresar Gasto');window.location.href='" + Request.RawUrl + "';", true);
                }
            }
        }

        protected void btnModificarGasto_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            long gasto = gastoUpdate.ID_GASTOS;
            long edificio = gastoUpdate.ID_EDIFICIO;
            int conserje = Convert.ToInt32(txtGConserje.Text);
            int guardia = Convert.ToInt32(txtGGuardia.Text);
            int mantencion = Convert.ToInt32(txtGMantAreas.Text);
            int camaras = Convert.ToInt32(txtGCamaras.Text);
            int articulos = Convert.ToInt32(txtGArtAseo.Text);
            int aseo = Convert.ToInt32(txtGAseo.Text);
            int ascensor = Convert.ToInt32(txtGAscensor.Text);
            int agua = Convert.ToInt32(txtGAgua.Text);
            int otro = Convert.ToInt32(txtGOtro.Text);
            int totaL = Convert.ToInt32(lbTotal.Text);

            string result = Controller.ControllerGastoComun.modficarGastoComun(gasto, edificio, conserje, guardia, mantencion, camaras, articulos, aseo, ascensor,
                agua, otro, totaL);
            if (result.Equals("Gasto Comun Modificado"))
            {
                Session["ModificarGasto"] = null;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Gasto Modificado');window.location.href='" + Request.RawUrl + "';", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Error al Modificar Gasto');window.location.href='" + Request.RawUrl + "';", true);
            }
        }
    }
}