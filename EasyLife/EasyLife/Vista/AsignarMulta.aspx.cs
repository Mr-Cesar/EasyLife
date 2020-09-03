using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EasyLife.Vista
{
    public partial class AsignarMulta : System.Web.UI.Page
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
                Response.Redirect("Index.aspx");
            }
            else if (adm == null && conserje == null && vendedor == null && propietario == null && admCondominio == null)
            {
                Response.Redirect("Index.aspx");
            }

            if (!IsPostBack)
            {
                if (adm != null)
                {
                    cargarCondominio();
                }
                else
                {
                    cargarCondominioAdministrador(admCondominio.ID_PERSONA);
                }
            }
        }

        private static List<Adapter.AdapterDepartamento> listaDepartamento = new List<Adapter.AdapterDepartamento>();
        private static List<string> listaMulta = new List<string>();

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
                dplDepartamento.Items.Insert(0, "Seleccione un Departamento");
                dplDepartamento.SelectedIndex = 0;
                txtMotivo.Text = "";
                txtMulta.Text = "";
                listaDepartamento = new List<Adapter.AdapterDepartamento>();
                grMulta.DataSource = listaDepartamento;
                grMulta.DataBind();
                listaMulta = new List<string>();
                listadoMultas.DataSource = listaMulta;
                listadoMultas.DataBind();
                listadoMultas.Visible = false;
                lbMultasExistentes.Visible = false;
                lbMultasNuevas.Visible = false;
            }
            catch (Exception ex)
            {
                dplEdificio.Items.Insert(0, "Seleccione un Edificio");
                dplEdificio.SelectedIndex = 0;
                dplDepartamento.Items.Insert(0, "Seleccione un Departamento");
                dplDepartamento.SelectedIndex = 0;
                txtMotivo.Text = "";
                txtMulta.Text = "";
                listaDepartamento = new List<Adapter.AdapterDepartamento>();
                grMulta.DataSource = listaDepartamento;
                grMulta.DataBind();
                listaMulta = new List<string>();
                listadoMultas.DataSource = listaMulta;
                listadoMultas.DataBind();
                listadoMultas.Visible = false;
                lbMultasExistentes.Visible = false;
                lbMultasNuevas.Visible = false;
                System.Diagnostics.Debug.WriteLine("Error: " + ex);
            }
        }

        protected void dplEdificio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                long edificio = Convert.ToInt64(dplEdificio.SelectedValue);
                List<DEPARTAMENTO> listaDep = Controller.ControllerDepartamento.listaDepartamentoOcupado(edificio);
                dplDepartamento.DataSource = listaDep;
                dplDepartamento.DataValueField = "ID_DEPARTAMENTO";
                dplDepartamento.DataTextField = "NUMERO_DEP";
                dplDepartamento.DataBind();
                dplDepartamento.Items.Insert(0, "Seleccione un Departamento");
                dplDepartamento.SelectedIndex = 0;
                txtMotivo.Text = "";
                txtMulta.Text = "";
                listaDepartamento = new List<Adapter.AdapterDepartamento>();
                grMulta.DataSource = listaDepartamento;
                grMulta.DataBind();
                listaMulta = new List<string>();
                listadoMultas.DataSource = listaMulta;
                listadoMultas.DataBind();
                listadoMultas.Visible = false;
                lbMultasExistentes.Visible = false;
                lbMultasNuevas.Visible = false;
            }
            catch (Exception ex)
            {
                dplDepartamento.Items.Insert(0, "Seleccione un Departamento");
                dplDepartamento.SelectedIndex = 0;
                txtMotivo.Text = "";
                txtMulta.Text = "";
                listaDepartamento = new List<Adapter.AdapterDepartamento>();
                grMulta.DataSource = listaDepartamento;
                grMulta.DataBind();
                listaMulta = new List<string>();
                listadoMultas.DataSource = listaMulta;
                listadoMultas.DataBind();
                listadoMultas.Visible = false;
                lbMultasExistentes.Visible = false;
                lbMultasNuevas.Visible = false;
                System.Diagnostics.Debug.WriteLine("Error: " + ex);
            }
        }

        protected void dplDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lbMultasExistentes.Visible = true;
                lbError.Visible = false;
                txtMotivo.Text = "";
                txtMulta.Text = "";
                DEPARTAMENTO dep = Controller.ControllerDepartamento.buscarIdDepartamento(Convert.ToInt64(dplDepartamento.SelectedValue));
                List<MULTA> listaMultas = new List<MULTA>();
                listaMultas = Controller.ControllerMulta.listaMultaNoPagadaDepartamento(dep.ID_DEPARTAMENTO);
                string multa = "";
                listaMulta = new List<string>();
                foreach (MULTA item in listaMultas)
                {
                    multa = item.MOTIVO + " " + item.COSTO_MULTA;
                    listaMulta.Add(multa);
                }
                listadoMultas.DataSource = listaMulta;
                listadoMultas.DataBind();
                listadoMultas.Visible = true;
            }
            catch (Exception ex)
            {
                long departamento = dplDepartamento.SelectedIndex;
                txtMotivo.Text = "";
                txtMulta.Text = "";
                if (departamento == 0)
                {
                    lbError.Visible = false;
                    lbMultasExistentes.Visible = false;
                    listaDepartamento = new List<Adapter.AdapterDepartamento>();
                    grMulta.DataSource = listaDepartamento;
                    grMulta.DataBind();
                    listaMulta = new List<string>();
                    listadoMultas.DataSource = listaMulta;
                    listadoMultas.DataBind();
                    listadoMultas.Visible = false;
                }
                else
                {
                    lbError.Visible = true;
                    lbMultasExistentes.Visible = false;
                    lbError.Text = "El departamento no presenta Multas a la Fecha";
                    listadoMultas.Visible = false;
                }
                System.Diagnostics.Debug.WriteLine("Error: " + ex);
            }
        }

        protected void btnAgregarMulta_Click(object sender, EventArgs e)
        {
            lbMultasNuevas.Visible = true;
            long condominio = Convert.ToInt64(dplCondominio.SelectedValue);
            CONDOMINIO con = Controller.ControllerCondominio.buscarIdCondominio(condominio);
            long edificio = Convert.ToInt64(dplEdificio.SelectedValue);
            EDIFICIO edi = Controller.ControllerEdificio.buscarIdEdificio(edificio);
            long departamento = Convert.ToInt64(dplDepartamento.SelectedValue);
            DEPARTAMENTO dep = Controller.ControllerDepartamento.buscarIdDepartamento(departamento);

            Adapter.AdapterDepartamento adapter = new Adapter.AdapterDepartamento();
            adapter._NOMBRE_CONDOMINIO = con.NOMBRE_CONDOMINIO;
            adapter._ID_DEPARTAMENTO = dep.ID_DEPARTAMENTO;
            adapter._NOMBRE_EDIFICIO = edi.NOMBRE_EDIFICIO;
            adapter._NUMERO_DEP = dep.NUMERO_DEP;
            adapter._MULTA = Convert.ToInt32(txtMulta.Text);
            adapter._MOTIVO = txtMotivo.Text;

            listaDepartamento.Add(adapter);
            grMulta.DataSource = listaDepartamento;
            grMulta.DataBind();

            txtMotivo.Text = "";
            txtMulta.Text = "";
        }

        protected void grMulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = grMulta.SelectedIndex;
            listaDepartamento.RemoveAt(index);
            grMulta.DataSource = listaDepartamento;
            grMulta.DataBind();
        }

        protected void grMulta_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grMulta.PageIndex = e.NewPageIndex;
            grMulta.DataSource = listaDepartamento;
            grMulta.DataBind();
        }

        protected void btnRegistroMulta_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            string result = "";
            foreach (Adapter.AdapterDepartamento item in listaDepartamento)
            {
                result = Controller.ControllerMulta.crearMulta(item._ID_DEPARTAMENTO, item._MULTA, item._MOTIVO);
            }

            if (result.Equals("Multa Creada"))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Multas Asignadas');window.location.href='" + Request.RawUrl + "';", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Error al Asignar Multa');window.location.href='" + Request.RawUrl + "';", true);
            }
        }

        protected void btnModificarMulta_Click(object sender, EventArgs e)
        {
        }
    }
}