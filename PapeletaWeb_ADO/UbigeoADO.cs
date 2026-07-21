using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using PapeletaWeb_BE;

namespace PapeletaWeb_ADO
{
    public class UbigeoADO
    {
        public List<UbigeoBE> ListarDepartamentos()
        {
            try
            {
                using (PAPELETAEntities db = new PAPELETAEntities())
                {
                    return db.TB_UBIGEO
                        .GroupBy(x => new
                        {
                            x.ID_DEPA,
                            x.DEPARTAMENTO
                        })
                        .Select(x => new UbigeoBE
                        {
                            Id_Depa = x.Key.ID_DEPA,
                            Departamento = x.Key.DEPARTAMENTO
                        })
                        .OrderBy(x => x.Departamento)
                        .ToList();
                }
            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<UbigeoBE> ListarProvincias(string idDepa)
        {
            try
            {
                using (PAPELETAEntities db = new PAPELETAEntities())
                {
                    return db.TB_UBIGEO
                        .Where(x => x.ID_DEPA == idDepa)
                        .GroupBy(x => new
                        {
                            x.ID_PROV,
                            x.PROVINCIA
                        })
                        .Select(x => new UbigeoBE
                        {
                            Id_Prov = x.Key.ID_PROV,
                            Provincia = x.Key.PROVINCIA
                        })
                        .OrderBy(x => x.Provincia)
                        .ToList();
                }
            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<UbigeoBE> ListarDistritos(string idDepa, string idProv)
        {
            try
            {
                using (PAPELETAEntities db = new PAPELETAEntities())
                {
                    return db.TB_UBIGEO
                        .Where(x => x.ID_DEPA == idDepa &&
                                    x.ID_PROV == idProv)
                        .Select(x => new UbigeoBE
                        {
                            Cod_Ubigeo = x.COD_UBIGEO,
                            Id_Dist = x.ID_DIST,
                            Distrito = x.DISTRITO
                        })
                        .OrderBy(x => x.Distrito)
                        .ToList();
                }
            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
