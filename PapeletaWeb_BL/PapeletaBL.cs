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

        //PARTE TRANSACCION

        public string InsertarPapeleta(
    PapeletaBE objPapeleta)
        {
            if (objPapeleta == null)
            {
                throw new Exception(
                    "No se recibieron los datos de la papeleta."
                );
            }

            if (string.IsNullOrWhiteSpace(
                objPapeleta.Cod_Infraccion))
            {
                throw new Exception(
                    "Debe seleccionar una infracción."
                );
            }

            if (string.IsNullOrWhiteSpace(
                objPapeleta.Cod_Policia))
            {
                throw new Exception(
                    "Debe identificar al policía."
                );
            }

            if (string.IsNullOrWhiteSpace(
                objPapeleta.Cod_Vehiculo))
            {
                throw new Exception(
                    "Debe indicar el vehículo."
                );
            }

            if (string.IsNullOrWhiteSpace(
                objPapeleta.Lugar_Infraccion))
            {
                throw new Exception(
                    "Debe ingresar el lugar de la infracción."
                );
            }

            DateTime fechaHora =
                objPapeleta.Fecha_Infraccion.Date
                    .Add(
                        objPapeleta.Hora_Infraccion
                    );

            if (fechaHora > DateTime.Now)
            {
                throw new Exception(
                    "La fecha y hora de la infracción no pueden ser futuras."
                );
            }

            return objPapeletaADO.InsertarPapeleta(
                objPapeleta
            );
        }
    }
}