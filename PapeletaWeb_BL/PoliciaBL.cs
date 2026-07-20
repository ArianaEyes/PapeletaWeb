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

        public List<PoliciaBE> BuscarPolicias(string filtro) => objPoliciaADO.BuscarPolicias(filtro);
        public List<PoliciaBE> ListarPolicias() => objPoliciaADO.ListarPolicias();
    }
}
