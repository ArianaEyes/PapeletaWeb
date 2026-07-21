using PapeletaWeb_BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoPapeletaWeb
{
    public partial class Infracciones : System.Web.UI.Page
    {
        InfraccionBL objInfraccionBL = new InfraccionBL();

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
                CargarInfracciones(null);
        }

        private void CargarInfracciones(string filtro)
        {
            int total = objInfraccionBL.ContarInfracciones(filtro);

            var lista = objInfraccionBL.BuscarInfracciones(
                filtro,
                PaginaActual,
                REGISTROS_POR_PAGINA);

            gvInfracciones.DataSource = lista;
            gvInfracciones.DataBind();

            lblCantidad.Text = "Infracciones: " + total;

            int totalPaginas = (int)Math.Ceiling((double)total / REGISTROS_POR_PAGINA);

            if (totalPaginas == 0)
                totalPaginas = 1;

            lblPagina.Text = "Página " + PaginaActual + " de " + totalPaginas;

            btnAnterior.Enabled = PaginaActual > 1;
            btnSiguiente.Enabled = PaginaActual < totalPaginas;
        }

        protected string ObtenerClaseBadge(object calificacion)
        {
            string calif = calificacion?.ToString() ?? "";
            if (calif == "MUY GRAVE") return "bg-danger";
            if (calif == "GRAVE") return "bg-warning text-dark";
            return "bg-success";
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            PaginaActual = 1;
            CargarInfracciones(txtBuscar.Text.Trim());
        }

        protected void btnAnterior_Click(object sender, EventArgs e)
        {
            if (PaginaActual > 1)
            {
                PaginaActual--;
                CargarInfracciones(txtBuscar.Text.Trim());
            }
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            PaginaActual++;
            CargarInfracciones(txtBuscar.Text.Trim());
        }
    }
}