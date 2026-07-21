using PapeletaWeb_BE;
using PapeletaWeb_BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoPapeletaWeb
{
    public partial class Policias : System.Web.UI.Page
    {
        PoliciaBL objPoliciaBL = new PoliciaBL();
        UbigeoBL objUbigeoBL = new UbigeoBL();
        RangoBL objRangoBL = new RangoBL();

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

        protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarProvincias();

            ddlDistrito.Items.Clear();
            ddlDistrito.Items.Insert(0, new ListItem("-- Seleccione --", ""));
        }
        private void CargarDepartamentos()
        {
            ddlDepartamento.DataSource = objUbigeoBL.ListarDepartamentos();
            ddlDepartamento.DataTextField = "Departamento";
            ddlDepartamento.DataValueField = "Id_Depa";
            ddlDepartamento.DataBind();

            ddlDepartamento.Items.Insert(0, new ListItem("-- Seleccione --", ""));
        }
        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDistritos();
        }
        private void CargarProvincias()
        {
            ddlProvincia.DataSource = objUbigeoBL.ListarProvincias(ddlDepartamento.SelectedValue);
            ddlProvincia.DataTextField = "Provincia";
            ddlProvincia.DataValueField = "Id_Prov";
            ddlProvincia.DataBind();

            ddlProvincia.Items.Insert(0, new ListItem("-- Seleccione --", ""));
        }

        private void CargarDistritos()
        {
            ddlDistrito.DataSource = objUbigeoBL.ListarDistritos(
                ddlDepartamento.SelectedValue,
                ddlProvincia.SelectedValue);

            ddlDistrito.DataTextField = "Distrito";
            ddlDistrito.DataValueField = "Cod_Ubigeo";
            ddlDistrito.DataBind();

            ddlDistrito.Items.Insert(0, new ListItem("-- Seleccione --", ""));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPolicias(null);

                CargarDepartamentos();
                CargarRangos();

                pnlFormulario.Visible = false;
            }
        }
        private void CargarRangos()
        {
            ddlRango.DataSource = objRangoBL.ListarRangos();

            ddlRango.DataValueField = "Cod_Rango";
            ddlRango.DataTextField = "Descripcion";

            ddlRango.DataBind();

            ddlRango.Items.Insert(0,
                new ListItem("-- Seleccione --", ""));
        }
        private void CargarPolicias(string filtro)
        {
            int total = objPoliciaBL.ContarPolicias(filtro);

            var lista = objPoliciaBL.BuscarPolicias(
                filtro,
                PaginaActual,
                REGISTROS_POR_PAGINA);

            gvPolicias.DataSource = lista;
            gvPolicias.DataBind();

            lblCantidad.Text = "Policías: " + total;

            int totalPaginas = (int)Math.Ceiling((double)total / REGISTROS_POR_PAGINA);

            if (totalPaginas == 0)
                totalPaginas = 1;

            lblPagina.Text = "Página " + PaginaActual + " de " + totalPaginas;

            btnAnterior.Enabled = PaginaActual > 1;
            btnSiguiente.Enabled = PaginaActual < totalPaginas;
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            PaginaActual = 1;
            CargarPolicias(txtBuscar.Text.Trim());
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();

            CodigoEditar = "";

            pnlFormulario.Visible = true;
        }
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                string codigo = ((LinkButton)sender).CommandArgument;

                PoliciaBE obj = objPoliciaBL.ConsultarPolicia(codigo);

                if (obj != null)
                {
                    CodigoEditar = obj.Cod_Policia;

                    txtDNI.Text = obj.Dni;
                    txtNombre.Text = obj.Nombre;
                    txtPaterno.Text = obj.Paterno;
                    txtMaterno.Text = obj.Materno;

                    txtNacimiento.Text = obj.FechaNacimiento.ToString("yyyy-MM-dd");

                    rblSexo.SelectedValue = obj.Sexo;
                    rblEstado.SelectedValue = obj.Estado;

                    ddlDepartamento.SelectedValue = obj.Id_Depa;
                    CargarProvincias();

                    ddlProvincia.SelectedValue = obj.Id_Prov;
                    CargarDistritos();

                    ddlDistrito.SelectedValue = obj.Cod_Ubigeo;

                    ddlRango.SelectedValue = obj.Cod_Rango.ToString();

                    pnlFormulario.Visible = true;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(
                    this,
                    GetType(),
                    "",
                    "alert('" + ex.Message.Replace("'", "") + "');",
                    true);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string codigo = ((LinkButton)sender).CommandArgument;

                objPoliciaBL.EliminarPolicia(codigo, "ADMIN");

                CargarPolicias(txtBuscar.Text.Trim());

                ScriptManager.RegisterStartupScript(
                    this,
                    GetType(),
                    "",
                    "alert('Policía inactivado correctamente.');",
                    true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(
                    this,
                    GetType(),
                    "",
                    "alert('" + ex.Message.Replace("'", "") + "');",
                    true);
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            if (!Page.IsValid)
            {
                pnlFormulario.Visible = true;
                return;
            }
            try
            {
                PoliciaBE obj = new PoliciaBE();

                obj.Nombre = txtNombre.Text.Trim();
                obj.Paterno = txtPaterno.Text.Trim();
                obj.Materno = txtMaterno.Text.Trim();
                obj.Dni = txtDNI.Text.Trim();

                obj.Cod_Ubigeo = ddlDistrito.SelectedValue;
                obj.Cod_Rango = Convert.ToInt32(ddlRango.SelectedValue);

                obj.Sexo = rblSexo.SelectedValue;
                obj.Estado = rblEstado.SelectedValue;

                obj.FechaNacimiento = Convert.ToDateTime(txtNacimiento.Text);
                obj.Foto = null;

                if (string.IsNullOrEmpty(CodigoEditar))
                {
                    obj.Usu_Registro = "ADMIN";
                    objPoliciaBL.InsertarPolicia(obj);
                }
                else
                {
                    obj.Cod_Policia = CodigoEditar;
                    obj.Usu_Ult_Modificacion = "ADMIN";
                    objPoliciaBL.ActualizarPolicia(obj);
                }

                LimpiarFormulario();

                CodigoEditar = "";

                pnlFormulario.Visible = false;

                CargarPolicias(txtBuscar.Text.Trim());

                ScriptManager.RegisterStartupScript(
                    this,
                    GetType(),
                    "",
                    "alert('Registro guardado correctamente');",
                    true);
            }
            catch (Exception ex)
            {
                pnlFormulario.Visible = true;

                ScriptManager.RegisterStartupScript(
                    this,
                    GetType(),
                    "",
                    "alert('" + ex.Message.Replace("'", "") + "');",
                    true);
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();

            CodigoEditar = "";

            pnlFormulario.Visible = false;
        }

        private void LimpiarFormulario()
        {
            txtDNI.Text = "";
            txtNombre.Text = "";
            txtPaterno.Text = "";
            txtMaterno.Text = "";
            txtNacimiento.Text = "";

            ddlDepartamento.SelectedIndex = 0;

            ddlProvincia.Items.Clear();
            ddlDistrito.Items.Clear();

            ddlRango.SelectedIndex = 0;

            rblSexo.SelectedValue = "M";
            rblEstado.SelectedValue = "A";
        }
        protected void btnAnterior_Click(object sender, EventArgs e)
        {
            if (PaginaActual > 1)
            {
                PaginaActual--;
                CargarPolicias(txtBuscar.Text.Trim());
            }
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            PaginaActual++;
            CargarPolicias(txtBuscar.Text.Trim());
        }
    }
}