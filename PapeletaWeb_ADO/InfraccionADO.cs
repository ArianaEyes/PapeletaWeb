using PapeletaWeb_BE;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapeletaWeb_ADO
{
    public class InfraccionADO
    {
        public List<InfraccionBE> BuscarInfracciones(string strFiltro)
        {
            try
            {
                using (PAPELETAEntities Papeleta = new PAPELETAEntities())
                {
                    var query = from i in Papeleta.TB_INFRACCION
                                select new InfraccionBE
                                {
                                    Cod_Infraccion = i.COD_INFRACCION,
                                    Descripcion_Sancion = i.DESCRIPCION_SANCION,
                                    Calificacion = i.CALIFICACION,
                                    Puntos = (int)i.PUNTOS,
                                    Uit = (decimal)i.UIT
                                };

                    if (!string.IsNullOrWhiteSpace(strFiltro))
                    {
                        query = query.Where(x =>
                            x.Cod_Infraccion.Contains(strFiltro) ||
                            x.Descripcion_Sancion.Contains(strFiltro) ||
                            x.Calificacion.Contains(strFiltro));
                    }

                    return query.OrderBy(x => x.Cod_Infraccion).ToList();
                }
            }
            catch (EntityException ex) { throw new Exception(ex.Message); }
        }

        public List<InfraccionBE> ListarInfracciones() => BuscarInfracciones(null);
    }
}
