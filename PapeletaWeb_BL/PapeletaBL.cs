using PapeletaWeb_ADO;
using PapeletaWeb_BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapeletaWeb_BL
{
    public class PapeletaBL
    {
        PapeletaADO objPapeletaADO = new PapeletaADO();

        public List<MultaBE> ListarMultasPorInfractor(string cod, DateTime ini, DateTime fin)
            => objPapeletaADO.ListarMultasPorInfractor(cod, ini, fin);

        public List<MultaBE> ListarMultasPorVehiculo(string cod, DateTime ini, DateTime fin)
            => objPapeletaADO.ListarMultasPorVehiculo(cod, ini, fin);

        public List<MultaBE> ListarMultasPorPolicia(string cod, DateTime ini, DateTime fin)
            => objPapeletaADO.ListarMultasPorPolicia(cod, ini, fin);
    }
}
