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

        public List<VehiculoBE> ListarVehiculos(int pagina, int registrosPorPagina)
        {
            return objVehiculoADO.ListarVehiculos(pagina, registrosPorPagina);
        }

        public List<VehiculoBE> BuscarVehiculos(string filtro,
                                                int pagina,
                                                int registrosPorPagina)
        {
            return objVehiculoADO.BuscarVehiculos(filtro,
                                                  pagina,
                                                  registrosPorPagina);
        }

        public int ContarVehiculos(string filtro)
        {
            return objVehiculoADO.ContarVehiculos(filtro);
        }
    }
}
