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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarInfracciones(null);
        }

        private void CargarInfracciones(string filtro)
        {
            var lista = objInfraccionBL.BuscarInfracciones(filtro);
            gvInfracciones.DataSource = lista;
            gvInfracciones.DataBind();
            lblCantidad.Text = "Infracciones: " + lista.Count;
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
            CargarInfracciones(txtBuscar.Text.Trim());
        }
    }
}