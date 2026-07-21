using PapeletaWeb_BL;
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
                CargarInfractores(null);
            }
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

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            PaginaActual = 1;
            CargarInfractores(txtBuscar.Text.Trim());
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
    }
}