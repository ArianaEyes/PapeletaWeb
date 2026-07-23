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

        public List<MarcaBE> ListarMarcas()
        {
            using (PAPELETAEntities Papeleta = new PAPELETAEntities())
            {
                return Papeleta.TB_MARCA
                    .Select(m => new MarcaBE { Cod_Marca = m.COD_MARCA, Marca = m.MARCA })
                    .OrderBy(m => m.Marca)
                    .ToList();
            }
        }

        public List<ColorBE> ListarColores()
        {
            using (PAPELETAEntities Papeleta = new PAPELETAEntities())
            {
                return Papeleta.TB_COLOR
                    .Select(c => new ColorBE { Cod_Color = c.COD_COLOR, Color = c.COLOR })
                    .OrderBy(c => c.Color)
                    .ToList();
            }
        }

        public List<TipoVehiculoBE> ListarTiposVehiculo()
        {
            using (PAPELETAEntities Papeleta = new PAPELETAEntities())
            {
                return Papeleta.TB_TIPO_VEHICULO
                    .Select(t => new TipoVehiculoBE { Cod_Tipo = t.COD_TIPO_VEHICULO.ToString(), Descripcion = t.DESCRIPCION_TIPO_VEHICULO })
                    .OrderBy(t => t.Descripcion)
                    .ToList();
            }
        }

        public bool InsertarVehiculo(VehiculoBE obj)
        {
            try
            {
                using (PAPELETAEntities Papeleta = new PAPELETAEntities())
                {
                    Papeleta.SP_INSERTAR_VEHICULO(
                        obj.Cod_Infractor,
                        obj.Cod_Marca,
                        obj.Cod_Color,
                        obj.Tipo_Vehiculo,
                        obj.Anio_Fabricacion,
                        obj.Nro_Motor,
                        "A",
                        null,
                        "ADMIN",
                        "ADMIN"
                    );
                    return true;
                }
            }
            catch (Exception) { throw; }
        }

        public VehiculoBE ObtenerVehiculo(string codigo)
        {
            using (PAPELETAEntities Papeleta = new PAPELETAEntities())
            {
                var vehiculo = (from v in Papeleta.TB_VEHICULO
                                where v.COD_VEHICULO == codigo
                                select new VehiculoBE
                                {
                                    Cod_Vehiculo = v.COD_VEHICULO,
                                    Cod_Infractor = v.COD_INFRACTOR,
                                    Cod_Marca = v.COD_MARCA,
                                    Cod_Color = v.COD_COLOR,
                                    Tipo_Vehiculo = v.COD_TIPO_VEHICULO.HasValue ? v.COD_TIPO_VEHICULO.Value.ToString() : "",
                                    Anio_Fabricacion = (int)v.ANIO_FABRICACION,
                                    Nro_Motor = v.NRO_MOTOR
                                }).FirstOrDefault();

                return vehiculo;
            }
        }

        public bool ActualizarVehiculo(VehiculoBE obj)
        {
            using (PAPELETAEntities Papeleta = new PAPELETAEntities())
            {
                var vehiculo = Papeleta.TB_VEHICULO
                    .FirstOrDefault(v => v.COD_VEHICULO == obj.Cod_Vehiculo);

                if (vehiculo == null)
                    return false;

                vehiculo.COD_INFRACTOR = obj.Cod_Infractor;
                vehiculo.COD_MARCA = obj.Cod_Marca;
                vehiculo.COD_COLOR = obj.Cod_Color;
                vehiculo.COD_TIPO_VEHICULO = Convert.ToInt32(obj.Tipo_Vehiculo);
                vehiculo.ANIO_FABRICACION = obj.Anio_Fabricacion;
                vehiculo.NRO_MOTOR = obj.Nro_Motor;
                vehiculo.ESTADO = "A";
                vehiculo.USU_ULT_MODIFICACION = "ADMIN";
                vehiculo.FEC_ULT_MODIFICACION = DateTime.Now;

                Papeleta.SaveChanges();

                return true;
            }
        }

        public bool EliminarVehiculo(string codigo)
        {
            using (PAPELETAEntities Papeleta = new PAPELETAEntities())
            {
                var vehiculo = Papeleta.TB_VEHICULO
                    .FirstOrDefault(v => v.COD_VEHICULO == codigo);

                if (vehiculo == null)
                    return false;

                vehiculo.ESTADO = "I";
                vehiculo.USU_ULT_MODIFICACION = "ADMIN";
                vehiculo.FEC_ULT_MODIFICACION = DateTime.Now;

                Papeleta.SaveChanges();

                return true;
            }
        }
    }
}