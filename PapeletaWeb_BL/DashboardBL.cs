using System;
using System.Collections.Generic;
using PapeletaWeb_BE;
using PapeletaWeb_ADO;

namespace PapeletaWeb_BL
{
    public class DashboardBL
    {
        DashboardADO objADO = new DashboardADO();

        public DashboardBE ObtenerTotales()
        {
            return objADO.ObtenerTotales();
        }

        public List<PapeletaAnualBE> ObtenerPapeletasPorAño()
        {
            return objADO.ObtenerPapeletasPorAño();
        }

        public List<TopInfraccionBE> ObtenerTopInfracciones()
        {
            return objADO.ObtenerTopInfracciones();
        }
        public List<PapeletaMesBE> ObtenerPapeletasPorMes()
        {
            return objADO.ObtenerPapeletasPorMes();
        }

        public List<PapeletaVehiculoBE> ObtenerInfraccionesPorVehiculo()
        {
            return objADO.ObtenerInfraccionesPorVehiculo();
        }
    }
}