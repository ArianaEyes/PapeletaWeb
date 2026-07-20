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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarPolicias(null);
        }

        private void CargarPolicias(string filtro)
        {
            var lista = objPoliciaBL.BuscarPolicias(filtro);
            gvPolicias.DataSource = lista;
            gvPolicias.DataBind();
            lblCantidad.Text = "Policías: " + lista.Count;
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            CargarPolicias(txtBuscar.Text.Trim());
        }
    }
}