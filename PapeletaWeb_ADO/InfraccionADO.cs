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
        public List<InfraccionBE> BuscarInfracciones(string strFiltro,
                                             int pagina,
                                             int registrosPorPagina)
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

                    return query
    .OrderBy(x => x.Cod_Infraccion)
    .Skip((pagina - 1) * registrosPorPagina)
    .Take(registrosPorPagina)
    .ToList();
                }
            }
            catch (EntityException ex) { throw new Exception(ex.Message); }
        }

        public int ContarInfracciones(string strFiltro)
        {
            try
            {
                using (PAPELETAEntities Papeleta = new PAPELETAEntities())
                {
                    var query = from i in Papeleta.TB_INFRACCION
                                select i;

                    if (!string.IsNullOrWhiteSpace(strFiltro))
                    {
                        query = query.Where(x =>
                            x.COD_INFRACCION.Contains(strFiltro) ||
                            x.DESCRIPCION_SANCION.Contains(strFiltro) ||
                            x.CALIFICACION.Contains(strFiltro));
                    }

                    return query.Count();
                }
            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<InfraccionBE> ListarInfracciones(int pagina,
                                             int registrosPorPagina)
        {
            return BuscarInfracciones(null, pagina, registrosPorPagina);
        }

        public bool InsertarInfraccion(InfraccionBE obj)
        {
            try
            {
                using (PAPELETAEntities Papeleta = new PAPELETAEntities())
                {
                    Papeleta.SP_INSERTAR_INFRACCION(
                        obj.Descripcion_Sancion,
                        obj.Calificacion,
                        obj.Puntos,
                        obj.Uit,
                        "A",
                        obj.Medida_Preventiva,
                        "ADMIN"
                    );
                    return true;
                }
            }
            catch (Exception) { throw; }
        }

        public bool EliminarInfraccion(string codigo)
        {
            try
            {
                using (PAPELETAEntities Papeleta = new PAPELETAEntities())
                {
                    Papeleta.SP_ELIMINAR_INFRACCION(codigo, "ADMIN");
                    return true;
                }
            }
            catch (Exception) { throw; }
        }

        public InfraccionBE ObtenerInfraccion(string codigo)
        {
            using (PAPELETAEntities Papeleta = new PAPELETAEntities())
            {
                return (from i in Papeleta.TB_INFRACCION
                        where i.COD_INFRACCION == codigo
                        select new InfraccionBE
                        {
                            Cod_Infraccion = i.COD_INFRACCION,
                            Descripcion_Sancion = i.DESCRIPCION_SANCION,
                            Calificacion = i.CALIFICACION,
                            Puntos = (int)i.PUNTOS,
                            Uit = (decimal)i.UIT,
                            Medida_Preventiva = i.MEDIDA_PREVENTIVA,
                            Estado = i.ESTADO
                        }).FirstOrDefault();
            }
        }

        public bool ActualizarInfraccion(InfraccionBE obj)
        {
            try
            {
                using (PAPELETAEntities Papeleta = new PAPELETAEntities())
                {
                    TB_INFRACCION infraccion =
                        Papeleta.TB_INFRACCION.FirstOrDefault(x =>
                            x.COD_INFRACCION == obj.Cod_Infraccion);

                    infraccion.DESCRIPCION_SANCION = obj.Descripcion_Sancion;
                    infraccion.CALIFICACION = obj.Calificacion;
                    infraccion.PUNTOS = obj.Puntos;
                    infraccion.UIT = obj.Uit;
                    infraccion.MEDIDA_PREVENTIVA = obj.Medida_Preventiva;
                    infraccion.ESTADO = "A";
                    infraccion.FEC_ULT_MODIFICACION = DateTime.Now;
                    infraccion.USU_ULT_MODIFICACION = "ADMIN";

                    Papeleta.SaveChanges();

                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
