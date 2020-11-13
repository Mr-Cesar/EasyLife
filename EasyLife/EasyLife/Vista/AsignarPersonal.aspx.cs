using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EasyLife.Vista
{
    public partial class AsignarPersonal : System.Web.UI.Page
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
                cargarOpcion(true);
            }
        }

        private static List<PERSONA> listaPersonal = new List<PERSONA>();
        private static List<Adapter.AdapterPersonal> listaPersonalAsignar = new List<Adapter.AdapterPersonal>();
        private static List<Adapter.AdapterPersonal> listaPersonalUpdate = new List<Adapter.AdapterPersonal>();
        private static List<Adapter.AdapterPersonal> listaPersonalActual = new List<Adapter.AdapterPersonal>();

        private static Boolean option = new Boolean();

        public void cargarOpcion(Boolean opcion)
        {
            if (opcion == true)
            {
                dplOption.Items.Insert(0, "Seleccione una Opción");
                dplOption.Items.Insert(1, "Asignar Administrador Condominio");
                dplOption.Items.Insert(2, "Asignar Conserje");
                dplOption.SelectedIndex = 0;
                option = true;
            }
            else
            {
                dplOption.Items.Insert(0, "Seleccione una Opción");
                dplOption.Items.Insert(1, "Asignar Conserje");
                dplOption.SelectedIndex = 0;
                option = false;
            }
        }

        public void cargarCondominio()
        {
            List<CONDOMINIO> listaCondominio = new List<CONDOMINIO>();
            listaCondominio = Controller.ControllerCondominio.listaCondominio();
            dplCondominio.DataSource = listaCondominio;
            dplCondominio.DataValueField = "ID_CONDOMINIO";
            dplCondominio.DataTextField = "NOMBRE_CONDOMINIO";
            dplCondominio.DataBind();
            dplCondominio.Items.Insert(0, "Seleccione un Condominio");
            dplCondominio.SelectedIndex = 0;
        }

        public void cargarCondominioAdm(long administrador)
        {
            List<CONDOMINIO> listaCondominio = new List<CONDOMINIO>();
            listaCondominio = Controller.ControllerCondominio.listaCondominioAdministrador(administrador);
            dplCondominio.DataSource = listaCondominio;
            dplCondominio.DataValueField = "ID_CONDOMINIO";
            dplCondominio.DataTextField = "NOMBRE_CONDOMINIO";
            dplCondominio.DataBind();
            dplCondominio.Items.Insert(0, "Seleccione un Condominio");
            dplCondominio.SelectedIndex = 0;
        }

        protected void dplOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                long seleccion = dplOption.SelectedIndex;
                listaPersonal = new List<PERSONA>();
                listaPersonalUpdate = new List<Adapter.AdapterPersonal>();
                listaPersonalActual = new List<Adapter.AdapterPersonal>();
                listaPersonalAsignar = new List<Adapter.AdapterPersonal>();
                dplCondominio.SelectedIndex = 0;
                dplCondominio.Enabled = true;
                dplPersonal.Enabled = true;
                btnAgregar.Visible = true;
                btnRegistro.Visible = true;
                lbPersonal.Visible = false;
                lbOk.Visible = false;
                lbError.Visible = false;
                grAsignados.DataSource = null;
                grAsignados.DataBind();
                grPersonal.DataSource = null;
                grPersonal.DataBind();

                if (seleccion == 0)
                {
                    btnAgregar.Visible = false;
                    btnRegistro.Visible = false;
                    grPersonal.DataSource = null;
                    grPersonal.DataBind();
                    grAsignados.DataSource = null;
                    grAsignados.DataBind();
                    dplCondominio.Enabled = true;
                    dplCondominio.SelectedIndex = 0;
                    dplPersonal.DataSource = null;
                    dplPersonal.DataBind();
                    dplPersonal.Items.Insert(0, "Seleccione Personal");
                    dplPersonal.SelectedIndex = 0;
                    dplCondominio.SelectedIndex = 0;
                }

                if (option == true)
                {
                    if (seleccion == 1)
                    {
                        listaPersonal = Controller.ControllerPersona.listaPersonalRol(5);
                        dplPersonal.DataSource = listaPersonal;
                        dplPersonal.DataValueField = "ID_PERSONA";
                        dplPersonal.DataTextField = "FK_RUT";
                        dplPersonal.DataBind();
                        dplPersonal.Items.Insert(0, "Seleccione Personal");
                        dplPersonal.SelectedIndex = 0;
                    }
                    else if (seleccion == 2)
                    {
                        listaPersonal = Controller.ControllerPersona.listaPersonalRol(2);
                        dplPersonal.DataSource = listaPersonal;
                        dplPersonal.DataValueField = "ID_PERSONA";
                        dplPersonal.DataTextField = "FK_RUT";
                        dplPersonal.DataBind();
                        dplPersonal.Items.Insert(0, "Seleccione Personal");
                        dplPersonal.SelectedIndex = 0;
                    }
                }
                else
                {
                    if (seleccion == 1)
                    {
                        listaPersonal = Controller.ControllerPersona.listaPersonalRol(2);
                        dplPersonal.DataSource = listaPersonal;
                        dplPersonal.DataValueField = "ID_PERSONA";
                        dplPersonal.DataTextField = "FK_RUT";
                        dplPersonal.DataBind();
                        dplPersonal.Items.Insert(0, "Seleccione Personal");
                        dplPersonal.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                btnAgregar.Visible = false;
                btnRegistro.Visible = false;
                grPersonal.DataSource = null;
                grPersonal.DataBind();
                grAsignados.DataSource = null;
                grAsignados.DataBind();
                dplCondominio.Enabled = true;
                dplCondominio.SelectedIndex = 0;
                dplPersonal.DataSource = null;
                dplPersonal.DataBind();
                dplPersonal.Items.Insert(0, "Seleccione Personal");
                dplPersonal.SelectedIndex = 0;
                dplCondominio.SelectedIndex = 0;
                System.Diagnostics.Debug.WriteLine("Error: " + ex);
            }
        }

        protected void dplCondominio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                long condominio = Convert.ToInt64(dplCondominio.SelectedValue);
                listaPersonalAsignar = new List<Adapter.AdapterPersonal>();
                listaPersonalUpdate = new List<Adapter.AdapterPersonal>();
                listaPersonalActual = new List<Adapter.AdapterPersonal>();
                listaPersonalActual = Controller.ControllerPersona.listaPersonalCondominio(condominio);
                grPersonal.DataSource = listaPersonalActual;
                grPersonal.DataBind();
            }
            catch (Exception ex)
            {
                dplPersonal.Items.Insert(0, "Seleccione Personal");
                dplPersonal.SelectedIndex = 0;
                grPersonal.DataSource = null;
                grPersonal.DataBind();
                grAsignados.DataSource = null;
                grAsignados.DataBind();
                System.Diagnostics.Debug.WriteLine("Error: " + ex);
            }
        }

        protected void grPersonal_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = grPersonal.SelectedIndex;
            Adapter.AdapterPersonal aux = listaPersonalActual[index];
            if (option == true)
            {
                listaPersonalUpdate.Add(listaPersonalActual[index]);
                listaPersonalActual.RemoveAt(index);
                grPersonal.DataSource = listaPersonalActual;
                grPersonal.DataBind();
            }
            else if (option == false)
            {
                if (aux._DESCRIPCION_ROL.Equals("Administrador Condominio"))
                {
                    lbPersonal.Visible = true;
                }
                else
                {
                    listaPersonalActual.RemoveAt(index);
                    listaPersonalUpdate.Add(listaPersonalActual[index]);
                    grPersonal.DataSource = listaPersonalActual;
                    grPersonal.DataBind();
                }
            }
        }

        protected void grPersonal_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grPersonal.PageIndex = e.NewPageIndex;
            grPersonal.DataSource = listaPersonal;
            grPersonal.DataBind();
        }

        protected void dplPersonal_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                long personal = Convert.ToInt64(dplPersonal.SelectedValue);
                lbError.Visible = false;
                Adapter.AdapterPersonal adapter = new Adapter.AdapterPersonal();
                Boolean action = true;
                foreach (Adapter.AdapterPersonal item in listaPersonalActual)
                {
                    if (item._ID_PERSONA == personal)
                    {
                        lbError.Visible = true;
                        action = false;
                    }
                }

                if (action == true)
                {
                    lbError.Visible = false;
                    adapter = Controller.ControllerPersona.buscarPersonalId(personal);
                    listaPersonalAsignar.Add(adapter);
                }
                grAsignados.DataSource = listaPersonalAsignar;
                grAsignados.DataBind();
                dplPersonal.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                grAsignados.DataSource = null;
                grAsignados.DataBind();
                System.Diagnostics.Debug.WriteLine("Error: " + ex);
            }
        }

        protected void grAsignados_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = grAsignados.SelectedIndex;
            listaPersonalAsignar.RemoveAt(index);
            grAsignados.DataSource = listaPersonalAsignar;
            grAsignados.DataBind();
        }

        protected void grAsignados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grAsignados.PageIndex = e.NewPageIndex;
            grAsignados.DataSource = listaPersonalAsignar;
            grAsignados.DataBind();
        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            string resultInsert = "";
            string resultUpdate = "";
            long condominio = Convert.ToInt64(dplCondominio.SelectedValue);
            if (listaPersonalAsignar.Count > 0)
            {
                if (listaPersonalUpdate.Count > 0)
                {
                    foreach (Adapter.AdapterPersonal item in listaPersonalUpdate)
                    {
                        if (item._DESCRIPCION_ROL.Equals("Administrador Condominio"))
                        {
                            resultUpdate = Controller.ControllerCondominio.quitarAdministradorCondominio(condominio);
                        }
                        else
                        {
                            resultUpdate = Controller.ControllerConserje.quitarConserjeCondominio(item._ID_PERSONA);
                        }
                    }
                }
                System.Diagnostics.Debug.WriteLine("Update: " + resultUpdate);

                foreach (Adapter.AdapterPersonal item in listaPersonalAsignar)
                {
                    if (item._DESCRIPCION_ROL.Equals("Administrador Condominio"))
                    {
                        resultInsert = Controller.ControllerCondominio.asignarAdministradorCondominio(item._ID_PERSONA, condominio);
                    }
                    else
                    {
                        resultInsert = Controller.ControllerConserje.asignarConserjeCondominio(item._ID_PERSONA, condominio);
                    }
                }
                System.Diagnostics.Debug.WriteLine("Insert: " + resultInsert);

                if (resultInsert.Equals("Personal Asignado"))
                {
                    if (listaPersonalUpdate.Count > 0)
                    {
                        if (resultUpdate.Equals("Personal Denegado"))
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Personal Asignado');window.location.href='" + Request.RawUrl + "';", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Personal Asignado');window.location.href='" + Request.RawUrl + "';", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Error al Asignar Personal');window.location.href='" + Request.RawUrl + "';", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('No ha Asignado Personal');window.location.href='" + Request.RawUrl + "';", true);
            }
        }
    }
}