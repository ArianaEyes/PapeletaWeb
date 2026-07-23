using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapeletaWeb_BE
{
    public class InfraccionBE
    {
        public string Cod_Infraccion { get; set; }
        public string Descripcion_Sancion { get; set; }
        public string Calificacion { get; set; }
        public int Puntos { get; set; }
        public decimal Uit { get; set; }
        public string Medida_Preventiva { get; set; }
        public string EstadoTexto { get; set; }
        public string Estado { get; set; }
    }
}
