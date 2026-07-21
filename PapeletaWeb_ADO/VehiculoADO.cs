using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using PapeletaWeb_BE;

namespace PapeletaWeb_ADO
{
    public class VehiculoADO
    {
        public List<VehiculoBE> BuscarVehiculos(string strFiltro,
                                        int pagina,
                                        int registrosPorPagina)
        {
            try
            {
                using (PAPELETAEntities Papeleta = new PAPELETAEntities())
                {
                    var query = from v in Papeleta.TB_VEHICULO
                                join i in Papeleta.TB_INFRACTOR on v.COD_INFRACTOR equals i.COD_INFRACTOR
                                join m in Papeleta.TB_MARCA on v.COD_MARCA equals m.COD_MARCA
                                join c in Papeleta.TB_COLOR on v.COD_COLOR equals c.COD_COLOR
                                join tv in Papeleta.TB_TIPO_VEHICULO on v.COD_TIPO_VEHICULO equals tv.COD_TIPO_VEHICULO
                                select new VehiculoBE
                                {
                                    Cod_Vehiculo = v.COD_VEHICULO,
                                    Cod_Infractor = i.COD_INFRACTOR,
                                    Dni = i.DNI,
                                    Infractor = i.NOMBRES + " " + i.APE_PATERNO + " " + i.APE_MATERNO,
                                    Cod_Marca = m.COD_MARCA,
                                    Marca = m.MARCA,
                                    Cod_Color = c.COD_COLOR,
                                    Color = c.COLOR,
                                    Tipo_Vehiculo = tv.DESCRIPCION_TIPO_VEHICULO,
                                    Anio_Fabricacion = (int)v.ANIO_FABRICACION,
                                    Nro_Motor = v.NRO_MOTOR,
                                    Foto = v.FOTO,
                                    Fec_Registro = (DateTime)v.FEC_REGISTRO,
                                    EstadoTexto = v.ESTADO == "A" ? "Activo" : "Inactivo"
                                };

                    if (!string.IsNullOrWhiteSpace(strFiltro))
                    {
                        query = query.Where(x =>
                            x.Cod_Vehiculo.Contains(strFiltro) ||
                            x.Dni.Contains(strFiltro) ||
                            x.Infractor.Contains(strFiltro) ||
                            x.Marca.Contains(strFiltro));
                    }

                    return query
    .OrderBy(x => x.Cod_Vehiculo)
    .Skip((pagina - 1) * registrosPorPagina)
    .Take(registrosPorPagina)
    .ToList();
                }
            }
            catch (EntityException ex) { throw new Exception(ex.Message); }
        }

        public int ContarVehiculos(string strFiltro)
        {
            try
            {
                using (PAPELETAEntities Papeleta = new PAPELETAEntities())
                {
                    var query = from v in Papeleta.TB_VEHICULO
                                join i in Papeleta.TB_INFRACTOR on v.COD_INFRACTOR equals i.COD_INFRACTOR
                                join m in Papeleta.TB_MARCA on v.COD_MARCA equals m.COD_MARCA
                                join c in Papeleta.TB_COLOR on v.COD_COLOR equals c.COD_COLOR
                                join tv in Papeleta.TB_TIPO_VEHICULO on v.COD_TIPO_VEHICULO equals tv.COD_TIPO_VEHICULO
                                select new VehiculoBE
                                {
                                    Cod_Vehiculo = v.COD_VEHICULO,
                                    Dni = i.DNI,
                                    Infractor = i.NOMBRES + " " + i.APE_PATERNO + " " + i.APE_MATERNO,
                                    Marca = m.MARCA
                                };

                    if (!string.IsNullOrWhiteSpace(strFiltro))
                    {
                        query = query.Where(x =>
                            x.Cod_Vehiculo.Contains(strFiltro) ||
                            x.Dni.Contains(strFiltro) ||
                            x.Infractor.Contains(strFiltro) ||
                            x.Marca.Contains(strFiltro));
                    }

                    return query.Count();
                }
            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<VehiculoBE> ListarVehiculos(int pagina,
                                        int registrosPorPagina)
        {
            return BuscarVehiculos(null, pagina, registrosPorPagina);
        }
    }
}