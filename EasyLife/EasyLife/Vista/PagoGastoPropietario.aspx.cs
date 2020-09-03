using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EasyLife.Vista
{
    public partial class PagoGastoPropietario : System.Web.UI.Page
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
                Response.Redirect("Index.aspx");
            }
            else if (adm == null && conserje == null && vendedor == null && propietario == null && admCondominio == null)
            {
                Response.Redirect("Index.aspx");
            }

            if (!IsPostBack)
            {
                cargarDepartamentoPropietario(propietario.ID_PERSONA);
            }
        }

        private static List<Adapter.AdapterBoletaGasto> listaGastos = new List<Adapter.AdapterBoletaGasto>();
        private static long total;
        private static PERSONA persona = new PERSONA();

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
                listGastos.DataSource = null;
                listGastos.DataBind();
                DEPARTAMENTO departamento = Controller.ControllerDepartamento.buscarIdDepartamento(Convert.ToInt64(dplDepartamento.SelectedValue));
                GASTOS_COMUNES gasto = Controller.ControllerGastoComun.buscarGastoComunEdificio(departamento.ID_EDIFICIO);
                List<MULTA> listaMultas = Controller.ControllerMulta.listaMultaNoPagadaDepartamento(Convert.ToInt64(dplDepartamento.SelectedValue));
                long multa = 0;
                foreach (MULTA item in listaMultas)
                {
                    multa = multa + item.COSTO_MULTA;
                }
                List<string> listaG = new List<string>()
                {
                    "Gasto Conserje " + gasto.GASTO_CONSERJE,
                    "Gasto Guardia " + gasto.GASTO_GUARDIA,
                    "Gasto Mantencion Areas " + gasto.GASTO_MANTENCION_AREAS,
                    "Gasto Camaras " + gasto.GASTO_CAMARAS,
                    "Gastos Articulos de Aseo " + gasto.GASTO_ARTICULOS_ASEO,
                    "Gasto Aseo " + gasto.GASTOS_ASEO,
                    "Gasto Ascensor " + gasto.GASTO_ASCENSOR,
                    "Gasto Agua Caliente " + gasto.GASTO_AGUA_CALIENTE,
                    "Otros Gastos " + gasto.GASTO_OTRO,
                    "Multa " + multa.ToString()
                };
                long total = Convert.ToInt64(gasto.TOTAL_GASTO) + multa;
                listGastos.DataSource = listaG;
                listGastos.DataBind();
            }
            catch (Exception ex)
            {
                listGastos.DataSource = null;
                listGastos.DataBind();
                System.Diagnostics.Debug.WriteLine("Error:  " + ex);
            }
        }

        protected void btnAgregarGasto_Click(object sender, EventArgs e)
        {
            btnPagarGasto.Visible = true;
            GASTOS_COMUNES gasto = new GASTOS_COMUNES();
            DEPARTAMENTO departamento = new DEPARTAMENTO();
            List<MULTA> listaMulta = Controller.ControllerMulta.listaMultaNoPagadaDepartamento(Convert.ToInt64(dplDepartamento.SelectedValue));
            long multa = 0;
            foreach (MULTA item in listaMulta)
            {
                multa = multa + item.COSTO_MULTA;
            }
            departamento = Controller.ControllerDepartamento.buscarIdDepartamento(Convert.ToInt64(dplDepartamento.SelectedValue));
            gasto = Controller.ControllerGastoComun.buscarGastoComunEdificio(departamento.ID_EDIFICIO);

            Adapter.AdapterBoletaGasto pago = new Adapter.AdapterBoletaGasto();
            long totalBoleta = Convert.ToInt64(gasto.TOTAL_GASTO) + multa;
            pago._ID_GASTOS = gasto.ID_GASTOS;
            pago._ID_DEPARTAMENTO = departamento.ID_DEPARTAMENTO;
            pago._FK_RUT = persona.FK_RUT;
            pago._NUMERO_DEP = departamento.NUMERO_DEP;
            pago._TOTAL_GASTO = gasto.TOTAL_GASTO;
            pago._MULTA = multa;
            pago._COSTO_BOLETA = totalBoleta;

            listaGastos.Add(pago);
            grGastos.DataSource = listaGastos;
            grGastos.DataBind();
            total = total + pago._COSTO_BOLETA;
            lbTotal.Text = total.ToString();
            dplDepartamento.SelectedIndex = 0;
            listGastos.DataSource = null;
            listGastos.DataBind();
        }

        protected void grGastos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = grGastos.SelectedIndex;
            Adapter.AdapterBoletaGasto aux = listaGastos[index];
            total = total - aux._COSTO_BOLETA;
            lbTotal.Text = total.ToString();
            listaGastos.RemoveAt(index);
            grGastos.DataSource = listaGastos;
            grGastos.DataBind();
            lbTotal.Text = total.ToString();
        }

        protected void grGastos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grGastos.PageIndex = e.NewPageIndex;
            grGastos.DataSource = listaGastos;
            grGastos.DataBind();
        }

        protected void btnPagarGasto_Click(object sender, EventArgs e)
        {
        }
    }
}