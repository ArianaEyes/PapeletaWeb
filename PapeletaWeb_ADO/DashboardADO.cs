using System;
using System.Collections.Generic;
using System.Linq;
using PapeletaWeb_BE;

namespace PapeletaWeb_ADO
{
    public class DashboardADO
    {
        PAPELETAEntities db = new PAPELETAEntities();

        public DashboardBE ObtenerTotales()
        {
            DashboardBE obj = new DashboardBE();
            try
            {
                obj.TotalPapeletas = db.TB_PAPELETA.Count();
                obj.TotalInfractores = db.TB_INFRACTOR.Count();
                obj.TotalVehiculos = db.TB_VEHICULO.Count();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener totales: " + ex.Message);
            }
            return obj;
        }

        public List<PapeletaAnualBE> ObtenerPapeletasPorAño()
        {
            List<PapeletaAnualBE> lista = new List<PapeletaAnualBE>();
            try
            {
                var query = db.SP_DASHBOARD_PAPELETAS_ANUAL().ToList();
                foreach (var item in query)
                {
                    PapeletaAnualBE obj = new PapeletaAnualBE();
                    obj.Año = item.Año.GetValueOrDefault();
                    obj.Cantidad = item.Cantidad.GetValueOrDefault();
                    lista.Add(obj);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener papeletas por año: " + ex.Message);
            }
            return lista;
        }

        public List<TopInfraccionBE> ObtenerTopInfracciones()
        {
            List<TopInfraccionBE> lista = new List<TopInfraccionBE>();
            try
            {
                var query = db.SP_DASHBOARD_TOP_INFRACCIONES().ToList();
                foreach (var item in query)
                {
                    TopInfraccionBE obj = new TopInfraccionBE();
                    obj.Infraccion = item.Infraccion;
                    obj.Cantidad = item.Cantidad.GetValueOrDefault();
                    lista.Add(obj);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener top infracciones: " + ex.Message);
            }
            return lista;
        }

        public List<PapeletaMesBE> ObtenerPapeletasPorMes()
        {
            try
            {
                List<PapeletaMesBE> objListaMes = new List<PapeletaMesBE>();

                using (PAPELETAEntities MisPapeletas = new PAPELETAEntities())
                {
                    var query = MisPapeletas.usp_PapeletasPorMes();
                    string[] nombresMeses = { "", "Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic" };

                    foreach (var resultado in query)
                    {
                        PapeletaMesBE objMes = new PapeletaMesBE();
                        int numeroMes = Convert.ToInt32(resultado.MesNumero);
                        objMes.Mes = nombresMeses[numeroMes];
                        objMes.Cantidad = Convert.ToInt32(resultado.Cantidad);
                        objListaMes.Add(objMes);
                    }

                    return objListaMes;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cargar los meses: " + ex.Message);
            }
        }

        public List<PapeletaVehiculoBE> ObtenerInfraccionesPorVehiculo()
        {
            try
            {
                List<PapeletaVehiculoBE> objListaVehiculo = new List<PapeletaVehiculoBE>();

                using (PAPELETAEntities MisPapeletas = new PAPELETAEntities())
                {
                    var query = MisPapeletas.SP_PAPELETAS_POR_TIPO_VEHICULO();

                    foreach (var resultado in query)
                    {
                        PapeletaVehiculoBE objVehiculo = new PapeletaVehiculoBE();
                        objVehiculo.TipoVehiculo = resultado.TipoVehiculo;
                        objVehiculo.Cantidad = Convert.ToInt32(resultado.Cantidad);
                        objListaVehiculo.Add(objVehiculo);
                    }

                    return objListaVehiculo;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cargar los vehículos: " + ex.Message);
            }
        }
    }
}