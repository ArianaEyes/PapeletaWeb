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
        public List<PoliciaBE> BuscarPolicias(string strFiltro)
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

                    return query.OrderBy(x => x.Paterno).ToList();
                }
            }
            catch (EntityException ex) { throw new Exception(ex.Message); }
        }

        public List<PoliciaBE> ListarPolicias() => BuscarPolicias(null);
    }
}
