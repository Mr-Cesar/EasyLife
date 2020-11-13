using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EasyLife.Vista
{
    public partial class RegistroLuz : System.Web.UI.Page
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
        }

        private static List<LUZ_EDIFICIO> listaLuzEdificio = new List<LUZ_EDIFICIO>();
        private static List<LUZ_DEPARTAMENTO> listaLuzDep = new List<LUZ_DEPARTAMENTO>();

        protected void dplOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                long option = dplOption.SelectedIndex;
                if (option == 0)
                {
                    btnAgregarLuzEdificio.Visible = false;
                    btnAgregarLuzDep.Visible = false;
                    btnRegistroLuzEdificio.Visible = false;
                    btnRegistroLuzDep.Visible = false;
                    listaLuzEdificio = new List<LUZ_EDIFICIO>();
                    grCodLuzEdificio.DataSource = listaLuzEdificio;
                    grCodLuzEdificio.DataBind();
                    listaLuzDep = new List<LUZ_DEPARTAMENTO>();
                    grCodLuzDep.DataSource = listaLuzDep;
                    grCodLuzDep.DataBind();
                }
                else if (option == 1)
                {
                    btnAgregarLuzEdificio.Visible = true;
                    btnRegistroLuzEdificio.Visible = true;
                    btnAgregarLuzDep.Visible = false;
                    btnAgregarLuzDep.Visible = false;
                    listaLuzEdificio = new List<LUZ_EDIFICIO>();
                    grCodLuzEdificio.DataSource = listaLuzEdificio;
                    grCodLuzEdificio.DataBind();
                    listaLuzDep = new List<LUZ_DEPARTAMENTO>();
                    grCodLuzDep.DataSource = listaLuzDep;
                    grCodLuzDep.DataBind();
                }
                else if (option == 2)
                {
                    btnAgregarLuzDep.Visible = true;
                    btnRegistroLuzDep.Visible = true;
                    btnAgregarLuzEdificio.Visible = false;
                    btnRegistroLuzEdificio.Visible = false;
                    listaLuzEdificio = new List<LUZ_EDIFICIO>();
                    grCodLuzEdificio.DataSource = listaLuzEdificio;
                    grCodLuzEdificio.DataBind();
                    listaLuzDep = new List<LUZ_DEPARTAMENTO>();
                    grCodLuzDep.DataSource = listaLuzDep;
                    grCodLuzDep.DataBind();
                }
            }
            catch (Exception ex)
            {
                btnAgregarLuzEdificio.Visible = false;
                btnAgregarLuzDep.Visible = false;
                btnRegistroLuzEdificio.Visible = false;
                btnRegistroLuzDep.Visible = false;
                listaLuzEdificio = new List<LUZ_EDIFICIO>();
                grCodLuzEdificio.DataSource = listaLuzEdificio;
                grCodLuzEdificio.DataBind();
                listaLuzDep = new List<LUZ_DEPARTAMENTO>();
                grCodLuzDep.DataSource = listaLuzDep;
                grCodLuzDep.DataBind();
                System.Diagnostics.Debug.WriteLine("Error: " + ex);
            }
        }

        protected void btnAgregarLuzEdificio_Click(object sender, EventArgs e)
        {
            LUZ_EDIFICIO luz = new LUZ_EDIFICIO();
            List<LUZ_EDIFICIO> lista = Controller.ControllerLuzEdificio.listaLuzEdificio();
            Boolean operation = true;
            foreach (LUZ_EDIFICIO item in lista)
            {
                if (item.CODIGO_LUZ_E.Equals(txtCod.Text))
                {
                    lbError.Visible = true;
                    lbError.Text = "Luz ya esta Registrada";
                    operation = false;
                }
            }

            if (listaLuzEdificio.Count > 0)
            {
                foreach (LUZ_EDIFICIO item in listaLuzEdificio)
                {
                    if (item.CODIGO_LUZ_E.Equals(txtCod.Text))
                    {
                        lbError.Visible = true;
                        lbError.Text = "Luz ya Ingresada";
                        operation = false;
                    }
                }
            }

            if (operation == true)
            {
                lbError.Visible = false;
                luz.CODIGO_LUZ_E = txtCod.Text;
                listaLuzEdificio.Add(luz);
                grCodLuzEdificio.DataSource = listaLuzEdificio;
                grCodLuzEdificio.DataBind();
            }
            txtCod.Text = "";
        }

        protected void btnAgregarLuzDep_Click(object sender, EventArgs e)
        {
            lbError.Visible = false;
            LUZ_DEPARTAMENTO luz = new LUZ_DEPARTAMENTO();
            List<LUZ_DEPARTAMENTO> lista = Controller.ControllerLuzDepartamento.listaLuzDepartamento();
            Boolean operation = true;
            foreach (LUZ_DEPARTAMENTO item in lista)
            {
                if (item.CODIGO_LUZ_D.Equals(txtCod.Text))
                {
                    lbError.Visible = true;
                    lbError.Text = "Luz ya esta Registrada";
                    operation = false;
                }
            }

            if (listaLuzDep.Count > 0)
            {
                foreach (LUZ_DEPARTAMENTO item in listaLuzDep)
                {
                    if (item.CODIGO_LUZ_D.Equals(txtCod.Text))
                    {
                        lbError.Visible = true;
                        lbError.Text = "Luz ya Ingresada";
                        operation = false;
                    }
                }
            }

            if (operation == true)
            {
                lbError.Visible = false;
                grCodLuzDep.Visible = true;
                luz.CODIGO_LUZ_D = txtCod.Text;
                listaLuzDep.Add(luz);
                grCodLuzDep.DataSource = listaLuzDep;
                grCodLuzDep.DataBind();
            }
            txtCod.Text = "";
        }

        protected void grCodLuzEdificio_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = grCodLuzEdificio.SelectedIndex;
            listaLuzEdificio.RemoveAt(index);
            grCodLuzEdificio.DataSource = listaLuzEdificio;
            grCodLuzEdificio.DataBind();
        }

        protected void grCodLuzEdificio_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grCodLuzEdificio.PageIndex = e.NewPageIndex;
            grCodLuzEdificio.DataSource = listaLuzEdificio;
            grCodLuzEdificio.DataBind();
        }

        protected void grCodLuzDep_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = grCodLuzDep.SelectedIndex;
            listaLuzDep.RemoveAt(index);
            grCodLuzDep.DataSource = listaLuzDep;
            grCodLuzDep.DataBind();
        }

        protected void grCodLuzDep_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grCodLuzDep.PageIndex = e.NewPageIndex;
            grCodLuzDep.DataSource = listaLuzDep;
            grCodLuzDep.DataBind();
        }

        protected void btnRegistroLuzEdificio_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            string result = "";
            if (listaLuzEdificio.Count > 0)
            {
                foreach (LUZ_EDIFICIO item in listaLuzEdificio)
                {
                    result = Controller.ControllerLuzEdificio.crearLuzEdificio(item.CODIGO_LUZ_E);
                }

                if (result.Equals("Luz Edificio Creada"))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Luz Registrada');window.location.href='" + Request.RawUrl + "';", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Error al Registrar Luz');window.location.href='" + Request.RawUrl + "';", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('No a Registrado Ninguna Luz');window.location.href='" + Request.RawUrl + "';", true);
            }
        }

        protected void btnRegistroLuzDep_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            string result = "";
            if (listaLuzDep.Count > 0)
            {
                foreach (LUZ_DEPARTAMENTO item in listaLuzDep)
                {
                    result = Controller.ControllerLuzDepartamento.crearLuzDepartamento(item.CODIGO_LUZ_D);
                }

                if (result.Equals("Luz Departamento Creada"))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Luz Registrada');window.location.href='" + Request.RawUrl + "';", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Error al Registrar Luz');window.location.href='" + Request.RawUrl + "';", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('No a Registrado Ninguna Luz');window.location.href='" + Request.RawUrl + "';", true);
            }
        }
    }
}