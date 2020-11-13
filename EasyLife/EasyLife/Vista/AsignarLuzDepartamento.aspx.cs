using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EasyLife.Vista
{
    public partial class AsignarLuzDepartamento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validación de Session Iniciada
            LOGIN adm = (LOGIN)Session["adm"];
            LOGIN conserje = (LOGIN)Session["conserje"];
            LOGIN vendedor = (LOGIN)Session["vendedor"];
            LOGIN propietario = (LOGIN)Session["login"];
            LOGIN admCondominio = (LOGIN)Session["admCondominio"];
            if (conserje != null || vendedor != null || propietario != null)
            {
                Response.Redirect("~/Vista/Index.aspx");
            }
            else if (adm == null && conserje == null && vendedor == null && propietario == null && admCondominio == null)
            {
                Response.Redirect("~/Vista/Index.aspx");
            }

            if (!IsPostBack)
            {
                if (adm != null)
                {
                    cargarCondominio();
                }
                else
                {
                    cargarCondominioAdm(admCondominio.ID_PERSONA);
                }
                cargarLuzDepartamento();
            }
        }

        private static List<Adapter.AdapterLuzDepartamento> listaLuzDepartamento = new List<Adapter.AdapterLuzDepartamento>();
        private static List<Adapter.AdapterLuzDepartamento> listaLuzDepartamentoUpdate = new List<Adapter.AdapterLuzDepartamento>();

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

        public void cargarCondominioAdm(long administrador)
        {
            List<CONDOMINIO> lista = Controller.ControllerCondominio.listaCondominioAdministrador(administrador);
            dplCondominio.DataSource = lista;
            dplCondominio.DataValueField = "ID_CONDOMINIO";
            dplCondominio.DataTextField = "NOMBRE_CONDOMINIO";
            dplCondominio.DataBind();
            dplCondominio.Items.Insert(0, "Seleccione un Condominio");
            dplCondominio.SelectedIndex = 0;
        }

        public void cargarLuzDepartamento()
        {
            List<LUZ_DEPARTAMENTO> lista = Controller.ControllerLuzDepartamento.listaLuzDepartamentoLibre();
            dplLuz.DataSource = lista;
            dplLuz.DataValueField = "ID_LUZ_D";
            dplLuz.DataTextField = "CODIGO_LUZ_D";
            dplLuz.DataBind();
            dplLuz.Items.Insert(0, "Seleccione una Luz");
            dplLuz.SelectedIndex = 0;
        }

        protected void dplOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dplCondominio.Enabled = true;
                dplEdificio.Enabled = true;
                dplDepartamento.Enabled = true;
                dplLuz.Enabled = true;
                lbError.Visible = false;
                listaLuzDepartamento = new List<Adapter.AdapterLuzDepartamento>();
                listaLuzDepartamentoUpdate = new List<Adapter.AdapterLuzDepartamento>();
                grLuces.DataSource = listaLuzDepartamento;
                grLuces.DataBind();
                int option = dplOption.SelectedIndex;
                if (option == 0)
                {
                    dplCondominio.Enabled = false;
                    dplEdificio.Enabled = false;
                    dplLuz.Enabled = false;
                    btnAgregarLuz.Visible = false;
                    btnRegistroLuz.Visible = false;
                    btnModificarLuz.Visible = false;
                    btnUpdateLuz.Visible = false;
                }
                else if (option == 1)
                {
                    btnAgregarLuz.Visible = true;
                    btnRegistroLuz.Visible = true;
                    btnAgregarLuz.Enabled = true;
                    btnModificarLuz.Visible = false;
                    btnUpdateLuz.Visible = false;
                }
                else if (option == 2)
                {
                    btnModificarLuz.Visible = true;
                    btnUpdateLuz.Visible = true;
                    btnModificarLuz.Enabled = true;
                    btnAgregarLuz.Visible = false;
                    btnRegistroLuz.Visible = false;
                }
            }
            catch (Exception ex)
            {
                listaLuzDepartamento = new List<Adapter.AdapterLuzDepartamento>();
                listaLuzDepartamentoUpdate = new List<Adapter.AdapterLuzDepartamento>();
                grLuces.DataSource = listaLuzDepartamento;
                grLuces.DataBind();
                dplCondominio.Enabled = false;
                dplEdificio.Enabled = false;
                dplLuz.Enabled = false;
                btnAgregarLuz.Visible = false;
                btnModificarLuz.Visible = false;
                btnRegistroLuz.Visible = false;
                btnUpdateLuz.Visible = false;
                lbError.Visible = false;
                System.Diagnostics.Debug.WriteLine("Error: " + ex);
            }
        }

        protected void dplCondominio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                btnAgregarLuz.Enabled = true;
                btnModificarLuz.Enabled = true;
                lbError.Visible = false;
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
                dplLuz.SelectedIndex = 0;
                System.Diagnostics.Debug.WriteLine("Error: " + ex);
            }
        }

        protected void dplEdificio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                btnAgregarLuz.Enabled = true;
                btnModificarLuz.Enabled = true;
                lbError.Visible = false;
                long edificio = Convert.ToInt64(dplEdificio.SelectedValue);
                List<DEPARTAMENTO> listaDepartamento = Controller.ControllerDepartamento.listaDepartamentoLuz(edificio);
                dplDepartamento.DataSource = listaDepartamento;
                dplDepartamento.DataValueField = "ID_DEPARTAMENTO";
                dplDepartamento.DataTextField = "NUMERO_DEP";
                dplDepartamento.DataBind();
                dplDepartamento.Items.Insert(0, "Seleccione un Departamento");
                dplDepartamento.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                dplDepartamento.Items.Insert(0, "Seleccione un Departamento");
                dplDepartamento.SelectedIndex = 0;
                System.Diagnostics.Debug.WriteLine("Error: " + ex);
            }
        }

        protected void dplDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                btnAgregarLuz.Enabled = true;
                lbError.Visible = false;
                long option = dplOption.SelectedIndex;
                if (option == 1)
                {
                    long departamento = Convert.ToInt64(dplDepartamento.SelectedValue);
                    DEPARTAMENTO aux = Controller.ControllerDepartamento.buscarIdDepartamento(departamento);
                    if (aux.ID_LUZ_D != null)
                    {
                        lbError.Visible = true;
                        lbError.Text = "Departamento ya Posee Luz";
                        btnAgregarLuz.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                dplLuz.SelectedIndex = 0;
                System.Diagnostics.Debug.WriteLine("Error: " + ex);
            }
        }

        protected void btnAgregarLuz_Click(object sender, EventArgs e)
        {
            Adapter.AdapterLuzDepartamento adapter = new Adapter.AdapterLuzDepartamento();
            CONDOMINIO condominio = Controller.ControllerCondominio.buscarIdCondominio(Convert.ToInt64(dplCondominio.SelectedValue));
            EDIFICIO edificio = Controller.ControllerEdificio.buscarIdEdificio(Convert.ToInt64(dplEdificio.SelectedValue));
            DEPARTAMENTO departamento = Controller.ControllerDepartamento.buscarIdDepartamento(Convert.ToInt64(dplDepartamento.SelectedValue));
            LUZ_DEPARTAMENTO luz = Controller.ControllerLuzDepartamento.buscarIdLuzDepartamento(Convert.ToInt64(dplLuz.SelectedValue));
            lbError.Visible = false;
            List<Adapter.AdapterLuzDepartamento> listaAux = listaLuzDepartamento;
            if (listaLuzDepartamento.Count > 0)
            {
                foreach (Adapter.AdapterLuzDepartamento item in listaAux.ToList())
                {
                    if (item._ID_LUZ_D == Convert.ToInt64(dplLuz.SelectedValue))
                    {
                        lbError.Visible = true;
                        lbError.Text = "Luz ya Asignada";
                    }
                    else if (item._ID_DEPARTAMENTO == Convert.ToInt64(dplDepartamento.SelectedValue))
                    {
                        lbError.Visible = true;
                        lbError.Text = "Departamento ya Posee Luz";
                    }
                    else
                    {
                        lbError.Visible = false;
                        adapter._ID_LUZ_D = luz.ID_LUZ_D;
                        adapter._CODIGO_LUZ_D = luz.CODIGO_LUZ_D;
                        adapter._ID_DEPARTAMENTO = departamento.ID_DEPARTAMENTO;
                        adapter._NUMERO_DEP = departamento.NUMERO_DEP;
                        adapter._ID_EDIFICIO = edificio.ID_EDIFICIO;
                        adapter._NOMBRE_EDIFICIO = edificio.NOMBRE_EDIFICIO;
                        adapter._ID_CONDOMINIO = condominio.ID_CONDOMINIO;
                        adapter._NOMBRE_CONDOMINIO = condominio.NOMBRE_CONDOMINIO;
                        adapter._ESTADO_LUZ_D = luz.ESTADO_LUZ_D;
                        listaLuzDepartamento.Add(adapter);
                        grLuces.DataSource = listaLuzDepartamento;
                        grLuces.DataBind();
                    }
                }
            }
            else
            {
                adapter._ID_LUZ_D = luz.ID_LUZ_D;
                adapter._CODIGO_LUZ_D = luz.CODIGO_LUZ_D;
                adapter._ID_DEPARTAMENTO = departamento.ID_DEPARTAMENTO;
                adapter._NUMERO_DEP = departamento.NUMERO_DEP;
                adapter._ID_EDIFICIO = edificio.ID_EDIFICIO;
                adapter._NOMBRE_EDIFICIO = edificio.NOMBRE_EDIFICIO;
                adapter._ID_CONDOMINIO = condominio.ID_CONDOMINIO;
                adapter._NOMBRE_CONDOMINIO = condominio.NOMBRE_CONDOMINIO;
                adapter._ESTADO_LUZ_D = luz.ESTADO_LUZ_D;
                listaLuzDepartamento.Add(adapter);
                grLuces.DataSource = listaLuzDepartamento;
                grLuces.DataBind();
            }
        }

        protected void btnModificarLuz_Click(object sender, EventArgs e)
        {
            Adapter.AdapterLuzDepartamento adapter = new Adapter.AdapterLuzDepartamento();
            CONDOMINIO condominio = Controller.ControllerCondominio.buscarIdCondominio(Convert.ToInt64(dplCondominio.SelectedValue));
            EDIFICIO edificio = Controller.ControllerEdificio.buscarIdEdificio(Convert.ToInt64(dplEdificio.SelectedValue));
            DEPARTAMENTO departamento = Controller.ControllerDepartamento.buscarIdDepartamento(Convert.ToInt64(dplDepartamento.SelectedValue));
            LUZ_DEPARTAMENTO luz = Controller.ControllerLuzDepartamento.buscarIdLuzDepartamento(Convert.ToInt64(dplLuz.SelectedValue));
            lbError.Visible = false;
            List<Adapter.AdapterLuzDepartamento> listaAux = listaLuzDepartamentoUpdate;
            if (listaLuzDepartamentoUpdate.Count > 0)
            {
                foreach (Adapter.AdapterLuzDepartamento item in listaAux.ToList())
                {
                    if (item._ID_LUZ_D == Convert.ToInt64(dplLuz.SelectedValue))
                    {
                        lbError.Visible = true;
                        lbError.Text = "Luz ya Asignada";
                    }
                    else if (item._ID_DEPARTAMENTO == Convert.ToInt64(dplDepartamento.SelectedValue))
                    {
                        lbError.Visible = true;
                        lbError.Text = "Departamento ya Posee Luz";
                    }
                    else
                    {
                        lbError.Visible = false;
                        adapter._ID_LUZ_D = luz.ID_LUZ_D;
                        adapter._CODIGO_LUZ_D = luz.CODIGO_LUZ_D;
                        adapter._ID_DEPARTAMENTO = departamento.ID_DEPARTAMENTO;
                        adapter._NUMERO_DEP = departamento.NUMERO_DEP;
                        adapter._ID_EDIFICIO = edificio.ID_EDIFICIO;
                        adapter._NOMBRE_EDIFICIO = edificio.NOMBRE_EDIFICIO;
                        adapter._ID_CONDOMINIO = condominio.ID_CONDOMINIO;
                        adapter._NOMBRE_CONDOMINIO = condominio.NOMBRE_CONDOMINIO;
                        adapter._ESTADO_LUZ_D = luz.ESTADO_LUZ_D;
                        listaLuzDepartamentoUpdate.Add(adapter);
                        grLuces.DataSource = listaLuzDepartamentoUpdate;
                        grLuces.DataBind();
                    }
                }
            }
            else
            {
                adapter._ID_LUZ_D = luz.ID_LUZ_D;
                adapter._CODIGO_LUZ_D = luz.CODIGO_LUZ_D;
                adapter._ID_DEPARTAMENTO = departamento.ID_DEPARTAMENTO;
                adapter._NUMERO_DEP = departamento.NUMERO_DEP;
                adapter._ID_EDIFICIO = edificio.ID_EDIFICIO;
                adapter._NOMBRE_EDIFICIO = edificio.NOMBRE_EDIFICIO;
                adapter._ID_CONDOMINIO = condominio.ID_CONDOMINIO;
                adapter._NOMBRE_CONDOMINIO = condominio.NOMBRE_CONDOMINIO;
                adapter._ESTADO_LUZ_D = luz.ESTADO_LUZ_D;
                listaLuzDepartamentoUpdate.Add(adapter);
                grLuces.DataSource = listaLuzDepartamentoUpdate;
                grLuces.DataBind();
            }
        }

        protected void grLuces_SelectedIndexChanged(object sender, EventArgs e)
        {
            long option = Convert.ToInt64(dplOption.SelectedIndex);
            if (option == 1)
            {
                int index = grLuces.SelectedIndex;
                listaLuzDepartamento.RemoveAt(index);
                grLuces.DataSource = listaLuzDepartamento;
                grLuces.DataBind();
            }
            else if (option == 2)
            {
                int index = grLuces.SelectedIndex;
                listaLuzDepartamentoUpdate.RemoveAt(index);
                grLuces.DataSource = listaLuzDepartamentoUpdate;
                grLuces.DataBind();
            }
        }

        protected void grLuces_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            long option = dplOption.SelectedIndex;
            if (option == 1)
            {
                grLuces.PageIndex = e.NewPageIndex;
                grLuces.DataSource = listaLuzDepartamento;
                grLuces.DataBind();
            }
            else if (option == 2)
            {
                grLuces.PageIndex = e.NewPageIndex;
                grLuces.DataSource = listaLuzDepartamentoUpdate;
                grLuces.DataBind();
            }
        }

        protected void btnRegistroLuz_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            string result = "";
            foreach (Adapter.AdapterLuzDepartamento item in listaLuzDepartamento)
            {
                result = Controller.ControllerLuzDepartamento.asignarLuzDepartamento(item._ID_DEPARTAMENTO, item._ID_LUZ_D);
            }

            if (result.Equals("Luz Departamento Asignada"))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Luz Asignada');window.location.href='" + Request.RawUrl + "';", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Error al Asignar Luz');window.location.href='" + Request.RawUrl + "';", true);
            }
        }

        protected void btnUpdateLuz_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            string result = "";
            foreach (Adapter.AdapterLuzDepartamento item in listaLuzDepartamentoUpdate)
            {
                result = Controller.ControllerLuzDepartamento.asignarLuzDepartamento(item._ID_DEPARTAMENTO, item._ID_LUZ_D);
            }

            if (result.Equals("Luz Departamento Asignada"))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Luz Asignada');window.location.href='" + Request.RawUrl + "';", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Error al Asignar Luz');window.location.href='" + Request.RawUrl + "';", true);
            }
        }
    }
}