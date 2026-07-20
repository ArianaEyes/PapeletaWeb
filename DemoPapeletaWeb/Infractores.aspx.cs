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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarInfractores(null);
            }
        }

        private void CargarInfractores(string filtro)
        {
            var lista = objInfractorBL.BuscarInfractores(filtro);

            gvInfractores.DataSource = lista;
            gvInfractores.DataBind(); ;

            lblCantidad.Text = "Infractores: " + lista.Count;
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            CargarInfractores(txtBuscar.Text.Trim());
        }
    }
}