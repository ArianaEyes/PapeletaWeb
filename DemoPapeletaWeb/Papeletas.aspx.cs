using PapeletaWeb_BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoPapeletaWeb
{
    public partial class Papeletas : System.Web.UI.Page
    {
        PapeletaBL objPapeletaBL = new PapeletaBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarPapeletas(null);
        }

        private void CargarPapeletas(string filtro)
        {
            var lista = objPapeletaBL.BuscarPapeletas(filtro);
            gvPapeletas.DataSource = lista;
            gvPapeletas.DataBind();
            lblCantidad.Text = "Papeletas: " + lista.Count;
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            CargarPapeletas(txtBuscar.Text.Trim());
        }
    }
}