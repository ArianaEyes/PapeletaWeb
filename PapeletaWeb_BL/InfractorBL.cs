using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PapeletaWeb_ADO;
using PapeletaWeb_BE;

namespace PapeletaWeb_BL
{
    public class InfractorBL
    {
        InfractorADO objInfractorADO = new InfractorADO();

        public InfractorBE ConsultarInfractor(string strCodigo)
        {
            return objInfractorADO.ConsultarInfractor(strCodigo);
        }

        public List<InfractorBE> ListarInfractores(int pagina,
                                           int registrosPorPagina)
        {
            return objInfractorADO.ListarInfractores(pagina, registrosPorPagina);
        }

        public List<InfractorBE> BuscarInfractores(string filtro,
                                                   int pagina,
                                                   int registrosPorPagina)
        {
            return objInfractorADO.BuscarInfractores(filtro,
                                                     pagina,
                                                     registrosPorPagina);
        }

        public int ContarInfractores(string filtro)
        {
            return objInfractorADO.ContarInfractores(filtro);
        }
    }
}
