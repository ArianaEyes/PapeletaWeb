using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapeletaWeb_BE
{
    public class MultaBE
    {
        public string Cod_Papeleta { get; set; }
        public string Cod_Infractor { get; set; }
        public string Infractor { get; set; }
        public string Lugar_Infraccion { get; set; }
        public string Falta_Cometida { get; set; }
        public string Calificacion { get; set; }
        public decimal Uit { get; set; }
        public DateTime Fecha_Infraccion { get; set; }
        public string Policia { get; set; }
        public string Estado_Papeleta { get; set; } // PENDIENTE / CANCELADO
    }
}
