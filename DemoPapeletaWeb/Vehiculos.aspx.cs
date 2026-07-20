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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarVehiculos(null);
            }
        }

        private void CargarVehiculos(string filtro)
        {
            var lista = objVehiculoBL.BuscarVehiculos(filtro);
            gvVehiculos.DataSource = lista;
            gvVehiculos.DataBind();
            lblCantidad.Text = "Vehículos: " + lista.Count;
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            CargarVehiculos(txtBuscar.Text.Trim());
        }
    }
}