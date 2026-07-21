using PapeletaWeb_BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            if (!IsPostBack)
            {
                CargarVehiculos(null);
            }
        }

        private void CargarVehiculos(string filtro)
        {
            int total = objVehiculoBL.ContarVehiculos(filtro);

            var lista = objVehiculoBL.BuscarVehiculos(
                filtro,
                PaginaActual,
                REGISTROS_POR_PAGINA);

            gvVehiculos.DataSource = lista;
            gvVehiculos.DataBind();

            lblCantidad.Text = "Vehículos: " + total;

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
            CargarVehiculos(txtBuscar.Text.Trim());
        }

        protected void btnAnterior_Click(object sender, EventArgs e)
        {
            if (PaginaActual > 1)
            {
                PaginaActual--;
                CargarVehiculos(txtBuscar.Text.Trim());
            }
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            PaginaActual++;
            CargarVehiculos(txtBuscar.Text.Trim());
        }
    }
}