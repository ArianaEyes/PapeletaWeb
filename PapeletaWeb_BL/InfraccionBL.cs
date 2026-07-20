using PapeletaWeb_ADO;
using PapeletaWeb_BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapeletaWeb_BL
{
    public class InfraccionBL
    {
        InfraccionADO objInfraccionADO = new InfraccionADO();

        public List<InfraccionBE> BuscarInfracciones(string filtro) => objInfraccionADO.BuscarInfracciones(filtro);
        public List<InfraccionBE> ListarInfracciones() => objInfraccionADO.ListarInfracciones();
    }
}
