using PapeletaWeb_ADO;
using PapeletaWeb_BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapeletaWeb_BL
{
    public class VehiculoBL
    {
        VehiculoADO objVehiculoADO = new VehiculoADO();

        public List<VehiculoBE> BuscarVehiculos(string filtro) => objVehiculoADO.BuscarVehiculos(filtro);
        public List<VehiculoBE> ListarVehiculos() => objVehiculoADO.ListarVehiculos();
    }
}
