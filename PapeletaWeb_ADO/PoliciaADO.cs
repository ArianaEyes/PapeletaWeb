using PapeletaWeb_BE;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapeletaWeb_ADO
{
    public class PoliciaADO
    {
        public List<PoliciaBE> BuscarPolicias(string strFiltro,
                                      int pagina,
                                      int registrosPorPagina)
        {
            try
            {
                using (PAPELETAEntities Papeleta = new PAPELETAEntities())
                {
                    var query = from p in Papeleta.TB_POLICIA
                                join r in Papeleta.TB_RANGO on p.COD_RANGO equals r.COD_RANGO
                                join u in Papeleta.TB_UBIGEO on p.COD_UBIGEO equals u.COD_UBIGEO into ubigeoJoin
                                from u in ubigeoJoin.DefaultIfEmpty()
                                select new PoliciaBE
                                {
                                    Cod_Policia = p.COD_POLICIA,
                                    Paterno = p.PATERNO,
                                    Materno = p.MATERNO,
                                    Nombre = p.NOMBRE,
                                    Dni = p.DNI,
                                    SexoTexto = p.SEXO == "M" ? "Masculino" : "Femenino",
                                    FechaNacimiento = (DateTime)p.FECHANACIMIENTO,
                                    Foto = p.FOTO,
                                    Rango = r.NOM_RANGO,
                                    Departamento = u != null ? u.DEPARTAMENTO : "-",
                                    Provincia = u != null ? u.PROVINCIA : "-",
                                    Distrito = u != null ? u.DISTRITO : "-",
                                    EstadoTexto = p.ESTADO == "A" ? "Activo" : "Inactivo"
                                };

                    if (!string.IsNullOrWhiteSpace(strFiltro))
                    {
                        query = query.Where(x =>
                            x.Cod_Policia.Contains(strFiltro) ||
                            x.Dni.Contains(strFiltro) ||
                            x.Nombre.Contains(strFiltro) ||
                            x.Paterno.Contains(strFiltro) ||
                            x.Materno.Contains(strFiltro));
                    }
                    return query
    .OrderBy(x => x.Paterno)
    .Skip((pagina - 1) * registrosPorPagina)
    .Take(registrosPorPagina)
    .ToList();
                }
            }
            catch (EntityException ex) { throw new Exception(ex.Message); }
        }

        public List<PoliciaBE> ListarPolicias(int pagina,
                                      int registrosPorPagina)
        {
            return BuscarPolicias(null, pagina, registrosPorPagina);
        }

        public int ContarPolicias(string strFiltro)
        {
            try
            {
                using (PAPELETAEntities Papeleta = new PAPELETAEntities())
                {
                    var query = from p in Papeleta.TB_POLICIA
                                join r in Papeleta.TB_RANGO on p.COD_RANGO equals r.COD_RANGO
                                join u in Papeleta.TB_UBIGEO on p.COD_UBIGEO equals u.COD_UBIGEO into ubigeoJoin
                                from u in ubigeoJoin.DefaultIfEmpty()
                                select new PoliciaBE
                                {
                                    Cod_Policia = p.COD_POLICIA,
                                    Dni = p.DNI,
                                    Nombre = p.NOMBRE,
                                    Paterno = p.PATERNO,
                                    Materno = p.MATERNO
                                };

                    if (!string.IsNullOrWhiteSpace(strFiltro))
                    {
                        query = query.Where(x =>
                            x.Cod_Policia.Contains(strFiltro) ||
                            x.Dni.Contains(strFiltro) ||
                            x.Nombre.Contains(strFiltro) ||
                            x.Paterno.Contains(strFiltro) ||
                            x.Materno.Contains(strFiltro));
                    }

                    return query.Count();
                }
            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool EliminarPolicia(string codPolicia, string usuario)
        {
            try
            {
                using (PAPELETAEntities PAPELETA = new PAPELETAEntities())
                {
                    PAPELETA.SP_ELIMINAR_POLICIA(
                        codPolicia,
                        usuario
                    );

                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public PoliciaBE ConsultarPolicia(string strCodigo)
        {
            try
            {
                PoliciaBE objPoliciaBE = new PoliciaBE();

                using (PAPELETAEntities PAPELETA = new PAPELETAEntities())
                {
                    var resultado =
                        (from p in PAPELETA.TB_POLICIA
                         join u in PAPELETA.TB_UBIGEO
                             on p.COD_UBIGEO equals u.COD_UBIGEO
                         where p.COD_POLICIA == strCodigo
                         select new { Policia = p, Ubigeo = u })
                         .FirstOrDefault();

                    if (resultado == null)
                    {
                        objPoliciaBE = null;
                    }
                    else
                    {
                        var p = resultado.Policia;

                        objPoliciaBE.Cod_Policia = p.COD_POLICIA;
                        objPoliciaBE.Nombre = p.NOMBRE;
                        objPoliciaBE.Paterno = p.PATERNO;
                        objPoliciaBE.Materno = p.MATERNO;
                        objPoliciaBE.Dni = p.DNI;

                        objPoliciaBE.Cod_Ubigeo = p.COD_UBIGEO;
                        objPoliciaBE.Cod_Rango = p.COD_RANGO ?? 0;
                        objPoliciaBE.Sexo = p.SEXO;
                        objPoliciaBE.Estado = p.ESTADO;

                        objPoliciaBE.FechaNacimiento = (DateTime)p.FECHANACIMIENTO;
                        objPoliciaBE.Foto = p.FOTO;

                        objPoliciaBE.Departamento = resultado.Ubigeo.DEPARTAMENTO;
                        objPoliciaBE.Provincia = resultado.Ubigeo.PROVINCIA;
                        objPoliciaBE.Distrito = resultado.Ubigeo.DISTRITO;

                        objPoliciaBE.Id_Depa = resultado.Ubigeo.ID_DEPA;
                        objPoliciaBE.Id_Prov = resultado.Ubigeo.ID_PROV;
                        objPoliciaBE.Id_Dist = resultado.Ubigeo.ID_DIST;
                    }
                }

                return objPoliciaBE;
            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool InsertarPolicia(PoliciaBE objPoliciaBE)
        {
            try
            {
                using (PAPELETAEntities PAPELETA = new PAPELETAEntities())
                {
                    PAPELETA.SP_INSERTAR_POLICIA(
                        objPoliciaBE.Nombre,
                        objPoliciaBE.Paterno,
                        objPoliciaBE.Materno,
                        objPoliciaBE.Dni,
                        objPoliciaBE.Cod_Ubigeo,
                        objPoliciaBE.Cod_Rango,
                        objPoliciaBE.Sexo,
                        objPoliciaBE.FechaNacimiento,
                        objPoliciaBE.Estado,
                        objPoliciaBE.Foto,
                        objPoliciaBE.Usu_Registro
                    );

                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ActualizarPolicia(PoliciaBE objPoliciaBE)
        {
            try
            {
                using (PAPELETAEntities PAPELETA = new PAPELETAEntities())
                {
                    PAPELETA.SP_ACTUALIZAR_POLICIA(
                        objPoliciaBE.Cod_Policia,
                        objPoliciaBE.Nombre,
                        objPoliciaBE.Paterno,
                        objPoliciaBE.Materno,
                        objPoliciaBE.Dni,
                        objPoliciaBE.Cod_Ubigeo,
                        objPoliciaBE.Cod_Rango,
                        objPoliciaBE.Sexo,
                        objPoliciaBE.FechaNacimiento,
                        objPoliciaBE.Estado,
                        objPoliciaBE.Foto,
                        objPoliciaBE.Usu_Ult_Modificacion
                    );

                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //PARTE TRANSACCION
        public PoliciaBE ConsultarPoliciaPorDni(string dni)
        {
            try
            {
                using (PAPELETAEntities Papeleta =
                    new PAPELETAEntities())
                {
                    return (
                        from p in Papeleta.TB_POLICIA
                        where p.DNI == dni
                        select new PoliciaBE
                        {
                            Cod_Policia =
                                p.COD_POLICIA,

                            Dni =
                                p.DNI,

                            Nombre =
                                p.NOMBRE,

                            Paterno =
                                p.PATERNO,

                            Materno =
                                p.MATERNO
                        }
                    ).FirstOrDefault();
                }
            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
