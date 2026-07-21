using PapeletaWeb_ADO;
using PapeletaWeb_BE;
using System.Collections.Generic;

namespace PapeletaWeb_BL
{
    public class RangoBL
    {
        RangoADO objRangoADO = new RangoADO();

        public List<RangoBE> ListarRangos()
        {
            return objRangoADO.ListarRangos();
        }
    }
}