using PapeletaWeb_ADO;
using PapeletaWeb_BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapeletaWeb_BL
{
    public class VehiculoBL
    {
        VehiculoADO objVehiculoADO = new VehiculoADO();

        public List<VehiculoBE> ListarVehiculos(int pagina, int registrosPorPagina)
        {
            return objVehiculoADO.ListarVehiculos(pagina, registrosPorPagina);
        }

        public List<VehiculoBE> BuscarVehiculos(string filtro,
                                                int pagina,
                                                int registrosPorPagina)
        {
            return objVehiculoADO.BuscarVehiculos(filtro,
                                                  pagina,
                                                  registrosPorPagina);
        }

        public int ContarVehiculos(string filtro)
        {
            return objVehiculoADO.ContarVehiculos(filtro);
        }

        public List<MarcaBE> ListarMarcas() => objVehiculoADO.ListarMarcas();
        public List<ColorBE> ListarColores() => objVehiculoADO.ListarColores();
        public List<TipoVehiculoBE> ListarTiposVehiculo() => objVehiculoADO.ListarTiposVehiculo();
        public bool InsertarVehiculo(VehiculoBE obj) => objVehiculoADO.InsertarVehiculo(obj);

        public VehiculoBE ObtenerVehiculo(string codigo)
        {
            return objVehiculoADO.ObtenerVehiculo(codigo);
        }

        public bool ActualizarVehiculo(VehiculoBE obj)
        {
            return objVehiculoADO.ActualizarVehiculo(obj);
        }

        public bool EliminarVehiculo(string codigo)
        {
            return objVehiculoADO.EliminarVehiculo(codigo);
        }
    }
}