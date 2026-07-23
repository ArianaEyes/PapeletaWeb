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

        public List<MultaBE> BuscarPapeletas(string strFiltro, int pagina, int registrosPorPagina)
        {
            try
            {
                using (PAPELETAEntities Papeleta = new PAPELETAEntities())
                {
                    var query = ConsultaBase(Papeleta);

                    if (!string.IsNullOrWhiteSpace(strFiltro))
                    {
                        query = query.Where(m =>
                            m.Cod_Papeleta.Contains(strFiltro) ||
                            m.Infractor.Contains(strFiltro) ||
                            m.Lugar_Infraccion.Contains(strFiltro) ||
                            m.Policia.Contains(strFiltro) ||
                            m.Estado_Papeleta.Contains(strFiltro));
                    }

                    return query
                            .OrderByDescending(m => m.Fecha_Infraccion)
                            .Skip((pagina - 1) * registrosPorPagina)
                            .Take(registrosPorPagina)
                            .ToList();
                }
            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<MultaBE> ListarPapeletas(int pagina, int registrosPorPagina)
        {
            return BuscarPapeletas(null, pagina, registrosPorPagina);
        }

        public int ContarPapeletas(string strFiltro)
        {
            try
            {
                using (PAPELETAEntities Papeleta = new PAPELETAEntities())
                {
                    var query = ConsultaBase(Papeleta);

                    if (!string.IsNullOrWhiteSpace(strFiltro))
                    {
                        query = query.Where(m =>
                            m.Cod_Papeleta.Contains(strFiltro) ||
                            m.Infractor.Contains(strFiltro) ||
                            m.Lugar_Infraccion.Contains(strFiltro) ||
                            m.Policia.Contains(strFiltro) ||
                            m.Estado_Papeleta.Contains(strFiltro));
                    }

                    return query.Count();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "Ocurrió un problema: " +
                    ex.Message
                );
            }
        }

        public PapeletaBE ConsultarPapeleta(string codigo)
        {
            try
            {
                using (PAPELETAEntities Papeleta = new PAPELETAEntities())
                {
                    var p = Papeleta.TB_PAPELETA
                        .FirstOrDefault(x =>
                            x.COD_PAPELETA == codigo);

                    if (p == null)
                        return null;


                    return new PapeletaBE
                    {
                        Cod_Papeleta = p.COD_PAPELETA,
                        Cod_Infraccion = p.COD_INFRACCION,
                        Cod_Policia = p.COD_POLICIA,
                        Cod_Vehiculo = p.COD_VEHICULO,
                        Fecha_Infraccion = p.FECHA_INFRACCION,
                        Hora_Infraccion = p.HORA_INFRACCION,
                        Lugar_Infraccion = p.LUGAR_INFRACCION,
                        Referencia = p.REFERENCIA,
                        Info_Adicional = p.INFO_ADICIONAL,
                        Observaciones = p.OBSERVACIONES,
                        Estado_Papeleta = p.ESTADO_PAPELETA
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool ActualizarPapeleta(PapeletaBE obj)
        {
            try
            {
                using (PAPELETAEntities Papeleta = new PAPELETAEntities())
                {

                    var papeleta =
                        Papeleta.TB_PAPELETA
                        .FirstOrDefault(x =>
                            x.COD_PAPELETA == obj.Cod_Papeleta);


                    if (papeleta == null)
                        return false;


                    papeleta.LUGAR_INFRACCION =
                        obj.Lugar_Infraccion;


                    papeleta.INFO_ADICIONAL =
                        obj.Info_Adicional;


                    papeleta.OBSERVACIONES =
                        obj.Observaciones;


                    papeleta.FEC_ULT_MODIFICACION =
                        DateTime.Now;


                    papeleta.USU_ULT_MODIFICACION =
                        obj.Usu_Ult_Modificacion;


                    Papeleta.SaveChanges();


                    return true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool EliminarPapeleta(string codigo)
        {
            try
            {
                using (PAPELETAEntities Papeleta = new PAPELETAEntities())
                {

                    var papeleta =
                        Papeleta.TB_PAPELETA
                        .FirstOrDefault(x =>
                            x.COD_PAPELETA == codigo);


                    if (papeleta == null)
                        return false;


                    Papeleta.TB_PAPELETA.Remove(papeleta);

                    Papeleta.SaveChanges();


                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        //PARTE TRANSACCIONES
        public string InsertarPapeleta(PapeletaBE objPapeleta)
        {
            try
            {
                using (PAPELETAEntities Papeleta = new PAPELETAEntities())
                {
                    string nuevoCodigo =
                        GenerarCodigoPapeleta(Papeleta);

                    TB_PAPELETA nuevaPapeleta =
                        new TB_PAPELETA
                        {
                            COD_PAPELETA =
                                nuevoCodigo,

                            COD_INFRACCION =
                                objPapeleta.Cod_Infraccion,

                            COD_POLICIA =
                                objPapeleta.Cod_Policia,

                            COD_VEHICULO =
                                objPapeleta.Cod_Vehiculo,

                            FECHA_INFRACCION =
                                objPapeleta.Fecha_Infraccion,

                            HORA_INFRACCION =
                                objPapeleta.Hora_Infraccion,

                            LUGAR_INFRACCION =
                                objPapeleta.Lugar_Infraccion,

                            REFERENCIA =
                                objPapeleta.Referencia,

                            INFO_ADICIONAL =
                                objPapeleta.Info_Adicional,

                            OBSERVACIONES =
                                objPapeleta.Observaciones,

                            // A = pendiente en tu proyecto
                            ESTADO_PAPELETA = "A",

                            FEC_REGISTRO =
                                DateTime.Now,

                            USU_REGISTRO =
                                objPapeleta.Usu_Registro,

                            FEC_ULT_MODIFICACION =
                                null,

                            USU_ULT_MODIFICACION =
                                null
                        };

                    Papeleta.TB_PAPELETA.Add(
                        nuevaPapeleta
                    );

                    Papeleta.SaveChanges();

                    return nuevoCodigo;
                }
            }
            catch (EntityException ex)
            {
                throw new Exception(
                    "Error de conexión al registrar la papeleta: " +
                    ex.Message
                );
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "No se pudo registrar la papeleta: " +
                    ex.Message
                );
            }
        }

        private string GenerarCodigoPapeleta(
    PAPELETAEntities Papeleta)
        {
            List<string> codigos =
                Papeleta.TB_PAPELETA
                    .Where(p =>
                        p.COD_PAPELETA.StartsWith("PA"))
                    .Select(
                        p => p.COD_PAPELETA
                    )
                    .ToList();

            int ultimoNumero = 0;

            foreach (string codigo in codigos)
            {
                if (string.IsNullOrWhiteSpace(codigo) ||
                    codigo.Length != 6)
                {
                    continue;
                }

                string parteNumerica =
                    codigo.Substring(2);

                int numero;

                if (int.TryParse(
                    parteNumerica,
                    out numero) &&
                    numero > ultimoNumero)
                {
                    ultimoNumero = numero;
                }
            }

            int nuevoNumero =
                ultimoNumero + 1;

            if (nuevoNumero > 9999)
            {
                throw new Exception(
                    "Se alcanzó el límite de códigos de papeleta."
                );
            }

            return "PA" +
                nuevoNumero.ToString("D4");
        }
    }
}
