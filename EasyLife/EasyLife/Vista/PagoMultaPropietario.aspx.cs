using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EasyLife.Vista
{
    public partial class PagoMultaPropietario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validación de Session Iniciada
            LOGIN adm = (LOGIN)Session["adm"];
            LOGIN conserje = (LOGIN)Session["conserje"];
            LOGIN vendedor = (LOGIN)Session["vendedor"];
            LOGIN propietario = (LOGIN)Session["login"];
            LOGIN admCondominio = (LOGIN)Session["admCondominio"];
            if (adm != null || conserje != null || vendedor != null || admCondominio != null)
            {
                Response.Redirect("~/Vista/Index.aspx");
            }
            else if (adm == null && conserje == null && vendedor == null && propietario == null && admCondominio == null)
            {
                Response.Redirect("~/Vista/Index.aspx");
            }

            if (!IsPostBack)
            {
                cargarDepartamentoPropietario(propietario.ID_PERSONA);
            }
        }

        private static long total;
        private static PERSONA persona = new PERSONA();
        private static List<Adapter.AdapterMulta> listaMulta = new List<Adapter.AdapterMulta>();

        public void cargarDepartamentoPropietario(long propietario)
        {
            persona = new PERSONA();
            List<DEPARTAMENTO> listaDep = Controller.ControllerDepartamento.listaDepartamentoPersona(propietario);
            dplDepartamento.DataSource = listaDep;
            dplDepartamento.DataValueField = "ID_DEPARTAMENTO";
            dplDepartamento.DataTextField = "NUMERO_DEP";
            dplDepartamento.DataBind();
            dplDepartamento.Items.Insert(0, "Seleccione un Departamento");
            dplDepartamento.SelectedIndex = 0;

            persona = Controller.ControllerPersona.buscarIdPersona(propietario);
        }

        protected void dplDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                long departamento = Convert.ToInt64(dplDepartamento.SelectedValue);
                total = 0;
                listaMulta = new List<Adapter.AdapterMulta>();
                listaMulta = Controller.ControllerMulta.listaAdapterMultaDepartamento(departamento);
                if (listaMulta.Count > 0)
                {
                    grMultas.DataSource = listaMulta;
                    grMultas.DataBind();
                    foreach (Adapter.AdapterMulta item in listaMulta)
                    {
                        total = total + item._COSTO_MULTA;
                    }
                    lbTotal.Text = total.ToString();
                }
                else
                {
                    listaMulta = new List<Adapter.AdapterMulta>();
                    grMultas.DataSource = listaMulta;
                    grMultas.DataBind();
                }
            }
            catch (Exception ex)
            {
                listaMulta = new List<Adapter.AdapterMulta>();
                grMultas.DataSource = listaMulta;
                grMultas.DataBind();
                System.Diagnostics.Debug.WriteLine("Error:  " + ex);
            }
        }

        protected void grMultas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grMultas.PageIndex = e.NewPageIndex;
            grMultas.DataSource = listaMulta;
            grMultas.DataBind();
        }

        protected void btnPagarMulta_Click(object sender, EventArgs e)
        {
        }
    }
}