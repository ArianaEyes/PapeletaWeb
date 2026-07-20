using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapeletaWeb_BE
{
    public class VehiculoBE
    {
        public string Cod_Vehiculo { get; set; }
        public string Cod_Infractor { get; set; }
        public string Dni { get; set; }
        public string Infractor { get; set; }
        public string Cod_Marca { get; set; }
        public string Marca { get; set; }
        public string Cod_Color { get; set; }
        public string Color { get; set; }
        public string Tipo_Vehiculo { get; set; }
        public int Anio_Fabricacion { get; set; }
        public string Nro_Motor { get; set; }
        public byte[] Foto { get; set; }
        public DateTime Fec_Registro { get; set; }
        public string EstadoTexto { get; set; }
    }
}
