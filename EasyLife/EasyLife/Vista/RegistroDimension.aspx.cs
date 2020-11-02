using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EasyLife.Vista
{
    public partial class RegistroDimension : System.Web.UI.Page
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
                string pagoCondominio = (string)Session["CondominioSinDimension"];
                //string gastoCondominio = (string)Session["CondominioSinPago"];
                if (pagoCondominio != null)
                {
                    cargarEdificio(pagoCondominio);
                }

                /*if (gastoCondominio != null)
                {
                    Response.Redirect("RegistroGasto.aspx");
                }*/
            }
        }

        private static List<Adapter.AdapterElemento> listaElemento = new List<Adapter.AdapterElemento>();
        private static List<Adapter.AdapterDepartamento> listaDepartamento = new List<Adapter.AdapterDepartamento>();
        private static string idCondominio = "";

        public void cargarEdificio(string condominio)
        {
            CONDOMINIO aux = Controller.ControllerCondominio.buscarIdCondominio(Convert.ToInt64(condominio));
            txtCondominio.Text = aux.NOMBRE_CONDOMINIO;
            List<EDIFICIO> listaEdificio = new List<EDIFICIO>();
            listaEdificio = Controller.ControllerEdificio.buscarEdificioCondominio(Convert.ToInt64(condominio));
            dplEdificio.DataSource = listaEdificio;
            dplEdificio.DataValueField = "ID_EDIFICIO";
            dplEdificio.DataTextField = "NOMBRE_EDIFICIO";
            dplEdificio.DataBind();
            dplEdificio.Items.Insert(0, "Seleccione un Edificio");
            dplEdificio.SelectedIndex = 0;
            idCondominio = condominio;
        }

        protected void dplEdificio_SelectedIndexChanged(object sender, EventArgs e)
        {
            dplTipo.Items.Insert(0, "Seleccione un Elemento");
            dplTipo.Items.Insert(1, "Bodega");
            dplTipo.Items.Insert(2, "Estacionamiento");
            dplTipo.SelectedIndex = 0;

            List<DEPARTAMENTO> listaDep = Controller.ControllerDepartamento.listaDepartamento(Convert.ToInt64(dplEdificio.SelectedValue));
            dplDepartamento.DataSource = listaDep;
            dplDepartamento.DataValueField = "ID_DEPARTAMENTO";
            dplDepartamento.DataTextField = "NUMERO_DEP";
            dplDepartamento.DataBind();
            dplDepartamento.Items.Insert(0, "Seleccione un Departamento");
            dplDepartamento.SelectedIndex = 0;
        }

        protected void dplTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (dplTipo.SelectedIndex == 1)
                {
                    panelBodega.Visible = true;
                    panelEstacionamiento.Visible = false;
                }
                else if (dplTipo.SelectedIndex == 2)
                {
                    panelBodega.Visible = false;
                    panelEstacionamiento.Visible = true;
                }
            }
            catch (Exception ex)
            {
                panelBodega.Visible = false;
                panelEstacionamiento.Visible = false;
                txtDimBodega.Text = "";
                txtCantidadBodega.Text = "";
                txtEstacionamiento.Text = "";
                System.Diagnostics.Debug.WriteLine("Error " + ex);
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            lbElementos.Visible = true;
            grElementos.Visible = true;
            Adapter.AdapterElemento adapter = new Adapter.AdapterElemento();
            EDIFICIO edificio = Controller.ControllerEdificio.buscarIdEdificio(Convert.ToInt64(dplEdificio.SelectedValue));
            adapter._ID_EDIFICIO = edificio.ID_EDIFICIO;
            adapter._NOMBRE_EDIFICIO = edificio.NOMBRE_EDIFICIO;
            adapter._TIPO = dplTipo.SelectedValue;
            if (dplTipo.SelectedIndex == 1)
            {
                adapter._CANTIDAD = Convert.ToInt32(txtCantidadBodega.Text);
                adapter._DIMENSION = Convert.ToDouble(txtDimBodega.Text);
                adapter._PRECIO = 0;
            }
            else if (dplTipo.SelectedIndex == 2)
            {
                adapter._CANTIDAD = Convert.ToInt32(txtEstacionamiento.Text);
                adapter._DIMENSION = 0;
                adapter._PRECIO = Convert.ToInt32(txtPrecio.Text);
            }
            listaElemento.Add(adapter);
            grElementos.DataSource = listaElemento;
            grElementos.DataBind();
            txtCantidadBodega.Text = "";
            txtDimBodega.Text = "";
            txtEstacionamiento.Text = "";
        }

        protected void grElementos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grElementos.PageIndex = e.NewPageIndex;
            grElementos.DataSource = listaElemento;
            grElementos.DataBind();
        }

        protected void btnAgregarDep_Click(object sender, EventArgs e)
        {
            Adapter.AdapterDepartamento adapter = new Adapter.AdapterDepartamento();
            lbError.Visible = false;
            Boolean option = true;
            if (listaDepartamento.Count <= 0)
            {
                EDIFICIO edificio = Controller.ControllerEdificio.buscarIdEdificio(Convert.ToInt64(dplEdificio.SelectedValue));
                DEPARTAMENTO departamento = Controller.ControllerDepartamento.buscarIdDepartamento(Convert.ToInt64(dplDepartamento.SelectedValue));
                adapter._ID_EDIFICIO = edificio.ID_EDIFICIO;
                adapter._NOMBRE_EDIFICIO = edificio.NOMBRE_EDIFICIO;
                adapter._ID_DEPARTAMENTO = departamento.ID_DEPARTAMENTO;
                adapter._NUMERO_DEP = departamento.NUMERO_DEP;
                adapter._DIMENSION_DEP = Convert.ToDouble(txtDimDepartamento.Text);
                listaDepartamento.Add(adapter);
            }
            else
            {
                foreach (Adapter.AdapterDepartamento item in listaDepartamento)
                {
                    if (Convert.ToInt64(dplDepartamento.SelectedValue) == item._ID_DEPARTAMENTO)
                    {
                        option = false;
                    }
                }

                if (option == true)
                {
                    lbError.Visible = false;
                    EDIFICIO edificio = Controller.ControllerEdificio.buscarIdEdificio(Convert.ToInt64(dplEdificio.SelectedValue));
                    DEPARTAMENTO departamento = Controller.ControllerDepartamento.buscarIdDepartamento(Convert.ToInt64(dplDepartamento.SelectedValue));
                    adapter._ID_EDIFICIO = edificio.ID_EDIFICIO;
                    adapter._NOMBRE_EDIFICIO = edificio.NOMBRE_EDIFICIO;
                    adapter._ID_DEPARTAMENTO = departamento.ID_DEPARTAMENTO;
                    adapter._NUMERO_DEP = departamento.NUMERO_DEP;
                    adapter._DIMENSION_DEP = Convert.ToDouble(txtDimDepartamento.Text);
                    listaDepartamento.Add(adapter);
                }
                else
                {
                    lbError.Visible = true;
                }
            }

            grDepartamento.DataSource = listaDepartamento;
            grDepartamento.DataBind();
            lbDep.Visible = true;
            grDepartamento.Visible = true;
            dplDepartamento.SelectedIndex = 0;
            txtDimDepartamento.Text = "";
        }

        protected void grDepartamento_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grDepartamento.PageIndex = e.NewPageIndex;
            grDepartamento.DataSource = listaDepartamento;
            grDepartamento.DataBind();
        }

        protected void btnRegistroDimension_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            string resultBodega = "";
            string resultEstacionamiento = "";
            string resultDepartamento = "";
            string numeroBodega = "";
            string numeroEstacionamiento = "";
            int positionBodega = 1;
            int positionEstacionamiento = 1;

            if (listaElemento.Count > 0)
            {
                foreach (Adapter.AdapterElemento item in listaElemento)
                {
                    if (item._TIPO.Equals("Bodega"))
                    {
                        for (int i = 1; i <= item._CANTIDAD; i++)
                        {
                            numeroBodega = "B" + positionBodega;
                            resultBodega = Controller.ControllerBodega.crearBodega(item._ID_EDIFICIO, item._DIMENSION, numeroBodega);
                            positionBodega++;
                        }
                    }
                    else
                    {
                        for (int i = 1; i < item._CANTIDAD; i++)
                        {
                            string letra = item._NOMBRE_EDIFICIO.Substring(item._NOMBRE_EDIFICIO.Length - 1, 1);
                            numeroEstacionamiento = letra + "E" + positionEstacionamiento;
                            resultEstacionamiento = Controller.ControllerEstacionamiento.crearEstacionamiento(item._ID_EDIFICIO, numeroEstacionamiento, item._PRECIO);
                            positionEstacionamiento++;
                        }
                    }
                }
            }

            if (listaDepartamento.Count > 0)
            {
                foreach (Adapter.AdapterDepartamento item in listaDepartamento)
                {
                    resultDepartamento = Controller.ControllerDepartamento.asignarDimDepartamento(item._ID_DEPARTAMENTO, item._DIMENSION_DEP);
                }
            }

            if (resultBodega.Equals("Bodega Creada") || resultEstacionamiento.Equals("Estacionamiento Creada") || resultDepartamento.Equals("Dimension Asignada"))
            {
                string condominioPago = idCondominio;
                Session["CondominioSinPago"] = condominioPago;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Dimensiones Registrado');window.location.href='" + Request.RawUrl + "';", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Error al Registrar Dimensiones');window.location.href='" + Request.RawUrl + "';", true);
            }
        }

        protected void btnModificarDimension_Click(object sender, EventArgs e)
        {
        }
    }
}