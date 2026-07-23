using PapeletaWeb_BL;
using PapeletaWeb_BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoPapeletaWeb
{
    public partial class Infractores : System.Web.UI.Page
    {

        InfractorBL objInfractorBL = new InfractorBL();

        UbigeoBL objUbigeoBL = new UbigeoBL();

        private string CodUbigeoSeleccionado
        {
            get
            {
                return ddlDistrito.SelectedValue;
            }
        }

        private const int REGISTROS_POR_PAGINA = 10;

        private int PaginaActual
        {
            get
            {
                return ViewState["PaginaActual"] == null ? 1 : (int)ViewState["PaginaActual"];
            }
            set
            {
                ViewState["PaginaActual"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();

            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx");
                return; // importante: corta la ejecución para que no siga con el resto del código
            }
            if (!IsPostBack)
            {
                CargarInfractores(null);

                CargarDepartamentos();

                rblSexo.SelectedValue = "M";

                rblEstado.SelectedValue = "A";

                pnlFormulario.Visible = false;
            }
        }

        private void LimpiarFormulario()
        {
            txtDNI.Text = "";
            txtCorreo.Text = "";
            txtNombres.Text = "";
            txtPaterno.Text = "";
            txtMaterno.Text = "";
            txtDireccion.Text = "";
            txtNacimiento.Text = "";
            txtBrevete.Text = "";
            ddlTipoBrevete.SelectedValue = "";

            ddlDepartamento.SelectedIndex = 0;

            ddlProvincia.Items.Clear();
            ddlDistrito.Items.Clear();

            rblSexo.SelectedValue = "M";
            rblEstado.SelectedValue = "A";
        }

        private void CargarDepartamentos()
        {
            ddlDepartamento.DataSource = objUbigeoBL.ListarDepartamentos();
            ddlDepartamento.DataTextField = "Departamento";
            ddlDepartamento.DataValueField = "Id_Depa";
            ddlDepartamento.DataBind();

            ddlDepartamento.Items.Insert(0, new ListItem("-- Seleccione --", ""));
        }

        private void CargarInfractores(string filtro)
        {
            int total = objInfractorBL.ContarInfractores(filtro);

            var lista = objInfractorBL.BuscarInfractores(
                filtro,
                PaginaActual,
                REGISTROS_POR_PAGINA);

            gvInfractores.DataSource = lista;
            gvInfractores.DataBind();

            lblCantidad.Text = "Infractores: " + total;

            int totalPaginas = (int)Math.Ceiling((double)total / REGISTROS_POR_PAGINA);

            lblPagina.Text = "Página " + PaginaActual + " de " + totalPaginas;

            btnAnterior.Enabled = PaginaActual > 1;
            btnSiguiente.Enabled = PaginaActual < totalPaginas;
        }

        private void CargarProvincias()
        {
            ddlProvincia.DataSource =
                objUbigeoBL.ListarProvincias(ddlDepartamento.SelectedValue);

            ddlProvincia.DataTextField = "Provincia";
            ddlProvincia.DataValueField = "Id_Prov";
            ddlProvincia.DataBind();

            ddlProvincia.Items.Insert(0, new ListItem("-- Seleccione --", ""));
        }

        private void CargarDistritos()
        {
            ddlDistrito.DataSource =
                objUbigeoBL.ListarDistritos(
                    ddlDepartamento.SelectedValue,
                    ddlProvincia.SelectedValue);

            ddlDistrito.DataTextField = "Distrito";
            ddlDistrito.DataValueField = "Cod_Ubigeo";
            ddlDistrito.DataBind();

            ddlDistrito.Items.Insert(0, new ListItem("-- Seleccione --", ""));
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            PaginaActual = 1;
            CargarInfractores(txtBuscar.Text.Trim());
        }

        private string CodigoEditar
        {
            get
            {
                return ViewState["CodigoEditar"] == null
                    ? ""
                    : ViewState["CodigoEditar"].ToString();
            }
            set
            {
                ViewState["CodigoEditar"] = value;
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)sender;

                string codigo = btn.CommandArgument;

                InfractorBE obj = objInfractorBL.ConsultarInfractor(codigo);

                if (obj != null)
                {
                    CodigoEditar = codigo;

                    txtDNI.Text = obj.Dni;
                    txtPaterno.Text = obj.Ape_Paterno;
                    txtMaterno.Text = obj.Ape_Materno;
                    txtNombres.Text = obj.Nombres;
                    txtCorreo.Text = obj.Correo;
                    txtDireccion.Text = obj.Direccion;

                    txtNacimiento.Text = obj.Fec_Nacimiento.ToString("yyyy-MM-dd");

                    txtBrevete.Text = obj.Nro_Brevete;
                    ddlTipoBrevete.SelectedValue = obj.Tipo_Brevete;


                    rblSexo.SelectedValue = obj.Sexo;
                    rblEstado.SelectedValue = obj.Estado;

                    ddlDepartamento.SelectedValue = obj.Id_Depa;
                    CargarProvincias();

                    ddlProvincia.SelectedValue = obj.Id_Prov;
                    CargarDistritos();

                    ddlDistrito.SelectedValue = obj.Cod_Ubigeo;

                    rblSexo.SelectedValue = obj.Sexo;
                    rblEstado.SelectedValue = obj.Estado;

                    pnlFormulario.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)sender;

                string codigo = btn.CommandArgument;

                objInfractorBL.EliminarInfractor(codigo, "ADMIN");

                CargarInfractores(txtBuscar.Text.Trim());

                ScriptManager.RegisterStartupScript(
                    this,
                    GetType(),
                    "ok",
                    "alert('Infractor inactivado correctamente.');",
                    true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(
                    this,
                    GetType(),
                    "error",
                    "alert('" + ex.Message.Replace("'", "") + "');",
                    true);
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                InfractorBE objInfractorBE = new InfractorBE();

                objInfractorBE.Dni = txtDNI.Text.Trim();
                objInfractorBE.Ape_Paterno = txtPaterno.Text.Trim();
                objInfractorBE.Ape_Materno = txtMaterno.Text.Trim();
                objInfractorBE.Nombres = txtNombres.Text.Trim();
                objInfractorBE.Correo = txtCorreo.Text.Trim();
                objInfractorBE.Direccion = txtDireccion.Text.Trim();

                objInfractorBE.Cod_Ubigeo = ddlDistrito.SelectedValue;

                objInfractorBE.Sexo = rblSexo.SelectedValue;

                objInfractorBE.Fec_Nacimiento = Convert.ToDateTime(txtNacimiento.Text);

                objInfractorBE.Foto = null;

                objInfractorBE.Nro_Brevete = txtBrevete.Text.Trim();
                objInfractorBE.Tipo_Brevete = ddlTipoBrevete.SelectedValue;

                objInfractorBE.Usu_Registro = "ADMIN";

                objInfractorBE.Estado = rblEstado.SelectedValue;

                bool ok;

                if (string.IsNullOrEmpty(CodigoEditar))
                {
                    ok = objInfractorBL.InsertarInfractor(objInfractorBE);
                }
                else
                {
                    objInfractorBE.Cod_Infractor = CodigoEditar;
                    ok = objInfractorBL.ActualizarInfractor(objInfractorBE);
                }

                if (ok)
                {
                    LimpiarFormulario();
                    CodigoEditar = "";

                    pnlFormulario.Visible = false;

                    CargarInfractores(null);

                    ScriptManager.RegisterStartupScript(
                        this,
                        GetType(),
                        "ok",
                        "alert('Datos guardados correctamente');",
                        true);
                }
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException?.InnerException?.Message
                          ?? ex.InnerException?.Message
                          ?? ex.Message;

                throw new Exception(msg);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            CodigoEditar = "";
            LimpiarFormulario();
            pnlFormulario.Visible = false;
        }

        protected void btnAnterior_Click(object sender, EventArgs e)
        {
            if (PaginaActual > 1)
            {
                PaginaActual--;
                CargarInfractores(txtBuscar.Text.Trim());
            }
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            PaginaActual++;
            CargarInfractores(txtBuscar.Text.Trim());
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            CodigoEditar = "";
            LimpiarFormulario();
            pnlFormulario.Visible = true;
        }

        protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarProvincias();

            ddlDistrito.Items.Clear();
        }

        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDistritos();
        }
    }
}