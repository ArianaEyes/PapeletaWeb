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
                obj.Cod_Infractor = txtCodInfractor.Text.Trim().ToUpper();
                obj.Cod_Marca = ddlMarca.SelectedValue;
                obj.Cod_Color = ddlColor.SelectedValue;
                obj.Tipo_Vehiculo = ddlTipo.SelectedValue;
                obj.Anio_Fabricacion = Convert.ToInt32(txtAnio.Text.Trim());
                obj.Nro_Motor = txtNroMotor.Text.Trim();

                if (objVehiculoBL.InsertarVehiculo(obj))
                {
                    LimpiarFormulario();
                    pnlFormulario.Visible = false;
                    CargarVehiculos(null);
                    ScriptManager.RegisterStartupScript(this, GetType(), "ok",
                        "alert('Vehículo registrado correctamente.');", true);
                }
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException?.InnerException?.Message
                          ?? ex.InnerException?.Message
                          ?? ex.Message;
                ScriptManager.RegisterStartupScript(this, GetType(), "error",
                    "alert('" + msg.Replace("'", "") + "');", true);
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