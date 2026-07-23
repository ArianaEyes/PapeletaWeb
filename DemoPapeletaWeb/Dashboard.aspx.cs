using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PapeletaWeb_BE;
using PapeletaWeb_BL;

namespace DemoPapeletaWeb
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();

            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx");
                return; // importante: corta la ejecución para que no siga con el resto del código
            }

            try
            {
                if (Page.IsPostBack == false)
                {
                    DashboardBL objDashboardBL = new DashboardBL();
                    DashboardBE objDashboardBE = objDashboardBL.ObtenerTotales();

                    lblTotalPapeletas.Text = objDashboardBE.TotalPapeletas.ToString();
                    lblTotalInfractores.Text = objDashboardBE.TotalInfractores.ToString();
                    lblTotalVehiculos.Text = objDashboardBE.TotalVehiculos.ToString();

                    List<PapeletaAnualBE> objListaAnual = objDashboardBL.ObtenerPapeletasPorAño();
                    List<TopInfraccionBE> objListaTop = objDashboardBL.ObtenerTopInfracciones();
                    List<PapeletaMesBE> objListaMes = objDashboardBL.ObtenerPapeletasPorMes();
                    List<PapeletaVehiculoBE> objListaVehiculo = objDashboardBL.ObtenerInfraccionesPorVehiculo();

                    grafAnual.Series.Clear();
                    grafTop.Series.Clear();
                    grafMes.Series.Clear();
                    grafVehiculo.Series.Clear();

                    grafAnual.Series.Add("Papeletas");
                    grafAnual.Series["Papeletas"].Points.DataBindXY(objListaAnual, "Año", objListaAnual, "Cantidad");
                    grafAnual.Series["Papeletas"].IsValueShownAsLabel = true;

                    grafTop.Series.Clear();
                    grafTop.Series.Add("Infracciones");
                    grafTop.Series["Infracciones"].Points.DataBindXY(objListaTop, "Infraccion", objListaTop, "Cantidad");
                    grafTop.Series["Infracciones"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Pie;
                    grafTop.Series["Infracciones"].Label = "#VALY";
                    grafTop.Series["Infracciones"].LegendText = "#VALX";

                    grafMes.Series.Add("Meses");
                    grafMes.Series["Meses"].Points.DataBindXY(objListaMes, "Mes", objListaMes, "Cantidad");
                    grafMes.Series["Meses"].IsValueShownAsLabel = true;
                    grafMes.Series["Meses"].Color = System.Drawing.Color.Orange;

                    grafVehiculo.Series.Clear();
                    grafVehiculo.Series.Add("Vehiculos");
                    grafVehiculo.Series["Vehiculos"].Points.DataBindXY(objListaVehiculo, "TipoVehiculo", objListaVehiculo, "Cantidad");
                    grafVehiculo.Series["Vehiculos"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Doughnut;
                    grafVehiculo.Series["Vehiculos"].Label = "#VALY";
                    grafVehiculo.Series["Vehiculos"].LegendText = "#VALX";
                }
            }
            catch (Exception ex)
            {
                lblTotalPapeletas.Text = "Error: " + ex.Message;
            }
        }
    }
}