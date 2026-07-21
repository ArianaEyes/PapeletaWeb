using PapeletaWeb_ADO;
using PapeletaWeb_BE;
using System.Collections.Generic;

namespace PapeletaWeb_BL
{
    public class InfraccionBL
    {
        InfraccionADO objInfraccionADO = new InfraccionADO();

        public List<InfraccionBE> ListarInfracciones(int pagina,
                                                     int registrosPorPagina)
        {
            return objInfraccionADO.ListarInfracciones(pagina, registrosPorPagina);
        }

        public List<InfraccionBE> BuscarInfracciones(string filtro,
                                                     int pagina,
                                                     int registrosPorPagina)
        {
            return objInfraccionADO.BuscarInfracciones(filtro,
                                                       pagina,
                                                       registrosPorPagina);
        }

        public int ContarInfracciones(string filtro)
        {
            return objInfraccionADO.ContarInfracciones(filtro);
        }
    }
}
