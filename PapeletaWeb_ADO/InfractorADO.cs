    using PapeletaWeb_BE;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Core;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace PapeletaWeb_ADO
    {
        public class InfractorADO
        {
            public InfractorBE ConsultarInfractor(String strCodigo)
            {
			    try
			    {
				    InfractorBE objInfractorBE = new InfractorBE();

				    using (PAPELETAEntities PAPELETA = new PAPELETAEntities())
				    {
					    var resultado = (
						    from i in PAPELETA.TB_INFRACTOR
						    join u in PAPELETA.TB_UBIGEO
						    on i.COD_UBIGEO equals u.COD_UBIGEO
						    where i.COD_INFRACTOR == strCodigo
						    select new { Infractor = i, Ubigeo = u }
						    ).FirstOrDefault();

					    if (resultado == null)
					    {
						    objInfractorBE = null;
					    }
					    else {
						    var i = resultado.Infractor;

						    objInfractorBE.Cod_Infractor = i.COD_INFRACTOR;
						    objInfractorBE.Dni = i.DNI;
						    objInfractorBE.Ape_Paterno = i.APE_PATERNO;
						    objInfractorBE.Ape_Materno = i.APE_MATERNO;
						    objInfractorBE.Nombres = i.NOMBRES;
						    objInfractorBE.Correo = i.CORREO;
						    objInfractorBE.Direccion = i.DIRECCION;
						    objInfractorBE.Fec_Nacimiento = (DateTime)i.FEC_NACIMIENTO;
						    objInfractorBE.Nro_Brevete = i.NRO_BREVETE;
						    objInfractorBE.Tipo_Brevete = i.TIPO_BREVETE;
						    objInfractorBE.Foto = i.FOTO;

						    objInfractorBE.SexoTexto = (i.SEXO == "M") ? "MASCULINO" : "FEMENINO";
						    objInfractorBE.EstadoTexto = (i.ESTADO == "A") ? "ACTIVO" : "INACTIVO";

                        objInfractorBE.Cod_Ubigeo = i.COD_UBIGEO;

                        objInfractorBE.Id_Depa = resultado.Ubigeo.ID_DEPA;
                        objInfractorBE.Id_Prov = resultado.Ubigeo.ID_PROV;
                        objInfractorBE.Id_Dist = resultado.Ubigeo.ID_DIST;

                        objInfractorBE.Sexo = i.SEXO;
                        objInfractorBE.Estado = i.ESTADO;

                        objInfractorBE.Departamento = resultado.Ubigeo.DEPARTAMENTO;
                        objInfractorBE.Provincia = resultado.Ubigeo.PROVINCIA;
                        objInfractorBE.Distrito = resultado.Ubigeo.DISTRITO;
                    }
				    }

				    return objInfractorBE;
			    }
                catch (EntityException ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            public List<InfractorBE> ListarInfractores(int pagina,
                                               int registrosPorPagina)
            {
                return BuscarInfractores(null, pagina, registrosPorPagina);
            }

            public List<InfractorBE> BuscarInfractores(string strFiltro,
                                               int pagina,
                                               int registrosPorPagina)
            {
                try
                {
                    List<InfractorBE> objLista = new List<InfractorBE>();

                    using (PAPELETAEntities PAPELETA = new PAPELETAEntities())
                    {
                        var query = PAPELETA.TB_INFRACTOR.AsQueryable();

                        if (!string.IsNullOrWhiteSpace(strFiltro))
                        {
                            query = query.Where(i =>
                                i.COD_INFRACTOR.Contains(strFiltro) ||
                                i.DNI.Contains(strFiltro) ||
                                i.NOMBRES.Contains(strFiltro) ||
                                i.APE_PATERNO.Contains(strFiltro) ||
                                i.APE_MATERNO.Contains(strFiltro));
                        }

                        var resultado = query
                            .OrderBy(i => i.NOMBRES)
                            .Skip((pagina - 1) * registrosPorPagina)
                            .Take(registrosPorPagina)
                            .ToList();

                        foreach (var i in resultado)
                        {
                            objLista.Add(new InfractorBE
                            {
                                Cod_Infractor = i.COD_INFRACTOR,
                                Dni = i.DNI,
                                Nombres = i.NOMBRES,
                                Ape_Paterno = i.APE_PATERNO,
                                Ape_Materno = i.APE_MATERNO,
                                Correo = i.CORREO,
                                Direccion = i.DIRECCION,
                                Nro_Brevete = i.NRO_BREVETE,
                                Tipo_Brevete = i.TIPO_BREVETE,
                                Fec_Registro = (DateTime)i.FEC_REGISTRO,
                                EstadoTexto = i.ESTADO == "A" ? "Activo" : "Inactivo"
                            });
                        }
                    }

                    return objLista;
                }
                catch (EntityException ex)
                {
                    throw new Exception(ex.Message);
                }
            }
   
        public int ContarInfractores(string strFiltro)
            {
                try
                {
                    using (PAPELETAEntities PAPELETA = new PAPELETAEntities())
                    {
                        var query = PAPELETA.TB_INFRACTOR.AsQueryable();

                        if (!string.IsNullOrWhiteSpace(strFiltro))
                        {
                            query = query.Where(i =>
                                i.COD_INFRACTOR.Contains(strFiltro) ||
                                i.DNI.Contains(strFiltro) ||
                                i.NOMBRES.Contains(strFiltro) ||
                                i.APE_PATERNO.Contains(strFiltro) ||
                                i.APE_MATERNO.Contains(strFiltro));
                        }

                        return query.Count();
                    }
                }
                catch (EntityException ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        public bool InsertarInfractor(InfractorBE objInfractorBE)
        {
            try
            {
                using (PAPELETAEntities PAPELETA = new PAPELETAEntities())
                {
                    PAPELETA.SP_INSERTAR_INFRACTOR(
                        objInfractorBE.Dni,
                        objInfractorBE.Ape_Paterno,
                        objInfractorBE.Ape_Materno,
                        objInfractorBE.Nombres,
                        objInfractorBE.Correo,
                        objInfractorBE.Direccion,
                        objInfractorBE.Cod_Ubigeo,
                        objInfractorBE.Sexo,
                        objInfractorBE.Fec_Nacimiento,
                        objInfractorBE.Foto,
                        objInfractorBE.Estado,
                        objInfractorBE.Nro_Brevete,
                        objInfractorBE.Tipo_Brevete,
                        objInfractorBE.Usu_Registro
                    );

                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ActualizarInfractor(InfractorBE objInfractorBE)
        {
            try
            {
                using (PAPELETAEntities PAPELETA = new PAPELETAEntities())
                {
                    PAPELETA.SP_ACTUALIZAR_INFRACTOR(
                        objInfractorBE.Cod_Infractor,
                        objInfractorBE.Dni,
                        objInfractorBE.Ape_Paterno,
                        objInfractorBE.Ape_Materno,
                        objInfractorBE.Nombres,
                        objInfractorBE.Correo,
                        objInfractorBE.Direccion,
                        objInfractorBE.Cod_Ubigeo,
                        objInfractorBE.Sexo,
                        objInfractorBE.Fec_Nacimiento,
                        objInfractorBE.Foto,
                        objInfractorBE.Nro_Brevete,
                        objInfractorBE.Tipo_Brevete,
                        objInfractorBE.Estado,
                        "ADMIN"
                    );

                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EliminarInfractor(string codigo, string usuario)
        {
            try
            {
                using (PAPELETAEntities PAPELETA = new PAPELETAEntities())
                {
                    PAPELETA.SP_ELIMINAR_INFRACTOR(codigo, usuario);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
