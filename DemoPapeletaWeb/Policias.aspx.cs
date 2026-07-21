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
                CargarPolicias(null);
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