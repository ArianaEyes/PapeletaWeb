using PapeletaWeb_BE;
using PapeletaWeb_BL;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoPapeletaWeb
{
    public partial class Vehiculos : System.Web.UI.Page
    {
        VehiculoBL objVehiculoBL = new VehiculoBL();
        private const int REGISTROS_POR_PAGINA = 10;

        private int PaginaActual
        {
            get { return ViewState["PaginaActual"] == null ? 1 : (int)ViewState["PaginaActual"]; }
            set { ViewState["PaginaActual"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarVehiculos(null);
                CargarCatalogos();
                pnlFormulario.Visible = false;
            }
        }

        private string CodigoVehiculo
        {
            get
            {
                return ViewState["CodigoVehiculo"] == null
                    ? ""
                    : ViewState["CodigoVehiculo"].ToString();
            }
            set
            {
                ViewState["CodigoVehiculo"] = value;
            }
        }

        private bool Editando
        {
            get
            {
                return ViewState["Editando"] == null
                    ? false
                    : (bool)ViewState["Editando"];
            }
            set
            {
                ViewState["Editando"] = value;
            }
        }

        private void CargarCatalogos()
        {
            ddlMarca.DataSource = objVehiculoBL.ListarMarcas();
            ddlMarca.DataTextField = "Marca";
            ddlMarca.DataValueField = "Cod_Marca";
            ddlMarca.DataBind();
            ddlMarca.Items.Insert(0, new ListItem("-- Seleccione --", ""));

            ddlColor.DataSource = objVehiculoBL.ListarColores();
            ddlColor.DataTextField = "Color";
            ddlColor.DataValueField = "Cod_Color";
            ddlColor.DataBind();
            ddlColor.Items.Insert(0, new ListItem("-- Seleccione --", ""));

            ddlTipo.DataSource = objVehiculoBL.ListarTiposVehiculo();
            ddlTipo.DataTextField = "Descripcion";
            ddlTipo.DataValueField = "Cod_Tipo";
            ddlTipo.DataBind();
            ddlTipo.Items.Insert(0, new ListItem("-- Seleccione --", ""));
        }

        private void LimpiarFormulario()
        {
            txtCodInfractor.Text = "";
            txtAnio.Text = "";
            txtNroMotor.Text = "";
            ddlMarca.SelectedIndex = 0;
            ddlColor.SelectedIndex = 0;
            ddlTipo.SelectedIndex = 0;
        }

        private void CargarVehiculos(string filtro)
        {
            int total = objVehiculoBL.ContarVehiculos(filtro);
            var lista = objVehiculoBL.BuscarVehiculos(filtro, PaginaActual, REGISTROS_POR_PAGINA);

            gvVehiculos.DataSource = lista;
            gvVehiculos.DataBind();

            lblCantidad.Text = "Vehículos: " + total;

            int totalPaginas = (int)Math.Ceiling((double)total / REGISTROS_POR_PAGINA);
            if (totalPaginas == 0) totalPaginas = 1;

            lblPagina.Text = "Página " + PaginaActual + " de " + totalPaginas;
            btnAnterior.Enabled = PaginaActual > 1;
            btnSiguiente.Enabled = PaginaActual < totalPaginas;
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            PaginaActual = 1;
            CargarVehiculos(txtBuscar.Text.Trim());
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            Editando = false;
            CodigoVehiculo = "";
            btnGuardar.Text = "Guardar";
            CargarCatalogos();
            pnlFormulario.Visible = true;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            pnlFormulario.Visible = false;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                VehiculoBE obj = new VehiculoBE();

                obj.Cod_Vehiculo = CodigoVehiculo;
                obj.Cod_Infractor = txtCodInfractor.Text.Trim().ToUpper();
                obj.Cod_Marca = ddlMarca.SelectedValue;
                obj.Cod_Color = ddlColor.SelectedValue;
                obj.Tipo_Vehiculo = ddlTipo.SelectedValue;
                obj.Anio_Fabricacion = Convert.ToInt32(txtAnio.Text.Trim());
                obj.Nro_Motor = txtNroMotor.Text.Trim();

                bool ok;
                bool estabaEditando = Editando;

                if (Editando)
                {
                    ok = objVehiculoBL.ActualizarVehiculo(obj);
                }
                else
                {
                    ok = objVehiculoBL.InsertarVehiculo(obj);
                }

                if (ok)
                {
                    LimpiarFormulario();
                    pnlFormulario.Visible = false;

                    Editando = false;
                    CodigoVehiculo = "";
                    btnGuardar.Text = "Guardar";

                    CargarVehiculos(txtBuscar.Text.Trim());

                    ScriptManager.RegisterStartupScript(
                        this,
                        GetType(),
                        "ok",
                        $"alert('Vehículo {(estabaEditando ? "actualizado" : "registrado")} correctamente.');", true);
                }
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException?.InnerException?.Message
                          ?? ex.InnerException?.Message
                          ?? ex.Message;

                ScriptManager.RegisterStartupScript(this, GetType(),
                    "error",
                    "alert('" + msg.Replace("'", "") + "');",
                    true);
            }
        }

        protected void gvVehiculos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                VehiculoBE obj = objVehiculoBL.ObtenerVehiculo(e.CommandArgument.ToString());

                if (obj != null)
                {
                    CodigoVehiculo = obj.Cod_Vehiculo;
                    Editando = true;

                    txtCodInfractor.Text = obj.Cod_Infractor;
                    ddlMarca.SelectedValue = obj.Cod_Marca;
                    ddlColor.SelectedValue = obj.Cod_Color;
                    ddlTipo.SelectedValue = obj.Tipo_Vehiculo;
                    txtAnio.Text = obj.Anio_Fabricacion.ToString();
                    txtNroMotor.Text = obj.Nro_Motor;

                    btnGuardar.Text = "Actualizar";
                    pnlFormulario.Visible = true;
                }
            }

            if (e.CommandName == "Eliminar")
            {
                objVehiculoBL.EliminarVehiculo(e.CommandArgument.ToString());

                CargarVehiculos(txtBuscar.Text.Trim());

                ScriptManager.RegisterStartupScript(
                    this,
                    GetType(),
                    "ok",
                    "alert('Vehículo desactivado correctamente.');",
                    true);
            }
        }

        protected void btnAnterior_Click(object sender, EventArgs e)
        {
            if (PaginaActual > 1) { PaginaActual--; CargarVehiculos(txtBuscar.Text.Trim()); }
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            PaginaActual++;
            CargarVehiculos(txtBuscar.Text.Trim());
        }
    }
}