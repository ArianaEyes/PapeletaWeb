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

        public bool EliminarPolicia(string codigo, string usuario)
        {
            return objPoliciaADO.EliminarPolicia(codigo, usuario);
        }

        public PoliciaBE ConsultarPolicia(string codigo)
        {
            return objPoliciaADO.ConsultarPolicia(codigo);
        }

        public bool InsertarPolicia(PoliciaBE objPoliciaBE)
        {
            return objPoliciaADO.InsertarPolicia(objPoliciaBE);
        }

        public bool ActualizarPolicia(PoliciaBE objPoliciaBE)
        {
            return objPoliciaADO.ActualizarPolicia(objPoliciaBE);
        }
    }
}
