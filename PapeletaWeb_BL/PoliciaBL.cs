using PapeletaWeb_ADO;
using PapeletaWeb_BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapeletaWeb_BL
{
    public class PoliciaBL
    {
        PoliciaADO objPoliciaADO = new PoliciaADO();

        public List<PoliciaBE> ListarPolicias(int pagina, int registrosPorPagina)
        {
            return objPoliciaADO.ListarPolicias(pagina, registrosPorPagina);
        }

        public List<PoliciaBE> BuscarPolicias(string filtro,
                                              int pagina,
                                              int registrosPorPagina)
        {
            return objPoliciaADO.BuscarPolicias(filtro,
                                                pagina,
                                                registrosPorPagina);
        }

        public int ContarPolicias(string filtro)
        {
            return objPoliciaADO.ContarPolicias(filtro);
        }
    }
}
