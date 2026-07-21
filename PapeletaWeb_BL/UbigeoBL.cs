using System.Collections.Generic;
using PapeletaWeb_ADO;
using PapeletaWeb_BE;

namespace PapeletaWeb_BL
{
    public class UbigeoBL
    {
        UbigeoADO objADO = new UbigeoADO();

        public List<UbigeoBE> ListarDepartamentos()
        {
            return objADO.ListarDepartamentos();
        }

        public List<UbigeoBE> ListarProvincias(string idDepa)
        {
            return objADO.ListarProvincias(idDepa);
        }

        public List<UbigeoBE> ListarDistritos(string idDepa,
                                              string idProv)
        {
            return objADO.ListarDistritos(idDepa,
                                          idProv);
        }
    }
}