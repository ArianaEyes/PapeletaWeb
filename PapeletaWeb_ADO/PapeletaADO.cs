using PapeletaWeb_BE;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapeletaWeb_ADO
{
    public class PapeletaADO
    {
        private IQueryable<MultaBE> ConsultaBase(PAPELETAEntities Papeleta)
        {
            return from p in Papeleta.TB_PAPELETA
                   join i in Papeleta.TB_INFRACCION on p.COD_INFRACCION equals i.COD_INFRACCION
                   join po in Papeleta.TB_POLICIA on p.COD_POLICIA equals po.COD_POLICIA
                   join v in Papeleta.TB_VEHICULO on p.COD_VEHICULO equals v.COD_VEHICULO
                   join inf in Papeleta.TB_INFRACTOR on v.COD_INFRACTOR equals inf.COD_INFRACTOR
                   select new MultaBE
                   {
                       Cod_Papeleta = p.COD_PAPELETA,
                       Cod_Infractor = inf.COD_INFRACTOR,
                       Infractor = inf.NOMBRES + " " + inf.APE_PATERNO + " " + inf.APE_MATERNO,
                       Lugar_Infraccion = p.LUGAR_INFRACCION,
                       Falta_Cometida = i.DESCRIPCION_SANCION,
                       Calificacion = i.CALIFICACION,
                       Uit = (decimal)i.UIT,
                       Fecha_Infraccion = p.FECHA_INFRACCION,
                       Policia = po.NOMBRE + " " + po.PATERNO + " " + po.MATERNO,
                       Estado_Papeleta = p.ESTADO_PAPELETA == "A" ? "PENDIENTE" : "CANCELADO"
                   };
        }

        public List<MultaBE> ListarMultasPorInfractor(string codInfractor, DateTime fecIni, DateTime fecFin)
        {
            try
            {
                using (PAPELETAEntities Papeleta = new PAPELETAEntities())
                {
                    return ConsultaBase(Papeleta)
                        .Where(m => m.Cod_Infractor == codInfractor
                                 && m.Fecha_Infraccion >= fecIni
                                 && m.Fecha_Infraccion <= fecFin)
                        .OrderBy(m => m.Fecha_Infraccion)
                        .ToList();
                }
            }
            catch (EntityException ex) { throw new Exception(ex.Message); }
        }

        public List<MultaBE> ListarMultasPorVehiculo(string codVehiculo, DateTime fecIni, DateTime fecFin)
        {
            try
            {
                using (PAPELETAEntities Papeleta = new PAPELETAEntities())
                {
                    return (from p in Papeleta.TB_PAPELETA
                            join i in Papeleta.TB_INFRACCION on p.COD_INFRACCION equals i.COD_INFRACCION
                            join po in Papeleta.TB_POLICIA on p.COD_POLICIA equals po.COD_POLICIA
                            join v in Papeleta.TB_VEHICULO on p.COD_VEHICULO equals v.COD_VEHICULO
                            join inf in Papeleta.TB_INFRACTOR on v.COD_INFRACTOR equals inf.COD_INFRACTOR
                            where v.COD_VEHICULO == codVehiculo
                               && p.FECHA_INFRACCION >= fecIni
                               && p.FECHA_INFRACCION <= fecFin
                            orderby p.FECHA_INFRACCION
                            select new MultaBE
                            {
                                Cod_Papeleta = p.COD_PAPELETA,
                                Cod_Infractor = inf.COD_INFRACTOR,
                                Infractor = inf.NOMBRES + " " + inf.APE_PATERNO + " " + inf.APE_MATERNO,
                                Lugar_Infraccion = p.LUGAR_INFRACCION,
                                Falta_Cometida = i.DESCRIPCION_SANCION,
                                Calificacion = i.CALIFICACION,
                                Uit = (decimal)i.UIT,
                                Fecha_Infraccion = p.FECHA_INFRACCION,
                                Policia = po.NOMBRE + " " + po.PATERNO + " " + po.MATERNO,
                                Estado_Papeleta = p.ESTADO_PAPELETA == "A" ? "PENDIENTE" : "CANCELADO"
                            }).ToList();
                }
            }
            catch (EntityException ex) { throw new Exception(ex.Message); }
        }

        public decimal CalcularUitPendiente(string codInfractor, DateTime fecIni, DateTime fecFin)
        {
            try
            {
                using (PAPELETAEntities Papeleta = new PAPELETAEntities())
                {
                    var total = (from p in Papeleta.TB_PAPELETA
                                 join i in Papeleta.TB_INFRACCION on p.COD_INFRACCION equals i.COD_INFRACCION
                                 join v in Papeleta.TB_VEHICULO on p.COD_VEHICULO equals v.COD_VEHICULO
                                 where v.COD_INFRACTOR == codInfractor
                                    && p.FECHA_INFRACCION >= fecIni && p.FECHA_INFRACCION <= fecFin
                                    && p.ESTADO_PAPELETA == "A" // Pendiente
                                 select (decimal?)i.UIT).Sum() ?? 0m;
                    return total;
                }
            }
            catch (EntityException ex) { throw new Exception(ex.Message); }
        }

        public (int pendientes, int canceladas) ContarPorEstado(string codVehiculo, DateTime fecIni, DateTime fecFin)
        {
            try
            {
                using (PAPELETAEntities Papeleta = new PAPELETAEntities())
                {
                    var query = Papeleta.TB_PAPELETA
                        .Where(p => p.COD_VEHICULO == codVehiculo
                                 && p.FECHA_INFRACCION >= fecIni && p.FECHA_INFRACCION <= fecFin);

                    int pend = query.Count(p => p.ESTADO_PAPELETA == "A");
                    int canc = query.Count(p => p.ESTADO_PAPELETA == "C");
                    return (pend, canc);
                }
            }
            catch (EntityException ex) { throw new Exception(ex.Message); }
        }

        public string ObtenerFaltaMasFrecuente(string codPolicia, DateTime fecIni, DateTime fecFin)
        {
            try
            {
                using (PAPELETAEntities Papeleta = new PAPELETAEntities())
                {
                    var top = (from p in Papeleta.TB_PAPELETA
                               join i in Papeleta.TB_INFRACCION on p.COD_INFRACCION equals i.COD_INFRACCION
                               where p.COD_POLICIA == codPolicia
                                  && p.FECHA_INFRACCION >= fecIni && p.FECHA_INFRACCION <= fecFin
                               group i by i.DESCRIPCION_SANCION into g
                               orderby g.Count() descending
                               select new { Falta = g.Key, Cantidad = g.Count() })
                               .FirstOrDefault();

                    return top == null ? "Sin registros" : $"{top.Falta} ({top.Cantidad} veces)";
                }
            }
            catch (EntityException ex) { throw new Exception(ex.Message); }
        }

        public List<MultaBE> ListarMultasPorPolicia(string codPolicia, DateTime fecIni, DateTime fecFin)
        {
            try
            {
                using (PAPELETAEntities Papeleta = new PAPELETAEntities())
                {
                    return (from p in Papeleta.TB_PAPELETA
                            join i in Papeleta.TB_INFRACCION on p.COD_INFRACCION equals i.COD_INFRACCION
                            join po in Papeleta.TB_POLICIA on p.COD_POLICIA equals po.COD_POLICIA
                            join v in Papeleta.TB_VEHICULO on p.COD_VEHICULO equals v.COD_VEHICULO
                            join inf in Papeleta.TB_INFRACTOR on v.COD_INFRACTOR equals inf.COD_INFRACTOR
                            where po.COD_POLICIA == codPolicia
                               && p.FECHA_INFRACCION >= fecIni
                               && p.FECHA_INFRACCION <= fecFin
                            orderby p.FECHA_INFRACCION
                            select new MultaBE
                            {
                                Cod_Papeleta = p.COD_PAPELETA,
                                Cod_Infractor = inf.COD_INFRACTOR,
                                Infractor = inf.NOMBRES + " " + inf.APE_PATERNO + " " + inf.APE_MATERNO,
                                Lugar_Infraccion = p.LUGAR_INFRACCION,
                                Falta_Cometida = i.DESCRIPCION_SANCION,
                                Calificacion = i.CALIFICACION,
                                Uit = (decimal)i.UIT,
                                Fecha_Infraccion = p.FECHA_INFRACCION,
                                Policia = po.NOMBRE + " " + po.PATERNO + " " + po.MATERNO,
                                Estado_Papeleta = p.ESTADO_PAPELETA == "A" ? "PENDIENTE" : "CANCELADO"
                            }).ToList();
                }
            }
            catch (EntityException ex) { throw new Exception(ex.Message); }
        }
    }
}
