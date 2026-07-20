using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapeletaWeb_BE
{
    public class PoliciaBE
    {
        public string Cod_Policia { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public string Nombre { get; set; }
        public string Dni { get; set; }
        public string SexoTexto { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public byte[] Foto { get; set; }
        public string Rango { get; set; }
        public string Departamento { get; set; }
        public string Provincia { get; set; }
        public string Distrito { get; set; }
        public string EstadoTexto { get; set; }
    }
}
