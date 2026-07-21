using PapeletaWeb_BE;
using System.Collections.Generic;
using System.Linq;

namespace PapeletaWeb_ADO
{
    public class RangoADO
    {
        PAPELETAEntities miDB = new PAPELETAEntities();

        public List<RangoBE> ListarRangos()
        {
            return miDB.TB_RANGO
                .OrderBy(x => x.COD_RANGO)
                .Select(x => new RangoBE
                {
                    Cod_Rango = x.COD_RANGO,
                    Descripcion = x.DESCRIPCION_RANGO
                })
                .ToList();
        }
    }
}