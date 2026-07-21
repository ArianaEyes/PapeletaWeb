using PapeletaWeb_ADO;
using PapeletaWeb_BE;
using System;
using System.Collections.Generic;

namespace PapeletaWeb_BL
{
    public class PapeletaBL
    {
        PapeletaADO objPapeletaADO = new PapeletaADO();

        public List<MultaBE> ListarMultasPorInfractor(string cod, DateTime ini, DateTime fin)
            => objPapeletaADO.ListarMultasPorInfractor(cod, ini, fin);

        public List<MultaBE> ListarMultasPorVehiculo(string cod, DateTime ini, DateTime fin)
            => objPapeletaADO.ListarMultasPorVehiculo(cod, ini, fin);

        public List<MultaBE> ListarMultasPorPolicia(string cod, DateTime ini, DateTime fin)
            => objPapeletaADO.ListarMultasPorPolicia(cod, ini, fin);

        public decimal CalcularUitPendiente(string cod, DateTime ini, DateTime fin)
            => objPapeletaADO.CalcularUitPendiente(cod, ini, fin);

        public (int pendientes, int canceladas) ContarPorEstado(string cod, DateTime ini, DateTime fin)
            => objPapeletaADO.ContarPorEstado(cod, ini, fin);

        public string ObtenerFaltaMasFrecuente(string cod, DateTime ini, DateTime fin)
            => objPapeletaADO.ObtenerFaltaMasFrecuente(cod, ini, fin);

        public List<MultaBE> BuscarPapeletas(string filtro, int pagina, int registrosPorPagina)
            => objPapeletaADO.BuscarPapeletas(filtro, pagina, registrosPorPagina);

        public int ContarPapeletas(string filtro)
            => objPapeletaADO.ContarPapeletas(filtro);

        public List<MultaBE> ListarPapeletas(int pagina, int registrosPorPagina)
            => objPapeletaADO.ListarPapeletas(pagina, registrosPorPagina);
    }
}